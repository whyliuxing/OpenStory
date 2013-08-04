using System.Collections.Generic;
using System.Linq;
using OpenStory.Common.Game;
using OpenStory.Framework.Contracts;
using OpenStory.Server.Processing;

namespace OpenStory.Server.Auth
{
    internal sealed class AuthOperator : ServerOperator<AuthClient>, IAuthServer
    {
        private readonly IClientFactory<AuthClient> clientFactory;

        private readonly List<IWorld> worlds;

        public AuthOperator(IClientFactory<AuthClient> clientFactory)
        {
            this.clientFactory = clientFactory;

            this.worlds = new List<IWorld>();
        }

        #region IAuthServer Members

        /// <inheritdoc />
        public IWorld GetWorldById(int worldId)
        {
            return this.worlds.First(w => w.Id == worldId);
        }

        #endregion

        public override void Configure(ServiceConfiguration configuration)
        {
        }

        /// <inheritdoc />
        protected override AuthClient CreateClient(IServerSession session)
        {
            return this.clientFactory.CreateClient(session);
        }
    }
}
