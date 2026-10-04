# Disk Cleaner

A tool to clean your disks. Finds and removes duplicate files.

## How it works

Files are grouped by their size, the ones with the same sizes are then compared by their SHA-256 Hash digest, and the oldest copy is kept, others are moved to the Recycle Bin. (Files are compared by content, not by name).

## Usage 

Requires the .NET 10 SDK.

From the repository folder, run:

Download from Releases, extract, run DiskCleaner.Cli.exe.

And follow the instructions.

## Warnings

- Windows only. The Recycle Bin integration uses Windows APIs.
- Deletion performed in a removable disk is permanent. This is an early version, back up important files before using.
- All empty files are deleted.
- DO NOT ENTER FOLDERS THAT ARE INSIDE EACH OTHER, OR THE SAME FOLDER TWİCE. THE SAME FİLE MAY BE SEEN AS ITS OWN DUPLICATE. 

## License

Licensed under the GNU General Public License v3.0. See [LICENSE](LICENSE).
