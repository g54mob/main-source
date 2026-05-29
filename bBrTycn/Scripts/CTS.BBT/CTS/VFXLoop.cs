using System.Collections;
using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	public class VFXLoop : MonoRoutine
	{
		[SerializeField]
		private ParticleSystem _particleSystem;

		protected override IEnumerator Routine()
		{
			_particleSystem.Play();
			ResetPlayCount();
			base.PlayOnEnable = true;
			while (true)
			{
				yield return null;
			}
		}

		protected override void OnStop()
		{
			base.PlayOnEnable = false;
			_particleSystem.Stop();
		}
	}
}
