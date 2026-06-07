using System;
using System.Collections.Generic;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using Assets.Scripts.Flight.MapView.Items;
using Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes;
using Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes.Interfaces;
using Assets.Scripts.Flight.MapView.Orbits.Chain.SoiEncounters;
using Assets.Scripts.Flight.MapView.Orbits.DrawModes;
using Assets.Scripts.Flight.MapView.Orbits.DrawModes.Interfaces.IDrawMode;
using Assets.Scripts.Flight.MapView.Orbits.Interfaces;
using Assets.Scripts.Flight.MapView.UI;
using Assets.Scripts.Flight.Sim;
using ModApi;
using ModApi.Flight.MapView;
using ModApi.Flight.Sim;
using ModApi.Ioc;
using ModApi.Math;
using ModApi.State.MapView;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using Vectrosity;

namespace Assets.Scripts.Flight.MapView.Orbits
{
	public class MapOrbitLine : MapItem, ICameraFocusable, IOrbitInteractionEventRecipient
	{
		public struct DebugInfoType
		{
			public struct GetPointsInfo
			{
				public bool EndOverride;

				public double MaxDist;

				public double MinDist;

				public double NuEnd;

				public double NuStart;

				public IOrbit Orbit;

				public double Resolution;

				public GetPointsInfo(IOrbit orbit, double res, double nuStart, double nuEnd, double minDist, double maxDist, bool endOverride)
				{
					Orbit = orbit;
					Resolution = res;
					NuStart = nuStart;
					NuEnd = nuEnd;
					MinDist = minDist;
					MaxDist = maxDist;
					EndOverride = endOverride;
				}
			}

			public GetPointsInfo PointsInfo;
		}

		public const int OrbitLineSegmentsDefault = 150;

		private Image _apoapsisIcon;

		private TextMeshProUGUI _apoDistanceText;

		private Image _ascendingNodeIcon;

		private CameraFocusableItemDestroyedHandler _cameraFocusableDestroyed;

		private ICurrentCameraTarget _cameraTarget;

		[SerializeField]
		private bool _debugEnabled;

		private Image _descendingNodeIcon;

		private DrawModeReferenceInfo _drawModeReferenceInfo;

		[SerializeField]
		private bool _forceUpdateOrbitLine;

		private int _indexOfPrecisePoint;

		private Image _invalidOrbitIcon;

		private bool _isSharedMaterial;

		private bool _isValidRendering = true;

		private IOrbitLineManager _lineManager;

		private Material _lineMaterial;

		private IManeuverNodeEventsProvider _maneuverNodeEventsProvider;

		private INavigationTargetProvider _navigationTargetProvider;

		private IMapOptions _options;

		private bool _orbitChanging;

		private Renderer _orbitLineRenderer;

		private IOrbitPointSet _orbitPointSet;

		private Image _periapsisIcon;

		private TextMeshProUGUI _periDistanceText;

		private Image _planetIntersectionIcon;

		private IPlayerCraftProvider _playerCraft;

		private List<Vector4d> _scaledLocalOrbitPointsCache;

		private bool _showApoapsis;

		private bool _showPeriapsis;

		private GameObject _sphereOfInfluence;

		private Image _targetAscendingNodeIcon;

		private Image _targetDescendingNodeIcon;

		private VectorLine _vectrocityLine;

		public bool ApoapsisOnVisibleOrbit
		{
			get
			{
				if (!base.OrbitInfo.OrbitNode.NodeExitsSoi)
				{
					return OrbitMath.TrueAnomalyBetween(Math.PI, base.OrbitInfo.ValidTrueAnomalyStart, base.OrbitInfo.ValidTrueAnomalyEnd, inclusive: true);
				}
				return false;
			}
		}

		public bool AscendingNodeOnVisibleOrbit => OrbitMath.TrueAnomalyBetween(base.OrbitInfo.OrbitNode.Orbit.TrueAnomalyOfAscendingNode, base.OrbitInfo.ValidTrueAnomalyStart, base.OrbitInfo.ValidTrueAnomalyEnd, inclusive: true);

		IPlanetNode ICameraFocusable.AssociatedPlanet => base.OrbitInfo.OrbitNode.Parent;

		public override ICameraFocusable AssociatedPlanetCameraFocusable => _playerCraft.PlayerCraft.AssociatedPlanetCameraFocusable;

		public bool DebugEnabled
		{
			get
			{
				return _debugEnabled;
			}
			set
			{
				_debugEnabled = value;
			}
		}

		public DebugInfoType DebugInfo { get; private set; }

		public bool DescendingNodeOnVisibleOrbit => OrbitMath.TrueAnomalyBetween(base.OrbitInfo.OrbitNode.Orbit.TrueAnomalyOfDescendingNode, base.OrbitInfo.ValidTrueAnomalyStart, base.OrbitInfo.ValidTrueAnomalyEnd, inclusive: true);

		public bool DrawFullOrbit { get; set; }

		bool ICameraFocusable.FocusByClick => false;

		public int Id { get; private set; }

		public double? InvalidTrueAnomaly { get; set; }

		public bool IsDrawing => _vectrocityLine.points3.Count > 0;

		public bool IsValidRendering
		{
			get
			{
				return _isValidRendering;
			}
			set
			{
				_isValidRendering = value;
				if (_isValidRendering)
				{
					_vectrocityLine.color = base.Color;
				}
				else
				{
					_vectrocityLine.color = Color.red;
				}
			}
		}

