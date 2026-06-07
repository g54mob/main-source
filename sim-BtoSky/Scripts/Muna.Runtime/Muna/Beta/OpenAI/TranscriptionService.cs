using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Muna.Beta.Services;
using Muna.C;
using Muna.Services;

namespace Muna.Beta.OpenAI
{
	public sealed class TranscriptionService
	{
		private delegate Task<Transcription> TranscriptionDelegate(string model, object file, string? language, string? prompt, float temperature, object acceleration);

		private readonly PredictorService predictors;

		private readonly global::Muna.Services.PredictionService predictions;

		private readonly RemotePredictionService remotePredictions;

		private readonly Dictionary<string, TranscriptionDelegate> cache;

		public Task<Transcription> Create(string model, Stream file, string? language = null, string? prompt = null, float temperature = 0f, object? acceleration = null)
		{
			return Create(model, (object)file, language, prompt, temperature, acceleration);
		}

		public Task<Transcription> Create(string model, Audio file, string? language = null, string? prompt = null, float temperature = 0f, object? acceleration = null)
		{
			return Create(model, (object)file, language, prompt, temperature, acceleration);
		}

		internal TranscriptionService(PredictorService predictors, global::Muna.Services.PredictionService predictions, RemotePredictionService remotePredictions)
		{
			this.predictors = predictors;
			this.predictions = predictions;
			this.remotePredictions = remotePredictions;
			cache = new Dictionary<string, TranscriptionDelegate>();
		}

		private async Task<TranscriptionDelegate> CreateTranscriptionDelegate(string tag)
		{
			Signature signature = ((await predictors.Retrieve(tag)) ?? throw new ArgumentException(tag + " cannot be used with OpenAI transcription API because the predictor could not be found. Check that your access key is valid and that you have access to the predictor.")).signature;
			Parameter[] array = signature.inputs.Where((Parameter parameter) => parameter.optional == false).ToArray();
			if (array.Length != 1)
			{
				throw new InvalidOperationException(tag + " cannot be used with OpenAI transcription API because it has more than one required input parameter.");
			}
			Parameter audioParam = array.FirstOrDefault((Parameter parameter) => parameter.dtype == Dtype.Float32 && parameter.denotation == "audio");
			if (audioParam == null)
			{
				throw new InvalidOperationException(tag + " cannot be used with OpenAI transcription API because it does not have a valid audio input parameter.");
			}
			Parameter languageParam = signature.inputs.FirstOrDefault((Parameter parameter) => parameter.dtype == Dtype.String && parameter.denotation == "openai.audio.transcriptions.language");
			Parameter promptParam = signature.inputs.FirstOrDefault((Parameter parameter) => parameter.dtype == Dtype.String && parameter.denotation == "openai.audio.transcriptions.prompt");
			Parameter temperatureParam = signature.inputs.FirstOrDefault((Parameter parameter) => new Dtype[2]
			{
				Dtype.Float32,
				Dtype.Float64
			}.Contains(parameter.dtype) && parameter.denotation == "openai.chat.completions.temperature");
			(int, Parameter) tuple = (from pair in signature.outputs.Select((Parameter parameter, int idx) => (idx: idx, parameter: parameter))
				where pair.parameter.dtype == Dtype.String
				select pair).FirstOrDefault();
			var (transcriptionParamIdx, _) = tuple;
			if (tuple.Item2 == null)
			{
				throw new InvalidOperationException(tag + " cannot be used with OpenAI transcription API because it has no output string parameter.");
			}
			return async delegate(string model, object file, string? language, string? prompt, float temperature, object acceleration)
			{
				Tensor<float> samples = ReadAudioSamples(file, audioParam.sampleRate.Value);
				Dictionary<string, object> dictionary = new Dictionary<string, object> { [audioParam.name] = samples };
				if (language != null && languageParam != null)
				{
					dictionary[languageParam.name] = language;
				}
				if (prompt != null && promptParam != null)
				{
					dictionary[promptParam.name] = prompt;
				}
				if (temperatureParam != null)
				{
					dictionary[temperatureParam.name] = temperature;
				}
				Prediction prediction = await CreatePrediction(model, dictionary, acceleration);
				if (prediction.error != null)
				{
					throw new InvalidOperationException(prediction.error);
				}
				object obj = prediction.results[transcriptionParamIdx];
				if (!(obj is string text))
				{
					throw new InvalidOperationException($"{tag} returned object of type {obj.GetType()} instead of a string");
				}
				float seconds = (float)samples.shape.Aggregate(1, (int a, int b) => a * b) / (float)audioParam.sampleRate.Value;
				return new Transcription
				{
					Text = text,
					Usage = new Transcription.UsageInfo
					{
						Type = "duration",
						Seconds = seconds
					}
				};
			};
		}

		private async Task<Transcription> Create(string model, object file, string? language, string? prompt, float temperature, object? acceleration)
		{
			if (!cache.ContainsKey(model))
			{
				TranscriptionDelegate value = await CreateTranscriptionDelegate(model);
				cache.Add(model, value);
			}
			return await cache[model](model, file, language, prompt, temperature, acceleration ?? ((object)Acceleration.Auto));
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

		private static Tensor<float> ReadAudioSamples(object file, int sampleRate)
		{
			if (file is Audio audio)
			{
				if (audio.sampleRate != sampleRate)
				{
					throw new ArgumentException($"Audio sample rate {audio.sampleRate}Hz does not match " + $"the required sample rate of {sampleRate}Hz.");
				}
				return audio.AsTensor();
			}
			if (file is Stream stream)
			{
				using Value value = Value.CreateFromBinary(stream, $"audio/*;rate={sampleRate}");
				object obj = value.ToObject();
				if (obj is Tensor<float>)
				{
					return (Tensor<float>)obj;
				}
				throw new InvalidOperationException("Failed to decode audio file into tensor samples");
			}
			throw new ArgumentException($"Unsupported audio file type: {file.GetType()}");
		}
	}
}
