using UnityEngine;
using VampireSurvivors.App.Framework;
using Zenject;

namespace VampireSurvivors.Installers
{
	public class MainMenuInstaller : MonoInstaller<MainMenuInstaller>
	{
		[SerializeField]
		private BestiaryFactory _BestiaryFactory;

		public override void InstallBindings()
		{
		}
	}
}
