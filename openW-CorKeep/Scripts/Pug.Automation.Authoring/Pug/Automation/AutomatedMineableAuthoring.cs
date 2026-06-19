using UnityEngine;

namespace Pug.Automation
{
	[DisallowMultipleComponent]
	public class AutomatedMineableAuthoring : MonoBehaviour
	{
		[Header("Decrease damage the more total damage is taken")]
		public float damageDecreaseFactor;

		[Tooltip("Decrease is the power of the factor to the total damage times this")]
		public float damageDecreaseExponential;
	}
}