		ICameraFocusable ICameraFocusable.ItemToFocusOnWhenDeleted => base.ItemRegistry.GetPlanet(base.OrbitInfo.OrbitNode.Parent);

		public Material LineMaterial => _lineMaterial;

		public override Vector3 MapPosition
		{
			get
			{
				Vector3d solarPosition = ((base.OrbitInfo.OrbitNode.Parent == null) ? ((Vector3d)Vector3.zero) : base.DrawModeProvider.DrawMode.GetSolarPositionAtCurrent(base.OrbitInfo));
				return (Vector3)base.CoordinateConverter.ConvertSolarToMapView(solarPosition);
			}
		}

		float ICameraFocusable.MinZoomDistance => AssociatedPlanetCameraFocusable.MinZoomDistance;

		OrbitInteractionScript.OrbitInteractionDelegate IOrbitInteractionEventRecipient.OnHoverEnter => OnHoverEnter;

		OrbitInteractionScript.OrbitInteractionDelegate IOrbitInteractionEventRecipient.OnHoverExit => OnHoverExit;

		OrbitInteractionScript.OrbitInteractionDelegate IOrbitInteractionEventRecipient.OnHoverStay => OnHoverStay;

		public bool OrbitHoveredWithDelay { get; private set; }

		public int OrbitLineSegments => _vectrocityLine.points3.Count;

		IOrbitNode ICameraFocusable.OrbitNode => base.OrbitInfo.OrbitNode;

		public bool PeriapsisOnVisibleOrbit => OrbitMath.TrueAnomalyBetween(0.0, base.OrbitInfo.ValidTrueAnomalyStart, base.OrbitInfo.ValidTrueAnomalyEnd, inclusive: true);

		public bool PlanetIntersectionOnVisibleOrbit
		{
			get
			{
				if (base.OrbitInfo.PlanetIntersection != null)
				{
					return OrbitMath.TrueAnomalyBetween(base.OrbitInfo.PlanetIntersection.TrueAnomaly, base.OrbitInfo.ValidTrueAnomalyStart, base.OrbitInfo.ValidTrueAnomalyEndExcludingPlanetIntersection, inclusive: true);
				}
				return false;
			}
		}

		public int PointCount { get; private set; }

		Vector3 ICameraFocusable.Position => MapPosition;

		public bool ShowApoapsisIcon
		{
			get
			{
				return _showApoapsis;
			}
			private set
			{
				_showApoapsis = value;
			}
		}

		public bool ShowApoapsisInfoText { get; private set; }

		public bool ShowApsidesInfoText { get; private set; }

		public bool ShowAscendingDescendingNodeIcons { get; private set; }

		public bool ShowPeriapsisIcon
		{
			get
			{
				return _showPeriapsis;
			}
			private set
			{
				_showPeriapsis = value;
			}
		}

		public bool ShowPeriapsisInfoText { get; private set; }

		public bool ShowPlanetIntersectionIcon { get; private set; }

		public bool ShowTargetAscendingDescNodeIcons { get; private set; }

		protected MapItemData Data { get; private set; }

		event CameraFocusableItemDestroyedHandler ICameraFocusable.Destroyed
		{
			add
			{
				_cameraFocusableDestroyed = (CameraFocusableItemDestroyedHandler)Delegate.Combine(_cameraFocusableDestroyed, value);
			}
			remove
			{
				_cameraFocusableDestroyed = (CameraFocusableItemDestroyedHandler)Delegate.Remove(_cameraFocusableDestroyed, value);
			}
		}

		public static MapOrbitLine Create(IIocContainer ioc, IMapViewContext mapViewContext, IOrbitNode node, MapItemData data, Color color, string name, Camera mapCamera, Material lineMaterial, bool isSharedMaterial)
		{
			return Create<MapOrbitLine>(ioc, mapViewContext, node, data, color, name, mapCamera, lineMaterial, isSharedMaterial);
		}

		public static void RepositionOrbitLine(List<Vector4d> scaledOrbitPointsCache, ref int indexOfPrecisePoint, IDrawModeProvider drawModeProvider, MapOrbitInfo orbitInfo, VectorLine orbitLine, IMapViewCoordinateConverter coordinateConverter)
		{
			if (Debug.isDebugBuild && !drawModeProvider.DrawMode.UpdateReferencePerPoint)
			{
				MapUtils.SamePlanet(orbitInfo.OrbitNode.Parent, drawModeProvider.DrawMode.GetReferenceNode(orbitInfo));
			}
			int count = orbitLine.points3.Count;
			List<Vector3> points = orbitLine.points3;
			Vector3d vector3d = drawModeProvider.DrawMode.GetReferenceSolarPosition(orbitInfo) * coordinateConverter.MapScale;
			Vector3d vector3d2 = coordinateConverter.ConvertAbsoluteToWorldMapPosition(Vector3d.zero);
			Vector3d vector3d3 = vector3d + vector3d2;
			double lastNu = 0.0;
			Vector3 value = default(Vector3);
			for (int i = 0; i < count; i++)
			{
				Vector4d position = GetPosition(i, scaledOrbitPointsCache, orbitInfo, coordinateConverter, ref indexOfPrecisePoint, ref lastNu);
				value.x = (float)(position.x + vector3d3.x);
				value.y = (float)(position.y + vector3d3.y);
				value.z = (float)(position.z + vector3d3.z);
				points[i] = value;
			}
			if (count > 0)
			{
				_ = orbitLine.isAutoDrawing;
			}
		}

