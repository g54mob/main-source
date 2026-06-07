using UnityEngine;

namespace Simulator.GameWorld
{
	public class ReserveShelfInteractable : MonoBehaviour, ISensable, IMainInteractable
	{
		[Header("Main Components")]
		[SerializeField]
		private ReserveShelfLabel m_label;

		[SerializeField]
		private Collider m_collider;

		[SerializeField]
		private GenericGrabber m_grabber;

		[Header("Detection")]
		[SerializeField]
		private Outline m_outline;

		[SerializeField]
		private Outline m_highlight;

		[SerializeField]
		private InputHint m_inputHint;

		private StackableBox m_box;

		private bool m_sensed;

		public StackableBox Box => m_box;

		public ReserveShelfLabel Label => m_label;

		public static ReserveShelfInteractable CurrentlyInspected { get; private set; }

		private void Awake()
		{
			Highlight(highlight: false);
		}

		protected virtual void OnEnable()
		{
			m_grabber.Grabbed += OnGrabbed;
			m_grabber.Gave += OnGave;
		}

		protected virtual void OnDisable()
		{
			m_grabber.Grabbed -= OnGrabbed;
			m_grabber.Gave -= OnGave;
		}

		protected void SetContent(StackableBox box)
		{
			m_box = box;
			if (m_box != null)
			{
				m_label.SetContent(box);
				if (box.IsOpen)
				{
					box.ToggleOpenState();
				}
			}
			else
			{
				m_label.SetContent(null);
			}
		}

		protected virtual void OnGrabbed(IGrabbable grabbable)
		{
			if (grabbable is StackableBox stackableBox)
			{
				SetContent(stackableBox);
				if (m_sensed)
				{
					stackableBox.OnSensed();
				}
			}
		}

		protected virtual void OnGave(IGrabbable grabbable)
		{
			if (m_sensed && m_box != null)
			{
				m_box.OnUnsensed();
			}
			SetContent(null);
			if (m_sensed)
			{
				OnSensed();
			}
		}

		public bool CanBeSensed()
		{
			if (World.PlayerController.Context == EControllerContext.CHARACTER)
			{
				EPlayerCharacterContext characterContext = World.PlayerCharacter.CharacterContext;
				if (characterContext == EPlayerCharacterContext.GRABBING || characterContext == EPlayerCharacterContext.NONE)
				{
					return CanMainInteract(World.PlayerCharacter);
				}
			}
			return false;
		}

		public void OnSensed()
		{
			m_sensed = true;
			CurrentlyInspected = this;
			if (m_box != null)
			{
				m_inputHint.enabled = false;
				m_outline.enabled = false;
				m_box.OnSensed();
			}
			else
			{
				m_inputHint.enabled = true;
				m_outline.enabled = true;
			}
		}

		public void OnUnsensed()
		{
			m_sensed = false;
			if (CurrentlyInspected == this)
			{
				CurrentlyInspected = null;
			}
			m_inputHint.enabled = false;
			m_outline.enabled = false;
			if (m_box != null)
			{
				m_box.OnUnsensed();
			}
		}

		public bool CanMainInteract(Character character)
		{
			if (character.CanGiveGrabbable(out var grabbable) && m_grabber.CanGrab(grabbable) && grabbable is StackableBox { IsEmpty: false })
			{
				return true;
			}
			if (m_grabber.CanGive(out grabbable) && character.CanGrab(grabbable))
			{
				return true;
			}
			return false;
		}

		void IMainInteractable.OnMainInteractedBy(Character character)
		{
			if (character.CanGiveGrabbable(out var _))
			{
				m_grabber.Grab(character.GiveGrabbableTo(m_grabber));
			}
			else
			{
				character.TakeFrom(m_grabber);
			}
		}

		public void Highlight(bool highlight)
		{
			if (m_highlight != null)
			{
				m_highlight.enabled = highlight;
			}
		}

		public virtual void Load(int phase, SaveClass_Furnitures.ReserveShelfState.ReserveShelfInteractableState state)
		{
			if (state.boxState != null)
			{
				BaseBox baseBox = BaseBox.LoadBoxFromSave(state.boxState);
				if (baseBox != null)
				{
					m_grabber.Grab(baseBox);
				}
			}
		}
	}
}
