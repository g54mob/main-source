using System;
using System.Buffers;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using ProtoBuf.Internal;
using ProtoBuf.Meta;
using ProtoBuf.Serializers;

namespace ProtoBuf
{
	public abstract class ProtoReader : IDisposable, ISerializationContext
	{
		private protected enum Read32VarintMode
		{
			Signed = 0,
			Unsigned = 1,
			FieldHeader = 2
		}

		[StructLayout(LayoutKind.Auto)]
		public ref struct State
		{
			private ProtoReader _reader;

			private ReadOnlyMemory<byte> _memory;

			internal ReadOnlySpan<byte> Span { get; private set; }

			internal int OffsetInCurrent { get; private set; }

			internal int RemainingInCurrent { get; private set; }

			public WireType WireType
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get
				{
					return _reader.WireType;
				}
			}

			public bool InternStrings
			{
				get
				{
					return _reader.InternStrings;
				}
				set
				{
					_reader.InternStrings = value;
				}
			}

			public int FieldNumber
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get
				{
					return _reader._fieldNumber;
				}
			}

			internal TypeModel Model
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get
				{
					return _reader?.Model;
				}
				private set
				{
					_reader.Model = value;
				}
			}

			public ISerializationContext Context
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get
				{
					return _reader;
				}
			}

			public static State Create(ReadOnlySequence<byte> source, TypeModel model, object userState = null)
			{
				ReadOnlySequenceProtoReader readOnlySequenceProtoReader = Pool<ReadOnlySequenceProtoReader>.TryGet() ?? new ReadOnlySequenceProtoReader();
				readOnlySequenceProtoReader.Init(source, model, userState);
				return new State(readOnlySequenceProtoReader);
			}

			public static State Create(ReadOnlyMemory<byte> source, TypeModel model, object userState = null)
			{
				return Create(new ReadOnlySequence<byte>(source), model, userState);
			}

			public void Dispose()
			{
				ProtoReader reader = _reader;
				this = default(State);
				reader?.Dispose();
			}

			internal SolidState Solidify()
			{
				return new SolidState(_reader, _memory.Slice(OffsetInCurrent, RemainingInCurrent));
			}

			internal State(ProtoReader reader, ReadOnlyMemory<byte> memory)
				: this(reader)
			{
				Init(memory);
			}

			internal State(ProtoReader reader)
			{
				this = default(State);
				_reader = reader;
			}

			internal void Init(ReadOnlyMemory<byte> memory)
			{
				_memory = memory;
				Span = memory.Span;
				OffsetInCurrent = 0;
				RemainingInCurrent = Span.Length;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void Skip(int bytes)
			{
				OffsetInCurrent += bytes;
				RemainingInCurrent -= bytes;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal ReadOnlySpan<byte> Consume(int bytes)
			{
				ReadOnlySpan<byte> result = Span.Slice(OffsetInCurrent, bytes);
				OffsetInCurrent += bytes;
				RemainingInCurrent -= bytes;
				return result;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal ReadOnlySpan<byte> Consume(int bytes, out int offset)
			{
				offset = OffsetInCurrent;
				OffsetInCurrent += bytes;
				RemainingInCurrent -= bytes;
				return Span;
			}

			internal int ReadVarintUInt32(out uint value)
			{
				value = Span[OffsetInCurrent];
				int num = (((value & 0x80) == 0) ? 1 : ParseVarintUInt32Tail(Span.Slice(OffsetInCurrent), ref value));
				OffsetInCurrent += num;
				RemainingInCurrent -= num;
				return num;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal int ParseVarintUInt32(ReadOnlySpan<byte> span, out uint value)
			{
				value = span[0];
				if ((value & 0x80) != 0)
				{
					return ParseVarintUInt32Tail(span, ref value);
				}
				return 1;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal int ParseVarintUInt32(ReadOnlySpan<byte> span, int offset, out uint value)
			{
				value = span[offset];
				if ((value & 0x80) != 0)
				{
					return ParseVarintUInt32Tail(span.Slice(offset), ref value);
				}
				return 1;
			}

			private int ParseVarintUInt32Tail(ReadOnlySpan<byte> span, ref uint value)
			{
				uint num = span[1];
				value = (value & 0x7F) | ((num & 0x7F) << 7);
				if ((num & 0x80) == 0)
				{
					return 2;
				}
				num = span[2];
				value |= (num & 0x7F) << 14;
				if ((num & 0x80) == 0)
				{
					return 3;
				}
				num = span[3];
				value |= (num & 0x7F) << 21;
				if ((num & 0x80) == 0)
				{
					return 4;
				}
				num = span[4];
				value |= num << 28;
				if ((num & 0xF0) == 0)
				{
					return 5;
				}
				ThrowOverflow();
				return 0;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void Advance(long count)
			{
				_reader.Advance(count);
			}

			internal static int TryParseUInt64Varint(ReadOnlySpan<byte> span, int offset, out ulong value)
			{
				if ((uint)offset >= (uint)span.Length)
				{
					value = 0uL;
					return 0;
				}
				value = span[offset++];
				if ((value & 0x80) == 0L)
				{
					return 1;
				}
				value &= 127uL;
				if ((uint)offset >= (uint)span.Length)
				{
					NoContextThrowEoF();
				}
				ulong num = span[offset++];
				value |= (num & 0x7F) << 7;
				if ((num & 0x80) == 0L)
				{
					return 2;
				}
				if ((uint)offset >= (uint)span.Length)
				{
					NoContextThrowEoF();
				}
				num = span[offset++];
				value |= (num & 0x7F) << 14;
				if ((num & 0x80) == 0L)
				{
					return 3;
				}
				if ((uint)offset >= (uint)span.Length)
				{
					NoContextThrowEoF();
				}
				num = span[offset++];
				value |= (num & 0x7F) << 21;
				if ((num & 0x80) == 0L)
				{
					return 4;
				}
				if ((uint)offset >= (uint)span.Length)
				{
					NoContextThrowEoF();
				}
				num = span[offset++];
				value |= (num & 0x7F) << 28;
				if ((num & 0x80) == 0L)
				{
					return 5;
				}
				if ((uint)offset >= (uint)span.Length)
				{
					NoContextThrowEoF();
				}
				num = span[offset++];
				value |= (num & 0x7F) << 35;
				if ((num & 0x80) == 0L)
				{
					return 6;
				}
				if ((uint)offset >= (uint)span.Length)
				{
					NoContextThrowEoF();
				}
				num = span[offset++];
				value |= (num & 0x7F) << 42;
				if ((num & 0x80) == 0L)
				{
					return 7;
				}
				if ((uint)offset >= (uint)span.Length)
				{
					NoContextThrowEoF();
				}
				num = span[offset++];
				value |= (num & 0x7F) << 49;
				if ((num & 0x80) == 0L)
				{
					return 8;
				}
				if ((uint)offset >= (uint)span.Length)
				{
					NoContextThrowEoF();
				}
				num = span[offset++];
				value |= (num & 0x7F) << 56;
				if ((num & 0x80) == 0L)
				{
					return 9;
				}
				if ((uint)offset >= (uint)span.Length)
				{
					NoContextThrowEoF();
				}
				num = span[offset];
				value |= num << 63;
				if ((num & 0xFFFFFFFFFFFFFFFEuL) != 0L)
				{
					NoContextThrowOverflow();
				}
				return 10;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal ProtoReader GetReader()
			{
				return _reader;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ushort ReadUInt16()
			{
				return checked((ushort)ReadUInt32());
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public short ReadInt16()
			{
				return checked((short)ReadInt32());
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public long GetPosition()
			{
				return _reader._longPosition;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public byte ReadByte()
			{
				return checked((byte)ReadUInt32());
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public sbyte ReadSByte()
			{
				return checked((sbyte)ReadInt32());
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public uint ReadUInt32()
			{
				switch (_reader.WireType)
				{
				case WireType.Variant:
					return ReadUInt32Varint(Read32VarintMode.Signed);
				case WireType.Fixed32:
					return _reader.ImplReadUInt32Fixed(ref this);
				case WireType.Fixed64:
				{
					ulong num = _reader.ImplReadUInt64Fixed(ref this);
					return checked((uint)num);
				}
				default:
					ThrowWireTypeException();
					return 0u;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public int ReadInt32()
			{
				switch (_reader.WireType)
				{
				case WireType.Variant:
					return (int)ReadUInt32Varint(Read32VarintMode.Signed);
				case WireType.Fixed32:
					return (int)_reader.ImplReadUInt32Fixed(ref this);
				case WireType.Fixed64:
				{
					long num = ReadInt64();
					return checked((int)num);
				}
				case WireType.SignedVariant:
					return Zag(ReadUInt32Varint(Read32VarintMode.Signed));
				default:
					ThrowWireTypeException();
					return 0;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public long ReadInt64()
			{
				switch (_reader.WireType)
				{
				case WireType.Variant:
					return (long)ReadUInt64Varint();
				case WireType.Fixed32:
					return (int)_reader.ImplReadUInt32Fixed(ref this);
				case WireType.Fixed64:
					return (long)_reader.ImplReadUInt64Fixed(ref this);
				case WireType.SignedVariant:
					return Zag(ReadUInt64Varint());
				default:
					ThrowWireTypeException();
					return 0L;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public unsafe double ReadDouble()
			{
				switch (_reader.WireType)
				{
				case WireType.Fixed32:
					return ReadSingle();
				case WireType.Fixed64:
				{
					long num = ReadInt64();
					return *(double*)(&num);
				}
				default:
					ThrowWireTypeException();
					return 0.0;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public unsafe float ReadSingle()
			{
				switch (_reader.WireType)
				{
				case WireType.Fixed32:
				{
					int num3 = ReadInt32();
					return *(float*)(&num3);
				}
				case WireType.Fixed64:
				{
					double num = ReadDouble();
					float num2 = (float)num;
					if (float.IsInfinity(num2) && !double.IsInfinity(num))
					{
						ThrowOverflow();
					}
					return num2;
				}
				default:
					ThrowWireTypeException();
					return 0f;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void PrepareToReadRepeated<T>(ref SerializerFeatures features, SerializerFeatures serializerFeatures, out SerializerFeatures category, out bool packed)
			{
				if (serializerFeatures.IsRepeated())
				{
					TypeModel.ThrowNestedListsNotSupported(typeof(T));
				}
				features.InheritFrom(serializerFeatures);
				category = serializerFeatures.GetCategory();
				packed = false;
				if (TypeHelper<T>.CanBePacked && WireType == WireType.String)
				{
					if (category != SerializerFeatures.CategoryScalar)
					{
						ThrowInvalidOperationException("Packed data expected a scalar serializer");
					}
					packed = true;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void ReadRepeatedCore<TSerializer, TList, T>(ref TList values, SerializerFeatures category, WireType wireType, in TSerializer serializer, T initialValue) where TSerializer : ISerializer<T> where TList : ICollection<T>
			{
				int fieldNumber = FieldNumber;
				do
				{
					T item;
					switch (category)
					{
					case SerializerFeatures.CategoryScalar:
						Hint(wireType);
						item = serializer.Read(ref this, initialValue);
						break;
					case SerializerFeatures.CategoryMessage:
					case SerializerFeatures.CategoryMessageWrappedAtRoot:
						item = ReadMessage(SerializerFeatures.CategoryRepeated, initialValue, in serializer);
						break;
					default:
						category.ThrowInvalidCategory();
						item = default(T);
						break;
					}
					values.Add(item);
				}
				while (TryReadFieldHeader(fieldNumber));
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void ReadPackedScalar<TSerializer, TList, T>(ref TList list, WireType wireType, in TSerializer serializer) where TSerializer : ISerializer<T> where TList : ICollection<T>
			{
				int num = checked((int)ReadUInt32Varint(Read32VarintMode.Unsigned));
				if (num == 0)
				{
					return;
				}
				int num2;
				if (wireType <= WireType.Fixed64)
				{
					if (wireType == WireType.Variant)
					{
						goto IL_00da;
					}
					if (wireType == WireType.Fixed64)
					{
						if (num % 8 != 0)
						{
							ThrowHelper.ThrowInvalidOperationException("packed length should be multiple of 8");
						}
						num2 = num / 8;
						goto IL_005a;
					}
				}
				else
				{
					if (wireType == WireType.Fixed32)
					{
						if (num % 4 != 0)
						{
							ThrowHelper.ThrowInvalidOperationException("packed length should be multiple of 4");
						}
						num2 = num / 4;
						goto IL_005a;
					}
					if (wireType == WireType.SignedVariant)
					{
						goto IL_00da;
					}
				}
				ThrowHelper.ThrowInvalidPackedOperationException(WireType, typeof(T));
				return;
				IL_00da:
				long num3 = GetPosition() + num;
				TSerializer val;
				do
				{
					_reader.WireType = wireType;
					val = serializer;
					T item = val.Read(ref this, default(T));
					list.Add(item);
				}
				while (GetPosition() < num3);
				if (GetPosition() != num3)
				{
					ThrowHelper.ThrowInvalidOperationException("over-read packed data");
				}
				return;
				IL_005a:
				if (list is List<T> list2)
				{
					list2.Capacity = Math.Max(list2.Capacity, list2.Count + Math.Min(num2, 8192));
				}
				for (int i = 0; i < num2; i++)
				{
					_reader.WireType = wireType;
					val = serializer;
					T item2 = val.Read(ref this, default(T));
					list.Add(item2);
				}
			}

			internal ReadBuffer<T> FillBuffer<TSerializer, T>(SerializerFeatures features, in TSerializer serializer, T initialValue) where TSerializer : ISerializer<T>
			{
				PrepareToReadRepeated<T>(ref features, serializer.Features, out var category, out var packed);
				ReadBuffer<T> values = ReadBuffer<T>.Create();
				try
				{
					WireType wireType = features.GetWireType();
					if (packed)
					{
						ReadPackedScalar<TSerializer, ReadBuffer<T>, T>(ref values, wireType, in serializer);
					}
					else
					{
						ReadRepeatedCore(ref values, category, wireType, in serializer, initialValue);
					}
					return values;
				}
				catch
				{
					try
					{
						values.Dispose();
					}
					catch
					{
					}
					throw;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool ReadBoolean()
			{
				return ReadUInt32() != 0;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ulong ReadUInt64()
			{
				switch (_reader.WireType)
				{
				case WireType.Variant:
					return ReadUInt64Varint();
				case WireType.Fixed32:
					return _reader.ImplReadUInt32Fixed(ref this);
				case WireType.Fixed64:
					return _reader.ImplReadUInt64Fixed(ref this);
				default:
					ThrowWireTypeException();
					return 0uL;
				}
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public byte[] AppendBytes(byte[] value)
			{
				return AppendBytes(value, DefaultMemoryConverter<byte>.Instance);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ReadOnlyMemory<byte> AppendBytes(ReadOnlyMemory<byte> value)
			{
				return AppendBytesImpl(value, DefaultMemoryConverter<byte>.Instance);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public Memory<byte> AppendBytes(Memory<byte> value)
			{
				return AppendBytesImpl(value, DefaultMemoryConverter<byte>.Instance);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ArraySegment<byte> AppendBytes(ArraySegment<byte> value)
			{
				return AppendBytesImpl(value, DefaultMemoryConverter<byte>.Instance);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public TStorage AppendBytes<TStorage>(TStorage value, IMemoryConverter<TStorage, byte> converter = null)
			{
				return AppendBytesImpl(value, converter ?? DefaultMemoryConverter<byte>.GetFor<TStorage>(Model));
			}

			private TStorage AppendBytesImpl<TStorage>(TStorage value, IMemoryConverter<TStorage, byte> converter)
			{
				WireType wireType = _reader.WireType;
				if (wireType == WireType.String)
				{
					int num = (int)ReadUInt32Varint(Read32VarintMode.Signed);
					_reader.WireType = WireType.None;
					if (num == 0)
					{
						return converter.NonNull(in value);
					}
					Memory<byte> memory = converter.Expand(Context, ref value, num);
					_reader.ImplReadBytes(ref this, memory.Span);
					return value;
				}
				ThrowWireTypeException();
				return default(TStorage);
			}

			public Span<byte> ReadBytes(Span<byte> destination)
			{
				WireType wireType = _reader.WireType;
				if (wireType == WireType.String)
				{
					int num = (int)ReadUInt32Varint(Read32VarintMode.Signed);
					if (num > destination.Length)
					{
						ThrowHelper.ThrowInvalidOperationException($"Insufficient space in the target span to read a string/bytes value; {destination.Length} vs {num} bytes");
					}
					_reader.WireType = WireType.None;
					destination = destination.Slice(0, num);
					_reader.ImplReadBytes(ref this, destination);
					return destination;
				}
				ThrowWireTypeException();
				return default(Span<byte>);
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public SubItemToken StartSubItem()
			{
				ProtoReader reader = _reader;
				switch (_reader.WireType)
				{
				case WireType.StartGroup:
					reader.WireType = WireType.None;
					reader._depth++;
					return new SubItemToken(-reader._fieldNumber);
				case WireType.String:
				{
					long num = (long)ReadUInt64Varint();
					if (num < 0)
					{
						ThrowInvalidOperationException();
					}
					long blockEnd = reader.blockEnd64;
					reader.blockEnd64 = reader._longPosition + num;
					reader._depth++;
					return new SubItemToken(blockEnd);
				}
				default:
					ThrowWireTypeException();
					return default(SubItemToken);
				}
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void EndSubItem(SubItemToken token)
			{
				long value = token.value64;
				ProtoReader reader = _reader;
				WireType wireType = reader.WireType;
				if (wireType == WireType.EndGroup)
				{
					if (value >= 0)
					{
						ThrowProtoException("A length-based message was terminated via end-group; this indicates data corruption");
					}
					if (-(int)value != reader._fieldNumber)
					{
						ThrowProtoException("Wrong group was ended");
					}
					reader.WireType = WireType.None;
					reader._depth--;
					return;
				}
				long longPosition = reader._longPosition;
				if (value < longPosition)
				{
					ThrowProtoException($"Sub-message not read entirely; expected {value}, was {longPosition}");
				}
				if (reader.blockEnd64 != longPosition && reader.blockEnd64 != long.MaxValue)
				{
					ThrowProtoException($"Sub-message not read correctly (end {reader.blockEnd64} vs {longPosition})");
				}
				reader.blockEnd64 = value;
				reader._depth--;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal object ReadObject(object value, Type type)
			{
				return ReadTypedObject(value, type);
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal object ReadTypedObject(object value, Type type)
			{
				TypeModel model = Model;
				if (model == null)
				{
					ThrowInvalidOperationException("Cannot deserialize sub-objects unless a model is provided");
				}
				if (DynamicStub.TryDeserialize(ObjectScope.WrappedMessage, type, model, ref this, ref value))
				{
					return value;
				}
				SubItemToken token = StartSubItem();
				if ((object)type == null || !model.TryDeserializeAuxiliaryType(ref this, DataFormat.Default, 1, type, ref value, skipOtherFields: true, asListItem: false, autoCreate: true, insideList: false, null))
				{
					TypeModel.ThrowUnexpectedType(type, Model);
				}
				EndSubItem(token);
				return value;
			}

			internal void SkipAllFields()
			{
				while (ReadFieldHeader() > 0)
				{
					SkipField();
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public string ReadString(StringMap map = null)
			{
				if (_reader.WireType == WireType.String)
				{
					int num = (int)ReadUInt32Varint(Read32VarintMode.Unsigned);
					if (num == 0)
					{
						return "";
					}
					string text = _reader.ImplReadString(ref this, num);
					if (_reader.InternStrings)
					{
						text = _reader.Intern(text);
					}
					return text;
				}
				ThrowWireTypeException();
				return null;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private uint ReadUInt32Varint(Read32VarintMode mode)
			{
				uint value;
				int num = _reader.ImplTryReadUInt32VarintWithoutMoving(ref this, mode, out value);
				if (num <= 0)
				{
					if (mode == Read32VarintMode.FieldHeader)
					{
						return 0u;
					}
					ThrowEoF();
				}
				_reader.ImplSkipBytes(ref this, num);
				return value;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private ulong ReadUInt64Varint()
			{
				ulong value;
				int num = _reader.ImplTryReadUInt64VarintWithoutMoving(ref this, out value);
				if (num <= 0)
				{
					ThrowEoF();
				}
				_reader.ImplSkipBytes(ref this, num);
				return value;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Assert(WireType wireType)
			{
				WireType wireType2 = _reader.WireType;
				if (wireType2 != wireType)
				{
					if ((wireType & (WireType)7) == wireType2)
					{
						_reader.WireType = wireType;
					}
					else
					{
						ThrowWireTypeException();
					}
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void SkipField()
			{
				switch (_reader.WireType)
				{
				case WireType.Fixed32:
					_reader.ImplSkipBytes(ref this, 4L);
					break;
				case WireType.Fixed64:
					_reader.ImplSkipBytes(ref this, 8L);
					break;
				case WireType.String:
				{
					long count = (long)ReadUInt64Varint();
					_reader.ImplSkipBytes(ref this, count);
					break;
				}
				case WireType.Variant:
				case WireType.SignedVariant:
					ReadUInt64Varint();
					break;
				case WireType.StartGroup:
					SkipGroup();
					break;
				default:
					ThrowWireTypeException();
					break;
				}
			}

			internal Type DeserializeType(string typeName)
			{
				return _reader.DeserializeType(typeName);
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private void SkipGroup()
			{
				int fieldNumber = _reader._fieldNumber;
				_reader._depth++;
				while (ReadFieldHeader() > 0)
				{
					SkipField();
				}
				_reader._depth--;
				if (_reader.WireType == WireType.EndGroup && _reader._fieldNumber == fieldNumber)
				{
					_reader.WireType = WireType.None;
				}
				else
				{
					ThrowWireTypeException();
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public int ReadFieldHeader()
			{
				if (_reader.blockEnd64 <= _reader._longPosition || _reader.WireType == WireType.EndGroup)
				{
					return 0;
				}
				if (RemainingInCurrent >= 5)
				{
					uint value;
					int num = ReadVarintUInt32(out value);
					_reader.Advance(num);
					return _reader.SetTag(value);
				}
				return ReadFieldHeaderFallback();
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private int ReadFieldHeaderFallback()
			{
				uint value;
				int num = _reader.ImplTryReadUInt32VarintWithoutMoving(ref this, Read32VarintMode.FieldHeader, out value);
				if (num == 0)
				{
					_reader.WireType = WireType.Variant;
					return _reader._fieldNumber = 0;
				}
				_reader.ImplSkipBytes(ref this, num);
				return _reader.SetTag(value);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool TryReadFieldHeader(int field)
			{
				ProtoReader reader = _reader;
				if (reader.blockEnd64 <= reader._longPosition || reader.WireType == WireType.EndGroup)
				{
					return false;
				}
				uint value;
				int num = reader.ImplTryReadUInt32VarintWithoutMoving(ref this, Read32VarintMode.FieldHeader, out value);
				WireType wireType;
				if (num > 0 && (int)value >> 3 == field && (wireType = (WireType)(value & 7)) != WireType.EndGroup)
				{
					reader.WireType = wireType;
					reader._fieldNumber = field;
					reader.ImplSkipBytes(ref this, num);
					return true;
				}
				return false;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void CheckFullyConsumed()
			{
				if (!_reader.IsFullyConsumed(ref this))
				{
					ThrowProtoException("Incorrect number of bytes consumed");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void Hint(WireType wireType)
			{
				_reader.Hint(wireType);
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void ThrowWireTypeException()
			{
				string message = ((_reader == null) ? "(no reader)" : $"Invalid wire-type ({_reader.WireType}); this usually means you have over-written a file without truncating or setting the length; see https://stackoverflow.com/q/2152978/23354");
				ThrowProtoException(message);
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void ThrowProtoException(string message)
			{
				throw AddErrorData(new ProtoException(message), _reader, ref this);
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void ThrowEoF()
			{
				throw AddErrorData(new EndOfStreamException(), _reader, ref this);
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void ThrowInvalidOperationException(string message = null)
			{
				InvalidOperationException exception = (string.IsNullOrWhiteSpace(message) ? new InvalidOperationException() : new InvalidOperationException(message));
				throw AddErrorData(exception, _reader, ref this);
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void ThrowArgumentException(string message)
			{
				throw AddErrorData(new ArgumentException(message), _reader, ref this);
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void ThrowOverflow()
			{
				throw AddErrorData(new OverflowException(), _reader, ref this);
			}

			internal static Exception AddErrorData(Exception exception, ProtoReader source, ref State state)
			{
				if (exception != null && source != null && !exception.Data.Contains("protoSource"))
				{
					exception.Data.Add("protoSource", $"tag={source.FieldNumber}; wire-type={source.WireType}; offset={state.GetPosition()}; depth={source._depth}");
				}
				return exception;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static int Zag(uint ziggedValue)
			{
				return (int)(0 - (ziggedValue & 1)) ^ (((int)ziggedValue >> 1) & 0x7FFFFFFF);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static long Zag(ulong ziggedValue)
			{
				return (long)(0L - (ziggedValue & 1)) ^ (((long)ziggedValue >> 1) & 0x7FFFFFFFFFFFFFFFL);
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void ThrowEnumException(Type type, int value)
			{
				string text = (((object)type == null) ? "<null>" : type.FullName);
				throw AddErrorData(new ProtoException("No " + text + " enum is mapped to the wire-value " + value), _reader, ref this);
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public void AppendExtensionData(IExtensible instance)
			{
				if (instance == null)
				{
					ThrowHelper.ThrowArgumentNullException("instance");
				}
				IExtension extensionObject = instance.GetExtensionObject(createIfMissing: true);
				bool commit = false;
				Stream stream = extensionObject.BeginAppend();
				try
				{
					ProtoWriter.State writeState = ProtoWriter.State.Create(stream, _reader._model);
					try
					{
						AppendExtensionField(ref writeState);
						writeState.Close();
					}
					catch
					{
						writeState.Abandon();
						throw;
					}
					finally
					{
						writeState.Dispose();
					}
					commit = true;
				}
				finally
				{
					extensionObject.EndAppend(stream, commit);
				}
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private void AppendExtensionField(ref ProtoWriter.State writeState)
			{
				ProtoReader reader = _reader;
				writeState.WriteFieldHeader(reader._fieldNumber, reader.WireType);
				switch (reader.WireType)
				{
				case WireType.Fixed32:
					writeState.WriteInt32(ReadInt32());
					break;
				case WireType.Variant:
				case WireType.Fixed64:
				case WireType.SignedVariant:
					writeState.WriteInt64(ReadInt64());
					break;
				case WireType.String:
					writeState.WriteBytes(AppendBytes(null));
					break;
				case WireType.StartGroup:
				{
					SubItemToken token = StartSubItem();
					SubItemToken token2 = writeState.StartSubItem(null);
					while (ReadFieldHeader() > 0)
					{
						AppendExtensionField(ref writeState);
					}
					EndSubItem(token);
					writeState.EndSubItem(token2);
					break;
				}
				default:
					ThrowWireTypeException();
					break;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public Type ReadType()
			{
				return TypeModel.DeserializeType(_reader._model, ReadString());
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public T ReadMessage<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(T value = default(T))
			{
				return ReadMessage(SerializerFeatures.CategoryRepeated, value);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public T ReadMessage<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(SerializerFeatures features, T value = default(T), ISerializer<T> serializer = null)
			{
				ISerializer<T> serializer2 = serializer ?? TypeModel.GetSerializer<T>(Model);
				return ReadMessage(features, value, in serializer2);
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal T ReadMessage<TSerializer, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(SerializerFeatures features, T value, in TSerializer serializer) where TSerializer : ISerializer<T>
			{
				SubItemToken token = StartSubItem();
				T result = serializer.Read(ref this, value);
				EndSubItem(token);
				return result;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public T ReadAny<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(T value = default(T))
			{
				return ReadAny(SerializerFeatures.CategoryRepeated, value);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public T ReadAny<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(SerializerFeatures features, T value = default(T), ISerializer<T> serializer = null)
			{
				if (serializer == null)
				{
					serializer = TypeModel.GetSerializer<T>(Model);
				}
				SerializerFeatures features2 = serializer.Features;
				features.InheritFrom(features2);
				switch (features2.GetCategory())
				{
				case SerializerFeatures.CategoryMessage:
				case SerializerFeatures.CategoryMessageWrappedAtRoot:
					return ReadMessage(features, value, serializer);
				case SerializerFeatures.CategoryRepeated:
					return ((IRepeatedSerializer<T>)serializer).ReadRepeated(ref this, features, value);
				case SerializerFeatures.CategoryScalar:
					features.HintIfNeeded(ref this);
					return serializer.Read(ref this, value);
				default:
					features.ThrowInvalidCategory();
					return default(T);
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ISerializer<T> GetSerializer<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>()
			{
				return TypeModel.GetSerializer<T>(Model);
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public T ReadBaseType<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] TBaseType, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(T value = null, ISubTypeSerializer<TBaseType> serializer = null) where TBaseType : class where T : class, TBaseType
			{
				return (T)(serializer ?? TypeModel.GetSubTypeSerializer<TBaseType>(_reader._model)).ReadSubType(ref this, SubTypeState<TBaseType>.Create(_reader, value));
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public T DeserializeRoot<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(T value = default(T), ISerializer<T> serializer = null)
			{
				value = ReadAsRoot(value, serializer ?? TypeModel.GetSerializer<T>(Model));
				CheckFullyConsumed();
				return value;
			}

			internal T ReadAsRoot<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(T value, ISerializer<T> serializer)
			{
				SerializerFeatures features = serializer.Features;
				switch (features.GetCategory())
				{
				case SerializerFeatures.CategoryMessageWrappedAtRoot:
					return ReadFieldOne(ref this, features, value, serializer);
				case SerializerFeatures.CategoryMessage:
					return serializer.Read(ref this, value);
				case SerializerFeatures.CategoryRepeated:
				case SerializerFeatures.CategoryScalar:
					return ReadFieldOne(ref this, features, value, serializer);
				default:
					features.ThrowInvalidCategory();
					return default(T);
				}
				static T ReadFieldOne(ref State state, SerializerFeatures features2, T val, ISerializer<T> serializer2)
				{
					bool flag = false;
					int num;
					while ((num = state.ReadFieldHeader()) > 0)
					{
						if (num == 1)
						{
							flag = true;
							val = state.ReadAny(features2, val, serializer2);
						}
						else
						{
							state.SkipField();
						}
					}
					if (TypeHelper<T>.IsReferenceType && !flag && val == null)
					{
						val = state.CreateInstance(serializer2);
					}
					return val;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public bool HasSubValue(WireType wireType)
			{
				return ProtoReader.HasSubValue(wireType, _reader);
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			public T CreateInstance<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(ISerializer<T> serializer = null)
			{
				return TypeModel.CreateInstance(Context, serializer);
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal object DeserializeRootFallbackWithModel(object value, Type type, TypeModel overrideModel)
			{
				TypeModel model = Model;
				try
				{
					Model = overrideModel;
					return DeserializeRootFallback(value, type);
				}
				finally
				{
					Model = model;
				}
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal object DeserializeRootFallback(object value, Type type)
			{
				bool autoCreate = TypeModel.PrepareDeserialize(value, ref type);
				object result = Model.DeserializeRootAny(ref this, type, value, autoCreate);
				CheckFullyConsumed();
				return result;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal T DeserializeRootImpl<T>(T value = default(T))
			{
				ISerializer<T> serializer = TypeModel.TryGetSerializer<T>(Model);
				if (serializer == null)
				{
					return (T)DeserializeRootFallback(value, typeof(T));
				}
				return DeserializeRoot(value, serializer);
			}

			public static State Create(Stream source, TypeModel model, object userState = null, long length = -1L)
			{
				ProtoReader reader = ProtoReader.Create(source, model, userState, length);
				return new State(reader);
			}
		}

		private sealed class ReadOnlySequenceProtoReader : ProtoReader
		{
			private ReadOnlySequence<byte>.Enumerator _source;

			protected internal override State DefaultState()
			{
				ThrowHelper.ThrowInvalidOperationException("You must retain and pass the state from ProtoReader.Create");
				return default(State);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal unsafe static string ToString(ReadOnlySpan<byte> span, int offset, int bytes)
			{
				fixed (byte* reference = &MemoryMarshal.GetReference(span))
				{
					byte* bytes2 = reference + offset;
					int charCount = UTF8.GetCharCount(bytes2, bytes);
					string text = new string('\0', charCount);
					fixed (char* chars = text)
					{
						UTF8.GetChars(bytes2, bytes, chars, charCount);
					}
					return text;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal unsafe static string ToString(ReadOnlySpan<byte> span)
			{
				fixed (byte* reference = &MemoryMarshal.GetReference(span))
				{
					byte* bytes = reference;
					int length = span.Length;
					int charCount = UTF8.GetCharCount(bytes, length);
					string text = new string('\0', charCount);
					fixed (char* chars = text)
					{
						UTF8.GetChars(bytes, length, chars, charCount);
					}
					return text;
				}
			}

			internal static int TryParseUInt32Varint(ref State state, int offset, bool trimNegative, out uint value, ReadOnlySpan<byte> span)
			{
				if ((uint)offset >= (uint)span.Length)
				{
					value = 0u;
					return 0;
				}
				value = span[offset++];
				if ((value & 0x80) == 0)
				{
					return 1;
				}
				value &= 127u;
				if ((uint)offset >= (uint)span.Length)
				{
					state.ThrowEoF();
				}
				uint num = span[offset++];
				value |= (num & 0x7F) << 7;
				if ((num & 0x80) == 0)
				{
					return 2;
				}
				if ((uint)offset >= (uint)span.Length)
				{
					state.ThrowEoF();
				}
				num = span[offset++];
				value |= (num & 0x7F) << 14;
				if ((num & 0x80) == 0)
				{
					return 3;
				}
				if ((uint)offset >= (uint)span.Length)
				{
					state.ThrowEoF();
				}
				num = span[offset++];
				value |= (num & 0x7F) << 21;
				if ((num & 0x80) == 0)
				{
					return 4;
				}
				if ((uint)offset >= (uint)span.Length)
				{
					state.ThrowEoF();
				}
				num = span[offset++];
				value |= num << 28;
				if ((num & 0xF0) == 0)
				{
					return 5;
				}
				if (trimNegative && (num & 0xF0) == 240 && offset + 4 < (uint)span.Length && span[offset] == byte.MaxValue && span[offset + 1] == byte.MaxValue && span[offset + 2] == byte.MaxValue && span[offset + 3] == byte.MaxValue && span[offset + 4] == 1)
				{
					return 10;
				}
				state.ThrowOverflow();
				return 0;
			}

			public override void Dispose()
			{
				base.Dispose();
				_source = default(ReadOnlySequence<byte>.Enumerator);
				Pool<ReadOnlySequenceProtoReader>.Put(this);
			}

			internal void Init(ReadOnlySequence<byte> source, TypeModel model, object userState)
			{
				Init(model, userState);
				_source = source.GetEnumerator();
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private int GetSomeData(ref State state, bool throwIfEOF = true)
			{
				int remainingInCurrent = state.RemainingInCurrent;
				if (remainingInCurrent != 0)
				{
					return remainingInCurrent;
				}
				return ReadNextBuffer(ref state, throwIfEOF);
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private int ReadNextBuffer(ref State state, bool throwIfEOF)
			{
				do
				{
					if (!_source.MoveNext())
					{
						if (throwIfEOF)
						{
							state.ThrowEoF();
						}
						return 0;
					}
					state.Init(_source.Current);
				}
				while (state.Span.IsEmpty);
				return state.Span.Length;
			}

			private protected override int ImplTryReadUInt64VarintWithoutMoving(ref State state, out ulong value)
			{
				if (state.RemainingInCurrent < 10)
				{
					return ViaStackAlloc(this, ref state, out value);
				}
				return State.TryParseUInt64Varint(state.Span, state.OffsetInCurrent, out value);
				static int ViaStackAlloc(ReadOnlySequenceProtoReader reader, ref State s, out ulong val)
				{
					Span<byte> span = stackalloc byte[10];
					Span<byte> destination = span;
					int num = 0;
					if (s.RemainingInCurrent != 0)
					{
						int num2 = Math.Min(s.RemainingInCurrent, destination.Length);
						Peek(ref s, num2).CopyTo(destination);
						destination = destination.Slice(num2);
						num += num2;
					}
					ReadOnlySequence<byte>.Enumerator source = reader._source;
					while (!destination.IsEmpty && source.MoveNext())
					{
						ReadOnlySpan<byte> span2 = source.Current.Span;
						int num3 = Math.Min(span2.Length, destination.Length);
						span2.Slice(0, num3).CopyTo(destination);
						destination = destination.Slice(num3);
						num += num3;
					}
					if (num != 10)
					{
						span = span.Slice(0, num);
					}
					return State.TryParseUInt64Varint(span, 0, out val);
				}
			}

			private protected override uint ImplReadUInt32Fixed(ref State state)
			{
				if (state.RemainingInCurrent < 4)
				{
					return ViaStackAlloc(ref state);
				}
				return BinaryPrimitives.ReadUInt32LittleEndian(Consume(ref state, 4));
				uint ViaStackAlloc(ref State st)
				{
					Span<byte> span = stackalloc byte[4];
					Span<byte> destination = span;
					while (!destination.IsEmpty)
					{
						int num = Math.Min(GetSomeData(ref st), destination.Length);
						Consume(ref st, num).CopyTo(destination);
						destination = destination.Slice(num);
					}
					return BinaryPrimitives.ReadUInt32LittleEndian(span);
				}
			}

			private protected override ulong ImplReadUInt64Fixed(ref State state)
			{
				if (state.RemainingInCurrent < 8)
				{
					return ViaStackAlloc(ref state);
				}
				return BinaryPrimitives.ReadUInt64LittleEndian(Consume(ref state, 8));
				ulong ViaStackAlloc(ref State st)
				{
					Span<byte> span = stackalloc byte[8];
					Span<byte> destination = span;
					while (!destination.IsEmpty)
					{
						int num = Math.Min(GetSomeData(ref st), destination.Length);
						Consume(ref st, num).CopyTo(destination);
						destination = destination.Slice(num);
					}
					return BinaryPrimitives.ReadUInt64LittleEndian(span);
				}
			}

			private protected override string ImplReadString(ref State state, int bytes)
			{
				if (state.RemainingInCurrent < bytes)
				{
					return ImplReadStringMultiSegment(ref state, bytes);
				}
				int offset;
				return ToString(Consume(ref state, bytes, out offset), offset, bytes);
			}

			private string ImplReadStringMultiSegment(ref State state, int bytes)
			{
				byte[] buffer = BufferPool.GetBuffer(bytes);
				try
				{
					Span<byte> span = new Span<byte>(buffer, 0, bytes);
					ImplReadBytes(ref state, span, bytes);
					return ToString(span);
				}
				finally
				{
					BufferPool.ReleaseBufferToPool(ref buffer);
				}
			}

			private void ImplReadBytes(ref State state, Span<byte> target, int bytesToRead)
			{
				if (state.RemainingInCurrent >= bytesToRead)
				{
					Consume(ref state, bytesToRead).CopyTo(target);
				}
				else
				{
					Looped(ref state, target);
				}
				void Looped(ref State st, Span<byte> ttarget)
				{
					int num;
					for (int i = 0; i < bytesToRead; i += num)
					{
						num = Math.Min(GetSomeData(ref st), bytesToRead - i);
						Consume(ref st, num).CopyTo(ttarget);
						ttarget = ttarget.Slice(num);
					}
				}
			}

			private protected override void ImplReadBytes(ref State state, Span<byte> target)
			{
				ImplReadBytes(ref state, target, target.Length);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private ReadOnlySpan<byte> Consume(ref State state, int bytes)
			{
				Advance(bytes);
				return state.Consume(bytes);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private ReadOnlySpan<byte> Consume(ref State state, int bytes, out int offset)
			{
				Advance(bytes);
				return state.Consume(bytes, out offset);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private static ReadOnlySpan<byte> Peek(ref State state, int bytes)
			{
				return state.Span.Slice(state.OffsetInCurrent, bytes);
			}

			private protected override int ImplTryReadUInt32VarintWithoutMoving(ref State state, Read32VarintMode mode, out uint value)
			{
				if (state.RemainingInCurrent < 10)
				{
					return ViaStackAlloc(ref state, mode, out value);
				}
				return TryParseUInt32Varint(ref state, state.OffsetInCurrent, mode == Read32VarintMode.Signed, out value, state.Span);
				unsafe int ViaStackAlloc(ref State s, Read32VarintMode m, out uint val)
				{
					byte* pointer = stackalloc byte[10];
					Span<byte> span = new Span<byte>(pointer, 10);
					Span<byte> destination = span;
					ReadOnlySpan<byte> readOnlySpan = Peek(ref s, Math.Min(destination.Length, s.RemainingInCurrent));
					readOnlySpan.CopyTo(destination);
					int num = readOnlySpan.Length;
					destination = destination.Slice(num);
					ReadOnlySequence<byte>.Enumerator source = _source;
					while (!destination.IsEmpty && source.MoveNext())
					{
						ReadOnlySpan<byte> span2 = source.Current.Span;
						int num2 = Math.Min(span2.Length, destination.Length);
						span2.Slice(0, num2).CopyTo(destination);
						destination = destination.Slice(num2);
						num += num2;
					}
					if (num != 10)
					{
						span = span.Slice(0, num);
					}
					return TryParseUInt32Varint(ref s, 0, m == Read32VarintMode.Signed, out val, span);
				}
			}

			private protected override void ImplSkipBytes(ref State state, long count)
			{
				if (state.RemainingInCurrent >= count)
				{
					Skip(ref state, (int)count);
				}
				else
				{
					Looped(ref state, count);
				}
				void Looped(ref State st, long ccount)
				{
					while (ccount != 0L)
					{
						int num = (int)Math.Min(GetSomeData(ref st), ccount);
						Skip(ref st, num);
						ccount -= num;
					}
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void Skip(ref State state, int bytes)
			{
				state.Skip(bytes);
				Advance(bytes);
			}

			private protected override bool IsFullyConsumed(ref State state)
			{
				return GetSomeData(ref state, throwIfEOF: false) == 0;
			}
		}

		[StructLayout(LayoutKind.Auto)]
		internal readonly struct SolidState : IDisposable
		{
			private readonly ReadOnlyMemory<byte> _memory;

			private readonly ProtoReader _reader;

			public void Dispose()
			{
				_reader?.Dispose();
			}

			internal SolidState(ProtoReader reader, ReadOnlyMemory<byte> memory)
			{
				_memory = memory;
				_reader = reader;
			}

			internal State Liquify()
			{
				return new State(_reader, _memory);
			}
		}

		private sealed class StreamProtoReader : ProtoReader
		{
			private Stream _source;

			private byte[] _ioBuffer;

			private bool _isFixedLength;

			private int _ioIndex;

			private int _available;

			private long _dataRemaining64;

			protected internal override State DefaultState()
			{
				return new State(this);
			}

			[Obsolete("Please use ProtoReader.Create; this API may be removed in a future version", false)]
			public StreamProtoReader(Stream source, TypeModel model, SerializationContext context, int length)
			{
				Init(source, model, context, length);
			}

			[Obsolete("Please use ProtoReader.Create; this API may be removed in a future version", false)]
			public StreamProtoReader(Stream source, TypeModel model, SerializationContext context, long length)
			{
				Init(source, model, context, length);
			}

			internal StreamProtoReader()
			{
			}

			[Obsolete("Please use ProtoReader.Create; this API may be removed in a future version", false)]
			public StreamProtoReader(Stream source, TypeModel model, SerializationContext context)
			{
				Init(source, model, context, -1L);
			}

			internal void Init(Stream source, TypeModel model, object userState, long length)
			{
				Init(model, userState);
				if (source == null)
				{
					ThrowHelper.ThrowArgumentNullException("source");
				}
				if (!source.CanRead)
				{
					ThrowHelper.ThrowArgumentException("Cannot read from stream", "source");
				}
				if (TryConsumeSegmentRespectingPosition(source, out var data, length))
				{
					_ioBuffer = data.Array;
					length = (_available = data.Count);
					_ioIndex = data.Offset;
				}
				else
				{
					_source = source;
					_ioBuffer = BufferPool.GetBuffer();
					_available = (_ioIndex = 0);
					_dataRemaining64 = ((_isFixedLength = length >= 0) ? length : 0);
				}
			}

			public override void Dispose()
			{
				base.Dispose();
				if (_source != null)
				{
					_source = null;
					BufferPool.ReleaseBufferToPool(ref _ioBuffer);
				}
				Pool<StreamProtoReader>.Put(this);
			}

			private protected override int ImplTryReadUInt32VarintWithoutMoving(ref State state, Read32VarintMode mode, out uint value)
			{
				if (_available < 10)
				{
					Ensure(ref state, 10, strict: false);
				}
				if (_available == 0)
				{
					value = 0u;
					return 0;
				}
				int ioIndex = _ioIndex;
				value = _ioBuffer[ioIndex++];
				if ((value & 0x80) == 0)
				{
					return 1;
				}
				value &= 127u;
				if (_available == 1)
				{
					state.ThrowEoF();
				}
				uint num = _ioBuffer[ioIndex++];
				value |= (num & 0x7F) << 7;
				if ((num & 0x80) == 0)
				{
					return 2;
				}
				if (_available == 2)
				{
					state.ThrowEoF();
				}
				num = _ioBuffer[ioIndex++];
				value |= (num & 0x7F) << 14;
				if ((num & 0x80) == 0)
				{
					return 3;
				}
				if (_available == 3)
				{
					state.ThrowEoF();
				}
				num = _ioBuffer[ioIndex++];
				value |= (num & 0x7F) << 21;
				if ((num & 0x80) == 0)
				{
					return 4;
				}
				if (_available == 4)
				{
					state.ThrowEoF();
				}
				num = _ioBuffer[ioIndex];
				value |= num << 28;
				if ((num & 0xF0) == 0)
				{
					return 5;
				}
				if (mode == Read32VarintMode.Signed && (num & 0xF0) == 240 && _available >= 10 && _ioBuffer[++ioIndex] == byte.MaxValue && _ioBuffer[++ioIndex] == byte.MaxValue && _ioBuffer[++ioIndex] == byte.MaxValue && _ioBuffer[++ioIndex] == byte.MaxValue && _ioBuffer[++ioIndex] == 1)
				{
					return 10;
				}
				state.ThrowOverflow();
				return 0;
			}

			private protected override ulong ImplReadUInt64Fixed(ref State state)
			{
				if (_available < 8)
				{
					Ensure(ref state, 8, strict: true);
				}
				Advance(8L);
				_available -= 8;
				ulong result = BinaryPrimitives.ReadUInt64LittleEndian(_ioBuffer.AsSpan(_ioIndex, 8));
				_ioIndex += 8;
				return result;
			}

			private protected override void ImplReadBytes(ref State state, Span<byte> target)
			{
				int num = target.Length;
				Advance(num);
				while (num > _available)
				{
					if (_available > 0)
					{
						new Span<byte>(_ioBuffer, _ioIndex, _available).CopyTo(target);
						num -= _available;
						target = target.Slice(_available);
						_ioIndex = (_available = 0);
					}
					int num2 = ((num > _ioBuffer.Length) ? _ioBuffer.Length : num);
					if (num2 > 0)
					{
						Ensure(ref state, num2, strict: true);
					}
				}
				if (num > 0)
				{
					new Span<byte>(_ioBuffer, _ioIndex, num).CopyTo(target);
					_available -= num;
					_ioIndex += num;
				}
			}

			private protected override int ImplTryReadUInt64VarintWithoutMoving(ref State state, out ulong value)
			{
				if (_available < 10)
				{
					Ensure(ref state, 10, strict: false);
				}
				if (_available == 0)
				{
					value = 0uL;
					return 0;
				}
				int ioIndex = _ioIndex;
				value = _ioBuffer[ioIndex++];
				if ((value & 0x80) == 0L)
				{
					return 1;
				}
				value &= 127uL;
				if (_available == 1)
				{
					state.ThrowEoF();
				}
				ulong num = _ioBuffer[ioIndex++];
				value |= (num & 0x7F) << 7;
				if ((num & 0x80) == 0L)
				{
					return 2;
				}
				if (_available == 2)
				{
					state.ThrowEoF();
				}
				num = _ioBuffer[ioIndex++];
				value |= (num & 0x7F) << 14;
				if ((num & 0x80) == 0L)
				{
					return 3;
				}
				if (_available == 3)
				{
					state.ThrowEoF();
				}
				num = _ioBuffer[ioIndex++];
				value |= (num & 0x7F) << 21;
				if ((num & 0x80) == 0L)
				{
					return 4;
				}
				if (_available == 4)
				{
					state.ThrowEoF();
				}
				num = _ioBuffer[ioIndex++];
				value |= (num & 0x7F) << 28;
				if ((num & 0x80) == 0L)
				{
					return 5;
				}
				if (_available == 5)
				{
					state.ThrowEoF();
				}
				num = _ioBuffer[ioIndex++];
				value |= (num & 0x7F) << 35;
				if ((num & 0x80) == 0L)
				{
					return 6;
				}
				if (_available == 6)
				{
					state.ThrowEoF();
				}
				num = _ioBuffer[ioIndex++];
				value |= (num & 0x7F) << 42;
				if ((num & 0x80) == 0L)
				{
					return 7;
				}
				if (_available == 7)
				{
					state.ThrowEoF();
				}
				num = _ioBuffer[ioIndex++];
				value |= (num & 0x7F) << 49;
				if ((num & 0x80) == 0L)
				{
					return 8;
				}
				if (_available == 8)
				{
					state.ThrowEoF();
				}
				num = _ioBuffer[ioIndex++];
				value |= (num & 0x7F) << 56;
				if ((num & 0x80) == 0L)
				{
					return 9;
				}
				if (_available == 9)
				{
					state.ThrowEoF();
				}
				num = _ioBuffer[ioIndex];
				value |= num << 63;
				if ((num & 0xFFFFFFFFFFFFFFFEuL) != 0L)
				{
					state.ThrowOverflow();
				}
				return 10;
			}

			private protected override string ImplReadString(ref State state, int bytes)
			{
				if (_available < bytes)
				{
					Ensure(ref state, bytes, strict: true);
				}
				string result = UTF8.GetString(_ioBuffer, _ioIndex, bytes);
				_available -= bytes;
				Advance(bytes);
				_ioIndex += bytes;
				return result;
			}

			private protected override bool IsFullyConsumed(ref State state)
			{
				return (_isFixedLength ? _dataRemaining64 : _available) == 0;
			}

			private protected override uint ImplReadUInt32Fixed(ref State state)
			{
				if (_available < 4)
				{
					Ensure(ref state, 4, strict: true);
				}
				Advance(4L);
				_available -= 4;
				uint result = BinaryPrimitives.ReadUInt32LittleEndian(_ioBuffer.AsSpan(_ioIndex, 4));
				_ioIndex += 4;
				return result;
			}

			private void Ensure(ref State state, int count, bool strict)
			{
				if (_source != null)
				{
					if (count > _ioBuffer.Length)
					{
						BufferPool.ResizeAndFlushLeft(ref _ioBuffer, count, _ioIndex, _available);
						_ioIndex = 0;
					}
					else if (_ioIndex + count >= _ioBuffer.Length)
					{
						Buffer.BlockCopy(_ioBuffer, _ioIndex, _ioBuffer, 0, _available);
						_ioIndex = 0;
					}
					count -= _available;
					int num = _ioIndex + _available;
					int num2 = _ioBuffer.Length - num;
					if (_isFixedLength && _dataRemaining64 < num2)
					{
						num2 = (int)_dataRemaining64;
					}
					int num3;
					while (count > 0 && num2 > 0 && (num3 = _source.Read(_ioBuffer, num, num2)) > 0)
					{
						_available += num3;
						count -= num3;
						num2 -= num3;
						num += num3;
						if (_isFixedLength)
						{
							_dataRemaining64 -= num3;
						}
					}
				}
				if (strict && count > 0)
				{
					state.ThrowEoF();
				}
			}

			private protected override void ImplSkipBytes(ref State state, long count)
			{
				if (_available < count && count < 128)
				{
					Ensure(ref state, (int)count, strict: true);
				}
				if (count <= _available)
				{
					_available -= (int)count;
					_ioIndex += (int)count;
					Advance(count);
					return;
				}
				Advance(count);
				count -= _available;
				_ioIndex = (_available = 0);
				if (_isFixedLength)
				{
					if (count > _dataRemaining64)
					{
						state.ThrowEoF();
					}
					_dataRemaining64 -= count;
				}
				if (_source == null)
				{
					state.ThrowEoF();
				}
				Seek(_source, count, _ioBuffer);
			}
		}

		internal const string PreferStateAPI = "If possible, please use the State API; a transitionary implementation is provided, but this API may be removed in a future version";

		internal const string PreferReadMessage = "If possible, please use the ReadMessage API; this API may not work correctly with all readers";

		private TypeModel _model;

		private int _fieldNumber;

		private int _depth;

		private long blockEnd64;

		private readonly NetObjectCache netCache = new NetObjectCache();

		internal const long TO_EOF = -1L;

		private long _longPosition;

		private Dictionary<string, string> stringInterner;

		private protected static readonly UTF8Encoding UTF8 = new UTF8Encoding();

		internal static readonly byte[] EmptyBlob = Array.Empty<byte>();

		internal const MethodImplOptions HotPath = MethodImplOptions.AggressiveInlining;

		private static readonly FieldInfo s_origin = typeof(MemoryStream).GetField("_origin", BindingFlags.Instance | BindingFlags.NonPublic);

		private static readonly FieldInfo s_buffer = typeof(MemoryStream).GetField("_buffer", BindingFlags.Instance | BindingFlags.NonPublic);

		public int FieldNumber
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return _fieldNumber;
			}
		}

		public WireType WireType
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get;
			private protected set; }

		public bool InternStrings { get; set; }

		public object UserState { get; private set; }

		[Obsolete("Prefer UserState")]
		public SerializationContext Context => SerializationContext.AsSerializationContext(this);

		public int Position
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return checked((int)_longPosition);
			}
		}

		public long LongPosition
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return _longPosition;
			}
		}

		public TypeModel Model
		{
			get
			{
				return _model;
			}
			internal set
			{
				_model = value;
			}
		}

		private protected abstract int ImplTryReadUInt64VarintWithoutMoving(ref State state, out ulong value);

		private protected abstract uint ImplReadUInt32Fixed(ref State state);

		private protected abstract ulong ImplReadUInt64Fixed(ref State state);

		private protected abstract string ImplReadString(ref State state, int bytes);

		private protected abstract void ImplSkipBytes(ref State state, long count);

		private protected abstract int ImplTryReadUInt32VarintWithoutMoving(ref State state, Read32VarintMode mode, out uint value);

		private protected abstract void ImplReadBytes(ref State state, Span<byte> target);

		private protected virtual void ImplReadBytes(ref State state, ReadOnlySequence<byte> target)
		{
			Memory<byte> memory;
			if (target.IsSingleSegment)
			{
				memory = MemoryMarshal.AsMemory(target.First);
				ImplReadBytes(ref state, memory.Span);
				return;
			}
			ReadOnlySequence<byte>.Enumerator enumerator = target.GetEnumerator();
			while (enumerator.MoveNext())
			{
				ReadOnlyMemory<byte> current = enumerator.Current;
				memory = MemoryMarshal.AsMemory(current);
				ImplReadBytes(ref state, memory.Span);
			}
		}

		private protected abstract bool IsFullyConsumed(ref State state);

		private protected ProtoReader()
		{
		}

		internal void Init(TypeModel model, object userState)
		{
			_model = model;
			if (userState is SerializationContext serializationContext)
			{
				serializationContext.Freeze();
			}
			UserState = userState;
			_longPosition = 0L;
			_depth = (_fieldNumber = 0);
			blockEnd64 = long.MaxValue;
			InternStrings = model.HasOption(TypeModel.TypeModelOptions.InternStrings);
			WireType = WireType.None;
		}

		public virtual void Dispose()
		{
			_model = null;
			if (stringInterner != null)
			{
				stringInterner.Clear();
				stringInterner = null;
			}
			netCache.Clear();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void Advance(long count)
		{
			_longPosition += count;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public short ReadInt16()
		{
			return DefaultState().ReadInt16();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ushort ReadUInt16()
		{
			return DefaultState().ReadUInt16();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public byte ReadByte()
		{
			return DefaultState().ReadByte();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public sbyte ReadSByte()
		{
			return DefaultState().ReadSByte();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public uint ReadUInt32()
		{
			return DefaultState().ReadUInt32();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int ReadInt32()
		{
			return DefaultState().ReadInt32();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public long ReadInt64()
		{
			return DefaultState().ReadInt64();
		}

		private protected string Intern(string value)
		{
			if (value == null)
			{
				return null;
			}
			if (value.Length == 0)
			{
				return "";
			}
			string value2;
			if (stringInterner == null)
			{
				stringInterner = new Dictionary<string, string>(StringComparer.Ordinal) { { value, value } };
			}
			else if (stringInterner.TryGetValue(value, out value2))
			{
				value = value2;
			}
			else
			{
				stringInterner.Add(value, value);
			}
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ReadString()
		{
			return DefaultState().ReadString();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void ThrowEnumException(Type type, int value)
		{
			DefaultState().ThrowEnumException(type, value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double ReadDouble()
		{
			return DefaultState().ReadDouble();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static object ReadObject(object value, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type, ProtoReader reader)
		{
			return reader.DefaultState().ReadObject(value, type);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void EndSubItem(SubItemToken token, ProtoReader reader)
		{
			reader.DefaultState().EndSubItem(token);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SubItemToken StartSubItem(ProtoReader reader)
		{
			return reader.DefaultState().StartSubItem();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int ReadFieldHeader()
		{
			return DefaultState().ReadFieldHeader();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private int SetTag(uint tag)
		{
			if ((_fieldNumber = (int)(tag >> 3)) < 1)
			{
				ThrowInvalidField(_fieldNumber);
			}
			WireType wireType = (WireType = (WireType)(tag & 7));
			if (wireType == WireType.EndGroup)
			{
				if (_depth > 0)
				{
					return 0;
				}
				ThrowUnexpectedEndGroup();
			}
			return _fieldNumber;
		}

		private static void ThrowInvalidField(int fieldNumber)
		{
			ThrowHelper.ThrowProtoException("Invalid field in source data: " + fieldNumber);
		}

		private static void ThrowUnexpectedEndGroup()
		{
			ThrowHelper.ThrowProtoException("Unexpected end-group in source data; this usually means the source data is corrupt");
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool TryReadFieldHeader(int field)
		{
			return DefaultState().TryReadFieldHeader(field);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Hint(WireType wireType)
		{
			if (WireType != wireType && (wireType & (WireType)7) == WireType)
			{
				WireType = wireType;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Assert(WireType wireType)
		{
			DefaultState().Assert(wireType);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void SkipField()
		{
			DefaultState().SkipField();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public ulong ReadUInt64()
		{
			return DefaultState().ReadUInt64();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public float ReadSingle()
		{
			return DefaultState().ReadSingle();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool ReadBoolean()
		{
			return DefaultState().ReadBoolean();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static byte[] AppendBytes(byte[] value, ProtoReader reader)
		{
			return reader.DefaultState().AppendBytes(value);
		}

		private static int ReadByteOrThrow(Stream source)
		{
			int num = source.ReadByte();
			if (num < 0)
			{
				ThrowEoF();
			}
			return num;
		}

		public static int ReadLengthPrefix(Stream source, bool expectHeader, PrefixStyle style, out int fieldNumber)
		{
			int bytesRead;
			return ReadLengthPrefix(source, expectHeader, style, out fieldNumber, out bytesRead);
		}

		public static int DirectReadLittleEndianInt32(Stream source)
		{
			return ReadByteOrThrow(source) | (ReadByteOrThrow(source) << 8) | (ReadByteOrThrow(source) << 16) | (ReadByteOrThrow(source) << 24);
		}

		public static int DirectReadBigEndianInt32(Stream source)
		{
			return (ReadByteOrThrow(source) << 24) | (ReadByteOrThrow(source) << 16) | (ReadByteOrThrow(source) << 8) | ReadByteOrThrow(source);
		}

		public static int DirectReadVarintInt32(Stream source)
		{
			ulong value;
			int num = TryReadUInt64Varint(source, out value);
			if (num <= 0)
			{
				ThrowEoF();
			}
			return checked((int)value);
		}

		public static void DirectReadBytes(Stream source, byte[] buffer, int offset, int count)
		{
			if (source == null)
			{
				ThrowHelper.ThrowArgumentNullException("source");
			}
			int num;
			while (count > 0 && (num = source.Read(buffer, offset, count)) > 0)
			{
				count -= num;
				offset += num;
			}
			if (count > 0)
			{
				ThrowEoF();
			}
		}

		public static byte[] DirectReadBytes(Stream source, int count)
		{
			byte[] array = new byte[count];
			DirectReadBytes(source, array, 0, count);
			return array;
		}

		public static string DirectReadString(Stream source, int length)
		{
			byte[] array = new byte[length];
			DirectReadBytes(source, array, 0, length);
			return ProtoWriter.UTF8.GetString(array, 0, length);
		}

		public static int ReadLengthPrefix(Stream source, bool expectHeader, PrefixStyle style, out int fieldNumber, out int bytesRead)
		{
			if (style == PrefixStyle.None)
			{
				bytesRead = (fieldNumber = 0);
				return int.MaxValue;
			}
			long num = ReadLongLengthPrefix(source, expectHeader, style, out fieldNumber, out bytesRead);
			return checked((int)num);
		}

		public static long ReadLongLengthPrefix(Stream source, bool expectHeader, PrefixStyle style, out int fieldNumber, out int bytesRead)
		{
			fieldNumber = 0;
			switch (style)
			{
			case PrefixStyle.None:
				bytesRead = 0;
				return long.MaxValue;
			case PrefixStyle.Base128:
			{
				bytesRead = 0;
				ulong value;
				int num2;
				if (expectHeader)
				{
					num2 = TryReadUInt64Varint(source, out value);
					bytesRead += num2;
					if (num2 > 0)
					{
						if ((value & 7) != 2)
						{
							ThrowHelper.ThrowInvalidOperationException($"Unexpected wire-type: {(WireType)(value & 7)}, expected {WireType.String})");
						}
						fieldNumber = (int)(value >> 3);
						num2 = TryReadUInt64Varint(source, out value);
						bytesRead += num2;
						if (bytesRead == 0)
						{
							ThrowEoF();
						}
						return (long)value;
					}
					bytesRead = 0;
					return -1L;
				}
				num2 = TryReadUInt64Varint(source, out value);
				bytesRead += num2;
				if (bytesRead >= 0)
				{
					return (long)value;
				}
				return -1L;
			}
			case PrefixStyle.Fixed32:
			{
				int num3 = source.ReadByte();
				if (num3 < 0)
				{
					bytesRead = 0;
					return -1L;
				}
				bytesRead = 4;
				return num3 | (ReadByteOrThrow(source) << 8) | (ReadByteOrThrow(source) << 16) | (ReadByteOrThrow(source) << 24);
			}
			case PrefixStyle.Fixed32BigEndian:
			{
				int num = source.ReadByte();
				if (num < 0)
				{
					bytesRead = 0;
					return -1L;
				}
				bytesRead = 4;
				return (num << 24) | (ReadByteOrThrow(source) << 16) | (ReadByteOrThrow(source) << 8) | ReadByteOrThrow(source);
			}
			default:
				ThrowHelper.ThrowArgumentOutOfRangeException("style");
				bytesRead = 0;
				return 0L;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void ThrowEoF()
		{
			default(State).ThrowEoF();
		}

		private static int TryReadUInt64Varint(Stream source, out ulong value)
		{
			value = 0uL;
			int num = source.ReadByte();
			if (num < 0)
			{
				return 0;
			}
			value = (uint)num;
			if ((value & 0x80) == 0L)
			{
				return 1;
			}
			value &= 127uL;
			int num2 = 1;
			int num3 = 7;
			while (num2 < 9)
			{
				num = source.ReadByte();
				if (num < 0)
				{
					ThrowEoF();
				}
				value |= ((ulong)num & 0x7FuL) << num3;
				num3 += 7;
				num2++;
				if ((num & 0x80) == 0)
				{
					return num2;
				}
			}
			num = source.ReadByte();
			if (num < 0)
			{
				ThrowEoF();
			}
			if ((num & 1) == 0)
			{
				value |= ((ulong)num & 0x7FuL) << num3;
				return ++num2;
			}
			ThrowHelper.ThrowOverflowException();
			return 0;
		}

		internal static void Seek(Stream source, long count, byte[] buffer)
		{
			if (source.CanSeek)
			{
				source.Seek(count, SeekOrigin.Current);
				count = 0L;
			}
			else if (buffer != null)
			{
				int num;
				while (count > buffer.Length && (num = source.Read(buffer, 0, buffer.Length)) > 0)
				{
					count -= num;
				}
				while (count > 0 && (num = source.Read(buffer, 0, (int)count)) > 0)
				{
					count -= num;
				}
			}
			else
			{
				buffer = BufferPool.GetBuffer();
				try
				{
					int num2;
					while (count > buffer.Length && (num2 = source.Read(buffer, 0, buffer.Length)) > 0)
					{
						count -= num2;
					}
					while (count > 0 && (num2 = source.Read(buffer, 0, (int)count)) > 0)
					{
						count -= num2;
					}
				}
				finally
				{
					BufferPool.ReleaseBufferToPool(ref buffer);
				}
			}
			if (count > 0)
			{
				ThrowEoF();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void AppendExtensionData(IExtensible instance)
		{
			DefaultState().AppendExtensionData(instance);
		}

		public static bool HasSubValue(WireType wireType, ProtoReader source)
		{
			if (source == null)
			{
				ThrowHelper.ThrowArgumentNullException("source");
			}
			if (source.blockEnd64 <= source._longPosition || wireType == WireType.EndGroup)
			{
				return false;
			}
			source.WireType = wireType;
			return true;
		}

		internal Type DeserializeType(string value)
		{
			return TypeModel.DeserializeType(_model, value);
		}

		public Type ReadType()
		{
			return DefaultState().ReadType();
		}

		public static object Merge(ProtoReader parent, object from, object to)
		{
			if (parent == null)
			{
				ThrowHelper.ThrowArgumentNullException("parent");
			}
			TypeModel model = parent.Model;
			object userState = parent.UserState;
			if (model == null)
			{
				ThrowHelper.ThrowInvalidOperationException("Types cannot be merged unless a type-model has been specified");
			}
			using MemoryStream memoryStream = new MemoryStream();
			ProtoWriter.State state = ProtoWriter.State.Create(memoryStream, model, userState);
			try
			{
				model.SerializeRootFallback(ref state, from);
			}
			finally
			{
				state.Dispose();
			}
			memoryStream.Position = 0L;
			using State state2 = State.Create(memoryStream, model, userState, -1L);
			return state2.DeserializeRootFallback(to, null);
		}

		protected internal abstract State DefaultState();

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void NoContextThrowEoF()
		{
			default(State).ThrowEoF();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static void NoContextThrowOverflow()
		{
			default(State).ThrowOverflow();
		}

		[Obsolete("If possible, please use the State API; a transitionary implementation is provided, but this API may be removed in a future version", false)]
		public static ProtoReader Create(Stream source, TypeModel model, SerializationContext context = null, long length = -1L)
		{
			return Create(source, model, (object)context, length);
		}

		internal static ProtoReader Create(Stream source, TypeModel model, object userState, long length)
		{
			StreamProtoReader streamProtoReader = Pool<StreamProtoReader>.TryGet() ?? new StreamProtoReader();
			streamProtoReader.Init(source, model ?? TypeModel.DefaultModel, userState, length);
			return streamProtoReader;
		}

		private static bool ReflectionTryGetBuffer(MemoryStream ms, out ArraySegment<byte> buffer)
		{
			if ((object)s_origin != null && (object)s_buffer != null)
			{
				try
				{
					int offset = (int)s_origin.GetValue(ms);
					byte[] array = (byte[])s_buffer.GetValue(ms);
					buffer = new ArraySegment<byte>(array, offset, checked((int)ms.Length));
					return true;
				}
				catch
				{
				}
			}
			buffer = default(ArraySegment<byte>);
			return false;
		}

		internal static bool TryConsumeSegmentRespectingPosition(Stream source, out ArraySegment<byte> data, long length)
		{
			if (source is MemoryStream memoryStream && memoryStream.CanSeek && (memoryStream.TryGetBuffer(out var buffer) || ReflectionTryGetBuffer(memoryStream, out buffer)))
			{
				int num = checked((int)memoryStream.Position);
				int num2 = buffer.Count - num;
				int offset = buffer.Offset + num;
				if (length >= 0 && length < num2)
				{
					num2 = (int)length;
				}
				data = new ArraySegment<byte>(buffer.Array, offset, num2);
				memoryStream.Seek(num2, SeekOrigin.Current);
				return true;
			}
			data = default(ArraySegment<byte>);
			return false;
		}
	}
}
