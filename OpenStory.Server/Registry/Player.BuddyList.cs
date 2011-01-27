﻿using System;
using System.Linq;
using OpenStory.Common.IO;
using OpenStory.Server.Data;
using Session = OpenStory.Networking.EncryptedNetworkSession;

namespace OpenStory.Server.Registry
{
    partial class Player
    {
        public void HandleBuddyOperation(PacketReader reader, Session session)
        {
            var operation = (BuddyOperation) reader.ReadByte();

            switch (operation)
            {
                case BuddyOperation.AddBuddy:
                    this.HandleAddBuddy(reader, session);
                    return;
                case BuddyOperation.AcceptRequest:
                    return;
                case BuddyOperation.RemoveBuddy:
                    return;
            }

            // If the operation is undefined...
            session.Close();
        }

        private void HandleAddBuddy(PacketReader reader, Session session)
        {
            string name;
            if (!reader.TryReadLengthString(out name) || name.Length > 12)
            {
                session.Close();
                return;
            }

            string groupName;
            if (!reader.TryReadLengthString(out groupName) || groupName.Length > 15)
            {
                session.Close();
                return;
            }

            Buddy entry = this.buddyList.FirstOrDefault(
                buddy => buddy.CharacterName.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (entry != null)
            {
                SendBuddyListOperationResult(session, BuddyOperationResult.AlreadyOnList);
                return;
            }

            if (this.buddyList.IsFull)
            {
                SendBuddyListOperationResult(session, BuddyOperationResult.BuddyListFull);
                return;
            }

            // TODO: Check the target buddy list stuff.
        }

        private static void SendBuddyListOperationResult(Session session, BuddyOperationResult buddyOperationResult)
        {
            using (var builder = new PacketBuilder(3))
            {
                builder.WriteOpCode("BuddyListOperationResponse");
                builder.WriteByte((byte) buddyOperationResult);
                session.WritePacket(builder.ToByteArray());
            }
        }
    }
}