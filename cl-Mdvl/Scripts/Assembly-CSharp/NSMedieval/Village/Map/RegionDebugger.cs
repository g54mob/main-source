using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Map;
using NSMedieval.Tools;
using UnityEngine;

namespace NSMedieval.Village.Map
{
	public class RegionDebugger : MonoSingleton<RegionDebugger>
	{
		private readonly Dictionary<int, RegionMarkerDebugHandler> generatedRegionMarkerElements = new Dictionary<int, RegionMarkerDebugHandler>();

		private readonly Dictionary<int, Color> regionColors = new Dictionary<int, Color>();

		public Region HoveredRegion { get; private set; }

		public Region SelectedRegion { get; private set; }

		public bool IsHoverLocked { get; private set; }

		public void GenerateDebugElements()
		{
			if (MonoSingleton<VisualDebugManager>.IsInstantiated() && (MonoSingleton<VisualDebugManager>.Instance.EnabledType & VisualDebugType.MapRegions) != VisualDebugType.None)
			{
				GenerateRegionMarkerElements();
			}
		}

		public void GenerateRegionMarkerElements()
		{
			VisualDebugManager visualDebugManager = MonoSingleton<VisualDebugManager>.Instance;
			visualDebugManager.HideForType(VisualDebugType.MapRegions);
			visualDebugManager.EnableType(VisualDebugType.MapRegions);
			generatedRegionMarkerElements.Clear();
			foreach (Region region in VillageManager.ActiveVillage.Map.RegionManager.Regions)
			{
				RegionMarkerDebugHandler regionMarkerDebugHandler = GenerateRegionMarker(region);
				if (!(regionMarkerDebugHandler == null))
				{
					generatedRegionMarkerElements.Add(region.UniqueId, regionMarkerDebugHandler);
					visualDebugManager.RegisterCustomDebugElement(VisualDebugType.MapRegions, "tag", regionMarkerDebugHandler.gameObject);
				}
			}
		}

		private RegionMarkerDebugHandler GenerateRegionMarker(Region region)
		{
			if (region.YRange.Min > MonoSingleton<World>.Instance.ElevationLevel)
			{
				return null;
			}
			if (!regionColors.ContainsKey(region.UniqueId))
			{
				regionColors[region.UniqueId] = Random.ColorHSV(0f, 1f);
			}
			Color color = regionColors[region.UniqueId];
			GameObject gameObject = new GameObject("Debug Region Overlay");
			MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
			MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
			MeshCollider meshCollider = gameObject.AddComponent<MeshCollider>();
			RegionMarkerDebugHandler regionMarkerDebugHandler = gameObject.AddComponent<RegionMarkerDebugHandler>();
			regionMarkerDebugHandler.Region = region;
			regionMarkerDebugHandler.Color = color;
			List<Vector3> vertices = new List<Vector3>();
			List<Color> list = new List<Color>();
			List<int> triangles = new List<int>();
			for (int i = 0; i < region.Nodes.Count; i++)
			{
				Vec3Int position = region.Nodes[i].Position;
				MeshDataUtils.AppendUnitQuad(ref vertices, ref triangles, GridUtils.GetWorldPosition(position));
				list.Add(color);
				list.Add(color);
				list.Add(color);
				list.Add(color);
			}
			gameObject.transform.position = gameObject.transform.position + Vector3.one * 0.05f;
			Mesh mesh = MeshDataUtils.ToMesh(ref vertices, ref triangles);
			mesh.SetColors(list);
			meshCollider.sharedMesh = mesh;
			meshRenderer.sharedMaterial = new Material(Shader.Find("FoxyVoxel/Miscellaneous/fv_region_debug"));
			meshFilter.mesh = mesh;
			gameObject.SetActive(value: true);
			return regionMarkerDebugHandler;
		}

		private void GenerateTextElement(Region region)
		{
			MonoSingleton<VisualDebugManager>.Instance.HideForType(VisualDebugType.MapRegions);
			Vec3Int position = region.Nodes.First().Position;
			Vector3 a = position.ToVector3World();
			Vector3 b = position.ToVector3World();
			Vector3 position2 = Vector3.Lerp(a, b, 0.22f);
			position2.y = (float)(position.y * 3) + 1f;
			string text = "the_region_tag_" + position.y;
			MonoSingleton<VisualDebugManager>.Instance.Draw3dText(VisualDebugType.MapRegions, text, "IDX: " + region.UniqueId, position2, Color.white);
		}

		private void OnLayerChanged(float currentLevel, int maxLevel)
		{
			MonoSingleton<TaskController>.Instance.OptimizedCall(this, "refresh", GenerateDebugElements);
		}

		private void Update()
		{
			if (Camera.main == null)
			{
				return;
			}
			RaycastHit[] array = Physics.RaycastAll(Camera.main.ScreenPointToRay(Input.mousePosition));
			if (array == null || array.Length == 0)
			{
				return;
			}
			RegionMarkerDebugHandler regionMarkerDebugHandler = null;
			RaycastHit[] array2 = array;
			foreach (RaycastHit raycastHit in array2)
			{
				RegionMarkerDebugHandler component = raycastHit.collider.gameObject.GetComponent<RegionMarkerDebugHandler>();
				if (component == null)
				{
					continue;
				}
				component.OnPointerEnter();
				foreach (Region connection in component.Region.Connections)
				{
					if (!connection.HasDisposed)
					{
						if (!generatedRegionMarkerElements.ContainsKey(connection.UniqueId))
						{
							Log.Warning("WARNING HERE! Report this! Phantom connection in region " + component.Region.UniqueId, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Map\\Region\\RegionDebugger.cs");
						}
						else
						{
							generatedRegionMarkerElements[connection.UniqueId].OnPointerEnter(isConnection: true);
						}
					}
				}
				regionMarkerDebugHandler = component;
				if (!IsHoverLocked)
				{
					HoveredRegion = component.Region;
				}
				if (Input.GetMouseButtonDown(0))
				{
					SelectedRegion = component.Region;
				}
				if (Input.GetMouseButtonDown(1))
				{
					IsHoverLocked = !IsHoverLocked;
				}
				break;
			}
			foreach (KeyValuePair<int, RegionMarkerDebugHandler> generatedRegionMarkerElement in generatedRegionMarkerElements)
			{
				if (generatedRegionMarkerElement.Value == regionMarkerDebugHandler || (regionMarkerDebugHandler != null && regionMarkerDebugHandler.Region.Connections.Contains(generatedRegionMarkerElement.Value.Region)))
				{
					continue;
				}
				generatedRegionMarkerElement.Value.OnPointerExit();
				foreach (Region connection2 in generatedRegionMarkerElement.Value.Region.Connections)
				{
					if (!connection2.HasDisposed && (!(regionMarkerDebugHandler != null) || (regionMarkerDebugHandler.Region != connection2 && !regionMarkerDebugHandler.Region.Connections.Contains(connection2))))
					{
						if (!generatedRegionMarkerElements.ContainsKey(connection2.UniqueId))
						{
							Log.Warning("WARNING HERE! Report this! Phantom connection in region " + generatedRegionMarkerElement.Value.Region.UniqueId, "C:\\GIT\\dev\\Assets\\Scripts\\Village\\Map\\Region\\RegionDebugger.cs");
						}
						else
						{
							generatedRegionMarkerElements[connection2.UniqueId].OnPointerExit();
						}
					}
				}
			}
		}

		private void Start()
		{
			MonoSingleton<World>.Instance.LayerChangeEvent += OnLayerChanged;
		}
	}
}
