namespace Rewired.Utils.Interfaces
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal interface IAddKeyValue<TKey, TValue>
	{
		void Add(TKey key, TValue value);
	}
}
