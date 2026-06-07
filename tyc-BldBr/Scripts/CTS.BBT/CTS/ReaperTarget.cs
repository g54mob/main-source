using CTS.Core;
using CTS.Core.Pooling;
using UnityEngine;

namespace CTS
{
	public class ReaperTarget : CTSBehaviour, IPoolCallbackReceiver
	{
		public ParticleSystem VFX { get; set; }

		void IPoolCallbackReceiver.OnPulled()
		{
		}

		void IPoolCallbackReceiver.OnPushed()
		{
			VFX.Stop();
		}
	}
}
