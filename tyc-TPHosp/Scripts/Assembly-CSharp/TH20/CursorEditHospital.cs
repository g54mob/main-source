using System;
using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	public class CursorEditHospital : CursorMode
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public GameObject TilePreviewPrefab;

			public GameObject DragFloorTilePrefab;

			public Material DragAddMaterialValid;

			public Material DragAddMaterialInvalid;

			public SharedInstance<RoomDefinition> DragRoomDefinition;

			public SharedInstance<RoomWallDefinition> DragAddWallDefinition;
		}

		private readonly HUD _hud;

		private readonly Level _level;

		private readonly Config _config;

		private readonly WorldState _worldState;

		private readonly Dictionary<HospitalPlot, GameObject> _tileMapPreview = new Dictionary<HospitalPlot, GameObject>();

		private HospitalPlot _hospitalPlot;

		public static HospitalPlotLayer HospitalPlotLayer;

		private bool _tileMapVisible;

		public CursorEditHospital(CursorManager cursorManager, Level level, Config config)
			: base(cursorManager)
		{
			_hud = level.HUD;
			_level = level;
			_config = config;
			_worldState = level.WorldState;
			_level.GameTime.IsPausedByMenu = true;
			_level.HospitalFailState.SetEnabled(enabled: false);
			HospitalPlot.DisableMerging = true;
			foreach (HospitalPlot hospitalPlot in _worldState.HospitalPlots)
			{
				hospitalPlot.BuyAndBuildImmediately();
				hospitalPlot.Close();
				CreateTilemapPreview(hospitalPlot);
				hospitalPlot.Definition.RemoveDuplicateItems();
			}
			_worldState.DestroyAllRooms();
			OnSelectHospitalPlot(_worldState.HospitalPlots[0]);
			HospitalEditEvents hospitalEditEvents = _level.HospitalEditEvents;
			hospitalEditEvents.OnBeginBuilding = (Action)Delegate.Combine(hospitalEditEvents.OnBeginBuilding, new Action(OnBeginBuilding));
			HospitalEditEvents hospitalEditEvents2 = _level.HospitalEditEvents;
			hospitalEditEvents2.OnBeginMovePlot = (Action)Delegate.Combine(hospitalEditEvents2.OnBeginMovePlot, new Action(OnBeginMovePlot));
			HospitalEditEvents hospitalEditEvents3 = _level.HospitalEditEvents;
			hospitalEditEvents3.OnBeginItemPlacement = (Action)Delegate.Combine(hospitalEditEvents3.OnBeginItemPlacement, new Action(OnBeginItemPlacement));
			HospitalEditEvents hospitalEditEvents4 = _level.HospitalEditEvents;
			hospitalEditEvents4.OnTileMapPreviewToggle = (Action)Delegate.Combine(hospitalEditEvents4.OnTileMapPreviewToggle, new Action(OnTileMapPreviewToggle));
			HospitalEditEvents hospitalEditEvents5 = _level.HospitalEditEvents;
			hospitalEditEvents5.OnSelectHospitalPlot = (Action<HospitalPlot>)Delegate.Combine(hospitalEditEvents5.OnSelectHospitalPlot, new Action<HospitalPlot>(OnSelectHospitalPlot));
			HospitalEditEvents hospitalEditEvents6 = _level.HospitalEditEvents;
			hospitalEditEvents6.OnSelectHospitalPlotLayer = (Action<HospitalPlotLayer>)Delegate.Combine(hospitalEditEvents6.OnSelectHospitalPlotLayer, new Action<HospitalPlotLayer>(OnSelectHospitalPlotLayer));
			HospitalEditEvents hospitalEditEvents7 = _level.HospitalEditEvents;
			hospitalEditEvents7.OnSetHospitalPlotState = (Action<HospitalPlot, bool>)Delegate.Combine(hospitalEditEvents7.OnSetHospitalPlotState, new Action<HospitalPlot, bool>(OnSetHospitalPlotState));
			HospitalEditEvents hospitalEditEvents8 = _level.HospitalEditEvents;
			hospitalEditEvents8.OnSetHospitalPlotVisible = (Action<HospitalPlot, bool>)Delegate.Combine(hospitalEditEvents8.OnSetHospitalPlotVisible, new Action<HospitalPlot, bool>(OnSetHospitalPlotVisible));
			HospitalEditEvents hospitalEditEvents9 = _level.HospitalEditEvents;
			hospitalEditEvents9.OnSetHospitalPlotLayerVisible = (Action<HospitalPlot, HospitalPlotLayer, bool>)Delegate.Combine(hospitalEditEvents9.OnSetHospitalPlotLayerVisible, new Action<HospitalPlot, HospitalPlotLayer, bool>(OnSetHospitalPlotLayerVisible));
			HospitalEditEvents hospitalEditEvents10 = _level.HospitalEditEvents;
			hospitalEditEvents10.OnOffsetLandsacpeItems = (Action<int, int>)Delegate.Combine(hospitalEditEvents10.OnOffsetLandsacpeItems, new Action<int, int>(OnOffsetLandsacpeItems));
			HospitalEditEvents hospitalEditEvents11 = _level.HospitalEditEvents;
			hospitalEditEvents11.OnNukeLandscapeItems = (Action<string>)Delegate.Combine(hospitalEditEvents11.OnNukeLandscapeItems, new Action<string>(OnNukeLandscapeItems));
		}

		private void CreateTilemapPreview(HospitalPlot hospitalPlot)
		{
			HospitalMap hospitalMap = hospitalPlot.HospitalMap;
			if (hospitalMap != null)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(_config.TilePreviewPrefab);
				gameObject.SetActive(value: false);
				gameObject.transform.position = new Vector3(-1f, 0.1f, -1f);
				gameObject.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
				gameObject.transform.localScale = new Vector3((float)hospitalMap.Width / 5f, 1f, (float)hospitalMap.Height / 5f);
				gameObject.GetComponent<MeshRenderer>().material.mainTexture = hospitalPlot.Definition.FloorImage;
				_tileMapPreview.Add(hospitalPlot, gameObject);
			}
		}

		public override void Destroy()
		{
			_level.GameTime.IsPausedByMenu = false;
			HospitalPlot.DisableMerging = false;
			foreach (HospitalMap hospitalMap in _worldState.HospitalMaps)
			{
				hospitalMap.Room.Open();
			}
			_cursorManager.PopMode<CursorEditHospitalItem>();
			_cursorManager.PopMode<CursorEditHospitalBuild>();
			_cursorManager.SetCursorIcon(CursorIcon.Default);
			_cursorManager.SetCursorModel(CursorModel.Default);
			foreach (KeyValuePair<HospitalPlot, GameObject> item in _tileMapPreview)
			{
				UnityEngine.Object.Destroy(item.Value);
			}
			HospitalEditEvents hospitalEditEvents = _level.HospitalEditEvents;
			hospitalEditEvents.OnBeginBuilding = (Action)Delegate.Remove(hospitalEditEvents.OnBeginBuilding, new Action(OnBeginBuilding));
			HospitalEditEvents hospitalEditEvents2 = _level.HospitalEditEvents;
			hospitalEditEvents2.OnBeginMovePlot = (Action)Delegate.Remove(hospitalEditEvents2.OnBeginMovePlot, new Action(OnBeginMovePlot));
			HospitalEditEvents hospitalEditEvents3 = _level.HospitalEditEvents;
			hospitalEditEvents3.OnBeginItemPlacement = (Action)Delegate.Remove(hospitalEditEvents3.OnBeginItemPlacement, new Action(OnBeginItemPlacement));
			HospitalEditEvents hospitalEditEvents4 = _level.HospitalEditEvents;
			hospitalEditEvents4.OnTileMapPreviewToggle = (Action)Delegate.Remove(hospitalEditEvents4.OnTileMapPreviewToggle, new Action(OnTileMapPreviewToggle));
			HospitalEditEvents hospitalEditEvents5 = _level.HospitalEditEvents;
			hospitalEditEvents5.OnSelectHospitalPlot = (Action<HospitalPlot>)Delegate.Remove(hospitalEditEvents5.OnSelectHospitalPlot, new Action<HospitalPlot>(OnSelectHospitalPlot));
			HospitalEditEvents hospitalEditEvents6 = _level.HospitalEditEvents;
			hospitalEditEvents6.OnSelectHospitalPlotLayer = (Action<HospitalPlotLayer>)Delegate.Remove(hospitalEditEvents6.OnSelectHospitalPlotLayer, new Action<HospitalPlotLayer>(OnSelectHospitalPlotLayer));
			HospitalEditEvents hospitalEditEvents7 = _level.HospitalEditEvents;
			hospitalEditEvents7.OnSetHospitalPlotState = (Action<HospitalPlot, bool>)Delegate.Remove(hospitalEditEvents7.OnSetHospitalPlotState, new Action<HospitalPlot, bool>(OnSetHospitalPlotState));
			HospitalEditEvents hospitalEditEvents8 = _level.HospitalEditEvents;
			hospitalEditEvents8.OnSetHospitalPlotVisible = (Action<HospitalPlot, bool>)Delegate.Remove(hospitalEditEvents8.OnSetHospitalPlotVisible, new Action<HospitalPlot, bool>(OnSetHospitalPlotVisible));
			HospitalEditEvents hospitalEditEvents9 = _level.HospitalEditEvents;
			hospitalEditEvents9.OnSetHospitalPlotLayerVisible = (Action<HospitalPlot, HospitalPlotLayer, bool>)Delegate.Remove(hospitalEditEvents9.OnSetHospitalPlotLayerVisible, new Action<HospitalPlot, HospitalPlotLayer, bool>(OnSetHospitalPlotLayerVisible));
			HospitalEditEvents hospitalEditEvents10 = _level.HospitalEditEvents;
			hospitalEditEvents10.OnOffsetLandsacpeItems = (Action<int, int>)Delegate.Remove(hospitalEditEvents10.OnOffsetLandsacpeItems, new Action<int, int>(OnOffsetLandsacpeItems));
			HospitalEditEvents hospitalEditEvents11 = _level.HospitalEditEvents;
			hospitalEditEvents11.OnNukeLandscapeItems = (Action<string>)Delegate.Remove(hospitalEditEvents11.OnNukeLandscapeItems, new Action<string>(OnNukeLandscapeItems));
			base.Destroy();
		}

		public override void OnBecomeActive()
		{
			_cursorManager.SetCursorVisible(visible: true);
			_cursorManager.SetCursorModel(CursorModel.Default);
		}

		private void StopEditModes()
		{
			_cursorManager.PopMode<CursorEditHospitalBuild>();
			_cursorManager.PopMode<CursorEditHospitalMovePlot>();
		}

		private void OnBeginBuilding()
		{
			if (_hospitalPlot != null)
			{
				if (_cursorManager.IsModeActive<CursorEditHospitalBuild>())
				{
					_cursorManager.PopMode<CursorEditHospitalBuild>();
					return;
				}
				_cursorManager.PopMode<CursorEditHospitalItem>();
				_cursorManager.PopMode<CursorEditHospitalMovePlot>();
				_cursorManager.PushMode(new CursorEditHospitalBuild(_cursorManager, _level, _hospitalPlot, _config));
			}
		}

		private void OnBeginMovePlot()
		{
			if (_hospitalPlot != null)
			{
				if (_cursorManager.IsModeActive<CursorEditHospitalMovePlot>())
				{
					_cursorManager.PopMode<CursorEditHospitalMovePlot>();
					return;
				}
				_cursorManager.PopMode<CursorEditHospitalItem>();
				_cursorManager.PopMode<CursorEditHospitalBuild>();
				_cursorManager.PushMode(new CursorEditHospitalMovePlot(_cursorManager, _level, _hospitalPlot));
			}
		}

		private void OnBeginItemPlacement()
		{
			if (_hospitalPlot != null)
			{
				if (_cursorManager.IsModeActive<CursorRoomItem>() || _cursorManager.IsModeActive<CursorEditHospitalItem>())
				{
					_cursorManager.PopMode<CursorEditHospitalItem>();
					return;
				}
				_cursorManager.PopMode<CursorEditHospitalBuild>();
				_cursorManager.PopMode<CursorEditHospitalMovePlot>();
				_cursorManager.PushMode(new CursorEditHospitalItem(_cursorManager, _level, _hospitalPlot, HospitalPlotLayer));
			}
		}

		private void OnTileMapPreviewToggle()
		{
			_tileMapVisible = !_tileMapVisible;
			foreach (KeyValuePair<HospitalPlot, GameObject> item in _tileMapPreview)
			{
				GameObjectUtils.SetActive(item.Value, _tileMapVisible && item.Key.IsVisible());
			}
		}

		private static void SetFloorImageAlpha(Texture2D texture, float alpha)
		{
			for (int i = 0; i < texture.height; i++)
			{
				for (int j = 0; j < texture.width; j++)
				{
					Color pixel = texture.GetPixel(j, i);
					if (pixel.r > 0f || pixel.g > 0f || pixel.b > 0f)
					{
						pixel.a = alpha;
					}
					else
					{
						pixel.a = 0f;
					}
					texture.SetPixel(j, i, pixel);
				}
			}
			texture.Apply();
		}

		private void OnSelectHospitalPlot(HospitalPlot hospitalPlot)
		{
			if (_hospitalPlot == hospitalPlot && _hospitalPlot.HospitalMap != null)
			{
				_level.CameraLogic.SetFocalPoint(_hospitalPlot.HospitalMap.FloorPlan.WorldBounds.Center.ToWorldPosition(), snap: false);
			}
			if (_hospitalPlot != hospitalPlot)
			{
				if (_hospitalPlot != null)
				{
					SetFloorImageAlpha(_hospitalPlot.Definition.FloorImage, 0.1f);
					_hospitalPlot.Close();
				}
				_hospitalPlot = hospitalPlot;
				_hospitalPlot.Open();
				SetFloorImageAlpha(_hospitalPlot.Definition.FloorImage, 0.5f);
			}
		}

		private void OnSelectHospitalPlotLayer(HospitalPlotLayer layer)
		{
			HospitalPlotLayer = layer;
		}

		private void RefreshLandscapeItemMenu()
		{
			LandscapeObjectsMenu landscapeObjectsMenu = _hud.FindMenu<LandscapeObjectsMenu>();
			if (landscapeObjectsMenu != null && _hospitalPlot.HospitalMap != null)
			{
				landscapeObjectsMenu.Setup(_hospitalPlot.HospitalMap.FloorPlan, _worldState, _level.BuildEvents);
			}
		}

		private void OnSetHospitalPlotVisible(HospitalPlot hospitalPlot, bool visible)
		{
			hospitalPlot.SetVisible(visible);
			_level.WorldState.CalculateLighting();
			GameObjectUtils.SetActive(_tileMapPreview[hospitalPlot].gameObject, visible && _tileMapVisible);
		}

		private void OnSetHospitalPlotLayerVisible(HospitalPlot hospitalPlot, HospitalPlotLayer layer, bool visible)
		{
			bool visible2 = hospitalPlot.IsVisible();
			hospitalPlot.SetLayerVisible(layer, visible);
			_level.WorldState.CalculateLighting();
			hospitalPlot.SetVisible(visible2);
			RefreshLandscapeItemMenu();
		}

		private void OnSetHospitalPlotState(HospitalPlot hospitalPlot, bool bought)
		{
			if (bought != hospitalPlot.Bought)
			{
				StopEditModes();
				bool visible = hospitalPlot.IsVisible();
				if (bought)
				{
					hospitalPlot.BuyAndBuildImmediately();
				}
				else
				{
					hospitalPlot.Sell();
				}
				hospitalPlot.SetVisible(visible);
				RefreshLandscapeItemMenu();
			}
		}

		private void OnOffsetLandsacpeItems(int x, int y)
		{
			if (_hospitalPlot == null)
			{
				return;
			}
			Vector3 vector = new Vector3((float)x * 2f, 0f, (float)y * 2f);
			foreach (HospitalPlotLayer value in Enum.GetValues(typeof(HospitalPlotLayer)))
			{
				List<HospitalPlotItem> items = _hospitalPlot.Definition.GetItems(value);
				if (items == null)
				{
					continue;
				}
				foreach (HospitalPlotItem item in items)
				{
					item.Position += vector;
				}
			}
			_hospitalPlot.Sell();
			_hospitalPlot.BuyAndBuildImmediately();
			SharedInstanceUtils.MarkAsDirty(_hospitalPlot.Definition);
		}

		private void OnNukeLandscapeItems(string tag)
		{
			if (_hospitalPlot == null)
			{
				return;
			}
			List<HospitalPlotItem> list = new List<HospitalPlotItem>();
			foreach (HospitalPlotLayer value in Enum.GetValues(typeof(HospitalPlotLayer)))
			{
				List<HospitalPlotItem> items = _hospitalPlot.Definition.GetItems(value);
				if (items == null)
				{
					continue;
				}
				foreach (HospitalPlotItem item in items)
				{
					if (item.Definition.Instance.DebugTag.Contains(tag, StringComparison.OrdinalIgnoreCase))
					{
						list.Add(item);
					}
				}
			}
			if (list.Count == 0)
			{
				return;
			}
			foreach (HospitalPlotItem item2 in list)
			{
				_hospitalPlot.Definition.GetItems(HospitalPlotLayer.Base).Remove(item2);
				_hospitalPlot.Definition.GetItems(HospitalPlotLayer.Built).Remove(item2);
				_hospitalPlot.Definition.GetItems(HospitalPlotLayer.Unbuilt).Remove(item2);
			}
			_hospitalPlot.Sell();
			_hospitalPlot.BuyAndBuildImmediately();
			SharedInstanceUtils.MarkAsDirty(_hospitalPlot.Definition);
		}
	}
}
