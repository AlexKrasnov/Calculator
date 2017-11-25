using System;
using System.Collections.Generic;

namespace Calculator
{
    /// <summary>
    /// Реализует IServiceProvider для приложения. Этот тип предоставляется через свойство App.Services
    /// и может использоваться для ContentManagers или других типов, которым требуется доступ к IServiceProvider.
    /// </summary>
    public class AppServiceProvider : IServiceProvider
    {
        // Сопоставление типа служб с самими службами
        private readonly Dictionary<Type, object> services = new Dictionary<Type, object>();

        /// <summary>
        /// Добавляет новую службу поставщику услуг.
        /// </summary>
        /// &lt;param name="serviceType"&gt;Тип добавляемой службы.</param>
        /// &lt;param name="service"&gt;Сам объект службы.</param>
        public void AddService(Type serviceType, object service)
        {
            // Проверьте входные данные
            if (serviceType == null)
                throw new ArgumentNullException("serviceType");
            if (service == null)
                throw new ArgumentNullException("service");
            if (!serviceType.IsAssignableFrom(service.GetType()))
                throw new ArgumentException("service does not match the specified serviceType");

            // Добавьте службу в словарь
            services.Add(serviceType, service);
        }

        /// <summary>
        /// Возвращает службу от поставщика услуг.
        /// </summary>
        /// &lt;param name="serviceType"&gt;Тип возвращаемой службы.</param>
        /// <returns>Объект службы, зарегистрированный для указанного типа.</returns>
        public object GetService(Type serviceType)
        {
            // Проверьте входные данные
            if (serviceType == null)
                throw new ArgumentNullException("serviceType");

            // Получите службу из словаря
            return services[serviceType];
        }

        /// <summary>
        /// Удаляет службу у поставщика услуг.
        /// </summary>
        /// &lt;param name="serviceType"&gt;Тип удаляемой службы.</param>
        public void RemoveService(Type serviceType)
        {
            // Проверьте входные данные
            if (serviceType == null)
                throw new ArgumentNullException("serviceType");

            // Удалите службу из словаря
            services.Remove(serviceType);
        }
    }
}
