using System.Collections.Generic;
using SINetworking;
using UnityEngine;

public class RoadBuildCube : MonoBehaviour
{
	public byte Type;

	public int x;

	public int y;

	public int lastX;

	public int lastY;

	public static RoadBuildCube Instance;

	private static float RoadCost = 20000f;

	public Material InvalidMat;

	public Material ValidMat;

	public Renderer rend;

	public GameObject Arrow;

	public GameObject Arrow2;

	private int prevX;

	private int prevY;

	private void Start()
	{
		if (Instance != null)
		{
			Object.Destroy(Instance.gameObject);
		}
		Instance = this;
		base.gameObject.SetActive(false);
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	private void OnEnable()
	{
		if (HUD.Instance != null)
		{
			BuildController.Instance.ClearBuild(false, true);
			WindowManager.SetCursorOverride("Place");
			Arrow.SetActive(false);
			if (Type < 4 || Type >= 8)
			{
				HUD.Instance.ShortcutPanel.AddShortcut("Stretch".Loc(), KeyCode.Mouse0, true);
			}
			else
			{
				HUD.Instance.ShortcutPanel.AddShortcut(InputController.Keys.FurnitureClock);
				HUD.Instance.ShortcutPanel.AddShortcut(InputController.Keys.FurnitureAntiClock);
			}
			if (GameSettings.Instance.ActiveFloor < 0 || GameSettings.Instance.ActiveFloor >= RoadManager.Floors || GameSettings.Instance.ActiveFloor % 2 == 1)
			{
				GameSettings.Instance.ActiveFloor = Mathf.Clamp(GameSettings.Instance.ActiveFloor / 2 * 2, 0, (RoadManager.Floors - 1) * 2);
				Furniture.UpdateEdgeDetection();
				GameSettings.Instance.sRoomManager.ChangeFloor();
			}
		}
	}

	private void OnDisable()
	{
		if (CostDisplay.Instance != null)
		{
			CostDisplay.Instance.Hide();
		}
	}

	public void ShowArrow(float rot, bool both)
	{
		Arrow.SetActive(true);
		Arrow2.SetActive(both);
		Arrow.transform.rotation = Quaternion.Euler(0f, rot, 0f);
	}

	public static float ActualRoadCost(int type, int floor)
	{
		if (type == 0)
		{
			return RoadCost * 0.5f;
		}
		float num = 1f;
		if (type >= 4 && type < 8)
		{
			num = 2f;
		}
		return RoadCost * num * Mathf.Pow(2f, floor);
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		SelectorController.CanClick = false;
		if (GameSettings.FreezeGame)
		{
			CostDisplay.Instance.Hide();
			return;
		}
		if (!CameraScript.WasDragging && Input.GetMouseButtonUp(1))
		{
			WindowManager.SetCursorOverride(null);
			HUD.Instance.ShortcutPanel.Hide();
			base.gameObject.SetActive(false);
			MaterialPreviewer.Instance.RefreshState();
			return;
		}
		if (Type >= 4 && Type < 8)
		{
			if (InputController.GetKeyUp(InputController.Keys.FurnitureClock))
			{
				Type++;
				if (Type >= 8)
				{
					Type = 4;
				}
				ShowArrow(Type * 90, false);
			}
			else if (InputController.GetKeyUp(InputController.Keys.FurnitureAntiClock))
			{
				Type--;
				if (Type < 4)
				{
					Type = 7;
				}
				ShowArrow(Type * 90, false);
			}
		}
		Ray ray = CameraScript.Instance.SSAScript.ScreenPointToRay(Input.mousePosition);
		Plane plane = new Plane(Vector3.up, Vector3.up * ((float)GameSettings.Instance.ActiveFloor * 2f));
		float enter = 0f;
		plane.Raycast(ray, out enter);
		Vector3 point = ray.GetPoint(enter);
		x = (int)(point.x / RoadManager.Instance.RoadSize);
		y = (int)(point.z / RoadManager.Instance.RoadSize);
		x = Mathf.Clamp(x, 0, RoadManager.Instance.GridSize - 1);
		y = Mathf.Clamp(y, 0, RoadManager.Instance.GridSize - 1);
		if (x != prevX || y != prevY)
		{
			if (Input.GetMouseButton(0))
			{
				float pitch = 1f + Mathf.Min(new Vector2(x - lastX, y - lastY).magnitude / 8f, 1f);
				UISoundFX.PlaySFX("Tick", pitch, 0f, true);
			}
			else
			{
				UISoundFX.PlaySFX("Tick", true);
			}
		}
		prevX = x;
		prevY = y;
		int num = GameSettings.Instance.ActiveFloor / 2;
		if (!GUICheck.OverGUI)
		{
			if (Input.GetMouseButtonDown(0))
			{
				lastX = x;
				lastY = y;
				return;
			}
			if (Input.GetMouseButtonUp(0))
			{
				float num2 = ActualRoadCost(Type, num);
				Rect buildRect = GetBuildRect();
				float num3 = 0f;
				for (int i = (int)buildRect.xMin; (float)i < buildRect.xMax; i++)
				{
					for (int j = (int)buildRect.yMin; (float)j < buildRect.yMax; j++)
					{
						num3 += (GetValid(i, j, num) ? num2 : 0f);
					}
				}
				if (num3 > 0f && GameSettings.Instance.MyCompany.CanMakeTransaction(0f - num3))
				{
					List<UndoObject.UndoAction> list = new List<UndoObject.UndoAction>
					{
						new UndoObject.UndoAction((int)buildRect.x, (int)buildRect.y, num, (int)buildRect.width, (int)buildRect.height, num3)
					};
					if (buildRect.width > 1f || buildRect.height > 1f)
					{
						RoadManager.Instance.PlaceRoad(buildRect, num, Type, list);
						if (num == 0)
						{
							GameSettings.Instance.sRoomManager.Outside.DirtyNavMesh = true;
							GameSettings.Instance.sRoomManager.Outside.DirtyPathNodes = true;
							GrassSystem.Instance.InvalidateArea();
						}
					}
					else
					{
						NetworkMessaging.SendPlaceRoad((int)buildRect.x, (int)buildRect.y, num, Type, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
						RoadManager.Instance.PlaceRoad(x, y, num, Type, list);
						if (num == 0)
						{
							GameSettings.Instance.sRoomManager.Outside.DirtyNavMesh = true;
							GameSettings.Instance.sRoomManager.Outside.DirtyPathNodes = true;
							GrassSystem.Instance.InvalidateArea();
						}
					}
					GameSettings.Instance.AddUndo(list.ToArray());
					GameSettings.Instance.SetDirtyHelipad(1);
					GameSettings.Instance.RefreshGaragePorts(num * 2);
					RoadManager.Instance.UpdateRoadVisibility();
					float roadSize = RoadManager.Instance.RoadSize;
					Rect rect = new Rect(buildRect.x * roadSize, buildRect.y * roadSize, buildRect.width * roadSize, buildRect.height * roadSize);
					foreach (Actor item in GameSettings.Instance.sActorManager.AllActors())
					{
						if (item.isActiveAndEnabled && item.currentRoom.Outside && item.ActualPosition.y > 1f && rect.Contains(item.ActualPosition.FlattenVector3()))
						{
							item.UpdateCurrentRoom(true);
						}
					}
					GameSettings.Instance.MyCompany.MakeTransaction(0f - num3, Company.TransactionCategory.Construction, true, "Road");
					UISoundFX.PlaySFX((Type == 0) ? "PlaceWallRev" : "PlaceRoom", true);
					UISoundFX.PlaySFX("Kaching");
					CostDisplay.Instance.FloatAway();
				}
				else if (num3 > 0f)
				{
					HUD.FlashMoney();
					UISoundFX.PlaySFX("BuildError");
				}
				return;
			}
			if (Input.GetMouseButton(0))
			{
				float num4 = ActualRoadCost(Type, num);
				Rect buildRect2 = GetBuildRect();
				float num5 = 0f;
				for (int k = (int)buildRect2.xMin; (float)k < buildRect2.xMax; k++)
				{
					for (int l = (int)buildRect2.yMin; (float)l < buildRect2.yMax; l++)
					{
						num5 += (GetValid(k, l, num) ? num4 : 0f);
					}
				}
				rend.sharedMaterial = ((num5 > 0f && GameSettings.Instance.MyCompany.CanMakeTransaction(0f - num5)) ? ValidMat : InvalidMat);
				if (num5 > 0f)
				{
					CostDisplay.Instance.Show(num5, base.transform.position + Vector3.up * 2f);
				}
				else
				{
					CostDisplay.Instance.Hide();
				}
				base.transform.position = new Vector3(buildRect2.x * RoadManager.Instance.RoadSize + buildRect2.width * RoadManager.Instance.RoadSize / 2f, (float)GameSettings.Instance.ActiveFloor * 2f, buildRect2.y * RoadManager.Instance.RoadSize + buildRect2.height * RoadManager.Instance.RoadSize / 2f);
				base.transform.localScale = new Vector3(buildRect2.width * RoadManager.Instance.RoadSize, base.transform.localScale.y, buildRect2.height * RoadManager.Instance.RoadSize);
				return;
			}
		}
		float num6 = ActualRoadCost(Type, num);
		bool flag = GetValid(x, y, num) && GameSettings.Instance.MyCompany.CanMakeTransaction(0f - num6);
		rend.sharedMaterial = (flag ? ValidMat : InvalidMat);
		if (flag)
		{
			CostDisplay.Instance.Show(num6, base.transform.position + Vector3.up * 2f);
		}
		else
		{
			CostDisplay.Instance.Hide();
		}
		base.transform.localScale = new Vector3(8f, base.transform.localScale.y, 8f);
		base.transform.position = new Vector3((float)x * RoadManager.Instance.RoadSize + RoadManager.Instance.RoadSize / 2f, (float)GameSettings.Instance.ActiveFloor * 2f, (float)y * RoadManager.Instance.RoadSize + RoadManager.Instance.RoadSize / 2f);
	}

	private Rect GetBuildRect()
	{
		if (Type >= 4 && Type < 8)
		{
			return new Rect(x, y, 1f, 1f);
		}
		int num = Mathf.Max(1, Mathf.Abs(lastX - x) + 1);
		int num2 = Mathf.Max(1, Mathf.Abs(lastY - y) + 1);
		bool flag = true;
		if (Type == 1)
		{
			if (num > num2)
			{
				num2 = 1;
			}
			else
			{
				flag = false;
				num = 1;
			}
		}
		int num3 = ((Type == 1 && !flag) ? lastX : Mathf.Min(x, lastX));
		int num4 = ((Type == 1 && flag) ? lastY : Mathf.Min(y, lastY));
		return new Rect(num3, num4, num, num2);
	}

	private bool GetValid(int x, int y, int floor)
	{
		if (floor < 0 || floor >= RoadManager.Floors)
		{
			return false;
		}
		if (RoadManager.Instance.GetRoad(x, y, floor) == Type)
		{
			return false;
		}
		bool flag = RoadManager.RaiseDirection(Type) > 0;
		if (flag && RoadManager.Instance.GetRoad(x, y, floor + 1) > 0)
		{
			ErrorOverlay.Instance.ShowError("OnRampError");
			return false;
		}
		if (floor >= RoadManager.Floors - 1 && Type >= 4 && Type < 8)
		{
			ErrorOverlay.Instance.ShowError("RampHighError");
			return false;
		}
		return RoadManager.Instance.CheckFree(x, y, floor, true, flag, Type != 0);
	}
}
