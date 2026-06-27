using System;
using System.Collections;
using Restory.Data.Devices.Quality;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Effects
{
	public class VfxService : MonoBehaviour, IInitializable
	{
		private VfxFactory vfxFactory;

		public event Action<DeviceQualityBase> OnCheckDeviceEffectTriggered;

		[Inject]
		private void Construct(VfxFactory vfxFactory)
		{
			this.vfxFactory = vfxFactory;
		}

		public void Initialize()
		{
			vfxFactory.Init(base.transform);
		}

		public void PlayCheckDeviceEffect(Transform vfxPoint, DeviceQualityBase quality)
		{
			CheckDeviceEffect effect = vfxFactory.GetCheckDeviceEffect(vfxPoint);
			effect.Play(quality, delegate
			{
				vfxFactory.ReleaseCheckDeviceEffect(effect);
			});
			this.OnCheckDeviceEffectTriggered?.Invoke(quality);
		}

		public void PlayPlacementEffect(Transform vfxPoint)
		{
			StartCoroutine(PlayPlacementEffectCoroutine(vfxPoint));
		}

		public void PlaySootCleaningEffect(Transform vfxPoint)
		{
			StartCoroutine(PlaySootCleaningEffectCoroutine(vfxPoint));
		}

		public void PlaySolderingEffect(Transform vfxPoint)
		{
			StartCoroutine(PlaySolderingEffectCoroutine(vfxPoint));
		}

		public void PlayDestroyEffect(Transform vfxPoint)
		{
			StartCoroutine(PlayDestroyEffectCoroutine(vfxPoint));
		}

		public void PlayMoneyEffect(Transform vfxPoint)
		{
			StartCoroutine(PlayMoneyEffectCoroutine(vfxPoint));
		}

		private IEnumerator PlayPlacementEffectCoroutine(Transform vfxPoint)
		{
			yield return null;
			if ((bool)vfxPoint)
			{
				ParticleSystem effect = vfxFactory.GetPlacementEffect(vfxPoint);
				effect.Play();
				ParticleSystem.MainModule main = effect.main;
				float seconds = main.duration + main.startLifetime.constantMax;
				yield return new WaitForSeconds(seconds);
				vfxFactory.ReleasePlacementEffect(effect);
			}
		}

		private IEnumerator PlaySootCleaningEffectCoroutine(Transform vfxPoint)
		{
			ParticleSystem effect = vfxFactory.GetSootCleaningEffect(vfxPoint);
			effect.Play();
			ParticleSystem.MainModule main = effect.main;
			float seconds = main.duration + main.startLifetime.constantMax;
			yield return new WaitForSeconds(seconds);
			vfxFactory.ReleaseSootCleaningEffect(effect);
		}

		private IEnumerator PlaySolderingEffectCoroutine(Transform vfxPoint)
		{
			ParticleSystem effect = vfxFactory.GetSolderingEffect(vfxPoint);
			effect.Play();
			ParticleSystem.MainModule main = effect.main;
			float seconds = main.duration + main.startLifetime.constantMax;
			yield return new WaitForSeconds(seconds);
			vfxFactory.ReleaseSolderingEffect(effect);
		}

		private IEnumerator PlayDestroyEffectCoroutine(Transform vfxPoint)
		{
			ParticleSystem effect = vfxFactory.GetPlacementEffect(vfxPoint);
			effect.Play();
			ParticleSystem.MainModule main = effect.main;
			float seconds = main.duration + main.startLifetime.constantMax;
			yield return new WaitForSeconds(seconds);
			vfxFactory.ReleasePlacementEffect(effect);
		}

		private IEnumerator PlayMoneyEffectCoroutine(Transform vfxPoint)
		{
			yield return null;
			if ((bool)vfxPoint)
			{
				ParticleSystem effect = vfxFactory.GetMoneyEffect(vfxPoint);
				effect.Play();
				ParticleSystem.MainModule main = effect.main;
				float seconds = main.duration + main.startLifetime.constantMax;
				yield return new WaitForSeconds(seconds);
				vfxFactory.ReleaseMoneyEffect(effect);
			}
		}
	}
}
