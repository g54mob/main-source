using System.Collections;
using DV.Utils;
using UnityEngine;

namespace DV.Printers
{
	public class PrinterController : MonoBehaviour
	{
		private const float COOLDOWN_TIME = 1.25f;

		public Transform spawnAnchor;

		[SerializeField]
		private AudioClip errorSound;

		[SerializeField]
		private AudioClip printingSound;

		public bool IsOnCooldown { get; private set; }

		protected virtual void Awake()
		{
			if (spawnAnchor == null)
			{
				Debug.LogWarning("spawnAnchor isn't set! Using transform of this script!", this);
				spawnAnchor = base.transform;
			}
			if (printingSound == null)
			{
				Debug.LogWarning("printingSound isn't set! Sound will not be played!", this);
			}
			if (errorSound == null)
			{
				Debug.LogWarning("errorSound isn't set! Sound will not be played!", this);
			}
		}

		public void Print(bool ignoreCooldown = false)
		{
			if (IsOnCooldown && !ignoreCooldown)
			{
				Debug.LogError("Attempt to print even when printer is on cooldown, ignoring request!");
				return;
			}
			if (printingSound != null)
			{
				printingSound.Play(spawnAnchor.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
			}
			if (!ignoreCooldown)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Run(PrintCooldown());
			}
		}

		public void PlayErrorSound()
		{
			if (errorSound != null)
			{
				errorSound.Play(spawnAnchor.position, 1f, 1f, 0f, 1f, 500f, default(AudioSourceCurves), null, base.transform);
			}
		}

		protected virtual void CooldownStarted()
		{
			IsOnCooldown = true;
		}

		protected virtual void CooldownFinished()
		{
			IsOnCooldown = false;
		}

		private IEnumerator PrintCooldown()
		{
			CooldownStarted();
			yield return WaitFor.Seconds(1.25f);
			CooldownFinished();
		}
	}
}
