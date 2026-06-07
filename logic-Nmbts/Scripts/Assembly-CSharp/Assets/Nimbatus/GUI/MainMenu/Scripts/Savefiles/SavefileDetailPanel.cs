using System;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts.Savefiles
{
	public class SavefileDetailPanel : MonoBehaviour
	{
		public SavefileListUI List;

		public LoadSaveButton LoadButton;

		public DeleteSaveButton DeleteButton;

		public UILabel InfoLabel;

		public UILabel TimeLabel;

		public UITexture CaptainImage;

		public Texture2D SandboxImage;

		public UIInput NameInput;

		private string _originalName;

		private SavefileListEntry _saveGame;

		public void Init(SavefileListEntry save)
		{
			if (save.Save == null)
			{
				return;
			}
			SaveData save2 = save.Save;
			if (save == _saveGame)
			{
				UpdateTranslation(save);
				return;
			}
			_saveGame = save;
			LoadButton.Init(List);
			DeleteButton.Init(List);
			if (save2.Mode == EGameMode.Campaign)
			{
				DronePerk perk = SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.GetPerk(save2.Settings.DronePerkId);
				if (perk != null)
				{
					CaptainImage.mainTexture = perk.Image;
				}
			}
			else if (save2.Mode == EGameMode.Creative)
			{
				CaptainImage.mainTexture = SandboxImage;
			}
			_originalName = save2.Name;
			NameInput.value = save2.Name;
			UpdateTranslation(_saveGame);
		}

		public void UpdateTranslation(SavefileListEntry savegame)
		{
			InfoLabel.text = savegame.Save.GetDescription();
			TimeSpan timeSpan = TimeSpan.FromSeconds(savegame.Save.TimePlayed);
			string translation = LocalizationManager.GetTermTranslation("MainMenu/SaveGameMeta");
			LocalizationManager.ApplyLocalizationParams(ref translation, new Dictionary<string, string>
			{
				{
					"Date",
					savegame.Save.LastPlayedTime.ToString()
				},
				{
					"PlayTime",
					SavefileListEntry.ToReadableString(timeSpan)
				},
				{
					"Version",
					savegame.Save.SaveGameVersion
				}
			});
			TimeLabel.text = translation;
		}

		public void SubmitName(string text)
		{
			if (text != _originalName)
			{
				_saveGame.Save.Name = text;
				_originalName = text;
				_saveGame.Save.StoreIntoSavefile();
				_saveGame.UpdateName(text);
			}
		}

		public void OnClose()
		{
			SubmitName(NameInput.value);
		}
	}
}
