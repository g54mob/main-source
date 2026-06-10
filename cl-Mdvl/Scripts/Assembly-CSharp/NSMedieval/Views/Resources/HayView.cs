using NSEipix.Base;
using NSMedieval.Scripts.Pooler;
using UnityEngine;

namespace NSMedieval.Views.Resources
{
	public class HayView : PlantMapResourceView
	{
		[SerializeField]
		private MeshRenderer meshL0;

		[SerializeField]
		private MeshRenderer meshL1;

		public override void Dispose()
		{
			if (base.HasDisposed)
			{
				return;
			}
			if (base.transform != null && MonoSingleton<ParticleSystemPool>.IsInstantiated())
			{
				MonoSingleton<ParticleSystemPool>.Instance.PlayParticles("hay_pickup", base.transform.position);
				if ((bool)meshL0)
				{
					meshL0.enabled = false;
				}
				if ((bool)meshL1)
				{
					meshL1.enabled = false;
				}
			}
			base.Dispose();
		}
	}
}
