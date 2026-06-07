namespace Rewired.Utils.Interfaces
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal interface IReadOnlyDictionaryEnumerator<TKey, TValue>
	{
		TValue this[TKey key] { get; }

		bool ContainsKey(TKey key);

		bool TryGetValue(TKey key, out TValue value);
	}
}
