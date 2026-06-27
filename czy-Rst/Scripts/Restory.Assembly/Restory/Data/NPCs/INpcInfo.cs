using UnityEngine;

namespace Restory.Data.NPCs
{
	public interface INpcInfo
	{
		string ID { get; }

		string NameLocalizationKey { get; }

		Sprite Icon { get; }

		GameObject Prefab { get; }
	}
}
