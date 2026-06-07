using System;
using Infrastructure.Services;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace UI
{
	public class TutorialCreativeModeUI : MonoBehaviour
	{
		private void Start()
		{
			if (AllServices.Container.Single<IPersistentProgressService>().Progress.IsFirstLaunchCreativeMode)
			{
				AllServices.Container.Single<IPersistentProgressService>().Progress.IsFirstLaunchCreativeMode = false;
				Show();
			}
			else
			{
				Hide();
			}
			InputManager.Instance.OnEscape += OnEscapeButton;
		}

		private void OnDestroy()
		{
			InputManager.Instance.OnEscape -= OnEscapeButton;
		}

		private void OnEscapeButton(object sender, EventArgs e)
		{
			if (base.isActiveAndEnabled)
			{
				Hide();
			}
		}

		public void Show()
		{
			base.gameObject.SetActive(value: true);
		}

		public void Hide()
		{
			base.gameObject.SetActive(value: false);
		}

		public void ToggleWindow()
		{
			if (base.isActiveAndEnabled)
			{
				Hide();
			}
			else
			{
				Show();
			}
		}
	}
}
