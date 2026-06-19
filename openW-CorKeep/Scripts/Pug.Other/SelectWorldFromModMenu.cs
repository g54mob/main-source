using System;
using System.Collections.Generic;
using System.IO;
using ModIO;
using PimDeWitte.UnityMainThreadDispatcher;
using Pug.Platform;
using Pug.UnityExtensions;
using PugMod;
using UnityEngine;

public class SelectWorldFromModMenu : SelectWorldMenu
{
	public class ModSave : IEquatable<ModSave>
	{
		public string ModName;

		public long ModId;

		public int WorldIDInMod;

		public FilesystemManager.File WorldSave;

		public string WorldSavePath;

		public FilesystemManager.File WorldInfo;

		public string WorldInfoPath;

		public FilesystemManager.File WorldGenerationParameters;

		public string WorldGenerationParametersPath;

		public FilesystemManager.File ServerMapParts;

		public string ServerMapPartsPath;

		public bool Equals(ModSave other)
		{
			if (ModId == other.ModId)
			{
				return WorldIDInMod == other.WorldIDInMod;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is ModSave other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (ModId.GetHashCode() * 397) ^ WorldIDInMod;
		}

		public static bool operator ==(ModSave left, ModSave right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(ModSave left, ModSave right)
		{
			return !left.Equals(right);
		}
	}

	protected override int numberOfSaveSlotsToInitializeInAwake => 0;

	protected override void InitializeSlot(GameObject instantiatedSlot, int index)
	{
	}

	public override void UpdatePosition()
	{
		float num = menuEntryStartPositionY;
		windowHeight = 0f;
		List<RadicalMenuOption> allCurrentlyActiveMenuOptions = GetAllCurrentlyActiveMenuOptions();
		for (int i = 0; i < allCurrentlyActiveMenuOptions.Count; i++)
		{
			Vector3 localPosition = allCurrentlyActiveMenuOptions[i].transform.localPosition;
			Vector3 localPosition2 = new Vector3(localPosition.x, num, localPosition.z);
			allCurrentlyActiveMenuOptions[i].transform.localPosition = localPosition2;
			num -= menuEntryVirtualHeight;
			windowHeight += menuEntryVirtualHeight;
		}
	}

	protected override void SetupSaveSlots()
	{
		int worldId = Manager.saves.GetWorldId();
		if (!ModIOUnity.IsInitialized())
		{
			Debug.LogError("modio not initialized");
			HandleError("Error/FailedToLoad");
			return;
		}
		IEnumerable<Loader.Mod> mods = Loader.Instance.Mods;
		HashSet<ModSave> hashSet = new HashSet<ModSave>();
		foreach (Loader.Mod item in mods)
		{
			string text = Path.Combine(item.Directory, "Saves");
			if (!Directory.Exists(text))
			{
				Debug.Log("no folder: " + text);
				continue;
			}
			foreach (string item2 in Directory.EnumerateFiles(text, "*", SearchOption.AllDirectories))
			{
				FilesystemManager.File file = FilesystemManager.Parse(Path.GetRelativePath(text, item2).Replace('\\', '/'));
				switch (file.FileID)
				{
				case FilesystemManager.FileID.WorldInfo:
				{
					ModSave orCreateModSave4 = GetOrCreateModSave(item, file, hashSet);
					orCreateModSave4.WorldInfo = file;
					orCreateModSave4.WorldInfoPath = item2;
					break;
				}
				case FilesystemManager.FileID.WorldSave:
				{
					ModSave orCreateModSave3 = GetOrCreateModSave(item, file, hashSet);
					orCreateModSave3.WorldSave = file;
					orCreateModSave3.WorldSavePath = item2;
					break;
				}
				case FilesystemManager.FileID.WorldGenerationParameters:
				{
					ModSave orCreateModSave2 = GetOrCreateModSave(item, file, hashSet);
					orCreateModSave2.WorldGenerationParameters = file;
					orCreateModSave2.WorldGenerationParametersPath = item2;
					break;
				}
				case FilesystemManager.FileID.ServerMapParts:
				{
					ModSave orCreateModSave = GetOrCreateModSave(item, file, hashSet);
					orCreateModSave.ServerMapParts = file;
					orCreateModSave.ServerMapPartsPath = item2;
					break;
				}
				}
			}
		}
		List<ModSave> list = new List<ModSave>();
		foreach (ModSave item3 in hashSet)
		{
			if (item3.WorldSavePath == null || item3.WorldInfoPath == null)
			{
				Debug.LogWarning($"missing some file for mod save: {item3.ModId} {item3.WorldIDInMod}");
				list.Add(item3);
			}
		}
		foreach (ModSave item4 in list)
		{
			hashSet.Remove(item4);
		}
		if (hashSet.Count == 0)
		{
			Debug.LogWarning("no saves found among mods");
			HandleError("Error/FailedToLoad");
			return;
		}
		int num = 0;
		foreach (ModSave item5 in hashSet)
		{
			WorldSlotFromModOption worldSlotFromModOption = null;
			if (menuOptions.Count <= num)
			{
				worldSlotFromModOption = UnityEngine.Object.Instantiate(worldSlotPrefab).GetComponent<WorldSlotFromModOption>();
				worldSlotFromModOption.transform.SetParent(saveSlotsContainer);
				worldSlotFromModOption.transform.localPosition = new Vector3(0f, 0f, 0f);
				menuOptions.Add(worldSlotFromModOption);
			}
			else
			{
				worldSlotFromModOption = (WorldSlotFromModOption)menuOptions[num];
			}
			if (num != 0)
			{
				RadicalMenuOption radicalMenuOption = menuOptions[num - 1];
				radicalMenuOption.bottomUIElements = new List<UIelement> { worldSlotFromModOption };
				worldSlotFromModOption.topUIElements = new List<UIelement> { radicalMenuOption };
			}
			worldSlotFromModOption.Init(item5, this, num, worldId);
			worldSlotFromModOption.SetParentMenu(this);
			worldSlotFromModOption.SetAsInactive();
			worldSlotFromModOption.ResetSelectedOption();
			num++;
		}
		for (int i = num; i < menuOptions.Count; i++)
		{
			UnityEngine.Object.Destroy(menuOptions[i].gameObject);
		}
		menuOptions.Resize(null, num);
		GetSelectedMenuOption()?.OnSelected();
	}

	private void HandleError(string error)
	{
		UnityMainThreadDispatcher.Instance().Enqueue(delegate
		{
			Manager.menu.centerPopUpText.StartNewDisplaySequence(error, null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, delegate
			{
				Manager.menu.PopMenu();
			}, new List<string> { "ok" }, 10f, 0.8f);
		});
	}

	private static ModSave GetOrCreateModSave(Loader.Mod mod, FilesystemManager.File file, HashSet<ModSave> modSaves)
	{
		ModSave modSave = new ModSave
		{
			ModName = mod.Metadata.name,
			ModId = mod.ModId,
			WorldIDInMod = file.instance0
		};
		if (modSaves.TryGetValue(modSave, out var actualValue))
		{
			modSave = actualValue;
		}
		else
		{
			modSaves.Add(modSave);
		}
		return modSave;
	}
}
