﻿using System;
using System.ServiceModel;

namespace OpenStory.ServiceModel
{
    /// <summary>
    /// Provides basic methods for game services.
    /// </summary>
    [ServiceContract(Namespace = null)]
    public interface IGameService
    {
        /// <summary>
        /// Starts the service.
        /// </summary>
        [OperationContract]
        [FaultContract(typeof(InvalidOperationException))]
        void Start();

        /// <summary>
        /// Stops the service.
        /// </summary>
        [OperationContract]
        [FaultContract(typeof(InvalidOperationException))]
        void Stop();

        /// <summary>
        /// Pings the service.
        /// </summary>
        /// <returns>true if the service is running; otherwise, false.</returns>
        [OperationContract]
        bool Ping();
    }
}