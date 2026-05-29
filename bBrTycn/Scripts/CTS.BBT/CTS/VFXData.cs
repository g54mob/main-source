using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "CTS/VFX Data")]
	public class VFXData : ScriptableObject
	{
		[field: SerializeField]
		public VFXTimer Prefab { get; private set; }
	}
}
