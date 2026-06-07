using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Muna.Beta.Services;
using Muna.Services;
using Newtonsoft.Json.Linq;

namespace Muna.Beta.OpenAI
{
	public sealed class ChatCompletionService
	{
		private delegate Task<object> CompletionDelegate(string model, ChatMessage[] messages, bool stream, Dictionary<string, object?>? responseFormat, string? reasoningEffort, int? maxCompletionTokens, float? temperature, float? topP, float? frequencyPenalty, float? presencePenalty, object acceleration);

		private readonly PredictorService predictors;

		private readonly global::Muna.Services.PredictionService predictions;

		private readonly RemotePredictionService remotePredictions;

		private readonly Dictionary<string, CompletionDelegate> cache;

		public async Task<ChatCompletion> Create(string model, ChatMessage[] messages, Dictionary<string, object?>? responseFormat = null, string? reasoningEffort = null, int? maxCompletionTokens = null, float? temperature = null, float? topP = null, float? frequencyPenalty = null, float? presencePenalty = null, object? acceleration = null)
		{
			if (!cache.ContainsKey(model))
			{
				Dictionary<string, CompletionDelegate> dictionary = cache;
				dictionary[model] = await CreateCompletionDelegate(model);
			}
			return (ChatCompletion)(await cache[model](model, messages, stream: false, responseFormat, reasoningEffort, maxCompletionTokens, temperature, topP, frequencyPenalty, presencePenalty, acceleration ?? ((object)Acceleration.Auto)));
		}

		public async IAsyncEnumerable<ChatCompletionChunk> Stream(string model, ChatMessage[] messages, Dictionary<string, object?>? responseFormat = null, string? reasoningEffort = null, int? maxCompletionTokens = null, float? temperature = null, float? topP = null, float? frequencyPenalty = null, float? presencePenalty = null, object? acceleration = null)
		{
			if (!cache.ContainsKey(model))
			{
				Dictionary<string, CompletionDelegate> dictionary = cache;
				dictionary[model] = await CreateCompletionDelegate(model);
			}
			IAsyncEnumerable<ChatCompletionChunk> asyncEnumerable = (IAsyncEnumerable<ChatCompletionChunk>)(await cache[model](model, messages, stream: true, responseFormat, reasoningEffort, maxCompletionTokens, temperature, topP, frequencyPenalty, presencePenalty, acceleration ?? ((object)Acceleration.Auto)));
			await foreach (ChatCompletionChunk item in asyncEnumerable)
			{
				yield return item;
			}
		}

		internal ChatCompletionService(PredictorService predictors, global::Muna.Services.PredictionService predictions, RemotePredictionService remotePredictions)
		{
			this.predictors = predictors;
			this.predictions = predictions;
			this.remotePredictions = remotePredictions;
			cache = new Dictionary<string, CompletionDelegate>();
		}

