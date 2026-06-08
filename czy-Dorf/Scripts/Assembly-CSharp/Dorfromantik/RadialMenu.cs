using System;
using System.Collections.Generic;
using DG.Tweening;
using Dorfromantik.UI.Components;
using LeTai.Asset.TranslucentImage;
using TMPro;
using UnityEngine;

namespace Dorfromantik
{
	public class RadialMenu : MonoBehaviour
	{
		[SerializeField]
		private List<RadialMenuSection> menuSections;

		[SerializeField]
		private RadialMenuSection centerSection;

		[SerializeField]
		private TextMeshProUGUI selectionDescription;

		[SerializeField]
		private GameObject radialMenuVisual;

		[SerializeField]
		private float joystickDeadzone = 0.1f;

		[SerializeField]
		private InputRouter inputRouter;

		[SerializeField]
		private float appearDuration = 0.3f;

		[SerializeField]
		private float confirmationDelay = 0.5f;

		private Tween scaleTween;

		private bool isActive;

		private RadialMenuSection selectedRadialSection;

		private GameState rememberInputState;

		public RadialMenuSection SelectedRadialSection => selectedRadialSection;

		private void Awake()
		{
			inputRouter.OnShowRadialMenu += Show;
			inputRouter.OnToggleRadialMenu += Toggle;
			inputRouter.OnRadialMenuInput += ChangeRadialSelection;
			inputRouter.OnRadialMenuSubmit += SubmitRadialSelection;
			ShortcutExtensions.DOScale(base.transform, 0f, 0f);
			radialMenuVisual.SetActive(value: false);
		}

		public void SubmitRadialSelection()
		{
			if ((bool)selectedRadialSection && selectedRadialSection != centerSection)
			{
				scaleTween = TweenSettingsExtensions.SetDelay(ShortcutExtensions.DOScale(base.transform, 0f, appearDuration), confirmationDelay);
				Tween tween = scaleTween;
				tween.onComplete = (TweenCallback)Delegate.Combine(tween.onComplete, new TweenCallback(HideRadialMenu));
				selectedRadialSection.Submit();
				inputRouter.SetInputState(GameState.Playing);
				isActive = false;
			}
		}

		public void Toggle()
		{
			Show(!isActive, executeSelectedCommand: false);
		}

		public void Show(bool show, bool executeSelectedCommand)
		{
			if (show)
			{
				if (inputRouter.GameState == GameState.Playing)
				{
					radialMenuVisual.SetActive(value: true);
					rememberInputState = inputRouter.GameState;
					Tween tween = scaleTween;
					if (tween != null)
					{
						TweenExtensions.Kill(tween);
					}
					scaleTween = ShortcutExtensions.DOScale(base.transform, 1f, appearDuration);
					inputRouter.SetInputState(GameState.RadialMenu);
					isActive = true;
				}
			}
			else if (executeSelectedCommand && inputRouter.GameState == GameState.RadialMenu && selectedRadialSection != null && selectedRadialSection != centerSection && !selectedRadialSection.isEmpty)
			{
				scaleTween = TweenSettingsExtensions.SetDelay(ShortcutExtensions.DOScale(base.transform, 0f, appearDuration), confirmationDelay);
				Tween tween2 = scaleTween;
				tween2.onComplete = (TweenCallback)Delegate.Combine(tween2.onComplete, new TweenCallback(HideRadialMenu));
				selectedRadialSection.Submit();
				if (inputRouter.GameState == GameState.RadialMenu)
				{
					inputRouter.SetInputState(GameState.Playing);
				}
				isActive = false;
			}
			else
			{
				Tween tween3 = scaleTween;
				if (tween3 != null)
				{
					TweenExtensions.Kill(tween3);
				}
				scaleTween = ShortcutExtensions.DOScale(base.transform, 0f, appearDuration);
				Tween tween4 = scaleTween;
				tween4.onComplete = (TweenCallback)Delegate.Combine(tween4.onComplete, new TweenCallback(HideRadialMenu));
				inputRouter.SetInputState(GameState.Playing);
				isActive = false;
			}
		}

		private void HideRadialMenu()
		{
			radialMenuVisual.SetActive(value: false);
			SelectSection(centerSection);
		}

		private void ChangeRadialSelection(Vector2 joystickDirection)
		{
			if (isActive)
			{
				RadialMenuSection radialMenuSection = null;
				if (joystickDirection.magnitude > joystickDeadzone)
				{
					int index = Mathf.FloorToInt((0f - Vector2.SignedAngle(Vector2.up, joystickDirection) + 360f / (float)menuSections.Count + 360f) % 360f / (360f / (float)menuSections.Count));
					radialMenuSection = menuSections[index];
				}
				if (!(selectedRadialSection == radialMenuSection))
				{
					SelectSection(radialMenuSection);
				}
			}
		}

		public void SelectSection(RadialMenuSection targetSection)
		{
			if ((bool)selectedRadialSection)
			{
				selectedRadialSection.Select(shouldSelect: false);
			}
			if ((bool)targetSection)
			{
				targetSection.Select(shouldSelect: true);
			}
			string targetText = ((targetSection == null) ? "" : LocalizationManager.Instance.GetLocalizedValue(targetSection.descriptionLocalizationKey));
			LocalizationManager.Instance.UpdateTextMesh(selectionDescription, LocalizedFontStyle.ExtraBold, targetText);
			selectedRadialSection = targetSection;
		}

		private void SetupSections()
		{
			for (int i = 0; i < menuSections.Count; i++)
			{
				if ((bool)menuSections[i])
				{
					menuSections[i].transform.rotation = Quaternion.AngleAxis(360f / (float)menuSections.Count * (float)i, Vector3.back);
					menuSections[i].GetComponentInChildren<TranslucentImage>().fillAmount = 1f / (float)menuSections.Count;
					if ((bool)menuSections[i].GetComponentInChildren<UiIconButtonIngame>())
					{
						menuSections[i].GetComponentInChildren<UiIconButtonIngame>().transform.rotation = Quaternion.identity;
					}
				}
			}
		}

		private void OnDestroy()
		{
			inputRouter.OnShowRadialMenu -= Show;
			inputRouter.OnRadialMenuInput -= ChangeRadialSelection;
			inputRouter.OnToggleRadialMenu -= Toggle;
			inputRouter.OnRadialMenuSubmit -= SubmitRadialSelection;
		}
	}
}
