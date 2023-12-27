namespace DomainDrivenDesign.SDK;

/// <summary>
/// Represents the unit of work implementation interface for domain aggregates.
/// </summary>
public interface IUnitOfWork : IDisposable {

    /// <summary>
    /// Saves all changes made in the domain aggregate context.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while 
    /// waiting for the task to complete.</param>
    /// <returns>A <see cref="Task{TResult}"/> that represents the asynchronous save operation. 
    /// The task result contains the number of state entries written in the domain aggregate context.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Dispatches all the existing domain entity events and saves all the changes made to the domain aggregate
    /// context.
    /// </summary>
    /// <param name="cancellationToken">A <see cref="CancellationToken"/> to observe while 
    /// waiting for the task to complete.</param>
    /// <returns>Returns <see langword="true"/> when all domain entity events are dispatched successfully
    /// and when all the changes made to the domain aggregate were successfully saved; 
    /// <see langword="false"/> otherwise.</returns>
    Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default);

}
