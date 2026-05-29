namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal interface IObjectPool
	{
		void Clear(bool reduceSize = false);

		object Get();

		bool Return(object item);
	}
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal interface IObjectPool<T>
	{
		void Clear(bool reduceSize = false);

		T Get();

		bool Return(T item);
	}
}
