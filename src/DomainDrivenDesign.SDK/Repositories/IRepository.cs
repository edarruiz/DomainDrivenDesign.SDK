namespace DomainDrivenDesign.SDK;

/// <summary>
/// Represents the domain repositories implementation interface.
/// </summary>
/// <typeparam name="TAggregateRoot">Represents the aggregate root entity of 
/// the repository.</typeparam>
internal interface IRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot {

    /// <summary>
    /// Gets the aggregate unit of work.
    /// </summary>
    IUnitOfWork UnitOfWork { get; }

}
