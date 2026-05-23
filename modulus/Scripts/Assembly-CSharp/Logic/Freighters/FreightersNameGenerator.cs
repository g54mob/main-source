using System.Collections.Generic;
using System.Linq;
using Data.Blueprints;
using Logic.Factory;
using NaughtyAttributes;
using UnityEngine;
using Utils;

namespace Logic.Freighters
{
	[CreateAssetMenu(menuName = "Utils/FreightersNameGenerator", fileName = "FreightersNameGenerator", order = 0)]
	public class FreightersNameGenerator : InitScriptableObject
	{
		[SerializeField]
		[LocaKey]
		private string _freighterNamesLocaKey;

		[SerializeField]
		[LocaKey]
		private string _freightHubNamesLocaKey;

		[SerializeField]
		private string[] _baseFreighterNames;

		[SerializeField]
		private string[] _baseFreightHubNames;

		[SerializeField]
		private BlueprintsColorLibrary _colorLibrary;

		private List<string> _freighterNamesList;

		private List<string> _freightHubNamesList;

		private List<string> _usedFreighterNames;

		private List<string> _usedFreightHubNames;

		[Button(null, EButtonEnableMode.Always)]
		private void GetNamesFromLoca()
		{
			_baseFreighterNames = LocalizationUtility.GetLocalizedText(_freighterNamesLocaKey).Split(',');
			_baseFreightHubNames = LocalizationUtility.GetLocalizedText(_freightHubNamesLocaKey).Split(',');
		}

		public override void Init()
		{
			GetNamesFromLoca();
			_freighterNamesList = _baseFreighterNames.ToList();
			_freightHubNamesList = _baseFreightHubNames.ToList();
			_usedFreighterNames = new List<string>();
			_usedFreightHubNames = new List<string>();
			LocalizationUtility.OnLanguageUpdate -= UpdateLanguage;
			LocalizationUtility.OnLanguageUpdate += UpdateLanguage;
		}

		private void UpdateLanguage()
		{
			GetNamesFromLoca();
			_freighterNamesList = _baseFreighterNames.ToList();
			_freightHubNamesList = _baseFreightHubNames.ToList();
		}

		public string GetFreighterName()
		{
			if (_freighterNamesList.Count == 0)
			{
				return string.Format("Freighter {0}", IntIdGenerator.GetNewIdOfKey("Freighter"));
			}
			int index = Random.Range(0, _freighterNamesList.Count);
			string text = _freighterNamesList[index];
			_freighterNamesList.RemoveAt(index);
			_usedFreighterNames.Add(text);
			return text;
		}

		public Color GetFreighterColor()
		{
			return _colorLibrary.Colors[Random.Range(0, _colorLibrary.Colors.Length)];
		}

		public void UseFreighterName(string name)
		{
			if (_baseFreighterNames.Contains(name))
			{
				_usedFreighterNames.Add(name);
				_freighterNamesList.Remove(name);
			}
		}

		public void ReturnFreighterName(string name)
		{
			_usedFreighterNames.Remove(name);
			if (_baseFreighterNames.Contains(name) && !_freighterNamesList.Contains(name))
			{
				_freighterNamesList.Add(name);
			}
		}

		public string GetFreightHubName()
		{
			if (_freightHubNamesList.Count == 0)
			{
				return string.Format("Freight Hub {0}", IntIdGenerator.GetNewIdOfKey("FreightHub"));
			}
			string text = _freightHubNamesList[0];
			_freightHubNamesList.RemoveAt(0);
			_usedFreightHubNames.Add(text);
			return text;
		}

		public void UseFreightHubName(string name)
		{
			if (_baseFreightHubNames.Contains(name))
			{
				_usedFreightHubNames.Add(name);
				_freightHubNamesList.Remove(name);
			}
		}

		public void ReturnFreightHubName(string name)
		{
			_usedFreightHubNames.Remove(name);
			_freightHubNamesList = _baseFreightHubNames.ToList();
			for (int num = _freightHubNamesList.Count - 1; num >= 0; num--)
			{
				if (_usedFreightHubNames.Contains(_freightHubNamesList[num]))
				{
					_freightHubNamesList.RemoveAt(num);
				}
			}
		}
	}
}
