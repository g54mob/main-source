using FMODUnity;
using UnityEngine;

namespace Restory.Data.Equipment
{
	[CreateAssetMenu(fileName = "Unscrewing Tool - Name", menuName = "Restory/Equipment/UnscrewingTool")]
	public class UnscrewingToolInfo : ToolInfo
	{
		[SerializeField]
		private bool autoUnscrewing;

		[SerializeField]
		[Min(0f)]
		private float unscrewingSpeed = 1f;

		[SerializeField]
		private EventReference screwingSound;

		public bool AutoUnscrewing => autoUnscrewing;

		public float UnscrewingSpeed => unscrewingSpeed;

		public EventReference ScrewingSound => screwingSound;
	}
}
