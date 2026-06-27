using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Equipment.DevicePaintingTools;
using UnityEngine;

namespace Restory.Gameplay.TextureMasks
{
	public class TextureCacheService : IDisposable
	{
		private readonly Dictionary<int, byte[]> textureCache = new Dictionary<int, byte[]>();

		private readonly Dictionary<int, Task<byte[]>> texturesInConversionProcess = new Dictionary<int, Task<byte[]>>();

		private readonly Dictionary<int, CancellationTokenSource> texturesConversionCancellationSources = new Dictionary<int, CancellationTokenSource>();

		private readonly HashSet<int> markedTextures = new HashSet<int>();

		private int nextTextureId;

		public bool AreAllTasksComplete => texturesInConversionProcess.Count == 0;

		public bool IsProcessing(int id)
		{
			return texturesInConversionProcess.ContainsKey(id);
		}

		public void Dispose()
		{
			CancelAllEncodingTasks();
		}

		public void CacheTextureDataAsync(ElementData elementData, Func<CancellationToken, Task<byte[]>> taskFactory, CachedTextureType textureType = CachedTextureType.DirtMaskTexture)
		{
			lock (texturesConversionCancellationSources)
			{
				int textureId = GetTextureId(elementData, textureType);
				if (texturesConversionCancellationSources.TryGetValue(textureId, out var value))
				{
					value.Cancel();
					value.Dispose();
				}
				CancellationTokenSource newSource = new CancellationTokenSource();
				texturesConversionCancellationSources[textureId] = newSource;
				Task<byte[]> task = taskFactory(newSource.Token);
				lock (texturesInConversionProcess)
				{
					texturesInConversionProcess[textureId] = task;
				}
				MarkTexture(textureId);
				task.ContinueWith(delegate(Task<byte[]> task2)
				{
					if (task2.Status == TaskStatus.RanToCompletion)
					{
						lock (textureCache)
						{
							textureCache[textureId] = task2.Result;
						}
					}
					lock (texturesInConversionProcess)
					{
						texturesInConversionProcess.Remove(textureId);
					}
					lock (texturesConversionCancellationSources)
					{
						if (texturesConversionCancellationSources.TryGetValue(textureId, out var value2) && value2 == newSource)
						{
							texturesConversionCancellationSources.Remove(textureId);
							newSource.Dispose();
						}
					}
				});
			}
		}

		public void CacheTextureDataAsync(PaintableDevice paintableDevice, Func<CancellationToken, Task<byte[]>> taskFactory, CachedTextureType textureType)
		{
			lock (texturesConversionCancellationSources)
			{
				int textureId = GetTextureId(paintableDevice, textureType);
				if (texturesConversionCancellationSources.TryGetValue(textureId, out var value))
				{
					value.Cancel();
					value.Dispose();
				}
				CancellationTokenSource newSource = new CancellationTokenSource();
				texturesConversionCancellationSources[textureId] = newSource;
				Task<byte[]> task = taskFactory(newSource.Token);
				lock (texturesInConversionProcess)
				{
					texturesInConversionProcess[textureId] = task;
				}
				MarkTexture(textureId);
				task.ContinueWith(delegate(Task<byte[]> task2)
				{
					if (task2.Status == TaskStatus.RanToCompletion)
					{
						lock (textureCache)
						{
							textureCache[textureId] = task2.Result;
						}
					}
					lock (texturesInConversionProcess)
					{
						texturesInConversionProcess.Remove(textureId);
					}
					lock (texturesConversionCancellationSources)
					{
						if (texturesConversionCancellationSources.TryGetValue(textureId, out var value2) && value2 == newSource)
						{
							texturesConversionCancellationSources.Remove(textureId);
							newSource.Dispose();
						}
					}
				});
			}
		}

		public async Task WaitForAllTexturesConversionCompletion()
		{
			Task<byte[]>[] tasks;
			lock (texturesInConversionProcess)
			{
				tasks = texturesInConversionProcess.Values.ToArray();
			}
			await Task.WhenAll(tasks);
		}

		public void CacheTextureData(ElementData elementData, byte[] textureData, CachedTextureType textureType = CachedTextureType.DirtMaskTexture)
		{
			int textureId = GetTextureId(elementData, textureType);
			textureCache[textureId] = textureData;
			MarkTexture(textureId);
		}

		public bool TryGetTextureData(int textureId, out byte[] textureData)
		{
			bool num = textureCache.TryGetValue(textureId, out textureData);
			if (!num)
			{
				Debug.LogError($"Failed to get texture for ID {textureId}");
				return num;
			}
			markedTextures.Add(textureId);
			return num;
		}

