﻿using System.ServiceModel;
using OpenStory.Server.Auth;
using OpenStory.Services.Wcf;

namespace OpenStory.Services.Auth
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    internal sealed class AuthService : RegisteredServiceBase<AuthServer>
    {
        private readonly NexusConnectionInfo nexusConnectionInfo;

        public AuthService(AuthServer authServer, NexusConnectionInfo nexusConnectionInfo)
            : base(authServer)
        {
            this.nexusConnectionInfo = nexusConnectionInfo;
        }
    }
}
