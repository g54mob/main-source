using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.BuildingComponents;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Production;
using NSMedieval.State;
using NSMedieval.Tools;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using NSMedieval.Utils.Pool;
using NSMedieval.View;
using NSMedieval.Village;
using NSMedieval.Village.Map;
using TMPro;
using UnityEngine;

namespace NSMedieval.RoomDetection
{
	public class RoomView : SelectableObject
	{
		private static int ignoreLayerIds;

		private static readonly string[] OutlineIgnoreLayers = new string[4] { "IgnoreOutline", "TransparentFX", "Grid", "UI" };

		private static readonly Color TransparentColor = new Color(0f, 0f, 0f, 0f);

		private readonly List<string> roomDescription = new List<string>();

		private readonly Dictionary<string, int> resourcesCount = new Dictionary<string, int>();

		private readonly HashSet<string> isPile = new HashSet<string>();

		private readonly HashSet<string> isPlant = new HashSet<string>();

		[SerializeField]
		protected TMP_Text text;

		[SerializeField]
		private const float FlashDuration = 1.3f;

		[SerializeField]
		private GameObject roomLevelPrefab;

		[NonSerialized]
		private HashSet<BaseBuildingInstance> stairsInRoom;

		[NonSerialized]
		private HashSet<SlopeInstance> slopesInRoom;

		[NonSerialized]
		private Room room;

		[NonSerialized]
		private List<MeshFilter> meshFilters = new List<MeshFilter>();

		[NonSerialized]
		private List<MeshRenderer> meshRenderers = new List<MeshRenderer>();

		[NonSerialized]
		private List<MeshCollider> meshColliders = new List<MeshCollider>();

		private Vector3 center;

		private bool subscribed;

		private bool isVisible;

		private bool flash;

		private float flashStart;

		private RoomType flashPreviousRoomType;

		public override bool Visible => true;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			ignoreLayerIds = 0;
		}

		public override WorldObject GetAsWorldObject()
		{
			return null;
		}

		public void Init(Room room, RoomType previousType)
		{
			if (stairsInRoom == null)
			{
				stairsInRoom = new HashSet<BaseBuildingInstance>();
			}
			else
			{
				stairsInRoom.Clear();
			}
			if (slopesInRoom == null)
			{
				slopesInRoom = new HashSet<SlopeInstance>();
			}
			else
			{
				slopesInRoom.Clear();
			}
			SlopeManager instance = MonoSingleton<SlopeManager>.Instance;
			foreach (Region region in room.Regions)
			{
				if (region == null)
				{
					continue;
				}
				foreach (Region connection in region.Connections)
				{
					if (connection == null || (connection.GridDataType & GridDataType.SlopeOrStairs) == 0 || !(connection is RegionBridge regionBridge))
					{
						continue;
					}
					foreach (MapNode node in regionBridge.Nodes)
					{
						if (node == null)
						{
							continue;
						}
						foreach (WorldObject worldObject in node.WorldObjects)
						{
							if (worldObject != null && (worldObject.GridDataType & GridDataType.Stairs) != GridDataType.None && worldObject is BaseBuildingInstance item)
							{
								stairsInRoom.Add(item);
							}
						}
					}
				}
				foreach (MapNode node2 in region.Nodes)
				{
					if ((node2.DataType & GridDataType.Slope) != GridDataType.None)
					{
						SlopeInstance slopeAtPosition = instance.GetSlopeAtPosition(node2.Position);
						if (slopeAtPosition != null)
						{
							slopesInRoom.Add(slopeAtPosition);
						}
					}
				}
			}
			Init(room);
			this.room = room;
			isVisible = MonoSingleton<RoomViewManager>.Instance.IsShowingRooms;
			if (previousType != room.RoomType)
			{
				RoomTypeChanged(previousType);
			}
		}

		public override string GetSimpleName()
		{
			return GetNameInSelection();
		}

		public override string GetMultiselectName()
		{
			return GetNameInSelection();
		}

