using System;
using System.Runtime.CompilerServices;

namespace Pug.UnityExtensions
{
	[Serializable]
	public struct OptionalValue<T>
	{
		public bool hasValue;

		public T value;

		public OptionalValue(T value)
		{
			this.value = value;
			hasValue = true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly T GetOrDefault(T defaultValue)
		{
			if (!hasValue)
			{
				return defaultValue;
			}
			return value;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public readonly bool TryGetValue(out T output)
		{
			if (hasValue)
			{
				output = value;
				return true;
			}
			output = default(T);
			return false;
		}
	}
}
