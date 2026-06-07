using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ModWindow : MonoBehaviour
{
	public static Dictionary<Type, EventList<object>> Mods = new Dictionary<Type, EventList<object>>
	{
		{
			typeof(ModPackage),
			new EventList<object>()
		},
		{
			typeof(ModController.DLLMod),
			new EventList<object>()
		},
		{
			typeof(Localization.Translation),
			new EventList<object>()
		},
		{
			typeof(FurnitureMod),
			new EventList<object>()
		},
		{
			typeof(BlueprintGroup),
			new EventList<object>()
		},
		{
			typeof(SaveGame),
			new EventList<object>()
		},
		{
			typeof(RoomMaterialPack),
			new EventList<object>()
		},
		{
			typeof(FailMod),
			new EventList<object>()
		}
	};

	public static Dictionary<string, Type> ModNames = new Dictionary<string, Type>
	{
		{
			"DataMods",
			typeof(ModPackage)
		},
		{
			"CodeMods",
			typeof(ModController.DLLMod)
		},
		{
			"Localizations",
			typeof(Localization.Translation)
		},
		{
			"Furniture",
			typeof(FurnitureMod)
		},
		{
			"Blueprints",
			typeof(BlueprintGroup)
		},
		{
			"BuildingMods",
			typeof(SaveGame)
		},
		{
			"MaterialMods",
			typeof(RoomMaterialPack)
		},
		{
			"Error",
			typeof(FailMod)
		}
	};

	public HashSet<Type> EnableAnywhere = new HashSet<Type> { typeof(ModController.DLLMod) };

	public HashSet<Type> Countable = new HashSet<Type>
	{
		typeof(BlueprintGroup),
		typeof(FurnitureMod),
		typeof(ModPackage),
		typeof(RoomMaterialPack),
		typeof(Localization.Translation)
	};

	public GUIListView List;

	public ModDetailPanel Panel;

	public Toggle TogglePrefab;

	public ToggleGroup TogglePanel;

	private List<KeyValuePair<Toggle, Type>> _toggles = new List<KeyValuePair<Toggle, Type>>();

	public MaterialEditorWindow MatWindow;

	private void Start()
	{
		foreach (KeyValuePair<string, Type> modName in ModNames)
		{
			Type type = modName.Value;
			Toggle toggle = UnityEngine.Object.Instantiate(TogglePrefab);
			toggle.isOn = false;
			toggle.GetComponentInChildren<Text>().text = modName.Key.Loc();
			bool isError = modName.Value == typeof(FailMod);
			toggle.onValueChanged.AddListener(delegate(bool x)
			{
				if (x)
				{
					ClearListEvents();
					List.Items = Mods[type];
					List["WorkshopType"].ToggleActive(false, isError);
					List["WorkshopToggle"].ToggleActive(false, EnableAnywhere.Contains(type));
					List["WorkshopCount"].ToggleActive(false, Countable.Contains(type));
				}
			});
			_toggles.Add(new KeyValuePair<Toggle, Type>(toggle, modName.Value));
			toggle.transform.SetParent(TogglePanel.transform, false);
			toggle.group = TogglePanel;
		}
		List.OnSelectChange = delegate
		{
			IWorkshopItem[] selected = List.GetSelected<IWorkshopItem>();
			Panel.SetMod((selected.Length != 0) ? selected[0] : null);
		};
		_toggles[0].Key.isOn = true;
		Panel.SetMod(null);
		List["WorkshopStatus"].ToggleActive(false, SteamManager.Initialized);
	}

	public static void AddMod(IWorkshopItem mod)
	{
		EventList<object> orDefault = Mods.GetOrDefault(mod.GetType());
		if (orDefault != null && !orDefault.Contains(mod))
		{
			orDefault.Add(mod);
		}
	}

	public static void RemoveMod(IWorkshopItem mod)
	{
		if (mod != null)
		{
			EventList<object> orDefault = Mods.GetOrDefault(mod.GetType());
			if (orDefault != null)
			{
				orDefault.Remove(mod);
			}
		}
	}

	private void ClearListEvents()
	{
		List.Items.OnChange = null;
		List.Items.PreChange = null;
	}

	public void OpenFurnitureEditor()
	{
		Example.GotoFurnitureEditor();
	}

	public void OpenHardwareEditor()
	{
		Example.GotoHardwareEditor();
	}

	public void OpenMaterialEditor()
	{
		List<RoomMaterialPack> mats = RoomMaterialController.Instance.MaterialPacks.Where((RoomMaterialPack x) => x.CanUpload).ToList();
		string[] array = new string[mats.Count + 1];
		array[0] = "CreateNew".Loc();
		for (int num = 0; num < mats.Count; num++)
		{
			array[num + 1] = mats[num].ItemTitle;
		}
		WindowManager.Instance.MultiWindow.Show("RoomMaterialEditor", array, delegate(int i)
		{
			if (i == 0)
			{
				RoomMaterialPack pack = new RoomMaterialPack();
				MatWindow.Show(pack);
			}
			else
			{
				MatWindow.Show(mats[i - 1]);
			}
		}, false);
	}

	private void OnDestroy()
	{
		ClearListEvents();
	}
}
