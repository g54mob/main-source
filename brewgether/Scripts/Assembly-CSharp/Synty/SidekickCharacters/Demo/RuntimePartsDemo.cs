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
	public class RuntimePartsDemo : MonoBehaviour
	{
		private readonly string _OUTPUT_MODEL_NAME;

		private Dictionary<CharacterPartType, int> _partIndexDictionary;

		private Dictionary<CharacterPartType, Dictionary<string, SidekickPart>> _availablePartDictionary;

		private DatabaseManager _dbManager;

		private SidekickRuntime _sidekickRuntime;

		private Dictionary<CharacterPartType, Dictionary<string, SidekickPart>> _partLibrary;

		public TextMeshProUGUI _loadingText;

		private void Start()
		{
		}

		public void ForwardTorso()
		{
		}

		public void BackwardTorso()
		{
		}

		public void ForwardUpperArmLeft()
		{
		}

		public void BackwardUpperArmLeft()
		{
		}

		public void ForwardUpperArmRight()
		{
		}

		public void BackwardUpperArmRight()
		{
		}

		public void ForwardLowerArmLeft()
		{
		}

		public void BackwardLowerArmLeft()
		{
		}

		public void ForwardLowerArmRight()
		{
		}

		public void BackwardLowerArmRight()
		{
		}

		public void ForwardHandLeft()
		{
		}

		public void BackwardHandLeft()
		{
		}

		public void ForwardHandRight()
		{
		}

		public void BackwardHandRight()
		{
		}

		public void ForwardBackAttachment()
		{
		}

		public void BackwardBackAttachment()
		{
		}

		public void UpdateBodySize(Slider slider)
		{
		}

		private void UpdateModel()
		{
		}
	}
}
