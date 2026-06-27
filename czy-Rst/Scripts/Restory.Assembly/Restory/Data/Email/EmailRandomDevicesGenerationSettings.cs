using Helpers.Ranges;
using Restory.Data.Tables.Balances;
using UnityEngine;

namespace Restory.Data.Email
{
	[CreateAssetMenu(menuName = "Restory/Devices/RandomDevicesGenerationSettings", fileName = "RandomDevicesGenerationSettings")]
	public class EmailRandomDevicesGenerationSettings : ScriptableObject, IGameBalanceEntity
	{
		[SerializeField]
		[Min(1f)]
		private int maximumRestorationTypesAtOnce;

		[SerializeField]
		private IntRange dirtyElementsAmount;

		[SerializeField]
		private IntRange damagedElementsAmount;

		[SerializeField]
		[Range(0f, 1f)]
		private float deviceHasDamagedElementsChance;

		[SerializeField]
		[Range(0f, 1f)]
		private float paintTaskChance;

		[SerializeField]
		[Range(0f, 1f)]
		private float hackTaskChance;

		public int MaximumRestorationTypesAtOnce => maximumRestorationTypesAtOnce;

		public IntRange DirtyElementsAmount => dirtyElementsAmount;

		public IntRange DamagedElementsAmount => damagedElementsAmount;

		public float DeviceHasDamagedElementsChance => deviceHasDamagedElementsChance;

		public float PaintTaskChance => paintTaskChance;

		public float HackTaskChance => hackTaskChance;
	}
}
