using Restory.UI.Presenters.PauseMenu;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameOverlay
{
	public class GUI_PauseMenuInstaller : MonoInstaller
	{
		[SerializeField]
		private GameObject pauseMenuPrefab;

		public override void InstallBindings()
		{
			base.Container.BindInterfacesAndSelfTo<GUI_PauseMenu>().FromMethod(Method).AsSingle();
		}

		private GUI_PauseMenu Method(InjectContext c)
		{
			return c.Container.InstantiatePrefab(pauseMenuPrefab).GetComponentInChildren<GUI_PauseMenu>(includeInactive: true);
		}
	}
}
