using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratergy_Csharp
{
    public class CustomerDataModel { public string ID { get; set; } }

    public interface ISearchFillter
    {
        bool Filter(CustomerDataModel model);
    }
    public class CustomerService
    {
        //CRUD
        List<CustomerDataModel> _customers = new List<CustomerDataModel>();
        public void CreateNewCustomer(CustomerDataModel model)
        {
            _customers.Add(model);

        }

        public List<CustomerDataModel> GetCustomers(ISearchFillter filter)
        {
            if (filter == null)
            {
                return _customers;
            }
            var _filteredList = new List<CustomerDataModel>();
            foreach(var customer in _customers)
            {
                if (filter.Filter(customer))
                {
                    _filteredList.Add(customer);

                }
            }
            return _filteredList;
        }
    


    }

    public class IDSearchStrategry : ISearchFillter
    {
        string id;
        public IDSearchStrategry(string id)
        {
            this.id = id;
        }
        public bool Filter(CustomerDataModel model)
        {
            return model.ID == this.id;
        }
    }
    public class NameSearchStratergy : ISearchFillter
    {
        public bool Filter(CustomerDataModel model)
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CustomerService _service = new CustomerService();
            _service.GetCustomers(new IDSearchStrategry("C1000"));
            _service.GetCustomers(new NameSearchStratergy("Tom"));
        }
    }
}
