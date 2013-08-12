﻿using System.Net;
using OpenStory.Framework.Contracts;
using OpenStory.Services;

namespace OpenStory.Server.Auth
{
    /// <summary>
    /// Represents an AuthOperator configuration.
    /// </summary>
    public sealed class AuthConfiguration : ServerConfiguration
    {
        /// <inheritdoc />
        public AuthConfiguration(ServiceConfiguration configuration)
            : base(configuration)
        {
        }
    }
}
