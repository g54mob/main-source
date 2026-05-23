using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Muna.Beta.Services;
using Muna.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace Muna.Beta.OpenAI
{
	public sealed class EmbeddingService
	{
		[JsonConverter(typeof(StringEnumConverter))]
		public enum EncodingFormat
		{
			[EnumMember(Value = "float")]
			Float = 1,
			[EnumMember(Value = "base64")]
			Base64 = 2
		}

		private delegate Task<CreateEmbeddingResponse> EmbeddingDelegate(string model, string[] input, int? dimensions, EncodingFormat encodingFormat, object acceleration);

		private readonly PredictorService predictors;

		private readonly global::Muna.Services.PredictionService predictions;

		private readonly RemotePredictionService remotePredictions;

		private readonly Dictionary<string, EmbeddingDelegate> cache;

		public Task<CreateEmbeddingResponse> Create(string model, string input, int? dimensions = null, EncodingFormat encodingFormat = EncodingFormat.Float, object? acceleration = null)
		{
			return Create(model, new string[1] { input }, dimensions, encodingFormat, acceleration);
		}

		public async Task<CreateEmbeddingResponse> Create(string model, string[] input, int? dimensions = null, EncodingFormat encodingFormat = EncodingFormat.Float, object? acceleration = null)
		{
			if (!cache.ContainsKey(model))
			{
				EmbeddingDelegate value = await CreateEmbeddingDelegate(model);
				cache.Add(model, value);
			}
			return await cache[model](model, input, dimensions, encodingFormat, acceleration ?? ((object)Acceleration.Auto));
		}

		internal EmbeddingService(PredictorService predictors, global::Muna.Services.PredictionService predictions, RemotePredictionService remotePredictions)
		{
			this.predictors = predictors;
			this.predictions = predictions;
			this.remotePredictions = remotePredictions;
			cache = new Dictionary<string, EmbeddingDelegate>();
		}

		private async Task<EmbeddingDelegate> CreateEmbeddingDelegate(string tag)
		{
			Signature signature = ((await predictors.Retrieve(tag)) ?? throw new ArgumentException(tag + " cannot be used with OpenAI embedding API because the predictor could not be found. Check that your access key is valid and that you have access to the predictor.")).signature;
			Parameter[] array = signature.inputs.Where((Parameter parameter) => parameter.optional == false).ToArray();
			if (array.Length != 1)
			{
				throw new InvalidOperationException(tag + " cannot be used with OpenAI embedding API because it has more than one required input parameter.");
			}
			Parameter inputParam = array.FirstOrDefault((Parameter p) => p.dtype == Dtype.List);
			if (inputParam == null)
			{
				throw new InvalidOperationException(tag + " cannot be used with OpenAI embedding API because it does not have a valid text embedding input parameter.");
			}
			Parameter matryoshkaParam = signature.inputs.FirstOrDefault((Parameter parameter) => new Dtype[8]
			{
				Dtype.Int8,
				Dtype.Int16,
				Dtype.Int32,
				Dtype.Int64,
				Dtype.Uint8,
				Dtype.Uint16,
				Dtype.Uint32,
				Dtype.Uint64
			}.Contains(parameter.dtype) && parameter.denotation == "openai.embeddings.dims");
			(int, Parameter) tuple = (from pair in signature.outputs.Select((Parameter parameter, int idx) => (idx: idx, parameter: parameter))
				where pair.parameter.dtype == Dtype.Float32 && pair.parameter.denotation == "embedding"
				select pair).FirstOrDefault();
			var (embeddingParamIdx, _) = tuple;
			if (tuple.Item2 == null)
			{
				throw new InvalidOperationException(tag + " cannot be used with OpenAI embedding API because it has no outputs with an `embedding` denotation.");
			}
			int? usageParamIdx = (from pair in signature.outputs.Select((Parameter parameter, int idx) => (idx: idx, parameter: parameter))
				where pair.parameter.schema != null && pair.parameter.schema.TryGetValue("title", out object value) && value?.ToString() == "Usage"
				select pair).Select<(int, Parameter), int?>((Func<(int, Parameter), int?>)(((int idx, Parameter parameter) pair) => pair.idx)).FirstOrDefault();
			return async delegate(string model, string[] input, int? dimensions, EncodingFormat encodingFormat, object acceleration)
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object> { [inputParam.name] = input };
				if (dimensions.HasValue && matryoshkaParam != null)
				{
					dictionary[matryoshkaParam.name] = dimensions.Value;
				}
				Prediction prediction = await CreatePrediction(model, dictionary, acceleration);
				if (prediction.error != null)
				{
					throw new InvalidOperationException(prediction.error);
				}
				object obj = prediction.results[embeddingParamIdx];
				if (!(obj is Tensor<float>))
				{
					throw new InvalidOperationException($"{tag} returned object of type {obj.GetType()} instead of an embedding matrix");
				}
				Tensor<float> embeddingMatrix = (Tensor<float>)obj;
				if (embeddingMatrix.shape.Length != 2)
				{
					string text = "(" + string.Join(",", embeddingMatrix.shape) + ")";
					throw new InvalidOperationException(tag + " returned embedding matrix with invalid shape: " + text);
				}
				Embedding[] data = (from idx in Enumerable.Range(0, embeddingMatrix.shape[0])
					select ParseEmbedding(embeddingMatrix, idx, encodingFormat)).ToArray();
				CreateEmbeddingResponse.UsageInfo usage = (usageParamIdx.HasValue ? (prediction.results[usageParamIdx.Value] as JObject).ToObject<CreateEmbeddingResponse.UsageInfo>() : new CreateEmbeddingResponse.UsageInfo
				{
					PromptTokens = 0,
					TotalTokens = 0
				});
				return new CreateEmbeddingResponse
				{
					Object = "list",
					Model = model,
					Data = data,
					Usage = usage
				};
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

		private unsafe Embedding ParseEmbedding(Tensor<float> matrix, int index, EncodingFormat format)
		{
			fixed (float* ptr = matrix)
			{
				float* pointer = ptr + index * matrix.shape[1];
				ReadOnlySpan<float> readOnlySpan = new ReadOnlySpan<float>(pointer, matrix.shape[1]);
				ReadOnlySpan<byte> bytes = new ReadOnlySpan<byte>(pointer, matrix.shape[1] * 4);
				float[] floats = ((format == EncodingFormat.Float) ? readOnlySpan.ToArray() : null);
				string @base = ((format == EncodingFormat.Base64) ? Convert.ToBase64String(bytes) : null);
				return new Embedding
				{
					Object = "embedding",
					Floats = floats,
					Index = index,
					Base64 = @base
				};
			}
		}
	}
}
