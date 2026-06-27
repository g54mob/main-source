using System;
using Restory.UI.Presenters.ToDoList;
using Restory.UI.Views.ToDoList;
using Restory.UserInterface.GameplayOverlay;
using UnityEngine;
using Zenject;

namespace Restory.Infrastructure.SceneInstallers.GameMechanics.Overlay
{
	[Serializable]
	public class GUI_ToDoListWindowInstaller : Installer
	{
		[SerializeField]
		private GUI_ToDoList toDoListPrefab;

		[SerializeField]
		private GUI_ToDoItemView toDoItemViewPrefab;

		public override void InstallBindings()
		{
			base.Container.Bind<GUI_ToDoList>().FromComponentInNewPrefab(toDoListPrefab).UnderTransform(GetCanvas)
				.AsSingle()
				.NonLazy();
			base.Container.Bind<GUI_ToDoItemViewPool>().AsSingle().WithArguments(toDoItemViewPrefab.gameObject);
		}

		private Transform GetCanvas(InjectContext c)
		{
			return c.Container.Resolve<GUI_GameplayOverlayCanvas>().transform;
		}
	}
}
