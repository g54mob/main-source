using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using Helpers.Extensions;
using Restory.Constants;
using Restory.Data.ReadWriteServices;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.FullSerializerWrappers;
using UnityEngine;

namespace Restory.Data.SaveLoad
{
	public class GameplaySaveDataBinarySerializer
	{
		private readonly GameEntityFullSerializer.Factory fsFactory;

		private readonly byte[] projectMark;

		private readonly int projectMarkLength;

		private readonly int gameVersionNumber;

		public GameplaySaveDataBinarySerializer(GameEntityFullSerializer.Factory fsFactory)
		{
			this.fsFactory = fsFactory;
			projectMark = Encoding.ASCII.GetBytes(ProjectConstants.Infrastructure.ProjectTag);
			projectMarkLength = projectMark.Length;
			gameVersionNumber = Application.version.GameVersionNumber();
		}

		public byte[] Serialize(GameplaySaveDataContainer saveDataContainer, Action onFailed = null)
		{
			try
			{
				string gameDataJson = fsFactory.Create().ToJson(saveDataContainer.GameData, onFailed);
				return SerializeToBinaryFormat(gameDataJson, saveDataContainer.TextureData);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				onFailed?.Invoke();
				throw;
			}
		}

		public GameplaySaveDataContainer Deserialize(byte[] binaryData, FileType fileType, Action<FileType> onFailed)
		{
			try
			{
				(string, byte[]) tuple = DeserializeFromBinaryFormat(binaryData);
				return new GameplaySaveDataContainer(fsFactory.Create().FromJson<SaveSystemSaveData>(tuple.Item1, fileType, onFailed), tuple.Item2);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				onFailed?.Invoke(fileType);
				throw;
			}
		}

		public GameplaySaveDataContainer DeserializeUnsafe(byte[] binaryData)
		{
			try
			{
				(string, byte[]) tuple = DeserializeFromBinaryFormat(binaryData);
				return new GameplaySaveDataContainer(fsFactory.Create().FromJsonUnsafe<SaveSystemSaveData>(tuple.Item1), tuple.Item2);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				throw;
			}
		}

		private byte[] SerializeToBinaryFormat(string gameDataJson, byte[] textureData)
		{
			byte[] array = CompressJson(gameDataJson);
			using MemoryStream memoryStream = new MemoryStream();
			using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, Encoding.UTF8);
			binaryWriter.Write(projectMark);
			binaryWriter.Write(gameVersionNumber);
			binaryWriter.Write(array.Length);
			binaryWriter.Write(array);
			binaryWriter.Write(textureData.Length);
			binaryWriter.Write(textureData);
			binaryWriter.Flush();
			return memoryStream.ToArray();
		}

		private (string gameDataJson, byte[] textureData) DeserializeFromBinaryFormat(byte[] binaryData)
		{
			using MemoryStream memoryStream = new MemoryStream(binaryData);
			using BinaryReader binaryReader = new BinaryReader(memoryStream, Encoding.UTF8);
			if (!binaryReader.ReadBytes(projectMarkLength).AsSpan().SequenceEqual(projectMark))
			{
				throw new InvalidDataException("Invalid save file format, expected project tag " + ProjectConstants.Infrastructure.ProjectTag);
			}
			int num = binaryReader.ReadInt32();
			Debug.Log($"Loading save file from game version [{num}]");
			int num2 = binaryReader.ReadInt32();
			if (num2 < 0 || num2 > binaryData.Length)
			{
				throw new InvalidDataException($"Invalid game data length: {num2}");
			}
			byte[] array = binaryReader.ReadBytes(num2);
			if (array.Length != num2)
			{
				throw new InvalidDataException($"Expected {num2} game data bytes, but only read {array.Length}");
			}
			string item = DecompressJson(array);
			int num3 = binaryReader.ReadInt32();
			int num4 = (int)(memoryStream.Length - memoryStream.Position);
			if (num3 != num4)
			{
				throw new InvalidDataException($"Invalid texture data length: {num3}");
			}
			byte[] item2 = binaryReader.ReadBytes(num4);
			return (gameDataJson: item, textureData: item2);
		}

		private byte[] CompressJson(string gameDataJson)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(gameDataJson);
			using MemoryStream memoryStream = new MemoryStream();
			using (GZipStream gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, leaveOpen: true))
			{
				gZipStream.Write(bytes, 0, bytes.Length);
				gZipStream.Flush();
			}
			return memoryStream.ToArray();
		}

		private string DecompressJson(byte[] compressedGameData)
		{
			using MemoryStream stream = new MemoryStream(compressedGameData);
			using MemoryStream memoryStream = new MemoryStream();
			using (GZipStream gZipStream = new GZipStream(stream, CompressionMode.Decompress, leaveOpen: true))
			{
				gZipStream.CopyTo(memoryStream);
			}
			return Encoding.UTF8.GetString(memoryStream.ToArray());
		}
	}
}
