using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stratergy_Csharp
{
    public class CustomerDataModel { public string ID { get; set; }  public string Name{get;set;}}

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

        //public List<CustomerDataModel> GetCustomers(List<ISearchFillter> filter)
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

    public class CompositeStratergy:ISearchFilter{
       List<ISearchFilter> _filters=new List<ISerachFilter>();
        public bool Filter(CustomerDataModel model)
        {
                foreach(){
                    
                }
        }
        public void AddFilterStratergy(ISearchFilter filter){
         this._filters.Add(filter);   
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
        string _name;
        public NameSearchStratergy(string name){
                this._name=name;
        }
        public bool Filter(CustomerDataModel model)
        {
            //
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CustomerService _service = new CustomerService();
            _service.GetCustomers(new IDSearchStrategry("C1000"));
            _service.GetCustomers(new NameSearchStratergy("Tom"));
            var compositeStratergy=new CompositeStratergy();
            compositeStratergy.Add(new  IDSearchStrategry("C1000"));
            compositeStratergy.Add(new  NameSearchStrategry("C1000"));
            _service.GetCustomers(compositeStratergy);
            
            
            
            
        }
    }
}
