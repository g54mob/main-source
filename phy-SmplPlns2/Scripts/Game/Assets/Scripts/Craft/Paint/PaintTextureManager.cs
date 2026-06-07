using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Assets.Scripts.Storage;
using BCnEncoder.Encoder;
using BCnEncoder.Shared;
using Jundroo.Common.Cryptography;
using Jundroo.Common.DataTypes;
using Jundroo.Common.Textures;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace Assets.Scripts.Craft.Paint
{
	public class PaintTextureManager : MonoBehaviour
	{
		private static class Profile
		{
			public static readonly ProfilerMarker CreateTextureArray = new ProfilerMarker("PaintTextureManager.CreateTextureArrays");

			public static readonly ProfilerMarker CreateTextureArrays = new ProfilerMarker("PaintTextureManager.CreateTextureArrays");

			public static readonly ProfilerMarker LoadTextureFromFile = new ProfilerMarker("PaintTextureManager.LoadTexture_File");

			public static readonly ProfilerMarker LoadTextureFromResource = new ProfilerMarker("PaintTextureManager.LoadTexture_Resource");
		}

		[SerializeField]
		private EnumDictionary<PaintStyle, Texture2DArray> _textureArrays;

		[SerializeField]
		private EnumDictionary<PaintStyle, List<PaintTextureData>> _textureData;

		private EnumDictionary<PaintStyle, Dictionary<string, PaintTextureData>> _textureDataByID;

		private Dictionary<string, PaintTexturePreset> _textureDataSharedPresets;

		public bool HasTexturesPendingProcessing { get; private set; }

		public static void CopyPaintTexturesExampleXml()
		{
			FileInfo fileInfo = new FileInfo(GameData.GetPath("PaintTextures/PaintTextures.xml"));
			if (!fileInfo.Exists)
			{
				if (!fileInfo.Directory.Exists)
				{
					fileInfo.Directory.Create();
				}
				string contents = Game.Instance.ResourceLoader.LoadText("Craft/PaintTextures/PaintTexturesAppData");
				File.WriteAllText(fileInfo.FullName, contents);
			}
		}

		public static PaintTextureManager Create(GameObject parent)
		{
			PaintTextureManager paintTextureManager = new GameObject("PaintTextureManager").AddComponent<PaintTextureManager>();
			paintTextureManager.transform.SetParent(parent.transform);
			paintTextureManager.Initialize();
			return paintTextureManager;
		}

		public void GetAvailableTextureIds(PaintStyle style, IList<string> list)
		{
			foreach (PaintTextureData item in _textureData[style])
			{
				if (item.Available)
				{
					list.Add(item.Id);
				}
			}
		}

		public Texture2DArray GetTextureArray(PaintStyle style)
		{
			return _textureArrays[style];
		}

		public IReadOnlyList<PaintTextureData> GetTextureData(PaintStyle style)
		{
			return _textureData[style];
		}

		public PaintTextureData GetTextureData(PaintStyle style, string textureId)
		{
			if (textureId != null)
			{
				return _textureDataByID[style]?.GetValueOrDefault(textureId);
			}
			return null;
		}

		public IReadOnlyCollection<string> GetTextureIds(PaintStyle style)
		{
			return _textureDataByID[style].Keys;
		}

		public async Task ProcessPendingTexturesAsync(IProgress<(string Path, float Progress)> progress = null)
		{
			HasTexturesPendingProcessing = false;
			List<PaintTextureData> dataToProcess = new List<PaintTextureData>();
			foreach (List<PaintTextureData> value2 in _textureData.Values)
			{
				foreach (PaintTextureData textureData in value2)
				{
					if (textureData.NeedsProcessed)
					{
						textureData.NeedsProcessed = false;
						if (!dataToProcess.Any((PaintTextureData x) => x.LocationPath == textureData.LocationPath))
						{
							dataToProcess.Add(textureData);
						}
					}
				}
			}
			for (int textureDataIndex = 0; textureDataIndex < dataToProcess.Count; textureDataIndex++)
			{
				PaintTextureData textureData2 = dataToProcess[textureDataIndex];
				string path = textureData2.LocationPath;
				FileInfo fileInfo = new FileInfo(GameData.GetPath(path));
				FileInfo processedFileInfo = new FileInfo(GameData.GetPath(Path.Combine("Cache", path)));
				FileInfo hashFileInfo = new FileInfo(processedFileInfo.FullName + ".hash");
				Debug.Log("Processing paint texture: " + path);
				try
				{
					if (!processedFileInfo.Directory.Exists)
					{
						processedFileInfo.Directory.Create();
					}
					Texture2D texture = GameData.LoadTexture(fileInfo.FullName);
					if (texture == null)
					{
						throw new Exception("Unable to load texture");
					}
					Texture2DArray textureArray = GetTextureArray(textureData2.PaintStyle);
					int2 int5 = new int2(textureArray.width, textureArray.height);
					if (texture.width != int5.x || texture.height != int5.y)
					{
						Debug.Log("Paint texture does not match the expected size and will be automatically resized. " + $"For best results, use textures of size {int5.x}x{int5.y}. " + "Texture Path: " + path);
						TextureScale.Bilinear(texture, int5.x, int5.y);
					}
					NativeArray<byte> pixelData = texture.GetPixelData<byte>(0);
					InvertAlphaChannel(texture.format, pixelData);
					if (!Game.Instance.Device.IsWindowsBuild)
					{
						texture.Apply(updateMipmaps: true, makeNoLongerReadable: false);
						texture.Compress(highQuality: true);
						pixelData = texture.GetPixelData<byte>(0);
					}
					int width = texture.width;
					int height = texture.height;
					TextureFormat format = texture.format;
					GraphicsFormat graphicsFormat = texture.graphicsFormat;
					await Task.Run(delegate
					{
						if (Game.Instance.Device.IsWindowsBuild)
						{
							using (MemoryStream memoryStream = new MemoryStream())
							{
								BcEncoder bcEncoder = new BcEncoder();
								bcEncoder.OutputOptions.GenerateMipMaps = true;
								bcEncoder.OutputOptions.Quality = CompressionQuality.Balanced;
								bcEncoder.OutputOptions.Format = CompressionFormat.Bc7;
								bcEncoder.OutputOptions.FileFormat = OutputFileFormat.Dds;
								bcEncoder.Options.TaskCount = Math.Max(2, System.Environment.ProcessorCount - 2);
								if (progress != null)
								{
									bcEncoder.Options.Progress = new Progress<ProgressElement>(delegate(ProgressElement x)
									{
										float num = 1f / (float)dataToProcess.Count;
										float num2 = num * (float)textureDataIndex;
										float num3 = x.Percentage * num;
										float value = num2 + num3;
										progress.Report((path, Mathf.Clamp01(value)));
									});
								}
								PixelFormat format2 = format switch
								{
									TextureFormat.RGBA32 => PixelFormat.Rgba32, 
									TextureFormat.BGRA32 => PixelFormat.Bgra32, 
									TextureFormat.ARGB32 => PixelFormat.Argb32, 
									TextureFormat.RGB24 => PixelFormat.Rgb24, 
									_ => throw new Exception($"Unsupported texture format: {format}"), 
								};
								bcEncoder.EncodeToStream(pixelData.AsReadOnlySpan(), width, height, format2, memoryStream);
								using FileStream destination = processedFileInfo.Open(FileMode.Create, FileAccess.Write, FileShare.Write);
								memoryStream.Position = 0L;
								memoryStream.CopyTo(destination);
								return;
							}
						}
						NativeArray<byte> nativeArray = ImageConversion.EncodeNativeArrayToPNG(pixelData, graphicsFormat, (uint)width, (uint)height);
						File.WriteAllBytes(processedFileInfo.FullName, nativeArray.ToArray());
					});
					UnloadTexture(texture, PaintTextureLocationType.LocalFileSystem);
					string contents = Hash.MD5(fileInfo.FullName);
					File.WriteAllText(hashFileInfo.FullName, contents);
					textureData2.NeedsProcessed = false;
					Debug.Log("Processing paint texture Completed: " + path);
				}
				catch (Exception exception)
				{
					Debug.LogError("An error occurred trying to process paint texture '" + path + "'");
					Debug.LogException(exception);
				}
			}
		}

		public void RebuildTextureArrays()
		{
			CreateTextureArrays();
		}

		protected virtual void OnDestroy()
		{
			foreach (Texture2DArray value in _textureArrays.Values)
			{
				if (value != null)
				{
					UnityEngine.Object.Destroy(value);
				}
			}
		}

		private static Texture2D LoadTexture(PaintTextureData textureData)
		{
			return LoadTexture(textureData.LocationType, textureData.LocationPath, textureData);
		}

		private static Texture2D LoadTexture(PaintTextureLocationType locationType, string path, PaintTextureData textureData = null)
		{
			switch (locationType)
			{
			case PaintTextureLocationType.Resource:
				using (Profile.LoadTextureFromResource.Auto())
				{
					return Game.Instance.ResourceLoader.LoadTexture(path);
				}
			case PaintTextureLocationType.LocalFileSystem:
			{
				FileInfo fileInfo = new FileInfo(GameData.GetPath(path));
				FileInfo fileInfo2 = new FileInfo(GameData.GetPath(Path.Combine("Cache", path)));
				FileInfo fileInfo3 = new FileInfo(fileInfo2.FullName + ".hash");
				bool flag = false;
				if (fileInfo2.Exists && fileInfo3.Exists)
				{
					string text = File.ReadAllText(fileInfo3.FullName);
					string text2 = Hash.MD5(fileInfo.FullName);
					flag = text == text2;
				}
				if (flag)
				{
					using (Profile.LoadTextureFromFile.Auto())
					{
						if (Game.Instance.Device.IsWindowsBuild)
						{
							using (FileStream fileStream = fileInfo2.OpenRead())
							{
								Span<byte> buffer = stackalloc byte[148];
								int num = fileStream.Read(buffer);
								if (num != buffer.Length)
								{
									Debug.LogError($"An error occurred reading header for texture '{fileInfo2.FullName}'. Bytes read: {num}, Expected: {buffer.Length}");
									return null;
								}
								uint num2 = MemoryMarshal.Read<uint>(buffer.Slice(12, 4));
								uint num3 = MemoryMarshal.Read<uint>(buffer.Slice(16, 4));
								int num4 = 8192;
								if (num2 > num4 || num3 > num4)
								{
									Debug.LogError($"An error occurred loading texture '{fileInfo2.FullName}'. Unexpected texture size: ({num3}, {num2})");
									return null;
								}
								NativeArray<byte> data = new NativeArray<byte>((int)fileStream.Length - 148, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
								num = fileStream.Read(data.AsSpan());
								if (num != data.Length)
								{
									Debug.LogError($"An error occurred reading texture '{fileInfo2.FullName}'. Bytes read: {num}, Expected: {data.Length}");
									return null;
								}
								Texture2D texture2D = new Texture2D((int)num3, (int)num2, TextureFormat.BC7, mipChain: true, linear: true, createUninitialized: true);
								texture2D.LoadRawTextureData(data);
								texture2D.Apply(updateMipmaps: true, makeNoLongerReadable: true);
								return texture2D;
							}
						}
						return GameData.LoadTexture(fileInfo.FullName, markNonReadable: true);
					}
				}
				if (textureData == null)
				{
					throw new InvalidOperationException("Unable to load texture from disk without a 'textureData' parameter specified");
				}
				textureData.NeedsProcessed = true;
				return null;
			}
			default:
				throw new NotSupportedException($"Paint texture location type of '{locationType}' is not currently supported");
			}
		}

		private static void UnloadTexture(Texture2D texture, PaintTextureLocationType locationType)
		{
			try
			{
				switch (locationType)
				{
				case PaintTextureLocationType.Resource:
					Resources.UnloadAsset(texture);
					break;
				case PaintTextureLocationType.LocalFileSystem:
					UnityEngine.Object.Destroy(texture);
					break;
				default:
					throw new NotSupportedException($"Paint texture location type of '{locationType}' is not currently supported");
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		private Texture2DArray CreateTextureArray(PaintStyle style)
		{
			using (Profile.CreateTextureArray.Auto())
			{
				Texture2DArray texture2DArray = null;
				try
				{
					Texture2D texture2D = LoadTexture(PaintTextureLocationType.Resource, $"Craft/PaintTextures/Textures/Default_{style}");
					if (texture2D == null)
					{
						throw new Exception($"Unable to find the default paint texture for paint style '{style}'. Paint texture array could not be created.");
					}
					texture2DArray = new Texture2DArray(texture2D.width, texture2D.height, _textureData[style].Count, texture2D.format, mipChain: true, linear: true, createUninitialized: true);
					texture2DArray.name = $"CraftPaintTextureArray_{style}";
					texture2DArray.wrapMode = TextureWrapMode.Clamp;
					texture2DArray.anisoLevel = 16;
					List<PaintTextureData> list = _textureData[style];
					for (int i = 0; i < list.Count; i++)
					{
						PaintTextureData paintTextureData = list[i];
						Texture2D texture2D2 = null;
						try
						{
							texture2D2 = LoadTexture(paintTextureData);
						}
						catch (Exception exception)
						{
							Debug.LogException(exception);
						}
						paintTextureData.Loaded = texture2D2 != null;
						HasTexturesPendingProcessing |= paintTextureData.NeedsProcessed;
						Texture2D src = (paintTextureData.Loaded ? texture2D2 : texture2D);
						if (!paintTextureData.Loaded && !paintTextureData.NeedsProcessed)
						{
							Debug.LogError($"Unable to load paint texture: {paintTextureData}");
						}
						Thread.Sleep(10);
						Graphics.CopyTexture(src, 0, texture2DArray, i);
						UnloadTexture(texture2D2, paintTextureData.LocationType);
					}
					UnloadTexture(texture2D, PaintTextureLocationType.Resource);
				}
				catch (Exception exception2)
				{
					Debug.LogException(exception2);
					Debug.LogError($"Unable to create the texture array for paint style '{style}'");
				}
				return texture2DArray;
			}
		}

		private void CreateTextureArrays()
		{
			using (Profile.CreateTextureArrays.Auto())
			{
				foreach (PaintStyle key in _textureArrays.Keys)
				{
					if (key.UsesTextureAtlas())
					{
						if (_textureArrays[key] != null)
						{
							UnityEngine.Object.Destroy(_textureArrays[key]);
						}
						_textureArrays[key] = CreateTextureArray(key);
					}
				}
			}
		}

		private void Initialize()
		{
			_textureData = new EnumDictionary<PaintStyle, List<PaintTextureData>>((PaintStyle x) => new List<PaintTextureData>());
			_textureDataByID = new EnumDictionary<PaintStyle, Dictionary<string, PaintTextureData>>((PaintStyle x) => new Dictionary<string, PaintTextureData>());
			_textureDataSharedPresets = new Dictionary<string, PaintTexturePreset>();
			_textureArrays = new EnumDictionary<PaintStyle, Texture2DArray>();
			LoadTextureData();
			CreateTextureArrays();
		}

		private void InvertAlphaChannel(TextureFormat format, NativeArray<byte> pixelData)
		{
			int? num = null;
			switch (format)
			{
			case TextureFormat.RGBA32:
			case TextureFormat.BGRA32:
				num = 3;
				break;
			case TextureFormat.ARGB32:
				num = 0;
				break;
			default:
				num = null;
				break;
			}
			if (num.HasValue)
			{
				for (int i = num.Value; i < pixelData.Length; i += 4)
				{
					pixelData[i] = (byte)(255 - pixelData[i]);
				}
			}
		}

		private void LoadTextureData(XElement xml, string rootPath, PaintTextureLocationType locationType, PaintStyle style)
		{
			List<PaintTextureData> list = _textureData[style];
			Dictionary<string, PaintTextureData> dictionary = _textureDataByID[style];
			foreach (XElement item in xml.Elements("Texture"))
			{
				PaintTextureData paintTextureData = null;
				try
				{
					paintTextureData = new PaintTextureData(item, list.Count, rootPath, locationType, style, _textureDataSharedPresets);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
				if (paintTextureData == null)
				{
					Debug.LogError($"Unable to load paint texture data from XML: {item}");
					continue;
				}
				if (string.IsNullOrEmpty(paintTextureData.Id))
				{
					Debug.LogError($"Paint texture data does not have a valid ID: {item}");
					continue;
				}
				if (dictionary.ContainsKey(paintTextureData.Id))
				{
					Debug.LogError($"Encountered duplicate paint texture with id '{paintTextureData.Id}' for paint style '{style}'.");
					continue;
				}
				dictionary.Add(paintTextureData.Id, paintTextureData);
				list.Add(paintTextureData);
			}
		}

		private void LoadTextureData()
		{
			XDocument xDocument = Game.Instance.ResourceLoader.LoadXml("Craft/PaintTextures/PaintTextures");
			LoadTextureDataSharedPresets(xDocument.Root.Element("TextureColorPresets"));
			LoadTextureData(xDocument.Root.Element(PaintStyle.SinglePlaneTextureColorMask.ToString()), "Craft/PaintTextures/Textures/", PaintTextureLocationType.Resource, PaintStyle.SinglePlaneTextureColorMask);
			LoadTextureData(xDocument.Root.Element(PaintStyle.TriPlaneTextureColorMask.ToString()), "Craft/PaintTextures/Textures/", PaintTextureLocationType.Resource, PaintStyle.TriPlaneTextureColorMask);
			string path = GameData.GetPath("PaintTextures/PaintTextures.xml");
			try
			{
				xDocument = GameData.LoadXml(path, throwFileNotFoundException: false);
				if (xDocument != null)
				{
					LoadTextureDataSharedPresets(xDocument.Root.Element("TextureColorPresets"));
					LoadTextureData(xDocument.Root.Element(PaintStyle.SinglePlaneTextureColorMask.ToString()), "PaintTextures/", PaintTextureLocationType.LocalFileSystem, PaintStyle.SinglePlaneTextureColorMask);
					LoadTextureData(xDocument.Root.Element(PaintStyle.TriPlaneTextureColorMask.ToString()), "PaintTextures/", PaintTextureLocationType.LocalFileSystem, PaintStyle.TriPlaneTextureColorMask);
				}
			}
			catch (Exception exception)
			{
				Debug.LogError("Unable to load PaintTextures.xml from '" + path + "'.");
				Debug.LogException(exception);
			}
		}

		private void LoadTextureDataSharedPresets(XElement xml)
		{
			if (xml == null)
			{
				return;
			}
			foreach (XElement item in xml.Elements("Preset"))
			{
				string text = (string)item.Attribute("refId");
				if (string.IsNullOrEmpty(text))
				{
					Debug.LogError($"Unable to load shared paint texture preset because the refId is null or empty: {System.Environment.NewLine}{item}");
					continue;
				}
				PaintTexturePreset paintTexturePreset = PaintTexturePreset.LoadFromXml(item);
				if (paintTexturePreset != null)
				{
					bool num = _textureDataSharedPresets.ContainsKey(text);
					_textureDataSharedPresets[text] = paintTexturePreset;
					if (num)
					{
						Debug.Log("Replacing paint texture preset with refId '" + text + "'");
					}
				}
			}
		}
	}
}