		private async Task<CompletionDelegate> CreateCompletionDelegate(string tag)
		{
			Signature signature = ((await predictors.Retrieve(tag)) ?? throw new ArgumentException(tag + " cannot be used with OpenAI chat completions API because the predictor could not be found. Check that your access key is valid and that you have access to the predictor.")).signature;
			Parameter[] array = signature.inputs.Where((Parameter p) => p.optional == false).ToArray();
			if (array.Length != 1)
			{
				throw new InvalidOperationException(tag + " cannot be used with OpenAI chat completions API because it has more than one required input parameter.");
			}
			Parameter inputParam = array.FirstOrDefault((Parameter p) => p.dtype == Dtype.List);
			if (inputParam == null)
			{
				throw new InvalidOperationException(tag + " cannot be used with OpenAI chat completions API because it does not have a valid chat messages input parameter.");
			}
			Parameter responseFormatParam = signature.inputs.FirstOrDefault((Parameter p) => p.dtype == Dtype.Dict && p.denotation == "openai.chat.completions.response_format");
			Parameter reasoningEffortParam = signature.inputs.FirstOrDefault((Parameter p) => p.dtype == Dtype.String && p.denotation == "openai.chat.completions.reasoning_effort");
			Parameter maxOutputTokensParam = signature.inputs.FirstOrDefault((Parameter p) => new Dtype[8]
			{
				Dtype.Int8,
				Dtype.Int16,
				Dtype.Int32,
				Dtype.Int64,
				Dtype.Uint8,
				Dtype.Uint16,
				Dtype.Uint32,
				Dtype.Uint64
			}.Contains(p.dtype) && p.denotation == "openai.chat.completions.max_output_tokens");
			Parameter temperatureParam = signature.inputs.FirstOrDefault((Parameter p) => new Dtype[2]
			{
				Dtype.Float32,
				Dtype.Float64
			}.Contains(p.dtype) && p.denotation == "openai.chat.completions.temperature");
			Parameter topPParam = signature.inputs.FirstOrDefault((Parameter p) => new Dtype[2]
			{
				Dtype.Float32,
				Dtype.Float64
			}.Contains(p.dtype) && p.denotation == "openai.chat.completions.top_p");
			Parameter frequencyPenaltyParam = signature.inputs.FirstOrDefault((Parameter p) => new Dtype[2]
			{
				Dtype.Float32,
				Dtype.Float64
			}.Contains(p.dtype) && p.denotation == "openai.chat.completions.frequency_penalty");
			Parameter presencePenaltyParam = signature.inputs.FirstOrDefault((Parameter p) => new Dtype[2]
			{
				Dtype.Float32,
				Dtype.Float64
			}.Contains(p.dtype) && p.denotation == "openai.chat.completions.presence_penalty");
			int? completionParamIdx = (from pair in signature.outputs.Select((Parameter parameter, int idx) => (idx: idx, parameter: parameter))
				where pair.parameter.dtype == Dtype.Dict && pair.parameter.schema != null && pair.parameter.schema.TryGetValue("title", out object value) && (value?.ToString() == "ChatCompletion" || value?.ToString() == "ChatCompletionChunk")
				select pair).Select<(int, Parameter), int?>((Func<(int, Parameter), int?>)(((int idx, Parameter parameter) pair) => pair.idx)).FirstOrDefault();
			if (!completionParamIdx.HasValue)
			{
				throw new InvalidOperationException(tag + " cannot be used with OpenAI chat completions API because it does not have a valid chat completion output parameter.");
			}
			return async delegate(string model, ChatMessage[] messages, bool stream, Dictionary<string, object?>? responseFormat, string? reasoningEffort, int? maxCompletionTokens, float? temperature, float? topP, float? frequencyPenalty, float? presencePenalty, object acceleration)
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object> { [inputParam.name] = messages };
				if (responseFormatParam != null && responseFormat != null)
				{
					dictionary[responseFormatParam.name] = responseFormat;
				}
				if (reasoningEffortParam != null && reasoningEffort != null)
				{
					dictionary[reasoningEffortParam.name] = reasoningEffort;
				}
				if (maxOutputTokensParam != null && maxCompletionTokens.HasValue)
				{
					dictionary[maxOutputTokensParam.name] = maxCompletionTokens.Value;
				}
				if (temperatureParam != null && temperature.HasValue)
				{
					dictionary[temperatureParam.name] = temperature.Value;
				}
				if (topPParam != null && topP.HasValue)
				{
					dictionary[topPParam.name] = topP.Value;
				}
				if (frequencyPenaltyParam != null && frequencyPenalty.HasValue)
				{
					dictionary[frequencyPenaltyParam.name] = frequencyPenalty.Value;
				}
				if (presencePenaltyParam != null && presencePenalty.HasValue)
				{
					dictionary[presencePenaltyParam.name] = presencePenalty.Value;
				}
				IAsyncEnumerable<Prediction> asyncEnumerable = StreamPrediction(model, dictionary, acceleration);
				return stream ? ((object)GatherCompletionChunks(asyncEnumerable, completionParamIdx.Value)) : ((object)(await GatherChatCompletion(asyncEnumerable, completionParamIdx.Value)));
			};
		}

		private IAsyncEnumerable<Prediction> StreamPrediction(string tag, Dictionary<string, object?> inputs, object acceleration)
		{
			if (!(acceleration is Acceleration acceleration2))
			{
				if (acceleration is RemoteAcceleration acceleration3)
				{
					return remotePredictions.Stream(tag, inputs, acceleration3);
				}
				throw new InvalidOperationException($"Cannot stream {tag} prediction because acceleration is invalid: {acceleration}");
			}
			return predictions.Stream(tag, inputs, acceleration2, (IntPtr)0);
		}

		private static async Task<ChatCompletion> GatherChatCompletion(IAsyncEnumerable<Prediction> predictions, int completionParamIdx)
		{
			List<JObject> outputs = new List<JObject>();
			await foreach (Prediction prediction in predictions)
			{
				if (prediction.error != null)
				{
					throw new InvalidOperationException(prediction.error);
				}
				outputs.Add(prediction.results[completionParamIdx] as JObject);
			}
			return ParseChatCompletion(outputs);
		}