		public static void UpdateLine(MapOrbitLine orbitLine, IDrawModeProvider drawModeProvider, ref DrawModeReferenceInfo drawModeReferenceInfo, ref IOrbitPointSet orbitPointSet, IMapViewCoordinateConverter coordinateConverter, IObjectContainerProvider containerProvider, ref List<Vector4d> scaledPointsCache, ref Renderer lineRenderer)
		{
			MapOrbitInfo orbitInfo = orbitLine.OrbitInfo;
			IOrbitNode orbitNode = orbitInfo.OrbitNode;
			IOrbit orbit = orbitNode.Orbit;
			IDrawMode drawMode = drawModeProvider.DrawMode;
			VectorLine vectrocityLine = orbitLine._vectrocityLine;
			UpdateGetPointsParams(drawModeProvider, orbitInfo, orbitLine.DrawFullOrbit, out var endNu);
			_ = orbitInfo.ValidTrueAnomalyStart;
			orbitPointSet = OrbitMath.GetPoints(orbit, orbitInfo.ValidTrueAnomalyStart, endNu, orbitNode.Parent.PlanetData.ImpactRadius, orbitLine.PointCount, orbitPointSet);
			if (orbitPointSet.Count > 0)
			{
				IOrbitPoint point = orbitPointSet.GetPoint(0);
				IOrbitPoint orbitPoint = orbitPointSet.Last();
				if (orbitPointSet.Closed)
				{
					orbitPointSet.AddPoint(point);
				}
				orbitInfo.SetPlanetIntersection(orbitPointSet.IntersectsPlanet ? orbitPointSet.Last() : null);
				int num = ((drawMode.UpdateReferencePerPoint || !MapUtils.SamePlanet(orbitInfo.OrbitNode.Parent, drawMode.GetReferenceNode(orbitInfo))) ? (orbitPointSet.Count - 5) : orbitPointSet.Count);
				vectrocityLine.points3.Clear();
				vectrocityLine.Uv2.Clear();
				if (scaledPointsCache == null)
				{
					scaledPointsCache = new List<Vector4d>();
				}
				if (!drawMode.UpdateReferencePerPoint)
				{
					drawMode.UpdateReferenceNoderPerOrbit(ref drawModeReferenceInfo, orbitInfo);
					scaledPointsCache.Clear();
				}
				MapOrbitInfo mapOrbitInfo = orbitInfo.ChainNode?.ListNode.List.First.Value.OrbitInfo;
				MapOrbitInfo mapOrbitInfo2 = orbitInfo.ChainNode?.ListNode.List.Last.Value.OrbitInfo;
				double num2 = mapOrbitInfo?.StartTime ?? point.Time;
				double timeSpan = (mapOrbitInfo2?.EndTime ?? orbitPoint.Time) - num2;
				bool flag = orbitInfo.ChainNode != null;
				IOrbit orbit2 = orbitLine.OrbitInfo.OrbitNode.Orbit;
				double nuStart = 0.0;
				orbitLine._indexOfPrecisePoint = -1;
				for (int i = 0; i < num; i++)
				{
					IOrbitPoint point2 = orbitPointSet.GetPoint(i);
					if (orbitLine._indexOfPrecisePoint < 0 && OrbitMath.TrueAnomalyBetween(orbit2.TrueAnomaly, nuStart, point2.TrueAnomaly, inclusive: true))
					{
						drawModeReferenceInfo = AddOrbitLinePoint(drawModeProvider, drawModeReferenceInfo, coordinateConverter, scaledPointsCache, orbitInfo, drawMode, vectrocityLine, num2, timeSpan, flag, OrbitMath.GetPointAtTrueAnomaly(orbit2, orbit2.TrueAnomaly), num);
						orbitLine._indexOfPrecisePoint = i;
					}
					drawModeReferenceInfo = AddOrbitLinePoint(drawModeProvider, drawModeReferenceInfo, coordinateConverter, scaledPointsCache, orbitInfo, drawMode, vectrocityLine, num2, timeSpan, flag, point2, num);
					nuStart = point2.TrueAnomaly;
				}
				if (flag)
				{
					vectrocityLine.Uv2.RemoveAt(vectrocityLine.Uv2.Count - 1);
					vectrocityLine.SetUvs(vectrocityLine.Uv2);
				}
				if (lineRenderer == null)
				{
					vectrocityLine.Draw3DAuto();
					lineRenderer = vectrocityLine.rectTransform.GetComponent<Renderer>();
					lineRenderer.shadowCastingMode = ShadowCastingMode.Off;
					lineRenderer.receiveShadows = false;
					if (orbitLine._lineMaterial != null)
					{
						lineRenderer.sharedMaterial = orbitLine._lineMaterial;
					}
					orbitLine.OnLineCreated(vectrocityLine);
				}
				vectrocityLine.rectTransform.SetParent(orbitLine.transform);
				_ = vectrocityLine.isAutoDrawing;
			}
			else
			{
				vectrocityLine.points3.Clear();
				vectrocityLine.Uv2.Clear();
			}
		}

		public override void Destroy()
		{
			base.Destroy();
			_cameraFocusableDestroyed?.Invoke(this);
			_cameraFocusableDestroyed = null;
		}

		public void ForceUpdate()
		{
			_forceUpdateOrbitLine = true;
		}

