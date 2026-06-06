using System.Collections.Generic;
using Brewery.Interaction;
using Player.Customization.Sidekick;
using Synty.SidekickCharacters.Database.DTO;
using Synty.SidekickCharacters.Enums;
using UI.Core;
using UnityEngine;
using UnityEngine.UIElements;

namespace MyStuff.CharacterCustomizer.Sidekick
{
	public class SidekickWardrobeUI : MonoBehaviour, IUIPanel
	{
		[Header("UI Document")]
		[SerializeField]
		private UIDocument uiDocument;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private SidekickCharacterCustomizer _customizer;

		private WardrobeInteractable _wardrobe;

		private SidekickSaveData _saveData;

		private Dictionary<CharacterPartType, Dictionary<string, SidekickPart>> _partLibrary;

		private Dictionary<CharacterPartType, List<string>> _partNamesByType;

		private Dictionary<CharacterPartType, int> _partIndices;

		private VisualElement _root;

		private VisualElement _panel;

		private bool _isVisible;

		private VisualElement _colorPickerModal;

		private Dictionary<string, Color> _selectedColors;

		private List<SidekickColorProperty> _allColorProperties;

		private static readonly Color[] SkinTones;

		private static readonly Color[] HairColors;

		private static readonly Color[] EyeColors;

		private static readonly Color[] OutfitPalette;

		private static readonly CharacterPartType[] WardrobeParts;

		private static readonly CharacterPartType[] WardrobeAttachments;

		private static readonly HashSet<CharacterPartType> OptionalParts;

		private static readonly Dictionary<CharacterPartType, CharacterPartType> PairedParts;

		private Button _tabHead;

		private Button _tabOutfit;

		private Button _tabExtras;

		private VisualElement _headContent;

		private VisualElement _outfitContent;

		private VisualElement _extrasContent;

		private VisualElement _colorsContent;

		public string PanelId => null;

		public int Priority => 0;

		public bool IsOpen => false;

		public static SidekickWardrobeUI Instance { get; private set; }

		public void Close()
		{
		}

		private static Color C(string hex)
		{
			return default(Color);
		}

		private void Awake()
		{
		}

		private void OnDestroy()
		{
		}

		public void Show(SidekickCharacterCustomizer customizer, WardrobeInteractable wardrobe)
		{
		}

		public void Hide()
		{
		}

		private void BuildPartIndices()
		{
		}

		private void BuildUI()
		{
		}

		private void SelectWardrobeTab(string tab)
		{
		}

		private static VisualElement BuildBackSlotHint()
		{
			return null;
		}

		private VisualElement CreatePartSelector(CharacterPartType partType, bool allowNone = false)
		{
			return null;
		}

		private void CyclePart(CharacterPartType partType, int direction, Label nameLabel, bool allowNone)
		{
		}

		private void UpdatePartLabel(Label label, CharacterPartType partType, bool allowNone = false)
		{
		}

		private string FormatPartTypeName(CharacterPartType partType)
		{
			return null;
		}

		private void PopulateWardrobeColors(VisualElement container)
		{
		}

		private void AddWardrobeOutfitColors(VisualElement container, string areaName, List<SidekickColorProperty> areaProps)
		{
		}

		private void OpenWardrobeMultiZoneColorPicker(string areaName, List<(string label, List<SidekickColorProperty> props)> zones, Dictionary<string, VisualElement> previewSwatches)
		{
		}

		private void AddWardrobeColorRow(VisualElement container, string categoryName, Color[] palette, List<SidekickColorProperty> properties)
		{
		}

		private void OpenWardrobeColorPicker(string categoryName, Color[] palette, List<SidekickColorProperty> properties, VisualElement previewSwatch)
		{
		}

		private void WardrobeApplyColor(Color color, List<SidekickColorProperty> properties)
		{
		}

		private bool ColorsMatch(Color a, Color b)
		{
			return false;
		}
	}
}
