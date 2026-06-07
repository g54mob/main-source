using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Muna.API;
using Muna.C;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Muna.Beta.Services
{
	public sealed class RemotePredictionService
	{
		[Serializable]
		[Preserve]
		private class RemotePrediction : Prediction
		{
			public new RemoteValue[]? results;
		}

		[Serializable]
		[Preserve]
		private class RemotePredictionEvent
		{
			[JsonProperty("event")]
			public string @event;

			public RemotePrediction data;
		}

		private readonly MunaClient client;

		public async Task<Prediction> Create(string tag, Dictionary<string, object?> inputs, RemoteAcceleration acceleration = RemoteAcceleration.Auto)
		{
			await Configuration.InitializationTask;
			Dictionary<string, RemoteValue> inputMap = new Dictionary<string, RemoteValue>();
			foreach (KeyValuePair<string, object> input in inputs)
			{
				Dictionary<string, RemoteValue> dictionary = inputMap;
				string key = input.Key;
				dictionary[key] = await ToValue(input.Value);
			}
			return await ParseRemotePrediction(await client.Request<RemotePrediction>("POST", "/predictions/remote", new Dictionary<string, object>
			{
				["tag"] = tag,
				["inputs"] = inputMap,
				["acceleration"] = acceleration,
				["clientId"] = Configuration.ClientId
			}));
		}

		public async IAsyncEnumerable<Prediction> Stream(string tag, Dictionary<string, object?> inputs, RemoteAcceleration acceleration = RemoteAcceleration.Auto)
		{
			await Configuration.InitializationTask;
			Dictionary<string, RemoteValue> inputMap = new Dictionary<string, RemoteValue>();
			foreach (KeyValuePair<string, object> input in inputs)
			{
				Dictionary<string, RemoteValue> dictionary = inputMap;
				string key = input.Key;
				dictionary[key] = await ToValue(input.Value);
			}
			await foreach (RemotePredictionEvent item in client.Stream<RemotePredictionEvent>("POST", "/predictions/remote", new Dictionary<string, object>
			{
				["tag"] = tag,
				["inputs"] = inputMap,
				["acceleration"] = acceleration,
				["clientId"] = Configuration.ClientId,
				["stream"] = true
			}))
			{
				yield return await ParseRemotePrediction(item.data);
			}
		}

		internal RemotePredictionService(MunaClient client)
		{
			this.client = client;
		}

		private async Task<RemoteValue> ToValue(object? value)
		{
			RemoteValue result;
			if (value != null)
			{
				if (!(value is float num))
				{
					if (!(value is double num2))
					{
						if (!(value is sbyte b))
						{
							if (!(value is short num3))
							{
								if (!(value is int num4))
								{
									if (!(value is long num5))
									{
										if (!(value is byte b2))
										{
											if (!(value is ushort num6))
											{
												if (!(value is uint num7))
												{
													if (!(value is ulong num8))
													{
														if (!(value is bool flag))
														{
															if (!(value is float[] x))
															{
																if (!(value is double[] x2))
																{
																	if (!(value is sbyte[] x3))
																	{
																		if (!(value is short[] x4))
																		{
																			if (!(value is int[] x5))
																			{
																				if (!(value is long[] x6))
																				{
																					if (!(value is byte[] x7))
																					{
																						if (!(value is ushort[] x8))
																						{
																							if (!(value is uint[] x9))
																							{
																								if (!(value is ulong[] x10))
																								{
																									if (!(value is bool[] x11))
																									{
																										if (!(value is Tensor<float> x12))
																										{
																											if (!(value is Tensor<double> x13))
																											{
																												if (!(value is Tensor<sbyte> x14))
																												{
																													if (!(value is Tensor<short> x15))
																													{
																														if (!(value is Tensor<int> x16))
																														{
																															if (!(value is Tensor<long> x17))
																															{
																																if (!(value is Tensor<byte> x18))
																																{
																																	if (!(value is Tensor<ushort> x19))
																																	{
																																		if (!(value is Tensor<uint> x20))
																																		{
																																			if (!(value is Tensor<ulong> x21))
																																			{
																																				if (!(value is Tensor<bool> x22))
																																				{
																																					if (!(value is string data))
																																					{
																																						if (!(value is IList value2))
																																						{
																																							if (!(value is IDictionary value3))
																																							{
																																								if (value is Image)
																																								{
																																									_ = (Image)value;
																																									result = new RemoteValue
																																									{
																																										data = "",
																																										dtype = Dtype.Image
																																									};
																																								}
																																								else if (!(value is Stream stream))
																																								{
																																									if (!(value is Enum value4))
																																									{
																																										if (!(value is RemoteValue remoteValue))
																																										{
																																											throw new InvalidOperationException($"Failed to serialize value '{value}' of type `{value.GetType()}` because it is not supported");
																																										}
																																										result = remoteValue;
																																									}
																																									else
																																									{
																																										result = await ToValue(value4.ToObject());
																																									}
																																								}
																																								else
																																								{
																																									RemoteValue remoteValue2 = new RemoteValue();
																																									RemoteValue remoteValue3 = remoteValue2;
																																									remoteValue3.data = await Upload(stream);
																																									remoteValue2.dtype = Dtype.Binary;
																																									result = remoteValue2;
																																								}
																																							}
																																							else
																																							{
																																								RemoteValue remoteValue3 = new RemoteValue();
																																								RemoteValue remoteValue2 = remoteValue3;
																																								remoteValue2.data = await Upload(JsonConvert.SerializeObject(value3).ToStream(), "application/json");
																																								remoteValue3.dtype = Dtype.Dict;
																																								result = remoteValue3;
																																							}
																																						}
																																						else
																																						{
																																							RemoteValue remoteValue2 = new RemoteValue();
																																							RemoteValue remoteValue3 = remoteValue2;
																																							remoteValue3.data = await Upload(JsonConvert.SerializeObject(value2).ToStream(), "application/json");
																																							remoteValue2.dtype = Dtype.List;
																																							result = remoteValue2;
																																						}
																																					}
																																					else
																																					{
																																						RemoteValue remoteValue3 = new RemoteValue();
																																						RemoteValue remoteValue2 = remoteValue3;
																																						remoteValue2.data = await Upload(data.ToStream(), "text/plain");
																																						remoteValue3.dtype = Dtype.String;
																																						result = remoteValue3;
																																					}
																																				}
																																				else
																																				{
																																					RemoteValue remoteValue2 = new RemoteValue();
																																					RemoteValue remoteValue3 = remoteValue2;
																																					remoteValue3.data = await Upload(x22.data.ToStream());
																																					remoteValue2.dtype = Dtype.Bool;
																																					remoteValue2.shape = x22.shape;
																																					result = remoteValue2;
																																				}
																																			}
																																			else
																																			{
																																				RemoteValue remoteValue3 = new RemoteValue();
																																				RemoteValue remoteValue2 = remoteValue3;
																																				remoteValue2.data = await Upload(x21.data.ToStream());
																																				remoteValue3.dtype = Dtype.Uint64;
																																				remoteValue3.shape = x21.shape;
																																				result = remoteValue3;
																																			}
																																		}
																																		else
																																		{
																																			RemoteValue remoteValue2 = new RemoteValue();
																																			RemoteValue remoteValue3 = remoteValue2;
																																			remoteValue3.data = await Upload(x20.data.ToStream());
																																			remoteValue2.dtype = Dtype.Uint32;
																																			remoteValue2.shape = x20.shape;
																																			result = remoteValue2;
																																		}
																																	}
																																	else
																																	{
																																		RemoteValue remoteValue3 = new RemoteValue();
																																		RemoteValue remoteValue2 = remoteValue3;
																																		remoteValue2.data = await Upload(x19.data.ToStream());
																																		remoteValue3.dtype = Dtype.Uint16;
																																		remoteValue3.shape = x19.shape;
																																		result = remoteValue3;
																																	}
																																}
																																else
																																{
																																	RemoteValue remoteValue2 = new RemoteValue();
																																	RemoteValue remoteValue3 = remoteValue2;
																																	remoteValue3.data = await Upload(x18.data.ToStream());
																																	remoteValue2.dtype = Dtype.Uint8;
																																	remoteValue2.shape = x18.shape;
																																	result = remoteValue2;
																																}
																															}
																															else
																															{
																																RemoteValue remoteValue3 = new RemoteValue();
																																RemoteValue remoteValue2 = remoteValue3;
																																remoteValue2.data = await Upload(x17.data.ToStream());
																																remoteValue3.dtype = Dtype.Int64;
																																remoteValue3.shape = x17.shape;
																																result = remoteValue3;
																															}
																														}
																														else
																														{
																															RemoteValue remoteValue2 = new RemoteValue();
																															RemoteValue remoteValue3 = remoteValue2;
																															remoteValue3.data = await Upload(x16.data.ToStream());
																															remoteValue2.dtype = Dtype.Int32;
																															remoteValue2.shape = x16.shape;
																															result = remoteValue2;
																														}
																													}
																													else
																													{
																														RemoteValue remoteValue3 = new RemoteValue();
																														RemoteValue remoteValue2 = remoteValue3;
																														remoteValue2.data = await Upload(x15.data.ToStream());
																														remoteValue3.dtype = Dtype.Int16;
																														remoteValue3.shape = x15.shape;
																														result = remoteValue3;
																													}
																												}
																												else
																												{
																													RemoteValue remoteValue2 = new RemoteValue();
																													RemoteValue remoteValue3 = remoteValue2;
																													remoteValue3.data = await Upload(x14.data.ToStream());
																													remoteValue2.dtype = Dtype.Int8;
																													remoteValue2.shape = x14.shape;
																													result = remoteValue2;
																												}
																											}
																											else
																											{
																												RemoteValue remoteValue3 = new RemoteValue();
																												RemoteValue remoteValue2 = remoteValue3;
																												remoteValue2.data = await Upload(x13.data.ToStream());
																												remoteValue3.dtype = Dtype.Float64;
																												remoteValue3.shape = x13.shape;
																												result = remoteValue3;
																											}
																										}
																										else
																										{
																											RemoteValue remoteValue2 = new RemoteValue();
																											RemoteValue remoteValue3 = remoteValue2;
																											remoteValue3.data = await Upload(x12.data.ToStream());
																											remoteValue2.dtype = Dtype.Float32;
																											remoteValue2.shape = x12.shape;
																											result = remoteValue2;
																										}
																									}
																									else
																									{
																										RemoteValue remoteValue3 = new RemoteValue();
																										RemoteValue remoteValue2 = remoteValue3;
																										remoteValue2.data = await Upload(x11.ToStream());
																										remoteValue3.dtype = Dtype.Bool;
																										remoteValue3.shape = new int[1] { x11.Length };
																										result = remoteValue3;
																									}
																								}
																								else
																								{
																									RemoteValue remoteValue2 = new RemoteValue();
																									RemoteValue remoteValue3 = remoteValue2;
																									remoteValue3.data = await Upload(x10.ToStream());
																									remoteValue2.dtype = Dtype.Uint64;
																									remoteValue2.shape = new int[1] { x10.Length };
																									result = remoteValue2;
																								}
																							}
																							else
																							{
																								RemoteValue remoteValue3 = new RemoteValue();
																								RemoteValue remoteValue2 = remoteValue3;
																								remoteValue2.data = await Upload(x9.ToStream());
																								remoteValue3.dtype = Dtype.Uint32;
																								remoteValue3.shape = new int[1] { x9.Length };
																								result = remoteValue3;
																							}
																						}
																						else
																						{
																							RemoteValue remoteValue2 = new RemoteValue();
																							RemoteValue remoteValue3 = remoteValue2;
																							remoteValue3.data = await Upload(x8.ToStream());
																							remoteValue2.dtype = Dtype.Uint16;
																							remoteValue2.shape = new int[1] { x8.Length };
																							result = remoteValue2;
																						}
																					}
																					else
																					{
																						RemoteValue remoteValue3 = new RemoteValue();
																						RemoteValue remoteValue2 = remoteValue3;
																						remoteValue2.data = await Upload(x7.ToStream());
																						remoteValue3.dtype = Dtype.Uint8;
																						remoteValue3.shape = new int[1] { x7.Length };
																						result = remoteValue3;
																					}
																				}
																				else
																				{
																					RemoteValue remoteValue2 = new RemoteValue();
																					RemoteValue remoteValue3 = remoteValue2;
																					remoteValue3.data = await Upload(x6.ToStream());
																					remoteValue2.dtype = Dtype.Int64;
																					remoteValue2.shape = new int[1] { x6.Length };
																					result = remoteValue2;
																				}
																			}
																			else
																			{
																				RemoteValue remoteValue3 = new RemoteValue();
																				RemoteValue remoteValue2 = remoteValue3;
																				remoteValue2.data = await Upload(x5.ToStream());
																				remoteValue3.dtype = Dtype.Int32;
																				remoteValue3.shape = new int[1] { x5.Length };
																				result = remoteValue3;
																			}
																		}
																		else
																		{
																			RemoteValue remoteValue2 = new RemoteValue();
																			RemoteValue remoteValue3 = remoteValue2;
																			remoteValue3.data = await Upload(x4.ToStream());
																			remoteValue2.dtype = Dtype.Int16;
																			remoteValue2.shape = new int[1] { x4.Length };
																			result = remoteValue2;
																		}
																	}
																	else
																	{
																		RemoteValue remoteValue3 = new RemoteValue();
																		RemoteValue remoteValue2 = remoteValue3;
																		remoteValue2.data = await Upload(x3.ToStream());
																		remoteValue3.dtype = Dtype.Int8;
																		remoteValue3.shape = new int[1] { x3.Length };
																		result = remoteValue3;
																	}
																}
																else
																{
																	RemoteValue remoteValue2 = new RemoteValue();
																	RemoteValue remoteValue3 = remoteValue2;
																	remoteValue3.data = await Upload(x2.ToStream());
																	remoteValue2.dtype = Dtype.Float64;
																	remoteValue2.shape = new int[1] { x2.Length };
																	result = remoteValue2;
																}
															}
															else
															{
																RemoteValue remoteValue3 = new RemoteValue();
																RemoteValue remoteValue2 = remoteValue3;
																remoteValue2.data = await Upload(x.ToStream());
																remoteValue3.dtype = Dtype.Float32;
																remoteValue3.shape = new int[1] { x.Length };
																result = remoteValue3;
															}
														}
														else
														{
															RemoteValue remoteValue2 = new RemoteValue();
															RemoteValue remoteValue3 = remoteValue2;
															remoteValue3.data = await Upload(new bool[1] { flag }.ToStream());
															remoteValue2.dtype = Dtype.Bool;
															remoteValue2.shape = new int[0];
															result = remoteValue2;
														}
													}
													else
													{
														RemoteValue remoteValue3 = new RemoteValue();
														RemoteValue remoteValue2 = remoteValue3;
														remoteValue2.data = await Upload(new ulong[1] { num8 }.ToStream());
														remoteValue3.dtype = Dtype.Uint64;
														remoteValue3.shape = new int[0];
														result = remoteValue3;
													}
												}
												else
												{
													RemoteValue remoteValue2 = new RemoteValue();
													RemoteValue remoteValue3 = remoteValue2;
													remoteValue3.data = await Upload(new uint[1] { num7 }.ToStream());
													remoteValue2.dtype = Dtype.Uint32;
													remoteValue2.shape = new int[0];
													result = remoteValue2;
												}
											}
											else
											{
												RemoteValue remoteValue3 = new RemoteValue();
												RemoteValue remoteValue2 = remoteValue3;
												remoteValue2.data = await Upload(new ushort[1] { num6 }.ToStream());
												remoteValue3.dtype = Dtype.Uint16;
												remoteValue3.shape = new int[0];
												result = remoteValue3;
											}
										}
										else
										{
											RemoteValue remoteValue2 = new RemoteValue();
											RemoteValue remoteValue3 = remoteValue2;
											remoteValue3.data = await Upload(new byte[1] { b2 }.ToStream());
											remoteValue2.dtype = Dtype.Uint8;
											remoteValue2.shape = new int[0];
											result = remoteValue2;
										}
									}
									else
									{
										RemoteValue remoteValue3 = new RemoteValue();
										RemoteValue remoteValue2 = remoteValue3;
										remoteValue2.data = await Upload(new long[1] { num5 }.ToStream());
										remoteValue3.dtype = Dtype.Int64;
										remoteValue3.shape = new int[0];
										result = remoteValue3;
									}
								}
								else
								{
									RemoteValue remoteValue2 = new RemoteValue();
									RemoteValue remoteValue3 = remoteValue2;
									remoteValue3.data = await Upload(new int[1] { num4 }.ToStream());
									remoteValue2.dtype = Dtype.Int32;
									remoteValue2.shape = new int[0];
									result = remoteValue2;
								}
							}
							else
							{
								RemoteValue remoteValue3 = new RemoteValue();
								RemoteValue remoteValue2 = remoteValue3;
								remoteValue2.data = await Upload(new short[1] { num3 }.ToStream());
								remoteValue3.dtype = Dtype.Int16;
								remoteValue3.shape = new int[0];
								result = remoteValue3;
							}
						}
						else
						{
							RemoteValue remoteValue2 = new RemoteValue();
							RemoteValue remoteValue3 = remoteValue2;
							remoteValue3.data = await Upload(new sbyte[1] { b }.ToStream());
							remoteValue2.dtype = Dtype.Int8;
							remoteValue2.shape = new int[0];
							result = remoteValue2;
						}
					}
					else
					{
						RemoteValue remoteValue3 = new RemoteValue();
						RemoteValue remoteValue2 = remoteValue3;
						remoteValue2.data = await Upload(new double[1] { num2 }.ToStream());
						remoteValue3.dtype = Dtype.Float64;
						remoteValue3.shape = new int[0];
						result = remoteValue3;
					}
				}
				else
				{
					RemoteValue remoteValue2 = new RemoteValue();
					RemoteValue remoteValue3 = remoteValue2;
					remoteValue3.data = await Upload(new float[1] { num }.ToStream());
					remoteValue2.dtype = Dtype.Float32;
					remoteValue2.shape = new int[0];
					result = remoteValue2;
				}
			}
			else
			{
				result = new RemoteValue
				{
					dtype = Dtype.Null
				};
			}
			return result;
		}

		private async Task<object?> ToObject(RemoteValue value)
		{
			if (value.dtype == Dtype.Null)
			{
				return null;
			}
			using Stream stream = await Download(value.data);
			return value.dtype switch
			{
				Dtype.Float32 => stream.ToObject<float>(value.shape), 
				Dtype.Float64 => stream.ToObject<double>(value.shape), 
				Dtype.Int8 => stream.ToObject<sbyte>(value.shape), 
				Dtype.Int16 => stream.ToObject<short>(value.shape), 
				Dtype.Int32 => stream.ToObject<int>(value.shape), 
				Dtype.Int64 => stream.ToObject<long>(value.shape), 
				Dtype.Uint8 => stream.ToObject<byte>(value.shape), 
				Dtype.Uint16 => stream.ToObject<ushort>(value.shape), 
				Dtype.Uint32 => stream.ToObject<uint>(value.shape), 
				Dtype.Uint64 => stream.ToObject<ulong>(value.shape), 
				Dtype.Bool => stream.ToObject<bool>(value.shape), 
				Dtype.String => new StreamReader(stream).ReadToEnd(), 
				Dtype.List => JsonConvert.DeserializeObject<JArray>(new StreamReader(stream).ReadToEnd()), 
				Dtype.Dict => JsonConvert.DeserializeObject<JObject>(new StreamReader(stream).ReadToEnd()), 
				Dtype.Image => DeserializeImageValue(stream), 
				Dtype.Binary => stream.Clone(), 
				_ => throw new InvalidOperationException($"Failed to deserialize value with type {value.dtype} because it is not supported"), 
			};
		}

		private Task<string> Upload(Stream stream, string? mime = "application/octet-stream")
		{
			string text = Convert.ToBase64String(stream.ToArray<byte>());
			return Task.FromResult("data:" + mime + ";base64," + text);
		}

		private async Task<Stream> Download(string url)
		{
			if (url.StartsWith("data:"))
			{
				int startIndex = url.LastIndexOf(",") + 1;
				byte[] array = Convert.FromBase64String(url.Substring(startIndex));
				return new MemoryStream(array, 0, array.Length, writable: false, publiclyVisible: false);
			}
			return await client.Download(url);
		}

		private static Image DeserializeImageValue(Stream stream)
		{
			using Value value = Value.CreateFromBinary(stream, "image/*");
			return (Image)value.ToObject();
		}

		private async Task<Prediction> ParseRemotePrediction(RemotePrediction prediction)
		{
			object?[] results = null;
			if (prediction?.results != null)
			{
				results = new object[prediction.results.Length];
				int i = 0;
				while (i < results.Length)
				{
					object?[] array = results;
					int num = i;
					array[num] = await ToObject(prediction.results[i]);
					int num2 = i + 1;
					i = num2;
				}
			}
			return new Prediction
			{
				id = prediction.id,
				tag = prediction.tag,
				created = prediction.created,
				results = results,
				latency = prediction.latency,
				error = prediction.error,
				logs = prediction.logs
			};
		}
	}
}
