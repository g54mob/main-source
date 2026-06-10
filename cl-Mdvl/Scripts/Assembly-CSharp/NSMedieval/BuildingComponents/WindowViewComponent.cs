using System;
using NSMedieval.Enums;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(WindowComponent))]
	public class WindowViewComponent : ComponentBaseView
	{
		[NonSerialized]
		private WindowComponent windowComponent;

		[SerializeField]
		private GameObject closedContent;

		public override void PreSpawnInitialization()
		{
			base.PreSpawnInitialization();
			windowComponent = GetComponent<WindowComponent>();
		}

		protected override void OnComponentEnterFinishedState(bool afterLoading = false)
		{
			windowComponent.WindowLockStatusChangedEvent += OnLockStatusChanged;
			OnLockStatusChanged();
			base.OnComponentEnterFinishedState(afterLoading);
		}

		protected override void OnBuildingDisposed(IDisposable disposable)
		{
			closedContent.SetActive(value: false);
		}

		private void OnLockStatusChanged()
		{
			closedContent.SetActive(windowComponent.ComponentInstance.LockState == LockState.Locked);
		}
	}
}
