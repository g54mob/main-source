using System.Collections.Generic;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Utilities
{
	[AddComponentMenu("Malbers/Interaction/Interactor")]
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/global-components/interactor")]
	public class MInteractor : MonoBehaviour, IInteractor
	{
		[Tooltip("Layer for the Interact with colliders")]
		[SerializeField]
		private LayerReference Layer = new LayerReference(-1);

		[SerializeField]
		private QueryTriggerInteraction TriggerInteraction = QueryTriggerInteraction.Ignore;

		[Tooltip("ID for the Interactor")]
		public IntReference m_ID = new IntReference(0);

		[Tooltip("Collider set as Trigger to Find Interactables OnTrigger Enter")]
		public Collider InteractionArea;

		[Tooltip("When an Interaction is executed these events will be invoked.\n\nOnInteractWithGO(GameObject) -> will have the *INTERACTABLE* gameObject as parameter\n\nOnInteractWith(Int) -> will have the *INTERACTABLE* ID as parameter")]
		public InteractionEvents events = new InteractionEvents();

		public GameObjectEvent OnFocused = new GameObjectEvent();

		public GameObjectEvent OnUnfocused = new GameObjectEvent();

		public List<IInteractable> FocusedInteractables;

		public List<MInteractorReaction> reactions = new List<MInteractorReaction>();

		private Transform RealRoot;

		public bool debug;

		[SerializeField]
		private int Editor_Tabs1;

		public int ID => m_ID.Value;

		public bool Enabled
		{
			get
			{
				return !base.enabled;
			}
			set
			{
				base.enabled = !value;
			}
		}

		public GameObject Owner => RealRoot.gameObject;

		public TriggerProxy Proxy { get; set; }

		private void OnValidate()
		{
			if (InteractionArea != null)
			{
				InteractionArea.isTrigger = true;
			}
		}

		private void OnEnable()
		{
			FocusedInteractables = new List<IInteractable>();
			RealRoot = base.transform.FindObjectCore();
			Proxy = TriggerProxy.CheckTriggerProxy(InteractionArea, Layer, TriggerInteraction, RealRoot);
			if ((bool)Proxy)
			{
				Proxy.OnTrigger_Enter.AddListener(TriggerEnter);
				Proxy.OnTrigger_Exit.AddListener(TriggerExit);
			}
		}

		private void OnDisable()
		{
			IInteractable[] array = FocusedInteractables.ToArray();
			foreach (IInteractable item in array)
			{
				UnFocus(item);
			}
			FocusedInteractables = null;
			if ((bool)Proxy)
			{
				Proxy.OnTrigger_Enter.RemoveListener(TriggerEnter);
				Proxy.OnTrigger_Exit.RemoveListener(TriggerExit);
			}
		}

		private void TriggerEnter(Collider collider)
		{
			if (collider.isTrigger && TriggerInteraction == QueryTriggerInteraction.Ignore)
			{
				return;
			}
			IInteractable[] array = collider.FindInterfaces<IInteractable>();
			if (array == null)
			{
				return;
			}
			IInteractable[] array2 = array;
			foreach (IInteractable item in array2)
			{
				if (!FocusedInteractables.Contains(item))
				{
					Focus(item);
				}
			}
		}

		private void TriggerExit(Collider collider)
		{
			if (!(collider != null))
			{
				return;
			}
			IInteractable[] array = collider.FindInterfaces<IInteractable>();
			if (array == null)
			{
				return;
			}
			IInteractable[] array2 = array;
			foreach (IInteractable interactable in array2)
			{
				if (interactable != null && FocusedInteractables.Contains(interactable))
				{
					UnFocus(interactable);
				}
			}
		}

		public virtual void Focus(IInteractable item)
		{
			if (item != null && item.Active)
			{
				item.CurrentInteractor = this;
				OnFocused.Invoke(item.Owner);
				item.Focused = true;
				FocusedInteractables.Add(item);
				if (item.Auto)
				{
					Interact(item);
				}
			}
		}

		public virtual void Focus(Component item)
		{
			if (item is IInteractable)
			{
				Focus(item as IInteractable);
			}
		}

		public virtual void Focus(GameObject item)
		{
			if (item != null)
			{
				Focus(item.FindInterface<IInteractable>());
			}
		}

		public void UnFocus(IInteractable item)
		{
			if (item != null)
			{
				OnUnfocused.Invoke(item.Owner);
				item.Focused = false;
				item.CurrentInteractor = null;
				FocusedInteractables.Remove(item);
			}
		}

		public bool Interact(IInteractable inter)
		{
			if (inter.Interact(this))
			{
				events.OnInteractWithGO.Invoke(inter.Owner);
				events.OnInteractWith.Invoke(inter.Index);
				foreach (MInteractorReaction reaction in reactions)
				{
					reaction.React(inter.Index);
				}
				if (debug)
				{
					Debug.Log($"{RealRoot.name} -> Interact ({inter.Index} : {inter.Owner.name})", this);
				}
				return true;
			}
			return false;
		}

		public void Interact()
		{
			IInteractable[] array = FocusedInteractables.ToArray();
			foreach (IInteractable inter in array)
			{
				Interact(inter);
			}
		}

		public void Restart()
		{
			FocusedInteractables = new List<IInteractable>();
			OnUnfocused.Invoke(null);
			OnFocused.Invoke(null);
		}

		public void Interact(GameObject interactable)
		{
			if ((bool)interactable)
			{
				Interact(interactable.FindInterface<IInteractable>());
			}
		}

		public void Interact(Component interactable)
		{
			if ((bool)interactable)
			{
				Interact(interactable.FindInterface<IInteractable>());
			}
		}
	}
}
