using UnityEngine;

namespace Restory.Data.Equipment
{
	[CreateAssetMenu(fileName = "Ultrasonic Tool - Name", menuName = "Restory/Equipment/UltrasonicTool")]
	public class UltrasonicToolInfo : ToolInfo
	{
		[SerializeField]
		[Min(1f)]
		[Tooltip("Realtime seconds, will be scaled by time settings to in-game duration.")]
		private float cleaningDuration = 15f;

		public float CleaningDuration => cleaningDuration;
	}
}
