using DG.Tweening;
using Dhs5.Utility.Updates;
using Simulator;
using Simulator.GameWorld;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tabletop.GameWorld
{
	public class WargameDice : MonoBehaviour, IUIInputReceiver, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
	{
		[Header("References")]
		[SerializeField]
		private Transform m_rotationRoot;

		[SerializeField]
		private BoxCollider m_collider;

		[SerializeField]
		private Renderer m_renderer;

		[SerializeField]
		private Outline m_outline;

		private Vector3 m_originPosition;

		private Quaternion m_originRotation;

		private WargameDiceAnchor m_currentAnchor;

		private int m_value;

		private bool m_dragging;

		private Vector2 m_mousePosition;

		private Sequence m_sequence;

		private Tween m_highlightTween;

		public int Value => m_value;

		public bool Anchored => m_currentAnchor != null;

		public void Init(int value, bool showRenderer)
		{
			m_value = value;
			m_collider.enabled = false;
			m_renderer.enabled = showRenderer;
			m_rotationRoot.localEulerAngles = WargameSettings.GetDiceRotationForFace(m_value);
			m_outline.OutlineWidth = 2f;
			m_outline.OutlineColor = WargameSettings.HoverDiceOutlineColor;
		}

		public void Throw(Vector3 destination)
		{
			m_originPosition = destination;
			m_originRotation = Quaternion.Euler(0f, Random.Range(0f, 359f), 0f);
			m_collider.enabled = true;
			m_renderer.enabled = true;
			TriggerThrowAnimation(destination);
		}

		public void Rethrow(Vector3 throwOrigin, int newValue)
		{
			m_value = newValue;
			m_originRotation = Quaternion.Euler(0f, Random.Range(0f, 359f), 0f);
			m_collider.enabled = true;
			m_renderer.enabled = true;
			base.transform.position = throwOrigin;
			TriggerThrowAnimation(m_originPosition);
		}

		private void TriggerThrowAnimation(Vector3 destination)
		{
			Vector3 diceRotationForFace = WargameSettings.GetDiceRotationForFace(m_value);
			Vector3 vector = destination - base.transform.position;
			vector.y = 0f;
			Vector3 endValue = new Vector3(base.transform.position.x + vector.x * 0.9f, destination.y, base.transform.position.z + vector.z * 0.9f);
			float diceThrowDuration = WargameSettings.GetDiceThrowDuration();
			Sequence sequence = DOTween.Sequence();
			sequence.Append(base.transform.DOJump(endValue, 0.15f, WargameSettings.DiceThrowNumberOfJumps, diceThrowDuration - WargameSettings.DiceThrowJumpDurationOffset).SetEase(WargameSettings.DiceThrowJumpEase));
			sequence.Append(base.transform.DOMove(destination, WargameSettings.DiceThrowJumpDurationOffset / 2f));
			Sequence sequence2 = DOTween.Sequence();
			sequence2.Append(sequence);
			sequence2.Join(m_rotationRoot.DOLocalRotate(diceRotationForFace + Vector3.one * 360f * WargameSettings.DiceThrowNumberOfTurns, diceThrowDuration, RotateMode.FastBeyond360).SetEase(WargameSettings.DiceThrowRotationEase));
			sequence2.Join(base.transform.DORotateQuaternion(m_originRotation, diceThrowDuration));
			sequence2.SetUpdate(isIndependentUpdate: true);
			sequence2.Play();
		}

		public void Show(bool show)
		{
			m_renderer.enabled = show;
		}

		public void SetAnchor(WargameDiceAnchor anchor)
		{
			if (m_currentAnchor != anchor && m_currentAnchor != null)
			{
				m_currentAnchor.OnLoseDice(this);
			}
			m_currentAnchor = anchor;
		}

		public void RejectFor(WargameDice other)
		{
			if (other.m_currentAnchor != null)
			{
				other.m_currentAnchor.Drop(this);
				SetPositionAndRotation(m_currentAnchor.transform.position, m_currentAnchor.transform.rotation);
			}
			else
			{
				m_currentAnchor = null;
				SetPositionAndRotation(m_originPosition, m_originRotation);
			}
		}

		public void ParentToAnchor()
		{
			if (m_currentAnchor != null)
			{
				base.transform.SetParent(m_currentAnchor.transform.parent, worldPositionStays: true);
			}
			m_collider.enabled = false;
		}

		public void EnableDragging(bool enable)
		{
			m_collider.enabled = enable;
		}

		public void Highlight(bool active)
		{
			JuiceManager.SetHighlightValue(active, m_renderer.material, m_highlightTween);
			if (active)
			{
				JuiceManager.AddBounce(EBouncePresets.DICE_CLICK, base.transform);
			}
			if ((bool)m_outline)
			{
				m_outline.enabled = active;
				m_outline.OutlineColor = WargameSettings.ActiveMiniatureColor;
			}
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			m_dragging = true;
			m_collider.enabled = false;
			base.transform.SetAsLastSibling();
			JuiceManager.AddBounce(EBouncePresets.DICE_CLICK, base.transform);
			IUIInputReceiver.SetCurrent(this);
			Updater.RegisterChannelCallback(register: true, EUpdateChannel.CLASSIC, OnUpdate);
		}

		public void OnDrag(PointerEventData eventData)
		{
		}

		private void OnUpdate(float deltaTime)
		{
			if (m_dragging)
			{
				base.transform.position = Vector3.Lerp(base.transform.position, TransientManager<CameraManager>.Instance.Camera.ScreenToWorldPoint(new Vector3(m_mousePosition.x, m_mousePosition.y, WargameSettings.DraggingDiceDistanceToCamera)), Time.unscaledDeltaTime * 16f);
			}
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			if (m_dragging)
			{
				IUIInputReceiver.SetCurrent(null);
				Updater.RegisterChannelCallback(register: false, EUpdateChannel.CLASSIC, OnUpdate);
				m_dragging = false;
				m_collider.enabled = true;
				SetPositionAndRotation((m_currentAnchor != null) ? m_currentAnchor.transform.position : m_originPosition, (m_currentAnchor != null) ? m_currentAnchor.transform.rotation : m_originRotation);
				JuiceManager.AddBounce(EBouncePresets.DICE_CLICK, base.transform);
			}
		}

		private void SetPositionAndRotation(Vector3 targetPos, Quaternion targetRot)
		{
			if (m_sequence.IsActive())
			{
				m_sequence.Kill();
			}
			m_sequence = DOTween.Sequence();
			m_sequence.SetUpdate(isIndependentUpdate: true);
			m_sequence.Join(base.transform.DOMove(targetPos, 0.3f)).SetEase(Ease.OutCirc);
			m_sequence.Join(base.transform.DORotateQuaternion(targetRot, 0.3f)).SetEase(Ease.OutCirc);
			m_sequence.Play();
		}

		public void OnDrop(PointerEventData eventData)
		{
			if (m_currentAnchor != null)
			{
				m_currentAnchor.OnDrop(eventData);
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (m_currentAnchor != null && eventData.button == PointerEventData.InputButton.Right)
			{
				m_currentAnchor.OnLoseDice(this);
				m_currentAnchor = null;
				SetPositionAndRotation(m_originPosition, m_originRotation);
			}
			JuiceManager.AddBounce(EBouncePresets.DICE_CLICK, base.transform);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (!eventData.dragging || !(m_currentAnchor == null))
			{
				if (m_outline != null)
				{
					m_outline.enabled = true;
				}
				JuiceManager.SetHighlightValue(active: true, m_renderer.material, m_highlightTween);
				JuiceManager.AddBounce(EBouncePresets.DICE_HOVER_ENTER, base.transform);
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (m_outline != null)
			{
				m_outline.enabled = false;
			}
			JuiceManager.SetHighlightValue(active: false, m_renderer.material, m_highlightTween);
			JuiceManager.AddBounce(EBouncePresets.DICE_HOVER_EXIT, base.transform);
		}

		public void OnUIInput_Navigate(Vector2 direction)
		{
		}

		public void OnUIInput_Point(Vector2 mousePosition)
		{
			m_mousePosition = mousePosition;
		}

		public void OnUIInput_Submit()
		{
		}

		public void OnUIInput_Space()
		{
		}

		public void OnUIInput_Memo()
		{
		}

		public void OnUIInput_GamepadNorthButton()
		{
		}

		public void OnUIInput_GamepadWestButton()
		{
		}

		public void OnUIInput_ExitWorkshop()
		{
		}
	}
}
