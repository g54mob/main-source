using System.Collections;
using HQFPSTemplate.UserInterface;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace HQFPSTemplate
{
	public class PostProcessingManager : Singleton<PostProcessingManager>
	{
		[SerializeField]
		private PostProcessVolume m_MainPPVolume;

		[SerializeField]
		private PostProcessVolume m_WorldPPVolume;

		[BHeader("DepthOfField", true)]
		[SerializeField]
		private bool m_EnableAimDOF = true;

		[SerializeField]
		private bool m_EnableItemWheelDOF = true;

		[BHeader("DeathAnim", true)]
		[SerializeField]
		[Range(0.01f, 15f)]
		private float m_DeathAnimSpeed = 1f;

		[SerializeField]
		[Range(-1f, 0f)]
		private float m_MinColorSaturation = -1f;

		private PostProcessProfile m_EditorMainProfile;

		private PostProcessProfile m_EditorWorldProfile;

		private PostProcessProfile m_MainProfile;

		private PostProcessProfile m_WorldProfile;

		private float m_DefaultSaturation;

		private bool m_PlayerDead;

		private ColorGrading m_ColorGrading;

		private DepthOfField m_MainDepthOfField;

		private DepthOfField m_WorldDepthOfField;

		private Player m_Player;

		private UIManager m_UIManager;

		private void EnableDOF(DepthOfField dofObject, bool enable)
		{
			if (dofObject.active != enable)
			{
				dofObject.active = enable;
			}
		}

		private void DoDeathAnim()
		{
			m_PlayerDead = true;
			StartCoroutine(C_DoDeathAnim());
		}

		private void RestoreDefaultProfile()
		{
			m_PlayerDead = false;
		}

		private void Start()
		{
			m_EditorMainProfile = m_MainPPVolume.profile;
			m_MainProfile = Object.Instantiate(m_EditorMainProfile);
			m_MainPPVolume.profile = m_MainProfile;
			m_EditorWorldProfile = m_WorldPPVolume.profile;
			m_WorldProfile = Object.Instantiate(m_EditorWorldProfile);
			m_WorldPPVolume.profile = m_WorldProfile;
			m_ColorGrading = m_MainPPVolume.profile.GetSetting<ColorGrading>();
			m_DefaultSaturation = m_ColorGrading.saturation;
			m_MainDepthOfField = m_MainProfile.GetSetting<DepthOfField>();
			m_WorldDepthOfField = m_WorldProfile.GetSetting<DepthOfField>();
			m_Player = Singleton<GameManager>.Instance.CurrentPlayer;
			m_UIManager = Singleton<GameManager>.Instance.CurrentInterface;
			if (m_Player != null)
			{
				m_Player.Death.AddListener(DoDeathAnim);
				m_Player.Respawn.AddListener(RestoreDefaultProfile);
				if (m_EnableAimDOF)
				{
					m_Player.Aim.AddStartListener(delegate
					{
						EnableDOF(m_MainDepthOfField, Singleton<GameManager>.Instance.CurrentPlayer.ActiveEquipmentItem.Get().EInfo.Aiming.UseAimBlur);
					});
					m_Player.Aim.AddStopListener(delegate
					{
						EnableDOF(m_MainDepthOfField, enable: false);
					});
				}
			}
			if (m_UIManager != null && m_EnableItemWheelDOF)
			{
				m_UIManager.ItemWheel.AddStartListener(delegate
				{
					EnableDOF(m_WorldDepthOfField, enable: true);
				});
				m_UIManager.ItemWheel.AddStopListener(delegate
				{
					EnableDOF(m_WorldDepthOfField, enable: false);
				});
			}
		}

		private void OnDestroy()
		{
			m_MainPPVolume.profile = m_EditorMainProfile;
			m_WorldPPVolume.profile = m_EditorWorldProfile;
		}

		private IEnumerator C_DoDeathAnim()
		{
			float saturation = m_ColorGrading.saturation.value;
			float requiredSaturation = m_MinColorSaturation * 100f;
			while (m_PlayerDead)
			{
				saturation = Mathf.Lerp(saturation, requiredSaturation, Time.deltaTime * m_DeathAnimSpeed);
				m_ColorGrading.saturation.value = saturation;
				yield return null;
			}
			if (!m_PlayerDead)
			{
				m_ColorGrading.saturation.value = m_DefaultSaturation;
			}
		}
	}
}
