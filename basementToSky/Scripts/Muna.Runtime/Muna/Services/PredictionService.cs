using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Muna.API;
using Muna.C;

namespace Muna.Services
{
	public sealed class PredictionService
	{
		private readonly MunaClient client;

		private readonly string cachePath;

		private readonly Dictionary<string, global::Muna.C.Predictor> cache = new Dictionary<string, global::Muna.C.Predictor>();

		public async Task<Prediction> Create(string tag, Dictionary<string, object?>? inputs = null, Acceleration acceleration = Acceleration.Auto, IntPtr device = default(IntPtr), string? clientId = null, string? configurationId = null)
		{
			await Configuration.InitializationTask;
			if (inputs == null)
			{
				return await CreateRawPrediction(tag, clientId, configurationId);
			}
			global::Muna.C.Predictor predictor = await GetPredictor(tag, acceleration, device, clientId, configurationId);
			using ValueMap inputs2 = ToValueMap(inputs);
			using global::Muna.C.Prediction prediction = predictor.CreatePrediction(inputs2);
			return ToPrediction(tag, prediction);
		}

		public async IAsyncEnumerable<Prediction> Stream(string tag, Dictionary<string, object?> inputs, Acceleration acceleration = Acceleration.Auto, IntPtr device = default(IntPtr))
		{
			await Configuration.InitializationTask;
			global::Muna.C.Predictor predictor = await GetPredictor(tag, acceleration, device);
			using ValueMap inputMap = ToValueMap(inputs);
			using PredictionStream stream = predictor.StreamPrediction(inputMap);
			global::Muna.C.Prediction prediction;
			while ((prediction = stream.ReadNext()) != null)
			{
				using (prediction)
				{
					yield return ToPrediction(tag, prediction);
				}
			}
		}

		public async Task<bool> Delete(string tag)
		{
			await Configuration.InitializationTask;
			if (!cache.TryGetValue(tag, out global::Muna.C.Predictor value))
			{
				return false;
			}
			value.Dispose();
			cache.Remove(tag);
			return true;
		}

		internal PredictionService(MunaClient client)
		{
			this.client = client;
			cachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".fxn", "cache");
		}

		private Task<Prediction> CreateRawPrediction(string tag, string? clientId = null, string? configurationId = null)
		{
			return client.Request<Prediction>("POST", "/predictions", new Dictionary<string, object>
			{
				["tag"] = tag,
				["clientId"] = clientId ?? Configuration.ClientId,
				["configurationId"] = configurationId ?? Configuration.ConfigurationId
			});
		}

		private async Task<global::Muna.C.Predictor> GetPredictor(string tag, Acceleration acceleration = Acceleration.Auto, IntPtr device = default(IntPtr), string? clientId = null, string? configurationId = null)
		{
			if (cache.TryGetValue(tag, out global::Muna.C.Predictor value))
			{
				return value;
			}
			Prediction prediction = await CreateRawPrediction(tag, clientId, configurationId);
			using Configuration configuration = new Configuration
			{
				tag = prediction.tag,
				token = prediction.configuration,
				acceleration = acceleration,
				device = device
			};
			PredictionResource[] resources = prediction.resources;
			foreach (PredictionResource predictionResource in resources)
			{
				Configuration configuration2 = configuration;
				string type = predictionResource.type;
				await configuration2.AddResource(type, await DownloadResource(predictionResource));
			}
			global::Muna.C.Predictor predictor = new global::Muna.C.Predictor(configuration);
			cache.Add(tag, predictor);
			return predictor;
		}

		private async Task<string> DownloadResource(PredictionResource resource)
		{
			Uri uri = new Uri(resource.url);
			if (uri.IsFile)
			{
				return uri.LocalPath;
			}
			string path = GetResourcePath(resource, cachePath);
			if (File.Exists(path))
			{
				return path;
			}
			Directory.CreateDirectory(Path.GetDirectoryName(path));
			using Stream stream = await client.Download(resource.url);
			using FileStream destination = File.Create(path);
			stream.CopyTo(destination);
			return path;
		}

		internal static string GetResourcePath(PredictionResource resource, string cacheDir)
		{
			string fileName = Path.GetFileName(new Uri(resource.url).AbsolutePath);
			if (!string.IsNullOrEmpty(resource.name))
			{
				return Path.Combine(cacheDir, fileName, resource.name);
			}
			return Path.Combine(cacheDir, fileName);
		}

