using DG.Tweening;
using UnityEngine;

namespace Simulator.GameWorld
{
	public abstract class CharacterModel : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private Transform m_root;

		[SerializeField]
		private Animator m_animator;

		[SerializeField]
		private Transform m_leftHandRoot;

		[SerializeField]
		private Transform m_rightHandRoot;

		[Header("Parameters")]
		[SerializeField]
		private bool m_isMan;

		[SerializeField]
		private int m_modelIndex;

		private bool m_walking;

		private bool m_sitted;

		private static int _walkingID;

		private static int _walkingSpeedID;

		private static int _sittedID;

		public bool HasAnimator => m_animator != null;

		protected Animator Animator => m_animator;

		public Transform LeftHandRoot => m_leftHandRoot;

		public Transform RightHandRoot => m_rightHandRoot;

		public bool IsMan => m_isMan;

		public int ModelIndex => m_modelIndex;

		private static int WalkingID
		{
			get
			{
				if (_walkingID == 0)
				{
					_walkingID = Animator.StringToHash("Walking");
				}
				return _walkingID;
			}
		}

		private static int WalkingSpeedID
		{
			get
			{
				if (_walkingSpeedID == 0)
				{
					_walkingSpeedID = Animator.StringToHash("WalkingSpeed");
				}
				return _walkingSpeedID;
			}
		}

		private static int SittedID
		{
			get
			{
				if (_sittedID == 0)
				{
					_sittedID = Animator.StringToHash("Sitted");
				}
				return _sittedID;
			}
		}

		protected virtual void OnEnable()
		{
			SetWalkingAnimSpeed();
		}

		public void SetUpdateMode(AnimatorUpdateMode mode)
		{
			if (HasAnimator)
			{
				m_animator.updateMode = mode;
			}
		}

		protected abstract float GetWalkingSpeed();

		protected void SetWalkingAnimSpeed()
		{
			if (HasAnimator)
			{
				m_animator.SetFloat(WalkingSpeedID, AIModelSettings.WalkingAnimationSpeedMultiplier * GetWalkingSpeed());
			}
		}

		public void SetWalking(bool walking)
		{
			if (HasAnimator && m_walking != walking)
			{
				m_walking = walking;
				m_animator.SetBool(WalkingID, walking);
			}
		}

		public void SetSitted(bool sitted)
		{
			if (HasAnimator && m_sitted != sitted)
			{
				m_sitted = sitted;
				m_animator.SetBool(SittedID, sitted);
				OnSetSitted(sitted);
			}
		}

		protected virtual void OnSetSitted(bool sitted)
		{
			if (sitted)
			{
				if (IsMan)
				{
					m_root.DOLocalMoveY(AIModelSettings.ManSitOffset, AIModelSettings.ManSitOffsetDuration);
				}
			}
			else if (IsMan)
			{
				m_root.DOLocalMoveY(0f, AIModelSettings.ManStandOffsetDuration);
			}
		}
	}
}