		public void GetAscendingDescendingNodesToTarget(out double? ascendingNodeToTarget, out double? descendingNodeToTarget)
		{
			ascendingNodeToTarget = null;
			descendingNodeToTarget = null;
			ITargetableItem targetableItem = _navigationTargetProvider?.NavigationTarget;
			if (targetableItem != null)
			{
				IOrbit orbit = base.OrbitInfo.OrbitNode.Orbit;
				IOrbit orbit2 = targetableItem.OrbitInfo.OrbitNode.Orbit;
				LinkedListNode<IChainableOrbit> obj = base.OrbitInfo.ChainNode?.ListNode?.Next;
				double trueAnomaly = orbit.TrueAnomaly;
				double trueAnomalyEnd = obj?.Value.TrueAnomalyOnPreviousOrbit ?? orbit.TrueAnomaly;
				OrbitAnalyser.GetAscendingDescendingNodes(orbit, orbit2, trueAnomaly, trueAnomalyEnd, out ascendingNodeToTarget, out descendingNodeToTarget);
			}
		}

		public override void OnAfterCameraPositioned()
		{
			base.OnAfterCameraPositioned();
			OrbitUiVerbosity orbitUiVerbosity = _options.OrbitUiVerbosity;
			bool canShowGlobal = Data.ShowOrbitLine && orbitUiVerbosity != OrbitUiVerbosity.Minimal && !base.OrbitInfo.InContactWithPlanet;
			UpdateIcons(canShowGlobal);
			UpdateText(canShowGlobal);
		}

		public override void OnBeforeCameraPositioned()
		{
			base.OnBeforeCameraPositioned();
			if (_vectrocityLine != null)
			{
				if (_forceUpdateOrbitLine || base.DrawModeProvider.DrawMode.UpdateReferencePerPoint || !MapUtils.SamePlanet(base.OrbitInfo.OrbitNode.Parent, base.DrawModeProvider.DrawMode.GetReferenceNode(base.OrbitInfo)))
				{
					_forceUpdateOrbitLine = false;
					UpdateLine();
				}
				else
				{
					RepositionOrbitLine();
				}
			}
		}

		public void OnLineResolutionQualityChanged()
		{
			PointCount = CalculatePointsCount();
			UpdateLine();
		}

		public virtual void OnNewNextNode()
		{
		}

		public void RegisterIcon(Image icon)
		{
		}

		public void RemoveIcon(Image icon)
		{
			throw new NotImplementedException();
		}

		public void RepositionOrbitLine()
		{
			if (_scaledLocalOrbitPointsCache == null)
			{
				UpdateLine();
			}
			else
			{
				RepositionOrbitLine(_scaledLocalOrbitPointsCache, ref _indexOfPrecisePoint, base.DrawModeProvider, base.OrbitInfo, _vectrocityLine, base.CoordinateConverter);
			}
		}

		public void SetDrawingAllowed(bool allowed)
		{
			if (allowed)
			{
				if (Data.ShowOrbitLine)
				{
					SetIsDrawing(drawing: true);
				}
			}
			else
			{
				SetIsDrawing(drawing: false);
			}
		}

		public void SetManeuverNodeEventsProvider(IManeuverNodeEventsProvider maneuverNodeEventsProvider)
		{
			_maneuverNodeEventsProvider = maneuverNodeEventsProvider;
			_maneuverNodeEventsProvider.ManeuverNodeAdjustmentChangingEvent += OnManeuverNodeAdjustmentChanging;
			_maneuverNodeEventsProvider.ManeuverNodeAdjustmentChangeEndEvent += OnManeuverNodeAdjustmentChangeEnd;
			_maneuverNodeEventsProvider.ManeuverNodeAdjustmentChangeBeginEvent += OnManeuverNodeAdjustmentChangeBegin;
		}

		public void UpdateLine()
		{
			UpdateLine(forceUpdate: false);
		}

		internal void Disable()
		{
			base.gameObject.SetActive(value: false);
		}

		internal void Enable()
		{
			base.gameObject.SetActive(value: true);
		}

		internal void SetColor(Color color)
		{
			base.Color = color;
			if (IsValidRendering)
			{
				_vectrocityLine.color = color;
			}
		}

		protected static T Create<T>(IIocContainer ioc, IMapViewContext mapViewContext, IOrbitNode node, MapItemData data, Color color, string name, Camera mapCamera, Material lineMaterial, bool isSharedMaterial) where T : MapOrbitLine
		{
			IObjectContainerProvider objectContainerProvider = ioc.Resolve<IObjectContainerProvider>(mapViewContext);
			T val = MapItem.Create<T>(ioc, mapViewContext, node, name, objectContainerProvider.OrbitCanvases, mapCamera, objectContainerProvider.OrbitContainer, null);
			val.name = $"{name}({val.GetInstanceID()})";
			val.Initialize(data, color, lineMaterial, isSharedMaterial);
			return val;
		}

