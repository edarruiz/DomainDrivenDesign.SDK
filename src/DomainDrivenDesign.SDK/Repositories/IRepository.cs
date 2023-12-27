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

    /// <summary>
    /// Adds an entity to the domain aggregate.
    /// </summary>
    /// <typeparam name="TEntity">Type of the entity to be added to the aggregate.</typeparam>
    /// <param name="entity">An entity to be added to the aggregate.</param>
    /// <returns>Returns the entity newly added to the aggregate.</returns>
    TEntity Add<TEntity>(TEntity entity) where TEntity : IEntity;

    /// <summary>
    /// Updates an entity's information in the domain aggregate.
    /// </summary>
    /// <typeparam name="TEntity">Type of the entity to be updated in the aggregate.</typeparam>
    /// <param name="entity">An entity to be updated in the aggregate.</param>
    /// <returns>Returns <see langword="true"/> if the entity was successfully updated
    /// in the aggregate; <see langword="false"/> othwerwise.</returns>
    bool Update<TEntity>(TEntity entity) where TEntity : IEntity;

    /// <summary>
    /// Remove an entity from the aggregate.
    /// </summary>
    /// <typeparam name="TEntity">Type of the entity to be removed from the aggregate.</typeparam>
    /// <param name="entity">An entity to be removed from the aggregate.</param>
    /// <returns>Returns <see langword="true"/> if the entity is successfully removed
    /// from the aggregate; <see langword="false"/> otherwise.</returns>
    bool Delete<TEntity>(TEntity entity) where TEntity : IEntity;

}
