using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ProtoBuf.Internal;
using ProtoBuf.Meta;

namespace ProtoBuf.Serializers
{
	[StructLayout(LayoutKind.Auto)]
	public struct SubTypeState<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors | DynamicallyAccessedMemberTypes.PublicMethods | DynamicallyAccessedMemberTypes.NonPublicMethods | DynamicallyAccessedMemberTypes.PublicFields | DynamicallyAccessedMemberTypes.NonPublicFields | DynamicallyAccessedMemberTypes.PublicNestedTypes | DynamicallyAccessedMemberTypes.NonPublicNestedTypes | DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.NonPublicProperties)] T> where T : class
	{
		private readonly ISerializationContext _context;

		private readonly Func<ISerializationContext, object> _ctor;

		private object _value;

		private Action<T, ISerializationContext> _onBeforeDeserialize;

		public T Value
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return (_value as T) ?? Cast();
			}
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set
			{
				_value = value;
			}
		}

		internal readonly object RawValue => _value;

		public readonly bool HasValue => _value != null;

		public static SubTypeState<T> Create<TValue>(ISerializationContext context, TValue value) where TValue : class, T
		{
			return new SubTypeState<T>(context, TypeHelper<T>.Factory, value, null);
		}

		private SubTypeState(ISerializationContext context, Func<ISerializationContext, object> ctor, object value, Action<T, ISerializationContext> onBeforeDeserialize)
		{
			_context = context;
			_ctor = ctor;
			_value = value;
			_onBeforeDeserialize = onBeforeDeserialize;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void CreateIfNeeded()
		{
			_ = Value;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private T Cast()
		{
			T val = ((_ctor as Func<ISerializationContext, T>) ?? TypeHelper<T>.Factory)(_context);
			if (_value != null)
			{
				val = Merge(_context, _value, val);
			}
			_onBeforeDeserialize?.Invoke(val, _context);
			_value = val;
			return val;
			static T Merge(ISerializationContext context, object value, T typed)
			{
				using MemoryStream memoryStream = new MemoryStream();
				context.Model.Serialize(memoryStream, value, context.UserState);
				memoryStream.Position = 0L;
				return context.Model.Deserialize(memoryStream, typed, context.UserState);
			}
		}

		public void ReadSubType<TSubType>(ref ProtoReader.State state, ISubTypeSerializer<TSubType> serializer = null) where TSubType : class, T
		{
			SubItemToken token = state.StartSubItem();
			_value = (serializer ?? TypeModel.GetSubTypeSerializer<TSubType>(_context.Model)).ReadSubType(ref state, new SubTypeState<TSubType>(_context, _ctor, _value, _onBeforeDeserialize));
			state.EndSubItem(token);
		}

		public void OnBeforeDeserialize(Action<T, ISerializationContext> callback)
		{
			if (callback != null)
			{
				if (_value is T arg)
				{
					callback(arg, _context);
				}
				else if (_onBeforeDeserialize != null)
				{
					ThrowHelper.ThrowInvalidOperationException("Only one pending OnBeforeDeserialize callback is supported");
				}
				else
				{
					_onBeforeDeserialize = callback;
				}
			}
		}
	}
}
