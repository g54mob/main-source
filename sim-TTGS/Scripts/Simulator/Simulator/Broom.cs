using System.Collections;
using Simulator.GameWorld;
using Unity.Cinemachine;
using UnityEngine;

namespace Simulator
{
	[SelectionBase]
	public class Broom : MonoBehaviour, IStainCleaner
	{
		[Header("References")]
		[SerializeField]
		private Animator m_animator;

		[SerializeField]
		private ToggleInputHint m_inputHint;

		[Header("Clipping")]
		[SerializeField]
		private ClippingObjectBehaviour m_clippingObjectBehaviour;

		private bool m_isHolding;

		private bool m_isUsed;

		private Transform m_refTransform;

		private BroomGrabber m_grabber;

		private bool m_isCleaning;

		private static readonly int _UseAnimatorHash = Animator.StringToHash("Use");

		private IEnumerator m_stopCleaningCoroutine;

		public ClippingObjectBehaviour clippingObjectBehaviour => m_clippingObjectBehaviour;

		public Stain Stain { get; private set; }

		public float CleaningRate => DirtSettings.BroomCleaningRate;

		private float SingleSweepDuration => DirtSettings.SingleSweepDuration;

		private void Start()
		{
			clippingObjectBehaviour.ValidateRenderersLayer();
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.TryGetComponent<Stain>(out var component))
			{
				Stain = component;
				if (m_isCleaning)
				{
					((IStainCleaner)this).TryStartCleanDirt(Stain);
				}
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (!(Stain == null) && other.gameObject == Stain.gameObject)
			{
				StopCleanDirt(Stain);
				Stain = null;
			}
		}

		public bool TryStartCleaning()
		{
			if (m_isCleaning || !m_isHolding || !m_isUsed)
			{
				return false;
			}
			StopStopCleaningRoutine();
			m_animator.SetBool(_UseAnimatorHash, value: true);
			((IStainCleaner)this).TryStartCleanDirt(Stain);
			m_isCleaning = true;
			return true;
		}

		public void StopCleaning()
		{
			if (m_isHolding)
			{
				m_animator.SetBool(_UseAnimatorHash, value: false);
				m_isCleaning = false;
				if (Stain != null)
				{
					StopCleanDirt(Stain);
				}
			}
		}

		public bool CanStartCleanDirt(Stain dirt)
		{
			if (dirt == null)
			{
				return false;
			}
			if (!m_isHolding)
			{
				return false;
			}
			return true;
		}

		public void StartCleanDirt(Stain dirt)
		{
			dirt.StartClean(this);
		}

		public void StopCleanDirt(Stain dirt)
		{
			dirt.StopClean();
		}

		public void OnSpawn(BroomGrabber grabber)
		{
			if (!m_isHolding)
			{
				m_isHolding = true;
				m_grabber = grabber;
				CinemachineCore.CameraUpdatedEvent.AddListener(OnCinemachineUpdate);
				LookUp();
				m_inputHint.enabled = true;
				RefreshInputHint();
			}
		}

		public void OnHide()
		{
			if (m_isHolding)
			{
				CinemachineCore.CameraUpdatedEvent.RemoveListener(OnCinemachineUpdate);
				m_grabber = null;
				m_isHolding = false;
				m_isUsed = false;
				m_inputHint.enabled = false;
				RefreshInputHint();
			}
		}

		private void OnCinemachineUpdate(CinemachineBrain brain)
		{
			if (m_grabber == null || !m_isHolding)
			{
				CinemachineCore.CameraUpdatedEvent.RemoveListener(OnCinemachineUpdate);
				return;
			}
			bool flag = false;
			if (brain.OutputCamera != null)
			{
				float num = brain.transform.eulerAngles.x;
				if (num > 180f)
				{
					num -= 360f;
				}
				flag = num > DirtSettings.BroomUpAngle;
			}
			if (!m_isUsed && flag)
			{
				LookDown();
			}
			else if (m_isUsed && !flag)
			{
				LookUp();
			}
			if (m_refTransform != null)
			{
				m_grabber.transform.rotation = Quaternion.Euler(m_refTransform.parent.eulerAngles.x, brain.transform.eulerAngles.y, m_refTransform.parent.eulerAngles.z);
			}
		}

		private void LookUp()
		{
			m_grabber.GrabBroom(out var refTransform);
			m_refTransform = refTransform;
			m_isUsed = false;
			StopCleaning();
			RefreshInputHint();
		}

		private void LookDown()
		{
			m_grabber.UseBroom(out var refTransform);
			m_refTransform = refTransform;
			m_isUsed = true;
			RefreshInputHint();
		}

		public void DoSingleSweep()
		{
			if (TryStartCleaning())
			{
				m_stopCleaningCoroutine = StopCleaningAfterDelay();
				StartCoroutine(m_stopCleaningCoroutine);
			}
		}

		private IEnumerator StopCleaningAfterDelay()
		{
			yield return new WaitForSeconds(SingleSweepDuration);
			StopCleaning();
		}

		private void StopStopCleaningRoutine()
		{
			if (m_stopCleaningCoroutine != null)
			{
				StopCoroutine(m_stopCleaningCoroutine);
				m_stopCleaningCoroutine = null;
			}
		}

		private void RefreshInputHint()
		{
			if (!(m_inputHint == null))
			{
				m_inputHint.AddFlags(ToggleInputHint.EActionStates.FALSE);
				if (m_isUsed)
				{
					m_inputHint.AddFlagsAndRefreshInputHint(ToggleInputHint.EActionStates.TRUE);
				}
				else
				{
					m_inputHint.RemoveFlagsAndRefreshInputHint(ToggleInputHint.EActionStates.TRUE);
				}
			}
		}
	}
}
