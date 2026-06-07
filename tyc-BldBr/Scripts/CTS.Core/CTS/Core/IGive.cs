using UnityEngine;

namespace CTS.Core
{
	public interface IGive<out TObject>
	{
		TObject Get();
	}
	public interface IGive<in TKey, out TObject>
	{
		TObject Get(TKey key);
	}
	internal interface IGive : IParentable<Object>
	{
		bool HasValue();

		object Get();
	}
}