		public void RemoveTextureData(int textureId)
		{
			if (textureId <= 0)
			{
				return;
			}
			lock (texturesConversionCancellationSources)
			{
				if (texturesConversionCancellationSources.TryGetValue(textureId, out var value))
				{
					value.Cancel();
					value.Dispose();
					texturesConversionCancellationSources.Remove(textureId);
				}
			}
			lock (texturesInConversionProcess)
			{
				texturesInConversionProcess.Remove(textureId);
			}
			textureCache.Remove(textureId);
			UnmarkTexture(textureId);
		}

		public byte[] SerializeTextureData()
		{
			if (textureCache.Count == 0 || markedTextures.Count == 0)
			{
				return new byte[4];
			}
			using MemoryStream memoryStream = new MemoryStream();
			using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			binaryWriter.Write(markedTextures.Count);
			Debug.Log($"Start serialization of {markedTextures.Count} textures");
			foreach (int markedTexture in markedTextures)
			{
				if (!textureCache.TryGetValue(markedTexture, out var value))
				{
					Debug.LogError($"Failed to find cached texture for Id {markedTexture}");
					continue;
				}
				binaryWriter.Write(markedTexture);
				binaryWriter.Write(value.Length);
				binaryWriter.Write(value);
				Debug.Log($"Serialized texture for Id {markedTexture}, with data length {value.Length}");
			}
			return memoryStream.ToArray();
		}

		public void DeserializeTextureData(byte[] data)
		{
			if (data == null || data.Length < 4)
			{
				throw new ArgumentException("Invalid texture cache data: insufficient data length");
			}
			textureCache.Clear();
			markedTextures.Clear();
			nextTextureId = 0;
			using MemoryStream input = new MemoryStream(data);
			using BinaryReader binaryReader = new BinaryReader(input);
			try
			{
				int num = binaryReader.ReadInt32();
				if (num == 0)
				{
					return;
				}
				Debug.Log($"Start deserialization of {num} textures");
				for (int i = 0; i < num; i++)
				{
					int num2 = binaryReader.ReadInt32();
					int num3 = binaryReader.ReadInt32();
					if (num3 < 0)
					{
						throw new ArgumentException($"Invalid texture data length: {num3}");
					}
					byte[] array = binaryReader.ReadBytes(num3);
					if (array.Length != num3)
					{
						throw new ArgumentException($"Expected {num3} bytes but only read {array.Length} bytes");
					}
					textureCache[num2] = array;
					if (num2 > nextTextureId)
					{
						nextTextureId = num2;
					}
					Debug.Log($"Deserialized texture for Id {num2}, with data length {array.Length}");
				}
			}
			catch (EndOfStreamException)
			{
				throw new ArgumentException("Invalid texture cache data: unexpected end of stream");
			}
		}

		private void MarkTexture(int textureId)
		{
			if (!textureCache.ContainsKey(textureId) && !texturesInConversionProcess.ContainsKey(textureId))
			{
				Debug.LogError($"Failed to mark texture for ID {textureId}");
			}
			else
			{
				markedTextures.Add(textureId);
			}
		}

		private void UnmarkTexture(int textureId)
		{
			markedTextures.Remove(textureId);
		}

		private void CancelAllEncodingTasks()
		{
			lock (texturesConversionCancellationSources)
			{
				foreach (CancellationTokenSource value in texturesConversionCancellationSources.Values)
				{
					value.Cancel();
					value.Dispose();
				}
				texturesConversionCancellationSources.Clear();
			}
		}

		private int GetTextureId(ElementData elementData, CachedTextureType textureType)
		{
			int num = 0;
			switch (textureType)
			{
			case CachedTextureType.DirtMaskTexture:
				if (elementData.DirtMaskTextureId == 0)
				{
					nextTextureId++;
					elementData.DirtMaskTextureId = nextTextureId;
				}
				return elementData.DirtMaskTextureId;
			case CachedTextureType.PaintingTexture:
				throw new InvalidOperationException("PaintingTexture should be cached through PaintableDevice");
			default:
				throw new NotImplementedException();
			}
		}

		private int GetTextureId(PaintableDevice paintableDevice, CachedTextureType textureType)
		{
			if (textureType != CachedTextureType.PaintingTexture)
			{
				throw new NotImplementedException();
			}
			if (paintableDevice.PaintTextureId == 0)
			{
				nextTextureId++;
				paintableDevice.SetPaintTextureId(nextTextureId);
			}
			return paintableDevice.PaintTextureId;
		}
	}
}
