using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Muna.Beta.Services;
using Muna.C;
using Muna.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Muna.Beta.OpenAI
{
	public sealed class SpeechService
	{
		[JsonConverter(typeof(StringEnumConverter))]
		public enum ResponseFormat
		{
			[EnumMember(Value = "mp3")]
			MP3 = 1,
			[EnumMember(Value = "opus")]
			Opus = 2,
			[EnumMember(Value = "aac")]
			AAC = 3,
			[EnumMember(Value = "flac")]
			FLAC = 4,
			[EnumMember(Value = "wav")]
			WAV = 5,
			[EnumMember(Value = "pcm")]
			PCM = 6
		}

		[JsonConverter(typeof(StringEnumConverter))]
		public enum StreamFormat
		{
			Audio = 1,
			SSE = 2
		}

		private delegate Task<BinaryData> SpeechDelegate(string model, string input, string voice, float speed, ResponseFormat responseFormat, StreamFormat streamFormat, object acceleration);

		private readonly PredictorService predictors;

		private readonly global::Muna.Services.PredictionService predictions;

		private readonly RemotePredictionService remotePredictions;

		private readonly Dictionary<string, SpeechDelegate> cache;

		public async Task<BinaryData> Create(string model, string input, string voice, float speed = 1f, ResponseFormat responseFormat = ResponseFormat.MP3, StreamFormat streamFormat = StreamFormat.Audio, object? acceleration = null)
		{
			if (!cache.ContainsKey(model))
			{
				SpeechDelegate value = await CreateSpeechDelegate(model);
				cache.Add(model, value);
			}
			return await cache[model](model, input, voice, speed, responseFormat, streamFormat, acceleration ?? ((object)Acceleration.Auto));
		}

		internal SpeechService(PredictorService predictors, global::Muna.Services.PredictionService predictions, RemotePredictionService remotePredictions)
		{
			this.predictors = predictors;
			this.predictions = predictions;
			this.remotePredictions = remotePredictions;
			cache = new Dictionary<string, SpeechDelegate>();
		}

		private async Task<SpeechDelegate> CreateSpeechDelegate(string tag)
		{
			Signature signature = ((await predictors.Retrieve(tag)) ?? throw new ArgumentException(tag + " cannot be used with OpenAI speech API because the predictor could not be found. Check that your access key is valid and that you have access to the predictor.")).signature;
			Parameter[] array = signature.inputs.Where((Parameter parameter) => parameter.optional == false).ToArray();
			if (array.Length != 2)
			{
				throw new InvalidOperationException(tag + " cannot be used with OpenAI speech API because it does not have exactly two required input parameters.");
			}
			Parameter inputParam = array.FirstOrDefault((Parameter parameter) => parameter.dtype == Dtype.String);
			if (inputParam == null)
			{
				throw new InvalidOperationException(tag + " cannot be used with OpenAI speech API because it does not have the required speech input parameter.");
			}
			Parameter voiceParam = array.FirstOrDefault((Parameter parameter) => parameter.dtype == Dtype.String && parameter.denotation == "openai.audio.speech.voice");
			if (voiceParam == null)
			{
				throw new InvalidOperationException(tag + " cannot be used with OpenAI speech API because it does not have the required speech voice parameter.");
			}
			Parameter speedParam = signature.inputs.FirstOrDefault((Parameter parameter) => new Dtype[2]
			{
				Dtype.Float32,
				Dtype.Float64
			}.Contains(parameter.dtype) && parameter.denotation == "openai.audio.speech.speed");
			var (audioParamIdx, audioParam) = (from pair in signature.outputs.Select((Parameter parameter, int idx) => (idx: idx, parameter: parameter))
				where pair.parameter.dtype == Dtype.Float32 && pair.parameter.denotation == "audio"
				select pair).FirstOrDefault();
			if (audioParam == null)
			{
				throw new InvalidOperationException(tag + " cannot be used with OpenAI speech API because it has no outputs with an `audio` denotation.");
			}
			return async delegate(string model, string input, string voice, float speed, ResponseFormat responseFormat, StreamFormat streamFormat, object acceleration)
			{
				if (streamFormat != StreamFormat.Audio)
				{
					throw new ArgumentException($"Cannot create speech with stream format `{streamFormat}` " + "because only `Audio` is currently supported.");
				}
				Dictionary<string, object> dictionary = new Dictionary<string, object>
				{
					[inputParam.name] = input,
					[voiceParam.name] = voice
				};
				if (speedParam != null)
				{
					dictionary[speedParam.name] = speed;
				}
				Prediction prediction = await CreatePrediction(model, dictionary, acceleration);
				if (prediction.error != null)
				{
					throw new InvalidOperationException(prediction.error);
				}
				object obj = prediction.results[audioParamIdx];
				if (!(obj is Tensor<float> audio))
				{
					throw new InvalidOperationException($"{tag} returned object of type {obj.GetType()} instead of an audio tensor");
				}
				if (audio.shape.Length != 1 && audio.shape.Length != 2)
				{
					throw new InvalidOperationException(tag + " returned audio tensor with invalid shape: (" + string.Join(",", audio.shape) + ")");
				}
				var (data, mediaType) = CreateResponseData(audio, audioParam.sampleRate.Value, responseFormat);
				return new BinaryData(data, mediaType);
			};
		}

		private Task<Prediction> CreatePrediction(string tag, Dictionary<string, object?> inputs, object acceleration)
		{
			if (!(acceleration is Acceleration acceleration2))
			{
				if (acceleration is RemoteAcceleration acceleration3)
				{
					return remotePredictions.Create(tag, inputs, acceleration3);
				}
				throw new InvalidOperationException($"Cannot create {tag} prediction because acceleration is invalid: {acceleration}");
			}
			return predictions.Create(tag, inputs, acceleration2, (IntPtr)0);
		}

		private unsafe static (byte[] content, string contentType) CreateResponseData(Tensor<float> audio, int sampleRate, ResponseFormat responseFormat)
		{
			int num = ((audio.shape.Length != 2) ? 1 : audio.shape[1]);
			if (responseFormat == ResponseFormat.PCM)
			{
				string item = string.Join(";", "audio/pcm", $"rate={sampleRate}", $"channels={num}", "encoding=float", "bits=32");
				byte[] array = new byte[audio.shape.Aggregate(1, (int a, int b) => a * b) * 4];
				fixed (float* source = audio)
				{
					fixed (byte* destination = array)
					{
						Buffer.MemoryCopy(source, destination, array.Length, array.Length);
					}
				}
				return (content: array, contentType: item);
			}
			using Value value = Value.CreateArray(in audio, Value.Flags.CopyData);
			string text = $"audio/{(global::Muna.Services.PredictionService.SerializeEnum(responseFormat))};rate={sampleRate}";
			return (content: value.Serialize(text), contentType: text);
		}
	}
}
