using UnityEngine;
using UnityEngine.Rendering;
using Zenject;

namespace Player
{
	public class PlayerDrinkVolume : MonoInstaller
	{
		[SerializeField]
		private Volume _needsVolume;

		public void SetWeight(float value)
		{
			_needsVolume.weight = value;
		}

		public override void InstallBindings()
		{
			base.Container.Bind<PlayerDrinkVolume>().FromInstance(this).AsSingle();
		}
	}
}
