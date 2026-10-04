# Disk Cleaner

A console tool to clean your disks. Finds and removes duplicate files.

## How it works

Files are grouped by their size, the ones with the same sizes are then compared by their SHA-256 Hash digest, and the oldest copy is kept, others are moved to the Recycle Bin.

## Usage 

Requires the .NET 10 SDK.

From the repository folder, run:

```
   dotnet run --project DiskCleaner.Cli
```

And follow the instructions.

## Warnings

- Windows only. The Recycle Bin integration uses Windows APIs.
- Deletion performed in a removable disk is permanent. This is an early version, back up important files before using.
- All empty files are deleted.

## License

Licensed under the GNU General Public License v3.0. See [LICENSE](LICENSE).
