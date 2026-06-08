using System;
using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using ProtoBuf.Internal;
using ProtoBuf.Meta;

namespace ProtoBuf
{
	public struct MeasureState<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T> : IDisposable
	{
		private readonly TypeModel _model;

		private readonly T _value;

		private readonly object _userState;

		private ProtoWriter _writer;

		public long Length { get; }

		internal MeasureState(TypeModel model, in T value, object userState, long abortAfter)
		{
			_model = model;
			_value = value;
			_userState = userState;
			ProtoWriter.State state = ProtoWriter.NullProtoWriter.CreateNullProtoWriter(_model, userState, abortAfter);
			try
			{
				Length = TypeModel.SerializeImpl(ref state, _value);
				ProtoWriter.NullProtoWriter.CheckOversized(abortAfter, Length);
				_writer = state.GetWriter();
			}
			catch
			{
				state.Dispose();
				throw;
			}
		}

		public void Dispose()
		{
			ProtoWriter writer = _writer;
			_writer = null;
			writer?.Dispose();
		}

		public long LengthOnly()
		{
			long length = Length;
			Dispose();
			return length;
		}

		private void SerializeCore(ProtoWriter.State state)
		{
			try
			{
				ProtoWriter writer = _writer;
				if (writer == null)
				{
					throw new ObjectDisposedException("MeasureState");
				}
				ProtoWriter writer2 = state.GetWriter();
				writer2.InitializeFrom(writer);
				long num = TypeModel.SerializeImpl(ref state, _value);
				writer2.CopyBack(writer);
				if (num != Length)
				{
					ThrowHelper.ThrowInvalidOperationException($"Invalid length; expected {Length}, actual: {num}");
				}
			}
			catch (Exception ex)
			{
				ex.Data?.Add("ProtoBuf.MeasuredLength", Length);
				throw;
			}
			finally
			{
				state.Dispose();
			}
		}

		internal int GetLengthHits(out int misses)
		{
			return _writer.GetLengthHits(out misses);
		}

		public void Serialize(Stream stream)
		{
			SerializeCore(ProtoWriter.State.Create(stream, _model, _userState));
		}

		public void Serialize(IBufferWriter<byte> writer)
		{
			SerializeCore(ProtoWriter.State.Create(writer, _model, _userState));
		}
	}
}
