namespace Rewired.Utils.Interfaces
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal interface IReadOnlyList
	{
		int Count { get; }

		object Item { get; }

		int IndexOf(object value);

		bool Contains(object value);
	}
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal interface IReadOnlyList<T> : IReadOnlyList
	{
		new T Item { get; }

		int IndexOf(T value);

		bool Contains(T value);
	}
}
