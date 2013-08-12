using System;
using System.ComponentModel;

namespace OpenStory.Framework.Contracts
{
    /// <summary>
    /// Represents connection information for a nexus service.
    /// </summary>
    [Localizable(true)]
    public sealed class NexusConnectionInfo
    {
        /// <summary>
        /// Gets the access token required to communicate with the Nexus service.
        /// </summary>
        public Guid AccessToken { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NexusConnectionInfo"/> class.
        /// </summary>
        public NexusConnectionInfo(Guid accessToken)
        {
            this.AccessToken = accessToken;
        }
    }
}