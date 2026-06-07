using System;
using DG.Tweening;
using Dhs5.Utility.Updates;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator
{
	public class LoadingScreen : TransientManager<LoadingScreen>
	{
		[SerializeField]
		protected Canvas m_canvas;

		[SerializeField]
		protected CanvasGroup m_group;

		[SerializeField]
		protected Image m_loadingImage;

		private Tween m_tween;

		protected float m_updateTime;

		public static bool IsAppearing { get; private set; }

		public static bool IsDisappearing { get; private set; }

		public static bool IsDisplayed { get; private set; }

		public static event Action StartedShow;

		public static event Action CompletedShow;

		public static event Action StartedHide;

		public static event Action CompletedHide;

		public void Show()
		{
			if (!IsAppearing && !IsDisplayed)
			{
				RegisterUpdate(register: true);
				m_tween.Kill();
				m_tween = null;
				m_tween = m_group.DOFade(1f, 0.25f).SetUpdate(isIndependentUpdate: true).OnPlay(OnStartShow)
					.OnComplete(OnCompleteShow)
					.Play();
			}
		}

		public void Hide()
		{
			if (!IsDisappearing && IsDisplayed)
			{
				RegisterUpdate(register: false);
				m_tween.Kill();
				m_tween = null;
				m_tween = m_group.DOFade(0f, 1f).SetUpdate(isIndependentUpdate: true).OnPlay(OnStartHide)
					.OnComplete(OnCompleteHide)
					.Play();
			}
		}

		protected void RegisterUpdate(bool register)
		{
			m_updateTime = 0f;
			Updater.RegisterChannelCallback(register, EUpdateChannel.CLASSIC, OnUpdateProgress);
		}

		protected virtual void OnUpdateProgress(float deltaTime)
		{
			m_updateTime += deltaTime;
			if (m_updateTime > 0.25f)
			{
				m_updateTime -= 0.25f;
				m_loadingImage.rectTransform.Rotate(new Vector3(0f, 0f, 1f), -36f);
			}
		}

		private void OnStartShow()
		{
			m_group.blocksRaycasts = true;
			IsDisplayed = true;
			IsAppearing = true;
			LoadingScreen.StartedShow?.Invoke();
		}

		private void OnCompleteShow()
		{
			IsAppearing = false;
			LoadingScreen.CompletedShow?.Invoke();
		}

		private void OnStartHide()
		{
			IsDisappearing = true;
			LoadingScreen.StartedHide?.Invoke();
		}

		private void OnCompleteHide()
		{
			m_group.blocksRaycasts = false;
			IsDisplayed = false;
			IsDisappearing = false;
			LoadingScreen.CompletedHide?.Invoke();
		}
	}
}
