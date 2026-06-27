using Restory.Audio;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.EndOfDay
{
	public class EndOfDayBackgroundSoundsInstaller : MonoInstaller
	{
		[SerializeField]
		private SoundLoopEmitter cityAmbientSoundLoopEmitterPrefab;

		public override void InstallBindings()
		{
			base.Container.InstantiateAndQueueForInject(cityAmbientSoundLoopEmitterPrefab.gameObject);
		}
	}
}
