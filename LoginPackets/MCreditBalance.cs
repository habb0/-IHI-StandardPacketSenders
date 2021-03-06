﻿#region GPLv3

// 
// Copyright (C) 2012  Chris Chenery
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 

#endregion

#region Usings

using IHI.Server.Habbos;

#endregion

namespace IHI.Server.Networking.Messages
{
    public class MCreditBalance : OutgoingMessage
    {
        /// <summary>
        ///   Constructs a new instance of MCreditBalance and sets the balance to that of a given Habbo.
        /// </summary>
        /// <param name = "habbo"></param>
        public MCreditBalance(Habbo habbo)
        {
            Balance = habbo.GetCreditBalance();
        }

        public int Balance { get; set; }

        public override OutgoingMessage Send(IMessageable target)
        {
            if (InternalOutgoingMessage.ID == 0)
            {
                InternalOutgoingMessage.Initialize(6)
                    .AppendString(Balance.ToString());
            }

            target.SendMessage(InternalOutgoingMessage);
            return this;
        }
    }
}