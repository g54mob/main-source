using System.Collections.Generic;
using Dhs5.Utility.Updates;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class ShelfInteractable : MonoBehaviour, ISensable, IMainInteractable, ISecondInteractable, IHoldInteractable
	{
		private struct HoldingCharacterState
		{
			public readonly bool mainInteraction;

			public readonly float timeSinceLastInteraction;

			public HoldingCharacterState(bool mainInteraction, float timeSinceLastInteraction)
			{
				this.mainInteraction = mainInteraction;
				this.timeSinceLastInteraction = timeSinceLastInteraction;
			}
		}

		[Header("Main Components")]
		[SerializeField]
		private ObjectStack m_stack;

		[SerializeField]
		private ShelfLabel m_label;

		[Header("Detection")]
		[SerializeField]
		private Outline m_outline;

		[SerializeField]
		private Outline m_highlight;

		[SerializeField]
		private ShelfInteractableInputHint m_inputHint;

		private IMainInteractable m_mainInteractable;

		private ISecondInteractable m_secondInteractable;

		private bool m_updateRegistered;

		private Dictionary<Character, HoldingCharacterState> m_holdingCharactersState = new Dictionary<Character, HoldingCharacterState>();

		public bool HasProducts => ProductCount > 0;

		public int ProductCount => m_stack.Count;

		public ProductData CurrentProduct => m_stack.GetCurrentData() as ProductData;

		public ObjectStack Stack => m_stack;

		public ShelfLabel Label => m_label;

		private void Awake()
		{
			m_mainInteractable = this;
			m_secondInteractable = this;
			Highlight(highlight: false);
		}

		private void OnEnable()
		{
			m_stack.StackedNewProduct += OnStackNewProduct;
			m_stack.Stacked += OnQuantityChanged;
			m_stack.Poped += OnQuantityChanged;
		}

		private void OnDisable()
		{
			m_stack.StackedNewProduct -= OnStackNewProduct;
			m_stack.Stacked -= OnQuantityChanged;
			m_stack.Poped -= OnQuantityChanged;
		}

		public bool HasBuyableProduct(out ProductData productData)
		{
			productData = CurrentProduct;
			float price;
			if (productData != null && HasProducts)
			{
				return PriceManager.TryGetProductPrice(productData.UID, out price);
			}
			return false;
		}

		public bool CanBeSensed()
		{
			if (World.PlayerController.Context == EControllerContext.CHARACTER)
			{
				EPlayerCharacterContext characterContext = World.PlayerCharacter.CharacterContext;
				return characterContext == EPlayerCharacterContext.NONE || characterContext == EPlayerCharacterContext.GRABBING;
			}
			return false;
		}

		public void OnSensed()
		{
			m_outline.enabled = true;
			if (m_inputHint != null)
			{
				RefreshInputHint();
			}
		}

		public void OnUnsensed()
		{
			if (m_inputHint != null)
			{
				m_inputHint.enabled = false;
			}
			if (m_outline != null)
			{
				m_outline.enabled = false;
			}
		}

		public bool CanMainInteract(Character character)
		{
			if (character.HasGrabbable(out var grabbable))
			{
				if (grabbable is StackableBox stackableBox)
				{
					if (!stackableBox.CanAnimatedPop())
					{
						return false;
					}
					if (!stackableBox.HasStackable(out var productData))
					{
						return false;
					}
					if (!m_stack.CanWelcome(productData))
					{
						return false;
					}
					if (!m_stack.HasSpaceLeft())
					{
						return false;
					}
					return true;
				}
				return false;
			}
			if (character.HasStackable(out var stackable))
			{
				if (stackable.StackableData.StackableType != IStackable.EType.PRODUCT)
				{
					return false;
				}
				if (!m_stack.CanWelcome(stackable.StackableData))
				{
					return false;
				}
				if (!m_stack.HasSpaceLeft())
				{
					return false;
				}
				if (!character.CanGiveStackable())
				{
					return false;
				}
				return true;
			}
			return false;
		}

		void IMainInteractable.OnMainInteractedBy(Character character)
		{
			IStackable stackable;
			if (character.HasGrabbable(out var grabbable))
			{
				if (grabbable is StackableBox stackableBox)
				{
					(IStackable, AnimationPath) tuple = stackableBox.AnimatedPop();
					m_stack.AnimatedStack(tuple.Item1, tuple.Item2);
				}
			}
			else if (character.HasStackable(out stackable) && stackable.StackableData.StackableType == IStackable.EType.PRODUCT)
			{
				IStackable stackable2 = character.GiveStackable();
				m_stack.AnimatedStack(stackable2, default(AnimationPath));
			}
		}

		public bool CanSecondInteract(Character character)
		{
			if (character.HasGrabbable(out var grabbable) && grabbable is StackableBox stackableBox)
			{
				if (!m_stack.HasStackable())
				{
					return false;
				}
				if (!stackableBox.CanWelcome(m_stack.GetCurrentData() as ProductData))
				{
					return false;
				}
				if (!m_stack.CanPop())
				{
					return false;
				}
				return true;
			}
			if (m_stack.TryPeek(out var stackable))
			{
				if (!character.CanHandleStackable(stackable))
				{
					return false;
				}
				if (!m_stack.CanPop())
				{
					return false;
				}
				return true;
			}
			return false;
		}

		void ISecondInteractable.OnSecondInteractedBy(Character character)
		{
			IStackable stackable2;
			if (character.HasGrabbable(out var grabbable))
			{
				if (grabbable is StackableBox stackableBox)
				{
					IStackable stackable = m_stack.Pop();
					stackableBox.AnimatedStack(stackable, default(AnimationPath));
				}
			}
			else if (m_stack.TryPeek(out stackable2))
			{
				IStackable stackable3 = m_stack.Pop();
				character.OnHandleStackable(stackable3);
			}
		}

		public bool CanMainHoldInteractBy(Character character)
		{
			if (!CanAddHoldingCharacter(character, mainInteraction: true))
			{
				return false;
			}
			if (!m_mainInteractable.CanMainInteract(character))
			{
				return false;
			}
			return true;
		}

		public void OnMainHoldInteractStartBy(Character character)
		{
			AddHoldingCharacter(character, mainInteraction: true);
		}

		public void OnMainHoldInteractStopBy(Character character)
		{
			RemoveHoldingCharacter(character, mainInteraction: true);
		}

		public bool CanSecondHoldInteractBy(Character character)
		{
			return false;
		}

		public bool OnSecondHoldInteractStartBy(Character character)
		{
			return false;
		}

		public bool OnSecondHoldInteractStopBy(Character character)
		{
			return false;
		}

		public void Highlight(bool highlight)
		{
			if (m_highlight != null)
			{
				m_highlight.enabled = highlight;
			}
		}

		protected void RegisterToUpdate(bool register)
		{
			if (m_updateRegistered != register)
			{
				m_updateRegistered = register;
				Updater.RegisterChannelCallback(register, EUpdateChannel.GAME_PLAYING, OnUpdate);
			}
		}

		protected virtual void OnUpdate(float deltaTime)
		{
			UpdateHoldingCharacters(deltaTime);
		}

		protected virtual bool CanAddHoldingCharacter(Character character, bool mainInteraction)
		{
			return m_holdingCharactersState.Count == 0;
		}

		protected virtual void AddHoldingCharacter(Character character, bool mainInteraction)
		{
			m_holdingCharactersState[character] = new HoldingCharacterState(mainInteraction, 0.5f);
			if (m_holdingCharactersState.Count == 1)
			{
				RegisterToUpdate(register: true);
			}
		}

		protected virtual void RemoveHoldingCharacter(Character character, bool mainInteraction)
		{
			if (m_holdingCharactersState.TryGetValue(character, out var value) && value.mainInteraction == mainInteraction && m_holdingCharactersState.Remove(character) && m_holdingCharactersState.Count == 0)
			{
				RegisterToUpdate(register: false);
			}
		}

		protected virtual void UpdateHoldingCharacters(float deltaTime)
		{
			foreach (KeyValuePair<Character, HoldingCharacterState> item in m_holdingCharactersState.Copy())
			{
				item.Deconstruct(out var key, out var value);
				Character character = key;
				HoldingCharacterState holdingCharacterState = value;
				float num = holdingCharacterState.timeSinceLastInteraction + deltaTime;
				if (num >= ShelfSettings.HoldInteractionSpeed)
				{
					num %= ShelfSettings.HoldInteractionSpeed;
					if (holdingCharacterState.mainInteraction)
					{
						m_mainInteractable.TryMainInteract(character);
					}
					else
					{
						m_secondInteractable.TrySecondInteract(character);
					}
				}
				m_holdingCharactersState[character] = new HoldingCharacterState(holdingCharacterState.mainInteraction, num);
			}
		}

		private void OnStackNewProduct(ProductData data)
		{
			m_label.SetProduct(data);
		}

		private void OnQuantityChanged()
		{
			m_label.SetQuantity(m_stack.ActualCount);
			RefreshInputHint();
		}

		private void RefreshInputHint()
		{
			if (!(m_inputHint == null))
			{
				if (CanMainInteract(World.PlayerCharacter))
				{
					m_inputHint.AddFlags(ShelfInteractableInputHint.EActionStates.PLACE);
				}
				else
				{
					m_inputHint.RemoveFlags(ShelfInteractableInputHint.EActionStates.PLACE);
				}
				if (CanSecondInteract(World.PlayerCharacter))
				{
					m_inputHint.AddFlags(ShelfInteractableInputHint.EActionStates.TAKE);
				}
				else
				{
					m_inputHint.RemoveFlags(ShelfInteractableInputHint.EActionStates.TAKE);
				}
				bool num = m_inputHint.enabled;
				m_inputHint.enabled = World.PlayerController.Sensor.CurrentSensable is ShelfInteractable shelfInteractable && shelfInteractable == this && CanBeSensed() && m_inputHint.HasFlags();
				if (num && m_inputHint.enabled)
				{
					m_inputHint.Refresh();
				}
			}
		}
	}
}
