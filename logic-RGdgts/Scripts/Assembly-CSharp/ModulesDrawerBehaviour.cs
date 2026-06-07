using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Tables;

public class ModulesDrawerBehaviour : ScrollableDrawerBehaviour
{
	public enum Mode
	{
		Sandbox = 0,
		Campaign = 1
	}

	public abstract class Slot
	{
		public abstract float GetCenter(DraggablePanel.Direction direction);

		public abstract float GetMax(DraggablePanel.Direction direction);

		public abstract float GetMin(DraggablePanel.Direction direction);

		public abstract Vector3 GetWorldPickupPosition();

		public abstract Bounds GetWorldBounds();

		public abstract Interactable GetInteractable();
	}

	public class ModuleSlot : Slot
	{
		public ModuleGestaltVariationEnum moduleGestaltVariationEnum;

		public DrawerContentModule moduleDrawerContent;

		public override float GetCenter(DraggablePanel.Direction direction)
		{
			return 0f;
		}

		public override float GetMax(DraggablePanel.Direction direction)
		{
			return 0f;
		}

		public override float GetMin(DraggablePanel.Direction direction)
		{
			return 0f;
		}

		public override Vector3 GetWorldPickupPosition()
		{
			return default(Vector3);
		}

		public override Bounds GetWorldBounds()
		{
			return default(Bounds);
		}

		public override Interactable GetInteractable()
		{
			return null;
		}

		public ModuleSlot(ModuleGestaltVariationEnum moduleGestaltVariationEnum, DrawerContentModule moduleDrawerContent)
		{
		}
	}

	public class MotherboardSectionSlot : Slot
	{
		public MotherboardSectionEnum motherboardSectionEnum;

		public DrawerContentMotherboardSection motherboardSectionContent;

		public override float GetCenter(DraggablePanel.Direction direction)
		{
			return 0f;
		}

		public override float GetMax(DraggablePanel.Direction direction)
		{
			return 0f;
		}

		public override float GetMin(DraggablePanel.Direction direction)
		{
			return 0f;
		}

		public override Vector3 GetWorldPickupPosition()
		{
			return default(Vector3);
		}

		public override Bounds GetWorldBounds()
		{
			return default(Bounds);
		}

		public override Interactable GetInteractable()
		{
			return null;
		}

		public MotherboardSectionSlot(MotherboardSectionEnum motherboardSectionEnum, DrawerContentMotherboardSection motherboardSectionContent)
		{
		}
	}

	private struct MotherboardsSectionsLayoutElement
	{
		public GadgetCoverMaterial coverMaterial;

		public DrawerContentSpriteAndLabel label;

		public DrawerContentSubpanel subpanel;
	}

	public Mode mode;

	public GameObject labelPrefab;

	public GameObject sandboxModulePrefab;

	public GameObject campaignModulePrefab;

	public GameObject sandboxMotherboardSectionPrefab;

	public GameObject campaignMotherboardSectionPrefab;

	public GameObject separatorPrefab;

	public GameObject materialLabelPrefab;

	public GameObject subpanelPrefab;

	public float additionalEndSpace;

	public ModuleGestalt.ModuleCategory category;

	public bool addMotherboardSections;

	public const float layoutModuleSpace = 0.4166667f;

	public const float layoutTextSpace = 1f / 3f;

	public const float layoutStartSpace = 1f / 3f;

	public const float layoutEndSpace = 1f / 6f;

	private int layer;

	private List<Slot> slots;

	private GadgetCoverMaterial coverMaterial;

	private List<MotherboardsSectionsLayoutElement> motherboardSectionsLayout;

	private Dictionary<ModuleGestaltVariationEnum, Queue<DrawerContentModule>> reusableModules;

	private Dictionary<MotherboardSectionEnum, Queue<DrawerContentMotherboardSection>> reusableMotherboards;

	public bool IsSlotInCenterArea(Slot slot)
	{
		return false;
	}

	public ModuleSlot GetModuleSlot(ModuleGestaltVariationEnum moduleGestaltVariation)
	{
		return null;
	}

	public bool CenterOnModule(ModuleGestaltVariationEnum moduleGestaltVariation, bool fast = false, bool immediate = false)
	{
		return false;
	}

	public MotherboardSectionSlot GetMotherboardSectionSlot(MotherboardSectionEnum motherboardSectionEnum)
	{
		return null;
	}

	public bool CenterOnMotherboardSection(MotherboardSectionEnum motherboardSectionEnum, bool fast = false, bool immediate = false)
	{
		return false;
	}

	public bool CenterOnSlot(Slot slot, bool fast = false, bool immediate = false)
	{
		return false;
	}

	public override void Init(Drawer drawer)
	{
	}

	public override void ClearContents()
	{
	}

	private void ClearContent(DrawerContent content)
	{
	}

	private void ClearModule(DrawerContentModule module)
	{
	}

	private void ClearMotherboardSection(DrawerContentMotherboardSection section)
	{
	}

	public void RefreshContents(bool immediateRefresh = false)
	{
	}

	private void RefreshMotherboardsSectionsLayout()
	{
	}

	public float AddModule(ModuleGestalt.Variation moduleGestaltVariation, float position, float offset = 0f, int rotation = 0, bool bottomPivot = true)
	{
		return 0f;
	}

	public float AddMotherboardSection(MotherboardSection section, float position, GadgetCoverMaterial coverMaterial, float offset = 0f, bool bottomPivot = true, DrawerContentSubpanel subpanel = null)
	{
		return 0f;
	}

	public float AddLabel(TableReference tableRef, TableEntryReference entryRef, float position, bool bottomPivot = true)
	{
		return 0f;
	}

	public float AddSeparator(float position, bool bottomPivot = true)
	{
		return 0f;
	}

	public (float, DrawerContentSpriteAndLabel) AddMaterialLabel(TableReference tableRef, TableEntryReference entryRef, float position, bool bottomPivot = true, Action onInteraction = null)
	{
		return default((float, DrawerContentSpriteAndLabel));
	}

	public DrawerContentSubpanel AddSubpanel(float position, int index)
	{
		return null;
	}

	private void SetCoverMaterial(GadgetCoverMaterial coverMaterial)
	{
	}

	protected override void Update()
	{
	}

	private void OnDestroy()
	{
	}
}
