using System;
using System.Collections.Generic;
using FMODUnity;
using I2.Loc;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Buildable/Decorations/Decoration Properties")]
public class DecorationProperties : PlaceableProperties
{
	public class FootprintAttribute : PropertyAttribute
	{
	}

	public enum Turns
	{
		Full = 0,
		Quarter = 1,
		Half = 2,
		ThreeQuarter = 3
	}

	[Serializable]
	public struct Footprint
	{
		public bool[] Toggles;

		[NonSerialized]
		private int _width;

		[NonSerialized]
		private int _depth;

		[NonSerialized]
		private Dictionary<Turns, bool[]> _turnToggles;

		public void InitializeTurns(int width, int depth)
		{
			if (_turnToggles.IsNullOrEmpty() || _width != width || _depth != depth)
			{
				_width = width;
				_depth = depth;
				_turnToggles = new Dictionary<Turns, bool[]>
				{
					{
						Turns.Full,
						Toggles
					},
					{
						Turns.Quarter,
						ReturnQuarterTurnToggles(width, depth)
					},
					{
						Turns.Half,
						ReturnHalfTurnToggles(width, depth)
					},
					{
						Turns.ThreeQuarter,
						ReturnThreeQuarterTurnToggles(width, depth)
					}
				};
			}
		}

		public bool IsToggled(int x, int y, Turns turn)
		{
			switch (turn)
			{
			case Turns.Full:
			case Turns.Half:
				return Toggles[y * _width + x];
			case Turns.Quarter:
			case Turns.ThreeQuarter:
				return Toggles[x * _depth + y];
			default:
				Debug.LogError("Not Supported!");
				return false;
			}
		}

		private bool[] ReturnQuarterTurnToggles(int width, int depth)
		{
			bool[] array = new bool[Toggles.Length];
			int num = 0;
			for (int i = 0; i < width; i++)
			{
				int num2 = depth;
				while (0 < num2--)
				{
					array[num++] = Toggles[i * depth + num2];
				}
			}
			return array;
		}

		private bool[] ReturnHalfTurnToggles(int width, int depth)
		{
			bool[] array = new bool[Toggles.Length];
			int num = 0;
			int num2 = depth;
			while (0 < num2--)
			{
				int num3 = width;
				while (0 < num3--)
				{
					array[num++] = Toggles[num2 * width + num3];
				}
			}
			return array;
		}

		private bool[] ReturnThreeQuarterTurnToggles(int width, int depth)
		{
			bool[] array = new bool[Toggles.Length];
			int num = 0;
			int num2 = width;
			while (0 < num2--)
			{
				for (int i = 0; i < depth; i++)
				{
					array[num] = Toggles[num2 * depth + i];
				}
			}
			return array;
		}
	}

	public static readonly Quaternion ROTATION_FULL = Quaternion.AngleAxis(0f, Vector3.up);

	public static readonly Quaternion ROTATION_QUARTER = Quaternion.AngleAxis(90f, Vector3.up);

	public static readonly Quaternion ROTATION_HALF = Quaternion.AngleAxis(180f, Vector3.up);

	public static readonly Quaternion ROTATION_THREE_QUARTER = Quaternion.AngleAxis(270f, Vector3.up);

	[Header("Decoration Properties")]
	[SerializeField]
	private DecorationType _decorationType;

	[SerializeField]
	private VisualPrefab _visualPrefab;

	[SerializeField]
	private VisualPrefab[] _visualPrefabs;

	[Footprint]
	[SerializeField]
	private Footprint _footprint;

	[SerializeField]
	private DecorationCursorProperties _cursorProperties;

	[SerializeField]
	private bool _isSelectable;

	[SerializeField]
	private LocalizedString _tooltip;

	[Header("Navigation")]
	[SerializeField]
	private bool _overrideHierarchicalNodePanelty;

	[SerializeField]
	[ConditionalHide(false, ConditionalSourceField = "_overrideHierarchicalNodePanelty")]
	private int _hierarchicalNodePanelty;

	[Header("UI Panel")]
	[SerializeField]
	private Sprite _headerSprite;

	[SerializeField]
	private DecorationPanelElementId _uiElements;

	[SerializeField]
	private bool _showMalfunctionElements;

	[SerializeField]
	private bool _showEnergyGridLinkElements;

	[SerializeField]
	private bool _showEnergyStorageElements;

	[SerializeField]
	private bool _showEnergyGridEfficiency;

	[SerializeField]
	private TutorialID _tutorialPageID;

	[Header("FMOD Events")]
	[SerializeField]
	private EventReference _variationEvent;

	[SerializeField]
	private EventReference _rotateEvent;

	[SerializeField]
	private EventReference _placeEvent;

	[SerializeField]
	private EventReference _selectEvent;

	public DecorationType DecorationType => _decorationType;

	public virtual Decoration DecorationPrefab => GameManager.Settings.BuildableSettings.DecorationPrefab;

	public VisualPrefab VisualPrefab => _visualPrefab;

	public VisualPrefab[] VisualPrefabs => _visualPrefabs;

	public override string SurvivalGuideIdentifier => "decoration-" + base.name.ToLower();

	public override Types Type => Types.DecorationProperties;

	public bool IsSelectable => _isSelectable;

	public bool OverrideHierarchicalNodePanelty => _overrideHierarchicalNodePanelty;

	public int HierarchicalNodePanelty => _hierarchicalNodePanelty;

	public Sprite HeaderSprite => _headerSprite;

	public DecorationPanelElementId UIElements => _uiElements;

