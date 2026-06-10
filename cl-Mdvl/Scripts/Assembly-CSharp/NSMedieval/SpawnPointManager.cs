using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix;
using NSEipix.Base;
using NSMedieval.Construction;
using NSMedieval.Manager;
using UnityEngine;

namespace NSMedieval
{
	public class SpawnPointManager : MonoSingleton<SpawnPointManager>
	{
		[SerializeField]
		private float ColorAlphaNormal = 1f;

		[SerializeField]
		private float ColorAlphaSelected = 6f;

		[SerializeField]
		private GameObject spawnPointPrefab;

		private List<SpawnPoint> spawnPoints;

		private Dictionary<Vec3Int, SpawnPoint> posToSpawnPoint;

		private Dictionary<SpawnPoint, GameObject> spawnPointToView;

		private List<GameObject> cachedSpawnPointObjects;

		private SpawnPoint selectedSpawnPoint;

		private Dictionary<SpawnPointType, Color> spawnPointColors;

		private SpawnPointType lastSpawnPointType;

		private Ray ray;

		private RaycastHit hit;

		private ObjectSide hitSide;

		private int voxelMapLayer;

		private int buildableSurfaceLayer;

		private int raycastPlaneHelperLayer;

		private int raycastMask;

		private bool isDragging;

		private bool isActive;

		private bool spawnPointsLoaded;

		public bool Active => isActive;

		public bool Dragging => isDragging;

		public List<SpawnPoint> SpawnPoints => spawnPoints;

		public SpawnPoint SelectedSpawnPoint => selectedSpawnPoint;

		[field: NonSerialized]
		public event Action OnPointsUpdated;

		public void SetActive(bool isActive)
		{
			this.isActive = isActive;
			SetActiveSpawnPoints(isActive);
		}

		public void LoadSpawnPoints()
		{
			if (spawnPointsLoaded || MonoSingleton<TravelManager>.Instance.SaveInfo == null)
			{
				return;
			}
			foreach (SpawnPoint allSpawnPoint in MonoSingleton<TravelManager>.Instance.SaveInfo.AllSpawnPoints)
			{
				LoadPoint(allSpawnPoint);
			}
			spawnPointsLoaded = true;
			this.OnPointsUpdated?.Invoke();
		}

		public void AddNewPoint()
		{
			Vector3 screenPos = new Vector3((float)Screen.width * 0.5f, (float)Screen.height * 0.5f, 0f);
			Vec3Int mouseGridPosition = GetMouseGridPosition(screenPos);
			if (!posToSpawnPoint.ContainsKey(mouseGridPosition))
			{
				SpawnPoint spawnPoint = new SpawnPoint(mouseGridPosition, (lastSpawnPointType == SpawnPointType.None) ? SpawnPointType.FriendlyGeneral : lastSpawnPointType);
				spawnPoints.Add(spawnPoint);
				posToSpawnPoint.Add(spawnPoint.Position, spawnPoint);
				spawnPointToView.Add(spawnPoint, GetObject());
				SetSpawnPointColor(spawnPoint);
				SelectSpawnPoint(spawnPoint);
				this.OnPointsUpdated?.Invoke();
			}
		}

		public void OnSelectSpawnPoint(SpawnPoint spawnPoint)
		{
			SelectSpawnPoint(spawnPoint);
		}

		public void OnSpawnPointTypeChange(SpawnPoint spawnPoint)
		{
			SetSpawnPointColor(spawnPoint);
			lastSpawnPointType = spawnPoint.Type;
		}

		public void DeleteSpawnPoint()
		{
			if (selectedSpawnPoint != null)
			{
				spawnPoints.Remove(selectedSpawnPoint);
				posToSpawnPoint.Remove(selectedSpawnPoint.Position);
				cachedSpawnPointObjects.Add(spawnPointToView[selectedSpawnPoint]);
				spawnPointToView[selectedSpawnPoint].SetActive(value: false);
				spawnPointToView.Remove(selectedSpawnPoint);
				SelectSpawnPoint(null);
				this.OnPointsUpdated?.Invoke();
			}
		}

		public void DeleteAllSpawnPoints()
		{
			spawnPoints.Clear();
			posToSpawnPoint.Clear();
			foreach (GameObject value in spawnPointToView.Values)
			{
				value.SetActive(value: false);
				cachedSpawnPointObjects.Add(value);
			}
			spawnPointToView.Clear();
			SelectSpawnPoint(null);
			this.OnPointsUpdated?.Invoke();
		}

