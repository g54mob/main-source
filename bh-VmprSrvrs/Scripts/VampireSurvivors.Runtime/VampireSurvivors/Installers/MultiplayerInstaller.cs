using UnityEngine;
using VampireSurvivors.Framework;
using Zenject;

namespace VampireSurvivors.Installers
{
	public class MultiplayerInstaller : MonoInstaller<MultiplayerInstaller>
	{
		[SerializeField]
		private CoopConfig _CoopConfig;

		public override void InstallBindings()
		{
		}
	}
}
