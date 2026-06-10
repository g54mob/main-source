using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Map;
using NSMedieval.Model;
using NSMedieval.Repository;
using UnityEngine;

namespace NSMedieval.RoomDetection
{
	public class RoomViewManager : MonoSingleton<RoomViewManager>
	{
		[SerializeField]
		private string roomViewPrefabName = "RoomViewPrefab";

		[SerializeField]
		private Material roomDetectionMaterial;

		private readonly Dictionary<Room, RoomView> viewsByRoom = new Dictionary<Room, RoomView>();

		private readonly List<RoomView> unusedRoomViews = new List<RoomView>();

		private readonly Dictionary<RoomType, Material> materialByRoomType = new Dictionary<RoomType, Material>();

		private GameObject roomViewPrefab;

		private bool isShowingRooms;

		public Action<bool> RoomOverlayToggleEvent;

		private GameObject roomViewsHolder;

		public bool ShowRoomCreatedText { get; private set; }

		private GameObject RoomViewPrefab
		{
			get
			{
				roomViewPrefab = ((roomViewPrefab == null) ? MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress(roomViewPrefabName) : roomViewPrefab);
				return roomViewPrefab;
			}
		}

		public bool IsShowingRooms
		{
			get
			{
				return isShowingRooms;
			}
			set
			{
				if (value != isShowingRooms)
				{
					isShowingRooms = value;
					RoomOverlayToggleEvent?.Invoke(value);
				}
			}
		}

		public Material GetMaterial(RoomType roomType)
		{
			if (roomType == null)
			{
				return roomDetectionMaterial;
			}
			if (!materialByRoomType.ContainsKey(roomType))
			{
				Material material = UnityEngine.Object.Instantiate(roomDetectionMaterial);
				material.SetColor("_StockpileColor", roomType.Color);
				materialByRoomType.Add(roomType, material);
			}
			return materialByRoomType[roomType];
		}

		public RoomView GetView(Room room)
		{
			if (!viewsByRoom.ContainsKey(room))
			{
				return null;
			}
			return viewsByRoom[room];
		}

		private void Start()
		{
			MonoSingleton<RoomDetectionController>.Instance.RoomAddedEvent += OnRoomAdded;
			MonoSingleton<RoomDetectionController>.Instance.RoomRemovedEvent += OnRoomRemoved;
			MonoSingleton<RoomDetectionController>.Instance.RoomTypeChangedEvent += OnRoomTypeChanged;
			MonoSingleton<World>.Instance.MapLoadedEvent += OnMapLoaded;
			MonoSingleton<SceneController>.Instance.SceneSetup += OnSceneSetup;
			isShowingRooms = GlobalSaveController.CurrentVillageData.HeatmapVisible == 3;
			RoomOverlayToggleEvent?.Invoke(isShowingRooms);
		}

		protected override void OnDestroy()
		{
			if (MonoSingleton<RoomDetectionController>.IsInstantiated())
			{
				MonoSingleton<RoomDetectionController>.Instance.RoomAddedEvent -= OnRoomAdded;
				MonoSingleton<RoomDetectionController>.Instance.RoomRemovedEvent -= OnRoomRemoved;
				MonoSingleton<RoomDetectionController>.Instance.RoomTypeChangedEvent -= OnRoomTypeChanged;
			}
			if (MonoSingleton<World>.IsInstantiated())
			{
				MonoSingleton<World>.Instance.MapLoadedEvent -= OnMapLoaded;
			}
			if (MonoSingleton<SceneController>.IsInstantiated())
			{
				MonoSingleton<SceneController>.Instance.SceneSetup -= OnSceneSetup;
			}
			foreach (Material value in materialByRoomType.Values)
			{
				UnityEngine.Object.Destroy(value);
			}
			RoomOverlayToggleEvent = null;
			materialByRoomType.Clear();
			base.OnDestroy();
		}

		private void OnSceneSetup()
		{
			MonoSingleton<TaskController>.Instance.WaitFor(1f).Then(delegate
			{
				ShowRoomCreatedText = true;
			});
		}

		private void OnMapLoaded(bool wasLoadedFromSave)
		{
			roomViewsHolder = new GameObject("RoomViews");
			int num = 20;
			if (unusedRoomViews.Count < num)
			{
				for (int i = 0; i < num - unusedRoomViews.Count; i++)
				{
					RoomView component = UnityEngine.Object.Instantiate(RoomViewPrefab).GetComponent<RoomView>();
					component.transform.parent = roomViewsHolder.transform;
					unusedRoomViews.Add(component);
					component.gameObject.SetActive(value: false);
				}
			}
		}

		private void OnRoomTypeChanged(Room room, RoomType previousType)
		{
			if (!viewsByRoom.ContainsKey(room))
			{
				bool isEnabled;
				FVLogInfoInterpolationHandler messageBuilder = new FVLogInfoInterpolationHandler(22, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\RoomDetection\\RoomViewManager.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Room ");
					messageBuilder.AppendFormatted(room);
					messageBuilder.AppendLiteral(" has no view yet.");
				}
				Log.Info(messageBuilder);
			}
			else
			{
				RoomView roomView = viewsByRoom[room];
				if (!(roomView == null))
				{
					roomView.RoomTypeChanged(previousType);
				}
			}
		}

		private void OnRoomAdded(Room room, RoomType previousType)
		{
			if (!viewsByRoom.ContainsKey(room))
			{
				RoomView roomView;
				if (unusedRoomViews.Any())
				{
					roomView = unusedRoomViews.First();
					unusedRoomViews.Remove(roomView);
				}
				else
				{
					roomView = UnityEngine.Object.Instantiate(RoomViewPrefab).GetComponent<RoomView>();
					roomView.transform.parent = roomViewsHolder.transform;
				}
				roomView.gameObject.SetActive(value: true);
				roomView.Init(room, previousType);
				viewsByRoom.Add(room, roomView);
			}
		}

		private void OnRoomRemoved(Room room)
		{
			if (viewsByRoom.ContainsKey(room))
			{
				RoomView roomView = viewsByRoom[room];
				unusedRoomViews.Insert(0, roomView);
				viewsByRoom.Remove(room);
				roomView.Deactivate();
			}
		}
	}
}
