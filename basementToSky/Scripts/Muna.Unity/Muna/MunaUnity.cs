using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Muna.API;
using Muna.Beta.OpenAI;
using Muna.Internal;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Muna
{
	public static class MunaUnity
	{
		private static readonly Dictionary<TextureFormat, int> TextureFormatToImageChannels = new Dictionary<TextureFormat, int>
		{
			[TextureFormat.R8] = 1,
			[TextureFormat.Alpha8] = 1,
			[TextureFormat.RGB24] = 3,
			[TextureFormat.RGBA32] = 4
		};

		private static readonly Dictionary<int, TextureFormat> ImageChannelsToTextureFormat = new Dictionary<int, TextureFormat>
		{
			[1] = TextureFormat.Alpha8,
			[3] = TextureFormat.RGB24,
			[4] = TextureFormat.RGBA32
		};

		public static Muna Create(string? accessKey = null, string? url = null)
		{
			MunaSettings instance = MunaSettings.Instance;
			return new Muna(new PredictionCacheClient(url ?? "https://api.muna.ai/v1", accessKey ?? instance?.accessKey));
		}

		public unsafe static Image ToImage(this Texture2D texture, byte[]? pixelBuffer = null)
		{
			if (texture == null)
			{
				throw new ArgumentNullException("texture");
			}
			if (!texture.isReadable)
			{
				throw new InvalidOperationException("Texture cannot be converted to a Muna image because it is not readable");
			}
			int valueOrDefault = TextureFormatToImageChannels.GetValueOrDefault(texture.format, 4);
			int num = texture.width * valueOrDefault;
			int num2 = num * texture.height;
			if (pixelBuffer == null)
			{
				pixelBuffer = new byte[num2];
			}
			if (pixelBuffer.Length < num2)
			{
				throw new InvalidOperationException($"Texture cannot be converted to a Muna image because pixel buffer length was expected to be greater than or equal to {num2} but got {pixelBuffer.Length}");
			}
			Color32[] obj = ((!TextureFormatToImageChannels.ContainsKey(texture.format)) ? texture.GetPixels32() : null);
			fixed (byte* ptr = pixelBuffer)
			{
				void* destination = ptr;
				fixed (Color32* ptr2 = obj)
				{
					void* ptr3 = ptr2;
					void* ptr4 = ((ptr3 == null) ? texture.GetRawTextureData<byte>().GetUnsafePtr() : ptr3);
					UnsafeUtility.MemCpyStride(destination, num, (byte*)ptr4 + num * (texture.height - 1), -num, num, texture.height);
				}
			}
			return new Image(pixelBuffer, texture.width, texture.height, valueOrDefault);
		}

		public unsafe static Texture2D ToTexture(this Image image, Texture2D? texture = null)
		{
			if (!ImageChannelsToTextureFormat.TryGetValue(image.channels, out var value))
			{
				throw new InvalidOperationException($"Image cannot be converted to a Texture2D because it has unsupported channel count: {image.channels}");
			}
			texture = ((texture != null) ? texture : new Texture2D(image.width, image.height, value, mipChain: false));
			if (texture.width != image.width || texture.height != image.height || texture.format != value)
			{
				texture.Reinitialize(image.width, image.height, value, hasMipMap: false);
			}
			int num = image.width * image.channels;
			fixed (byte* ptr = image)
			{
				UnsafeUtility.MemCpyStride(texture.GetRawTextureData<byte>().GetUnsafePtr(), num, ptr + num * (image.height - 1), -num, num, image.height);
			}
			texture.Apply();
			return texture;
		}

		public static AudioClip ToAudioClip(this BinaryData data)
		{
			if (string.IsNullOrEmpty(data.MediaType) || !data.MediaType.StartsWith("audio/pcm"))
			{
				throw new ArgumentException("Failed to create audio clip from binary data because media type was expected to be 'audio/pcm' but got: '" + data.MediaType + "'");
			}
			Match match = Regex.Match(data.MediaType, "rate=(\\d+)");
			Match match2 = Regex.Match(data.MediaType, "channels=(\\d+)");
			if (!match.Success || !match2.Success)
			{
				throw new ArgumentException("Failed to create audio clip from binary data because media type is invalid: '" + data.MediaType + "'");
			}
			if (!int.TryParse(match.Groups[1].Value, out var result))
			{
				throw new ArgumentException("Failed to create audio clip from binary data because sample rate is invalid: '" + match.Value + "'");
			}
			if (!int.TryParse(match2.Groups[1].Value, out var result2))
			{
				throw new ArgumentException("Failed to create audio clip from binary data because channel count is invalid: '" + match2.Value + "'");
			}
			int num = data.Length / 4;
			int lengthSamples = num / result2;
			AudioClip audioClip = AudioClip.Create("audio", lengthSamples, result2, result, stream: false);
			float[] array = new float[num];
			Buffer.BlockCopy(data.ToArray(), 0, array, 0, data.Length);
			audioClip.SetData(array, 0);
			return audioClip;
		}
	}
}
