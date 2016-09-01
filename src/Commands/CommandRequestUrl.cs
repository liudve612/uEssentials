#region License
/*
 *  This file is part of uEssentials project.
 *      https://uessentials.github.io/
 *
 *  Copyright (C) 2015-2016  leonardosnt
 *
 *  This program is free software; you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation; either version 2 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License along
 *  with this program; if not, write to the Free Software Foundation, Inc.,
 *  51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
*/
#endregion

using Essentials.Api.Command;
using Essentials.Api.Command.Source;
using Essentials.I18n;

namespace Essentials.Commands {

    [CommandInfo(
        Name = "requesturl",
        Aliases = new[] { "requrl" },
        Description = "Request player to open an URL.",
        Usage = "[player] [message] [url]",
        MinArgs = 3,
        MaxArgs = 3
    )]
    public class CommandRequestUrl : EssCommand {

        public override CommandResult OnExecute(ICommandSource src, ICommandArgs args) {
            if (!args[0].IsValidPlayerIdentifier) {
                return CommandResult.Lang("PLAYER_NOT_FOUND", args[0]);
            }

            var target = args[0].ToPlayer;
            var message = args[1].ToString();
            var url = args[2].ToString();

            target.UnturnedPlayer.sendBrowserRequest(message, url);
            EssLang.Send(src, "REQUEST_URL_SUCCESS", target.DisplayName, url);

            return CommandResult.Success();
        }

    }

}