using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Threading.Tasks;

namespace Laboratorio14_analsis_disenio
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WebService1 : System.Web.Services.WebService
    {
        private static int lastOrderId = 0;
        [WebMethod]
        public string CreateOrder(string sandwichType, int quantity, string address)
        {
            int orderId = GenerateOrderId();
            // Aquí iría la lógica para guardar el pedido
            return $"Pedido [ID: {orderId}] de {quantity} sándwiches tipo {sandwichType} ha sido realizado a la dirección {address}.";
        }
        private int GenerateOrderId()
        {
            // Incrementar el ID de la última orden y retornarlo
            return ++lastOrderId;
        }

        [WebMethod]
        public string GetOrderDetails(int orderId)
        {
            // Aquí iría la lógica para recuperar detalles del pedido
            return $"Detalles del Pedido ID: {orderId}";
        }
    }

}

