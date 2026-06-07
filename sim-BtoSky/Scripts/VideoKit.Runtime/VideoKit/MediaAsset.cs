using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AOT;
using Muna;
using Muna.Beta.OpenAI;
using NJsonSchema;
using NJsonSchema.Generation;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;
using UnityEngine.Networking;
using VideoKit.Internal;

namespace VideoKit
{
	public sealed class MediaAsset
	{
		public enum MediaType
		{
			[EnumMember(Value = "unknown")]
			Unknown = 0,
			[EnumMember(Value = "image")]
			Image = 1,
			[EnumMember(Value = "audio")]
			Audio = 2,
			[EnumMember(Value = "video")]
			Video = 3,
			[EnumMember(Value = "text")]
			Text = 4,
			[EnumMember(Value = "sequence")]
			Sequence = 5
		}

		[JsonConverter(typeof(StringEnumConverter))]
		public enum NarrationVoice
		{
			[EnumMember(Value = "kevin")]
			Kevin = 1,
			[EnumMember(Value = "arjun")]
			Arjun = 2,
			[EnumMember(Value = "dami")]
			Dami = 3,
			[EnumMember(Value = "juan")]
			Juan = 4,
			[EnumMember(Value = "rhea")]
			Rhea = 5,
			[EnumMember(Value = "aliyah")]
			Aliyah = 6,
			[EnumMember(Value = "kristen")]
			Kristen = 7,
			[EnumMember(Value = "salma")]
			Salma = 8
		}

