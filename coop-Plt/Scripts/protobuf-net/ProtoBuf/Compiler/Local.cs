using System;
using System.Reflection.Emit;

namespace ProtoBuf.Compiler
{
	internal sealed class Local : IDisposable
	{
		private LocalBuilder value;

		private readonly Type type;

		private CompilerContext ctx;

		internal LocalBuilder Value => value ?? throw new ObjectDisposedException(GetType().Name);

		public Type Type => type;

		private Local(LocalBuilder value, Type type)
		{
			this.value = value;
			this.type = type;
		}

		internal Local(CompilerContext ctx, Type type)
		{
			this.ctx = ctx;
			if (ctx != null)
			{
				value = ctx.GetFromPool(type);
			}
			this.type = type;
		}

		public Local AsCopy()
		{
			if (ctx == null)
			{
				return this;
			}
			return new Local(value, type);
		}

		public void Dispose()
		{
			if (ctx != null)
			{
				ctx.ReleaseToPool(value);
				value = null;
				ctx = null;
			}
		}

		internal bool IsSame(Local other)
		{
			if (this == other)
			{
				return true;
			}
			object obj = value;
			if (other != null)
			{
				return obj == other.value;
			}
			return false;
		}
	}
}
