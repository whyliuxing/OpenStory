﻿using Ninject.Extensions.Factory;
using Ninject.Modules;
using OpenStory.Framework.Contracts;
using OpenStory.Server.Processing;
using OpenStory.Server.Registry;
using OpenStory.Services;

namespace OpenStory.Server
{
    /// <summary>
    /// Basic server module.
    /// </summary>
    public class ServerModule : NinjectModule
    {
        /// <inheritdoc />
        public override void Load()
        {
            // No dependencies:
            Bind<IPlayerRegistry>().To<PlayerRegistry>();
            Bind<ILocationRegistry>().To<LocationRegistry>();

            // PacketFactory requires IPacketCodeTable
            Bind<IPacketFactory>().To<PacketFactory>();

            // ServerSession requires IPacketCodeTable and ILogger
            Bind<IServerSession>().To<ServerSession>();
            Bind<IServerSessionFactory>().ToFactory();

            // ServerProcess requires ServiceConfiguration, IServerSessionFactory and ILogger
            Bind<IServerProcess>().To<ServerProcess>();

            Bind<GameServiceBase>().To<GameServer>();

            // IGameServiceFactory requires GameServiceBase.
            Bind<IGameServiceFactory>().ToFactory();

            // Bootstrapper.
            Bind<Bootstrapper>().ToSelf().InSingletonScope();
        }
    }
}
