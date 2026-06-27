using Restory.Gameplay.Effects;
using UnityEngine;

namespace Restory.Gameplay.Devices
{
	public class LicensedDevicePackage : DevicePackageBase
	{
		[SerializeField]
		private BounceEffect bounceEffect;

		[SerializeField]
		private ParticleSystem repackEffect;

		public void PerformRepack()
		{
			bounceEffect.PlayBounce();
			repackEffect.Play();
		}
	}
}
