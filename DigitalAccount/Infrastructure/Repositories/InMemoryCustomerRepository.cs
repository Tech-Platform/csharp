using Domain.Entities;

public class InMemoryCustomerRepository : ICustomerRepository {
    // Armazena clientes em memória durante a execução da aplicação.
    private readonly List<Customer> _customers = new();

    public void Save(Customer customer) {
        _customers.Add(customer);
    }

    public IEnumerable<Customer> GetAll() {
        return _customers;
    }

    public Customer? GetById(Guid id) {
        return _customers.FirstOrDefault(c => c.Id == id);
    }

    public bool Update(Guid id, string name, string email)
    {
        var existing = GetById(id);
        if (existing == null) return false;
        existing.Update(name, email);
        return true;
    }

    public bool Delete(Guid id)
    {
        var removed = _customers.RemoveAll(c => c.Id == id);
        return removed > 0;
    }
}