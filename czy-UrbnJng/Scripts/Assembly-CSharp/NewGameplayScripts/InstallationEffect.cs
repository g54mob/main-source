using System.Collections;
using UnityEngine;

namespace NewGameplayScripts
{
	public class InstallationEffect : MonoBehaviour
	{
		[SerializeField]
		private ParticleSystem particles;

		public void TurnOnStandByEffect()
		{
			if (particles != null)
			{
				particles.gameObject.SetActive(value: true);
				particles.Play();
				StartCoroutine(DeactivateParticlesAfterCompletion());
			}
		}

		private IEnumerator DeactivateParticlesAfterCompletion()
		{
			yield return new WaitForSeconds(particles.main.duration);
			particles.gameObject.SetActive(value: false);
		}
	}
}