		private void RefreshSpawnPoints()
		{
			posToSpawnPoint.Clear();
			foreach (SpawnPoint spawnPoint in spawnPoints)
			{
				posToSpawnPoint.Add(spawnPoint.Position, spawnPoint);
			}
			this.OnPointsUpdated?.Invoke();
		}

		private void LoadPoint(SpawnPoint spawnPoint)
		{
			spawnPoints.Add(spawnPoint);
			posToSpawnPoint.Add(spawnPoint.Position, spawnPoint);
			spawnPointToView.Add(spawnPoint, GetObject());
			SetSpawnPointColor(spawnPoint);
		}

		public void OnMouseButtonDown(Vector3 position)
		{
		}

		public void OnMouseButtonUp(Vector3 position)
		{
			if (isDragging)
			{
				isDragging = false;
				RefreshSpawnPoints();
				return;
			}
			Vec3Int mouseGridPosition = GetMouseGridPosition(position);
			if (posToSpawnPoint.TryGetValue(mouseGridPosition, out var value))
			{
				SelectSpawnPoint(value);
			}
			else
			{
				SelectSpawnPoint(null);
			}
			RefreshSpawnPoints();
		}

		public void CancelSelection()
		{
			SelectSpawnPoint(null);
			isDragging = false;
		}

		public void OnDragStart(Vector3 position)
		{
			Vec3Int mouseGridPosition = GetMouseGridPosition(position);
			if (posToSpawnPoint.TryGetValue(mouseGridPosition, out var value))
			{
				SelectSpawnPoint(value);
				isDragging = true;
			}
		}

		public void OnDragTick(Vector3 position)
		{
			if (isDragging && selectedSpawnPoint != null)
			{
				selectedSpawnPoint.Position = GetMouseGridPosition(position);
			}
		}

		public void OnPositionUpdate(Vector3 position)
		{
			DrawSpawnPoints();
		}

		protected override void Awake()
		{
			base.Awake();
			spawnPoints = new List<SpawnPoint>();
			posToSpawnPoint = new Dictionary<Vec3Int, SpawnPoint>();
			spawnPointToView = new Dictionary<SpawnPoint, GameObject>();
			cachedSpawnPointObjects = new List<GameObject>();
			buildableSurfaceLayer = 1 << LayerMask.NameToLayer("BuildableSurface");
			raycastPlaneHelperLayer = 1 << LayerMask.NameToLayer("RaycastPlaneHelper");
			voxelMapLayer = 1 << LayerMask.NameToLayer("VoxelMap");
			raycastMask = voxelMapLayer | buildableSurfaceLayer | raycastPlaneHelperLayer;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			this.OnPointsUpdated = null;
			spawnPoints = null;
			posToSpawnPoint = null;
			selectedSpawnPoint = null;
			spawnPointToView = null;
			cachedSpawnPointObjects = null;
		}

		private void SetActiveSpawnPoints(bool active)
		{
			foreach (KeyValuePair<SpawnPoint, GameObject> item in spawnPointToView)
			{
				item.Value.SetActive(active);
			}
		}

		private void DrawSpawnPoints()
		{
			if (!Active || spawnPoints.Count == 0)
			{
				return;
			}
			foreach (SpawnPoint spawnPoint in spawnPoints)
			{
				spawnPointToView[spawnPoint].transform.position = spawnPoint.Position.ToVector3World();
			}
		}

		private void SelectSpawnPoint(SpawnPoint spawnPoint)
		{
			SetSpawnPointAlpha(selectedSpawnPoint, ColorAlphaNormal);
			selectedSpawnPoint = spawnPoint;
			SetSpawnPointAlpha(selectedSpawnPoint, ColorAlphaSelected);
		}

		private void SetSpawnPointAlpha(SpawnPoint spawnPoint, float alpha)
		{
			if (spawnPoint != null && spawnPointToView.ContainsKey(spawnPoint))
			{
				MeshRenderer component = spawnPointToView[spawnPoint].GetComponent<MeshRenderer>();
				Color color = component.material.color;
				color.a = alpha;
				component.material.color = color;
			}
		}

