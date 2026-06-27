using FMODUnity;
using UnityEngine;

namespace Restory.Data.Equipment
{
	[CreateAssetMenu(fileName = "Shredder Tool - Name", menuName = "Restory/Equipment/ShredderTool")]
	public class ShredderToolInfo : ToolInfo
	{
		[SerializeField]
		[Min(0f)]
		private int minReward = 50;

		[SerializeField]
		[Min(0f)]
		private int maxReward = 300;

		[SerializeField]
		[Min(0f)]
		private int critSuccessBarrier = 250;

		[SerializeField]
		[Min(1f)]
		private float critSuccessMod = 2f;

		[SerializeField]
		[Min(0f)]
		private int critFailBarrier;

		[SerializeField]
		private EventReference objectShreddedSound;

		public int MinReward => minReward;

		public int MaxReward => maxReward;

		public int CritSuccessBarrier => critSuccessBarrier;

		public float CritSuccessMod => critSuccessMod;

		public int CritFailBarrier => critFailBarrier;

		public EventReference ObjectShreddedSound => objectShreddedSound;
	}
}
