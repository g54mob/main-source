using DV.CabControls;
using DV.Customization.Paint;
using DV.Interaction.Inputs;
using DV.InventorySystem;
using DV.Items;
using DV.Localization;
using DV.Utils;
using UnityEngine;

namespace DV.Interaction
{
	public class PaintCan : MagazineAmmo, IItemUse
	{
		public enum Validity : byte
		{
			Ok = 0,
			PaintCanMissing = 1,
			PaintCanEmpty = 2,
			AlreadyPainted = 3,
			NotOwnedLoco = 4,
			Incompatible = 5
		}

		private const string LOC_INTERACTION = "interaction/load_paint_can";

		public PaintTheme theme;

		[Header("All paint themes which can transition into the above defined one. Leave empty for always allowed.")]
		public PaintTheme[] transitionsFrom;

		public GameObject emptyCanPrefab;

		[SerializeField]
		private ItemUseTarget itemUseTarget;

		[SerializeField]
		private Renderer canRenderer;

		public override ItemBase Item { get; protected set; }

		public override ItemUseTarget AmmoUseTarget
		{
			get
			{
				return itemUseTarget;
			}
			protected set
			{
				itemUseTarget = value;
			}
		}

		public Material[] OriginalMaterials { get; private set; }

		private void Awake()
		{
			if (canRenderer == null)
			{
				Debug.LogError("PaintCan: Missing Renderer component. Paint can will not be visible.", this);
			}
			else
			{
				OriginalMaterials = canRenderer.sharedMaterials;
			}
		}

		private void Start()
		{
			Item = GetComponent<ItemBase>();
		}

		public Validity CheckPaintApplicationValidity(PaintTheme themeFrom, TrainCar target, bool isCareerMode)
		{
			if (theme == null)
			{
				return Validity.PaintCanEmpty;
			}
			if (theme == themeFrom)
			{
				return Validity.AlreadyPainted;
			}
			if (isCareerMode && !target.uniqueCar)
			{
				return Validity.NotOwnedLoco;
			}
			if (themeFrom == null)
			{
				return Validity.Ok;
			}
			if (transitionsFrom == null || transitionsFrom.Length == 0)
			{
				return Validity.Ok;
			}
			PaintTheme[] array = transitionsFrom;
			foreach (PaintTheme paintTheme in array)
			{
				if (themeFrom == paintTheme)
				{
					return Validity.Ok;
				}
			}
			return Validity.Incompatible;
		}

		public bool HandleHover(ItemUseTarget target)
		{
			if (VRManager.IsVREnabled())
			{
				return false;
			}
			SingletonBehaviour<InteractionTextControllerNonVr>.Instance.DisplayText(LocalizationAPI.L("interaction/load_paint_can", InputManager.Actions.InteractionPrimary.LocalizeInput()));
			return true;
		}

		public bool HandleUse(ItemUseTarget target)
		{
			if (!target.TryGetComponent<PaintSprayer>(out var component))
			{
				return false;
			}
			SingletonBehaviour<Inventory>.Instance.DropItemFromHandsOrInventory(base.gameObject);
			component.HandleUse(itemUseTarget);
			return true;
		}

		public bool IsHoverCompatible(ItemUseTarget target)
		{
			return IsUseCompatible(target);
		}

		public bool IsUseCompatible(ItemUseTarget target)
		{
			if (isSpent)
			{
				return false;
			}
			ItemMagazine component = target.GetComponent<ItemMagazine>();
			if (component == null)
			{
				return false;
			}
			if (!component.ValidItem(this, allowSpent: false))
			{
				return false;
			}
			return component.GetFirstFreeSlot() >= 0;
		}
	}
}
