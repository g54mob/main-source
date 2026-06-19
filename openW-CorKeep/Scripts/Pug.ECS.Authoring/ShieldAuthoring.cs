using NaughtyAttributes;
using UnityEngine;

[DisallowMultipleComponent]
public class ShieldAuthoring : MonoBehaviour
{
	[MinValue(0)]
	[MaxValue(360)]
	public int shieldWidthDegrees = 90;

	public bool defaultShieldActive;
}
