using System.Runtime.Serialization;
using ProtoBuf.Internal;

namespace ProtoBuf
{
	public sealed class SerializationContext
	{
		private bool frozen;

		private object context;

		private StreamingContextStates state = StreamingContextStates.Persistence;

		public object Context
		{
			get
			{
				return context;
			}
			set
			{
				if (context != value)
				{
					ThrowIfFrozen();
					context = value;
				}
			}
		}

		internal static SerializationContext Default { get; } = new SerializationContext
		{
			frozen = true
		};

		public StreamingContextStates State
		{
			get
			{
				return state;
			}
			set
			{
				if (state != value)
				{
					ThrowIfFrozen();
					state = value;
				}
			}
		}

		internal void Freeze()
		{
			frozen = true;
		}

		private void ThrowIfFrozen()
		{
			if (frozen)
			{
				ThrowHelper.ThrowInvalidOperationException("The serialization-context cannot be changed once it is in use");
			}
		}

		public static implicit operator StreamingContext(SerializationContext ctx)
		{
			if (ctx == null)
			{
				return new StreamingContext(StreamingContextStates.Persistence);
			}
			return new StreamingContext(ctx.state, ctx.context);
		}

		public static implicit operator SerializationContext(StreamingContext ctx)
		{
			return new SerializationContext
			{
				Context = ctx.Context,
				State = ctx.State
			};
		}

		public static StreamingContext AsStreamingContext(ISerializationContext context)
		{
			object obj = context?.UserState;
			if (obj is SerializationContext serializationContext)
			{
				return new StreamingContext(serializationContext.state, serializationContext.context);
			}
			return new StreamingContext(StreamingContextStates.Persistence, obj);
		}

		public static SerializationContext AsSerializationContext(ISerializationContext context)
		{
			object obj = context?.UserState;
			if (obj != null)
			{
				if (obj is SerializationContext result)
				{
					return result;
				}
				return new SerializationContext
				{
					context = context,
					frozen = true
				};
			}
			return Default;
		}
	}
}