		private void SetSpawnPointColor(SpawnPoint spawnPoint)
		{
			spawnPointToView[spawnPoint].GetComponent<MeshRenderer>().material.color = GetColorForType(spawnPoint.Type);
		}

		private Color GetColorForType(SpawnPointType type)
		{
			if (spawnPointColors == null || spawnPointColors.Count == 0)
			{
				spawnPointColors = new Dictionary<SpawnPointType, Color>();
				spawnPointColors.Add(SpawnPointType.FriendlyGeneral, new Color(0.158f, 0.347f, 1f, ColorAlphaNormal));
				spawnPointColors.Add(SpawnPointType.FriendlyArcher, new Color(0.158f, 0.73f, 1f, ColorAlphaNormal));
				spawnPointColors.Add(SpawnPointType.FriendlyAnimal, new Color(0.158f, 1f, 0.69f, ColorAlphaNormal));
				spawnPointColors.Add(SpawnPointType.FriendlyResources, new Color(0.21f, 0.67f, 0.07f, ColorAlphaNormal));
				spawnPointColors.Add(SpawnPointType.EnemyGeneral, new Color(1f, 0.01f, 0.04f, ColorAlphaNormal));
				spawnPointColors.Add(SpawnPointType.EnemyArcher, new Color(1f, 0.6f, 0f, ColorAlphaNormal));
				spawnPointColors.Add(SpawnPointType.EnemyAnimal, new Color(1f, 1f, 0f, ColorAlphaNormal));
				spawnPointColors.Add(SpawnPointType.EnemyResources, new Color(1f, 0.13f, 0.69f, ColorAlphaNormal));
				spawnPointColors.Add(SpawnPointType.PrisonerGeneral, new Color(0.53f, 0.13f, 1f, ColorAlphaNormal));
			}
			return spawnPointColors[type];
		}

		private GameObject GetObject()
		{
			if (cachedSpawnPointObjects.Count == 0)
			{
				return UnityEngine.Object.Instantiate(spawnPointPrefab);
			}
			GameObject gameObject = cachedSpawnPointObjects.FirstOrDefault();
			cachedSpawnPointObjects.Remove(gameObject);
			gameObject.SetActive(value: true);
			return gameObject;
		}

		private Vec3Int GetMouseGridPosition(Vector3 screenPos)
		{
			if (!MonoSingleton<CameraManager>.IsInstantiated() || MonoSingleton<CameraManager>.Instance.GameplayCamera == null)
			{
				return Vec3Int.down;
			}
			ray = MonoSingleton<CameraManager>.Instance.GameplayCamera.ScreenPointToRay(screenPos);
			if (!Physics.Raycast(ray, out hit, float.PositiveInfinity, raycastMask))
			{
				return Vec3Int.down;
			}
			hitSide = CalculateSide(hit);
			Vec3Int a = hit.point.SnapToGrid(0.01f).ToGridVec3Int();
			if (hitSide == ObjectSide.Left)
			{
				return a + new Vec3Int(-1, 0, 0);
			}
			if (hitSide == ObjectSide.Right)
			{
				return a;
			}
			if (hitSide == ObjectSide.Front)
			{
				return a;
			}
			if (hitSide == ObjectSide.Back)
			{
				return a + ILSpyHelper_AsRefReadOnly(new Vector3(0f, 0f, -1f));
			}
			_ = hitSide;
			_ = 2;
			return a;
			static ref readonly T ILSpyHelper_AsRefReadOnly<T>(in T temp)
			{
				//ILSpy generated this function to help ensure overload resolution can pick the overload using 'in'
				return ref temp;
			}
		}

		private ObjectSide CalculateSide(RaycastHit hit)
		{
			float num = Vector3.Dot(hit.normal, hit.transform.forward);
			if (num < -0.99f)
			{
				return ObjectSide.Back;
			}
			if (num > 0.99f)
			{
				return ObjectSide.Front;
			}
			float num2 = Vector3.Dot(hit.normal, hit.transform.right);
			if (num2 < -0.99f)
			{
				return ObjectSide.Left;
			}
			if (num2 > 0.99f)
			{
				return ObjectSide.Right;
			}
			if (Vector3.Dot(hit.normal, hit.transform.up) > 0.99f)
			{
				return ObjectSide.Top;
			}
			return ObjectSide.Bottom;
		}
	}
}