		private readonly struct NativeMediaSequence : IReadOnlyList<MediaAsset?>, IEnumerable<MediaAsset?>, IEnumerable, IReadOnlyCollection<MediaAsset?>
		{
			private readonly MediaAsset asset;

			public int Count
			{
				get
				{
					if (asset.handle.GetMediaAssetSubAssetCount(out var count) == VideoKit.Internal.VideoKit.Status.Ok)
					{
						return count;
					}
					return 0;
				}
			}

			public MediaAsset? this[int index]
			{
				get
				{
					asset.handle.GetMediaAssetSubAsset(index, out var subAsset).Throw();
					return new MediaAsset(subAsset, asset);
				}
			}

			public NativeMediaSequence(MediaAsset asset)
			{
				this.asset = asset;
			}

			IEnumerator<MediaAsset?> IEnumerable<MediaAsset>.GetEnumerator()
			{
				int idx = 0;
				while (idx < Count)
				{
					yield return this[idx];
					int num = idx + 1;
					idx = num;
				}
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<MediaAsset>)this).GetEnumerator();
			}
		}

		private readonly IntPtr handle;

		private readonly MediaAsset? parent;

		private static readonly Dictionary<NarrationVoice, string> SpeechPredictorMap = new Dictionary<NarrationVoice, string>();

		internal const string TranscribeTag = "@videokit/transcribe-v1";

		public string? path
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder(2048);
				if (handle.GetMediaAssetPath(stringBuilder, stringBuilder.Capacity) != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return null;
				}
				return stringBuilder.ToString();
			}
		}

		public MediaType type
		{
			get
			{
				if (handle.GetMediaAssetMediaType(out var result).Throw() != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return MediaType.Unknown;
				}
				return result;
			}
		}

		public int width
		{
			get
			{
				if (handle.GetMediaAssetWidth(out var result) != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return 0;
				}
				return result;
			}
		}

		public int height
		{
			get
			{
				if (handle.GetMediaAssetHeight(out var result) != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return 0;
				}
				return result;
			}
		}

		public float frameRate
		{
			get
			{
				if (handle.GetMediaAssetFrameRate(out var result) != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return 0f;
				}
				return result;
			}
		}

		public int sampleRate
		{
			get
			{
				if (handle.GetMediaAssetSampleRate(out var result) != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return 0;
				}
				return result;
			}
		}

		public int channelCount
		{
			get
			{
				if (handle.GetMediaAssetChannelCount(out var result) != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return 0;
				}
				return result;
			}
		}

		public float duration
		{
			get
			{
				if (handle.GetMediaAssetDuration(out var result) != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return 0f;
				}
				return result;
			}
		}

		public IReadOnlyList<MediaAsset> assets => new NativeMediaSequence(this);

		public static Task<MediaAsset> FromFile(string path)
		{
			TaskCompletionSource<MediaAsset> taskCompletionSource = new TaskCompletionSource<MediaAsset>();
			GCHandle gCHandle = GCHandle.Alloc(taskCompletionSource, GCHandleType.Normal);
			try
			{
				VideoKit.Internal.VideoKit.CreateMediaAsset(path, OnCreateAsset, (IntPtr)gCHandle).Throw();
			}
			catch (Exception exception)
			{
				gCHandle.Free();
				taskCompletionSource.SetException(exception);
			}
			return taskCompletionSource.Task;
		}

		public static Task<MediaAsset> FromTexture(Texture2D texture)
		{
			if (texture == null)
			{
				return Task.FromException<MediaAsset>(new ArgumentNullException("texture"));
			}
			if (!texture.isReadable)
			{
				return Task.FromException<MediaAsset>(new ArgumentException("Cannot create media asset from texture that is not readable"));
			}
			byte[] bytes = texture.EncodeToPNG();
			string text = Guid.NewGuid().ToString("N");
			string text2 = Path.Combine(Application.temporaryCachePath, text + ".png");
			File.WriteAllBytes(text2, bytes);
			return FromFile(text2);
		}

		public static async Task<MediaAsset> FromAudioClip(AudioClip clip, MediaRecorder.Format format = MediaRecorder.Format.WAV)
		{
			float[] data = new float[clip.samples * clip.channels];
			clip.GetData(data, 0);
			using AudioBuffer audioBuffer = new AudioBuffer(clip.frequency, clip.channels, data, 0L);
			MediaRecorder obj = await MediaRecorder.Create(format, 0, 0, 0f, audioBuffer.sampleRate, audioBuffer.channelCount);
			obj.Append(audioBuffer);
			return await obj.FinishWriting();
		}

		public static Task<MediaAsset> FromText(string text)
		{
			string text2 = Guid.NewGuid().ToString("N");
			string text3 = Path.Combine(Application.temporaryCachePath, text2 + ".txt");
			File.WriteAllText(text3, text);
			return FromFile(text3);
		}

		public static Task<MediaAsset?> FromCameraRoll(MediaType type)
		{
			TaskCompletionSource<MediaAsset> taskCompletionSource = new TaskCompletionSource<MediaAsset>();
			GCHandle gCHandle = GCHandle.Alloc(taskCompletionSource, GCHandleType.Normal);
			try
			{
				VideoKit.Internal.VideoKit.CreateMediaAssetFromCameraRoll(type, OnCreateAsset, (IntPtr)gCHandle).Throw();
			}
			catch (Exception exception)
			{
				gCHandle.Free();
				taskCompletionSource.SetException(exception);
			}
			return taskCompletionSource.Task;
		}

		public static async Task<MediaAsset?> FromStreamingAssets(string path)
		{
			return await FromFile((await StreamingAssetsToAbsolutePath(path)) ?? throw new InvalidOperationException("Failed to create media asset because file '" + path + "' could not be found in `StreamingAssets`"));
		}

		public static Task<MediaAsset> FromConcatenatingAssets(params MediaAsset[] assets)
		{
			return FromConcatenatingAssets(assets, MediaRecorder.Format.MP4);
		}

		public static async Task<MediaAsset> FromConcatenatingAssets(MediaAsset[] assets, MediaRecorder.Format format, string? prefix = null)
		{
			if (assets.Length == 0)
			{
				throw new ArgumentException("Concatenate requires at least one media asset");
			}
			if (assets.Any((MediaAsset asset) => asset.type != MediaType.Video))
			{
				throw new NotImplementedException("Concatenate only supports video assets");
			}
			int width = assets[0].width;
			int height = assets[0].height;
			if (assets.Any((MediaAsset asset) => asset.width != width || asset.height != height))
			{
				throw new ArgumentException("Concatenate requires that all videos have the same resolution");
			}
			if (assets.Any((MediaAsset asset) => asset.sampleRate > 0 && asset.channelCount > 0))
			{
				throw new NotImplementedException("Concatenate only supports videos without audio");
			}
			float frameRate = assets[0].frameRate;
			MediaRecorder mediaRecorder = await MediaRecorder.Create(format, width, height, frameRate, 0, 0, 20000000, 2, 0.8f, 64000, prefix);
			GCHandle gCHandle = GCHandle.Alloc(new byte[width * height * 4], GCHandleType.Pinned);
			IntPtr intPtr = gCHandle.AddrOfPinnedObject();
			long num = 0L;
			try
			{
				foreach (MediaAsset obj in assets)
				{
					long num3 = 0L;
					foreach (PixelBuffer item in obj.Read<PixelBuffer>())
					{
						using PixelBuffer pixelBuffer = Wrap(intPtr, width, height, num + item.timestamp);
						item.CopyTo(pixelBuffer);
						mediaRecorder.Append(pixelBuffer);
						num3 = pixelBuffer.timestamp;
					}
					num = num3 + (long)(1E+09f / frameRate);
				}
			}
			finally
			{
				gCHandle.Free();
			}
			return await mediaRecorder.FinishWriting();
			unsafe static PixelBuffer Wrap(IntPtr handle, int num4, int num5, long timestamp)
			{
				return new PixelBuffer(num4, num5, PixelBuffer.Format.RGBA8888, (byte*)(void*)handle, 0, timestamp);
			}
		}

		internal static async Task<MediaAsset> FromGeneratedSpeech(string prompt, NarrationVoice voice, float speed = 1f)
		{
			OpenAIClient openAI = VideoKitClient.Instance.muna.Beta.OpenAI;
			string model = SpeechPredictorMap[voice];
			return await FromAudioClip(ToAudioClip(await openAI.Audio.Speech.Create(model, prompt, GetEnumValueString(voice), speed, SpeechService.ResponseFormat.PCM, SpeechService.StreamFormat.Audio, Acceleration.Auto)));
		}

		public static async Task<MediaAsset> FromGeneratedTranscription(AudioClip audio)
		{
			return await FromGeneratedTranscription((await FromAudioClip(audio)).path);
		}

		public static async Task<MediaAsset> FromGeneratedTranscription(string path)
		{
			OpenAIClient openAI = VideoKitClient.Instance.muna.Beta.OpenAI;
			using FileStream stream = File.OpenRead(path);
			return await FromText((await openAI.Audio.Transcriptions.Create("@videokit/transcribe-v1", stream)).Text);
		}

		internal static async Task<MediaAsset> FromGeneratedImage(string prompt, int width = 1024, int height = 1024)
		{
			return null;
		}

		public string ToText()
		{
			if (type != MediaType.Text)
			{
				throw new ArgumentException("`MediaAsset.ToText` can only be used on text assets");
			}
			if (string.IsNullOrEmpty(path))
			{
				throw new InvalidOperationException("Text asset does not have a valid file path");
			}
			return File.ReadAllText(path);
		}

		public async Task<Texture2D> ToTexture(float time = 0f)
		{
			if (type == MediaType.Video)
			{
				throw new NotImplementedException("`MediaAsset.ToTexture` is not yet supported for video assets");
			}
			if (type != MediaType.Image)
			{
				throw new ArgumentException("`MediaAsset.ToTexture` can only be used on image assets");
			}
			string uri = ((path[0] == '/') ? ("file://" + path) : path);
			using UnityWebRequest request = UnityWebRequestTexture.GetTexture(uri);
			request.SendWebRequest();
			while (!request.isDone)
			{
				await Task.Yield();
			}
			if (request.result != UnityWebRequest.Result.Success)
			{
				throw new InvalidOperationException("Image asset could not be loaded with error: " + request.error);
			}
			return DownloadHandlerTexture.GetContent(request);
		}

		public async Task<AudioClip> ToAudioClip()
		{
			if (type != MediaType.Audio)
			{
				throw new ArgumentException($"Cannot create audio clip from asset because asset has invalid type: {type}");
			}
			string uri = ((path[0] == '/') ? ("file://" + path) : path);
			using UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip(uri, AudioType.WAV);
			request.SendWebRequest();
			while (!request.isDone)
			{
				await Task.Yield();
			}
			if (request.result != UnityWebRequest.Result.Success)
			{
				throw new InvalidOperationException("Audio clip could not be loaded with error: " + request.error);
			}
			return DownloadHandlerAudioClip.GetContent(request);
		}

		public IEnumerable<T> Read<T>() where T : struct
		{
			MediaType type = GetMediaType<T>();
			foreach (IntPtr item in Read(type))
			{
				switch (type)
				{
				case MediaType.Video:
					yield return (T)(object)new PixelBuffer(item);
					continue;
				case MediaType.Audio:
					yield return (T)(object)new AudioBuffer(item);
					continue;
				}
				break;
			}
		}

		internal async Task<T> Parse<T>()
		{
			if (type != MediaType.Text)
			{
				throw new ArgumentException("Cannot perform structured parsing on media asset because asset is not a text asset");
			}
			JsonSchema.FromType<T>(new JsonSchemaGeneratorSettings
			{
				GenerateAbstractSchemas = false,
				GenerateExamples = false,
				UseXmlDocumentation = false,
				ResolveExternalXmlDocumentation = false,
				FlattenInheritanceHierarchy = false
			});
			return default(T);
		}

		public Task<MediaAsset> Take(float duration, MediaRecorder.Format format = MediaRecorder.Format.MP4, string? prefix = null)
		{
			return Take(TimeSpan.FromSeconds(duration), format, prefix);
		}

		public async Task<MediaAsset> Take(TimeSpan duration, MediaRecorder.Format format = MediaRecorder.Format.MP4, string? prefix = null)
		{
			if (type != MediaType.Video)
			{
				throw new NotImplementedException("Trimming media assets is only supported for videos");
			}
			if (sampleRate > 0 && channelCount > 0)
			{
				throw new NotImplementedException("Trimming videos with audio is not yet supported");
			}
			if ((double)this.duration < duration.TotalSeconds)
			{
				return this;
			}
			MediaRecorder mediaRecorder = await MediaRecorder.Create(format, width, height, frameRate, 0, 0, 20000000, 2, 0.8f, 64000, prefix);
			GCHandle gCHandle = GCHandle.Alloc(new byte[width * height * 4], GCHandleType.Pinned);
			IntPtr intPtr = gCHandle.AddrOfPinnedObject();
			try
			{
				foreach (PixelBuffer item in Read<PixelBuffer>())
				{
					if (!((double)item.timestamp > duration.TotalMilliseconds * 1000000.0))
					{
						using (PixelBuffer pixelBuffer = Wrap(intPtr, width, height, item.timestamp))
						{
							item.CopyTo(pixelBuffer);
							mediaRecorder.Append(pixelBuffer);
						}
						continue;
					}
					break;
				}
			}
			finally
			{
				gCHandle.Free();
			}
			return await mediaRecorder.FinishWriting();
			unsafe static PixelBuffer Wrap(IntPtr handle, int width, int height, long timestamp)
			{
				return new PixelBuffer(width, height, PixelBuffer.Format.RGBA8888, (byte*)(void*)handle, 0, timestamp);
			}
		}

		public Task<MediaAsset> TakeLast(float duration, MediaRecorder.Format format = MediaRecorder.Format.MP4, string? prefix = null)
		{
			return TakeLast(TimeSpan.FromSeconds(duration), format, prefix);
		}

		public async Task<MediaAsset> TakeLast(TimeSpan duration, MediaRecorder.Format format = MediaRecorder.Format.MP4, string? prefix = null)
		{
			if (type != MediaType.Video)
			{
				throw new NotImplementedException("Trimming media assets is only supported for videos");
			}
			if (sampleRate > 0 && channelCount > 0)
			{
				throw new NotImplementedException("Trimming videos with audio is not yet supported");
			}
			if ((double)this.duration < duration.TotalSeconds)
			{
				return this;
			}
			MediaRecorder mediaRecorder = await MediaRecorder.Create(format, width, height, frameRate, 0, 0, 20000000, 2, 0.8f, 64000, prefix);
			GCHandle gCHandle = GCHandle.Alloc(new byte[width * height * 4], GCHandleType.Pinned);
			IntPtr intPtr = gCHandle.AddrOfPinnedObject();
			long num = (long)(duration.TotalMilliseconds * 1000000.0);
			long num2 = (long)(this.duration * 1E+09f) - num;
			long? num3 = null;
			try
			{
				foreach (PixelBuffer item in Read<PixelBuffer>())
				{
					long timestamp = item.timestamp;
					if (timestamp >= num2)
					{
						if (!num3.HasValue)
						{
							num3 = timestamp;
						}
						using PixelBuffer pixelBuffer = Wrap(intPtr, width, height, timestamp - num3.Value);
						item.CopyTo(pixelBuffer);
						mediaRecorder.Append(pixelBuffer);
					}
				}
			}
			finally
			{
				gCHandle.Free();
			}
			return await mediaRecorder.FinishWriting();
			unsafe static PixelBuffer Wrap(IntPtr handle, int width, int height, long timestamp2)
			{
				return new PixelBuffer(width, height, PixelBuffer.Format.RGBA8888, (byte*)(void*)handle, 0, timestamp2);
			}
		}

		public Task<string?> Share(string? message = null)
		{
			if (type == MediaType.Sequence)
			{
				throw new InvalidOperationException("Sequence assets cannot be shared");
			}
			TaskCompletionSource<string> taskCompletionSource = new TaskCompletionSource<string>();
			GCHandle gCHandle = GCHandle.Alloc(taskCompletionSource, GCHandleType.Normal);
			try
			{
				handle.ShareMediaAsset(message, OnShare, (IntPtr)gCHandle).Throw();
			}
			catch (NotImplementedException)
			{
				taskCompletionSource.SetResult(null);
				gCHandle.Free();
			}
			catch (Exception exception)
			{
				taskCompletionSource.SetException(exception);
				gCHandle.Free();
			}
			return taskCompletionSource.Task;
		}

		public Task<bool> SaveToCameraRoll(string? album = null)
		{
			if (type == MediaType.Sequence)
			{
				throw new InvalidOperationException("Sequence assets cannot be saved to the camera roll");
			}
			TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
			GCHandle gCHandle = GCHandle.Alloc(taskCompletionSource, GCHandleType.Normal);
			try
			{
				handle.SaveMediaAssetToCameraRoll(album, OnSaveToCameraRoll, (IntPtr)gCHandle).Throw();
			}
			catch (NotImplementedException)
			{
				taskCompletionSource.SetResult(result: false);
				gCHandle.Free();
			}
			catch (Exception exception)
			{
				taskCompletionSource.SetException(exception);
				gCHandle.Free();
			}
			return taskCompletionSource.Task;
		}

		internal MediaAsset(IntPtr handle, MediaAsset? parent = null)
		{
			this.handle = handle;
			this.parent = parent;
		}

		~MediaAsset()
		{
			if (parent == null)
			{
				handle.ReleaseMediaAsset();
			}
		}

		private IEnumerable<IntPtr> Read(MediaType type)
		{
			handle.CreateMediaReader(type, out var reader).Throw();
			try
			{
				IntPtr sampleBuffer;
				while (reader.ReadNextSampleBuffer(out sampleBuffer) != VideoKit.Internal.VideoKit.Status.InvalidOperation)
				{
					if (!(sampleBuffer == (IntPtr)0))
					{
						yield return sampleBuffer;
						sampleBuffer.ReleaseSampleBuffer();
					}
				}
			}
			finally
			{
				reader.ReleaseMediaReader();
			}
		}

		public static implicit operator IntPtr(MediaAsset asset)
		{
			return asset.handle;
		}

		[MonoPInvokeCallback(typeof(VideoKit.Internal.VideoKit.MediaAssetHandler))]
		private static void OnCreateAsset(IntPtr context, IntPtr asset)
		{
			try
			{
				if (VideoKit.Internal.VideoKit.IsAppDomainLoaded)
				{
					GCHandle gCHandle = (GCHandle)context;
					TaskCompletionSource<MediaAsset> obj = gCHandle.Target as TaskCompletionSource<MediaAsset>;
					gCHandle.Free();
					obj?.SetResult((asset != IntPtr.Zero) ? new MediaAsset(asset) : null);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		[MonoPInvokeCallback(typeof(VideoKit.Internal.VideoKit.MediaAssetShareHandler))]
		private static void OnShare(IntPtr context, IntPtr receiver)
		{
			try
			{
				if (VideoKit.Internal.VideoKit.IsAppDomainLoaded)
				{
					GCHandle gCHandle = (GCHandle)context;
					TaskCompletionSource<string> obj = gCHandle.Target as TaskCompletionSource<string>;
					gCHandle.Free();
					string result = Marshal.PtrToStringUTF8(receiver);
					obj?.SetResult(result);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		[MonoPInvokeCallback(typeof(VideoKit.Internal.VideoKit.MediaAssetShareHandler))]
		private static void OnSaveToCameraRoll(IntPtr context, IntPtr receiver)
		{
			try
			{
				if (VideoKit.Internal.VideoKit.IsAppDomainLoaded)
				{
					GCHandle gCHandle = (GCHandle)context;
					TaskCompletionSource<bool> obj = gCHandle.Target as TaskCompletionSource<bool>;
					gCHandle.Free();
					bool result = receiver != IntPtr.Zero;
					obj?.SetResult(result);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		private static async Task<string?> StreamingAssetsToAbsolutePath(string relativePath)
		{
			string text = Path.Combine(Application.streamingAssetsPath, relativePath);
			if (Application.platform != RuntimePlatform.Android)
			{
				return File.Exists(text) ? text : null;
			}
			string persistentPath = Path.Combine(Application.persistentDataPath, relativePath);
			if (File.Exists(persistentPath))
			{
				return persistentPath;
			}
			Directory.CreateDirectory(Path.GetDirectoryName(persistentPath));
			using UnityWebRequest request = UnityWebRequest.Get(text);
			request.SendWebRequest();
			while (!request.isDone)
			{
				await Task.Yield();
			}
			if (request.result != UnityWebRequest.Result.Success)
			{
				return null;
			}
			File.WriteAllBytes(persistentPath, request.downloadHandler.data);
			return persistentPath;
		}

		private static MediaType GetMediaType<T>()
		{
			Type typeFromHandle = typeof(T);
			if (typeFromHandle == typeof(AudioBuffer))
			{
				return MediaType.Audio;
			}
			if (typeFromHandle == typeof(PixelBuffer))
			{
				return MediaType.Video;
			}
			return MediaType.Unknown;
		}

		private static string? GetEnumValueString(Enum value)
		{
			if (!(value.GetType().GetField(value.ToString())?.GetCustomAttributes(typeof(EnumMemberAttribute), inherit: false)?.FirstOrDefault() is EnumMemberAttribute { IsValueSetExplicitly: not false } enumMemberAttribute))
			{
				return null;
			}
			return enumMemberAttribute.Value;
		}

		private static AudioClip ToAudioClip(BinaryData data)
		{
			Match match = Regex.Match(data.MediaType, "rate=(\\d+)");
			Match match2 = Regex.Match(data.MediaType, "channels=(\\d+)");
			if (!match.Success || !match2.Success)
			{
				throw new ArgumentException("Failed to extract audio format from speech binary data because media type is invalid: '" + data.MediaType + "'");
			}
			if (!int.TryParse(match.Groups[1].Value, out var result))
			{
				throw new ArgumentException("Failed to parse sample rate from speech binary data because it is invalid: '" + match.Value + "'");
			}
			if (!int.TryParse(match2.Groups[1].Value, out var result2))
			{
				throw new ArgumentException("Failed to parse channel count from speech binary data because it is invalid: '" + match2.Value + "'");
			}
			int num = data.Length / 4;
			int lengthSamples = num / result2;
			AudioClip audioClip = AudioClip.Create("audio", lengthSamples, result2, result, stream: false);
			float[] array = new float[num];
			Buffer.BlockCopy(data.ToArray(), 0, array, 0, data.Length);
			audioClip.SetData(array, 0);
			return audioClip;
		}

		[Obsolete("Deprecated in VideoKit 1.0.11. Use `MediaAsset.FromConcatenatingAssets` static method instead.")]
		public static Task<MediaAsset> Concatenate(params MediaAsset[] assets)
		{
			return FromConcatenatingAssets(assets, MediaRecorder.Format.MP4);
		}

		[Obsolete("Deprecated in VideoKit 1.0.11. Use `MediaAsset.FromConcatenatingAssets` static method instead.")]
		public static Task<MediaAsset> Concatenate(MediaAsset[] assets, MediaRecorder.Format format, string? prefix = null)
		{
			return FromConcatenatingAssets(assets, format, prefix);
		}

		[Obsolete("Deprecated in VideoKit 1.0.11. Use `MediaAsset.Take` instance method instead.")]
		public static Task<MediaAsset> Take(MediaAsset asset, float duration, MediaRecorder.Format format = MediaRecorder.Format.MP4, string? prefix = null)
		{
			return asset.Take(duration, format, prefix);
		}

		[Obsolete("Deprecated in VideoKit 1.0.11. Use `MediaAsset.Take` instance method instead.")]
		public static Task<MediaAsset> Take(MediaAsset asset, TimeSpan duration, MediaRecorder.Format format = MediaRecorder.Format.MP4, string? prefix = null)
		{
			return asset.Take(duration, format, prefix);
		}

		[Obsolete("Deprecated in VideoKit 1.0.11. Use `MediaAsset.TakeLast` instance method instead.")]
		public static Task<MediaAsset> TakeLast(MediaAsset asset, float duration, MediaRecorder.Format format = MediaRecorder.Format.MP4, string? prefix = null)
		{
			return asset.TakeLast(duration, format, prefix);
		}
	}
}