		private static async IAsyncEnumerable<ChatCompletionChunk> GatherCompletionChunks(IAsyncEnumerable<Prediction> predictions, int completionParamIdx)
		{
			await foreach (Prediction prediction in predictions)
			{
				if (prediction.error != null)
				{
					throw new InvalidOperationException(prediction.error);
				}
				JObject output = prediction.results[completionParamIdx] as JObject;
				yield return ParseChatCompletionChunk(output);
			}
		}

		private static ChatCompletion ParseChatCompletion(List<JObject> outputs)
		{
			if (outputs.Count == 0)
			{
				throw new InvalidOperationException("Failed to parse chat completion because model did not return any outputs");
			}
			if (outputs.All((JObject o) => o["object"]?.ToString() == "chat.completion"))
			{
				return outputs.Select((JObject o) => o.ToObject<ChatCompletion>()).ToList().Last();
			}
			if (outputs.All((JObject o) => o["object"]?.ToString() == "chat.completion.chunk"))
			{
				return MergeChunks(outputs.Select((JObject o) => o.ToObject<ChatCompletionChunk>()).ToList());
			}
			throw new InvalidOperationException("Failed to parse chat completion from model outputs");
		}

		private static ChatCompletionChunk ParseChatCompletionChunk(JObject output)
		{
			if (output["object"]?.ToString() == "chat.completion.chunk")
			{
				return output.ToObject<ChatCompletionChunk>();
			}
			if (output["object"]?.ToString() == "chat.completion")
			{
				ChatCompletion chatCompletion = output.ToObject<ChatCompletion>();
				return new ChatCompletionChunk
				{
					Object = "chat.completion.chunk",
					Id = chatCompletion.Id,
					Created = chatCompletion.Created,
					Model = chatCompletion.Model,
					Choices = chatCompletion.Choices.Select((ChatCompletion.Choice choice) => new ChatCompletionChunk.Choice
					{
						Index = choice.Index,
						Delta = new ChatCompletionChunk.Choice.MessageDelta
						{
							Role = choice.Message.Role,
							Content = choice.Message.Content
						},
						FinishReason = choice.FinishReason
					}).ToArray(),
					Usage = chatCompletion.Usage
				};
			}
			throw new InvalidOperationException("Failed to parse streaming chat completion chunk from model output");
		}

		private static ChatCompletion MergeChunks(List<ChatCompletionChunk> chunks)
		{
			Dictionary<int, List<ChatCompletionChunk.Choice>> dictionary = new Dictionary<int, List<ChatCompletionChunk.Choice>>();
			foreach (ChatCompletionChunk chunk in chunks)
			{
				ChatCompletionChunk.Choice[] choices = chunk.Choices;
				foreach (ChatCompletionChunk.Choice choice in choices)
				{
					if (!dictionary.ContainsKey(choice.Index))
					{
						dictionary[choice.Index] = new List<ChatCompletionChunk.Choice>();
					}
					dictionary[choice.Index].Add(choice);
				}
			}
			ChatCompletion.Choice[] choices2 = dictionary.Select((KeyValuePair<int, List<ChatCompletionChunk.Choice>> pair) => CreateCompletionChoice(pair.Key, pair.Value)).ToArray();
			List<ChatCompletion.UsageInfo> source = (from c in chunks
				where c.Usage.HasValue
				select c.Usage.Value).ToList();
			ChatCompletion.UsageInfo usage = new ChatCompletion.UsageInfo
			{
				PromptTokens = source.Sum((ChatCompletion.UsageInfo u) => u.PromptTokens),
				CompletionTokens = source.Sum((ChatCompletion.UsageInfo u) => u.CompletionTokens),
				TotalTokens = source.Sum((ChatCompletion.UsageInfo u) => u.TotalTokens)
			};
			return new ChatCompletion
			{
				Object = "chat.completion",
				Id = chunks[0].Id,
				Created = chunks[0].Created,
				Model = chunks[0].Model,
				Choices = choices2,
				Usage = usage
			};
		}

		private static ChatCompletion.Choice CreateCompletionChoice(int index, List<ChatCompletionChunk.Choice> choices)
		{
			string role = choices.Select((ChatCompletionChunk.Choice c) => c.Delta?.Role).FirstOrDefault((string r) => r != null) ?? "assistant";
			string content = string.Join("", from c in choices
				where c.Delta?.Content != null
				select c.Delta.Content);
			string finishReason = choices.Select((ChatCompletionChunk.Choice c) => c.FinishReason).FirstOrDefault((string r) => r != null);
			return new ChatCompletion.Choice
			{
				Index = index,
				Message = new ChatMessage
				{
					Role = role,
					Content = content
				},
				FinishReason = finishReason
			};
		}
	}
}
