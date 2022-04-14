using Models;

namespace DL;

public interface IRepository
{
    Customer CreateCustomer(Customer newCustomer);
    int LoginValid(Customer login);
    Customer GetCustomer(Customer customer);
    Product CreateProduct(Product newProduct);
    Product GetProduct(int id);
    List<Product> GetProducts(StoreFrontId getProduct);
    List<StoreFrontId> GetStoreFrontIdFronts();
    Order UpdateOrders(Order updateOrder);
    List<StoreFrontId> GetStoreFrontIds();
}
