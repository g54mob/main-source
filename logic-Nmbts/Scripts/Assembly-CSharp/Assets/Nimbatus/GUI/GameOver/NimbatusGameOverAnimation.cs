using Sirenix.Utilities;
using UnityEngine;

namespace Assets.Nimbatus.GUI.GameOver
{
	public class NimbatusGameOverAnimation : MonoBehaviour
	{
		public string ExplosionSound;

		public string LoopSound;

		private void Start()
		{
			if (!ExplosionSound.IsNullOrWhitespace())
			{
				AudioController.Play(ExplosionSound);
			}
			if (!LoopSound.IsNullOrWhitespace())
			{
				AudioController.Play(LoopSound);
			}
		}
	}
}
