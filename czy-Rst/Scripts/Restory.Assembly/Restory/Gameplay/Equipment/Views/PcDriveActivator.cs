using Restory.Gameplay.Effects;
using UnityEngine;

namespace Restory.Gameplay.Equipment.Views
{
	public class PcDriveActivator : EquipmentActivatorBase
	{
		[SerializeField]
		private BounceEffect bounceEffect;

		public override void Activate()
		{
			bounceEffect.PlayBounce();
		}
	}
}
