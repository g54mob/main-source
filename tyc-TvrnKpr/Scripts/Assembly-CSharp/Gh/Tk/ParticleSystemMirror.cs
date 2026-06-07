using UnityEngine;

namespace Gh.Tk
{
	public class ParticleSystemMirror : MonoBehaviour
	{
		private bool[] _isInitialisedStates;

		public ParticleSystem[] OurSystems { get; set; }

		public ParticleSystem[] TheirSystems { get; set; }

		public void LateUpdate()
		{
		}

		public static void ApplyParticleMirror(GameObject uiModel, GameObject inGameModel)
		{
		}
	}
}
