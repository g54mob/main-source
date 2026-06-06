using System;
using System.Collections;
using System.Collections.Generic;
using MalbersAnimations.Events;
using MalbersAnimations.Reactions;
using MalbersAnimations.Scriptables;
using MalbersAnimations.Utilities;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	[AddComponentMenu("Malbers/Interaction/Pick Up - Drop")]
	public class MPickUp : MonoBehaviour, IAnimatorListener
	{
		[Serializable]
		public struct ExtraHolder
		{
			public Transform transform;

			public Vector3 position;

			public Vector3 rotation;
		}

		[RequiredField]
		[Tooltip("Trigger used to find Items that can be picked Up")]
		public Collider PickUpArea;

		[SerializeField]
		[Tooltip("When an Item is Picked and Hold, the Pick Trigger area will be disabled")]
		private BoolReference m_HidePickArea = new BoolReference(value: true);

		[Tooltip("Transform to Parent the Picked Item")]
		public Transform Holder;

		public Vector3 PosOffset;

		public Vector3 RotOffset;

		public List<ExtraHolder> extraHolders;

		[Tooltip("Check for tags on the Pickable items")]
		public Tag[] Tags;

		[Tooltip("Layer for the Interact with colliders")]
		[SerializeField]
		private LayerReference Layer = new LayerReference(-1);

		[SerializeField]
		private QueryTriggerInteraction triggerInteraction = QueryTriggerInteraction.Ignore;

		[SerializeReference]
		[SubclassSelector]
		[Tooltip("Invokes a reaction if the Pickable is a collectable")]
		public Reaction CollectableReaction;

		public BoolEvent CanPickUp = new BoolEvent();

		public GameObjectEvent OnItemPicked = new GameObjectEvent();

		public GameObjectEvent OnItemDrop = new GameObjectEvent();

		public GameObjectEvent OnFocusedItem = new GameObjectEvent();

		public IntEvent OnPicking = new IntEvent();

		public IntEvent OnDropping = new IntEvent();

		public bool debug;

		public float DebugRadius = 0.02f;

		public Color DebugColor = Color.yellow;

		protected ICharacterAction character;

		[SerializeField]
		private TriggerProxy Proxy;

		protected bool PickingItem;

		[SerializeField]
		private Pickable item;

		[SerializeField]
		private Pickable focusedItem;

		private IEnumerator TryAlign;

		[SerializeField]
		private int Editor_Tabs1;

		public Transform Root { get; set; }

		public GameObject Owner { get; private set; }

		public bool Has_Item => Item != null;

		public virtual Pickable Item
		{
			get
			{
				return item;
			}
			set
			{
				item = value;
			}
		}

		public virtual Pickable FocusedItem
		{
			get
			{
				return focusedItem;
			}
			set
			{
				focusedItem = value;
				OnFocusedItem.Invoke((focusedItem != null) ? focusedItem.gameObject : null);
				CanPickUp.Invoke(focusedItem != null);
			}
		}

		Transform IAnimatorListener.transform => base.transform;

		protected virtual void Awake()
		{
			character = base.gameObject.FindInterface<ICharacterAction>();
			Owner = ((character != null) ? character.gameObject : base.gameObject);
			CheckTriggerProxy();
		}

		protected virtual void CheckTriggerProxy()
		{
			Root = base.transform.FindObjectCore();
			if ((bool)PickUpArea)
			{
				Proxy = TriggerProxy.CheckTriggerProxy(PickUpArea, Layer, triggerInteraction, Root);
			}
			else
			{
				Debug.LogWarning("Please set a Pick up Area");
			}
		}

		protected virtual void OnEnable()
		{
			Proxy.OnTrigger_Enter.AddListener(OnGameObjectEnter);
			Proxy.OnTrigger_Exit.AddListener(OnGameObjectExit);
			if (Has_Item)
			{
				PickUpItem();
			}
		}

		protected virtual void OnDisable()
		{
			Proxy.OnTrigger_Enter.RemoveListener(OnGameObjectEnter);
			Proxy.OnTrigger_Exit.RemoveListener(OnGameObjectExit);
		}

		protected virtual void OnGameObjectEnter(Collider col)
		{
			Pickable pickable = col.FindComponent<Pickable>();
			if ((bool)pickable && pickable.enabled)
			{
				if (pickable != FocusedItem && FocusedItem != null)
				{
					FocusedItem.SetFocused(Owner, isFocused: false);
				}
				FocusedItem = pickable;
				FocusedItem.SetFocused(Owner, isFocused: true);
				Debugging("Focused Item - " + FocusedItem.name);
				if (FocusedItem.AutoPick)
				{
					TryPickUp();
				}
			}
		}

		protected virtual void OnGameObjectExit(Collider col)
		{
			if (FocusedItem != null && !PickingItem)
			{
				Pickable pickable = col.FindComponent<Pickable>();
				if (pickable == FocusedItem)
				{
					Debugging("Unfocused Item - " + FocusedItem.name);
					FocusedItem.SetFocused(Owner, isFocused: false);
					FocusedItem = null;
				}
				else if ((bool)pickable)
				{
					pickable.SetFocused(Owner, isFocused: false);
				}
			}
		}

		public virtual void TryPickUpDrop()
		{
			if (character == null || !character.IsPlayingAction)
			{
				if (!Has_Item)
				{
					TryPickUp();
				}
				else
				{
					TryDrop();
				}
			}
		}

		public virtual void TryDrop()
		{
			if (base.enabled && (bool)item && !item.InCoolDown)
			{
				if (character != null && !character.IsPlayingAction)
				{
					Item.OnPreDropped.Invoke(base.gameObject);
					Item.PreDroppedReaction?.React(base.gameObject);
				}
				Debugging("Item Try Drop - " + Item.name);
				if (!item.ByAnimation)
				{
					Invoke("DropItem", Item.DropDelay.Value);
				}
			}
		}

		public virtual void TryPickUp()
		{
			if (!base.isActiveAndEnabled || !FocusedItem)
			{
				return;
			}
			if (!FocusedItem.CanBePicked)
			{
				FocusedItem.OnPickedFailed.Invoke(character.gameObject);
				Debugging("Item Picked Failed - " + FocusedItem.name, FocusedItem);
			}
			else
			{
				if (FocusedItem.InCoolDown)
				{
					return;
				}
				if (character != null && !character.IsPlayingAction)
				{
					if (FocusedItem.Align)
					{
						Transform holder = Holder;
						if (extraHolders != null && FocusedItem.holder > -1 && FocusedItem.holder < extraHolders.Count)
						{
							holder = extraHolders[FocusedItem.holder].transform;
						}
						if (TryAlign != null)
						{
							StopCoroutine(TryAlign);
						}
						TryAlign = MTools.AlignTransform_Position(FocusedItem.transform, holder, FocusedItem.AlignTime);
						StartCoroutine(TryAlign);
						PickingItem = true;
					}
					FocusedItem.OnPrePicked.Invoke(character.gameObject);
					FocusedItem.PrePickedReaction?.React(character.gameObject);
				}
				Debugging("Try Pick Up");
				if (!FocusedItem.ByAnimation)
				{
					Invoke("PickUpItem", FocusedItem.PickDelay.Value);
				}
			}
		}

		public void PickUpItem()
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			if (Item == null)
			{
				Item = FocusedItem;
			}
			if (!Item)
			{
				return;
			}
			if (!Item.CanBePicked)
			{
				FocusedItem.OnPickedFailed.Invoke(character.gameObject);
				Debugging("Item Picked Failed - " + FocusedItem.name, FocusedItem);
				return;
			}
			Debugging("Item Picked - " + Item.name);
			if (TryAlign != null)
			{
				StopCoroutine(TryAlign);
			}
			PickingItem = false;
			ParentItemToHolster();
			Item.Picker = this;
			Item.Pick();
			FocusedItem = null;
			OnItemPicked.Invoke(Item.gameObject);
			OnPicking.Invoke(Item.ID);
			_ = Item;
			if (Item.Collectable)
			{
				Item = null;
				PickUpArea.enabled = false;
				this.Delay_Action(delegate
				{
					PickUpArea.enabled = true;
				});
			}
			else if (m_HidePickArea.Value)
			{
				PickUpArea.enabled = false;
			}
			Proxy.ResetTrigger();
		}

		protected virtual void ParentItemToHolster()
		{
			Transform holder = Holder;
			Vector3 localPosition = PosOffset;
			Vector3 localEulerAngles = RotOffset;
			if (Item.holder > -1 && Item.holder < extraHolders.Count)
			{
				holder = extraHolders[Item.holder].transform;
				localPosition = extraHolders[Item.holder].position;
				localEulerAngles = extraHolders[Item.holder].rotation;
			}
			if ((bool)holder)
			{
				Vector3 localScale = Item.transform.localScale;
				Item.transform.parent = holder;
				Item.transform.localPosition = localPosition;
				Item.transform.localEulerAngles = localEulerAngles;
				Item.transform.localScale = localScale;
			}
		}

		public virtual void DropItem()
		{
			if (base.enabled && Has_Item)
			{
				Debugging("Item Dropped - " + Item.name);
				Item.Drop();
				OnItemDrop.Invoke(Item.gameObject);
				OnDropping.Invoke(Item.ID);
				Item = null;
				if (m_HidePickArea.Value)
				{
					PickUpArea.enabled = true;
				}
				if (FocusedItem != null && !FocusedItem.AutoPick)
				{
					Proxy.ResetTrigger();
				}
			}
		}

		private void Debugging(string msg)
		{
			Debugging(msg, this);
		}

		private void Debugging(string msg, UnityEngine.Object ob)
		{
		}

		public virtual bool OnAnimatorBehaviourMessage(string message, object value)
		{
			return this.InvokeWithParams(message, value);
		}
	}
}
