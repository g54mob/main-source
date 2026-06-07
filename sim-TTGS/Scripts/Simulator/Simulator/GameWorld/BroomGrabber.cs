using DG.Tweening;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class BroomGrabber : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private Broom m_broom;

		[SerializeField]
		private PlayerCharacter m_playerCharacter;

		[SerializeField]
		private Transform m_grabTransform;

		[SerializeField]
		private Transform m_useTransform;

		[Header("Tween")]
		[SerializeField]
		private float m_moveTweenDuration = 0.5f;

		[SerializeField]
		private float m_rotateTweenDuration = 0.5f;

		private Tween m_moveTween;

		private Tween m_rotateTween;

		private bool m_isHoldingBroom;

		public void ToggleBroom(bool value, out Broom broom)
		{
			broom = null;
			if (!m_isHoldingBroom && value)
			{
				SpawnBroom();
				broom = m_broom;
			}
			else if (m_isHoldingBroom && !value)
			{
				HideBroom();
			}
		}

		private void SpawnBroom()
		{
			m_broom.gameObject.SetActive(value: true);
			GrabBroom(out var _);
			m_broom.OnSpawn(this);
			m_isHoldingBroom = true;
		}

		private void HideBroom()
		{
			m_broom.OnHide();
			m_broom.gameObject.SetActive(value: false);
			UseBroom(out var _);
			m_isHoldingBroom = false;
		}

		public void GrabBroom(out Transform refTransform)
		{
			m_broom.transform.SetParent(m_grabTransform);
			ResetBroomPosition(m_broom);
			refTransform = base.transform;
		}

		public void UseBroom(out Transform refTransform)
		{
			refTransform = null;
			m_broom.transform.SetParent(m_useTransform);
			ResetBroomPosition(m_broom);
			refTransform = base.transform;
		}

		private void ResetBroomPosition(Broom broom)
		{
			m_moveTween?.Kill();
			m_moveTween = broom.transform.DOLocalMove(Vector3.zero, m_moveTweenDuration);
			m_rotateTween?.Kill();
			m_rotateTween = broom.transform.DOLocalRotate(Vector3.zero, m_rotateTweenDuration);
		}

		public bool IsHoldingBroom(out Broom broom)
		{
			broom = (m_isHoldingBroom ? m_broom : null);
			return m_isHoldingBroom;
		}
	}
}
