using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Muna.C
{
	public sealed class Value : IDisposable
	{
		[Flags]
		public enum Flags
		{
			None = 0,
			CopyData = 1
		}

		private readonly IntPtr value;

		public unsafe void* data
		{
			get
			{
				value.GetValueData(out var intPtr).Throw();
				return (void*)intPtr;
			}
		}

		public Dtype dtype
		{
			get
			{
				value.GetValueType(out var type).Throw();
				return type;
			}
		}

		public int[] shape
		{
			get
			{
				value.GetValueDimensions(out var dimensions).Throw();
				int[] result = new int[dimensions];
				value.GetValueShape(result, dimensions).Throw();
				return result;
			}
		}

		public unsafe object? ToObject()
		{
			return dtype switch
			{
				Dtype.Null => null, 
				Dtype.Float32 => ToObject((float*)data, shape), 
				Dtype.Float64 => ToObject((double*)data, shape), 
				Dtype.Int8 => ToObject((sbyte*)data, shape), 
				Dtype.Int16 => ToObject((short*)data, shape), 
				Dtype.Int32 => ToObject((int*)data, shape), 
				Dtype.Int64 => ToObject((long*)data, shape), 
				Dtype.Uint8 => ToObject((byte*)data, shape), 
				Dtype.Uint16 => ToObject((ushort*)data, shape), 
				Dtype.Uint32 => ToObject((uint*)data, shape), 
				Dtype.Uint64 => ToObject((ulong*)data, shape), 
				Dtype.Bool => ToObject((bool*)data, shape), 
				Dtype.String => Marshal.PtrToStringUTF8((IntPtr)data), 
				Dtype.List => JsonConvert.DeserializeObject<JArray>(Marshal.PtrToStringUTF8((IntPtr)data)), 
				Dtype.Dict => JsonConvert.DeserializeObject<JObject>(Marshal.PtrToStringUTF8((IntPtr)data)), 
				Dtype.Image => new Image(ToArray((byte*)data, shape), shape[1], shape[0], shape[2]), 
				Dtype.Binary => new MemoryStream(ToArray((byte*)data, shape)), 
				_ => throw new InvalidOperationException($"Cannot convert Muna value to object because value type is unsupported: {dtype}"), 
			};
		}

		public unsafe byte[] Serialize(string contentType)
		{
			Function.CreateSerializedValue(this.value, contentType, out var result).Throw();
			using Value value = new Value(result);
			return ToArray((byte*)value.data, value.shape);
		}

		public void Dispose()
		{
			value.ReleaseValue();
		}

		public static Value CreateArray<T>(T scalar) where T : unmanaged
		{
			return CreateArray<T>(new Tensor<T>(new T[1] { scalar }, new int[0]), Flags.CopyData);
		}

		public static Value CreateArray<T>(T[] vector) where T : unmanaged
		{
			return CreateArray<T>(new Tensor<T>(vector, new int[1] { vector.Length }), Flags.CopyData);
		}

		public unsafe static Value CreateArray<T>(in Tensor<T> tensor, Flags flags = Flags.None) where T : unmanaged
		{
			IntPtr intPtr = default(IntPtr);
			flags = (Flags)((int)flags | ((tensor.data != null) ? 1 : 0));
			fixed (T* ptr = tensor)
			{
				Function.CreateArrayValue(ptr, tensor.shape, tensor.shape.Length, ToDtype<T>(), flags, out intPtr).Throw();
			}
			return new Value(intPtr);
		}

		public static Value CreateString(string input)
		{
			Function.CreateStringValue(input, out var intPtr).Throw();
			return new Value(intPtr);
		}

		public static Value CreateList(IList list)
		{
			Function.CreateListValue(JsonConvert.SerializeObject(list), out var intPtr).Throw();
			return new Value(intPtr);
		}

		public static Value CreateDict(IDictionary dict)
		{
			Function.CreateDictValue(JsonConvert.SerializeObject(dict), out var intPtr).Throw();
			return new Value(intPtr);
		}

		public unsafe static Value CreateImage(in Image image, Flags flags = Flags.None)
		{
			IntPtr intPtr = default(IntPtr);
			flags = (Flags)((int)flags | ((image.data != null) ? 1 : 0));
			fixed (byte* pixelBuffer = image)
			{
				Function.CreateImageValue(pixelBuffer, image.width, image.height, image.channels, flags, out intPtr).Throw();
			}
			return new Value(intPtr);
		}

		public static Value CreateBinary(Stream stream, Flags flags = Flags.None)
		{
			byte[] array;
			if (stream is MemoryStream memoryStream)
			{
				array = memoryStream.ToArray();
			}
			else
			{
				using MemoryStream memoryStream2 = new MemoryStream();
				stream.CopyTo(memoryStream2);
				array = memoryStream2.ToArray();
			}
			flags |= Flags.CopyData;
			Function.CreateBinaryValue(array, array.Length, flags, out var intPtr).Throw();
			return new Value(intPtr);
		}

		public static Value CreateNull()
		{
			Function.CreateNullValue(out var intPtr).Throw();
			return new Value(intPtr);
		}

		public static Value CreateFromBinary(Stream stream, string contentType)
		{
			using Value value = CreateBinary(stream);
			Function.CreateValueFromSerializedValue(value, contentType, out var result).Throw();
			return new Value(result);
		}

		internal Value(IntPtr value)
		{
			this.value = value;
		}

		public static implicit operator IntPtr(Value value)
		{
			return value.value;
		}

		private unsafe static object ToObject<T>(T* data, int[] shape) where T : unmanaged
		{
			if (shape.Length == 0)
			{
				return *data;
			}
			return new Tensor<T>(ToArray(data, shape), shape);
		}

		private unsafe static T[] ToArray<T>(T* data, int[] shape) where T : unmanaged
		{
			int num = shape.Aggregate(1, (int a, int b) => a * b);
			T[] array = new T[num];
			int num2 = num * sizeof(T);
			fixed (T* ptr = array)
			{
				void* destination = ptr;
				Buffer.MemoryCopy(data, destination, num2, num2);
			}
			return array;
		}

		private static Dtype ToDtype<T>() where T : unmanaged
		{
			T val = default(T);
			if (!(val is float))
			{
				if (!(val is double))
				{
					if (!(val is sbyte))
					{
						if (!(val is short))
						{
							if (!(val is int))
							{
								if (!(val is long))
								{
									if (!(val is byte))
									{
										if (!(val is ushort))
										{
											if (!(val is uint))
											{
												if (!(val is ulong))
												{
													if (val is bool)
													{
														return Dtype.Bool;
													}
													return Dtype.Null;
												}
												return Dtype.Uint64;
											}
											return Dtype.Uint32;
										}
										return Dtype.Uint16;
									}
									return Dtype.Uint8;
								}
								return Dtype.Int64;
							}
							return Dtype.Int32;
						}
						return Dtype.Int16;
					}
					return Dtype.Int8;
				}
				return Dtype.Float64;
			}
			return Dtype.Float32;
		}
	}
}
