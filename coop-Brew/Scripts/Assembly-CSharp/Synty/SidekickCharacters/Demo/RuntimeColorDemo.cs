using System.Collections.Generic;
using Synty.SidekickCharacters.API;
using Synty.SidekickCharacters.Database;
using Synty.SidekickCharacters.Database.DTO;
using Synty.SidekickCharacters.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Synty.SidekickCharacters.Demo
{
	public class RuntimeColorDemo : MonoBehaviour
	{
		private readonly string _OUTPUT_MODEL_NAME;

		private Dictionary<string, SidekickPartPreset> _availableHeadPresetDictionary;

		private Dictionary<string, SidekickPartPreset> _availableUpperBodyPresetDictionary;

		private Dictionary<string, SidekickPartPreset> _availableLowerBodyPresetDictionary;

		private List<SidekickBodyShapePreset> _availableBodyShapes;

		private List<SidekickColorPreset> _availableColorPresets;

		private int _currentHeadPresetIndex;

		private int _currentUpperBodyPresetIndex;

		private int _currentLowerBodyPresetIndex;

		private int _currentBodyShapePresetIndex;

		private int _currentColorPresetIndex;

		private DatabaseManager _dbManager;

		private SidekickRuntime _sidekickRuntime;

		private Dictionary<CharacterPartType, Dictionary<string, SidekickPart>> _partLibrary;

		public TextMeshProUGUI _loadingText;

		private void Start()
		{
		}

		public void ProcessSkinColorChange(Image image)
		{
		}

		public void ProcessOutfitColorChange(Image image)
		{
		}

		private void UpdateModel()
		{
		}

		private string GetResourcePath(string fullPath)
		{
			return null;
		}
	}
}
