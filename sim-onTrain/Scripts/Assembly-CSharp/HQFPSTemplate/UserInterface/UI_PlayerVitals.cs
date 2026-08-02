using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HQFPSTemplate.UserInterface
{
	public class UI_PlayerVitals : UserInterfaceBehaviour
	{
		[Serializable]
		private class PlayerStatHUD
		{
			public bool hideOnNonUse;

			[SerializeField]
			private Image m_StatBar;

			[SerializeField]
			private Image m_StatBarBG;

			[SerializeField]
			private CanvasGroup m_CanvasGroup;

			[SerializeField]
			private Gradient m_StatColorOverTime;

			[Space]
			[SerializeField]
			private bool m_FastChangeBarEnabled;

			[SerializeField]
			[ShowIf("m_FastChangeBarEnabled", true, 10f)]
			[Range(0.01f, 100f)]
			private float m_FastChangeThreshold = 15f;

			[SerializeField]
			[ShowIf("m_FastChangeBarEnabled", true, 10f)]
			private float m_FastChangeBarStay = 1f;

			[SerializeField]
			[ShowIf("m_FastChangeBarEnabled", true, 10f)]
			[Range(0.01f, 1f)]
			private float m_FastChangeBarSpeed = 0.1f;

			[SerializeField]
			[ShowIf("m_FastChangeBarEnabled", true, 10f)]
			private Image m_FastChangeBar;

			[Space]
			[SerializeField]
			private bool m_AnimateStatBarBG;

			[SerializeField]
			[ShowIf("m_AnimateStatBarBG", true, 10f)]
			[Range(0.01f, 1f)]
			private float m_StatBGAnimSpeed = 0.1f;

			[SerializeField]
			[ShowIf("m_AnimateStatBarBG", true, 10f)]
			private Gradient m_StatBGColorOverTime;

			[Space]
			[Header("Hide/Show Settings")]
			[SerializeField]
			[ShowIf("hideOnNonUse", true, 10f)]
			private float m_HideDelay = 3f;

			[SerializeField]
			[ShowIf("hideOnNonUse", true, 10f)]
			private float m_FadeSpeed = 2f;

			private Value<float> m_AttachedStatValue;

			private float m_CurrentAnimStatus;

			private float m_NextTimeRestoreFastChangeBar;

			private bool m_FastChangeBarActive;

			private float m_LastValueChangeTime;

			private bool m_IsVisible = true;

			private Coroutine m_FadeCoroutine;

			private MonoBehaviour m_CoroutineRunner;

			private int m_FrameCounter;

			public void UpdateHUD()
			{
				m_FrameCounter++;
				if (m_AttachedStatValue.Val < 100f)
				{
					if (m_AnimateStatBarBG)
					{
						m_CurrentAnimStatus = Mathf.MoveTowards(m_CurrentAnimStatus, 1f, m_StatBGAnimSpeed / 100f);
						if (Mathf.Abs(1f - m_CurrentAnimStatus) < 0.01f)
						{
							m_CurrentAnimStatus = 0f;
						}
						m_StatBarBG.color = m_StatBGColorOverTime.Evaluate(m_CurrentAnimStatus);
					}
					if (m_FastChangeBarActive && m_NextTimeRestoreFastChangeBar < Time.time)
					{
						m_FastChangeBar.fillAmount = Mathf.MoveTowards(m_FastChangeBar.fillAmount, 0f, m_FastChangeBarSpeed / 100f);
						if (Mathf.Abs(m_FastChangeBar.fillAmount - m_StatBar.fillAmount) < Mathf.Epsilon)
						{
							m_FastChangeBarActive = false;
						}
					}
				}
				CheckHideOnNonUse();
			}

			public bool TryInitialize(Value<float> eventValue, MonoBehaviour coroutineRunner)
			{
				if (m_StatBar == null)
				{
					return false;
				}
				m_AttachedStatValue = eventValue;
				m_CoroutineRunner = coroutineRunner;
				m_AttachedStatValue.AddChangeListener(OnValueChange);
				m_LastValueChangeTime = Time.time;
				if (m_CanvasGroup != null)
				{
					ShowCanvasGroup();
				}
				OnValueChange(eventValue.Val);
				return true;
			}

			private void OnValueChange(float statValue)
			{
				float num = statValue / 100f;
				float num2 = m_AttachedStatValue.GetPreviousValue() / 100f;
				m_StatBar.fillAmount = num;
				m_StatBar.color = m_StatColorOverTime.Evaluate(num);
				if (m_FastChangeBarEnabled && m_FastChangeBar != null && num2 - num > m_FastChangeThreshold / 100f)
				{
					m_FastChangeBar.fillAmount = num2;
					m_NextTimeRestoreFastChangeBar = Time.time + m_FastChangeBarStay;
					m_FastChangeBarActive = true;
				}
				m_LastValueChangeTime = Time.time;
				if (hideOnNonUse && !m_IsVisible)
				{
					ShowCanvasGroup();
				}
			}

			private void CheckHideOnNonUse()
			{
				if (hideOnNonUse && !(m_CanvasGroup == null) && m_IsVisible && Time.time - m_LastValueChangeTime >= m_HideDelay)
				{
					HideCanvasGroup();
				}
			}

			private void ShowCanvasGroup()
			{
				if (!(m_CanvasGroup == null))
				{
					m_IsVisible = true;
					if (m_FadeCoroutine != null)
					{
						m_CoroutineRunner.StopCoroutine(m_FadeCoroutine);
					}
					m_FadeCoroutine = m_CoroutineRunner.StartCoroutine(FadeCanvasGroup(1f));
				}
			}

			private void HideCanvasGroup()
			{
				if (!(m_CanvasGroup == null))
				{
					m_IsVisible = false;
					if (m_FadeCoroutine != null)
					{
						m_CoroutineRunner.StopCoroutine(m_FadeCoroutine);
					}
					m_FadeCoroutine = m_CoroutineRunner.StartCoroutine(FadeCanvasGroup(0f));
				}
			}

			private IEnumerator FadeCanvasGroup(float targetAlpha)
			{
				float startAlpha = m_CanvasGroup.alpha;
				float elapsed = 0f;
				while (elapsed < 1f)
				{
					elapsed += Time.deltaTime * m_FadeSpeed;
					m_CanvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsed);
					yield return null;
				}
				m_CanvasGroup.alpha = targetAlpha;
				m_FadeCoroutine = null;
			}
		}

		[SerializeField]
		[Group]
		private PlayerStatHUD m_HealthHUD = new PlayerStatHUD();

		[SerializeField]
		[Group]
		private PlayerStatHUD m_StaminaHUD = new PlayerStatHUD();

		[SerializeField]
		[Group]
		private PlayerStatHUD m_FoodHud = new PlayerStatHUD();

		private List<PlayerStatHUD> m_PlayerVitalSettings = new List<PlayerStatHUD>();

		private void Start()
		{
			OnPostAttachment();
		}

		public override void OnPostAttachment()
		{
			if (base.Player == null)
			{
				Debug.LogError("[UI DEBUG] HATA! Player NULL! UI başlatılamıyor!");
			}
			else if (m_StaminaHUD.TryInitialize(base.Player.Stamina, this))
			{
				m_PlayerVitalSettings.Add(m_StaminaHUD);
			}
			else
			{
				Debug.LogError("[UI DEBUG] HATA! Stamina HUD başlatılamadı!");
			}
		}

		private void Update()
		{
			foreach (PlayerStatHUD playerVitalSetting in m_PlayerVitalSettings)
			{
				playerVitalSetting.UpdateHUD();
			}
		}
	}
}