	public bool ShowMalfunctionElements => _showMalfunctionElements;

	public bool ShowEnergyGridLinkElements => _showEnergyGridLinkElements;

	public bool ShowEnergyStorageElements => _showEnergyStorageElements;

	public bool ShowEnergyGridEfficiency => _showEnergyGridEfficiency;

	public TutorialID TutorialPageID => _tutorialPageID;

	protected override bool DefaultToUnlocked => false;

	public EventReference FMODEventReference_Variation => _variationEvent;

	public EventReference FMODEventReference_Rotate => _rotateEvent;

	public EventReference FMODEventReference_Place => _placeEvent;

	public EventReference FMODEventReference_Select => _selectEvent;

	public override void ActivateCursor(CursorManager.CursorEvent deactivatedCallback)
	{
		_cursorProperties.Initialize(this);
		GameManager.CursorManager.Activate(_cursorProperties, deactivatedCallback);
	}

	public override bool ReturnCanBePlaced(Community community, bool checkResources = true)
	{
		if (base.RequiredResources.IsNullOrEmpty())
		{
			return true;
		}
		return ResourceManager.AreCommunityResourcesAvailable(base.RequiredResources);
	}

	public bool ReturnCanPlaceOnSlots(DecorationSlots decorationSlots)
	{
		if (base.Width <= decorationSlots.Width)
		{
			return base.Depth <= decorationSlots.Height;
		}
		return false;
	}

	public bool ReturnCanPlaceOnSlot(DecorationSlots decorationSlots, int index, Turns turn, List<int> footprintIndices, List<int> boundsInidices)
	{
		bool flag = decorationSlots.Slots[index].IsAvailable(this);
		if (base.Width == 1 && base.Depth == 1 && flag)
		{
			footprintIndices.Add(index);
			boundsInidices.Add(index);
			return true;
		}
		if (decorationSlots.Width < base.Width || decorationSlots.Height < base.Depth || !flag)
		{
			return false;
		}
		int slotX = index % decorationSlots.Width;
		int slotY = index / decorationSlots.Width;
		switch (turn)
		{
		case Turns.Full:
		case Turns.Half:
			return FitsFootprintHorizontal(decorationSlots, turn, slotX, slotY, footprintIndices, boundsInidices);
		case Turns.Quarter:
		case Turns.ThreeQuarter:
			return FitsFootprintVertical(decorationSlots, turn, slotX, slotY, footprintIndices, boundsInidices);
		default:
			throw new NotImplementedException();
		}
	}

	private bool FitsFootprintHorizontal(DecorationSlots decorationSlots, Turns turn, int slotX, int slotY, List<int> footprintIndices, List<int> boundsIndices)
	{
		if (decorationSlots.Width < slotX + base.Width || decorationSlots.Height < slotY + base.Depth)
		{
			return false;
		}
		for (int i = 0; i < base.Depth; i++)
		{
			int num = (slotY + i) * decorationSlots.Width;
			for (int j = 0; j < base.Width; j++)
			{
				int num2 = num + slotX + j;
				boundsIndices.Add(num2);
				if (decorationSlots.Slots[num2].IsAvailable(this) && _footprint.IsToggled(j, i, turn))
				{
					footprintIndices.Add(num2);
					continue;
				}
				return false;
			}
		}
		return true;
	}

	private bool FitsFootprintVertical(DecorationSlots decorationSlots, Turns turn, int slotX, int slotY, List<int> footprintIndices, List<int> boundsIndices)
	{
		if (decorationSlots.Width < slotX + base.Depth || decorationSlots.Height < slotY + base.Width)
		{
			return false;
		}
		for (int i = 0; i < base.Width; i++)
		{
			int num = (slotY + i) * decorationSlots.Width;
			for (int j = 0; j < base.Depth; j++)
			{
				int num2 = num + slotX + j;
				boundsIndices.Add(num2);
				if (decorationSlots.Slots[num2].IsAvailable(this) && _footprint.IsToggled(i, j, turn))
				{
					footprintIndices.Add(num2);
					continue;
				}
				return false;
			}
		}
		return true;
	}

	public override string GetTooltip(TooltipBuilder tooltipBuilder)
	{
		return _tooltip;
	}

	public Quaternion TurnToRotation(Turns turn)
	{
		return turn switch
		{
			Turns.Full => ROTATION_FULL, 
			Turns.Quarter => ROTATION_QUARTER, 
			Turns.Half => ROTATION_HALF, 
			Turns.ThreeQuarter => ROTATION_THREE_QUARTER, 
			_ => throw new NotSupportedException(), 
		};
	}

	public Turns RotationToTurn(Quaternion rotation)
	{
		float y = rotation.eulerAngles.y;
		if (Mathf.Approximately(y, 0f))
		{
			return Turns.Full;
		}
		if (Mathf.Approximately(y, 90f))
		{
			return Turns.Quarter;
		}
		if (Mathf.Approximately(y, 180f))
		{
			return Turns.Half;
		}
		if (Mathf.Approximately(y, 270f))
		{
			return Turns.ThreeQuarter;
		}
		Debug.LogWarningFormat("Unable to convert rotation {0} to Turns, returning Turns.Full", y);
		return Turns.Full;
	}

	public Decoration GetDecorationPrefabWithProperties()
	{
		Decoration decorationPrefab = DecorationPrefab;
		if ((bool)decorationPrefab)
		{
			return decorationPrefab.GetPrefabWithProperties(this);
		}
		return null;
	}
}
