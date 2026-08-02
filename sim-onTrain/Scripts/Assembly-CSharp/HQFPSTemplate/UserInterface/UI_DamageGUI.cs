using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace HQFPSTemplate.UserInterface
{
	public class UI_DamageGUI : UserInterfaceBehaviour
	{
		[Serializable]
		public class ImageFader
		{
			[SerializeField]
			private Image m_Image;

			[SerializeField]
			[Range(0f, 1f)]
			private float m_MinAlpha = 0.4f;

			[SerializeField]
			[Range(0f, 100f)]
			private float m_FadeInSpeed = 25f;

			[SerializeField]
			[Range(0f, 100f)]
			private float m_FadeOutSpeed = 0.3f;

			[SerializeField]
			[Range(0f, 10f)]
			private float m_FadeOutPause = 0.5f;

			private Coroutine m_FadeHandler;

			public bool Fading { get; private set; }

			public void DoFadeCycle(MonoBehaviour parent, float targetAlpha)
			{
				if (m_Image == null)
				{
					Debug.LogError("[ImageFader] - The image to fade is not assigned!");
					return;
				}
				targetAlpha = Mathf.Clamp01(Mathf.Max(Mathf.Abs(targetAlpha), m_MinAlpha));
				if (m_FadeHandler != null)
				{
					parent.StopCoroutine(m_FadeHandler);
				}
				m_FadeHandler = parent.StartCoroutine(C_DoFadeCycle(targetAlpha));
			}

			private IEnumerator C_DoFadeCycle(float targetAlpha)
			{
				Fading = true;
				while (Mathf.Abs(m_Image.color.a - targetAlpha) > 0.01f)
				{
					m_Image.color = Color.Lerp(m_Image.color, new Color(m_Image.color.r, m_Image.color.g, m_Image.color.b, targetAlpha), m_FadeInSpeed * Time.deltaTime);
					yield return null;
				}
				m_Image.color = new Color(m_Image.color.r, m_Image.color.g, m_Image.color.b, targetAlpha);
				if (m_FadeOutPause > 0f)
				{
					yield return new WaitForSeconds(m_FadeOutPause);
				}
				while (m_Image.color.a > 0.01f)
				{
					m_Image.color = Color.Lerp(m_Image.color, new Color(m_Image.color.r, m_Image.color.g, m_Image.color.b, 0f), m_FadeOutSpeed * Time.deltaTime);
					yield return null;
				}
				m_Image.color = new Color(m_Image.color.r, m_Image.color.g, m_Image.color.b, 0f);
				Fading = false;
			}
		}

		[BHeader("Blood Screen...")]
		[SerializeField]
		private ImageFader m_BloodScreenFader;

		[Space]
		[BHeader("Damage Indicator...", order = 100)]
		[SerializeField]
		private RectTransform m_DamageIndicatorRT;

		[SerializeField]
		private ImageFader m_DamageIndicatorFader;

		[SerializeField]
		[Clamp(0f, 512f)]
		[Tooltip("Damage indicator distance (in pixels) from the screen center.")]
		private int m_DamageIndicatorDistance = 128;

		private Vector3 m_LastHitPoint;

		public override void OnPostAttachment()
		{
			base.Player.ChangeHealth.AddListener(OnHealthChanged);
		}

		private void Update()
		{
			if (m_DamageIndicatorFader.Fading)
			{
				Vector3 normalized = Vector3.ProjectOnPlane(base.Player.LookDirection.Get(), Vector3.up).normalized;
				Vector3 normalized2 = Vector3.ProjectOnPlane(m_LastHitPoint - base.Player.transform.position, Vector3.up).normalized;
				Vector3 lhs = Vector3.Cross(normalized, Vector3.up);
				float num = Vector3.Angle(normalized, normalized2) * Mathf.Sign(Vector3.Dot(lhs, normalized2));
				m_DamageIndicatorRT.localEulerAngles = Vector3.forward * num;
				m_DamageIndicatorRT.localPosition = m_DamageIndicatorRT.up * m_DamageIndicatorDistance;
			}
		}

		private void OnHealthChanged(DamageInfo dmgInfo)
		{
			if (dmgInfo.Delta < 0f)
			{
				if (base.Player.Health.Val > 0f)
				{
					m_BloodScreenFader.DoFadeCycle(this, dmgInfo.Delta / 100f);
				}
				if (dmgInfo.HitPoint != Vector3.zero)
				{
					m_LastHitPoint = dmgInfo.HitPoint;
					m_DamageIndicatorFader.DoFadeCycle(this, 1f);
				}
			}
		}
	}
}
