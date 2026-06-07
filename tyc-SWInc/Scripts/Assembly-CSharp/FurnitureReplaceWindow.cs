using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FurnitureReplaceWindow : MonoBehaviour
{
	public GUIWindow Window;

	public BuilderDetailPanel DetailPanel;

	public GameObject BuildButtonPrototype;

	public RectTransform ButtonPanel;

	public ToggleGroup ButtonGroup;

	private readonly Dictionary<Toggle, Furniture> _upgradeTo = new Dictionary<Toggle, Furniture>();

	private readonly List<Furniture> _furns = new List<Furniture>();

	private Action<Furniture> OnClose;

	public void Show(Furniture replacer, Action<Furniture> onClose)
	{
		HashSet<string> replacables = ObjectDatabase.Instance.GetReplacables(replacer.name);
		if (replacables == null)
		{
			return;
		}
		_furns.Clear();
		foreach (KeyValuePair<Toggle, Furniture> item in _upgradeTo)
		{
			UnityEngine.Object.Destroy(item.Key.gameObject);
		}
		_upgradeTo.Clear();
		foreach (string item2 in replacables.Append(replacer.name))
		{
			Furniture furnitureComponent = ObjectDatabase.Instance.GetFurnitureComponent(item2);
			if (!furnitureComponent.IsUnlocked() || !furnitureComponent.Queryable() || !furnitureComponent.IsPurchasable())
			{
				continue;
			}
			GameObject obj = UnityEngine.Object.Instantiate(BuildButtonPrototype);
			obj.transform.SetParent(ButtonPanel, false);
			Toggle component = obj.GetComponent<Toggle>();
			_upgradeTo[component] = furnitureComponent;
			obj.GetComponentsInChildren<Image>()[2].sprite = furnitureComponent.Thumbnail;
			component.isOn = false;
			component.group = ButtonGroup;
			Furniture f1 = furnitureComponent;
			component.onValueChanged.AddListener(delegate(bool x)
			{
				if (x)
				{
					DetailPanel.SetFurniture(f1, null);
				}
			});
		}
		if (_upgradeTo.Count > 0)
		{
			_upgradeTo.First().Key.isOn = true;
			Window.Show();
		}
		OnClose = onClose;
	}

	public void Show(List<Furniture> furns)
	{
		OnClose = null;
		_furns.Clear();
		_furns.AddRange(furns);
		foreach (KeyValuePair<Toggle, Furniture> item in _upgradeTo)
		{
			UnityEngine.Object.Destroy(item.Key.gameObject);
		}
		_upgradeTo.Clear();
		foreach (Furniture item2 in from x in _furns.Select((Furniture x) => x.UpgradeTo).Distinct().SelectMany((string x) => ObjectDatabase.Instance.GetUpgrades(x, _furns))
				.Distinct()
			where x != null && x.IsPlayerControlled()
			orderby x.Cost
			select x)
		{
			if (!item2.IsUnlocked() || !item2.Queryable() || (!GameSettings.Instance.AllowModdedFurniture && item2.FileName != null))
			{
				continue;
			}
			GameObject obj = UnityEngine.Object.Instantiate(BuildButtonPrototype);
			obj.transform.SetParent(ButtonPanel, false);
			Toggle component = obj.GetComponent<Toggle>();
			_upgradeTo[component] = item2;
			obj.GetComponentsInChildren<Image>()[2].sprite = item2.Thumbnail;
			component.isOn = false;
			component.group = ButtonGroup;
			Furniture f1 = item2;
			component.onValueChanged.AddListener(delegate(bool x)
			{
				if (x)
				{
					DetailPanel.SetFurniture(f1, null);
				}
			});
		}
		if (_upgradeTo.Count > 0)
		{
			_upgradeTo.First().Key.isOn = true;
			Window.Show();
		}
	}

	public bool ValidSnap(Furniture target, Furniture upgrade)
	{
		if (upgrade.IsSnapping)
		{
			if (!target.IsSnapping)
			{
				return false;
			}
			string element = target.SnappedTo.Name;
			if (!upgrade.SnapsTo.Contains(element))
			{
				return false;
			}
		}
		return true;
	}

	public void Accept()
	{
		Furniture upgrade = _upgradeTo.First((KeyValuePair<Toggle, Furniture> x) => x.Key.isOn).Value;
		if (!upgrade.IsPurchasable())
		{
			WindowManager.Instance.ShowMessageBox("FurnitureUnlock".Loc(upgrade.UnlockYear), false, DialogWindow.DialogType.Error);
			return;
		}
		if (OnClose != null)
		{
			OnClose(upgrade);
			OnClose = null;
			Window.Close();
			return;
		}
		SelectorController.Instance.Highligt(false);
		SelectorController.Instance.Selected.Clear();
		bool flag = false;
		bool flag2 = false;
		List<UndoObject.UndoAction> list = new List<UndoObject.UndoAction>();
		int num = GameSettings.GetInventoryCount(upgrade.name);
		bool flag3 = _furns.All((Furniture x) => x.name.Equals(upgrade.name));
		for (int num2 = 0; num2 < _furns.Count; num2++)
		{
			Furniture furniture = _furns[num2];
			if (furniture == null || furniture.gameObject == null || furniture.WallFurn != upgrade.WallFurn || (!flag3 && furniture.name.Equals(upgrade.name)) || string.IsNullOrEmpty(furniture.UpgradeTo) || !upgrade.UpgradeCompatible(furniture.UpgradeTo) || !ValidSnap(furniture, upgrade))
			{
				continue;
			}
			float cost = upgrade.GetCost();
			if (num == 0 && !GameSettings.Instance.MyCompany.CanMakeTransaction(0f - cost))
			{
				WindowManager.Instance.ShowMessageBox("CannotAfford".Loc(), false, DialogWindow.DialogType.Error);
				break;
			}
			if (ValidPlacement(furniture, upgrade) && ValidUpgradeBoundary(furniture, upgrade))
			{
				if (num > 0)
				{
					num--;
				}
				bool inventory = true;
				Furniture furniture2 = UpgradeFurniture(furniture, upgrade, _furns, num2, ref inventory, list);
				furniture2.gameObject.SetActive(true);
				SelectorController.Instance.Selected.Add(furniture2);
				if (!inventory && cost > 0f)
				{
					GameSettings.Instance.MyCompany.MakeTransaction(0f - cost, Company.TransactionCategory.Construction, false, "Furniture");
					GameSettings.Instance.MyCompany.AddTax(TaxReport.TaxType.Depreciation, furniture.GetSellPrice() - cost);
					CostDisplay.Instance.Show(cost, furniture2.transform.position);
					CostDisplay.Instance.FloatAway();
				}
				flag = true;
			}
			else
			{
				flag2 = true;
			}
		}
		if (flag)
		{
			GameSettings.Instance.AddUndo(list.ToArray());
			UISoundFX.PlaySFX("PlaceFurniture", true);
			UISoundFX.PlaySFX("Kaching");
			SelectorController.Instance.DoPostSelectChecks();
			HUD.Instance.serverWindow.UpdateServerList();
			GameSettings.Instance.sRoomManager.RecalculateAllDirtyTableGroups();
		}
		if (flag2)
		{
			WindowManager.Instance.ShowMessageBox("FurnitureReplacementBlocked".Loc(), false, DialogWindow.DialogType.Information);
		}
		Window.Close();
	}

	private bool ValidPlacement(Furniture furn, Furniture upgrade)
	{
		if (((furn.Parent.Outdoors && upgrade.ValidOutdoors) || (!furn.Parent.Outdoors && upgrade.ValidIndoors)) && (!furn.OnlyOnGrass || "None".Equals(furn.Parent.FloorMat) || furn.Parent.Outside) && (upgrade.BasementValid || furn.Parent.Floor >= 0))
		{
			if (upgrade.WallFurn && upgrade.OnlyExteriorWalls)
			{
				return !furn.SecondEdge.Links.ContainsValue(furn.FirstEdge);
			}
			return true;
		}
		return false;
	}

	private bool DoubleWallFurnCheck(Vector2 pos, Furniture upg, WallEdge e1, WallEdge e2)
	{
		float num = (e1.Pos - pos).magnitude - upg.WallWidth / 2f;
		if (num >= Room.WallOffset / 2f)
		{
			float magnitude = (e1.Pos - e2.Pos).magnitude;
			if (num + upg.WallWidth <= magnitude - Room.WallOffset / 2f)
			{
				return true;
			}
		}
		return false;
	}

	private static float GetOffset(Furniture furn, Furniture upg)
	{
		float floorOffset = furn.transform.position.y.GetFloorOffset(furn.Floor);
		if (furn.WallFurn)
		{
			if (upg.CustomHeight)
			{
				return Mathf.Clamp(floorOffset, upg.GetValidHeight(0), upg.GetValidHeight(1));
			}
			return 0f;
		}
		return floorOffset;
	}

	private bool ValidUpgradeBoundary(Furniture furn, Furniture upg)
	{
		Vector3 vector = furn.OriginalPosition;
		if (furn.WallFurn)
		{
			if (furn.IsReversed && !upg.ValidOutside)
			{
				return false;
			}
			Vector2 pos = furn.OriginalPosition.FlattenVector3();
			WallEdge firstEdge = furn.FirstEdge;
			WallEdge secondEdge = furn.SecondEdge;
			float height = GetOffset(furn, upg);
			if (!firstEdge.ValidSegment(ref pos, ref height, upg.WallWidth, secondEdge, !upg.PokesThroughWall, upg.IsConnecter, furn.IsReversed ^ upg.ReverseWallSide, true, upg.ValidOnFence, upg.Height1, upg.Height2, false, 0f, 0f, false, furn))
			{
				return false;
			}
			if (!DoubleWallFurnCheck(pos, upg, firstEdge, secondEdge))
			{
				return false;
			}
			vector = pos.ToVector3(vector.y);
		}
		if (upg.BuildBoundary == null || upg.BuildBoundary.Length == 0)
		{
			return true;
		}
		List<Furniture> list = new List<Furniture> { furn };
		float num = 0f;
		if (upg.IsSnapping)
		{
			num = furn.OriginalPosition.y.GetFloorOffset(furn.Parent.Floor);
		}
		if (furn.IsSnapping)
		{
			if (furn.CanSnapSurface && furn.SnappedTo.HasSurface && (!furn.SnappedTo.CheckCollisions(vector, upg.SurfaceSnapRadius, furn, null) || !furn.SnappedTo.IsWithinSurface(vector, upg.SurfaceSnapRadius)))
			{
				return false;
			}
			list.Add(furn.SnappedTo.Parent);
		}
		foreach (SnapPoint item in furn.SnapPoints.Where((SnapPoint x) => x.UsedByCount > 0))
		{
			list.AddRange(item.GetAllUsedBy());
		}
		Matrix4x4 mat = Matrix4x4.TRS(vector, furn.transform.rotation, Vector3.one);
		return FurnitureBuilder.IsValid(upg, vector, upg.BuildBoundary.Select((Vector2 x) => mat.MultiplyPoint(new Vector3(x.x, 0f, x.y)).FlattenVector3()).ToArray(), upg.Height1 + num, upg.Height2 + num, furn.Parent, false, list.ToArray());
	}

	private static bool ValidSnapBoundary(Furniture furn, Furniture snappingTo, Furniture[] otherSnaps, Vector3 newPos, Quaternion newRot)
	{
		if (furn.BuildBoundary == null || furn.BuildBoundary.Length == 0)
		{
			return true;
		}
		List<Furniture> list = new List<Furniture>(1 + furn.SnapPoints.Length + otherSnaps.Length);
		list.Add(snappingTo);
		foreach (SnapPoint item in furn.SnapPoints.Where((SnapPoint x) => x.UsedByCount > 0))
		{
			list.AddRange(item.GetAllUsedBy());
		}
		for (int num = 0; num < otherSnaps.Length; num++)
		{
			list.Add(otherSnaps[num]);
		}
		Matrix4x4 mat = Matrix4x4.TRS(newPos, newRot, Vector3.one);
		return FurnitureBuilder.IsValid(furn, newPos, furn.BuildBoundary.Select((Vector2 x) => mat.MultiplyPoint(new Vector3(x.x, 0f, x.y)).FlattenVector3()).ToArray(), furn.OffsetHeight(0), furn.OffsetHeight(1), furn.Parent, false, list.ToArray());
	}

	private static bool DeleteParent(Furniture furn, Furniture upg)
	{
		if (furn.IsSnapping && !upg.IsSnapping)
		{
			return furn.SnappedTo.Parent.SnapPoints.Any((SnapPoint x) => x.IsUsedBy(furn));
		}
		return false;
	}

	public static Furniture UpgradeFurniture(Furniture furn, Furniture upgrade)
	{
		bool inventory = false;
		return UpgradeFurniture(furn, upgrade, new List<Furniture> { furn }, 0, ref inventory, null);
	}

	private static Furniture UpgradeFurniture(Furniture furn, Furniture upgrade, List<Furniture> upgrades, int idx, ref bool inventory, List<UndoObject.UndoAction> undos)
	{
		Vector3 vector = furn.OriginalPosition;
		if (furn.WallFurn)
		{
			float height = GetOffset(furn, upgrade);
			Vector2 pos = vector.FlattenVector3();
			furn.FirstEdge.ValidSegment(ref pos, ref height, upgrade.WallWidth, furn.SecondEdge, !upgrade.PokesThroughWall, upgrade.IsConnecter, furn.IsReversed ^ upgrade.ReverseWallSide, true, upgrade.ValidOnFence, upgrade.Height1, upgrade.Height2, false, 0f, 0f, false, furn);
			vector = pos.ToVector3((float)(furn.Floor * 2) + height);
		}
		WallEdge wallEdge = (furn.WallFurn ? furn.FirstEdge : null);
		WallEdge wallEdge2 = (furn.WallFurn ? furn.SecondEdge : null);
		bool isReversed = furn.IsReversed;
		Quaternion rotation = furn.transform.rotation;
		float rotationOffset = furn.RotationOffset;
		Room parent = furn.Parent;
		SnapPoint snappedTo = furn.SnappedTo;
		Dictionary<int, List<Furniture>> dictionary = furn.SnapPoints.Where((SnapPoint sp) => sp.UsedByCount > 0).ToDictionary((SnapPoint sp) => sp.Id, (SnapPoint sp) => sp.GetAllUsedBy().ToList());
		for (int num = 0; num < furn.SnapPoints.Length; num++)
		{
			furn.SnapPoints[num].ClearUsedBy();
		}
		TableScript component = furn.GetComponent<TableScript>();
		Server component2 = furn.GetComponent<Server>();
		Actor ownedBy = furn.OwnedBy;
		float num2 = 0f;
		WriteDictionary oldFurn = null;
		List<UndoObject.UndoAction> list = ((undos == null) ? null : new List<UndoObject.UndoAction>());
		if (undos != null)
		{
			num2 -= furn.GetSellPrice();
			oldFurn = furn.SerializeThis(GameReader.NewLoadMode.Full, false);
		}
		furn.DestroyGO();
		if (DeleteParent(furn, upgrade))
		{
			upgrades.Remove(furn.SnappedTo.Parent);
			for (int num3 = idx + 1; num3 < upgrades.Count; num3++)
			{
				Furniture upg = upgrades[num3];
				if (furn.SnappedTo.Parent.SnapPoints.Any((SnapPoint y) => y.IsUsedBy(upg)))
				{
					upgrades.Remove(upg);
					num3--;
				}
			}
			if (undos != null)
			{
				undos.Add(new UndoObject.UndoAction(furn.SnappedTo.Parent, false));
				foreach (Furniture item2 in furn.SnappedTo.Parent.IterateSnap(furn))
				{
					undos.Add(new UndoObject.UndoAction(item2, false));
				}
			}
			furn.SnappedTo.Parent.DestroyGO();
		}
		InventoryItem inventoryItem = (inventory ? GameSettings.PopFromInventory(upgrade.name) : null);
		Furniture furniture = UnityEngine.Object.Instantiate(upgrade);
		furniture.name = furniture.name.Replace("(Clone)", "");
		Furniture component3 = furniture.GetComponent<Furniture>();
		component3.ColorPrimary = component3.ColorPrimaryDefault;
		component3.ColorSecondary = component3.ColorSecondaryDefault;
		component3.ColorTertiary = component3.ColorTertiaryDefault;
		component3.IsReversed = isReversed;
		component3.RotationOffset = rotationOffset;
		if (snappedTo != null)
		{
			if (component3.IsSnapping)
			{
				component3.OriginalPosition = vector;
				component3.transform.SetPositionAndRotation(vector, Quaternion.Euler(0f, rotationOffset, 0f) * snappedTo.transform.rotation);
				component3.SnappedTo = snappedTo;
				snappedTo.SetUsedBy(component3);
			}
			else
			{
				component3.OriginalPosition = new Vector3(vector.x, furn.Parent.Floor * 2, vector.z);
				component3.transform.SetPositionAndRotation(component3.OriginalPosition, rotation);
			}
		}
		else if (component3.WallFurn)
		{
			float magnitude = (wallEdge.Pos - wallEdge2.Pos).magnitude;
			float magnitude2 = (vector.FlattenVector3() - wallEdge.Pos).magnitude;
			component3.transform.position = (component3.OriginalPosition = vector);
			component3.Init(wallEdge, wallEdge2, magnitude2 / magnitude);
		}
		else
		{
			component3.OriginalPosition = new Vector3(vector.x, furn.Parent.Floor * 2, vector.z);
			component3.transform.SetPositionAndRotation(component3.OriginalPosition, rotation);
		}
		component3.UpdateConnectorPositions();
		component3.Parent = parent;
		component3.Floor = parent.Floor;
		Server component4 = component3.GetComponent<Server>();
		if (component2 != null && component4 != null)
		{
			component4.ServerName = component2.ServerName;
			component4.PreWired = true;
		}
		component3.OwnedBy = ownedBy;
		if (furn.InteractionPoints.Length == component3.InteractionPoints.Length)
		{
			for (int num4 = 0; num4 < furn.InteractionPoints.Length; num4++)
			{
				if (furn.InteractionPoints[num4].UsedBy != null && furn.InteractionPoints[num4].Action == component3.InteractionPoints[num4].Action)
				{
					Actor usedBy = furn.InteractionPoints[num4].UsedBy;
					usedBy.UsingPoint = component3.InteractionPoints[num4];
					component3.InteractionPoints[num4].UsedBy = usedBy;
				}
			}
		}
		if (dictionary.Count > 0)
		{
			Furniture[] otherSnaps = dictionary.SelectMany((KeyValuePair<int, List<Furniture>> x) => x.Value).ToArray();
			foreach (KeyValuePair<int, List<Furniture>> item in dictionary)
			{
				foreach (Furniture snapee in item.Value)
				{
					SnapPoint snapPoint = component3.SnapPoints.FirstOrDefault((SnapPoint sp) => sp.Id == item.Key && snapee.DoesSnapTo(sp.Name));
					bool flag = snapPoint != null;
					if (flag && snapee.CanSnapSurface && snapPoint.HasSurface && !snapPoint.IsWithinSurface(snapPoint.FixPosition(snapee.SnapPointOffset), snapee.SurfaceSnapRadius))
					{
						flag = false;
					}
					if (!flag)
					{
						if (undos != null)
						{
							list.Add(new UndoObject.UndoAction(snapee, false));
							foreach (Furniture item3 in snapee.IterateSnap())
							{
								list.Add(new UndoObject.UndoAction(item3, false));
							}
						}
						snapee.DestroyGO();
						continue;
					}
					Quaternion quaternion = Quaternion.Euler(0f, snapee.RotationOffset, 0f) * snapPoint.transform.rotation;
					if (ValidSnapBoundary(snapee, furn, otherSnaps, snapPoint.transform.position, quaternion))
					{
						snapee.SnappedTo = snapPoint;
						snapee.OriginalPosition = snapPoint.FixPosition(snapee.SnapPointOffset);
						snapee.transform.SetPositionAndRotation(snapee.OriginalPosition, quaternion);
						snapPoint.SetUsedBy(snapee);
						continue;
					}
					if (undos != null)
					{
						list.Add(new UndoObject.UndoAction(snapee, false));
						foreach (Furniture item4 in snapee.IterateSnap())
						{
							list.Add(new UndoObject.UndoAction(item4, false));
						}
					}
					snapee.DestroyGO();
				}
			}
		}
		if (component != null)
		{
			parent.RecalculateTableGroups();
		}
		component3.UpdateFreeNavs();
		component3.Parent.AddFurniture(component3);
		component3.InitLOD();
		component3.UpdateBoundaryPoints();
		if (inventoryItem != null)
		{
			inventoryItem.Deserialize(component3);
			inventory = true;
		}
		else
		{
			num2 += upgrade.GetCost();
			inventory = false;
		}
		if (undos != null)
		{
			undos.Add(new UndoObject.UndoAction(oldFurn, component3, num2, inventoryItem != null));
			undos.AddRange(list);
		}
		component3.AtlasIndex = component3.AtlasOff;
		return component3;
	}

	public void Cancel()
	{
		Window.Close();
	}
}