		internal static Value ToValue(object? value)
		{
			if (!(value is Value result))
			{
				if (!(value is IntPtr value2))
				{
					if (!(value is float scalar))
					{
						if (!(value is double scalar2))
						{
							if (!(value is sbyte scalar3))
							{
								if (!(value is short scalar4))
								{
									if (!(value is int scalar5))
									{
										if (!(value is long scalar6))
										{
											if (!(value is byte scalar7))
											{
												if (!(value is ushort scalar8))
												{
													if (!(value is uint scalar9))
													{
														if (!(value is ulong scalar10))
														{
															if (!(value is bool scalar11))
															{
																if (!(value is float[] vector))
																{
																	if (!(value is double[] vector2))
																	{
																		if (!(value is sbyte[] vector3))
																		{
																			if (!(value is short[] vector4))
																			{
																				if (!(value is int[] vector5))
																				{
																					if (!(value is long[] vector6))
																					{
																						if (!(value is byte[] vector7))
																						{
																							if (!(value is ushort[] vector8))
																							{
																								if (!(value is uint[] vector9))
																								{
																									if (!(value is ulong[] vector10))
																									{
																										if (!(value is bool[] vector11))
																										{
																											if (!(value is Tensor<float> tensor))
																											{
																												if (!(value is Tensor<double> tensor2))
																												{
																													if (!(value is Tensor<sbyte> tensor3))
																													{
																														if (!(value is Tensor<short> tensor4))
																														{
																															if (!(value is Tensor<int> tensor5))
																															{
																																if (!(value is Tensor<long> tensor6))
																																{
																																	if (!(value is Tensor<byte> tensor7))
																																	{
																																		if (!(value is Tensor<ushort> tensor8))
																																		{
																																			if (!(value is Tensor<uint> tensor9))
																																			{
																																				if (!(value is Tensor<ulong> tensor10))
																																				{
																																					if (!(value is Tensor<bool> tensor11))
																																					{
																																						if (!(value is string input))
																																						{
																																							if (!(value is Enum value3))
																																							{
																																								if (!(value is IList list))
																																								{
																																									if (!(value is IDictionary dict))
																																									{
																																										if (!(value is Image image))
																																										{
																																											if (!(value is Stream stream))
																																											{
																																												if (value == null)
																																												{
																																													return Value.CreateNull();
																																												}
																																												throw new InvalidOperationException($"Cannot create a Muna value from value '{value}' of type {value.GetType()}");
																																											}
																																											return Value.CreateBinary(stream);
																																										}
																																										return Value.CreateImage(in image);
																																									}
																																									return Value.CreateDict(dict);
																																								}
																																								return Value.CreateList(list);
																																							}
																																							return ToValue(SerializeEnum(value3));
																																						}
																																						return Value.CreateString(input);
																																					}
																																					return Value.CreateArray(in tensor11);
																																				}
																																				return Value.CreateArray(in tensor10);
																																			}
																																			return Value.CreateArray(in tensor9);
																																		}
																																		return Value.CreateArray(in tensor8);
																																	}
																																	return Value.CreateArray(in tensor7);
																																}
																																return Value.CreateArray(in tensor6);
																															}
																															return Value.CreateArray(in tensor5);
																														}
																														return Value.CreateArray(in tensor4);
																													}
																													return Value.CreateArray(in tensor3);
																												}
																												return Value.CreateArray(in tensor2);
																											}
																											return Value.CreateArray(in tensor);
																										}
																										return Value.CreateArray(vector11);
																									}
																									return Value.CreateArray(vector10);
																								}
																								return Value.CreateArray(vector9);
																							}
																							return Value.CreateArray(vector8);
																						}
																						return Value.CreateArray(vector7);
																					}
																					return Value.CreateArray(vector6);
																				}
																				return Value.CreateArray(vector5);
																			}
																			return Value.CreateArray(vector4);
																		}
																		return Value.CreateArray(vector3);
																	}
																	return Value.CreateArray(vector2);
																}
																return Value.CreateArray(vector);
															}
															return Value.CreateArray(scalar11);
														}
														return Value.CreateArray(scalar10);
													}
													return Value.CreateArray(scalar9);
												}
												return Value.CreateArray(scalar8);
											}
											return Value.CreateArray(scalar7);
										}
										return Value.CreateArray(scalar6);
									}
									return Value.CreateArray(scalar5);
								}
								return Value.CreateArray(scalar4);
							}
							return Value.CreateArray(scalar3);
						}
						return Value.CreateArray(scalar2);
					}
					return Value.CreateArray(scalar);
				}
				return new Value(value2);
			}
			return result;
		}

		private static ValueMap ToValueMap(Dictionary<string, object?> inputs)
		{
			ValueMap valueMap = new ValueMap();
			foreach (KeyValuePair<string, object> input in inputs)
			{
				valueMap[input.Key] = ToValue(input.Value);
			}
			return valueMap;
		}

		private static Prediction ToPrediction(string tag, global::Muna.C.Prediction prediction)
		{
			ValueMap results = prediction.results;
			return new Prediction
			{
				id = prediction.id,
				tag = tag,
				created = DateTime.UtcNow,
				results = ((results != null) ? (from value in Enumerable.Range(0, results.size).Select(results.GetKey).Select(results.GetValue)
					select value.ToObject()).ToArray() : null),
				latency = prediction.latency,
				error = prediction.error,
				logs = prediction.logs
			};
		}

		internal static object SerializeEnum(Enum value)
		{
			if (!(value.GetType().GetField(value.ToString())?.GetCustomAttributes(typeof(EnumMemberAttribute), inherit: false)?.FirstOrDefault() is EnumMemberAttribute { IsValueSetExplicitly: not false } enumMemberAttribute))
			{
				return Convert.ToInt32(value);
			}
			return enumMemberAttribute.Value;
		}
	}
}