		public void RoomTypeChanged(RoomType previousType)
		{
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(30, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\RoomDetection\\RoomView.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("ROOM TYPE CHANGED - VIEW ");
				messageBuilder.AppendFormatted(previousType);
				messageBuilder.AppendLiteral(" --> ");
				messageBuilder.AppendFormatted(room.RoomType);
			}
			Log.Info(messageBuilder);
			SetRoomMeshColor(room.RoomType.Color);
			foreach (MeshRenderer meshRenderer in meshRenderers)
			{
				meshRenderer.material = MonoSingleton<RoomViewManager>.Instance.GetMaterial(room.RoomType);
			}
			Vector3 position = base.transform.position;
			if (MonoSingleton<RoomViewManager>.Instance.ShowRoomCreatedText)
			{
				DamagePopup.Create(position, room.GetRoomTypeLocalized());
			}
			if (MonoSingleton<RoomViewManager>.Instance.ShowRoomCreatedText && !room.RoomType.Equals(Repository<RoomTypeRepository, RoomType>.Instance.DefaultRoomType))
			{
				string messageText = MonoSingleton<LocalizationController>.Instance.GetText("room_new") + ": " + room.GetRoomTypeLocalized();
				MonoSingleton<BlackBarMessageController>.Instance.ShowClickableBlackBarMessage(messageText, position);
			}
			if (previousType != null)
			{
				SetRoomMeshColor(previousType.Color);
			}
			Flash(previousType);
		}

		public override InfoPanelData GetInfoPanelData()
		{
			return InfoPanelData();
		}

		public override InfoPanelData UpdateCallback()
		{
			return InfoPanelData();
		}

		protected override bool IsSelectionNull()
		{
			if (room != null)
			{
				return room.RoomType == null;
			}
			return true;
		}

		protected override bool CheckMeshRenderLayer(GameObject rendererGameObject)
		{
			if (ignoreLayerIds == 0)
			{
				string[] outlineIgnoreLayers = OutlineIgnoreLayers;
				foreach (string layerName in outlineIgnoreLayers)
				{
					ignoreLayerIds |= 1 << LayerMask.NameToLayer(layerName);
				}
			}
			return ((1 << rendererGameObject.layer) & ignoreLayerIds) == 0;
		}

		private void OnRoomOverlayToggle(bool roomOverlayEnabled)
		{
			if (room != null && !(room.RoomType == null))
			{
				isVisible = roomOverlayEnabled;
				if (isVisible)
				{
					SetRoomMeshColor(room.RoomType.Color);
				}
				if (base.gameObject.activeInHierarchy)
				{
					SetVisible(roomOverlayEnabled);
				}
			}
		}

		private string GetNameInSelection()
		{
			if (room == null || room.RoomType == null)
			{
				return string.Empty;
			}
			if (MonoSingleton<SelectableObjectManager>.Instance.SelectedObjects.Any((SelectableObject obj) => obj is RoomView { room: not null } roomView && roomView.room.RoomType != room.RoomType))
			{
				return MonoSingleton<LocalizationController>.Instance.GetText("room_in_selection");
			}
			return room.GetRoomTypeLocalized();
		}

		private new void OnDestroy()
		{
			foreach (MeshFilter meshFilter in meshFilters)
			{
				Mesh sharedMesh = meshFilter.sharedMesh;
				meshFilter.sharedMesh = null;
				meshFilter.mesh = null;
				UnityEngine.Object.DestroyImmediate(sharedMesh);
			}
			foreach (MeshRenderer meshRenderer in meshRenderers)
			{
				if (meshRenderer.material != null)
				{
					Material material = meshRenderer.material;
					meshRenderer.material = null;
					UnityEngine.Object.DestroyImmediate(material);
				}
				meshRenderer.sharedMaterial = null;
			}
			meshFilters.Clear();
			meshRenderers.Clear();
			meshColliders.Clear();
			Unsubscribe();
			base.OnDestroy();
		}

