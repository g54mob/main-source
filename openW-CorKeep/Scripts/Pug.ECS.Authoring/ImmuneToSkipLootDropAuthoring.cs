using NaughtyAttributes;
using UnityEngine;

public class ImmuneToSkipLootDropAuthoring : MonoBehaviour
{
	[ReadOnly]
	public bool ignoredInCreativeMode = true;
}
