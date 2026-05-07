using Domain.Entities;

public class InMemoryCustomerRepository : ICustomerRepository {
    // Armazena clientes em memória durante a execução da aplicação.
    private readonly List<Customer> _customers = new();

    public void Save(Customer customer) {
        // Adiciona o cliente à lista em memória.
        _customers.Add(customer);
    }

    public IEnumerable<Customer> GetAll() {
        // Retorna todos os clientes armazenados atualmente.
        return _customers;
    }

    public Customer? GetById(Guid id) {
        // Busca na lista um cliente cujo Id corresponde ao informado.
        return _customers.FirstOrDefault(c => c.Id == id);
    }
}