		private void Unsubscribe()
		{
			if (MonoSingleton<RoomViewManager>.IsInstantiated())
			{
				RoomViewManager instance = MonoSingleton<RoomViewManager>.Instance;
				instance.RoomOverlayToggleEvent = (Action<bool>)Delegate.Remove(instance.RoomOverlayToggleEvent, new Action<bool>(OnRoomOverlayToggle));
			}
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.LayerChangeEvent -= OnLayerChanged;
			}
			subscribed = false;
		}

		private void OnLayerChanged(float layerLevel, int mapSizeY)
		{
			if (room?.YLevels == null || room.YLevels.Count > meshRenderers.Count)
			{
				return;
			}
			for (int i = 0; i < room.YLevels.Count; i++)
			{
				if ((float)room.YLevels[i] > layerLevel)
				{
					meshRenderers[i].gameObject.SetActive(value: false);
				}
				else
				{
					meshRenderers[i].gameObject.SetActive(value: true);
				}
			}
		}

		private void OnCreateMesh(int yLevel, ref List<Vector3> vertices, ref List<int> triangles)
		{
			float blockHeight = World.MapBlockHeight;
			List<Vector3> verts = ListPool<Vector3>.Get();
			List<int> tris = ListPool<int>.Get();
			foreach (BaseBuildingInstance item in stairsInRoom)
			{
				if (item != null && !(item.Blueprint == null) && yLevel == item.GridDataPosition.y)
				{
					AppendStairMesh(GridUtils.GetWorldPosition(item.GridDataPosition) - center, item.Size, item.Angle + 90f, ref vertices, ref triangles);
				}
			}
			foreach (SlopeInstance item2 in slopesInRoom)
			{
				if (item2 != null && yLevel == item2.GridDataPosition.y)
				{
					AppendStairMesh(GridUtils.GetWorldPosition(item2.GridDataPosition) - center, new Vec3Int(item2.Positions.Count, 1, 1), item2.Angle + 180f, ref vertices, ref triangles);
				}
			}
			ListPool<Vector3>.Return(verts);
			ListPool<int>.Return(tris);
			void AppendStairMesh(Vector3 worldPos, Vec3Int size, float angle, ref List<Vector3> v, ref List<int> t)
			{
				verts.Clear();
				tris.Clear();
				float num = size.x;
				MeshDataUtils.AppendQuad(v1: new Vector3(-0.5f, 0f, -0.5f), v2: new Vector3(0.5f, 0f, -0.5f), v3: new Vector3(0.5f, 0f - blockHeight, -0.5f + num), v4: new Vector3(-0.5f, 0f - blockHeight, -0.5f + num), vertices: ref verts, triangles: ref tris);
				MeshDataUtils.RotateMeshAround(ref verts, Vector3.up, angle);
				MeshDataUtils.TranslateMesh(ref verts, worldPos + Vector3.up * blockHeight);
				MeshDataUtils.AddToMesh(ref verts, ref tris, ref v, ref t);
			}
		}

		private void Update()
		{
			UpdateFlash();
			bool visible = isVisible || flash;
			SetVisible(visible);
			ShowWeatherDebug();
		}

		private void ShowWeatherDebug()
		{
			if (!(text == null))
			{
				bool flag = MonoSingleton<WeatherManager>.Instance.IsDebugViewEnabled() && MonoSingleton<WeatherManager>.Instance.DebugWeatherInfo;
				if (flag && !text.gameObject.activeSelf)
				{
					text.gameObject.SetActive(value: true);
				}
				else if (!flag && text.gameObject.activeSelf)
				{
					text.gameObject.SetActive(value: false);
				}
				if (room != null && flag && text.gameObject.activeInHierarchy)
				{
					text.SetText(room.GetDebugText());
				}
			}
		}

		private void UpdateFlash()
		{
			if (room == null || room.RoomType == null || !flash)
			{
				return;
			}
			float unscaledTime = Time.unscaledTime;
			Color roomMeshColor;
			if (unscaledTime >= flashStart + 1.3f)
			{
				flash = false;
				roomMeshColor = room.RoomType.Color;
			}
			else
			{
				float num = (unscaledTime - flashStart) / 1.3f;
				float num2 = Mathf.Sin(MathF.PI * num);
				num2 = 1f - Mathf.Pow(1f - num2, 3f);
				if (isVisible)
				{
					Color color = ((flashPreviousRoomType != null) ? flashPreviousRoomType.Color : room.RoomType.Color);
					roomMeshColor = Color.Lerp((num < 0.5f) ? color : room.RoomType.Color, Color.white, num2);
				}
				else
				{
					roomMeshColor = Color.Lerp(TransparentColor, room.RoomType.Color, num2);
				}
			}
			SetRoomMeshColor(roomMeshColor);
		}

		private void GetRoomStatsInfo(out List<string> infos, out List<string> infoTooltips)
		{
			infos = new List<string>();
			infoTooltips = new List<string>();
			if (room != null && !(room.RoomType == null))
			{
				string text = ColorUtility.ToHtmlStringRGB(room.RoomType.Color);
				infos.Add(MonoSingleton<LocalizationController>.Instance.GetText("room_info_type") + " <color=#" + text + ">" + room.RoomType.NameLocalized + "</color>");
				infoTooltips.Add(string.Empty);
				infos.Add(MonoSingleton<LocalizationController>.Instance.GetText("room_info_temperature") + " " + WorldDate.GetLocalizedTemperature(room.AverageTemperature));
				infoTooltips.Add(string.Empty);
				infos.Add(MonoSingleton<LocalizationController>.Instance.GetText("room_imp") + ": " + room.Impressiveness?.NameLocalized);
				infoTooltips.Add("<style=TooltipTitle>" + MonoSingleton<LocalizationController>.Instance.GetText("room_imp") + "</style>\n" + room.Impressiveness?.InfoLocalized);
				infos.Add(string.Format("{0}: {1}", MonoSingleton<LocalizationController>.Instance.GetText("room_imp_free_space"), room.FreeSpace));
				infoTooltips.Add("<style=TooltipTitle>" + MonoSingleton<LocalizationController>.Instance.GetText("room_imp_free_space") + "</style>\n" + MonoSingleton<LocalizationController>.Instance.GetText("room_imp_free_space_info"));
				infos.Add(string.Format("{0}: {1:F1}", MonoSingleton<LocalizationController>.Instance.GetText("room_imp_wealth"), room.TotalWealth));
				infoTooltips.Add("<style=TooltipTitle>" + MonoSingleton<LocalizationController>.Instance.GetText("room_imp_wealth") + "</style>\n" + MonoSingleton<LocalizationController>.Instance.GetText("room_imp_wealth_info"));
				infos.Add(string.Format("{0}: {1:F1}", MonoSingleton<LocalizationController>.Instance.GetText("room_imp_average_beauty"), room.AverageBeauty));
				infoTooltips.Add("<style=TooltipTitle>" + MonoSingleton<LocalizationController>.Instance.GetText("room_imp_average_beauty") + "</style>\n" + MonoSingleton<LocalizationController>.Instance.GetText("room_imp_average_beauty_info"));
				ListRoomContent(ref infos, ref infoTooltips);
			}
		}

		private void ListRoomContent(ref List<string> list, ref List<string> tooltips)
		{
			resourcesCount.Clear();
			isPile.Clear();
			isPlant.Clear();
			foreach (WorldObject item in room.IterateRoomContent())
			{
				if (item.Type == WorldObjectType.ResourcePile)
				{
					ResourcePileInstance resourcePileInstance = (ResourcePileInstance)item;
					string blueprintId = resourcePileInstance.BlueprintId;
					int num = ((resourcePileInstance.GetStoredResource() != null) ? resourcePileInstance.GetStoredResource().Amount : 0);
					if (!resourcesCount.TryAdd(blueprintId, num))
					{
						resourcesCount[blueprintId] += num;
					}
					else
					{
						isPile.Add(blueprintId);
					}
				}
				if (item.Type == WorldObjectType.Building)
				{
					string blueprintId2 = item.BlueprintId;
					if (!resourcesCount.TryAdd(blueprintId2, 1))
					{
						resourcesCount[blueprintId2]++;
					}
				}
				if (item.Type == WorldObjectType.MapResource && item is PlantMapResourceInstance)
				{
					string blueprintId3 = item.BlueprintId;
					if (!resourcesCount.TryAdd(blueprintId3, 1))
					{
						resourcesCount[blueprintId3]++;
					}
					else
					{
						isPlant.Add(blueprintId3);
					}
				}
			}
			list.Add("\n");
			list.Add(MonoSingleton<LocalizationController>.Instance.GetText("room_info_content"));
			foreach (string key in resourcesCount.Keys)
			{
				string text = ((!isPile.Contains(key)) ? ((!isPlant.Contains(key)) ? BuildingUtils.GetLocalizedName(key) : PlantUtils.GetLocalizedName(key)) : ResourceUtils.GetLocalizedResourceName(key));
				list.Add(text + " " + ((resourcesCount[key] > 1) ? $"x{resourcesCount[key]}" : string.Empty));
			}
		}

		private List<string> GetDescription()
		{
			roomDescription.Clear();
			if (room == null || room.RoomType == null)
			{
				return roomDescription;
			}
			roomDescription.Add(MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetInfo(room.RoomType.LocKeys)));
			return roomDescription;
		}

		private string GetPanelTitle()
		{
			if (room == null)
			{
				return string.Empty;
			}
			return room.GetRoomTypeLocalized();
		}

		private List<string> GetInfos()
		{
			List<string> list = new List<string>();
			if (room == null || room.RoomType == null)
			{
				return list;
			}
			list.Add(MonoSingleton<LocalizationController>.Instance.GetText("room_info_type") + " " + room.RoomType.NameLocalized);
			list.Add(string.Format("{0} {1}", MonoSingleton<LocalizationController>.Instance.GetText("room_info_area"), room.AllNodes.Count));
			return list;
		}

		private void Flash(RoomType previousType)
		{
			flashPreviousRoomType = previousType;
			if (MonoSingleton<RoomViewManager>.Instance.ShowRoomCreatedText)
			{
				flash = true;
				flashStart = Time.unscaledTime;
			}
		}

		private void SetRoomMeshColor(Color color)
		{
			foreach (MeshRenderer meshRenderer in meshRenderers)
			{
				meshRenderer.material.SetColor("_StockpileColor", color);
			}
		}

		private void SetVisible(bool isVisible)
		{
			foreach (MeshRenderer meshRenderer in meshRenderers)
			{
				if (meshRenderer != null && meshRenderer.enabled != isVisible)
				{
					meshRenderer.enabled = isVisible;
				}
			}
			foreach (MeshCollider meshCollider in meshColliders)
			{
				if (meshCollider != null && meshCollider.gameObject.activeSelf != isVisible)
				{
					meshCollider.gameObject.SetActive(isVisible);
				}
			}
		}

		private void Init(Room room)
		{
			center = room.GetAveragePosition();
			base.gameObject.transform.position = center;
			int num = 0;
			foreach (int yLevel in room.YLevels)
			{
				MeshFilter meshFilter;
				MeshCollider meshCollider;
				if (num < meshFilters.Count)
				{
					meshFilter = meshFilters[num];
					meshCollider = meshColliders[num];
				}
				else
				{
					GameObject obj = UnityEngine.Object.Instantiate(roomLevelPrefab, base.transform, worldPositionStays: false);
					meshFilter = obj.GetComponent<MeshFilter>();
					MeshRenderer component = obj.GetComponent<MeshRenderer>();
					meshCollider = obj.GetComponentInChildren<MeshCollider>();
					meshFilters.Add(meshFilter);
					meshRenderers.Add(component);
					meshColliders.Add(meshCollider);
				}
				Mesh outMesh = null;
				CreateMesh(room, yLevel, ref outMesh);
				meshFilter.sharedMesh = outMesh;
				meshCollider.sharedMesh = outMesh;
				num++;
			}
			meshRenderers.SetActiveFromIndex(num, active: false);
			base.transform.position = center;
			SetVisible(MonoSingleton<RoomViewManager>.Instance.IsShowingRooms);
			if ((bool)text)
			{
				text.gameObject.SetActive(value: false);
			}
			if (!subscribed)
			{
				subscribed = true;
				RoomViewManager instance = MonoSingleton<RoomViewManager>.Instance;
				instance.RoomOverlayToggleEvent = (Action<bool>)Delegate.Combine(instance.RoomOverlayToggleEvent, new Action<bool>(OnRoomOverlayToggle));
				MonoSingleton<World>.Instance.LayerChangeEvent += OnLayerChanged;
			}
		}

		public void Deactivate()
		{
			room = null;
			stairsInRoom?.Clear();
			slopesInRoom?.Clear();
			Unsubscribe();
			base.gameObject.SetActive(value: false);
		}

		private void CreateMesh(Room room, int yLevel, ref Mesh outMesh)
		{
			List<Vector3> vertices = new List<Vector3>();
			List<int> triangles = new List<int>();
			foreach (MapNode allNode in room.AllNodes)
			{
				if ((allNode.DataType & GridDataType.SlopeOrStairs) != GridDataType.None || allNode.Position.y != yLevel)
				{
					continue;
				}
				if (allNode.DataType == GridDataType.None && allNode.GetNodeBelow()?.VoxelType == null)
				{
					MapNode nodeBelow = allNode.GetNodeBelow();
					if (nodeBelow != null && (nodeBelow.Tag & (MapNodeTags.DoorWorkerWalkable | MapNodeTags.DoorCompletelyLocked | MapNodeTags.BarnDoor | MapNodeTags.DoorAlwaysOpen | MapNodeTags.Wall | MapNodeTags.EnemyDoorClosed)) == 0)
					{
						continue;
					}
				}
				MapNode nodeBelow2 = allNode.GetNodeBelow();
				if (nodeBelow2 == null || (nodeBelow2.DataType & GridDataType.SlopeOrStairs) == 0)
				{
					MeshDataUtils.AppendUnitQuad(ref vertices, ref triangles, allNode.WorldPosition - center);
				}
			}
			OnCreateMesh(yLevel, ref vertices, ref triangles);
			bool isEnabled;
			FVLogInfoInterpolationHandler messageBuilder;
			if (outMesh == null)
			{
				messageBuilder = new FVLogInfoInterpolationHandler(11, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\RoomDetection\\RoomView.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("[");
					messageBuilder.AppendFormatted(GetHashCode());
					messageBuilder.AppendLiteral("] NEW MESH");
				}
				Log.Info(messageBuilder);
				outMesh = MeshDataUtils.ToMesh(ref vertices, ref triangles);
				return;
			}
			messageBuilder = new FVLogInfoInterpolationHandler(11, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\RoomDetection\\RoomView.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("[");
				messageBuilder.AppendFormatted(GetHashCode());
				messageBuilder.AppendLiteral("] old MESH");
			}
			Log.Info(messageBuilder);
			outMesh.Clear();
			outMesh.SetVertices(vertices);
			outMesh.SetTriangles(triangles, 0);
		}

		private InfoPanelData InfoPanelData()
		{
			InfoPanelHeader header = new InfoPanelHeader("room", GetPanelTitle(), GetSimpleName());
			InfoPanelBody panelBody = GetPanelBody();
			InfoPanelFooter footer = new InfoPanelFooter(new List<InfoPanelAction>());
			return new InfoPanelData(InfoPanelDataType.General, header, panelBody, footer);
		}

		private InfoPanelBody GetPanelBody()
		{
			GetRoomStatsInfo(out var infos, out var infoTooltips);
			return new InfoPanelBody("room", GetSimpleName(), string.Empty, GetInfoStats(), infos, infoTooltips, null, GetDescription(), GetInfos());
		}

		private static List<InfoPanelStat> GetInfoStats()
		{
			return new List<InfoPanelStat>();
		}
	}
}
