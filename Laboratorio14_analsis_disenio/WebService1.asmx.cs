using System;
using System.Web.Services;
using Newtonsoft.Json;

namespace Laboratorio14_analsis_disenio
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class WebService1 : System.Web.Services.WebService
    {
        private static int lastOrderId = 0;
        private static int quantity = 0;
        private static string sandwichType = "";
        private static string address = "";

        [WebMethod]
        public string CreateOrder(int quantity, string sandwichType, string address)
        {
            int orderId = GenerateOrderId();

            // Guardar los datos de la orden en las variables estáticas
            WebService1.quantity = quantity;
            WebService1.sandwichType = sandwichType;
            WebService1.address = address;

            // Crear un objeto Order con los datos proporcionados
            Order order = new Order(orderId, quantity, sandwichType, address);

            // Convertir el objeto Order a JSON
            string jsonOrder = JsonConvert.SerializeObject(order);

            return jsonOrder;
        }

        private int GenerateOrderId()
        {
            // Incrementar el ID de la última orden y retornarlo
            return ++lastOrderId;
        }

        [WebMethod]
        public string GetOrderDetails(int orderId)
        {
            // Aquí iría la lógica para recuperar detalles del pedido basados en el orderId

            // Obtener los datos de la orden de las variables estáticas
            int quantity = WebService1.quantity;
            string sandwichType = WebService1.sandwichType;
            string address = WebService1.address;

            // Crear un objeto Order con los datos obtenidos
            Order orderDetails = new Order(orderId, quantity, sandwichType, address);

            // Convertir el objeto Order a JSON
            string jsonOrderDetails = JsonConvert.SerializeObject(orderDetails);

            return jsonOrderDetails;
        }
    }

    // Clase para almacenar detalles de la orden
    public class Order
    {
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public string SandwichType { get; set; }
        public string Address { get; set; }

        // Constructor
        public Order(int orderId, int quantity, string sandwichType, string address)
        {
            OrderId = orderId;
            Quantity = quantity;
            SandwichType = sandwichType;
            Address = address;
        }
    }
}
