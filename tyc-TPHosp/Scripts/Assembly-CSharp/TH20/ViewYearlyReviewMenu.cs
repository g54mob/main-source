using System;
using JetBrains.Annotations;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	[DontSave]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ViewYearlyReviewMenu : AnimatedMenuBase
	{
		[SerializeField]
		private DynamicButton _closeButton;

		[SerializeField]
		private DynamicButton _viewButton;

		[SerializeField]
		private TMP_Text _countdownText;

		[SerializeField]
		private RuntimeAnimatorController _advisorAnimationController;

		private Level _level;

		private float _timeRemaining;

		private ButtonAnimator _closeButtonAnimator;

		private ButtonAnimator _viewButtonAnimator;

		private Action _openYearlyReview;

		private AdvisorPortraitScene _advisorPortraitScene;

		public void Setup(Level level, Action openYearlyReview)
		{
			_level = level;
			_openYearlyReview = openYearlyReview;
			AdvisorMenu advisorMenu = _level.HUD.FindMenu<AdvisorMenu>();
			if (advisorMenu != null)
			{
				_advisorPortraitScene = advisorMenu.AdvisorPortraitScene;
				if ((bool)_advisorPortraitScene)
				{
					_advisorPortraitScene.ShowAdvisorModel(_advisorAnimationController);
				}
			}
			_timeRemaining = 10f;
			_countdownText.text = ((int)_timeRemaining).ToString();
			_viewButton.onPrimaryDown.AddListener(OpenOverviewMenu);
			_closeButton.onPrimaryDown.AddListener(OnCloseMenuClicked);
			_closeButtonAnimator = _closeButton.GetComponent<ButtonAnimator>();
			_viewButtonAnimator = _viewButton.GetComponent<ButtonAnimator>();
		}

		private void OpenOverviewMenu()
		{
			base.HUD.DestroyMenu(this);
			_openYearlyReview.InvokeSafe();
		}

		private void OnCloseMenuClicked()
		{
			_level.HospitalAwardsManager.ProcessEndOfYearAwardsSilently();
			CloseMenu();
		}

		protected override void Update()
		{
			base.Update();
			if (_level.GameTime.IsSuperPaused || _level.GameTime.IsPausedByUser || _level.GameTime.IsPausedByMenu || _level.HUD.IsPauseTimeMenuOpen)
			{
				SetButtonInteractable(interactable: false);
				return;
			}
			SetButtonInteractable(interactable: true);
			if (_timeRemaining > 0f)
			{
				_timeRemaining -= Time.unscaledDeltaTime;
				if (_timeRemaining <= 0f)
				{
					_timeRemaining = 0f;
					_advisorPortraitScene.PopDownAdvisor();
				}
				_countdownText.text = ((int)_timeRemaining).ToString();
			}
			else
			{
				_timeRemaining -= Time.unscaledDeltaTime;
				if (_timeRemaining <= 1f)
				{
					OpenOverviewMenu();
				}
			}
		}

		private void SetButtonInteractable(bool interactable)
		{
			GameObjectUtils.SetInteractable(_closeButton, interactable);
			GameObjectUtils.SetInteractable(_viewButton, interactable);
			if (_closeButtonAnimator != null)
			{
				_closeButtonAnimator.CurrentState = ((!interactable) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
			}
			if (_viewButtonAnimator != null)
			{
				_viewButtonAnimator.CurrentState = ((!interactable) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
			}
		}
	}
}
