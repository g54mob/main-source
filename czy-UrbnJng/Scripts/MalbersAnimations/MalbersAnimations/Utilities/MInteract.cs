using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.Serialization;

namespace MalbersAnimations.Utilities
{
	[DefaultExecutionOrder(15)]
	[SelectionBase]
	[AddComponentMenu("Malbers/Interaction/Interactable")]
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/global-components/interactable")]
	public class MInteract : MonoBehaviour, IInteractable
	{
		[Tooltip("Own Index. This is used to Identify each Interactable. 0 or -1 means that all interactors can interact with this.")]
		public IntReference m_ID = new IntReference(0);

		[Tooltip("ID for the Interactor. Makes this Interactable to interact only with Interactors with this ID Value\nBy default its -1, which means that can be activated by anyone")]
		[FormerlySerializedAs("m_InteracterID")]
		public IntReference m_InteractorID = new IntReference(-1);

		[Tooltip("If the Interactor has this Interactable focused, it will interact with it automatically.\nIt also is used by the AI Animals. If the Animal Reaches this gameobject to Interact with it this needs to be set to true")]
		[SerializeField]
		private BoolReference m_Auto = new BoolReference(value: false);

		[Tooltip("Interact Once, after that it cannot longer work, unlest the Interactable is Restarted. Disable the component")]
		[SerializeField]
		private BoolReference m_singleInteraction = new BoolReference(value: false);

		[Tooltip("Destroy after a Single Interaction. (After the Delay)")]
		[SerializeField]
		private BoolReference m_Destroy = new BoolReference(value: false);

		[Tooltip("Delay time to activate the events on the Interactable")]
		public FloatReference m_Delay = new FloatReference(0f);

		[Tooltip("CoolDown between Interactions when the Interactable is NOT a Single/One time interaction")]
		public FloatReference m_CoolDown = new FloatReference(0f);

		[Tooltip("When an Interaction is executed these events will be invoked.\n\nOnInteractWithGO(GameObject) -> will have the *INTERACTER* gameObject as parameter\n\nOnInteractWith(Int) -> will have the *INTERACTER* ID as parameter")]
		public InteractionEvents events = new InteractionEvents();

		public GameObjectEvent OnFocused = new GameObjectEvent();

		public GameObjectEvent OnUnfocused = new GameObjectEvent();

		public BoolEvent OnCoolDown = new BoolEvent();

		private bool focused;

		private float CurrentActivationTime;

		public string Description = "Invoke events when an Interactor interacts with it";

		[HideInInspector]
		public bool ShowDescription = true;

		[SerializeField]
		private int Editor_Tabs1;

		public int Index => m_ID;

		public bool Active
		{
			get
			{
				if (base.enabled)
				{
					return !InCooldown;
				}
				return false;
			}
			set
			{
				base.enabled = value;
			}
		}

		public bool SingleInteraction
		{
			get
			{
				return m_singleInteraction.Value;
			}
			set
			{
				m_singleInteraction.Value = value;
			}
		}

		public bool Auto
		{
			get
			{
				return m_Auto.Value;
			}
			set
			{
				m_Auto.Value = value;
			}
		}

		public float Delay
		{
			get
			{
				return m_Delay.Value;
			}
			set
			{
				m_Delay.Value = value;
			}
		}

		public float Cooldown
		{
			get
			{
				return m_CoolDown.Value;
			}
			set
			{
				m_CoolDown.Value = value;
			}
		}

		public bool InCooldown => !MTools.ElapsedTime(CurrentActivationTime, Cooldown);

		public IInteractor CurrentInteractor { get; set; }

		public bool Focused
		{
			get
			{
				return focused;
			}
			set
			{
				if (focused != value)
				{
					focused = value;
					if (focused)
					{
						OnFocused.Invoke(CurrentInteractor?.Owner);
					}
					else
					{
						OnUnfocused.Invoke(CurrentInteractor?.Owner);
					}
				}
			}
		}

		public GameObject Owner { get; set; }

		[ContextMenu("Show Description")]
		internal void EditDescription()
		{
			ShowDescription = !ShowDescription;
		}

		private void OnEnable()
		{
			Owner = base.transform.FindObjectCore().gameObject;
			CurrentActivationTime = 0f - Cooldown;
		}

		private void OnDisable()
		{
			focused = false;
			CurrentInteractor?.UnFocus(this);
		}

		public bool Interact(int InteracterID, GameObject interacter)
		{
			if (Active)
			{
				if ((int)m_InteractorID <= 0 || (int)m_InteractorID == InteracterID)
				{
					CurrentActivationTime = Time.time;
					this.Delay_Action(Delay, delegate
					{
						events.OnInteractWithGO.Invoke(interacter);
						events.OnInteractWith.Invoke(InteracterID);
					});
					if (SingleInteraction)
					{
						Focused = false;
						Active = false;
						if (m_Destroy.Value)
						{
							Object.Destroy(base.gameObject, Delay + 0.001f);
						}
					}
					if (Cooldown > 0f && !m_Destroy.Value)
					{
						OnCoolDown.Invoke(arg0: true);
						this.Delay_Action(Cooldown, delegate
						{
							OnCoolDown.Invoke(arg0: false);
						});
					}
					return true;
				}
				return false;
			}
			return false;
		}

		public bool Interact(IInteractor interacter)
		{
			if (interacter != null)
			{
				return Interact(interacter.ID, interacter.Owner.gameObject);
			}
			return false;
		}

		public void Interact()
		{
			Interact(-1, null);
		}

		public virtual void Restart()
		{
			Focused = false;
			Active = true;
			CurrentActivationTime = 0f - Cooldown;
		}

		public void DestroyMe(float time)
		{
			Object.Destroy(base.gameObject, time);
		}
	}
}
