using System;
using System.IO;
using System.Threading;
using Cysharp.Text;
using Cysharp.Threading.Tasks;
using MessagePack;
using MessagePack.Resolvers;
using MessagePack.Unity;
using UnityEngine;

public static class SaveSystem
{
	private static readonly MessagePackSerializerOptions serializerOptions = MessagePackSerializerOptions.Standard.WithCompression(MessagePackCompression.Lz4BlockArray).WithResolver(CompositeResolver.Create(StandardResolver.Instance, UnityResolver.Instance));

	public static bool HasMeta(int profile)
	{
		return File.Exists(FilePaths.GetMetaFilePath(profile));
	}

	public static bool HasState(int profile)
	{
		return File.Exists(FilePaths.GetStateFilePath(profile));
	}

	public static bool HasGlobal()
	{
		return File.Exists(FilePaths.GetGlobalFilePath());
	}

	public static void SaveProfile(int profile, MetaFileDto meta, StateFileDto state, GlobalFileDto global)
	{
		EnsureProfileFolder(profile);
		WriteAtomic(FilePaths.GetStateFilePath(profile), state);
		WriteAtomic(FilePaths.GetMetaFilePath(profile), meta);
		WriteAtomic(FilePaths.GetGlobalFilePath(), global);
	}

	public static async UniTask SaveProfileAsync(int profile, MetaFileDto meta, StateFileDto state, GlobalFileDto global, Action callback = null, CancellationToken token = default(CancellationToken))
	{
		EnsureProfileFolder(profile);
		await WriteAtomicAsync(FilePaths.GetStateFilePath(profile), state, token);
		await WriteAtomicAsync(FilePaths.GetMetaFilePath(profile), meta, token);
		await WriteAtomicAsync(FilePaths.GetGlobalFilePath(), global, token);
		callback?.Invoke();
	}

	public static async UniTask SaveMetaAsync(int profile, MetaFileDto meta, Action callback = null, CancellationToken token = default(CancellationToken))
	{
		EnsureProfileFolder(profile);
		await WriteAtomicAsync(FilePaths.GetMetaFilePath(profile), meta, token);
		callback?.Invoke();
	}

	public static async UniTask SaveStateAsync(int profile, StateFileDto state, Action callback = null, CancellationToken token = default(CancellationToken))
	{
		EnsureProfileFolder(profile);
		await WriteAtomicAsync(FilePaths.GetStateFilePath(profile), state, token);
		callback?.Invoke();
	}

	public static async UniTask SaveGlobalAsync(int profile, GlobalFileDto state, Action callback = null, CancellationToken token = default(CancellationToken))
	{
		EnsureProfileFolder(profile);
		await WriteAtomicAsync(FilePaths.GetGlobalFilePath(), state, token);
		callback?.Invoke();
	}

	public static MetaFileDto LoadMeta(int profile)
	{
		try
		{
			return Read<MetaFileDto>(FilePaths.GetMetaFilePath(profile));
		}
		catch (FileNotFoundException)
		{
			return null;
		}
		catch (Exception innerException)
		{
			throw new SaveFileException($"Failed to load save file for profile {profile} [Meta].", innerException);
		}
	}

	public static StateFileDto LoadState(int profile)
	{
		try
		{
			return Read<StateFileDto>(FilePaths.GetStateFilePath(profile));
		}
		catch (Exception innerException)
		{
			throw new SaveFileException($"Failed to load save file for profile {profile} [State].", innerException);
		}
	}

	public static GlobalFileDto LoadGlobal()
	{
		try
		{
			return Read<GlobalFileDto>(FilePaths.GetGlobalFilePath());
		}
		catch (Exception innerException)
		{
			throw new SaveFileException("Failed to load save file [Global].", innerException);
		}
	}

	public static void DeleteProfile(int profile)
	{
		Directory.Delete(FilePaths.ProfileFolderPath(profile), recursive: true);
	}

	private static void EnsureProfileFolder(int profile)
	{
		if (!Directory.Exists(Application.persistentDataPath))
		{
			Directory.CreateDirectory(Application.persistentDataPath);
		}
		if (!Directory.Exists(FilePaths.ProfilesRootPath))
		{
			Directory.CreateDirectory(FilePaths.ProfilesRootPath);
		}
		string path = FilePaths.ProfileFolderPath(profile);
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}
	}

	private static async UniTask WriteAtomicAsync<T>(string path, T value, CancellationToken token)
	{
		string tempPath = ZString.Concat(path, ".tmp");
		string backupPath = ZString.Concat(path, ".bak");
		await using (FileStream fs = new FileStream(tempPath, FileMode.Create, FileAccess.Write, FileShare.None, 65536, useAsync: true))
		{
			await MessagePackSerializer.SerializeAsync(fs, value, serializerOptions, token);
			await fs.FlushAsync(token);
		}
		if (File.Exists(path))
		{
			TryDeleteFile(backupPath);
			File.Move(path, backupPath);
		}
		TryDeleteFile(path);
		File.Move(tempPath, path);
	}

	private static void WriteAtomic<T>(string path, T value)
	{
		string text = ZString.Concat(path, ".tmp");
		string text2 = ZString.Concat(path, ".bak");
		using (FileStream fileStream = new FileStream(text, FileMode.Create, FileAccess.Write, FileShare.None, 65536))
		{
			MessagePackSerializer.Serialize(fileStream, value, serializerOptions);
			fileStream.Flush();
		}
		if (File.Exists(path))
		{
			TryDeleteFile(text2);
			File.Move(path, text2);
		}
		TryDeleteFile(path);
		File.Move(text, path);
	}

	private static T Read<T>(string path) where T : class
	{
		if (!File.Exists(path))
		{
			string text = ZString.Concat(path, ".bak");
			if (File.Exists(text))
			{
				return ReadFile<T>(text);
			}
			throw new FileNotFoundException(ZString.Format("Save file '{0}' and Backup '{1}' do not exist.", path, text));
		}
		try
		{
			return ReadFile<T>(path);
		}
		catch (Exception)
		{
			string path2 = ZString.Concat(path, ".bak");
			if (!File.Exists(path2))
			{
				throw;
			}
			return ReadFile<T>(path2);
		}
	}

	private static T ReadFile<T>(string path)
	{
		return MessagePackSerializer.Deserialize<T>(File.ReadAllBytes(path), serializerOptions);
	}

	private static void TryDeleteFile(string path)
	{
		try
		{
			if (File.Exists(path))
			{
				File.Delete(path);
			}
		}
		catch (Exception ex)
		{
			Debug.LogWarning("Failed to delete file '" + path + "'. " + ex.GetType().Name + ": " + ex.Message);
		}
	}
}
