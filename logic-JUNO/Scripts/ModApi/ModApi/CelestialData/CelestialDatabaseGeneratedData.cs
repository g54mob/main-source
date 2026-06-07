using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Xml.Linq;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace ModApi.CelestialData
{
	public class CelestialDatabaseGeneratedData
	{
		public Guid AssociatedFileId { get; }

		public string RootPath { get; }

		public CelestialDatabaseGeneratedData(string rootPath, Guid associatedFileId)
		{
			AssociatedFileId = associatedFileId;
			RootPath = Path.Combine(rootPath, associatedFileId.ToString());
		}

		public static List<(Guid Id, string Path)> GetDirectories(string rootPath)
		{
			List<(Guid, string)> list = new List<(Guid, string)>();
			foreach (DirectoryInfo item in new DirectoryInfo(rootPath).EnumerateDirectories("*", SearchOption.TopDirectoryOnly))
			{
				if (Guid.TryParse(item.Name, out var result))
				{
					list.Add((result, item.FullName));
				}
			}
			return list;
		}

		public bool FileExists(string fileName)
		{
			return File.Exists(Path.Combine(RootPath, fileName));
		}

		public string GetFilePath(string fileName, bool createDirectory = false)
		{
			if (createDirectory && !Directory.Exists(RootPath))
			{
				Directory.CreateDirectory(RootPath);
			}
			return Path.Combine(RootPath, fileName);
		}

		public byte[] LoadFile(string fileName)
		{
			string filePath = GetFilePath(fileName);
			if (!File.Exists(filePath))
			{
				return null;
			}
			return File.ReadAllBytes(filePath);
		}

		public unsafe Color32[] LoadFileAsColor32(string fileName)
		{
			string filePath = GetFilePath(fileName);
			if (!File.Exists(filePath))
			{
				return null;
			}
			Color32[] array = null;
			using FileStream fileStream = File.OpenRead(filePath);
			array = new Color32[fileStream.Length / 4];
			byte[] array2 = new byte[4096];
			ulong gcHandle;
			byte* ptr = (byte*)UnsafeUtility.PinGCArrayAndGetDataAddress(array, out gcHandle);
			fixed (byte* source = array2)
			{
				int num = 0;
				while ((num = fileStream.Read(array2, 0, array2.Length)) > 0)
				{
					UnsafeUtility.MemCpy(ptr, source, num);
					ptr += num;
				}
				UnsafeUtility.ReleaseGCObject(gcHandle);
				return array;
			}
		}

		public unsafe int LoadFileAsColor32(string fileName, NativeArray<Color32> data, bool compressed)
		{
			string filePath = GetFilePath(fileName);
			if (!File.Exists(filePath))
			{
				return 0;
			}
			using FileStream fileStream = File.OpenRead(filePath);
			Stream stream = fileStream;
			try
			{
				if (compressed)
				{
					stream = new GZipStream(fileStream, CompressionMode.Decompress, leaveOpen: true);
				}
				byte[] array = new byte[4096];
				byte* ptr = (byte*)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(data);
				byte* ptr2 = ptr;
				fixed (byte* source = array)
				{
					int num = 0;
					while ((num = stream.Read(array, 0, array.Length)) > 0)
					{
						UnsafeUtility.MemCpy(ptr, source, num);
						ptr += num;
					}
				}
				return (int)((ptr - ptr2) / 4);
			}
			finally
			{
				if (compressed)
				{
					stream?.Dispose();
				}
			}
		}

		public Stream LoadFileAsStream(string fileName)
		{
			string filePath = GetFilePath(fileName);
			if (!File.Exists(filePath))
			{
				return null;
			}
			return File.OpenRead(filePath);
		}

		public string LoadFileAsText(string fileName)
		{
			string filePath = GetFilePath(fileName);
			if (!File.Exists(filePath))
			{
				return null;
			}
			return File.ReadAllText(filePath);
		}

		public XDocument LoadFileAsXml(string fileName)
		{
			string filePath = GetFilePath(fileName);
			if (!File.Exists(filePath))
			{
				return null;
			}
			return XDocument.Load(filePath);
		}

		public Texture2D LoadTexture(string fileName, bool mipmaps, bool linear, bool markNonReadable)
		{
			byte[] array = LoadFile(fileName);
			if (array != null)
			{
				Texture2D texture2D = new Texture2D(2, 2, TextureFormat.RGBA32, mipmaps, linear);
				if (texture2D.LoadImage(array, markNonReadable))
				{
					return texture2D;
				}
				string filePath = GetFilePath(fileName);
				Debug.LogError("Could not load texture '" + filePath + "'. The file existed but could not be loaded as a texture.");
			}
			return null;
		}

		public unsafe string SaveFile(string fileName, NativeArray<byte> data, bool compressed)
		{
			string filePath = GetFilePath(fileName, createDirectory: true);
			using FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
			Stream stream = fileStream;
			try
			{
				if (compressed)
				{
					stream = new GZipStream(fileStream, CompressionMode.Compress, leaveOpen: true);
				}
				byte[] array = new byte[4096];
				fixed (byte* destination = array)
				{
					byte* ptr = (byte*)NativeArrayUnsafeUtility.GetUnsafeBufferPointerWithoutChecks(data);
					int i = 0;
					int num;
					for (int length = data.Length; i < length; i += num)
					{
						num = System.Math.Min(array.Length, length - i);
						UnsafeUtility.MemCpy(destination, ptr, num);
						stream.Write(array, 0, num);
						ptr += num;
					}
					return filePath;
				}
			}
			finally
			{
				if (compressed)
				{
					stream?.Dispose();
				}
			}
		}

		public string SaveFile(string fileName, byte[] data)
		{
			string filePath = GetFilePath(fileName, createDirectory: true);
			File.WriteAllBytes(filePath, data);
			return filePath;
		}

		public string SaveFile(string fileName, Stream stream)
		{
			string filePath = GetFilePath(fileName, createDirectory: true);
			using FileStream destination = new FileStream(filePath, FileMode.Create, FileAccess.Write);
			stream.CopyTo(destination);
			return filePath;
		}

		public string SaveFile(string fileName, string text)
		{
			string filePath = GetFilePath(fileName, createDirectory: true);
			File.WriteAllText(filePath, text);
			return filePath;
		}

		public string SaveFile(string fileName, XDocument xml)
		{
			string filePath = GetFilePath(fileName, createDirectory: true);
			xml.Save(filePath);
			return filePath;
		}

		public string SaveFile(string fileName, XElement xml)
		{
			string filePath = GetFilePath(fileName, createDirectory: true);
			xml.Save(filePath);
			return filePath;
		}

		public string SaveTextureAsExr(string fileName, Texture2D texture, Texture2D.EXRFlags flags)
		{
			byte[] data = texture.EncodeToEXR();
			return SaveFile(fileName, data);
		}

		public string SaveTextureAsJpg(string fileName, Texture2D texture, int quality)
		{
			byte[] data = texture.EncodeToJPG();
			return SaveFile(fileName, data);
		}

		public string SaveTextureAsPng(string fileName, Texture2D texture)
		{
			byte[] data = texture.EncodeToPNG();
			return SaveFile(fileName, data);
		}

		public string SaveTextureAsTga(string fileName, Texture2D texture)
		{
			byte[] data = texture.EncodeToTGA();
			return SaveFile(fileName, data);
		}
	}
}
