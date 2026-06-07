using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TexturePickerWindow : MonoBehaviour
{
	public static string[] Tabs = new string[6] { "Exterior", "Interior", "Floor", "Fence", "Roof", "Path" };

	public GUIWindow Window;

	public ToggleGroup Panel;

	public GameObject TogglePrefab;

	public GameObject OffsetPanel;

	public GameObject CustomButton;

	public Texture DefaultFenceExtra;

	public Toggle[] TabToggles;

	public Material None;

	public Material RGBAtlas;

	public Dictionary<Toggle, string> Choices = new Dictionary<Toggle, string>();

	public Transform ColorPresetPanel;

	public List<GameObject> ColorButtons = new List<GameObject>();

	private List<Room> Rooms = new List<Room>();

	private List<Roof> Roofs = new List<Roof>();

	private List<WallSnap> Furniture = new List<WallSnap>();

	private List<PathObject> Paths = new List<PathObject>();

	private string[,] DefaultTex;

	private string[] Chosen = new string[4] { "", "", "", "" };

	[NonSerialized]
	private Color[] _colors = new Color[7];

	public bool OutDoors;

	public bool Roof;

	public bool Path;

	public bool Furns;

	public bool Balcony;

	public bool Atlas;

	private UndoObject.UndoAction Undo;

	private List<UndoObject.UndoAction> TempUndo = new List<UndoObject.UndoAction>();

	public Slider RotationSlider;

	public Slider OffsetXSlider;

	public Slider OffsetYSlider;

	public Slider ScaleSlider;

	private bool _disableOffsetUpdate;

	[NonSerialized]
	private int _lastChoice;

	private List<RawImage> _cleanUp = new List<RawImage>();

	private void Start()
	{
		GameData.OnNewImages += GameData_OnNewImages;
	}

	private void OnDestroy()
	{
		GameData.OnNewImages -= GameData_OnNewImages;
	}

	private void GameData_OnNewImages(object sender, EventArgs e)
	{
		if (Window.Shown && _lastChoice == 9)
		{
			InitButtons(9);
		}
	}

	public void OnOffsetChange()
	{
		if (!_disableOffsetUpdate)
		{
			for (int i = 0; i < Rooms.Count; i++)
			{
				Room room = Rooms[i];
				room.FloorOffset = new SVector3(OffsetXSlider.value, OffsetYSlider.value, 0f);
				room.DirtyFloorMesh = true;
			}
		}
	}

	public void OnScaleChange()
	{
		if (!_disableOffsetUpdate)
		{
			if (Mathf.Abs(1f - ScaleSlider.value) < 0.1f)
			{
				_disableOffsetUpdate = true;
				ScaleSlider.value = 1f;
				_disableOffsetUpdate = false;
			}
			for (int i = 0; i < Rooms.Count; i++)
			{
				Room room = Rooms[i];
				room.FloorScale = ScaleSlider.value;
				room.DirtyFloorMesh = true;
			}
		}
	}

	public void OnRotationChange()
	{
		if (!_disableOffsetUpdate)
		{
			float num = Mathf.Round(RotationSlider.value / 90f) * 90f;
			if (Mathf.Abs(num - RotationSlider.value) < 5f)
			{
				_disableOffsetUpdate = true;
				RotationSlider.value = num;
				_disableOffsetUpdate = false;
			}
			for (int i = 0; i < Rooms.Count; i++)
			{
				Room room = Rooms[i];
				room.FloorRotation = RotationSlider.value;
				room.DirtyFloorMesh = true;
			}
		}
	}

	public void AlignWithGrid()
	{
		Vector3 position;
		Quaternion rotation;
		Vector3 scale;
		BuildController.Instance.GridMatrix.ExtractTRS(out position, out rotation, out scale);
		_disableOffsetUpdate = true;
		RotationSlider.value = rotation.eulerAngles.y;
		float num = 1f - (ScaleSlider.value - 1f);
		OffsetXSlider.value = Mathf.Abs(position.x * num % 1f);
		if (position.x < 0f)
		{
			OffsetXSlider.value = 1f - OffsetXSlider.value;
		}
		OffsetYSlider.value = Mathf.Abs(position.z * num % 1f);
		if (position.z < 0f)
		{
			OffsetYSlider.value = 1f - OffsetYSlider.value;
		}
		_disableOffsetUpdate = false;
		for (int i = 0; i < Rooms.Count; i++)
		{
			Room room = Rooms[i];
			room.FloorRotation = RotationSlider.value;
			room.FloorOffset = new SVector3(OffsetXSlider.value, OffsetYSlider.value, 0f);
			room.DirtyFloorMesh = true;
		}
	}

	public void InitTabs(bool room, bool imageFrame, string[] replacements = null)
	{
		bool flag = room && !OutDoors;
		TabToggles[0].gameObject.SetActive(flag || Roof);
		TabToggles[1].gameObject.SetActive(flag);
		TabToggles[2].gameObject.SetActive(room);
		TabToggles[3].gameObject.SetActive(OutDoors || Balcony);
		TabToggles[4].gameObject.SetActive(Roof);
		TabToggles[5].gameObject.SetActive(Path);
		TabToggles[6].gameObject.SetActive(Atlas && replacements != null && replacements.Length != 0);
		if (replacements != null && replacements.Length != 0)
		{
			TabToggles[7].gameObject.SetActive(true);
			TabToggles[7].GetComponentInChildren<Text>().text = replacements[0].Loc();
		}
		else
		{
			TabToggles[7].gameObject.SetActive(false);
		}
		if (replacements != null && replacements.Length > 1)
		{
			TabToggles[8].gameObject.SetActive(true);
			TabToggles[8].GetComponentInChildren<Text>().text = replacements[1].Loc();
		}
		else
		{
			TabToggles[8].gameObject.SetActive(false);
		}
		TabToggles[9].gameObject.SetActive(imageFrame);
		CustomButton.SetActive(imageFrame);
		int num = 0;
		if (room)
		{
			if (OutDoors)
			{
				num = 2;
			}
		}
		else if (Roof)
		{
			num = 4;
		}
		else if (Path)
		{
			num = 5;
		}
		else if (Furns)
		{
			num = (imageFrame ? 9 : ((!Atlas) ? 7 : 6));
		}
		for (int i = 0; i < TabToggles.Length; i++)
		{
			TabToggles[i].isOn = false;
		}
		TabToggles[num].isOn = true;
	}

	public void UpdateColorPreset(RoomMaterialController.WallMaterial material, Toggle parent = null, Action<Color, Color?> setColor = null)
	{
		if (material == null || material.ColorPresets.Count == 0)
		{
			for (int i = 0; i < ColorButtons.Count; i++)
			{
				ColorButtons[i].transform.SetParent(ColorPresetPanel, false);
			}
			ColorPresetPanel.gameObject.SetActive(false);
			return;
		}
		Transform parent2 = Utilities.FindTransformPath("ColorPanel", parent.transform);
		for (int j = 0; j < ColorButtons.Count; j++)
		{
			ColorButtons[j].GetComponent<Button>().onClick.RemoveAllListeners();
		}
		int k = 0;
		for (int num = Mathf.Min(material.ColorPresets.Count, ColorButtons.Count); k < num; k++)
		{
			GameObject obj = ColorButtons[k];
			obj.SetActive(true);
			Image[] componentsInChildren = obj.GetComponentsInChildren<Image>();
			RoomMaterialController.WallMaterial.ColorPreset preset = material.ColorPresets[k];
			componentsInChildren[1].color = preset.Color1;
			componentsInChildren[2].color = (material.SecondaryColorEnabled ? preset.Color2 : preset.Color1);
			Color? c2 = (material.SecondaryColorEnabled ? new Color?(preset.Color2) : ((Color?)null));
			obj.GetComponent<Button>().onClick.AddListener(delegate
			{
				ColorPresetClick(preset.Color1, c2, setColor);
			});
			obj.transform.SetParent(parent2, false);
		}
		for (; k < ColorButtons.Count; k++)
		{
			ColorButtons[k].SetActive(false);
		}
	}

	public void ColorPresetClick(Color c1, Color? c2, Action<Color, Color?> setColor = null)
	{
		_colors[_lastChoice * 2] = c1;
		_colors[_lastChoice * 2 + 1] = c2 ?? Color.black;
		if (setColor != null)
		{
			setColor(c1, c2);
		}
		foreach (KeyValuePair<Toggle, string> choice in Choices)
		{
			RoomMaterialController.WallMaterial wallMaterial = RoomMaterialController.Instance.AllMaterials[choice.Value];
			RawImage componentInChildren = choice.Key.GetComponentInChildren<RawImage>();
			componentInChildren.material.SetColor("_Color", wallMaterial.Name.Equals("None") ? TimeOfDay.Instance.GetGroundColor() : _colors[_lastChoice * 2]);
			componentInChildren.material.SetColor("_Color2", (!wallMaterial.SecondaryColorEnabled) ? wallMaterial.ForcedSecondaryColor : (wallMaterial.Name.Equals("None") ? TimeOfDay.Instance.GetGroundColor() : _colors[_lastChoice * 2 + 1]));
		}
	}

	public void Show(List<WallSnap> furns)
	{
		Undo = new UndoObject.UndoAction(furns.ToArray(), true);
		OutDoors = false;
		Roof = false;
		Path = false;
		Furniture = furns;
		Furns = true;
		Balcony = false;
		Atlas = Furniture[0].AtlasObject != null;
		foreach (KeyValuePair<Toggle, string> choice in Choices)
		{
			UnityEngine.Object.Destroy(choice.Key.gameObject);
		}
		UserImageFrame userImageFrame = furns.FirstNotNull((WallSnap x) => x.GetComponent<UserImageFrame>());
		InitTabs(false, userImageFrame != null, Furniture[0].ReplacementGroups);
		Chosen[0] = Furniture[0].AtlasIndex.ToString();
		Chosen[1] = Furniture[0].GetReplacement(0);
		Chosen[2] = Furniture[0].GetReplacement(1);
		Chosen[3] = (((object)userImageFrame != null) ? userImageFrame.ImageName : null);
		InitButtons(6);
		DefaultTex = new string[3, Furniture.Count];
		for (int num = 0; num < Furniture.Count; num++)
		{
			UserImageFrame component;
			if (Furniture[num].TryGetComponent<UserImageFrame>(out component))
			{
				DefaultTex[0, num] = component.ImageName;
			}
			else
			{
				DefaultTex[0, num] = Furniture[num].AtlasIndex.ToString();
			}
			DefaultTex[1, num] = Furniture[num].GetReplacement(0);
			DefaultTex[2, num] = Furniture[num].GetReplacement(1);
		}
		Furniture.ForEach(delegate(WallSnap x)
		{
			x.Stylize(true);
		});
		Window.OnClose = delegate
		{
			for (int i = 0; i < Furniture.Count; i++)
			{
				UserImageFrame component2;
				if (Furniture[i].TryGetComponent<UserImageFrame>(out component2))
				{
					component2.SetImage(DefaultTex[0, i]);
					DefaultTex[0, i] = component2.ImageName;
				}
				else
				{
					Furniture[i].AtlasIndex = DefaultTex[0, i].ConvertToIntDef(0);
				}
				Furniture[i].SetReplacement(0, DefaultTex[1, i]);
				Furniture[i].SetReplacement(1, DefaultTex[2, i]);
			}
			Furniture.ForEach(delegate(WallSnap x)
			{
				x.Stylize(false);
			});
		};
		Window.Show();
	}

	public void Show(List<PathObject> paths)
	{
		Undo = new UndoObject.UndoAction(true, paths.ToArray());
		OutDoors = false;
		Roof = false;
		Furns = false;
		Paths = paths;
		Path = true;
		Balcony = false;
		Atlas = false;
		foreach (KeyValuePair<Toggle, string> choice in Choices)
		{
			UnityEngine.Object.Destroy(choice.Key.gameObject);
		}
		InitTabs(false, false);
		Chosen[0] = Paths[0].Material;
		_colors[0] = Paths[0].MatColor;
		_colors[1] = Paths[0].MatColor2;
		InitButtons(5);
		DefaultTex = new string[1, Paths.Count];
		for (int i = 0; i < Paths.Count; i++)
		{
			DefaultTex[0, i] = Paths[i].Material;
		}
		Window.OnClose = delegate
		{
			new UndoObject(Undo).Execute();
		};
		Window.Show();
	}

	public void Show(List<Roof> roofs)
	{
		Undo = new UndoObject.UndoAction(roofs);
		OutDoors = false;
		Roof = true;
		Path = false;
		Furns = false;
		Balcony = false;
		Roofs = roofs;
		Atlas = false;
		foreach (KeyValuePair<Toggle, string> choice in Choices)
		{
			UnityEngine.Object.Destroy(choice.Key.gameObject);
		}
		InitTabs(false, false);
		Chosen[0] = Roofs[0].RoofMaterial;
		Chosen[1] = Roofs[0].GableMaterial;
		_colors[0] = Roofs[0].RoofColor;
		_colors[1] = Roofs[0].RoofColor2;
		_colors[2] = Roofs[0].GableColor;
		_colors[3] = Roofs[0].GableColor2;
		InitButtons(4);
		DefaultTex = new string[2, Roofs.Count];
		for (int i = 0; i < 2; i++)
		{
			for (int j = 0; j < Roofs.Count; j++)
			{
				switch (i)
				{
				case 0:
					DefaultTex[i, j] = Roofs[j].RoofMaterial;
					break;
				case 1:
					DefaultTex[i, j] = Roofs[j].GableMaterial;
					break;
				}
			}
		}
		Window.OnClose = delegate
		{
			new UndoObject(Undo).Execute();
		};
		Window.Show();
	}

	public void Show(List<Room> rooms)
	{
		TempUndo.Clear();
		Undo = new UndoObject.UndoAction(rooms, true, true, true);
		OutDoors = !rooms.Any((Room x) => !x.Outdoors);
		Roof = false;
		Path = false;
		Furns = false;
		Atlas = false;
		rooms.RemoveAll((Room x) => x.Outdoors ^ OutDoors);
		foreach (KeyValuePair<Toggle, string> choice in Choices)
		{
			UnityEngine.Object.Destroy(choice.Key.gameObject);
		}
		Balcony = rooms.Any((Room x) => x.IsBalcony);
		Chosen[0] = rooms[0].OutsideMat;
		Chosen[1] = rooms[0].InsideMat;
		Chosen[2] = rooms[0].FloorMat;
		Chosen[3] = rooms[0].FenceStyle;
		InitTabs(true, false);
		Rooms = rooms;
		_colors[0] = Rooms[0].OutsideColor;
		_colors[1] = Rooms[0].OutsideColor2;
		_colors[2] = Rooms[0].InsideColor;
		_colors[3] = Rooms[0].InsideColor2;
		_colors[4] = Rooms[0].FloorColor;
		_colors[5] = Rooms[0].FloorColor2;
		_colors[6] = Rooms[0].FenceColor;
		InitButtons(OutDoors ? 2 : 0);
		_disableOffsetUpdate = true;
		RotationSlider.value = Rooms[0].FloorRotation;
		OffsetXSlider.value = Rooms[0].FloorOffset.x;
		OffsetYSlider.value = Rooms[0].FloorOffset.y;
		ScaleSlider.value = Rooms[0].FloorScale;
		_disableOffsetUpdate = false;
		DefaultTex = new string[4, Rooms.Count];
		for (int num = 0; num < 4; num++)
		{
			for (int num2 = 0; num2 < Rooms.Count; num2++)
			{
				switch (num)
				{
				case 0:
					DefaultTex[num, num2] = Rooms[num2].OutsideMat;
					break;
				case 1:
					DefaultTex[num, num2] = Rooms[num2].InsideMat;
					break;
				case 2:
					DefaultTex[num, num2] = Rooms[num2].FloorMat;
					break;
				case 3:
					DefaultTex[num, num2] = Rooms[num2].FenceStyle;
					break;
				}
			}
		}
		Window.OnClose = delegate
		{
			new UndoObject(TempUndo.ToArray()).Execute();
			TempUndo.Clear();
			new UndoObject(Undo).Execute();
			Selectable.DisableDiagonalHighlights = false;
			SelectorController.Instance.Highligt(true);
		};
		Window.Show();
	}

	public void InitButtons(int choice)
	{
		OffsetPanel.SetActive(false);
		UpdateColorPreset(null);
		if (!TabToggles[choice].isOn)
		{
			return;
		}
		_cleanUp.ForEach(delegate(RawImage rawImage)
		{
			UnityEngine.Object.Destroy(rawImage.material);
		});
		_cleanUp.Clear();
		foreach (KeyValuePair<Toggle, string> choice2 in Choices)
		{
			UnityEngine.Object.Destroy(choice2.Key.gameObject);
		}
		Choices.Clear();
		if (choice != 3 && choice < 6)
		{
			Action<Color, Color?> setColor = null;
			int acChoice = choice;
			if (Roof)
			{
				switch (acChoice)
				{
				case 0:
					setColor = delegate(Color color1, Color? color2)
					{
						Roofs.ForEach(delegate(Roof roof)
						{
							roof.GableColor = color1;
							if (color2.HasValue)
							{
								roof.GableColor2 = color2.Value;
							}
						});
					};
					acChoice = 1;
					break;
				case 4:
					setColor = delegate(Color color1, Color? color2)
					{
						Roofs.ForEach(delegate(Roof roof)
						{
							roof.RoofColor = color1;
							if (color2.HasValue)
							{
								roof.RoofColor2 = color2.Value;
							}
						});
					};
					acChoice = 0;
					break;
				}
			}
			else if (Path)
			{
				setColor = delegate(Color color1, Color? color2)
				{
					Paths.ForEach(delegate(PathObject pathObject)
					{
						pathObject.MatColor = color1;
						if (color2.HasValue)
						{
							pathObject.MatColor2 = color2.Value;
						}
					});
				};
				acChoice = 0;
			}
			else
			{
				switch (choice)
				{
				case 0:
					setColor = delegate(Color color1, Color? color2)
					{
						Rooms.ForEach(delegate(Room room)
						{
							room.OutsideColor = color1;
							if (color2.HasValue)
							{
								room.OutsideColor2 = color2.Value;
							}
						});
					};
					break;
				case 1:
					setColor = delegate(Color color1, Color? color2)
					{
						Rooms.ForEach(delegate(Room room)
						{
							room.InsideColor = color1;
							if (color2.HasValue)
							{
								room.InsideColor2 = color2.Value;
							}
						});
					};
					break;
				case 2:
					OffsetPanel.SetActive(true);
					setColor = delegate(Color color1, Color? color2)
					{
						Rooms.ForEach(delegate(Room room)
						{
							room.FloorColor = color1;
							if (color2.HasValue)
							{
								room.FloorColor2 = color2.Value;
							}
						});
					};
					break;
				}
			}
			_lastChoice = acChoice;
			{
				foreach (RoomMaterialController.WallMaterial item in RoomMaterialController.Instance.AllMaterials.Values.Where((RoomMaterialController.WallMaterial wallMaterial) => (wallMaterial.Category.Equals(Tabs[choice]) || (OutDoors && choice == 2 && wallMaterial.Category.Equals("Path"))) && (OutDoors || !wallMaterial.Name.Equals("None")) && !wallMaterial.Name.Equals("CannotRent")).ToList())
				{
					GameObject gameObject = UnityEngine.Object.Instantiate(TogglePrefab);
					RawImage componentInChildren = gameObject.GetComponentInChildren<RawImage>();
					Material material = new Material(componentInChildren.material);
					material.SetColor("_Color", item.Name.Equals("None") ? TimeOfDay.Instance.GetGroundColor() : _colors[acChoice * 2]);
					material.SetColor("_Color2", (!item.SecondaryColorEnabled) ? item.ForcedSecondaryColor : (item.Name.Equals("None") ? TimeOfDay.Instance.GetGroundColor() : _colors[acChoice * 2 + 1]));
					material.SetTexture("_MainTex", (item.Base != null) ? item.Base : RoomMaterialController.Instance.DefaultBase);
					material.SetTexture("_BumpTex", (item.Bump != null) ? item.Bump : RoomMaterialController.Instance.DefaultBump);
					material.SetTexture("_ExtraTex", (item.Extra != null) ? item.Extra : RoomMaterialController.Instance.DefaultExtra);
					componentInChildren.material = material;
					_cleanUp.Add(componentInChildren);
					gameObject.GetComponentsInChildren<Image>(true).First((Image image) => image.name.Equals("SteamIcon")).gameObject.SetActive(item.FromSteam);
					gameObject.transform.SetParent(Panel.transform, false);
					Toggle gToggle = gameObject.GetComponent<Toggle>();
					gToggle.group = Panel;
					string mName = item.Name;
					gToggle.isOn = mName == Chosen[acChoice];
					if (gToggle.isOn)
					{
						UpdateColorPreset(item, gToggle, setColor);
					}
					RoomMaterialController.WallMaterial mat2 = item;
					gToggle.onValueChanged.AddListener(delegate(bool flag)
					{
						if (flag)
						{
							UpdateColorPreset(mat2, gToggle, setColor);
							switch (acChoice)
							{
							case 0:
								if (Roof)
								{
									Roofs.ForEachNotNull(delegate(Roof z)
									{
										z.RoofMaterial = mName;
									});
								}
								else if (Path)
								{
									Paths.ForEachNotNull(delegate(PathObject z)
									{
										z.Material = mName;
									});
								}
								else
								{
									Rooms.ForEachNotNull(delegate(Room z)
									{
										z.OutsideMat = mName;
									});
								}
								break;
							case 1:
								if (Roof)
								{
									Roofs.ForEachNotNull(delegate(Roof z)
									{
										z.GableMaterial = mName;
									});
								}
								else
								{
									Rooms.ForEachNotNull(delegate(Room z)
									{
										z.InsideMat = mName;
									});
								}
								break;
							case 2:
								Rooms.ForEachNotNull(delegate(Room z)
								{
									z.FloorMat = mName;
								});
								break;
							}
							Chosen[acChoice] = mName;
						}
					});
					Choices.Add(gToggle, mName);
				}
				return;
			}
		}
		if (choice == 6)
		{
			_lastChoice = choice;
			WallSnap wallSnap;
			Texture texture;
			if (Furniture[0] is Furniture)
			{
				wallSnap = ObjectDatabase.Instance.GetFurnitureComponent(Furniture[0].name) ?? Furniture[0];
				Furniture furniture = wallSnap as Furniture;
				texture = ((wallSnap.AtlasObject == furniture.TheScreen) ? furniture.OnMat.mainTexture : wallSnap.AtlasObject.sharedMaterial.mainTexture);
			}
			else
			{
				wallSnap = ObjectDatabase.Instance.GetSegmentComponent(Furniture[0].name) ?? Furniture[0];
				texture = wallSnap.AtlasObject.sharedMaterial.mainTexture;
			}
			Vector2 atlasDimensions = wallSnap.AtlasDimensions;
			for (int num = 0; num < wallSnap.AtlasCount / wallSnap.AtlasSkip; num++)
			{
				int num2 = num * wallSnap.AtlasSkip + wallSnap.AtlasOff;
				float x = (float)num2 % atlasDimensions.x / atlasDimensions.x;
				float y = (atlasDimensions.y - 1f - Mathf.Floor((float)num2 / atlasDimensions.x)) / atlasDimensions.y;
				GameObject obj = UnityEngine.Object.Instantiate(TogglePrefab);
				RawImage componentInChildren2 = obj.GetComponentInChildren<RawImage>();
				componentInChildren2.texture = texture;
				componentInChildren2.uvRect = new Rect(x, y, 1f / atlasDimensions.x, 1f / atlasDimensions.y);
				if (wallSnap.AtlasColorable)
				{
					componentInChildren2.material = new Material(RGBAtlas);
					componentInChildren2.material.SetColor("_Color1", Furniture[0].ColorPrimary);
					componentInChildren2.material.SetColor("_Color2", Furniture[0].ColorSecondary);
					componentInChildren2.material.SetColor("_Color3", Furniture[0].ColorTertiary);
					_cleanUp.Add(componentInChildren2);
				}
				else
				{
					componentInChildren2.material = null;
				}
				obj.transform.SetParent(Panel.transform, false);
				Toggle component = obj.GetComponent<Toggle>();
				component.group = Panel;
				int j = num2;
				string fName = j.ToString();
				component.isOn = fName == Chosen[0];
				component.onValueChanged.AddListener(delegate
				{
					Furniture.ForEachNotNull(delegate(WallSnap z)
					{
						z.AtlasIndex = j;
					});
					Chosen[0] = fName;
				});
				Choices.Add(component, fName);
			}
			return;
		}
		if (choice == 7 || choice == 8)
		{
			_lastChoice = choice;
			string gr = Furniture[0].ReplacementGroups[choice - 7];
			ObjectDatabase.ReplacementGroup group;
			if (!ObjectDatabase.Instance.GetReplacementGroup(gr, out group))
			{
				return;
			}
			for (int num3 = 0; num3 < group.Replacements.Count; num3++)
			{
				ObjectDatabase.ReplacementObject rep = group.Replacements[num3];
				GameObject obj2 = UnityEngine.Object.Instantiate(TogglePrefab);
				RawImage componentInChildren3 = obj2.GetComponentInChildren<RawImage>();
				componentInChildren3.material = new Material(RGBAtlas);
				_cleanUp.Add(componentInChildren3);
				componentInChildren3.material.SetColor("_Color1", (rep.Thumbnail != null) ? Color.red : Furniture[0].ColorPrimary);
				componentInChildren3.material.SetColor("_Color2", (rep.Thumbnail != null) ? Color.green : Furniture[0].ColorSecondary);
				componentInChildren3.material.SetColor("_Color3", (rep.Thumbnail != null) ? Color.blue : Furniture[0].ColorTertiary);
				if (rep.Thumbnail != null)
				{
					componentInChildren3.texture = rep.Thumbnail.texture;
					componentInChildren3.uvRect = rep.Thumbnail.GetAtlasRect();
				}
				else
				{
					componentInChildren3.texture = rep.AlbedoThumb;
				}
				obj2.transform.SetParent(Panel.transform, false);
				Toggle component2 = obj2.GetComponent<Toggle>();
				component2.group = Panel;
				component2.isOn = rep.Name == Chosen[choice - 6];
				component2.onValueChanged.AddListener(delegate
				{
					Furniture.ForEachNotNull(delegate(WallSnap z)
					{
						z.SetReplacement(gr, rep.Name);
					});
					Chosen[choice - 6] = rep.Name;
				});
				Choices.Add(component2, rep.Name);
			}
			return;
		}
		if (choice == 9)
		{
			_lastChoice = choice;
			{
				foreach (KeyValuePair<string, Material> uImg in GameData.UserImages)
				{
					GameObject obj3 = UnityEngine.Object.Instantiate(TogglePrefab);
					RawImage componentInChildren4 = obj3.GetComponentInChildren<RawImage>();
					componentInChildren4.material = null;
					componentInChildren4.texture = uImg.Value.mainTexture;
					float num4 = (float)componentInChildren4.texture.width / (float)componentInChildren4.texture.height;
					if (num4 > 1f)
					{
						componentInChildren4.uvRect = new Rect(0f, (0f - (num4 - 1f)) / 2f, 1f, num4);
					}
					else
					{
						num4 = 1f / num4;
						componentInChildren4.uvRect = new Rect((0f - (num4 - 1f)) / 2f, 0f, num4, 1f);
					}
					obj3.transform.SetParent(Panel.transform, false);
					Toggle component3 = obj3.GetComponent<Toggle>();
					component3.group = Panel;
					component3.isOn = uImg.Key == Chosen[3];
					component3.onValueChanged.AddListener(delegate
					{
						foreach (WallSnap item2 in Furniture)
						{
							UserImageFrame component5;
							if (item2.TryGetComponent<UserImageFrame>(out component5))
							{
								component5.SetImage(uImg.Key);
							}
						}
						Chosen[3] = uImg.Key;
					});
					Choices.Add(component3, uImg.Key);
				}
				return;
			}
		}
		_lastChoice = choice;
		foreach (ObjectDatabase.FenceStyle fenceStyle in ObjectDatabase.Instance.FenceStyles)
		{
			GameObject obj4 = UnityEngine.Object.Instantiate(TogglePrefab);
			RawImage componentInChildren5 = obj4.GetComponentInChildren<RawImage>();
			Material material2 = new Material(componentInChildren5.material);
			material2.SetColor("_Color", _colors[choice * 2]);
			material2.SetColor("_Color2", Color.clear);
			material2.SetTexture("_MainTex", fenceStyle.Thumbnail);
			material2.SetTexture("_BumpTex", fenceStyle.ThumbnailBump);
			material2.SetTexture("_ExtraTex", (fenceStyle.ThumbnailExtra == null) ? DefaultFenceExtra : fenceStyle.ThumbnailExtra);
			componentInChildren5.material = material2;
			_cleanUp.Add(componentInChildren5);
			obj4.transform.SetParent(Panel.transform, false);
			Toggle component4 = obj4.GetComponent<Toggle>();
			component4.group = Panel;
			string fName2 = fenceStyle.Name;
			component4.isOn = fName2 == Chosen[choice];
			component4.onValueChanged.AddListener(delegate
			{
				new UndoObject(TempUndo.ToArray()).Execute();
				TempUndo.Clear();
				Rooms.ForEachNotNull(delegate(Room z)
				{
					z.SetFenceStyle(fName2, TempUndo);
				});
				Chosen[choice] = fName2;
			});
			Choices.Add(component4, fName2);
		}
	}

	public void OpenCustomFolder()
	{
		WindowManager.Instance.ShowMessageBox("PutYourImagesIn".Loc(GameData.UserImagePath), true, DialogWindow.DialogType.Information);
		try
		{
			Utilities.OpenFolder(GameData.UserImagePath);
		}
		catch (Exception ex)
		{
			Debug.Log(ex.ToString());
		}
	}

	public void Apply()
	{
		Window.OnClose = null;
		if (Roof)
		{
			Roofs.ForEachNotNull(delegate(Roof x)
			{
				x.RoofMaterial = Chosen[0];
				x.GableMaterial = Chosen[1];
				x.UpdateStyleNetwork();
			});
			MaterialPreviewer.RefreshSelectedStyle(MaterialPreviewer.Mode.Roof);
		}
		else if (OutDoors)
		{
			new UndoObject(TempUndo.ToArray()).Execute();
			TempUndo.Clear();
			Rooms.ForEachNotNull(delegate(Room x)
			{
				x.FloorMat = Chosen[2];
				x.SetFenceStyle(Chosen[3], TempUndo);
				x.UpdateStyleNetwork();
			});
			GameSettings.Instance.AddUndo(TempUndo.ToArray());
			MaterialPreviewer.RefreshSelectedStyle(MaterialPreviewer.Mode.Fence);
		}
		else if (Path)
		{
			Paths.ForEachNotNull(delegate(PathObject x)
			{
				x.Material = Chosen[0];
			});
			MaterialPreviewer.RefreshSelectedStyle(MaterialPreviewer.Mode.Path);
		}
		else if (Furns)
		{
			Furniture.ForEachNotNull(delegate(WallSnap x)
			{
				x.Stylize(false);
				x.UpdateStyleNetwork();
			});
		}
		else
		{
			Rooms.ForEachNotNull(delegate(Room x)
			{
				x.OutsideMat = Chosen[0];
				x.InsideMat = Chosen[1];
				x.FloorMat = Chosen[2];
				if (x.IsBalcony)
				{
					x.SetFenceStyle(Chosen[3], TempUndo);
				}
				x.UpdateStyleNetwork();
			});
			MaterialPreviewer.Mode mode = MaterialPreviewer.Mode.Room;
			if (Balcony)
			{
				mode |= MaterialPreviewer.Mode.Balcony;
			}
			MaterialPreviewer.RefreshSelectedStyle(mode);
		}
		if (Undo != null)
		{
			GameSettings.Instance.AddUndo(Undo);
		}
		Selectable.DisableDiagonalHighlights = false;
		SelectorController.Instance.Highligt(true);
		Window.Close();
	}

	public void RefreshUserImages()
	{
		GameData.UserImagesDirty = true;
	}
}
