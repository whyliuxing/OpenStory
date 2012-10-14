﻿using OpenStory.Common.Game;

namespace OpenStory.Server.Channel
{
    internal sealed partial class Player : IPlayer
    {
        #region Visible info

        public int WorldId { get; private set; }

        public Gender Gender { get; private set; }
        public int HairId { get; private set; }
        public int FaceId { get; private set; }
        public int SkinColor { get; private set; }

        public int Fame { get; private set; }

        public int CharacterId { get; private set; }
        public string CharacterName { get; private set; }
        public int JobId { get; private set; }
        public int Level { get; private set; }

        public int ChannelId { get; private set; }
        public int MapId { get; private set; }

        #endregion

        public int Meso { get; private set; }
        public int Experience { get; private set; }

        public ChannelClient Client { get; private set; }

        private Player(ChannelClient client, ChannelCharacter character)
        {
            this.Client = client;

            // Get what we can from the transfer object.
            this.CharacterId = character.Id;
            this.CharacterName = character.Name;
            this.WorldId = character.WorldId;

            this.Gender = character.Gender;
            this.HairId = character.HairId;
            this.FaceId = character.FaceId;
            this.SkinColor = character.SkinColor;

            this.JobId = character.JobId;
            this.Fame = character.Fame;
            this.Level = character.Level;

            // TODO: There are still more things to add to ChannelCharacter
        }

        /// <summary>
        /// Gets the extension object of this player instance for the specified key.
        /// </summary>
        /// <typeparam name="TPlayerExtension">The type of the extension interface.</typeparam>
        /// <param name="key">The key for the extension.</param>
        /// <returns>an instance of <typeparamref name="TPlayerExtension"/>.</returns>
        TPlayerExtension GetExtension<TPlayerExtension>(string key)
            where TPlayerExtension : IPlayerExtension
        {
            throw new System.NotImplementedException();
        }
    }
}
