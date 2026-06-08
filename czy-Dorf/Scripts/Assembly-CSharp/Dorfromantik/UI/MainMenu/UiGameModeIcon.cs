using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Dorfromantik.UI.MainMenu
{
	public class UiGameModeIcon : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler
	{
		[SerializeField]
		private bool shouldAlsoAffectTexts;

		[SerializeField]
		private List<TextMeshProUGUI> texts;

		[SerializeField]
		internal UiGameModeContainer gameModeContainer;

		[SerializeField]
		internal GameObject contentContainer;

		[SerializeField]
		internal GameMode gameMode;

		[SerializeField]
		private Sprite highlightSprite;

		[SerializeField]
		private Image underline;

		[SerializeField]
		private Image iconImage;

		[SerializeField]
		private UnityEvent onClick;

		[SerializeField]
		private AudioClipOptions clickSound;

		[SerializeField]
		private AudioClipOptions hoverSound;

		[SerializeField]
		private UiVisualState currentUiVisualState;

		[SerializeField]
		private bool isContentVisible;

		private Sprite defaultSprite;

		public void Awake()
		{
			if (iconImage == null)
			{
				iconImage = Enumerable.Single(GetComponentsInChildren<Image>(includeInactive: true));
			}
			defaultSprite = iconImage.sprite;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			SetVisualState(UiVisualState.Highlighted);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			SetVisualState((!(gameModeContainer.activeGameMode != gameMode)) ? UiVisualState.Active : UiVisualState.Default);
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			gameModeContainer.SelectGameMode(gameMode);
			SetVisualState(UiVisualState.Active);
			onClick?.Invoke();
		}

		internal void SetVisualState(UiVisualState uiVisualState, bool isInitialCall = false)
		{
			if (currentUiVisualState == uiVisualState && !isInitialCall)
			{
				return;
			}
			underline.gameObject.SetActive(gameModeContainer.activeGameMode == gameMode);
			gameModeContainer.SetVisibilityForContentContainers(this, uiVisualState != UiVisualState.Default);
			iconImage.sprite = ((uiVisualState == UiVisualState.Default) ? defaultSprite : highlightSprite);
			iconImage.color = ((uiVisualState == UiVisualState.Highlighted) ? Constants.UI.Colors.SelectedBlack : Color.white);
			if (shouldAlsoAffectTexts)
			{
				SetContentContainerTextsColor(iconImage.color);
			}
			switch (uiVisualState)
			{
			case UiVisualState.Highlighted:
				if (AudioManager.Instance != null)
				{
					AudioManager.Instance.PlayGlobalSound(hoverSound);
				}
				break;
			case UiVisualState.Active:
				if (AudioManager.Instance != null)
				{
					AudioManager.Instance.PlayGlobalSound(clickSound);
				}
				break;
			default:
				throw new ArgumentOutOfRangeException("uiVisualState", uiVisualState, null);
			case UiVisualState.Default:
				break;
			}
			currentUiVisualState = uiVisualState;
		}

		internal void SetContentContainerVisible(bool shouldBeVisible)
		{
			contentContainer.SetActive(shouldBeVisible);
			isContentVisible = shouldBeVisible;
		}

		private bool IsActiveGameMode()
		{
			return gameMode.id == (GameModeId)PlayerPrefsAccessor.GetInt("LastPlayedGameMode", 0);
		}

		private void SetContentContainerTextsColor(Color color)
		{
			foreach (TextMeshProUGUI text in texts)
			{
				text.color = color;
			}
		}
	}
}
