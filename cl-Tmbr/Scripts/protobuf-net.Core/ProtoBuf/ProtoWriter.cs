using System;
using System.Buffers;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using ProtoBuf.Internal;
using ProtoBuf.Meta;
using ProtoBuf.Serializers;

namespace ProtoBuf
{
	public abstract class ProtoWriter : IDisposable, ISerializationContext
	{
		[StructLayout(LayoutKind.Auto)]
		public ref struct State
		{
			private Span<byte> _span;

			private Memory<byte> _memory;

			private ProtoWriter _writer;

			internal readonly bool IsActive => !_span.IsEmpty;

			internal readonly Span<byte> Remaining
			{
				[MethodImpl(MethodImplOptions.AggressiveInlining)]
				get
				{
					return _span.Slice(OffsetInCurrent);
				}
			}

			internal int RemainingInCurrent { get; private set; }

			internal int OffsetInCurrent { get; private set; }

			internal readonly TypeModel Model => _writer?.Model;

			internal readonly WireType WireType
			{
				get
				{
					return _writer.WireType;
				}
				set
				{
					_writer.WireType = value;
				}
			}

			internal readonly int Depth => _writer.Depth;

			internal readonly int FieldNumber
			{
				get
				{
					return _writer.fieldNumber;
				}
				private set
				{
					_writer.fieldNumber = value;
				}
			}

			public readonly ISerializationContext Context => _writer;

			public static State Create(IBufferWriter<byte> writer, TypeModel model, object userState = null)
			{
				return BufferWriterProtoWriter.CreateBufferWriterProtoWriter(writer, model, userState);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal State(ProtoWriter writer)
			{
				this = default(State);
				_writer = writer;
			}

			internal void Init(Memory<byte> memory)
			{
				_memory = memory;
				_span = memory.Span;
				RemainingInCurrent = _span.Length;
			}

			public void Flush()
			{
				if (_writer.TryFlush(ref this))
				{
					_writer._needFlush = false;
				}
			}

			internal int ConsiderWritten()
			{
				int offsetInCurrent = OffsetInCurrent;
				ProtoWriter writer = _writer;
				this = default(State);
				_writer = writer;
				return offsetInCurrent;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void LocalWriteFixed32(uint value)
			{
				BinaryPrimitives.WriteUInt32LittleEndian(Remaining, value);
				OffsetInCurrent += 4;
				RemainingInCurrent -= 4;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal readonly void ReverseLast32()
			{
				_span.Slice(OffsetInCurrent - 4, 4).Reverse();
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void LocalAdvance(int bytes)
			{
				OffsetInCurrent += bytes;
				RemainingInCurrent -= bytes;
			}

			internal void LocalWriteBytes(ReadOnlySpan<byte> span)
			{
				span.CopyTo(Remaining);
				OffsetInCurrent += span.Length;
				RemainingInCurrent -= span.Length;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal void LocalWriteFixed64(ulong value)
			{
				BinaryPrimitives.WriteUInt64LittleEndian(Remaining, value);
				OffsetInCurrent += 8;
				RemainingInCurrent -= 8;
			}

			internal void LocalWriteString(string value)
			{
				int bytes = UTF8.GetBytes(value.AsSpan(), Remaining);
				OffsetInCurrent += bytes;
				RemainingInCurrent -= bytes;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal int LocalWriteVarint64(ulong value)
			{
				int num = WriteVarint64(value, _span, OffsetInCurrent);
				OffsetInCurrent += num;
				RemainingInCurrent -= num;
				return num;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal static int WriteVarint64(ulong value, Span<byte> span, int offset = 0)
			{
				int num = 0;
				do
				{
					span[offset++] = (byte)((value & 0x7F) | 0x80);
					num++;
				}
				while ((value >>= 7) != 0L);
				span[offset - 1] &= 127;
				return num;
			}

			internal int ReadFrom(Stream source)
			{
				ArraySegment<byte> segment;
				int num = ((!MemoryMarshal.TryGetArray((ReadOnlyMemory<byte>)_memory, out segment)) ? source.Read(Remaining) : source.Read(segment.Array, segment.Offset + OffsetInCurrent, RemainingInCurrent));
				if (num > 0)
				{
					OffsetInCurrent += num;
					RemainingInCurrent -= num;
				}
				return num;
			}

			internal int LocalWriteVarint32(uint value)
			{
				int num = 0;
				Span<byte> span = _span;
				int offsetInCurrent = OffsetInCurrent;
				do
				{
					span[offsetInCurrent++] = (byte)((value & 0x7F) | 0x80);
					num++;
				}
				while ((value >>= 7) != 0);
				span[offsetInCurrent - 1] &= 127;
				OffsetInCurrent += num;
				RemainingInCurrent -= num;
				return num;
			}

			public void WriteString(int fieldNumber, string value, StringMap map = null)
			{
				if (value != null)
				{
					WriteFieldHeader(fieldNumber, WireType.String);
					WriteStringWithLengthPrefix(value, map);
				}
			}

			private void WriteStringWithLengthPrefix(string value, StringMap map)
			{
				ProtoWriter writer = _writer;
				if (string.IsNullOrEmpty(value))
				{
					writer.AdvanceAndReset(writer.ImplWriteVarint32(ref this, 0u));
					return;
				}
				int byteCount = UTF8.GetByteCount(value);
				writer.AdvanceAndReset(writer.ImplWriteVarint32(ref this, (uint)byteCount) + byteCount);
				writer.ImplWriteString(ref this, value, byteCount);
			}

			public void WriteString(string value, StringMap map = null)
			{
				WireType wireType = _writer.WireType;
				if (wireType == WireType.String)
				{
					WriteStringWithLengthPrefix(value, map);
				}
				else
				{
					ThrowInvalidSerializationOperation();
				}
			}

			public void WriteType(Type value)
			{
				WriteString(_writer.SerializeType(value));
			}

			public void WriteFieldHeader(int fieldNumber, WireType wireType)
			{
				ProtoWriter writer = _writer;
				if (writer.WireType != WireType.None)
				{
					FailPendingField(writer, fieldNumber, wireType);
				}
				if (fieldNumber < 0)
				{
					ThrowHelper.ThrowArgumentOutOfRangeException("fieldNumber");
				}
				writer._needFlush = true;
				if (writer.packedFieldNumber == 0)
				{
					writer.fieldNumber = fieldNumber;
					writer.WireType = wireType;
					WriteHeaderCore(fieldNumber, wireType);
				}
				else
				{
					WritePackedField(writer, fieldNumber, wireType);
				}
				static void FailPendingField(ProtoWriter protoWriter, int num, WireType wireType2)
				{
					ThrowHelper.ThrowInvalidOperationException($"Cannot write a {wireType2}/{num} header until the {protoWriter.WireType}/{protoWriter.fieldNumber} data has been written; writer: {protoWriter}");
				}
				static void WritePackedField(ProtoWriter protoWriter, int num, WireType wireType2)
				{
					if (protoWriter.packedFieldNumber == num)
					{
						if ((uint)wireType2 > 1u && wireType2 != WireType.Fixed32 && wireType2 != WireType.SignedVariant)
						{
							ThrowHelper.ThrowInvalidOperationException("Wire-type cannot be encoded as packed: " + wireType2);
						}
						protoWriter.fieldNumber = num;
						protoWriter.WireType = wireType2;
					}
					else
					{
						ThrowHelper.ThrowInvalidOperationException("Field mismatch during packed encoding; expected " + protoWriter.packedFieldNumber + " but received " + num);
					}
				}
			}

			public void WriteInt32Varint(int fieldNumber, int value)
			{
				WriteFieldHeader(fieldNumber, WireType.Variant);
				WriteInt32VarintImpl(value);
			}

			private void WriteInt32VarintImpl(int value)
			{
				ProtoWriter writer = _writer;
				if (value >= 0)
				{
					writer.AdvanceAndReset(writer.ImplWriteVarint32(ref this, (uint)value));
				}
				else
				{
					writer.AdvanceAndReset(writer.ImplWriteVarint64(ref this, (ulong)value));
				}
			}

			public void WriteInt32(int value)
			{
				ProtoWriter writer = _writer;
				switch (writer.WireType)
				{
				case WireType.Fixed32:
					writer.ImplWriteFixed32(ref this, (uint)value);
					writer.AdvanceAndReset(4);
					break;
				case WireType.Fixed64:
					writer.ImplWriteFixed64(ref this, (ulong)value);
					writer.AdvanceAndReset(8);
					break;
				case WireType.Variant:
					WriteInt32VarintImpl(value);
					break;
				case WireType.SignedVariant:
					writer.AdvanceAndReset(writer.ImplWriteVarint32(ref this, Zig(value)));
					break;
				default:
					ThrowInvalidSerializationOperation();
					break;
				}
			}

			public void WriteSByte(sbyte value)
			{
				WriteInt32(value);
			}

			public void WriteInt16(short value)
			{
				WriteInt32(value);
			}

			public void WriteUInt16(ushort value)
			{
				WriteUInt32(value);
			}

			public void WriteByte(byte value)
			{
				WriteUInt32(value);
			}

			public void WriteBoolean(bool value)
			{
				WriteUInt32(value ? 1u : 0u);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void WriteIntPtr(IntPtr value)
			{
				WriteInt64(value.ToInt64());
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void WriteUIntPtr(UIntPtr value)
			{
				WriteUInt64(value.ToUInt64());
			}

			public void WriteUInt32(uint value)
			{
				ProtoWriter writer = _writer;
				switch (writer.WireType)
				{
				case WireType.Fixed32:
					writer.ImplWriteFixed32(ref this, value);
					writer.AdvanceAndReset(4);
					break;
				case WireType.Fixed64:
					writer.ImplWriteFixed64(ref this, value);
					writer.AdvanceAndReset(8);
					break;
				case WireType.Variant:
				{
					int count = writer.ImplWriteVarint32(ref this, value);
					writer.AdvanceAndReset(count);
					break;
				}
				default:
					ThrowInvalidSerializationOperation();
					break;
				}
			}

			public unsafe void WriteDouble(double value)
			{
				ProtoWriter writer = _writer;
				switch (writer.WireType)
				{
				case WireType.Fixed32:
				{
					float num = (float)value;
					if (float.IsInfinity(num) && !double.IsInfinity(value))
					{
						ThrowHelper.ThrowOverflowException();
					}
					WriteSingle(num);
					break;
				}
				case WireType.Fixed64:
					writer.ImplWriteFixed64(ref this, *(ulong*)(&value));
					writer.AdvanceAndReset(8);
					break;
				default:
					ThrowInvalidSerializationOperation();
					break;
				}
			}

			public unsafe void WriteSingle(float value)
			{
				ProtoWriter writer = _writer;
				switch (writer.WireType)
				{
				case WireType.Fixed32:
					writer.ImplWriteFixed32(ref this, *(uint*)(&value));
					writer.AdvanceAndReset(4);
					break;
				case WireType.Fixed64:
					WriteDouble(value);
					break;
				default:
					ThrowInvalidSerializationOperation();
					break;
				}
			}

			public void WriteInt64(long value)
			{
				ProtoWriter writer = _writer;
				switch (writer.WireType)
				{
				case WireType.Fixed64:
					writer.ImplWriteFixed64(ref this, (ulong)value);
					writer.AdvanceAndReset(8);
					break;
				case WireType.Variant:
					writer.AdvanceAndReset(writer.ImplWriteVarint64(ref this, (ulong)value));
					break;
				case WireType.SignedVariant:
					writer.AdvanceAndReset(writer.ImplWriteVarint64(ref this, Zig(value)));
					break;
				case WireType.Fixed32:
					writer.ImplWriteFixed32(ref this, checked((uint)(int)value));
					writer.AdvanceAndReset(4);
					break;
				default:
					ThrowInvalidSerializationOperation();
					break;
				}
			}

			public void WriteUInt64(ulong value)
			{
				ProtoWriter writer = _writer;
				switch (writer.WireType)
				{
				case WireType.Fixed64:
					writer.ImplWriteFixed64(ref this, value);
					writer.AdvanceAndReset(8);
					break;
				case WireType.Variant:
				{
					int count = writer.ImplWriteVarint64(ref this, value);
					writer.AdvanceAndReset(count);
					break;
				}
				case WireType.Fixed32:
					writer.ImplWriteFixed32(ref this, checked((uint)value));
					writer.AdvanceAndReset(4);
					break;
				default:
					ThrowInvalidSerializationOperation();
					break;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void WriteMessage<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(SerializerFeatures features, T value, ISerializer<T> serializer = null)
			{
				_writer.WriteMessage(ref this, value, serializer, PrefixStyle.Base128, features.ApplyRecursionCheck());
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void WriteMessage<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(int fieldNumber, SerializerFeatures features, T value, ISerializer<T> serializer = null)
			{
				if (!TypeHelper<T>.CanBeNull || !TypeHelper<T>.ValueChecker.IsNull(value))
				{
					WriteFieldHeader(fieldNumber, features.IsGroup() ? WireType.StartGroup : WireType.String);
					_writer.WriteMessage(ref this, value, serializer, PrefixStyle.Base128, features.ApplyRecursionCheck());
				}
			}

			public void WriteGroup<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(int fieldNumber, SerializerFeatures features, T value, ISerializer<T> serializer = null)
			{
				if (!TypeHelper<T>.CanBeNull || !TypeHelper<T>.ValueChecker.IsNull(value))
				{
					WriteFieldHeader(fieldNumber, WireType.StartGroup);
					_writer.WriteMessage(ref this, value, serializer, PrefixStyle.Base128, features.ApplyRecursionCheck());
				}
			}

			public void WriteAny<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(int fieldNumber, T value, ISerializer<T> serializer = null)
			{
				if (serializer == null)
				{
					serializer = TypeModel.GetSerializer<T>(Model);
				}
				WriteAny(fieldNumber, serializer.Features, value, serializer);
			}

			internal static WireType AssertWrappedAndGetWireType(ref SerializerFeatures features, out bool fieldPresence)
			{
				if (features.IsRepeated())
				{
					fieldPresence = false;
					return AssertWrappedAndGetWireType(ref features, SerializerFeatures.OptionWrappedCollection, SerializerFeatures.OptionWrappedCollectionGroup);
				}
				fieldPresence = features.HasAny(SerializerFeatures.OptionWrappedValueFieldPresence);
				return AssertWrappedAndGetWireType(ref features, SerializerFeatures.OptionWrappedValue, SerializerFeatures.OptionWrappedValueGroup);
				static WireType AssertWrappedAndGetWireType(ref SerializerFeatures reference, SerializerFeatures demanded, SerializerFeatures group)
				{
					if (!reference.HasAny(demanded))
					{
						ThrowHelper.ThrowInvalidOperationException(string.Format("{0} called for {1}, but {2} was not specified", "WriteWrapped", reference.GetCategory(), demanded));
					}
					reference &= ~demanded;
					if (!reference.HasAny(group))
					{
						return WireType.String;
					}
					return WireType.StartGroup;
				}
			}

			public void WriteWrapped<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(int fieldNumber, SerializerFeatures features, T value, ISerializer<T> serializer = null)
			{
				if (serializer == null)
				{
					serializer = TypeModel.GetSerializer<T>(Model);
				}
				features.InheritFrom(serializer.Features);
				bool fieldPresence;
				WireType wireType = AssertWrappedAndGetWireType(ref features, out fieldPresence);
				bool flag = TypeHelper<T>.CanBeNull && TypeHelper<T>.ValueChecker.IsNull(value);
				if (!(!fieldPresence && flag))
				{
					WriteFieldHeader(fieldNumber, wireType);
					if (!flag && (fieldPresence || TypeHelper<T>.ValueChecker.HasNonTrivialValue(value)))
					{
						GetWriter().WriteWrappedItem(ref this, features, value, serializer);
					}
					else
					{
						GetWriter().WriteEmptyWrappedItem(ref this);
					}
				}
			}

			public void WriteAny<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(int fieldNumber, SerializerFeatures features, T value, ISerializer<T> serializer = null)
			{
				if (serializer == null)
				{
					serializer = TypeModel.GetSerializer<T>(Model);
				}
				features.InheritFrom(serializer.Features);
				if (features.HasAny(SerializerFeatures.OptionWrappedValue))
				{
					WriteWrapped(fieldNumber, features, value, serializer);
				}
				else if (!TypeHelper<T>.CanBeNull || !TypeHelper<T>.ValueChecker.IsNull(value))
				{
					switch (features.GetCategory())
					{
					case SerializerFeatures.CategoryRepeated:
						((IRepeatedSerializer<T>)serializer).WriteRepeated(ref this, fieldNumber, features, value);
						break;
					case SerializerFeatures.CategoryMessage:
					case SerializerFeatures.CategoryMessageWrappedAtRoot:
						WriteFieldHeader(fieldNumber, features.GetWireType());
						_writer.WriteMessage(ref this, value, serializer, PrefixStyle.Base128, features.ApplyRecursionCheck());
						break;
					case SerializerFeatures.CategoryScalar:
						WriteFieldHeader(fieldNumber, features.GetWireType());
						serializer.Write(ref this, value);
						break;
					default:
						features.ThrowInvalidCategory();
						break;
					}
				}
			}

			public void WriteSubType<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(T value, ISubTypeSerializer<T> serializer = null) where T : class
			{
				_writer.WriteSubType(ref this, value, serializer ?? TypeModel.GetSubTypeSerializer<T>(Model));
			}

			public void WriteSubType<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(int fieldNumber, T value, ISubTypeSerializer<T> serializer = null) where T : class
			{
				WriteFieldHeader(fieldNumber, WireType.String);
				_writer.WriteSubType(ref this, value, serializer ?? TypeModel.GetSubTypeSerializer<T>(Model));
			}

			public void WriteBaseType<T>([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T value, ISubTypeSerializer<T> serializer = null) where T : class
			{
				(serializer ?? TypeModel.GetSubTypeSerializer<T>(Model)).WriteSubType(ref this, value);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public ISerializer<T> GetSerializer<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>()
			{
				return TypeModel.GetSerializer<T>(Model);
			}

			internal readonly long GetPosition()
			{
				return _writer._position64;
			}

			internal readonly ProtoWriter GetWriter()
			{
				return _writer;
			}

			public void WriteBytes(ReadOnlySequence<byte> data)
			{
				ProtoWriter writer = _writer;
				int num = checked((int)data.Length);
				switch (writer.WireType)
				{
				case WireType.Fixed32:
					if (num != 4)
					{
						ThrowHelper.ThrowArgumentException("length");
					}
					writer.ImplWriteBytes(ref this, data);
					writer.AdvanceAndReset(4);
					break;
				case WireType.Fixed64:
					if (num != 8)
					{
						ThrowHelper.ThrowArgumentException("length");
					}
					writer.ImplWriteBytes(ref this, data);
					writer.AdvanceAndReset(8);
					break;
				case WireType.String:
					writer.AdvanceAndReset(writer.ImplWriteVarint32(ref this, (uint)num) + num);
					if (num != 0)
					{
						writer.ImplWriteBytes(ref this, data);
					}
					break;
				default:
					ThrowInvalidSerializationOperation();
					break;
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void WriteBytes(ArraySegment<byte> data)
			{
				WriteBytes(new ReadOnlyMemory<byte>(data.Array, data.Offset, data.Count));
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void WriteBytes(byte[] data)
			{
				WriteBytes(new ReadOnlyMemory<byte>(data));
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void WriteBytes<TStorage>(TStorage value, IMemoryConverter<TStorage, byte> converter = null)
			{
				WriteBytes((ReadOnlyMemory<byte>)(converter ?? DefaultMemoryConverter<byte>.GetFor<TStorage>(Model)).GetMemory(in value));
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public void WriteBytes(Memory<byte> data)
			{
				WriteBytes(data.Span);
			}

			public void WriteBytes(ReadOnlyMemory<byte> data)
			{
				WriteBytes(data.Span);
			}

			public void WriteBytes(ReadOnlySpan<byte> data)
			{
				ProtoWriter writer = _writer;
				int length = data.Length;
				switch (writer.WireType)
				{
				case WireType.Fixed32:
					if (length != 4)
					{
						ThrowHelper.ThrowArgumentException("length");
					}
					writer.ImplWriteBytes(ref this, data);
					writer.AdvanceAndReset(4);
					break;
				case WireType.Fixed64:
					if (length != 8)
					{
						ThrowHelper.ThrowArgumentException("length");
					}
					writer.ImplWriteBytes(ref this, data);
					writer.AdvanceAndReset(8);
					break;
				case WireType.String:
					writer.AdvanceAndReset(writer.ImplWriteVarint32(ref this, (uint)length) + length);
					if (length != 0)
					{
						writer.ImplWriteBytes(ref this, data);
					}
					break;
				default:
					ThrowInvalidSerializationOperation();
					break;
				}
			}

			public long SerializeRoot<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(T value, ISerializer<T> serializer = null)
			{
				try
				{
					CheckClear();
					if (serializer == null)
					{
						serializer = TypeModel.GetSerializer<T>(Model);
					}
					long position = GetPosition();
					WriteAsRoot(value, serializer);
					CheckClear();
					long position2 = GetPosition();
					return position2 - position;
				}
				catch
				{
					Abandon();
					throw;
				}
			}

			internal void WriteAsRoot<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(T value, ISerializer<T> serializer)
			{
				SerializerFeatures serializerFeatures = serializer.Features;
				SerializerFeatures category = serializerFeatures.GetCategory();
				if (category == SerializerFeatures.CategoryMessageWrappedAtRoot)
				{
					WriteMessage(1, SerializerFeatures.CategoryRepeated, value, serializer);
				}
				else
				{
					if (TypeHelper<T>.CanBeNull && TypeHelper<T>.ValueChecker.IsNull(value))
					{
						return;
					}
					switch (category)
					{
					case SerializerFeatures.CategoryScalar:
						WriteFieldHeader(1, serializerFeatures.GetWireType());
						serializer.Write(ref this, value);
						break;
					case SerializerFeatures.CategoryMessage:
						serializer.Write(ref this, value);
						break;
					case SerializerFeatures.CategoryRepeated:
						if (Model.OmitsOption(TypeModel.TypeModelOptions.AllowPackedEncodingAtRoot))
						{
							serializerFeatures |= SerializerFeatures.OptionPackedDisabled;
						}
						((IRepeatedSerializer<T>)serializer).WriteRepeated(ref this, 1, serializerFeatures, value);
						break;
					default:
						serializerFeatures.ThrowInvalidCategory();
						break;
					}
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public readonly void Abandon()
			{
				_writer?.Abandon();
			}

			private void CheckClear()
			{
				_writer?.CheckClear(ref this);
			}

			internal void WritePackedPrefix(int elementCount, WireType wireType)
			{
				if (WireType != WireType.String)
				{
					ThrowHelper.ThrowInvalidOperationException("Invalid wire-type: " + WireType);
				}
				if (elementCount < 0)
				{
					ThrowHelper.ThrowArgumentOutOfRangeException("elementCount");
				}
				ulong value;
				switch (wireType)
				{
				case WireType.Fixed32:
					value = (ulong)((long)elementCount << 2);
					break;
				case WireType.Fixed64:
					value = (ulong)((long)elementCount << 3);
					break;
				default:
					ThrowHelper.ThrowArgumentOutOfRangeException("wireType", "Invalid wire-type: " + wireType);
					value = 0uL;
					break;
				}
				int count = _writer.ImplWriteVarint64(ref this, value);
				_writer.AdvanceAndReset(count);
			}

			internal void WriteObject(object value, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] Type type, PrefixStyle style, int fieldNumber)
			{
				TypeModel model = Model;
				if (model == null)
				{
					ThrowHelper.ThrowInvalidOperationException("Cannot serialize sub-objects unless a model is provided");
				}
				if ((object)type == null)
				{
					type = value.GetType();
				}
				if (WireType != WireType.None)
				{
					ThrowInvalidSerializationOperation();
				}
				switch (style)
				{
				case PrefixStyle.Base128:
					WireType = WireType.String;
					FieldNumber = fieldNumber;
					if (fieldNumber > 0)
					{
						WriteHeaderCore(fieldNumber, WireType.String);
					}
					break;
				case PrefixStyle.Fixed32:
				case PrefixStyle.Fixed32BigEndian:
					FieldNumber = 0;
					WireType = WireType.Fixed32;
					break;
				default:
					ThrowHelper.ThrowArgumentOutOfRangeException("style");
					break;
				}
				SubItemToken token = StartSubItem(value, style);
				if (!DynamicStub.TrySerializeAny(1, SerializerFeatures.CategoryMessageWrappedAtRoot, type, Model, ref this, value))
				{
					TypeModel.ThrowUnexpectedType(value.GetType(), Model);
				}
				EndSubItem(token, style);
			}

			internal void WriteHeaderCore(int fieldNumber, WireType wireType)
			{
				uint value = (uint)(fieldNumber << 3) | (uint)(wireType & (WireType)7);
				int num = _writer.ImplWriteVarint32(ref this, value);
				_writer.Advance(num);
			}

			[Obsolete("If possible, please use the WriteMessage API; this API may not work correctly with all writers", false)]
			public SubItemToken StartSubItem(object instance)
			{
				return StartSubItem(instance, PrefixStyle.Base128);
			}

			public void Dispose()
			{
				ProtoWriter writer = _writer;
				this = default(State);
				writer?.Dispose();
			}

			[Obsolete("If possible, please use the WriteMessage API; this API may not work correctly with all writers", false)]
			internal SubItemToken StartSubItem(object instance, PrefixStyle style)
			{
				_writer.PreSubItem(ref this, instance);
				switch (WireType)
				{
				case WireType.StartGroup:
					WireType = WireType.None;
					return new SubItemToken(-FieldNumber);
				case WireType.Fixed32:
					if ((uint)(style - 2) > 1u)
					{
						ThrowInvalidSerializationOperation();
						return default(SubItemToken);
					}
					goto case WireType.String;
				case WireType.String:
					return _writer.ImplStartLengthPrefixedSubItem(ref this, instance, style);
				default:
					ThrowInvalidSerializationOperation();
					return default(SubItemToken);
				}
			}

			[Obsolete("If possible, please use the WriteMessage API; this API may not work correctly with all writers", false)]
			internal void EndSubItem(SubItemToken token, PrefixStyle style)
			{
				_writer.PostSubItem(ref this);
				int num = (int)token.value64;
				if (num < 0)
				{
					WriteHeaderCore(-num, WireType.EndGroup);
					WireType = WireType.None;
				}
				else
				{
					_writer.ImplEndLengthPrefixedSubItem(ref this, token, style);
				}
			}

			public void Close()
			{
				CheckClear();
				_writer?.Cleanup();
			}

			[Obsolete("If possible, please use the WriteMessage API; this API may not work correctly with all writers", false)]
			public void EndSubItem(SubItemToken token)
			{
				EndSubItem(token, PrefixStyle.Base128);
			}

			public void AppendExtensionData(IExtensible instance)
			{
				if (instance == null)
				{
					ThrowHelper.ThrowArgumentNullException("instance");
				}
				if (WireType != WireType.None)
				{
					ThrowInvalidSerializationOperation();
				}
				AppendExtensionDataImpl(instance.GetExtensionObject(createIfMissing: false));
			}

			private void AppendExtensionDataImpl(IExtension extn)
			{
				if (extn == null)
				{
					return;
				}
				Stream stream = extn.BeginQuery();
				try
				{
					if (ProtoReader.TryConsumeSegmentRespectingPosition(stream, out var data, -1L))
					{
						_writer.ImplWriteBytes(ref this, new ReadOnlySpan<byte>(data.Array, data.Offset, data.Count));
						_writer.Advance(data.Count);
					}
					else
					{
						_writer.ImplCopyRawFromStream(ref this, stream);
					}
				}
				finally
				{
					extn.EndQuery(stream);
				}
			}

			public void AppendExtensionData(ITypedExtensible instance, Type type)
			{
				if (instance == null)
				{
					ThrowHelper.ThrowArgumentNullException("instance");
				}
				if (WireType != WireType.None)
				{
					ThrowInvalidSerializationOperation();
				}
				AppendExtensionDataImpl(instance.GetExtensionObject(type, createIfMissing: false));
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal void ThrowInvalidSerializationOperation()
			{
				if (_writer == null)
				{
					ThrowHelper.ThrowProtoException("No underlying writer");
				}
				ThrowHelper.ThrowProtoException($"Invalid serialization operation with wire-type {WireType} at position {GetPosition()}, depth {Depth}");
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal readonly void ThrowTooDeep(int depth)
			{
				ThrowHelper.ThrowInvalidOperationException("Maximum model depth exceeded (see TypeModel.MaxDepth): " + depth);
			}

			public readonly void SetPackedField(int fieldNumber)
			{
				if (fieldNumber <= 0)
				{
					ThrowHelper.ThrowArgumentOutOfRangeException("fieldNumber");
				}
				_writer.packedFieldNumber = fieldNumber;
			}

			public readonly void ClearPackedField(int fieldNumber)
			{
				if (fieldNumber != _writer.packedFieldNumber)
				{
					ThrowWrongPackedField(fieldNumber, _writer);
				}
				_writer.packedFieldNumber = 0;
				static void ThrowWrongPackedField(int num, ProtoWriter writer)
				{
					ThrowHelper.ThrowInvalidOperationException("Field mismatch during packed encoding; expected " + writer.packedFieldNumber + " but received " + num);
				}
			}

			public void ThrowEnumException(object enumValue)
			{
				string arg = ((enumValue == null) ? "<null>" : (enumValue.GetType().FullName + "." + enumValue.ToString()));
				ThrowHelper.ThrowProtoException($"No wire-value is mapped to the enum {arg} at position {GetPosition()}");
			}

			public static State Create(Stream dest, TypeModel model, object userState = null)
			{
				StreamProtoWriter writer = StreamProtoWriter.CreateStreamProtoWriter(dest, model, userState);
				return new State(writer);
			}
		}

		private sealed class BufferWriterProtoWriter : ProtoWriter
		{
			private IBufferWriter<byte> _writer;

			private readonly NullProtoWriter _nullWriter;

			private protected override bool ImplDemandFlushOnDispose => true;

			internal static State CreateBufferWriterProtoWriter(IBufferWriter<byte> writer, TypeModel model, object userState)
			{
				if (writer == null)
				{
					ThrowHelper.ThrowArgumentNullException("writer");
				}
				BufferWriterProtoWriter bufferWriterProtoWriter = Pool<BufferWriterProtoWriter>.TryGet() ?? new BufferWriterProtoWriter();
				bufferWriterProtoWriter.Init(model, userState, impactCount: true);
				bufferWriterProtoWriter._writer = writer;
				return new State(bufferWriterProtoWriter);
			}

			internal override void Init(TypeModel model, object userState, bool impactCount)
			{
				base.Init(model, userState, impactCount);
				_nullWriter.Init(model, userState, impactCount: false);
			}

			private BufferWriterProtoWriter()
			{
				_nullWriter = new NullProtoWriter(netCache);
			}

			private protected override void ClearKnownObjects()
			{
			}

			internal override void Dispose()
			{
				base.Dispose();
				Pool<BufferWriterProtoWriter>.Put(this);
			}

			private protected override void Cleanup()
			{
				base.Cleanup();
				_nullWriter.Cleanup();
				_writer = null;
			}

			protected internal override State DefaultState()
			{
				ThrowHelper.ThrowInvalidOperationException("You must retain and pass the state from ProtoWriter.CreateForBufferWriter");
				return default(State);
			}

			private protected override bool TryFlush(ref State state)
			{
				if (state.IsActive)
				{
					int num = 0;
					try
					{
						num = state.ConsiderWritten();
						_writer.Advance(num);
					}
					catch (Exception ex)
					{
						ex.Data?.Add("ProtoBuf.Position", _position64);
						ex.Data?.Add("ProtoBuf.Flushing", num);
						throw;
					}
				}
				return true;
			}

			private protected override void ImplWriteFixed32(ref State state, uint value)
			{
				if (state.RemainingInCurrent < 4)
				{
					GetBuffer(ref state);
				}
				state.LocalWriteFixed32(value);
			}

			private protected override void ImplWriteFixed64(ref State state, ulong value)
			{
				if (state.RemainingInCurrent < 8)
				{
					GetBuffer(ref state);
				}
				state.LocalWriteFixed64(value);
			}

			private protected override void ImplWriteString(ref State state, string value, int expectedBytes)
			{
				if (expectedBytes <= state.RemainingInCurrent)
				{
					state.LocalWriteString(value);
				}
				else
				{
					FallbackWriteString(ref state, value, expectedBytes);
				}
			}

			private void FallbackWriteString(ref State state, string value, int expectedBytes)
			{
				GetBuffer(ref state);
				if (expectedBytes <= state.RemainingInCurrent)
				{
					state.LocalWriteString(value);
					return;
				}
				byte[] array = ArrayPool<byte>.Shared.Rent(expectedBytes);
				try
				{
					UTF8.GetBytes(value, 0, value.Length, array, 0);
					FallbackWriteBytes(ref state, new ReadOnlySpan<byte>(array, 0, expectedBytes));
				}
				finally
				{
					ArrayPool<byte>.Shared.Return(array);
				}
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private void GetBuffer(ref State state)
			{
				TryFlush(ref state);
				state.Init(_writer.GetMemory((model == null) ? 1024 : model.BufferSize));
			}

			private protected override void ImplWriteBytes(ref State state, ReadOnlySpan<byte> bytes)
			{
				if (bytes.Length <= state.RemainingInCurrent)
				{
					state.LocalWriteBytes(bytes);
				}
				else
				{
					FallbackWriteBytes(ref state, bytes);
				}
			}

			private protected override void ImplWriteBytes(ref State state, ReadOnlySequence<byte> data)
			{
				if (data.IsSingleSegment)
				{
					ReadOnlySpan<byte> span = data.First.Span;
					if (span.Length <= state.RemainingInCurrent)
					{
						state.LocalWriteBytes(span);
					}
					else
					{
						FallbackWriteBytes(ref state, span);
					}
					return;
				}
				ReadOnlySequence<byte>.Enumerator enumerator = data.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ReadOnlySpan<byte> span2 = enumerator.Current.Span;
					if (span2.Length <= state.RemainingInCurrent)
					{
						state.LocalWriteBytes(span2);
					}
					else
					{
						FallbackWriteBytes(ref state, span2);
					}
				}
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			private void FallbackWriteBytes(ref State state, ReadOnlySpan<byte> span)
			{
				while (true)
				{
					GetBuffer(ref state);
					int remainingInCurrent = state.RemainingInCurrent;
					if (span.Length <= remainingInCurrent)
					{
						break;
					}
					state.LocalWriteBytes(span.Slice(0, remainingInCurrent));
					span = span.Slice(remainingInCurrent);
				}
				state.LocalWriteBytes(span);
			}

			private protected override int ImplWriteVarint32(ref State state, uint value)
			{
				if (state.RemainingInCurrent < 5)
				{
					GetBuffer(ref state);
				}
				return state.LocalWriteVarint32(value);
			}

			internal override int ImplWriteVarint64(ref State state, ulong value)
			{
				if (state.RemainingInCurrent < 10)
				{
					GetBuffer(ref state);
				}
				return state.LocalWriteVarint64(value);
			}

			protected internal override void WriteMessage<T>(ref State state, T value, ISerializer<T> serializer, PrefixStyle style, bool recursionCheck)
			{
				switch (base.WireType)
				{
				case WireType.String:
				case WireType.Fixed32:
					PreSubItem(ref state, (TypeHelper<T>.IsReferenceType && recursionCheck) ? ((object)value) : null);
					WriteWithLengthPrefix(ref state, value, serializer, style);
					PostSubItem(ref state);
					break;
				default:
					base.WriteMessage(ref state, value, serializer, style, recursionCheck);
					break;
				}
			}

			internal override void WriteWrappedItem<T>(ref State state, SerializerFeatures features, T value, ISerializer<T> serializer)
			{
				switch (base.WireType)
				{
				case WireType.String:
				{
					if (serializer == null)
					{
						serializer = TypeModel.GetSerializer<T>(base.Model);
					}
					long num = MeasureAny(_nullWriter, 1, features, value, serializer);
					AdvanceAndReset(ImplWriteVarint64(ref state, (ulong)num));
					if (num != 0L)
					{
						long position = GetPosition(ref state);
						state.WriteAny(1, features, value, serializer);
						long position2 = GetPosition(ref state);
						long num2 = position2 - position;
						if (num2 != num)
						{
							ThrowHelper.ThrowInvalidOperationException($"Length mismatch; calculated '{num}', actual '{num2}'");
						}
					}
					break;
				}
				case WireType.StartGroup:
					base.WriteWrappedItem(ref state, features, value, serializer);
					break;
				default:
					ThrowHelper.ThrowArgumentOutOfRangeException("WireType");
					break;
				}
			}

			internal override void WriteWrappedCollection<TCollection, TItem>(ref State state, SerializerFeatures features, TCollection values, RepeatedSerializer<TCollection, TItem> serializer, ISerializer<TItem> valueSerializer)
			{
				switch (base.WireType)
				{
				case WireType.String:
				{
					if (valueSerializer == null)
					{
						valueSerializer = TypeModel.GetSerializer<TItem>(base.Model);
					}
					long num = MeasureRepeated(_nullWriter, 1, features, values, serializer, valueSerializer);
					AdvanceAndReset(ImplWriteVarint64(ref state, (ulong)num));
					if (num != 0L)
					{
						long position = GetPosition(ref state);
						serializer.WriteRepeated(ref state, 1, features, values, valueSerializer);
						long position2 = GetPosition(ref state);
						long num2 = position2 - position;
						if (num2 != num)
						{
							ThrowHelper.ThrowInvalidOperationException($"Length mismatch; calculated '{num}', actual '{num2}'");
						}
					}
					break;
				}
				case WireType.StartGroup:
					base.WriteWrappedCollection(ref state, features, values, serializer, valueSerializer);
					break;
				default:
					ThrowHelper.ThrowArgumentOutOfRangeException("WireType");
					break;
				}
			}

			internal override void WriteWrappedMap<TCollection, TKey, TValue>(ref State state, SerializerFeatures features, TCollection values, MapSerializer<TCollection, TKey, TValue> serializer, SerializerFeatures keyFeatures, SerializerFeatures valueFeatures, ISerializer<TKey> keySerializer, ISerializer<TValue> valueSerializer)
			{
				switch (base.WireType)
				{
				case WireType.String:
				{
					long num = MeasureMap(_nullWriter, 1, features, values, serializer, keyFeatures, valueFeatures, keySerializer, valueSerializer);
					AdvanceAndReset(ImplWriteVarint64(ref state, (ulong)num));
					if (num != 0L)
					{
						long position = GetPosition(ref state);
						serializer.WriteMap(ref state, 1, features, values, keyFeatures, valueFeatures, keySerializer, valueSerializer);
						long position2 = GetPosition(ref state);
						long num2 = position2 - position;
						if (num2 != num)
						{
							ThrowHelper.ThrowInvalidOperationException($"Length mismatch; calculated '{num}', actual '{num2}'");
						}
					}
					break;
				}
				case WireType.StartGroup:
					base.WriteWrappedMap(ref state, features, values, serializer, keyFeatures, valueFeatures, keySerializer, valueSerializer);
					break;
				default:
					ThrowHelper.ThrowArgumentOutOfRangeException("WireType");
					break;
				}
			}

			protected internal override void WriteSubType<T>(ref State state, T value, ISubTypeSerializer<T> serializer)
			{
				switch (base.WireType)
				{
				case WireType.String:
				case WireType.Fixed32:
					WriteWithLengthPrefix(ref state, value, serializer);
					break;
				default:
					base.WriteSubType(ref state, value, serializer);
					break;
				}
			}

			private void WriteWithLengthPrefix<T>(ref State state, T value, ISerializer<T> serializer, PrefixStyle style)
			{
				if (serializer == null)
				{
					serializer = TypeModel.GetSerializer<T>(base.Model);
				}
				long num = Measure(_nullWriter, value, serializer);
				switch (style)
				{
				case PrefixStyle.Base128:
					AdvanceAndReset(ImplWriteVarint64(ref state, (ulong)num));
					break;
				case PrefixStyle.Fixed32:
				case PrefixStyle.Fixed32BigEndian:
					ImplWriteFixed32(ref state, checked((uint)num));
					if (style == PrefixStyle.Fixed32BigEndian)
					{
						state.ReverseLast32();
					}
					AdvanceAndReset(4);
					break;
				default:
					ThrowHelper.ThrowNotImplementedException($"Sub-object prefix style not implemented: {style}");
					break;
				case PrefixStyle.None:
					break;
				}
				if (num != 0L)
				{
					long position = GetPosition(ref state);
					serializer.Write(ref state, value);
					long position2 = GetPosition(ref state);
					long num2 = position2 - position;
					if (num2 != num)
					{
						ThrowHelper.ThrowInvalidOperationException($"Length mismatch; calculated '{num}', actual '{num2}'");
					}
				}
			}

			private void WriteWithLengthPrefix<T>(ref State state, T value, ISubTypeSerializer<T> serializer) where T : class
			{
				if (serializer == null)
				{
					serializer = TypeModel.GetSubTypeSerializer<T>(base.Model);
				}
				long num = Measure(_nullWriter, value, serializer);
				AdvanceAndReset(ImplWriteVarint64(ref state, (ulong)num));
				long position = GetPosition(ref state);
				serializer.WriteSubType(ref state, value);
				long position2 = GetPosition(ref state);
				long num2 = position2 - position;
				if (num2 != num)
				{
					ThrowHelper.ThrowInvalidOperationException($"Length mismatch; calculated '{num}', actual '{num2}'");
				}
			}

			private protected override void ImplEndLengthPrefixedSubItem(ref State state, SubItemToken token, PrefixStyle style)
			{
				ThrowHelper.ThrowNotSupportedException("You must use the WriteMessage API with this writer type");
			}

			private protected override SubItemToken ImplStartLengthPrefixedSubItem(ref State state, object instance, PrefixStyle style)
			{
				ThrowHelper.ThrowNotSupportedException("You must use the WriteMessage API with this writer type");
				return default(SubItemToken);
			}

			private protected override void ImplCopyRawFromStream(ref State state, Stream source)
			{
				while (true)
				{
					if (state.RemainingInCurrent == 0)
					{
						GetBuffer(ref state);
					}
					int num = state.ReadFrom(source);
					if (num > 0)
					{
						Advance(num);
						continue;
					}
					break;
				}
			}
		}

		[StructLayout(LayoutKind.Auto)]
		internal readonly struct WriteState
		{
			internal readonly long Position;

			internal readonly WireType WireType;

			internal readonly int FieldNumber;

			internal WriteState(long position, int fieldNumber, WireType wireType)
			{
				Position = position;
				FieldNumber = fieldNumber;
				WireType = wireType;
			}
		}

		internal sealed class NullProtoWriter : ProtoWriter
		{
			private long _abortAfter;

			private protected override bool ImplDemandFlushOnDispose => false;

			protected internal override State DefaultState()
			{
				return new State(this);
			}

			internal static State CreateNullProtoWriter(TypeModel model, object userState, long abortAfter)
			{
				NullProtoWriter nullProtoWriter = Pool<NullProtoWriter>.TryGet() ?? new NullProtoWriter();
				nullProtoWriter.Init(model, userState, impactCount: true);
				nullProtoWriter._abortAfter = ((abortAfter < 0) ? long.MaxValue : abortAfter);
				return new State(nullProtoWriter);
			}

			private NullProtoWriter()
			{
			}

			internal NullProtoWriter(NetObjectCache knownObjects)
				: base(knownObjects)
			{
				_abortAfter = long.MaxValue;
			}

			internal override void Dispose()
			{
				base.Dispose();
				Pool<NullProtoWriter>.Put(this);
			}

			private protected override void ImplCopyRawFromStream(ref State state, Stream source)
			{
				byte[] array = ArrayPool<byte>.Shared.Rent(8192);
				try
				{
					while (true)
					{
						int num = source.Read(array, 0, array.Length);
						if (num <= 0)
						{
							break;
						}
						Advance(num);
						CheckOversized(ref state);
					}
				}
				finally
				{
					ArrayPool<byte>.Shared.Return(array);
				}
			}

			[MethodImpl(MethodImplOptions.NoInlining)]
			internal static void CheckOversized(long max, long actual)
			{
				if (max >= 0 && actual > max)
				{
					ThrowHelper.ThrowProtoException($"Length {actual} exceeds constrained size of {max} bytes");
				}
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void CheckOversized(ref State state)
			{
				long position = state.GetPosition();
				if (position > _abortAfter)
				{
					CheckOversized(_abortAfter, position);
				}
			}

			protected internal override void WriteMessage<T>(ref State state, T value, ISerializer<T> serializer, PrefixStyle style, bool recursionCheck)
			{
				long length = Measure(this, value, serializer ?? TypeModel.GetSerializer<T>(base.Model));
				AdvanceSubMessage(ref state, length, style);
			}

			internal override void WriteWrappedItem<T>(ref State state, SerializerFeatures features, T value, ISerializer<T> serializer)
			{
				long length = MeasureAny(this, 1, features, value, serializer ?? TypeModel.GetSerializer<T>(base.Model));
				AdvanceSubMessage(ref state, length, PrefixStyle.Base128);
			}

			internal override void WriteWrappedCollection<TCollection, TItem>(ref State state, SerializerFeatures features, TCollection values, RepeatedSerializer<TCollection, TItem> serializer, ISerializer<TItem> valueSerializer)
			{
				long length = MeasureRepeated(this, 1, features, values, serializer, valueSerializer ?? TypeModel.GetSerializer<TItem>(base.Model));
				AdvanceSubMessage(ref state, length, PrefixStyle.Base128);
			}

			internal override void WriteWrappedMap<TCollection, TKey, TValue>(ref State state, SerializerFeatures features, TCollection values, MapSerializer<TCollection, TKey, TValue> serializer, SerializerFeatures keyFeatures, SerializerFeatures valueFeatures, ISerializer<TKey> keySerializer, ISerializer<TValue> valueSerializer)
			{
				long length = MeasureMap(this, 1, features, values, serializer, keyFeatures, valueFeatures, keySerializer, valueSerializer);
				AdvanceSubMessage(ref state, length, PrefixStyle.Base128);
			}

			private void AdvanceSubMessage(ref State state, long length, PrefixStyle style)
			{
				long num;
				switch (base.WireType)
				{
				case WireType.String:
				case WireType.Fixed32:
					switch (style)
					{
					case PrefixStyle.None:
						num = 0L;
						break;
					case PrefixStyle.Fixed32:
					case PrefixStyle.Fixed32BigEndian:
						num = 4L;
						break;
					case PrefixStyle.Base128:
						num = ImplWriteVarint64(ref state, (ulong)length);
						break;
					default:
						state.ThrowInvalidSerializationOperation();
						num = 0L;
						break;
					}
					break;
				case WireType.StartGroup:
					num = ImplWriteVarint32(ref state, (uint)(fieldNumber << 3));
					break;
				default:
					state.ThrowInvalidSerializationOperation();
					num = 0L;
					break;
				}
				Advance(num + length);
				CheckOversized(ref state);
				base.WireType = WireType.None;
			}

			protected internal override void WriteSubType<T>(ref State state, T value, ISubTypeSerializer<T> serializer)
			{
				if (serializer == null)
				{
					serializer = TypeModel.GetSubTypeSerializer<T>(base.Model);
				}
				long length = Measure(this, value, serializer);
				AdvanceSubMessage(ref state, length, PrefixStyle.Base128);
			}

			private protected override SubItemToken ImplStartLengthPrefixedSubItem(ref State state, object instance, PrefixStyle style)
			{
				base.WireType = WireType.None;
				return new SubItemToken(_position64);
			}

			private protected override void ImplEndLengthPrefixedSubItem(ref State state, SubItemToken token, PrefixStyle style)
			{
				long value = _position64 - token.value64;
				int num;
				switch (style)
				{
				case PrefixStyle.Fixed32:
				case PrefixStyle.Fixed32BigEndian:
					num = 4;
					break;
				case PrefixStyle.Base128:
					num = ImplWriteVarint64(ref state, (ulong)value);
					break;
				default:
					state.ThrowInvalidSerializationOperation();
					goto case PrefixStyle.None;
				case PrefixStyle.None:
					num = 0;
					break;
				}
				Advance(num);
				CheckOversized(ref state);
			}

			private protected override void ImplWriteBytes(ref State state, ReadOnlySpan<byte> data)
			{
			}

			private protected override void ImplWriteBytes(ref State state, ReadOnlySequence<byte> data)
			{
			}

			private protected override void ImplWriteFixed32(ref State state, uint value)
			{
			}

			private protected override void ImplWriteFixed64(ref State state, ulong value)
			{
			}

			private protected override void ImplWriteString(ref State state, string value, int expectedBytes)
			{
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private protected override int ImplWriteVarint32(ref State state, uint value)
			{
				return MeasureUInt32(value);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			internal override int ImplWriteVarint64(ref State state, ulong value)
			{
				return MeasureUInt64(value);
			}

			private protected override bool TryFlush(ref State state)
			{
				return true;
			}
		}

		private class StreamProtoWriter : ProtoWriter
		{
			private Stream dest;

			private int flushLock;

			private byte[] ioBuffer;

			private int ioIndex;

			private protected override bool ImplDemandFlushOnDispose => true;

			protected internal override State DefaultState()
			{
				return new State(this);
			}

			private StreamProtoWriter()
			{
			}

			internal static StreamProtoWriter CreateStreamProtoWriter(Stream dest, TypeModel model, object userState)
			{
				StreamProtoWriter streamProtoWriter = Pool<StreamProtoWriter>.TryGet() ?? new StreamProtoWriter();
				streamProtoWriter.Init(model, userState, impactCount: true);
				if (dest == null)
				{
					ThrowHelper.ThrowArgumentNullException("dest");
				}
				if (!dest.CanWrite)
				{
					ThrowHelper.ThrowArgumentException("Cannot write to stream", "dest");
				}
				streamProtoWriter.dest = dest;
				streamProtoWriter.ioBuffer = BufferPool.GetBuffer();
				return streamProtoWriter;
			}

			internal override void Init(TypeModel model, object userState, bool impactCount)
			{
				base.Init(model, userState, impactCount);
				ioIndex = 0;
				flushLock = 0;
			}

			internal override void Dispose()
			{
				base.Dispose();
				Pool<StreamProtoWriter>.Put(this);
			}

			private protected override void Cleanup()
			{
				base.Cleanup();
				dest = null;
				BufferPool.ReleaseBufferToPool(ref ioBuffer);
			}

			private static void IncrementedAndReset(int length, StreamProtoWriter writer)
			{
				writer.ioIndex += length;
				writer.Advance(length);
				writer.WireType = WireType.None;
			}

			private protected override bool TryFlush(ref State state)
			{
				if (flushLock != 0)
				{
					return false;
				}
				if (ioIndex != 0 && dest != null)
				{
					dest.Write(ioBuffer, 0, ioIndex);
					ioIndex = 0;
				}
				return true;
			}

			private static void DemandSpace(int required, StreamProtoWriter writer, ref State state)
			{
				if (writer.ioBuffer.Length - writer.ioIndex < required)
				{
					TryFlushOrResize(required, writer, ref state);
				}
			}

			private static void TryFlushOrResize(int required, StreamProtoWriter writer, ref State state)
			{
				if (!writer.TryFlush(ref state) || writer.ioBuffer.Length - writer.ioIndex < required)
				{
					BufferPool.ResizeAndFlushLeft(ref writer.ioBuffer, required + writer.ioIndex, 0, writer.ioIndex);
				}
			}

			private protected override void ImplWriteBytes(ref State state, ReadOnlySpan<byte> bytes)
			{
				int length = bytes.Length;
				if (flushLock != 0 || length <= ioBuffer.Length)
				{
					DemandSpace(length, this, ref state);
					bytes.CopyTo(new Span<byte>(ioBuffer, ioIndex, length));
					ioIndex += length;
				}
				else
				{
					state.Flush();
					dest.Write(bytes);
				}
			}

			private protected override void ImplWriteBytes(ref State state, ReadOnlySequence<byte> data)
			{
				int num = checked((int)data.Length);
				if (num == 0)
				{
					return;
				}
				if (flushLock != 0 || num <= ioBuffer.Length)
				{
					DemandSpace(num, this, ref state);
					data.CopyTo(new Span<byte>(ioBuffer, ioIndex, num));
					ioIndex += num;
					return;
				}
				state.Flush();
				ReadOnlySequence<byte>.Enumerator enumerator = data.GetEnumerator();
				while (enumerator.MoveNext())
				{
					ReadOnlyMemory<byte> current = enumerator.Current;
					dest.Write(current.Span);
				}
			}

			private protected override void ImplWriteString(ref State state, string value, int expectedBytes)
			{
				DemandSpace(expectedBytes, this, ref state);
				int bytes = UTF8.GetBytes(value, 0, value.Length, ioBuffer, ioIndex);
				ioIndex += bytes;
			}

			private static void WriteUInt32ToBuffer(uint value, byte[] buffer, int index)
			{
				BinaryPrimitives.WriteUInt32LittleEndian(buffer.AsSpan(index, 4), value);
			}

			private protected override void ImplWriteFixed32(ref State state, uint value)
			{
				DemandSpace(4, this, ref state);
				WriteUInt32ToBuffer(value, ioBuffer, ioIndex);
				ioIndex += 4;
			}

			private protected override void ImplWriteFixed64(ref State state, ulong value)
			{
				DemandSpace(8, this, ref state);
				byte[] array = ioBuffer;
				int start = ioIndex;
				BinaryPrimitives.WriteUInt64LittleEndian(array.AsSpan(start, 8), value);
				ioIndex += 8;
			}

			internal override int ImplWriteVarint64(ref State state, ulong value)
			{
				DemandSpace(10, this, ref state);
				int num = 0;
				do
				{
					ioBuffer[ioIndex++] = (byte)((value & 0x7F) | 0x80);
					num++;
				}
				while ((value >>= 7) != 0L);
				ioBuffer[ioIndex - 1] &= 127;
				return num;
			}

			private protected override int ImplWriteVarint32(ref State state, uint value)
			{
				DemandSpace(5, this, ref state);
				int num = 0;
				do
				{
					ioBuffer[ioIndex++] = (byte)((value & 0x7F) | 0x80);
					num++;
				}
				while ((value >>= 7) != 0);
				ioBuffer[ioIndex - 1] &= 127;
				return num;
			}

			private protected override void ImplCopyRawFromStream(ref State state, Stream source)
			{
				byte[] array = ioBuffer;
				int num = array.Length - ioIndex;
				int num2 = 1;
				while (num > 0 && (num2 = source.Read(array, ioIndex, num)) > 0)
				{
					ioIndex += num2;
					Advance(num2);
					num -= num2;
				}
				if (num2 <= 0)
				{
					return;
				}
				if (flushLock == 0)
				{
					state.Flush();
					while ((num2 = source.Read(array, 0, array.Length)) > 0)
					{
						dest.Write(array, 0, num2);
						Advance(num2);
					}
					return;
				}
				while (true)
				{
					DemandSpace(128, this, ref state);
					if ((num2 = source.Read(ioBuffer, ioIndex, ioBuffer.Length - ioIndex)) > 0)
					{
						Advance(num2);
						ioIndex += num2;
						continue;
					}
					break;
				}
			}

			private protected override SubItemToken ImplStartLengthPrefixedSubItem(ref State state, object instance, PrefixStyle style)
			{
				switch (base.WireType)
				{
				case WireType.String:
					base.WireType = WireType.None;
					DemandSpace(32, this, ref state);
					flushLock++;
					Advance(1L);
					return new SubItemToken(ioIndex++);
				case WireType.Fixed32:
				{
					DemandSpace(32, this, ref state);
					flushLock++;
					SubItemToken result = new SubItemToken(ioIndex);
					IncrementedAndReset(4, this);
					return result;
				}
				default:
					state.ThrowInvalidSerializationOperation();
					return default(SubItemToken);
				}
			}

			private protected override void ImplEndLengthPrefixedSubItem(ref State state, SubItemToken token, PrefixStyle style)
			{
				int num = (int)token.value64;
				switch (style)
				{
				case PrefixStyle.Fixed32:
				{
					int num2 = ioIndex - num - 4;
					WriteUInt32ToBuffer((uint)num2, ioBuffer, num);
					break;
				}
				case PrefixStyle.Fixed32BigEndian:
				{
					int num2 = ioIndex - num - 4;
					byte[] array2 = ioBuffer;
					WriteUInt32ToBuffer((uint)num2, array2, num);
					byte b = array2[num];
					array2[num] = array2[num + 3];
					array2[num + 3] = b;
					b = array2[num + 1];
					array2[num + 1] = array2[num + 2];
					array2[num + 2] = b;
					break;
				}
				case PrefixStyle.Base128:
				{
					int num2 = ioIndex - num - 1;
					int num3 = 0;
					uint num4 = (uint)num2;
					while ((num4 >>= 7) != 0)
					{
						num3++;
					}
					if (num3 == 0)
					{
						ioBuffer[num] = (byte)(num2 & 0x7F);
						break;
					}
					DemandSpace(num3, this, ref state);
					byte[] array = ioBuffer;
					Buffer.BlockCopy(array, num + 1, array, num + 1 + num3, num2);
					num4 = (uint)num2;
					do
					{
						array[num++] = (byte)((num4 & 0x7F) | 0x80);
					}
					while ((num4 >>= 7) != 0);
					array[num - 1] = (byte)(array[num - 1] & -129);
					Advance(num3);
					ioIndex += num3;
					break;
				}
				default:
					ThrowHelper.ThrowArgumentOutOfRangeException("style");
					break;
				}
				if (--flushLock == 0 && ioIndex >= 1024)
				{
					state.Flush();
				}
			}
		}

		private const MethodImplOptions HotPath = MethodImplOptions.AggressiveInlining;

		internal const string PreferWriteMessage = "If possible, please use the WriteMessage API; this API may not work correctly with all writers";

		private TypeModel model;

		private int packedFieldNumber;

		private protected readonly NetObjectCache netCache;

		private int fieldNumber;

		private int _depth;

		private const int RecursionCheckDepth = 25;

		private List<object> recursionStack;

		private bool _needFlush;

		private long _position64;

		protected internal static readonly UTF8Encoding UTF8 = new UTF8Encoding();

		internal WireType WireType { get; set; }

		[Obsolete("Prefer UserState")]
		public SerializationContext Context => SerializationContext.AsSerializationContext(this);

		public object UserState { get; private set; }

		internal int Depth => _depth;

		public TypeModel Model
		{
			get
			{
				return model;
			}
			internal set
			{
				model = value;
			}
		}

		private protected abstract bool ImplDemandFlushOnDispose { get; }

		[Obsolete("Please migrate to TypeModel.BufferSize")]
		public static int BufferSize
		{
			get
			{
				return TypeModel.DefaultModel.BufferSize;
			}
			set
			{
				TypeModel.DefaultModel.BufferSize = value;
			}
		}

		void IDisposable.Dispose()
		{
			Dispose();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteFieldHeader(int fieldNumber, WireType wireType, ProtoWriter writer)
		{
			writer.DefaultState().WriteFieldHeader(fieldNumber, wireType);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteBytes(byte[] data, ProtoWriter writer)
		{
			writer.DefaultState().WriteBytes(data);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteBytes(byte[] data, int offset, int length, ProtoWriter writer)
		{
			writer.DefaultState().WriteBytes(new ReadOnlyMemory<byte>(data, offset, length));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Obsolete("If possible, please use the WriteMessage API; this API may not work correctly with all writers", false)]
		public static SubItemToken StartSubItem(object instance, ProtoWriter writer)
		{
			return writer.DefaultState().StartSubItem(instance, PrefixStyle.Base128);
		}

		private void PreSubItem(ref State state, object instance)
		{
			if (_depth < 0)
			{
				state.ThrowInvalidSerializationOperation();
			}
			if (++_depth >= ((model == null) ? 512 : model.MaxDepth))
			{
				state.ThrowTooDeep(_depth);
			}
			if (_depth > 25)
			{
				CheckRecursionStackAndPush(instance);
			}
			if (packedFieldNumber != 0)
			{
				ThrowHelper.ThrowInvalidOperationException("Cannot begin a sub-item while performing packed encoding");
			}
		}

		private void CheckRecursionStackAndPush(object instance)
		{
			if (recursionStack == null)
			{
				recursionStack = new List<object>();
			}
			else if (instance != null)
			{
				int num = 0;
				foreach (object item in recursionStack)
				{
					if (item == instance)
					{
						ThrowHelper.ThrowProtoException($"Possible recursion detected (offset: {recursionStack.Count - num} level(s)): {instance}");
					}
					num++;
				}
			}
			recursionStack.Add(instance);
		}

		private void PopRecursionStack()
		{
			recursionStack.RemoveAt(recursionStack.Count - 1);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Obsolete("If possible, please use the WriteMessage API; this API may not work correctly with all writers", false)]
		public static void EndSubItem(SubItemToken token, ProtoWriter writer)
		{
			writer.DefaultState().EndSubItem(token, PrefixStyle.Base128);
		}

		private void PostSubItem(ref State state)
		{
			if (WireType != WireType.None)
			{
				state.ThrowInvalidSerializationOperation();
			}
			if (_depth <= 0)
			{
				state.ThrowInvalidSerializationOperation();
			}
			if (_depth-- > 25)
			{
				PopRecursionStack();
			}
			packedFieldNumber = 0;
		}

		private protected ProtoWriter()
		{
			netCache = new NetObjectCache();
		}

		private protected ProtoWriter(NetObjectCache knownObjects)
		{
			netCache = knownObjects;
		}

		internal virtual void Init(TypeModel model, object userState, bool impactCount)
		{
			_position64 = 0L;
			_needFlush = false;
			packedFieldNumber = 0;
			_depth = 0;
			fieldNumber = 0;
			this.model = model;
			WireType = WireType.None;
			if (userState is SerializationContext serializationContext)
			{
				serializationContext.Freeze();
			}
			UserState = userState;
		}

		internal WriteState ResetWriteState()
		{
			WriteState result = new WriteState(_position64, fieldNumber, WireType);
			_position64 = 0L;
			fieldNumber = 0;
			WireType = WireType.None;
			return result;
		}

		internal void SetWriteState(WriteState state)
		{
			_position64 = state.Position;
			fieldNumber = state.FieldNumber;
			WireType = state.WireType;
		}

		internal virtual void Dispose()
		{
			Cleanup();
		}

		private protected virtual void Cleanup()
		{
			if (_depth == 0 && _needFlush && ImplDemandFlushOnDispose)
			{
				ThrowHelper.ThrowInvalidOperationException("Writer was disposed without being flushed; data may be lost - you should ensure that Flush (or Abandon) is called");
			}
			recursionStack?.Clear();
			ClearKnownObjects();
			model = null;
			UserState = null;
		}

		private protected virtual void ClearKnownObjects()
		{
			netCache?.Clear();
		}

		protected internal virtual void WriteMessage<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(ref State state, T value, ISerializer<T> serializer, PrefixStyle style, bool recursionCheck)
		{
			SubItemToken token = state.StartSubItem((TypeHelper<T>.IsReferenceType && recursionCheck) ? ((object)value) : null, style);
			(serializer ?? TypeModel.GetSerializer<T>(model)).Write(ref state, value);
			state.EndSubItem(token, style);
		}

		internal virtual void WriteWrappedCollection<TCollection, TItem>(ref State state, SerializerFeatures features, TCollection values, RepeatedSerializer<TCollection, TItem> serializer, ISerializer<TItem> valueSerializer)
		{
			SubItemToken token = state.StartSubItem(null);
			serializer.WriteRepeated(ref state, 1, features, values, valueSerializer);
			state.EndSubItem(token);
		}

		internal virtual void WriteWrappedMap<TCollection, TKey, TValue>(ref State state, SerializerFeatures features, TCollection values, MapSerializer<TCollection, TKey, TValue> serializer, SerializerFeatures keyFeatures, SerializerFeatures valueFeatures, ISerializer<TKey> keySerializer, ISerializer<TValue> valueSerializer)
		{
			SubItemToken token = state.StartSubItem(null);
			serializer.WriteMap(ref state, 1, features, values, keyFeatures, valueFeatures, keySerializer, valueSerializer);
			state.EndSubItem(token);
		}

		internal void WriteEmptyWrappedItem(ref State state)
		{
			switch (WireType)
			{
			case WireType.String:
				AdvanceAndReset(ImplWriteVarint32(ref state, 0u));
				break;
			case WireType.StartGroup:
				state.WriteHeaderCore(state.FieldNumber, WireType.EndGroup);
				WireType = WireType.None;
				break;
			default:
				ThrowHelper.ThrowArgumentOutOfRangeException("WireType");
				break;
			}
		}

		internal virtual void WriteWrappedItem<T>(ref State state, SerializerFeatures features, T value, ISerializer<T> serializer)
		{
			SubItemToken token = state.StartSubItem((TypeHelper<T>.IsReferenceType & features.ApplyRecursionCheck()) ? ((object)value) : null, PrefixStyle.Base128);
			state.WriteAny(1, features, value, serializer);
			state.EndSubItem(token);
		}

		protected internal virtual void WriteSubType<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T>(ref State state, T value, ISubTypeSerializer<T> serializer) where T : class
		{
			SubItemToken token = state.StartSubItem(null, PrefixStyle.Base128);
			serializer.WriteSubType(ref state, value);
			state.EndSubItem(token, PrefixStyle.Base128);
		}

		public void Abandon()
		{
			_needFlush = false;
		}

		internal long GetPosition(ref State state)
		{
			return _position64;
		}

		private protected void Advance(long count)
		{
			_position64 += count;
		}

		internal void AdvanceAndReset(int count)
		{
			_position64 += count;
			WireType = WireType.None;
		}

		internal void AdvanceAndReset(long count)
		{
			_position64 += count;
			WireType = WireType.None;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Close()
		{
			DefaultState().Close();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal void CheckClear(ref State state)
		{
			if (_depth != 0 || !TryFlush(ref state))
			{
				ThrowHelper.ThrowInvalidOperationException($"The writer is in an incomplete state (depth: {_depth}, type: {GetType().Name}, field: {fieldNumber}, wire-type: {WireType}, position: {state.GetPosition()})");
			}
			_needFlush = false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static uint Zig(int value)
		{
			return (uint)((value << 1) ^ (value >> 31));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static ulong Zig(long value)
		{
			return (ulong)((value << 1) ^ (value >> 63));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteString(string value, ProtoWriter writer)
		{
			writer.DefaultState().WriteString(value);
		}

		private protected abstract void ImplWriteString(ref State state, string value, int expectedBytes);

		private protected abstract int ImplWriteVarint32(ref State state, uint value);

		internal abstract int ImplWriteVarint64(ref State state, ulong value);

		private protected abstract void ImplWriteFixed32(ref State state, uint value);

		private protected abstract void ImplWriteFixed64(ref State state, ulong value);

		private protected abstract void ImplWriteBytes(ref State state, ReadOnlySpan<byte> data);

		private protected abstract void ImplWriteBytes(ref State state, ReadOnlySequence<byte> data);

		private protected abstract void ImplCopyRawFromStream(ref State state, Stream source);

		private protected abstract SubItemToken ImplStartLengthPrefixedSubItem(ref State state, object instance, PrefixStyle style);

		private protected abstract void ImplEndLengthPrefixedSubItem(ref State state, SubItemToken token, PrefixStyle style);

		private protected abstract bool TryFlush(ref State state);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteUInt64(ulong value, ProtoWriter writer)
		{
			writer.DefaultState().WriteUInt64(value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteInt64(long value, ProtoWriter writer)
		{
			writer.DefaultState().WriteInt64(value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteUInt32(uint value, ProtoWriter writer)
		{
			writer.DefaultState().WriteUInt32(value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteInt16(short value, ProtoWriter writer)
		{
			writer.DefaultState().WriteInt16(value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteUInt16(ushort value, ProtoWriter writer)
		{
			writer.DefaultState().WriteUInt16(value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteByte(byte value, ProtoWriter writer)
		{
			writer.DefaultState().WriteByte(value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteSByte(sbyte value, ProtoWriter writer)
		{
			writer.DefaultState().WriteSByte(value);
		}

		public static void WriteInt32(int value, ProtoWriter writer)
		{
			writer.DefaultState().WriteInt32(value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteDouble(double value, ProtoWriter writer)
		{
			writer.DefaultState().WriteDouble(value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteSingle(float value, ProtoWriter writer)
		{
			writer.DefaultState().WriteSingle(value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ThrowEnumException(ProtoWriter writer, object enumValue)
		{
			writer.DefaultState().ThrowEnumException(enumValue);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteBoolean(bool value, ProtoWriter writer)
		{
			writer.DefaultState().WriteBoolean(value);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AppendExtensionData(IExtensible instance, ProtoWriter writer)
		{
			writer.DefaultState().AppendExtensionData(instance);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPackedField(int fieldNumber, ProtoWriter writer)
		{
			writer.DefaultState().SetPackedField(fieldNumber);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ClearPackedField(int fieldNumber, ProtoWriter writer)
		{
			writer.DefaultState().ClearPackedField(fieldNumber);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WritePackedPrefix(int elementCount, WireType wireType, ProtoWriter writer)
		{
			writer.DefaultState().WritePackedPrefix(elementCount, wireType);
		}

		internal string SerializeType(Type type)
		{
			return TypeModel.SerializeType(model, type);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void WriteType(Type value, ProtoWriter writer)
		{
			writer.DefaultState().WriteType(value);
		}

		internal static long MeasureRepeated<TCollection, TItem>(NullProtoWriter writer, int fieldNumber, SerializerFeatures features, TCollection values, RepeatedSerializer<TCollection, TItem> serializer, ISerializer<TItem> valueSerializer)
		{
			object obj = null;
			long length;
			if (TypeHelper<TCollection>.IsReferenceType)
			{
				obj = values;
				if (obj == null)
				{
					return 0L;
				}
				if (writer.netCache.TryGetKnownLength(obj, null, out length))
				{
					return length;
				}
			}
			WriteState writeState = writer.ResetWriteState();
			State state = new State(writer);
			serializer.WriteRepeated(ref state, fieldNumber, features, values, valueSerializer);
			length = state.GetPosition();
			writer.SetWriteState(writeState);
			if (obj != null)
			{
				writer.netCache.SetKnownLength(obj, null, length);
			}
			return length;
		}

		internal static long MeasureMap<TCollection, TKey, TValue>(NullProtoWriter writer, int fieldNumber, SerializerFeatures features, TCollection values, MapSerializer<TCollection, TKey, TValue> serializer, SerializerFeatures keyFeatures, SerializerFeatures valueFeatures, ISerializer<TKey> keySerializer, ISerializer<TValue> valueSerializer)
		{
			object obj = null;
			long length;
			if (TypeHelper<TCollection>.IsReferenceType)
			{
				obj = values;
				if (obj == null)
				{
					return 0L;
				}
				if (writer.netCache.TryGetKnownLength(obj, null, out length))
				{
					return length;
				}
			}
			WriteState writeState = writer.ResetWriteState();
			State state = new State(writer);
			serializer.WriteMap(ref state, fieldNumber, features, values, keyFeatures, valueFeatures, keySerializer, valueSerializer);
			length = state.GetPosition();
			writer.SetWriteState(writeState);
			if (obj != null)
			{
				writer.netCache.SetKnownLength(obj, null, length);
			}
			return length;
		}

		internal static long MeasureAny<T>(NullProtoWriter writer, int fieldNumber, SerializerFeatures features, T value, ISerializer<T> serializer)
		{
			WriteState writeState = writer.ResetWriteState();
			State state = new State(writer);
			state.WriteAny(fieldNumber, features, value, serializer);
			long position = state.GetPosition();
			writer.SetWriteState(writeState);
			return position;
		}

		internal static long Measure<T>(NullProtoWriter writer, T value, ISerializer<T> serializer)
		{
			object obj = null;
			long length;
			if (TypeHelper<T>.IsReferenceType)
			{
				obj = value;
				if (obj == null)
				{
					return 0L;
				}
				if (writer.netCache.TryGetKnownLength(obj, null, out length))
				{
					return length;
				}
			}
			WriteState writeState = writer.ResetWriteState();
			State state = new State(writer);
			serializer.Write(ref state, value);
			length = state.GetPosition();
			writer.SetWriteState(writeState);
			if (obj != null)
			{
				writer.netCache.SetKnownLength(obj, null, length);
			}
			return length;
		}

		internal static long Measure<T>(NullProtoWriter writer, T value, ISubTypeSerializer<T> serializer) where T : class
		{
			if (value == null)
			{
				return 0L;
			}
			if (writer.netCache.TryGetKnownLength(value, typeof(T), out var length))
			{
				return length;
			}
			WriteState writeState = writer.ResetWriteState();
			State state = new State(writer);
			serializer.WriteSubType(ref state, value);
			length = state.GetPosition();
			writer.SetWriteState(writeState);
			writer.netCache.SetKnownLength(value, typeof(T), length);
			return length;
		}

		internal static State CreateNull(TypeModel model, object userState, long abortAfter)
		{
			return NullProtoWriter.CreateNullProtoWriter(model, userState, abortAfter);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static int MeasureInt32(int value)
		{
			if (value >= 0)
			{
				return MeasureUInt32((uint)value);
			}
			return 10;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static int MeasureUInt32(uint value)
		{
			int num = 1;
			while ((value >>= 7) != 0)
			{
				num++;
			}
			return num;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static int MeasureInt64(long value)
		{
			if (value >= 0)
			{
				return MeasureUInt64((ulong)value);
			}
			return 10;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		internal static int MeasureUInt64(ulong value)
		{
			int num = 1;
			while ((value >>= 7) != 0L)
			{
				num++;
			}
			return num;
		}

		protected internal abstract State DefaultState();

		internal void InitializeFrom(ProtoWriter writer)
		{
			netCache?.InitializeFrom(writer?.netCache);
		}

		internal void CopyBack(ProtoWriter writer)
		{
			netCache?.CopyBack(writer?.netCache);
		}

		internal int GetLengthHits(out int misses)
		{
			misses = netCache?.LengthMisses ?? 0;
			return netCache?.LengthHits ?? 0;
		}

		[Obsolete("If possible, please use the State API; a transitionary implementation is provided, but this API may be removed in a future version", false)]
		public static ProtoWriter Create(Stream dest, TypeModel model, SerializationContext context = null)
		{
			return StreamProtoWriter.CreateStreamProtoWriter(dest, model, context);
		}
	}
}
