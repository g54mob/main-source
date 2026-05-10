using UnityEngine;

namespace CTS.Core
{
	internal interface IGiveWithKey : IParentable<Object>
	{
		bool HasValue();

		object Get<TKey>(TKey key);
	}
}
