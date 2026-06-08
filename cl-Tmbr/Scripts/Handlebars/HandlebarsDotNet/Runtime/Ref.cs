using System.Runtime.CompilerServices;

namespace HandlebarsDotNet.Runtime
{
	public sealed class Ref<T> where T : class
	{
		public T Value
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set;
		}

		public Ref()
		{
		}

		public Ref(T value)
		{
			Value = value;
		}
	}
}
