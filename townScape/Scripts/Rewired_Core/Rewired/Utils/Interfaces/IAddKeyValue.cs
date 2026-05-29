namespace Rewired.Utils.Interfaces
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal interface IAddKeyValue<TKey, TValue>
	{
		void Add(TKey key, TValue value);
	}
}
