using System;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts.Savefiles
{
	public class SavefileListEntry : MonoBehaviour
	{
		public UILabel NameLabel;

		public UILabel DescriptionLabel;

		public UITexture Background;

		public UITexture Image;

		public Texture2D SandboxImage;

		public Texture2D DefaultImage;

		public Color NormalColor;

		public Color HoverColor;

		public Color SelectedColor;

		public SaveData Save;

		private SavefileListUI _parent;

		private bool _hover;

		public void Init(SavefileListUI parent, SaveData savegame)
		{
			_parent = parent;
			Save = savegame;
			NameLabel.text = savegame.Name;
			UpdateDescription(savegame);
			if (savegame.Mode == EGameMode.Campaign)
			{
				DronePerk perk = SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.GetPerk(savegame.Settings.DronePerkId);
				if (perk != null)
				{
					Image.mainTexture = perk.Icon;
				}
			}
			else if (savegame.Mode == EGameMode.Creative)
			{
				Image.mainTexture = SandboxImage;
			}
			else
			{
				Image.mainTexture = DefaultImage;
			}
		}

		public void UpdateName(string text)
		{
			NameLabel.text = text;
		}

		public void UpdateDescription(SaveData savegame)
		{
			TimeSpan timeSpan = TimeSpan.FromSeconds(savegame.TimePlayed);
			string translation = LocalizationManager.GetTermTranslation("MainMenu/SaveGameMeta");
			LocalizationManager.ApplyLocalizationParams(ref translation, new Dictionary<string, string>
			{
				{
					"Date",
					savegame.LastPlayedTime.ToString()
				},
				{
					"PlayTime",
					ToReadableString(timeSpan)
				},
				{ "Version", Save.SaveGameVersion }
			});
			DescriptionLabel.text = translation;
		}

		public void Update()
		{
			if (_parent != null)
			{
				if (_parent.SelectedSaveFile == this)
				{
					Background.color = SelectedColor;
				}
				else
				{
					Background.color = (_hover ? HoverColor : NormalColor);
				}
			}
		}

		public static string ToReadableString(TimeSpan timeSpan)
		{
			return Mathf.FloorToInt((float)timeSpan.TotalHours).ToString("F0") + ":" + timeSpan.Minutes.ToString("00") + ":" + timeSpan.Seconds.ToString("00");
		}

		public void OnClick()
		{
			_parent.SelectedSaveFile = this;
		}

		public void OnHover(bool isOver)
		{
			_hover = isOver;
		}
	}
}
