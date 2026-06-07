using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Character.Suit;
using Assets.Scripts.Craft.Parts.Modifiers.Character;
using Assets.Scripts.Menu.MainMenu;
using Assets.Scripts.Settings;
using Lightbug.CharacterControllerPro.Core;
using UnityEngine;

namespace Assets.Scripts.Character
{
	public class CharacterManager
	{
		public enum CharacterDance
		{
			Shuffle = 0,
			Macarena = 1,
			CrissCross = 2,
			IndianStep = 3,
			RejectStep = 4,
			MillyRock = 5,
			SpongeSwing = 6
		}

		public class Character
		{
			public class CharacterSuit
			{
				public Dictionary<string, CharacterSuitData> Configs { get; set; }

				public string Name { get; set; }

				public string Path { get; set; }

				public CharacterSuitData SelectedConfig => Configs[SelectedConfigName];

				public string SelectedConfigName { get; private set; }

				public void SetSelectedConfig(string name)
				{
					if (Configs.TryGetValue(name, out var _))
					{
						SelectedConfigName = name;
						return;
					}
					Debug.LogWarning("Configuration \"" + name + "\" does not exist for " + Name + " suit.");
					SelectedConfigName = Configs.Keys.FirstOrDefault();
				}
			}

			public CharacterDance Dance { get; set; }

			public string Name { get; set; }

			public CharacterSuit SelectedSuit { get; private set; }

			public Dictionary<string, CharacterSuit> Suits { get; set; }

			public void SetSelectedSuit(string name)
			{
				if (Suits.TryGetValue(name, out var value))
				{
					SelectedSuit = value;
					return;
				}
				Debug.LogWarning("Suit \"" + name + "\" does not exist for " + Name + " character");
			}
		}

		public static readonly string DefaultConfigName = "Default";

		private static CharacterManager _instance;

