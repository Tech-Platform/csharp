using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase {
    private readonly ICustomerRepository _repository;
    private readonly AddCustomerUseCase _addUseCase;
    private readonly UpdateCustomerUseCase _updateUseCase;
    private readonly DeleteCustomerUseCase _deleteUseCase;

    public CustomerController(ICustomerRepository repository, AddCustomerUseCase addUseCase, UpdateCustomerUseCase updateUseCase, DeleteCustomerUseCase deleteUseCase) {
        _repository = repository;
        
        _addUseCase = addUseCase;
        _updateUseCase = updateUseCase;
        _deleteUseCase = deleteUseCase;
    }

    [HttpPost]
    public IActionResult Create(string name, string email) {
        _addUseCase.Execute(name, email);
        return Ok($"Cliente {name} com email {email} criado com sucesso no MVP!");
    }

    [HttpGet]
    public IActionResult GetAll() {
        var customers = _repository.GetAll();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id) {
        var customer = _repository.GetById(id);
        if (customer == null) return NotFound();
        return Ok(customer);
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, string name, string email)
    {
        var success = _updateUseCase.Execute(id, name, email);
        if (!success) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var success = _deleteUseCase.Execute(id);
        if (!success) return NotFound();
        return NoContent();
    }
}