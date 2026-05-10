using UnityEngine;

namespace CTS.Core
{
	[CreateAssetMenu(menuName = "CTS/Selection/Mode", fileName = "New Selection Mode")]
	public class SelectionMode : ScriptableStringKey
	{
		[field: SerializeField]
		public LayerMask PhysicsMask { get; private set; } = -1;

		[field: SerializeField]
		public bool AllowMultipleSelection { get; private set; }
	}
}