		public static CharacterManager Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new CharacterManager();
					_instance.LoadCharacterData();
				}
				return _instance;
			}
		}

		public Dictionary<string, Character> Characters { get; private set; }

		public Character SelectedCharacter { get; private set; }

		public CharacterSuitData SelectedConfig => SelectedSuit.SelectedConfig;

		public string SelectedConfigName => SelectedSuit.SelectedConfigName;

		public CharacterDance SelectedDance => SelectedCharacter.Dance;

		public Character.CharacterSuit SelectedSuit => SelectedCharacter.SelectedSuit;

		public CharacterSuitData GetSuitConfig(string characterName, string suitName, string configName)
		{
			if (Characters.TryGetValue(characterName, out var value) && value.Suits.TryGetValue(suitName, out var value2) && value2.Configs.TryGetValue(configName, out var value3))
			{
				return value3;
			}
			return null;
		}

		public string GetSuitPath(string characterName, string suitName)
		{
			if (Characters.TryGetValue(characterName, out var value) && value.Suits.TryGetValue(suitName, out var value2))
			{
				return value2.Path;
			}
			return null;
		}

		public void LoadCharacterData()
		{
			LoadDefaultCharacterData();
			if (File.Exists(GetCharacterSettingsFilePath()))
			{
				try
				{
					XDocument xDocument = XDocument.Load(GetCharacterSettingsFilePath());
					if (xDocument != null)
					{
						LoadCharacterData(xDocument);
					}
					else
					{
						Debug.Log("User character settings file is invalid.");
					}
					return;
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					Debug.LogError("Could not load user character settings.");
					return;
				}
			}
			Debug.Log("User Character Settings file does not exist, so it will be created from the defaults.");
			SaveCharacterSettings();
		}

		public void LoadDefaultCharacterData()
		{
			XDocument xdoc = Game.Instance.ResourceLoader.LoadXml("Characters/CharacterDefinitions-Default");
			LoadCharacterData(xdoc, defaults: true);
		}

		public void SaveCharacterSettings()
		{
			XDocument xDocument = new XDocument();
			XElement xElement = new XElement("Characters");
			xElement.Add(new XAttribute("selected", SelectedCharacter.Name));
			foreach (Character value2 in Characters.Values)
			{
				XElement xElement2 = new XElement("Character");
				xElement2.Add(new XAttribute("name", value2.Name));
				xElement2.Add(new XAttribute("selectedSuit", value2.SelectedSuit.Name));
				xElement2.Add(new XAttribute("dance", (int)value2.Dance));
				foreach (Character.CharacterSuit value3 in value2.Suits.Values)
				{
					XElement xElement3 = new XElement("Suit");
					xElement3.Add(new XAttribute("name", value3.Name));
					xElement3.Add(new XAttribute("selectedConfig", value3.SelectedConfigName));
					foreach (KeyValuePair<string, CharacterSuitData> config in value3.Configs)
					{
						config.Deconstruct(out var key, out var value);
						string name = key;
						XElement content = value.GenerateXml(name);
						xElement3.Add(content);
					}
					xElement2.Add(xElement3);
				}
				xElement.Add(xElement2);
			}
			xDocument.Add(xElement);
			xDocument.Save(GetCharacterSettingsFilePath());
			Debug.Log("Character settings saved.");
		}

		public void SetSelectedCharacter(string name)
		{
			if (Characters.TryGetValue(name, out var value))
			{
				SelectedCharacter = value;
			}
			else
			{
				Debug.LogWarning("Character \"" + name + "\" does not exist.");
			}
		}

		public bool SetSuitConfig(string characterName, string suitName, string configName, CharacterSuitData data)
		{
			if (Characters.TryGetValue(characterName, out var value) && value.Suits.TryGetValue(suitName, out var value2))
			{
				value2.Configs[configName] = data;
				return true;
			}
			return false;
		}

		public CharacterSuitScript SwapCharacterSuit(CharacterSuitScript current, string character, string suit, CharacterSuitData configuration = null)
		{
			GameObject gameObject = Game.Instance.ResourceLoader.InstantiatePrefab(GetSuitPath(character, suit), current.transform.parent);
			gameObject.transform.SetLocalPositionAndRotation(current.transform.localPosition, current.transform.localRotation);
			Animator component = gameObject.GetComponent<Animator>();
			component.runtimeAnimatorController = current.GetComponent<Animator>().runtimeAnimatorController;
			CharacterSuitScript component2 = gameObject.GetComponent<CharacterSuitScript>();
			if (component2 != null && configuration != null)
			{
				component2.ApplyData(configuration);
			}
			if (Game.Instance.SceneManager.InFlightScene)
			{
				CharacterActor componentInParent = current.GetComponentInParent<CharacterActor>(includeInactive: true);
				if (componentInParent != null)
				{
					current.gameObject.SetActive(value: false);
					gameObject.transform.SetAsFirstSibling();
					componentInParent.InitializeAnimation();
				}
				IKSeatScript iKSeatScript = current?.GetComponentInParent<IKSeatScript>();
				if (iKSeatScript != null)
				{
					iKSeatScript.ReleasePose();
					iKSeatScript.StartPose(gameObject.transform);
				}
			}
			else if (Game.Instance.SceneManager.InMenuScene)
			{
				MenuCharacterAnimationScript componentInParent2 = current.GetComponentInParent<MenuCharacterAnimationScript>();
				if (componentInParent2 != null)
				{
					componentInParent2.SetAnimator(component);
				}
			}
			UnityEngine.Object.Destroy(current.gameObject);
			return component2;
		}

		private string GetCharacterSettingsFilePath()
		{
			return SettingsManager.PathForCharacterSettings;
		}

		private void LoadCharacterData(XDocument xdoc, bool defaults = false)
		{
			try
			{
				XElement xElement = xdoc?.Element("Characters");
				if (xElement == null)
				{
					Debug.LogError("Could not find Character Definitions.");
					return;
				}
				if (defaults || Characters == null)
				{
					Characters = new Dictionary<string, Character>();
				}
				foreach (XElement item in xElement.Elements("Character"))
				{
					string stringAttributeOrNullIfEmpty = item.GetStringAttributeOrNullIfEmpty("name");
					if (stringAttributeOrNullIfEmpty == null)
					{
						Debug.LogError("Character element present without a name!");
						continue;
					}
					if (!Characters.TryGetValue(stringAttributeOrNullIfEmpty, out var value))
					{
						value = new Character();
						value.Name = stringAttributeOrNullIfEmpty;
					}
					value.Dance = item.GetEnumAttribute("dance", CharacterDance.Macarena);
					if (defaults || value.Suits == null)
					{
						value.Suits = new Dictionary<string, Character.CharacterSuit>();
					}
					foreach (XElement item2 in item.Elements("Suit"))
					{
						string stringAttributeOrNullIfEmpty2 = item2.GetStringAttributeOrNullIfEmpty("name");
						if (stringAttributeOrNullIfEmpty2 == null)
						{
							Debug.LogError("Suit element present without a name!");
							continue;
						}
						if (!value.Suits.TryGetValue(stringAttributeOrNullIfEmpty2, out var value2))
						{
							value2 = new Character.CharacterSuit();
							value2.Name = stringAttributeOrNullIfEmpty2;
						}
						if (defaults)
						{
							value2.Path = item2.GetStringAttributeOrNullIfEmpty("path");
							if (value2.Path == null)
							{
								Debug.LogError("Default suit \"" + value2.Name + "\" present without path!");
							}
						}
						if (defaults || value2.Configs == null)
						{
							value2.Configs = new Dictionary<string, CharacterSuitData>();
						}
						foreach (XElement item3 in item2.Elements("Config"))
						{
							string stringAttributeOrNullIfEmpty3 = item3.GetStringAttributeOrNullIfEmpty("name");
							if (stringAttributeOrNullIfEmpty3 == null)
							{
								Debug.LogError("Suit Configuration present without a name!");
							}
							else if (stringAttributeOrNullIfEmpty3 != DefaultConfigName || defaults)
							{
								CharacterSuitData characterSuitData = new CharacterSuitData();
								characterSuitData.RestoreFromXml(item3);
								value2.Configs[stringAttributeOrNullIfEmpty3] = characterSuitData;
							}
						}
						string stringAttribute = item2.GetStringAttribute("selectedConfig", value2.Configs.Keys.FirstOrDefault());
						value2.SetSelectedConfig(stringAttribute);
						value.Suits[value2.Name] = value2;
					}
					string stringAttribute2 = item.GetStringAttribute("selectedSuit", value.Suits.Keys.FirstOrDefault());
					value.SetSelectedSuit(stringAttribute2);
					Characters[value.Name] = value;
				}
				string stringAttribute3 = xElement.GetStringAttribute("selected", Characters.Keys.FirstOrDefault());
				SetSelectedCharacter(stringAttribute3);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}
	}
}
