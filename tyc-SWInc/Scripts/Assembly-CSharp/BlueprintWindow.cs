using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BlueprintWindow : MonoBehaviour
{
	public GUIWindow Window;

	public RawImage Thumbnail;

	public GameObject SteamSticker;

	private Texture2D MainTexture;

	public Text InfoText;

	public Toggle WithBasement;

	public Toggle Furnished;

	public Toggle CreateGroups;

	public Toggle TrashCans;

	public GUICombobox GroupOption;

	public Button GroupSelection;

	public Text GroupSelectionLabel;

	public RectTransform BlueprintPanel;

	public RectTransform ReplacePanel;

	public RectTransform ReplaceContent;

	public List<Button> ReplaceButtonPool = new List<Button>();

	[NonSerialized]
	private int _replaceCount;

	public List<BluePrintUIItem> Items = new List<BluePrintUIItem>();

	public BluePrintUIItem GroupPrefab;

	public BluePrintUIItem ItemPrefab;

	public BluePrintUIItem SinglePrefab;

	[NonSerialized]
	public BluePrintUIItem Selected;

	public InputField SearchBar;

	[NonSerialized]
	public Dictionary<string, string> Replacements = new Dictionary<string, string>();

	public static BlueprintWindow Instance
	{
		get
		{
			HUD instance = HUD.Instance;
			if ((object)instance == null)
			{
				return null;
			}
			return instance.blueprint;
		}
	}

	public void GroupOptionChange()
	{
		RoomCloneTool.GroupOption selected = GroupOption.GetSelected<RoomCloneTool.GroupOption>();
		GroupSelection.gameObject.SetActive(selected == RoomCloneTool.GroupOption.Replace);
		CreateGroups.gameObject.SetActive(selected == RoomCloneTool.GroupOption.Copy);
		if (selected == RoomCloneTool.GroupOption.Replace)
		{
			string text = GameSettings.Instance.GetRoomGroups(false).FirstOrDefault();
			GroupSelectionLabel.text = text ?? "None".Loc();
		}
	}

	public void SelectGroupReplacement()
	{
		List<string> g = GameSettings.Instance.GetRoomGroups(false, true).ToList();
		if (g.Count > 0)
		{
			WindowManager.Instance.MultiWindow.Show("Roomgroups".Loc(), g, delegate(int x)
			{
				GroupSelectionLabel.text = g[x];
			}, false);
		}
	}

	public void SearchUpdate()
	{
		if (string.IsNullOrWhiteSpace(SearchBar.text))
		{
			for (int i = 0; i < Items.Count; i++)
			{
				BluePrintUIItem bluePrintUIItem = Items[i];
				bluePrintUIItem.gameObject.SetActive(bluePrintUIItem.Group || bluePrintUIItem.ParentItem == null || bluePrintUIItem.ParentItem.Unfolded);
			}
			return;
		}
		bool flag = true;
		for (int j = 0; j < BlueprintPanel.childCount; j++)
		{
			BluePrintUIItem component = BlueprintPanel.GetChild(j).GetComponent<BluePrintUIItem>();
			if (!(component != null))
			{
				continue;
			}
			if (component.Group)
			{
				component.gameObject.SetActive(false);
				continue;
			}
			bool flag2 = (component.Parent.IsSingleton() ? component.Parent.ItemTitle : component.Prefab.Name).ToLower().Contains(SearchBar.text.ToLower());
			if (flag2 && flag)
			{
				flag = false;
				Select(component);
			}
			component.gameObject.SetActive(flag2);
		}
	}

	public void Select(BluePrintUIItem item)
	{
		if (Selected != null)
		{
			Selected.Select(false);
		}
		Selected = item;
		if (Selected != null)
		{
			Selected.Select(true);
			string path = Path.Combine(Selected.Parent.FolderPath(), Selected.Prefab.Name + ".png");
			if (!File.Exists(path))
			{
				if (Selected.Parent.CanUpload)
				{
					try
					{
						File.WriteAllBytes(path, GenerateThumbnail(Selected.Prefab));
					}
					catch (Exception ex)
					{
						Debug.Log(ex.ToString());
					}
				}
				else
				{
					path = Path.Combine(Selected.Parent.FolderPath(), "Thumbnail.png");
				}
			}
			if (File.Exists(path))
			{
				MainTexture.LoadImage(File.ReadAllBytes(path));
				MainTexture.Apply();
				Thumbnail.texture = MainTexture;
			}
			else
			{
				Thumbnail.texture = null;
			}
			SteamSticker.SetActive(Selected.Parent.GetSteamID().HasValue);
		}
		else
		{
			SteamSticker.SetActive(false);
		}
		UpdateBasementToggle();
		Furnished.isOn = true;
		UpdateReplacement();
		UpdateInfo();
	}

	public void UpdateFurnished()
	{
		bool flag = Furnished.isOn && _replaceCount > 0;
		if (flag != ReplacePanel.gameObject.activeSelf)
		{
			if (flag)
			{
				ReplacePanel.gameObject.SetActive(true);
				ReplacePanel.localScale = Vector3.one;
			}
			else
			{
				ReplacePanel.gameObject.SetActive(false);
			}
		}
		UpdateInfo();
	}

	private void Awake()
	{
		MainTexture = new Texture2D(256, 256, TextureFormat.ARGB32, false);
		Thumbnail.texture = MainTexture;
	}

	private void OnDestroy()
	{
		UnityEngine.Object.Destroy(MainTexture);
	}

	public void CreateItems(BlueprintGroup group)
	{
		if (group.Prefabs.Count <= 0)
		{
			return;
		}
		if (group.IsSingleton())
		{
			CreateItem(group, group.Prefabs[0], null);
			return;
		}
		BluePrintUIItem bluePrintUIItem = UnityEngine.Object.Instantiate(GroupPrefab);
		bluePrintUIItem.Label.text = group.ItemTitle;
		bluePrintUIItem.transform.SetParent(BlueprintPanel, false);
		bluePrintUIItem.Parent = group;
		Items.Add(bluePrintUIItem);
		for (int i = 0; i < group.Prefabs.Count; i++)
		{
			CreateItem(group, group.Prefabs[i], bluePrintUIItem);
		}
	}

	public void RenameItem(BluePrintUIItem item)
	{
		if (item.Group || item.ParentItem == null)
		{
			WindowManager.SpawnInputDialog("BlueprintGroupPrompt".Loc(), "BlueprintGroupPromptTitle".Loc(), item.Label.text, delegate(string name)
			{
				string text = Utilities.CleanFileName(name);
				item.Parent.SetName(text, false);
				if (item.Parent.MetaData.SaveChanges())
				{
					item.Label.text = text;
					RefreshOrder();
				}
				else
				{
					WindowManager.SpawnDialog("BlueprintSaveError".Loc("N/A"), true, DialogWindow.DialogType.Error);
				}
			});
			return;
		}
		WindowManager.SpawnInputDialog("BlueprintPrompt".Loc(), "BlueprintPromptTitle".Loc(), item.Label.text, delegate(string name)
		{
			string rName = Utilities.CleanFileName(name);
			if (item.Parent.Prefabs.Any((BuildingPrefab x) => x.Name.Equals(rName)))
			{
				WindowManager.SpawnDialog("BlueprintPromptError".Loc(), true, DialogWindow.DialogType.Error);
			}
			else if (!RenamePrefab(rName, item.Parent, item.Prefab))
			{
				WindowManager.SpawnDialog("BlueprintSaveError".Loc("N/A"), true, DialogWindow.DialogType.Error);
			}
			else
			{
				item.Label.text = rName;
				RefreshOrder();
			}
		});
	}

	public BluePrintUIItem CreateItem(BlueprintGroup group, BuildingPrefab prefab, BluePrintUIItem parent)
	{
		BluePrintUIItem bluePrintUIItem = UnityEngine.Object.Instantiate((parent == null) ? SinglePrefab : ItemPrefab);
		bluePrintUIItem.transform.SetParent(BlueprintPanel, false);
		bluePrintUIItem.Label.text = ((parent == null) ? group.ItemTitle : prefab.Name);
		bluePrintUIItem.Parent = group;
		bluePrintUIItem.Prefab = prefab;
		bluePrintUIItem.ParentItem = parent;
		Items.Add(bluePrintUIItem);
		if (parent != null)
		{
			parent.Children.Add(bluePrintUIItem);
			bluePrintUIItem.gameObject.SetActive(parent.Unfolded);
		}
		return bluePrintUIItem;
	}

	public void RefreshOrder()
	{
		int num = 0;
		foreach (BluePrintUIItem item in from x in Items
			orderby x.Parent.IsSingleton() ? 1 : 0, x.Parent.ItemTitle, (!x.Group) ? x.Prefab.Name : null
			select x)
		{
			item.transform.SetSiblingIndex(num);
			num++;
		}
	}

	private void Start()
	{
		GameData.Blueprints.ForEach(CreateItems);
		GroupOption.UpdateContent(Enum.GetValues(typeof(RoomCloneTool.GroupOption)).OfType<RoomCloneTool.GroupOption>());
		RefreshOrder();
	}

	public void ToggleBasement()
	{
		UpdateInfo();
	}

	public void UpdateBasementToggle()
	{
		BluePrintUIItem selected = Selected;
		BuildingPrefab buildingPrefab = (((object)selected != null) ? selected.Prefab : null);
		if (buildingPrefab != null)
		{
			WithBasement.isOn = true;
			WithBasement.gameObject.SetActive(buildingPrefab.Rooms.Any((BuildingPrefab.RoomObject x) => x.Floor < 0));
		}
		else
		{
			WithBasement.gameObject.SetActive(false);
		}
	}

	public Button GetReplaceButton()
	{
		Button button;
		if (_replaceCount < ReplaceButtonPool.Count)
		{
			button = ReplaceButtonPool[_replaceCount];
		}
		else
		{
			button = UnityEngine.Object.Instantiate(ReplaceButtonPool[0]);
			ReplaceButtonPool.Add(button);
		}
		button.transform.SetParent(ReplaceContent, false);
		button.gameObject.SetActive(true);
		button.onClick.RemoveAllListeners();
		_replaceCount++;
		return button;
	}

	public void UpdateReplacement()
	{
		Replacements.Clear();
		ReplaceButtonPool.ForEach(delegate(Button x)
		{
			x.gameObject.SetActive(false);
		});
		_replaceCount = 0;
		BluePrintUIItem selected = Selected;
		BuildingPrefab buildingPrefab = (((object)selected != null) ? selected.Prefab : null);
		if (buildingPrefab != null)
		{
			foreach (var furn in (from x in buildingPrefab.Rooms.SelectMany((BuildingPrefab.RoomObject x) => x.Furniture)
				group x by x.Name into x
				select new ValueTuple<string, int>(x.Key, x.Count())).OrderByDescending(([TupleElementNames(new string[] { "Key", null })] ValueTuple<string, int> x) => x.Item2))
			{
				Furniture f = ObjectDatabase.Instance.GetFurnitureComponent(furn.Item1);
				if (!(f != null))
				{
					continue;
				}
				HashSet<string> replacables = ObjectDatabase.Instance.GetReplacables(furn.Item1);
				if (f.IsPurchasable() && f.IsUnlocked() && (replacables == null || !replacables.Any((string x) => x != furn.Item1 && ObjectDatabase.Instance.CurrentlyValidFurnitureReplacement(x))))
				{
					continue;
				}
				Furniture optimalReplacement = ObjectDatabase.Instance.GetOptimalReplacement(f);
				if (optimalReplacement != null)
				{
					Replacements[f.name] = optimalReplacement.name;
				}
				optimalReplacement = optimalReplacement ?? f;
				Button replaceButton = GetReplaceButton();
				Text[] l = replaceButton.GetComponentsInChildren<Text>(true);
				l[0].text = Localization.GetFurniture(optimalReplacement.GetLocalizationName(), optimalReplacement.GetDefaultName(), optimalReplacement.ButtonDescription)[0];
				Text obj = l[1];
				int item = furn.Item2;
				obj.text = item.ToString();
				Image[] images = replaceButton.GetComponentsInChildren<Image>(true);
				images[1].sprite = optimalReplacement.Thumbnail;
				images[2].gameObject.SetActive(!optimalReplacement.IsPurchasable() || !optimalReplacement.IsUnlocked());
				replaceButton.onClick.AddListener(delegate
				{
					SelectorController.Instance.FurnReplacer.Show(f, delegate(Furniture x)
					{
						if (x.name == furn.Item1)
						{
							Replacements.Remove(x.name);
						}
						else
						{
							Replacements[furn.Item1] = x.name;
						}
						l[0].text = Localization.GetFurniture(x.GetLocalizationName(), x.GetDefaultName(), x.ButtonDescription)[0];
						images[1].sprite = x.Thumbnail;
						images[2].gameObject.SetActive(false);
						UpdateInfo();
					});
				});
			}
			if (_replaceCount > 0)
			{
				if (Furnished.isOn)
				{
					ReplacePanel.gameObject.SetActive(true);
					ReplacePanel.localScale = new Vector3(0f, 1f, 1f);
					ReplacePanel.DOScaleX(1f, 0.2f);
				}
				else
				{
					ReplacePanel.gameObject.SetActive(false);
					ReplacePanel.localScale = Vector3.one;
				}
			}
			else
			{
				ReplacePanel.gameObject.SetActive(false);
			}
		}
		else
		{
			ReplacePanel.gameObject.SetActive(false);
		}
	}

	public void UpdateInfo()
	{
		BluePrintUIItem selected = Selected;
		BuildingPrefab blueprint = (((object)selected != null) ? selected.Prefab : null);
		if (blueprint != null)
		{
			bool flag = blueprint.AddTrashCans;
			List<BuildingPrefab.RoomObject> list = blueprint.Rooms.Where((BuildingPrefab.RoomObject roomObject) => WithBasement.isOn || roomObject.Floor >= 0).ToList();
			List<string> list2 = (from furnitureObject in list.SelectMany((BuildingPrefab.RoomObject roomObject) => roomObject.Furniture)
				where Furnished.isOn || furnitureObject.IsConstructionFurniture()
				select Replacements.GetOrDefault(furnitureObject.Name, furnitureObject.Name)).ToList();
			HashSet<string> hashSet = (from text2 in list2.Distinct()
				where ObjectDatabase.Instance.GetFurniture(text2) == null
				select text2).ToHashSet();
			List<Furniture> list3 = list2.SelectNotNull((string text2) => ObjectDatabase.Instance.GetFurnitureComponent(text2)).ToList();
			hashSet.AddRange(from furniture in list3.Distinct()
				where !furniture.IsPurchasable()
				select furniture.name);
			string text = ((hashSet.Count > 0) ? string.Join("\n", hashSet.ToArray()) : "None".Loc());
			int minF = list.Min((BuildingPrefab.RoomObject roomObject) => roomObject.Floor);
			int maxF = list.Max((BuildingPrefab.RoomObject roomObject) => roomObject.Floor);
			float num = list.SumSafe((BuildingPrefab.RoomObject z, int i) => (z.Atrium >= 0 && z.Atrium != i) ? 0f : z.Area);
			float num2 = list.SumSafe(delegate(BuildingPrefab.RoomObject roomObject, int i)
			{
				BuildingPrefab.RoomObject.AtriumType atriumType = roomObject.GetAtriumType(i, blueprint.Rooms);
				return BuildController.GetRoomCost(roomObject.Edges.Select((int y) => blueprint.Edges[y].ToVector2()).ToList(), roomObject.Area, roomObject.Outdoor || atriumType == BuildingPrefab.RoomObject.AtriumType.Balcony, roomObject.Pillar, roomObject.Floor - minF - 1, false, false, atriumType == BuildingPrefab.RoomObject.AtriumType.Upper);
			});
			float num3 = list.SumSafe(delegate(BuildingPrefab.RoomObject roomObject, int i)
			{
				BuildingPrefab.RoomObject.AtriumType atriumType = roomObject.GetAtriumType(i, blueprint.Rooms);
				return BuildController.GetRoomCost(roomObject.Edges.Select((int y) => blueprint.Edges[y].ToVector2()).ToList(), roomObject.Area, roomObject.Outdoor || atriumType == BuildingPrefab.RoomObject.AtriumType.Balcony, roomObject.Pillar, GameSettings.MaxFloor - (maxF - Mathf.Max(0, minF)) + roomObject.Floor, false, false, atriumType == BuildingPrefab.RoomObject.AtriumType.Upper);
			});
			float num4 = list.SelectMany((BuildingPrefab.RoomObject roomObject) => roomObject.Segments).SumSafe(delegate(BuildingPrefab.SegmentObject segmentObject)
			{
				RoomSegment segmentComponent = ObjectDatabase.Instance.GetSegmentComponent(segmentObject.Name);
				return (!(segmentComponent == null)) ? (segmentComponent.Cost / segmentComponent.WallWidth * segmentObject.Width) : 0f;
			});
			num3 += num4;
			num2 += num4;
			float x = list3.SumSafe((Furniture furniture) => furniture.GetCost());
			int num5 = list3.Count((Furniture furniture) => "Computer".Equals(furniture.Type));
			if (flag)
			{
				flag = flag && num5 > 0;
			}
			TrashCans.gameObject.SetActive(flag);
			TrashCans.isOn = flag;
			InfoText.text = string.Format("{0}: {1}\n{2}: {3}\n{4}: {5}\n{6}: {7}\n{8}:\n{9}", "Squaremeters".Loc(), num, "Buildingcost".Loc(), num2.Currency() + " - " + num3.Currency(), "Furniturecost".Loc(), x.Currency(), "Computers".Loc(), num5, "Incompatiblefurniture".Loc(), text);
		}
		else
		{
			InfoText.text = "";
			TrashCans.gameObject.SetActive(false);
		}
	}

	public void Build()
	{
		BluePrintUIItem selected = Selected;
		BuildingPrefab buildingPrefab = (((object)selected != null) ? selected.Prefab : null);
		if (buildingPrefab != null)
		{
			RoomCloneTool.Instance.Show(buildingPrefab, WithBasement.isOn, Replacements.ToDictionary((KeyValuePair<string, string> z) => z.Key, (KeyValuePair<string, string> z) => z.Value), Furnished.isOn, GroupOption.GetSelected<RoomCloneTool.GroupOption>(), GroupSelectionLabel.text, CreateGroups.isOn, TrashCans.isOn);
			Window.Close();
		}
	}

	public void UpdatePrefab(BluePrintUIItem item)
	{
		BuildingPrefab prefab;
		byte[] thumbData;
		if (GetRooms(SelectorController.Instance.Selected, out prefab, out thumbData))
		{
			if (!item.Parent.CanUpload)
			{
				WindowManager.Instance.ShowMessageBox("OverwriteError".Loc(), false, DialogWindow.DialogType.Error);
				return;
			}
			string path = item.Parent.FolderPath();
			File.WriteAllText(Path.Combine(path, item.Prefab.Name + ".xml"), XMLParser.ExportXML(prefab.ToXmlNode()));
			File.WriteAllBytes(Path.Combine(path, item.Prefab.Name + ".png"), thumbData);
			prefab.Name = item.Prefab.Name;
			item.Parent.Prefabs.Remove(item.Prefab);
			item.Prefab = prefab;
			item.Parent.Prefabs.Add(prefab);
			item.Parent.RefreshThumbnail();
			Select(item);
		}
	}

	public byte[] GenerateThumbnail(BuildingPrefab prefab)
	{
		GameObject gameObject = MinimapThumbnailMaker.Instance.MinimapMaker.CreateMap(MinimapThumbnailMaker.Instance.MinimapMaker.MapDescFromRooms(prefab, false), true, false, false);
		Texture2D texture2D = MinimapThumbnailMaker.Instance.RenderObject(gameObject, MinimapThumbnailMaker.ThumbSize.Big);
		byte[] result = texture2D.EncodeToPNG();
		UnityEngine.Object.Destroy(texture2D);
		gameObject.GetComponentsInChildren<MeshFilter>().ForEachEnum(delegate(MeshFilter x)
		{
			UnityEngine.Object.Destroy(x.sharedMesh);
		});
		UnityEngine.Object.Destroy(gameObject);
		return result;
	}

	public bool GetRooms(IEnumerable<Selectable> selected, out BuildingPrefab prefab, out byte[] thumbData)
	{
		prefab = null;
		thumbData = null;
		Room[] rooms = selected.OfType<Room>().ToArray();
		if (rooms.Length != 0)
		{
			Roof[] roofs = selected.OfType<Roof>().ToArray();
			if (!BuildingPrefab.ValidCheck(rooms))
			{
				WindowManager.Instance.ShowMessageBox("UnsupportedStructure".Loc(), false, DialogWindow.DialogType.Error, new KeyValuePair<string, Action>("OK", delegate
				{
				}), new KeyValuePair<string, Action>("Select unsupported rooms", delegate
				{
					SelectorController.Instance.Highligt(false);
					SelectorController.Instance.Selected.Clear();
					SelectorController.Instance.Selected.AddRange(BuildingPrefab.GetInvalid(rooms).OfType<Selectable>());
					SelectorController.Instance.DoPostSelectChecks();
				}));
				return false;
			}
			prefab = BuildingPrefab.SaveRooms(rooms, roofs, true, false, true, false, false, false, true);
			if (prefab.Rooms.Length != 0 && prefab.Edges.Length != 0)
			{
				thumbData = GenerateThumbnail(prefab);
				return true;
			}
			return false;
		}
		return false;
	}

	public bool RenamePrefab(string newName, BlueprintGroup group, BuildingPrefab prefab)
	{
		try
		{
			if (!newName.Equals(prefab.Name))
			{
				string path = group.FolderPath();
				string text = Path.Combine(path, prefab.Name + ".xml");
				string text2 = Path.Combine(path, newName + ".xml");
				if (File.Exists(text) && !File.Exists(text2))
				{
					File.Move(text, text2);
					text = Path.Combine(path, prefab.Name + ".png");
					prefab.Name = newName;
					if (File.Exists(text))
					{
						text2 = Path.Combine(path, newName + ".png");
						File.Move(text, text2);
					}
					return true;
				}
			}
		}
		catch (Exception ex)
		{
			Debug.Log(ex.ToString());
		}
		return false;
	}

	public void DeleteBlueprint(BluePrintUIItem item)
	{
		WindowManager.Instance.ShowMessageBox("BlueprintDeleteConfirmation".LocColor(item.Group ? item.Parent.ItemTitle : item.Prefab.Name), false, DialogWindow.DialogType.Warning, delegate
		{
			if (item.Group)
			{
				Directory.Delete(item.Parent.FolderPath(), true);
				GameData.Blueprints.Remove(item.Parent);
				item.DestroyMe();
			}
			else
			{
				File.Delete(Path.Combine(item.Parent.FolderPath(), item.name + ".xml"));
				if (File.Exists(Path.Combine(item.Parent.FolderPath(), item.name + ".png")))
				{
					try
					{
						File.Delete(Path.Combine(item.Parent.FolderPath(), item.name + ".png"));
					}
					catch (Exception)
					{
					}
				}
				item.Parent.Prefabs.Remove(item.Prefab);
				if (item.Parent.CheckToRemove() && item.ParentItem != null)
				{
					item.ParentItem.DestroyMe();
				}
				else
				{
					item.Parent.RefreshThumbnail();
					item.DestroyMe();
				}
			}
		});
	}

	public void MoveToGroup(BluePrintUIItem item)
	{
		List<BlueprintGroup> validGroups = GameData.Blueprints.Where((BlueprintGroup x) => !x.IsSingleton() && item.Parent != x).ToList();
		if (validGroups.Count <= 0)
		{
			return;
		}
		WindowManager.Instance.MultiWindow.Show("Move", validGroups.Select((BlueprintGroup x) => x.ItemTitle), delegate(int i)
		{
			BlueprintGroup newGroup = validGroups[i];
			string newName = (item.Parent.IsSingleton() ? item.Parent.ItemTitle : item.Prefab.Name);
			if (newGroup.Prefabs.Any((BuildingPrefab x) => x.Name.Equals(newName)))
			{
				newName = FindNewName(newGroup);
			}
			try
			{
				File.Move(Path.Combine(item.Parent.FolderPath(), item.Prefab.Name + ".xml"), Path.Combine(newGroup.FolderPath(), newName + ".xml"));
				if (File.Exists(Path.Combine(item.Parent.FolderPath(), item.Prefab.Name + ".png")))
				{
					try
					{
						File.Move(Path.Combine(item.Parent.FolderPath(), item.Prefab.Name + ".png"), Path.Combine(newGroup.FolderPath(), newName + ".png"));
					}
					catch (Exception)
					{
					}
				}
				item.Prefab.Name = newName;
				item.Parent.Prefabs.Remove(item.Prefab);
				if (item.Parent.CheckToRemove() && item.ParentItem != null)
				{
					item.ParentItem.DestroyMe();
				}
				else
				{
					item.DestroyMe();
				}
				newGroup.Prefabs.Add(item.Prefab);
				newGroup.RefreshThumbnail();
				CreateItem(newGroup, item.Prefab, Items.FirstOrDefault((BluePrintUIItem x) => x.Group && x.Parent == newGroup));
				RefreshOrder();
			}
			catch (Exception ex2)
			{
				WindowManager.SpawnDialog("BlueprintSaveError".Loc(ex2.Message), true, DialogWindow.DialogType.Error);
			}
		}, false);
	}

	public string FindNewName(BlueprintGroup group)
	{
		int num = 1;
		string res;
		string text = (res = "Prefab");
		while (group.Prefabs.Any((BuildingPrefab x) => x.Name.Equals(res)))
		{
			res = text + " " + num;
			num++;
		}
		return res;
	}

	public void CreateGroup(BluePrintUIItem singleItem)
	{
		WindowManager.SpawnInputDialog("BlueprintGroupPrompt".Loc(), "BlueprintGroupPromptTitle".Loc(), "BlueprintGroupPromptDefault".Loc(), delegate(string name)
		{
			string value = Utilities.CleanFileName(name);
			try
			{
				BlueprintGroup parent = singleItem.Parent;
				if (singleItem.Prefab.Name.Equals(value))
				{
					if (!RenamePrefab("Prefab", parent, singleItem.Prefab))
					{
						return;
					}
				}
				else if (singleItem.Prefab.Name.Equals("Building") && !RenamePrefab(singleItem.Parent.ItemTitle, parent, singleItem.Prefab))
				{
					return;
				}
				parent.SetName(value, false);
				parent.MetaData.SaveChanges();
				singleItem.DestroyMe();
				CreateItems(parent);
				RefreshOrder();
			}
			catch (Exception ex)
			{
				WindowManager.SpawnDialog("BlueprintSaveError".Loc(ex.Message), true, DialogWindow.DialogType.Error);
			}
		});
	}

	public void SaveToGroup(BluePrintUIItem group)
	{
		BuildingPrefab prefab;
		byte[] thumbData;
		if (!GetRooms(SelectorController.Instance.Selected, out prefab, out thumbData))
		{
			return;
		}
		WindowManager.SpawnInputDialog("BlueprintPrompt".Loc(), "BlueprintPromptTitle".Loc(), "BlueprintPromptDefault".Loc(), delegate(string name)
		{
			try
			{
				string rName = Utilities.CleanFileName(name);
				if (group.Parent.Prefabs.Any((BuildingPrefab x) => x.Name.Equals(rName)))
				{
					WindowManager.SpawnDialog("BlueprintPromptError".Loc(), true, DialogWindow.DialogType.Error);
				}
				else
				{
					string path = group.Parent.FolderPath();
					File.WriteAllText(Path.Combine(path, rName + ".xml"), XMLParser.ExportXML(prefab.ToXmlNode()));
					File.WriteAllBytes(Path.Combine(path, rName + ".png"), thumbData);
					prefab.Name = rName;
					group.Parent.Prefabs.Add(prefab);
					group.Parent.RefreshThumbnail();
					BluePrintUIItem item = CreateItem(group.Parent, prefab, group);
					group.Children.Add(item);
					RefreshOrder();
				}
			}
			catch (Exception ex)
			{
				WindowManager.SpawnDialog("BlueprintSaveError".Loc(ex.Message), true, DialogWindow.DialogType.Error);
			}
		});
	}

	public void SaveSelected()
	{
		BuildingPrefab prefab;
		byte[] thumbData;
		if (!GetRooms(SelectorController.Instance.Selected, out prefab, out thumbData))
		{
			return;
		}
		WindowManager.SpawnInputDialog("BlueprintPrompt".Loc(), "BlueprintPromptTitle".Loc(), "BlueprintPromptDefault".Loc(), delegate(string name)
		{
			string text = Utilities.CleanFileName(name);
			string text2 = Path.Combine(Path.Combine(Utilities.GetRoot(), "Blueprints"), text);
			string rootInv = SteamWorkshop.NormalizePath(text2);
			if (GameData.Blueprints.Any((BlueprintGroup x) => x.SameRoot(rootInv, true)))
			{
				WindowManager.SpawnDialog("BlueprintPromptError".Loc(), true, DialogWindow.DialogType.Error);
				return;
			}
			try
			{
				Directory.CreateDirectory(text2);
				File.WriteAllText(Path.Combine(text2, text + ".xml"), XMLParser.ExportXML(prefab.ToXmlNode()));
				File.WriteAllBytes(Path.Combine(text2, "Thumbnail.png"), thumbData);
				File.WriteAllBytes(Path.Combine(text2, text + ".png"), thumbData);
				prefab.Name = text;
				BlueprintGroup blueprintGroup = new BlueprintGroup(text2, new List<BuildingPrefab> { prefab }, 0f);
				GameData.Blueprints.Add(blueprintGroup);
				CreateItems(blueprintGroup);
				RefreshOrder();
			}
			catch (Exception ex)
			{
				WindowManager.SpawnDialog("BlueprintSaveError".Loc(ex.Message), true, DialogWindow.DialogType.Error);
			}
		});
	}

	private void Update()
	{
		if (HUD.Instance == null || !HUD.Instance.BuildMode)
		{
			Window.Close();
		}
	}

	public void SearchEnd()
	{
		if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Return))
		{
			Build();
		}
	}

	public void Show()
	{
		if (BuildController.Instance.ActivePrefab != null)
		{
			WindowManager.Instance.ShowMessageBox("ForcedPrefabError".Loc(), true, DialogWindow.DialogType.Error);
			return;
		}
		Window.Show();
		SearchBar.text = "";
		SearchBar.Select();
		UpdateReplacement();
	}
}
