# SpotiSharp
![RELEASES](https://img.shields.io/github/v/release/L0um15/SpotiSharp?include_prereleases&style=flat-square)
![HEART](https://img.shields.io/static/v1?label=made+with&message=❤&color=red&style=flat-square)
![LICENSE](https://img.shields.io/github/license/L0um15/SpotiSharp?style=flat-square)

![ISSUES](https://img.shields.io/github/issues/L0um15/SpotiSharp?style=flat-square)
![LAST COMMIT](https://img.shields.io/github/last-commit/L0um15/SpotiSharp?style=flat-square)

<img align="right" src=".github/images/icon.png" width="128px" height="128px" />

## Music Downloader using Spotify Web API

SpotiSharp is a Open-Source CLI application made in .NET Core

SpotiSharp applies metadata like `Artist` `Title` `Lyrics` `Genres` `Album` `AlbumArt` and more...<br />

Linux users: [README-LINUX](README-LINUX.md)

### Usage

**KEEP THESE KEYS PRIVATE, DO NOT SHARE THEM TO ANYONE**

Create Application on [Spotify Developer Dashboard](https://developer.spotify.com/dashboard/) then provide these keys to config.json

SpotiSharp will generate config.json on first run.</br>
**All non-blank fields will be auto-completed by SpotiSharp**
```json
{
  "ConfigVersion": "(SpotiSharp Version)",
  "ClientID": "",
  "ClientSecret": "",
  "FFmpegPath": "(Application Directory)",
  "DownloadPath": "(MyMusic Directory)"
}
```
**You can reset config.json to default settings. Delete desired line and reset ConfigVersion to "0", all missing lines will be replaced with default ones**

SpotiSharp will download FFmpeg to application directory by default if it is not detected.</br>

```sh
.\SpotiSharp # Prints help.
.\SpotiSharp "bury the light" # Downloads song by text search
.\SpotiSharp https://open.spotify.com/track/5Gcb49reXLKujOV3J7wZ7W # Parses url to search for track, album, playlist
```

<img src=".github/images/preview.png" />

