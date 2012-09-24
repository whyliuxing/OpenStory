using System;
using System.ServiceModel;

namespace OpenStory.Services.Contracts
{
    /// <summary>
    /// Provides methods for Game Service Registration
    /// </summary>
    [ServiceContract(Namespace = null, Name = "RegistryService")]
    public interface IRegistryService
    {
        /// <summary>
        /// Attempts to register an authentication service module.
        /// </summary>
        /// <param name="uri">The URI for the service.</param>
        /// <param name="token">A variable to hold an access token for this registration.</param>
        /// <returns>an instance of <see cref="ServiceOperationResult"/>.</returns>
        ServiceOperationResult TryRegisterAuthService(Uri uri, out Guid token);

        /// <summary>
        /// Attempts to register an account service module.
        /// </summary>
        /// <param name="uri">The URI for the service.</param>
        /// <param name="token">A variable to hold an access token for this registration.</param>
        /// <returns>an instance of <see cref="ServiceOperationResult"/>.</returns>
        ServiceOperationResult TryRegisterAccountService(Uri uri, out Guid token);

        /// <summary>
        /// Attempts to register a world service module.
        /// </summary>
        /// <param name="uri">The URI for the service.</param>
        /// <param name="worldId">The public world identifier for the service instance.</param>
        /// <param name="token">A variable to hold an access token for this registration.</param>
        /// <returns>an instance of <see cref="ServiceOperationResult"/>.</returns>
        ServiceOperationResult TryRegisterWorldService(Uri uri, int worldId, out Guid token);

        /// <summary>
        /// Attempts to register a channel service module.
        /// </summary>
        /// <param name="uri">The URI for the service.</param>
        /// <param name="worldId">The public world identifier for the service instance.</param>
        /// <param name="channelId">The public channel identifier for the channel instance.</param>
        /// <param name="token">A variable to hold an access token for this registration.</param>
        /// <returns>an instance of <see cref="ServiceOperationResult"/>.</returns>
        ServiceOperationResult TryRegisterChannelService(Uri uri, int worldId, int channelId, out Guid token);

        /// <summary>
        /// Attempts to unregister the service with the specified token.
        /// </summary>
        /// <param name="registrationToken">The registration token issued when the service was registered.</param>
        /// <returns>an instance of <see cref="ServiceOperationResult"/>.</returns>
        ServiceOperationResult TryUnregisterService(Guid registrationToken);
    }
}