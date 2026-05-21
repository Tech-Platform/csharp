namespace Domain.Entities;

public class Customer {
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; }
    public string Email { get; private set; }

    public Customer(string name, string email) {
        Name = name;
        Email = email;
    }

    public void Update(string name, string email)
    {
        Name = name;
        Email = email;
    }
}

