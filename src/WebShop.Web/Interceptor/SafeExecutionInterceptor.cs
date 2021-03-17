using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
using System;
using WebShop.Web.Exceptions;

namespace WebShop.Web.Interceptor
{
    public class SafeExecutionInterceptor : IInterceptor
    {
        private readonly ILogger<SafeExecutionInterceptor> _logger;

        public SafeExecutionInterceptor(ILogger<SafeExecutionInterceptor> logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                _logger.LogInformation($"Begin execution of method: {invocation.TargetType}.{ invocation.Method.Name} ");

                invocation.Proceed();

                _logger.LogInformation($"End execution of method: {invocation.TargetType}.{ invocation.Method.Name}");
            }
            catch (NotEnoughBalanceException ex)
            {
                _logger.LogInformation("not enough balance error", ex);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogCritical("error", ex);
                throw;
            }
        }
    }
}
