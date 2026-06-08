using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dorfromantik.UI.MainMenu
{
	public class ConfirmationScreen : MonoBehaviour
	{
		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

			public static UnityAction _003C_003E9__10_0;

			internal void _003CAwake_003Eb__10_0()
			{
				Singleton<MainMenuUi>.Instance.CancelMenu();
			}
		}

		public ConfirmationScreenType type;

		[SerializeField]
		public GameObject defaultSelectableParent;

		[SerializeField]
		public Selectable defaultSelectable;

		[SerializeField]
		private List<Button> buttonsThatDontCancelMenuWhenPressed;

		public ConfirmationScreenType previousScreen;

		private Button[] buttons;

		private bool _003CShown_003Ek__BackingField;

		public bool Shown
		{
			get
			{
				return _003CShown_003Ek__BackingField;
			}
			private set
			{
				_003CShown_003Ek__BackingField = value;
			}
		}

		private void Awake()
		{
			buttons = GetComponentsInChildren<Button>();
			Button[] array = buttons;
			foreach (Button button in array)
			{
				if (!buttonsThatDontCancelMenuWhenPressed.Contains(button))
				{
					button.onClick.AddListener(delegate
					{
						Singleton<MainMenuUi>.Instance.CancelMenu();
					});
				}
			}
		}

		public void HideConfirmationScreen(bool returnToPreviousScreen)
		{
			Singleton<MainMenuUi>.Instance.ShowConfirmationScreen(returnToPreviousScreen ? previousScreen : ConfirmationScreenType.None);
		}

		public void Show(bool newShow)
		{
			if (newShow)
			{
				base.gameObject.SetActive(value: true);
			}
			Tween t = ShortcutExtensions.DOScale(base.transform, newShow ? 1 : 0, 0.5f);
			if (!newShow)
			{
				TweenSettingsExtensions.OnComplete(t, delegate
				{
					base.gameObject.SetActive(value: false);
				});
			}
			if ((bool)defaultSelectableParent)
			{
				defaultSelectable = defaultSelectableParent.GetComponentInChildren<Selectable>();
			}
			else if ((bool)defaultSelectable)
			{
				defaultSelectable.Select();
			}
		}

		private void OnEnable()
		{
			Shown = true;
		}

		private void OnDisable()
		{
			Shown = false;
		}

		private void _003CShow_003Eb__12_0()
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