		protected virtual void Initialize(MapItemData data, Color color, Material lineMaterial, bool isSharedMaterial)
		{
			Data = data;
			Id = base.gameObject.GetInstanceID();
			base.OrbitInfo.SetOrbitLine(this);
			IIocContainer ioc = base.Ioc;
			IMapViewContext mapViewContext = base.MapViewContext;
			_lineManager = ioc.Resolve<IOrbitLineManager>(mapViewContext);
			_options = ioc.Resolve<IMapOptions>();
			_cameraTarget = ioc.Resolve<ICurrentCameraTarget>(mapViewContext);
			_navigationTargetProvider = ioc.Resolve<INavigationTargetProvider>(mapViewContext);
			_playerCraft = ioc.Resolve<IPlayerCraftProvider>(mapViewContext);
			IMapView mapView = ioc.Resolve<IMapView>(mapViewContext);
			_isSharedMaterial = isSharedMaterial;
			_lineMaterial = lineMaterial;
			base.Color = color;
			base.Selectable = true;
			Vector2 value = new Vector2(0.5f, 0f);
			_apoapsisIcon = UiUtils.CreateUiIcon(base.InfoCanvas, "Apoapsis", clickable: false, value);
			_periapsisIcon = UiUtils.CreateUiIcon(base.InfoCanvas, "Periapsis", clickable: false, value);
			_ascendingNodeIcon = UiUtils.CreateUiIcon(base.InfoCanvas, "AscendingNode", clickable: false, value);
			_descendingNodeIcon = UiUtils.CreateUiIcon(base.InfoCanvas, "DescendingNode", clickable: false, value);
			_targetAscendingNodeIcon = UiUtils.CreateUiIcon(base.InfoCanvas, "AscendingNodeOfTarget", clickable: false, value);
			_targetDescendingNodeIcon = UiUtils.CreateUiIcon(base.InfoCanvas, "DescendingNodeOfTarget", clickable: false, value);
			_planetIntersectionIcon = UiUtils.CreateUiIcon(base.InfoCanvas, "PlanetIntersection", clickable: false);
			_apoDistanceText = UiUtils.CreateUiText(base.InfoCanvas.transform, "ApoDist", clickable: false, TextAlignmentOptions.Bottom);
			_periDistanceText = UiUtils.CreateUiText(base.InfoCanvas.transform, "PeriDist", clickable: false, TextAlignmentOptions.Bottom);
			if (Game.InPlanetStudioScene)
			{
				_invalidOrbitIcon = UiUtils.CreateUiIcon(base.InfoCanvas, "PlanetIconAlternative", clickable: false);
				_invalidOrbitIcon.color = new Color(0.8f, 0.1f, 0.1f);
				_sphereOfInfluence = MapUtils.CreateSoiSphere(base.OrbitInfo.OrbitNode as PlanetNode, base.ItemName, base.gameObject.layer, base.transform, base.CoordinateConverter);
			}
			_orbitPointSet = new OrbitPointSet();
			_vectrocityLine = CreateLine(base.transform, base.Color, base.name, base.gameObject.layer);
			bool isDrawing = mapView.Visible && Data.ShowOrbitLine;
			SetIsDrawing(isDrawing);
			UpdateEventSubscriptions(subscribe: true);
			PointCount = CalculatePointsCount();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			_cameraFocusableDestroyed?.Invoke(this);
			_cameraFocusableDestroyed = null;
			if (_vectrocityLine != null)
			{
				VectorLine.Destroy(ref _vectrocityLine);
			}
			UpdateEventSubscriptions(subscribe: false);
			if (_lineMaterial != null)
			{
				if (!_isSharedMaterial)
				{
					UnityEngine.Object.Destroy(_lineMaterial);
				}
				_lineMaterial = null;
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			SetIsDrawing(drawing: false);
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			if (Data != null && Data.ShowOrbitLine)
			{
				SetIsDrawing(drawing: true);
			}
		}

		protected virtual void OnLineCreated(VectorLine vectrocityLine)
		{
		}

		private static DrawModeReferenceInfo AddOrbitLinePoint(IDrawModeProvider drawModeProvider, DrawModeReferenceInfo drawModeReferenceInfo, IMapViewCoordinateConverter coordinateConverter, List<Vector4d> scaledPointsCache, MapOrbitInfo orbitInfo, IDrawMode drawmode, VectorLine vectrocityLine, double startTime, double timeSpan, bool animatedShader, IOrbitPoint point, int pointCount)
		{
			if (drawmode.UpdateReferencePerPoint)
			{
				drawmode.UpdateReferenceNodeFromPoint(ref drawModeReferenceInfo, orbitInfo, point);
			}
			else
			{
				scaledPointsCache.Add(GetScaledCachePoint(point, coordinateConverter));
			}
			Vector3d solarPosition = drawModeProvider.DrawMode.GetSolarPosition(drawModeReferenceInfo, orbitInfo, point);
			vectrocityLine.points3.Add((Vector3)coordinateConverter.ConvertSolarToMapView(solarPosition));
			if (animatedShader)
			{
				double num = (point.Time - startTime) / timeSpan;
				float y = (float)point.EccentricAnomaly * (float)(pointCount - 1) / (MathF.PI * 2f);
				vectrocityLine.Uv2.Add(new Vector2((float)num, y));
			}
			return drawModeReferenceInfo;
		}

		private static int CalculatePointsCount()
		{
			int num = (int)Mathf.Lerp(1f, 33f, Game.Instance.Settings.Quality.Map.MapLineResolution.Value);
			return 12 * num;
		}

		private static VectorLine CreateLine(Transform parent, Color color, string name, int layer)
		{
			List<Vector3> points = new List<Vector3>(150);
			VectorLine vectorLine = new VectorLine($"OrbitLine({name})", points, 2f, LineType.Continuous);
			vectorLine.color = color;
			vectorLine.layer = layer;
			vectorLine.rectTransform.SetParent(parent);
			return vectorLine;
		}

		private static IPlanetNode DuplicateParentSimNodes(IOrbitNode top)
		{
			IPlanetNode parent = top.Parent;
			if (parent is SoiEncounterPlanetSimNode)
			{
				return new SoiEncounterPlanetSimNode(parent.PlanetData, new Orbit(parent.Orbit), DuplicateParentSimNodes(parent), (parent as SoiEncounterPlanetSimNode).ReferencePlanet);
			}
			return parent;
		}

		private static Vector4d GetPosition(int index, List<Vector4d> scaledOrbitPointsCache, MapOrbitInfo orbitInfo, IMapViewCoordinateConverter coordinateConverter, ref int indexOfPrecisePoint, ref double lastNu)
		{
			Vector4d vector4d = scaledOrbitPointsCache[index];
			double w = vector4d.w;
			if (indexOfPrecisePoint >= 0 && index == indexOfPrecisePoint)
			{
				vector4d = GetScaledCachePoint(OrbitMath.GetPointAtTrueAnomaly(orbitInfo.OrbitNode.Orbit, orbitInfo.OrbitNode.Orbit.TrueAnomaly), coordinateConverter);
				w = vector4d.w;
				int num = index + 1;
				if (num >= scaledOrbitPointsCache.Count)
				{
					num = 0;
				}
				Vector4d vector4d2 = scaledOrbitPointsCache[num];
				double w2 = vector4d2.w;
				if (!OrbitMath.TrueAnomalyBetween(w, lastNu, w2, inclusive: true) || (lastNu == w2 && lastNu < w))
				{
					scaledOrbitPointsCache.RemoveAt(index);
					indexOfPrecisePoint = index + 1;
					if (indexOfPrecisePoint >= scaledOrbitPointsCache.Count - 1)
					{
						indexOfPrecisePoint = 1;
					}
					scaledOrbitPointsCache.Insert(indexOfPrecisePoint, vector4d);
					vector4d = vector4d2;
					w = vector4d.w;
				}
			}
			lastNu = w;
			return vector4d;
		}

		private static Vector4d GetScaledCachePoint(IOrbitPoint point, IMapViewCoordinateConverter coordinateConverter)
		{
			Vector3d vector3d = point.Position * coordinateConverter.MapScale;
			return new Vector4d(vector3d.x, vector3d.y, vector3d.z, point.TrueAnomaly);
		}

		private static bool ShouldUiComponentBeEnabled(double trueAnomalyOfIcon, double startNu, double endNu)
		{
			if (!Utilities.CompareDoubles(trueAnomalyOfIcon, startNu, 0.0010000000474974513) && !Utilities.CompareDoubles(trueAnomalyOfIcon, endNu, 0.0010000000474974513))
			{
				return OrbitMath.TrueAnomalyBetween(trueAnomalyOfIcon, startNu, endNu, inclusive: true);
			}
			return true;
		}

		private static void UpdateGetPointsParams(IDrawModeProvider drawmodeProvider, MapOrbitInfo orbitInfo, bool fullOrbit, out double endNu)
		{
			IPlanetNode referenceNode = drawmodeProvider.DrawMode.GetReferenceNode(orbitInfo);
			double? lineEndNu = drawmodeProvider.DrawMode.GetLineEndNu(referenceNode, orbitInfo);
			if (lineEndNu.HasValue)
			{
				endNu = lineEndNu.Value;
			}
			else if (fullOrbit)
			{
				IOrbitNode orbitNode = orbitInfo.OrbitNode;
				IOrbit orbit = orbitNode.Orbit;
				double sphereOfInfluenceExitDistance = orbitNode.Parent.SphereOfInfluenceExitDistance;
				if (orbit.ApoapsisDistanceEffective > sphereOfInfluenceExitDistance)
				{
					endNu = OrbitMath.GetPointAtDistance(orbit, orbitNode.Parent.SphereOfInfluenceExitDistance, ascent: true).TrueAnomaly;
				}
				else
				{
					endNu = orbitInfo.ValidTrueAnomalyStart;
				}
			}
			else
			{
				endNu = orbitInfo.ValidTrueAnomalyEndExcludingPlanetIntersection;
			}
		}

		private void OnDataShowOrbitLineChanged(bool shouldDraw)
		{
			SetIsDrawing(shouldDraw);
		}

		private void OnHoverEnter(OrbitInteractionScript source, OrbitInteractionScript.OrbitCursorInfo pointInfo)
		{
		}

		private void OnHoverExit(OrbitInteractionScript source, OrbitInteractionScript.OrbitCursorInfo pointInfo)
		{
			OrbitHoveredWithDelay = false;
		}

		private void OnHoverStay(OrbitInteractionScript source, OrbitInteractionScript.OrbitCursorInfo pointInfo)
		{
			if (!_playerCraft.PlayerCraft.ManeuverNodeManager.AnyItemsBeingHoveredWhichPreventManeuverNodeAdder && (double)pointInfo.HoverTime > 0.25)
			{
				OrbitHoveredWithDelay = true;
			}
		}

		private void OnManeuverNodeAdjustmentChangeBegin(ManeuverNodeScript source, IOrbit updatedOrbit)
		{
		}

		private void OnManeuverNodeAdjustmentChangeEnd(ManeuverNodeScript source, IOrbit updatedOrbit)
		{
			_orbitChanging = false;
		}

		private void OnManeuverNodeAdjustmentChanging(ManeuverNodeScript source, IOrbit updatedOrbit)
		{
			_orbitChanging = true;
		}

		private void SetIsDrawing(bool drawing)
		{
			if (drawing != IsDrawing)
			{
				if (drawing)
				{
					UpdateLine(forceUpdate: false);
				}
				else
				{
					_vectrocityLine.points3.Clear();
				}
			}
		}

		private void UpdateEventSubscriptions(bool subscribe)
		{
			if (subscribe)
			{
				Data.ShowOrbitLineChanged += OnDataShowOrbitLineChanged;
				return;
			}
			Data.ShowOrbitLineChanged -= OnDataShowOrbitLineChanged;
			if (_maneuverNodeEventsProvider != null)
			{
				_maneuverNodeEventsProvider.ManeuverNodeAdjustmentChangingEvent -= OnManeuverNodeAdjustmentChanging;
				_maneuverNodeEventsProvider.ManeuverNodeAdjustmentChangeEndEvent -= OnManeuverNodeAdjustmentChangeEnd;
				_maneuverNodeEventsProvider.ManeuverNodeAdjustmentChangeBeginEvent -= OnManeuverNodeAdjustmentChangeBegin;
			}
		}

		private void UpdateIcons(bool canShowGlobal)
		{
			OrbitUiVerbosity orbitUiVerbosity = _options.OrbitUiVerbosity;
			bool flag = base.OrbitInfo.IsAssociatedWith(_cameraTarget.Target);
			bool isPartOfPlayerChain = base.OrbitInfo.IsPartOfPlayerChain;
			bool flag2 = OrbitHoveredWithDelay || DrawFullOrbit || flag;
			bool periapsisOnVisibleOrbit = PeriapsisOnVisibleOrbit;
			ShowPeriapsisIcon = canShowGlobal && periapsisOnVisibleOrbit && flag2;
			if (ShowPeriapsisIcon)
			{
				UiUtils.UpdateUiComponentFromNu(_periapsisIcon, 0.0, base.OrbitInfo, base.DrawModeProvider, base.CoordinateConverter, base.InfoCanvas, base.Camera, base.UiMaxRenderDist, Vector2.zero);
			}
			else
			{
				UiUtils.UiComponentSetEnabled(_periapsisIcon, enabled: false);
			}
			periapsisOnVisibleOrbit = canShowGlobal && ApoapsisOnVisibleOrbit;
			ShowApoapsisIcon = periapsisOnVisibleOrbit && flag2;
			if (ShowApoapsisIcon)
			{
				UiUtils.UpdateUiComponentFromNu(_apoapsisIcon, Math.PI, base.OrbitInfo, base.DrawModeProvider, base.CoordinateConverter, base.InfoCanvas, base.Camera, base.UiMaxRenderDist, Vector2.zero);
			}
			else
			{
				UiUtils.UiComponentSetEnabled(_apoapsisIcon, enabled: false);
			}
			ShowTargetAscendingDescNodeIcons = canShowGlobal && orbitUiVerbosity >= OrbitUiVerbosity.Medium && _navigationTargetProvider?.NavigationTarget != null && OrbitHoveredWithDelay;
			if (ShowTargetAscendingDescNodeIcons)
			{
				GetAscendingDescendingNodesToTarget(out var ascendingNodeToTarget, out var descendingNodeToTarget);
				if (ascendingNodeToTarget.HasValue)
				{
					UiUtils.UpdateUiComponentFromNu(_targetAscendingNodeIcon, ascendingNodeToTarget.Value, base.OrbitInfo, base.DrawModeProvider, base.CoordinateConverter, base.InfoCanvas, base.Camera, base.UiMaxRenderDist, Vector2.zero);
				}
				else
				{
					UiUtils.UiComponentSetEnabled(_targetAscendingNodeIcon, enabled: false);
				}
				if (descendingNodeToTarget.HasValue)
				{
					UiUtils.UpdateUiComponentFromNu(_targetDescendingNodeIcon, descendingNodeToTarget.Value, base.OrbitInfo, base.DrawModeProvider, base.CoordinateConverter, base.InfoCanvas, base.Camera, base.UiMaxRenderDist, Vector2.zero);
				}
				else
				{
					UiUtils.UiComponentSetEnabled(_targetDescendingNodeIcon, enabled: false);
				}
			}
			else
			{
				UiUtils.UiComponentSetEnabled(_targetAscendingNodeIcon, enabled: false);
				UiUtils.UiComponentSetEnabled(_targetDescendingNodeIcon, enabled: false);
			}
			if (Game.InPlanetStudioScene)
			{
				if (InvalidTrueAnomaly.HasValue)
				{
					IOrbitPoint pointAtTrueAnomaly = OrbitMath.GetPointAtTrueAnomaly(base.OrbitInfo.OrbitNode.Orbit, InvalidTrueAnomaly.Value);
					_sphereOfInfluence.SetActive(value: true);
					_sphereOfInfluence.transform.position = (Vector3)base.CoordinateConverter.ConvertSolarToMapView(base.DrawModeProvider.DrawMode.GetSolarPosition(base.OrbitInfo, pointAtTrueAnomaly));
					UiUtils.UpdateUiComponentFromPoint(_invalidOrbitIcon, pointAtTrueAnomaly, base.OrbitInfo, base.DrawModeProvider, base.CoordinateConverter, base.InfoCanvas, base.Camera, base.UiMaxRenderDist);
				}
				else
				{
					_sphereOfInfluence.SetActive(value: false);
					UiUtils.UiComponentSetEnabled(_invalidOrbitIcon, enabled: false);
				}
			}
			if (Game.InPlanetStudioScene)
			{
				periapsisOnVisibleOrbit = true;
			}
			else
			{
				periapsisOnVisibleOrbit = false;
				periapsisOnVisibleOrbit = ((base.OrbitInfo.ChainNode == null) ? (canShowGlobal && _navigationTargetProvider.NavigationTarget?.OrbitInfo == base.OrbitInfo) : (canShowGlobal && (base.OrbitInfo.ChainNode.ListNode.Next == null || OrbitHoveredWithDelay || base.OrbitInfo.Selected)));
				periapsisOnVisibleOrbit = periapsisOnVisibleOrbit && OrbitHoveredWithDelay && !base.OrbitInfo.OrbitNode.NodeExitsSoi;
			}
			ShowAscendingDescendingNodeIcons = canShowGlobal && periapsisOnVisibleOrbit && orbitUiVerbosity >= OrbitUiVerbosity.Medium;
			if (ShowAscendingDescendingNodeIcons)
			{
				UiUtils.UpdateUiComponentFromNu(_ascendingNodeIcon, base.OrbitInfo.OrbitNode.Orbit.TrueAnomalyOfAscendingNode, base.OrbitInfo, base.DrawModeProvider, base.CoordinateConverter, base.InfoCanvas, base.Camera, base.UiMaxRenderDist, Vector2.zero);
				UiUtils.UpdateUiComponentFromNu(_descendingNodeIcon, base.OrbitInfo.OrbitNode.Orbit.TrueAnomalyOfDescendingNode, base.OrbitInfo, base.DrawModeProvider, base.CoordinateConverter, base.InfoCanvas, base.Camera, base.UiMaxRenderDist, Vector2.zero);
			}
			else
			{
				UiUtils.UiComponentSetEnabled(_ascendingNodeIcon, enabled: false);
				UiUtils.UiComponentSetEnabled(_descendingNodeIcon, enabled: false);
			}
			periapsisOnVisibleOrbit = base.OrbitInfo.PlanetIntersectionOnVisibleOrbit;
			ShowPlanetIntersectionIcon = canShowGlobal && periapsisOnVisibleOrbit && isPartOfPlayerChain;
			if (ShowPlanetIntersectionIcon)
			{
				UiUtils.UpdateUiComponentFromPoint(_planetIntersectionIcon, base.OrbitInfo.PlanetIntersection, base.OrbitInfo, base.DrawModeProvider, base.CoordinateConverter, base.InfoCanvas, base.Camera, base.UiMaxRenderDist);
			}
			else
			{
				UiUtils.UiComponentSetEnabled(_planetIntersectionIcon, enabled: false);
			}
		}

		private void UpdateLine(bool forceUpdate)
		{
			if (Data.ShowOrbitLine || forceUpdate)
			{
				UpdateLine(this, base.DrawModeProvider, ref _drawModeReferenceInfo, ref _orbitPointSet, base.CoordinateConverter, base.ContainerProvider, ref _scaledLocalOrbitPointsCache, ref _orbitLineRenderer);
			}
		}

		private void UpdateText(bool canShowGlobal)
		{
			OrbitUiVerbosity orbitUiVerbosity = _options.OrbitUiVerbosity;
			bool flag = orbitUiVerbosity != OrbitUiVerbosity.Low;
			ShowApsidesInfoText = canShowGlobal && (orbitUiVerbosity == OrbitUiVerbosity.High || _lineManager.ShowApsidesInfo || DrawFullOrbit || _orbitChanging || (OrbitHoveredWithDelay && flag));
			ShowApoapsisInfoText = ShowApsidesInfoText && ShowApoapsisIcon;
			ShowPeriapsisInfoText = ShowApsidesInfoText && ShowPeriapsisIcon;
			if (ShowApoapsisInfoText)
			{
				double num = base.OrbitInfo.OrbitNode.Orbit.ApoapsisDistance - base.OrbitInfo.OrbitNode.Parent.PlanetData.Radius;
				double seconds = ((base.OrbitInfo.IsPartOfPlayerChain && base.OrbitInfo.OrbitNode.Orbit.Eccentricity < 1.0) ? (base.OrbitInfo.OrbitNode.Apoapsis.Time - _playerCraft.PlayerCraft.OrbitInfo.OrbitNode.Orbit.Time) : base.OrbitInfo.OrbitNode.Orbit.GetTimeToApoapsis());
				_apoDistanceText.text = Units.GetDistanceString((float)num) + "\n" + Units.GetRelativeTimeString(seconds);
				UiUtils.UpdateUiComponentFromNu(_apoDistanceText, Math.PI, base.OrbitInfo, base.DrawModeProvider, base.CoordinateConverter, base.InfoCanvas, base.Camera, base.UiMaxRenderDist, new Vector2(0f, 50f));
			}
			else
			{
				UiUtils.UiComponentSetEnabled(_apoDistanceText, enabled: false);
			}
			if (ShowPeriapsisInfoText)
			{
				double num2 = base.OrbitInfo.OrbitNode.Orbit.PeriapsisDistance - base.OrbitInfo.OrbitNode.Parent.PlanetData.Radius;
				double seconds2 = (base.OrbitInfo.IsPartOfPlayerChain ? (base.OrbitInfo.OrbitNode.Periapsis.Time - _playerCraft.PlayerCraft.OrbitInfo.OrbitNode.Orbit.Time) : base.OrbitInfo.OrbitNode.Orbit.GetTimeToPeriapsis());
				_periDistanceText.text = Units.GetDistanceString((float)num2, useAbsoluteValue: false) + "\n" + Units.GetRelativeTimeString(seconds2);
				UiUtils.UpdateUiComponentFromNu(_periDistanceText, 0.0, base.OrbitInfo, base.DrawModeProvider, base.CoordinateConverter, base.InfoCanvas, base.Camera, base.UiMaxRenderDist, new Vector2(0f, 50f));
			}
			else
			{
				UiUtils.UiComponentSetEnabled(_periDistanceText, enabled: false);
			}
		}
	}
}
