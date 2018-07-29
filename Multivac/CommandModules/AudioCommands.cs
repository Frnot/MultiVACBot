﻿using Discord.Commands;
using Multivac.Main;
using System.Threading.Tasks;

namespace Multivac.Commands
{
    public class AudioCommands : ModuleBase<SocketCommandContext>
    {
        private readonly AudioService AudioHandler;

        public AudioCommands(AudioService AudioHandler)
        {
            this.AudioHandler = AudioHandler;
        }
        // end Constructor


        [Command("join")]
        public async Task Join()
            => await AudioHandler.JoinChannelAsync(Context);

        [Command("play")]
        public async Task PlayMusic([Remainder] string input)
        {
            await AudioHandler.PlayMusicAsync(Context, input);
        }

        [Command("stop")]
        [RequireOwner]
        public async Task StopMusic()
            => await AudioHandler.StopMusicAsync(Context.Guild.Id);

        [Command("restart")]
        public async Task RestartSong()
            => await AudioHandler.RestartSongAsync(Context);
        

        [Command("skip"), Alias("next")]
        public async Task SkipSong()
            => await AudioHandler.SkipSongAsync(Context);

        [Command("loop"), Alias("repeat")]
        public async Task RepeatSong()
            => await AudioHandler.RepeatSongAsync(Context.Guild.Id);

        [Command("leave")]
        public async Task Leave()
            => await AudioHandler.DisconnectAsync(Context.Guild.Id);



        [Command("nowplaying", RunMode = RunMode.Async), Alias("np", "currentsong", "currenttrack")]
        public async Task NowPlaying()
            => await AudioHandler.NowPlayingAsync(Context);

        [Command("upnext"), Alias("nextsong", "nexttrack")]
        public async Task UpNext()
            => await AudioHandler.UpNextAsync(Context);

        [Command("showqueue"), Alias("songlist", "songs")]
        public async Task ShowTrackList()
            => await AudioHandler.ShowQueueAsync(Context);

        [Command("volume")]
        public async Task Volume()
            => await AudioHandler.ShowVolumeAsync(Context);

        [Command("volume")]
        //[RequireUserPermission(GuildPermission.Administrator, Group = "perms")]
        [RequireOwner(Group = "perms")]
        public async Task Volume(int volume)
            => await AudioHandler.SetVolumeAsync(Context.Guild.Id, volume);
    }
}
