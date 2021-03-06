﻿using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Net.Providers.WS4Net;

namespace Pkmn_Discordia_Bot
{
    class Program
    {
        DiscordSocketClient _client;
        CommandHandler _handler;

        static void Main(string[] args)
        => new Program().StartAsync().GetAwaiter().GetResult();
        public async Task StartAsync()
        {
            if (Config.bot.token == "" || Config.bot.token == null) return;

              _client = new DiscordSocketClient(new DiscordSocketConfig
              {
                  LogLevel = LogSeverity.Verbose,
                  WebSocketProvider = WS4NetProvider.Instance
              });
            _client.Log += Log;
            await _client.LoginAsync(TokenType.Bot, Config.bot.token);
            await _client.StartAsync();
            await _client.StartAsync();
            await _handler.IntializeAsync(_client);
            _handler = new CommandHandler();
        }

        private async Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.Message);
        }
    }
}
