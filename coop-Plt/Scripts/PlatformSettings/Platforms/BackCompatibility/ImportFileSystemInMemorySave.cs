using System;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Huey.Core.Utilities;
using Kitchen.NetworkSupport;
using UnityEngine;

namespace Platforms.BackCompatibility
{
	public static class ImportFileSystemInMemorySave
	{
		public const string FolderPrefix = "/persistentDataPath";

		public static async Task ConvertOldData()
		{
			_ = 3;
			try
			{
				byte[] fsim_data = await Platform.Current.GetFSIMContent();
				if (fsim_data == null)
				{
					EventLog.Files.Report(FileEvent.ReadingFSIM, "Not found");
					return;
				}
				await EnsureSaveCompression();
				EventLog.Files.Report(FileEvent.ReadingFSIM, fsim_data.Length.ToString());
				await Import(fsim_data);
				await Platform.Current.BackupFSIM();
			}
			catch (FileNotFoundException)
			{
			}
			catch (Exception ex2)
			{
				EventLog.Files.Report(FileEvent.FailedToImportFSIM, ex2.Message);
			}
		}

		private static string FixPath(string path)
		{
			if (path.StartsWith("/persistentDataPath"))
			{
				path = path.Substring("/persistentDataPath".Length);
			}
			EventLog.Files.Report(FileEvent.ConvertingFSIMPath, "Fixing path " + path + " to get " + Platform.Current.FixFSIMFilename(path));
			path = Platform.Current.FixFSIMFilename(path);
			return path;
		}

		private static byte[] UnHuey(byte[] input)
		{
			MemoryStream serializationStream = new MemoryStream(input);
			return (byte[])new BinaryFormatter().Deserialize(serializationStream);
		}

		private static FileSystemInMemory DeserialiseViaMessagepack(byte[] fsim_bytes)
		{
			return FileSystemInMemory.LoadFromByteArray(fsim_bytes, force_compress: true);
		}

		private static FileSystemInMemory DeserialiseViaZippedJSON(byte[] fsim_bytes)
		{
			using GZipStream gZipStream = new GZipStream(new MemoryStream(fsim_bytes), CompressionMode.Decompress);
			using MemoryStream memoryStream = new MemoryStream();
			gZipStream.CopyTo(memoryStream);
			byte[] bytes = memoryStream.ToArray();
			return JsonUtility.FromJson<FileSystemInMemory>(Encoding.UTF8.GetString(bytes));
		}

		private static FileSystemInMemory DeserialiseViaJSON(byte[] fsim_bytes)
		{
			return JsonUtility.FromJson<FileSystemInMemory>(Encoding.UTF8.GetString(fsim_bytes));
		}

		public static async Task DeleteAllFiles()
		{
			string[] dirs = new string[8]
			{
				Path.Combine("Full", "1"),
				Path.Combine("Full", "2"),
				Path.Combine("Full", "3"),
				Path.Combine("Full", "4"),
				Path.Combine("Full", "5"),
				"Profile",
				"Progress",
				"."
			};
			await Platform.Current.DeleteFile("SaveBlob");
			await Platform.Current.DeleteFile("fsim_status.txt");
			string[] array = dirs;
			foreach (string path in array)
			{
				foreach (FileReference item in await Platform.Current.GetFiles(path, ".plateupsave", filter_empty: false))
				{
					Debug.LogWarning("Deleting " + item.Path);
					await Platform.Current.DeleteFile(item.Path);
				}
			}
		}

		public static async Task EnsureSaveCompression()
		{
			for (int i = 0; i < 5; i++)
			{
				try
				{
					string path = Path.Combine("Full", (i + 1).ToString());
					foreach (FileReference file in await Platform.Current.GetFiles(path, ".plateupsave", filter_empty: false))
					{
						byte[] array = await Platform.Current.ReadAllBytes(file.Path);
						if (array != null)
						{
							SaveStorage<Nothing>.Decompress(array, out var was_compressed);
							if (!was_compressed)
							{
								byte[] bytes = SaveStorage<Nothing>.Compress(array);
								await Platform.Current.WriteAllBytes(file.Path, bytes);
							}
						}
					}
				}
				catch
				{
				}
			}
		}

		public static async Task Import(byte[] fsim_bytes)
		{
			FileSystemInMemory fsim;
			try
			{
				fsim = DeserialiseViaMessagepack(fsim_bytes);
			}
			catch (Exception ex)
			{
				EventLog.Files.Report(FileEvent.ReadingFSIMNotMessagepack);
				try
				{
					fsim = DeserialiseViaZippedJSON(fsim_bytes);
				}
				catch
				{
					EventLog.Files.Report(FileEvent.ReadingFSIMNotZippedJSON);
					try
					{
						fsim = DeserialiseViaJSON(fsim_bytes);
						goto end_IL_004f;
					}
					catch
					{
						EventLog.Files.Report(FileEvent.ReadingFSIMNotPlainJSON);
						throw ex;
					}
					end_IL_004f:;
				}
			}
			if (fsim == null)
			{
				EventLog.Files.Report(FileEvent.ReadingFSIMFailedToDeserialise);
				return;
			}
			foreach (string directory in fsim._directories)
			{
				string text = FixPath(directory);
				if (!(text == ""))
				{
					EventLog.Files.Report(FileEvent.ReadingFSIMNewDirectory, text);
					await Platform.Current.CreateDirectory(text);
				}
			}
			foreach (FileSystemInMemory.VFSEntity file in fsim._files)
			{
				string fixed_path = FixPath(file._fullPath);
				if (fixed_path == "")
				{
					continue;
				}
				EventLog.Files.Report(FileEvent.ReadingFSIMNewFile, fixed_path);
				byte[] unhueyed_file = null;
				if (fixed_path.StartsWith("/Full") || fixed_path.StartsWith("Full"))
				{
					unhueyed_file = file._data;
				}
				else
				{
					try
					{
						unhueyed_file = UnHuey(file._data);
					}
					catch (Exception ex2)
					{
						EventLog.Files.Report(FileEvent.ConvertingFSIMFileFailure, ex2);
					}
				}
				try
				{
					byte[] array = SaveStorage<Nothing>.Compress(unhueyed_file);
					unhueyed_file = array;
				}
				catch
				{
				}
				if (unhueyed_file != null)
				{
					try
					{
						await Platform.Current.CreateDirectory(Path.GetDirectoryName(fixed_path));
					}
					catch
					{
					}
					await Platform.Current.WriteAllBytes(fixed_path, unhueyed_file);
				}
			}
		}
	}
}
