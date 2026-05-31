using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Static Behaviours/Freemode Profile Behaviour")]
	public class FreemodeProfileMethods : ScriptableObject
	{
		[SerializeField]
		private MapInfoSO _demoSandboxLevel;
	}
}
