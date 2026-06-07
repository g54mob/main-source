using System;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class Bin : MonoBehaviour, ISensable, IMainInteractable, IGrabber
	{
		[SerializeField]
		private Outline m_outline;

		[SerializeField]
		private InputHint m_inputHint;

		private PlayerCharacter m_interactingCharacter;

		public static Furniture FurnitureBeingSold { get; private set; }

		public ClippingObjectBehaviour.ELayerType ClippingLayerType => ClippingObjectBehaviour.ELayerType.DEFAULT;

		public event Action OnInteracted;

		public static event Action TrashThrown;

		public bool CanBeSensed()
		{
			if (World.PlayerController.Context == EControllerContext.CHARACTER)
			{
				EPlayerCharacterContext characterContext = World.PlayerCharacter.CharacterContext;
				if (characterContext == EPlayerCharacterContext.GRABBING || characterContext == EPlayerCharacterContext.MOVING_FURNITURE)
				{
					return CanMainInteract(World.PlayerCharacter);
				}
			}
			return false;
		}

		public void OnSensed()
		{
			m_outline.enabled = true;
			m_inputHint.enabled = true;
		}

		public void OnUnsensed()
		{
			m_outline.enabled = false;
			m_inputHint.enabled = false;
		}

		private bool HasValidGrabbable(Character character)
		{
			if (character.CanGiveGrabbable(out var grabbable))
			{
				return CanGrab(grabbable);
			}
			return false;
		}

		private bool HasValidTrash(Character character, out Trash trash)
		{
			trash = null;
			if (!character.HasStackable(out var stackable) || !(stackable is Trash trash2))
			{
				return false;
			}
			trash = trash2;
			return true;
		}

		public bool CanMainInteract(Character character)
		{
			if (HasValidGrabbable(character))
			{
				return true;
			}
			if (HasValidTrash(character, out var _))
			{
				return true;
			}
			if (character.IsPlayer && character is PlayerCharacter playerCharacter && playerCharacter.IsMovingFurniture(out var furniture))
			{
				return furniture.CanBeSold;
			}
			return false;
		}

		void IMainInteractable.OnMainInteractedBy(Character character)
		{
			Trash trash;
			Furniture furniture;
			if (HasValidGrabbable(character))
			{
				UnityEngine.Object.Destroy(character.GiveGrabbableTo(this).transform.gameObject);
				World.GameState.GainMoney(ShopSettings.BinMoney);
				GameAnalytics.NewOrAddDesignEvent("id_analytics_trashbox", 1f);
				this.OnInteracted?.Invoke();
				Bin.TrashThrown?.Invoke();
			}
			else if (HasValidTrash(character, out trash))
			{
				character.GiveStackable();
				trash.OnRecycled();
				UnityEngine.Object.Destroy(trash.transform.gameObject);
				World.GameState.GainMoney(ShopSettings.TrashBinMoney);
				GameAnalytics.NewOrAddDesignEvent("id_analytics_trashbox", 1f);
				this.OnInteracted?.Invoke();
				Bin.TrashThrown?.Invoke();
			}
			else if (character.IsPlayer && character is PlayerCharacter playerCharacter && playerCharacter.IsMovingFurniture(out furniture) && furniture.CanBeSold)
			{
				m_interactingCharacter = playerCharacter;
				FurnitureBeingSold = furniture;
				World.HUDPopup.Open(EHUDPopupModuleType.SELL_FURNITURE);
				HUDPopup.ModuleValidated += OnHUDPopupModuleValidated;
			}
		}

		public bool CanGrab(IGrabbable grabbable)
		{
			if (grabbable is BaseBox baseBox)
			{
				return baseBox.IsEmpty;
			}
			return false;
		}

		public bool Grab(IGrabbable grabbable)
		{
			return false;
		}

		public bool HasGrabbable(out IGrabbable grabbable)
		{
			grabbable = null;
			return false;
		}

		private void OnHUDPopupModuleValidated(EHUDPopupModuleType type)
		{
			if (type == EHUDPopupModuleType.SELL_FURNITURE)
			{
				HUDPopup.ModuleValidated -= OnHUDPopupModuleValidated;
				if (FurnitureBeingSold != null)
				{
					World.GameState.GainMoney(PriceManager.GetFurnitureMarketStorePrice(FurnitureBeingSold.UID) * FurnitureSettings.ResellPricePercentage);
					World.ShopBuilding.DestroyFurniture(FurnitureBeingSold.GameID);
					m_interactingCharacter.ThrowFurniture();
					this.OnInteracted?.Invoke();
				}
			}
		}
	}
}
