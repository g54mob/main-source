using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class MachineProcessParticles : CTSBehaviour
	{
		[SerializeField]
		private ParticleSystem _particleSystem;

		[InjectScope(EGetScope.Parent)]
		[Inject(false)]
		private IProcessMachine _processMachine;

		protected override void OnAwake()
		{
			base.OnAwake();
			_processMachine.ProcessStarted += OnProcessStarted;
			_processMachine.ProcessEnded += OnProcessEnded;
		}

		private void OnDestroy()
		{
			_processMachine.ProcessStarted -= OnProcessStarted;
			_processMachine.ProcessEnded -= OnProcessEnded;
		}

		private void OnProcessEnded()
		{
			_particleSystem.Stop();
		}

		private void OnProcessStarted()
		{
			_particleSystem.Play();
		}
	}
}
