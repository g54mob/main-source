using UnityEngine;
using VampireSurvivors.App.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.DLC;
using Zenject;

namespace VampireSurvivors.Installers
{
	public class CoreInstaller : MonoInstaller<CoreInstaller>
	{
		[SerializeField]
		private GameObject _Graphy;

		[SerializeField]
		private GameObject _InGameDebugConsole;

		[SerializeField]
		private DlcCatalog _DlcCatalog;

		[SerializeField]
		private BaseGameData _BaseGameData;

		[SerializeField]
		private MainMenuBackgroundFactory _MainMenuBackgroundFactory;

		public void Awake()
		{
		}

		public override void InstallBindings()
		{
		}

		private void SetupGraphics()
		{
		}

		private static void SetupOrientations()
		{
		}

		private static void UpdateLogging()
		{
		}
	}
}
