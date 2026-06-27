using System;
using Restory.Infrastructure.CommonServices;
using Restory.UI.Views.DayEndWindow;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.EndOfDay
{
	[Serializable]
	public class DayEndCursorInstaller : Installer
	{
		[SerializeField]
		private GameObject prefab;

		public override void InstallBindings()
		{
			GameObject gameObject = base.Container.InstantiateAndQueueForInject(prefab);
			base.Container.BindInterfacesAndSelfTo<MenuCursorDetector>().FromComponentOn(gameObject).AsSingle();
			base.Container.Bind<DayEndSceneCursorView>().FromComponentOn(gameObject).AsSingle();
		}
	}
}
