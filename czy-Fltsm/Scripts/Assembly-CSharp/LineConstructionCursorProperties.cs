using System;
using FMODUnity;
using PajamaLlama.Generic;
using PajamaLlama.Math;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(menuName = "Flotsam/Cursor Properties/Line Construction")]
public class LineConstructionCursorProperties : ConstructionCursorProperties
{
	public enum Iteration
	{
		StartPreview = 0,
		LinePreview = 1
	}

	[SerializeField]
	protected CountedItemProperty[] _requiredResources;

	[SerializeField]
	protected WalkwaySegment[] _segments = new WalkwaySegment[0];

	[Space]
	[MinMaxRangeFloat(0f, 360f)]
	[SerializeField]
	private RangedFloat _angleLimit = new RangedFloat(10f, 45f);

	[Tooltip("Minimum length for a walkway line.")]
	[SerializeField]
	private int _minimumLength = 1;

	[SerializeField]
	protected int _waypointSize = 1;

	[Header("FMOD")]
	[SerializeField]
	private EventReference _increaseLengthEvent;

	[SerializeField]
	private EventReference _decreaseLengthEvent;

	[SerializeField]
	private EventReference _hookEvent;

	[NonSerialized]
	protected ConstructionPreview _segmentPreview;

	[NonSerialized]
	protected ConstructionPreview _startWaypointPreview;

	[NonSerialized]
	protected ConstructionPreview _endWaypointPreview;

	[NonSerialized]
	protected Vector2 _startPosition;

	[NonSerialized]
	protected Vector2 _endPosition;

	[NonSerialized]
	private float _wantedLength;

	[NonSerialized]
	protected Iteration _iteration;

	[NonSerialized]
	protected int _maximumLength;

	[NonSerialized]
	protected WalkwaySegment _currentSegment;

	[NonSerialized]
	protected Hookable _waypointHookable;

	[NonSerialized]
	private WalkwayScalable[] _scalables;

	public WalkwaySegment[] Segments => _segments;

	public override void Initialize(Buildable buildable, int visualIndex = -1)
	{
		base.Initialize(buildable, visualIndex);
	}

	public override void Activate()
	{
		base.Activate();
		_startWaypointPreview = CreateConstructionVisual(_buildable, _visualIndex);
		_endWaypointPreview = CreateConstructionVisual(_buildable, _visualIndex);
		_endWaypointPreview.Disable();
		InitializeSegments();
	}

	protected void InitializeSegments()
	{
		_maximumLength = 0;
		WalkwaySegment[] segments = _segments;
		foreach (WalkwaySegment walkwaySegment in segments)
		{
			if (_maximumLength < walkwaySegment.Length)
			{
				_maximumLength = walkwaySegment.Length;
			}
			walkwaySegment.ManuallySetBuildable();
		}
		_waypointHookable = _buildable.GetComponent<Hookable>();
		_maximumLength += 2 * _waypointSize;
		if (_segments.Length <= 1)
		{
			_minimumLength = _maximumLength;
		}
	}

	public override void UpdateCursor(CursorManager cursor)
	{
		base.UpdateCursor(cursor);
		bool canBePlaced = true;
		bool snapBuilding = Settings.Instance.GameplayPlayerData.SnapBuilding;
		switch (_iteration)
		{
		case Iteration.StartPreview:
			UpdatePreviewPlacingConstruction(_startWaypointPreview, out _startPosition, out canBePlaced, _maximumLength / 2, _maximumLength / 2, _requiredResources);
			break;
		case Iteration.LinePreview:
			UpdateLinePreview(snapBuilding, out canBePlaced);
			break;
		}
		if (canBePlaced && !EventSystem.current.IsPointerOverGameObject() && GetInteract() && Iterate())
		{
			cursor.Deactivate();
		}
	}

	public override void DeactivateImmediately()
	{
		base.DeactivateImmediately();
		RemoveConstructionPreview(ref _startWaypointPreview);
		RemoveConstructionPreview(ref _endWaypointPreview);
		RemoveConstructionPreview(ref _segmentPreview);
		Reset();
	}

	public override bool TryToDeactivate(CursorManager cursor)
	{
		if (GetCancel() && CancelIteration())
		{
			cursor.Deactivate(cancelled: true);
			return true;
		}
		return false;
	}

	public override void DrawGizmos()
	{
		base.DrawGizmos();
	}

	protected void UpdateLinePreview(bool snap, out bool canBePlaced)
	{
		canBePlaced = true;
		if (_startWaypointPreview.IsHooked && _startWaypointPreview.Hookable.RotateAroundHook)
		{
			UpdateStartHook(_startWaypointPreview.Hookable, _startWaypointPreview.Hookable.Buildable.OutlinePolygon, _startWaypointPreview.Hookable.transform.position.Vector2TopDown(), CursorManager.BuildingPosition.Vector2TopDown());
			Vector2 vector = _startWaypointPreview.Hookable.transform.position.Vector2TopDown();
			_startPosition = vector + (_endPosition - vector).normalized * _startWaypointPreview.Hookable.RotateRadius;
		}
		UpdateEndWaypoint(snap);
		_endPosition = ReturnLineEndPosition();
		UpdateLinePreview(_startPosition, _endPosition);
		if (_segmentPreview.OutlineCorners.Count != 4)
		{
			throw new NotImplementedException();
		}
		UpdateOutline();
		bool flag = CanPlaceEndWaypoint();
		_endWaypointPreview.SetValid(flag);
		UpdateCanSegmentBePlaced(_segmentPreview, _startPosition, _endPosition);
		bool flag2 = ResourceManager.AreCommunityResourcesAvailable(_requiredResources);
		_endWaypointPreview.SetValid(flag && flag2);
		_segmentPreview.SetValid(_segmentPreview.CanPlace && flag2);
		canBePlaced = flag && _segmentPreview.CanPlace && flag2;
	}

	private void UpdateStartHook(Hookable hookable, Polygon polygon, Vector2 startPosition, Vector2 endPosition)
	{
		polygon.FastUpdate();
		if (!polygon.ReturnIsLineIntersecting(startPosition, endPosition, out var closestIntersection))
		{
			return;
		}
		Hookable.Edge edge = _startWaypointPreview.Hook.Edge;
		if (hookable.TryReturnClosestEdge(closestIntersection.Vector3TopDown(), float.MaxValue, out var closestEdge, out var _, out var _))
		{
			_startWaypointPreview.Hook.Edge = closestEdge;
			_startPosition = _startWaypointPreview.Hook.Edge.Center;
			if (edge != closestEdge)
			{
				BuildingGrid.SetPlacement(_startPosition.Vector3TopDown(), _startWaypointPreview.Hook);
			}
		}
	}

	private bool TryToSpawnResources()
	{
		if (_buildable == null || _currentSegment == null)
		{
			return false;
		}
		if (BuildingDevTools.TryAutoSpawnResources(_buildable.Properties.RequiredResources))
		{
			return BuildingDevTools.TryAutoSpawnResources(_currentSegment.Buildable.Properties.RequiredResources);
		}
		return false;
	}

	protected bool PlaceLine(WalkwaySegment currentSegment, bool hookNext, bool storedBuildable = false)
	{
		Hookable waypoint;
		return PlaceLine(currentSegment, out waypoint, hookNext, storedBuildable);
	}

	protected bool PlaceLine(WalkwaySegment currentSegment, out Hookable waypoint, bool hookNext, bool storedBuildable = false)
	{
		waypoint = null;
		if (!currentSegment.Buildable.Properties.ReturnCanBePlaced(Community.PlayerCommunity, !storedBuildable) || !_buildable.Properties.ReturnCanBePlaced(Community.PlayerCommunity, !storedBuildable))
		{
			return false;
		}
		Vector3 position = _endWaypointPreview.Transform.transform.position;
		Quaternion rotation = _endWaypointPreview.Transform.transform.rotation;
		if (_endWaypointPreview.IsHooked)
		{
			waypoint = _endWaypointPreview.Hookable;
		}
		else
		{
			waypoint = Buildable.Place(_buildable, position, rotation, _endWaypointPreview.VisualIndex, instantPlacement: true).GetComponent<Hookable>();
		}
		Quaternion rotation2 = Math3d.FlattenQuaternion(_segmentPreview.Transform.transform.rotation);
		WalkwaySegment walkwaySegment = UnityEngine.Object.Instantiate(currentSegment, _segmentPreview.Transform.transform.position.Leveled(), rotation2);
		_segmentPreview.Transform.transform.rotation = rotation2;
		UpdateOutline();
		Vector2[] array = new Vector2[_segmentPreview.OutlineCorners.Count];
		for (int i = 0; i < _segmentPreview.OutlineCorners.Count; i++)
		{
			Vector3 localPosition = _segmentPreview.OutlineCorners[i].localPosition;
			array[i] = localPosition.Vector2TopDown();
		}
		walkwaySegment.GetComponent<Buildable>().Initialize(Community.PlayerCommunity, _segmentPreview.VisualIndex, array);
		walkwaySegment.InitializeSegment(_startPosition.Vector3TopDown(), _endPosition.Vector3TopDown(), _startWaypointPreview.Hookable, waypoint, _wantedLength);
		walkwaySegment.UpdateScale();
		walkwaySegment.Buildable.BuoyantTransform.position = _segmentPreview.Transform.transform.position;
		walkwaySegment.Buildable.BuoyantTransform.rotation = _segmentPreview.Transform.transform.rotation;
		if (BuildingDevTools.InstantBuild || storedBuildable)
		{
			walkwaySegment.Buildable.FinishBuilding();
		}
		else
		{
			walkwaySegment.Buildable.SpawnedVisual.SetProgress(0f);
			walkwaySegment.Buildable.PlaceBuildingLines();
			walkwaySegment.Buildable.StartBuilding();
		}
		if (_startWaypointPreview.Hookable.TryGetComponent<Construction>(out var component) && waypoint.TryGetComponent<Construction>(out var component2) && walkwaySegment.Construction != null)
		{
			walkwaySegment.Construction.AddNeighbourConstruction(component2);
			walkwaySegment.Construction.AddNeighbourConstruction(component);
			component.AddNeighbourConstruction(walkwaySegment.Construction);
			walkwaySegment.Construction.AddNeighbourConstruction(component2);
			component2.AddNeighbourConstruction(walkwaySegment.Construction);
		}
		if (!hookNext)
		{
			return true;
		}
		return ContinuousBuilding(waypoint);
	}

	public bool ContinuousBuilding(Hookable waypoint = null, bool useWaypointPosition = false)
	{
		Vector3 normalized = (_endPosition - _startPosition).Vector3TopDown().normalized;
		Vector3 vector = ((!useWaypointPosition) ? (_endWaypointPreview.Transform.transform.position + normalized * _waypointSize) : (waypoint.transform.position + normalized * _waypointSize));
		if (waypoint.TryToHookPoint(vector, float.MaxValue, out var hook))
		{
			_startWaypointPreview.Hook = hook;
			_startWaypointPreview.Hookable = waypoint;
			BuildingGrid.SetPlacement(vector, hook);
			RemoveConstructionPreview(ref _endWaypointPreview);
			_visualIndex = _buildable.ReturnVisualIndex(-1);
			_endWaypointPreview = CreateConstructionVisual(_buildable, _visualIndex);
			_endWaypointPreview.Transform.gameObject.SetActive(value: false);
			return true;
		}
		if (hook == null)
		{
			_startWaypointPreview.Hook = null;
		}
		return false;
	}

	public void CreatePontonForSegment(WalkwaySegment segment, Buildable pontonPrefab, bool hookToEnd)
	{
		Vector3 position = (hookToEnd ? segment.EndPosition : segment.StartPosition);
		Hookable component = Buildable.Place(pontonPrefab, position, segment.transform.rotation, pontonPrefab.VisualIndex, instantPlacement: true).GetComponent<Hookable>();
		if (component.TryGetComponent<Construction>(out var component2) && segment.Construction != null)
		{
			segment.Construction.AddNeighbourConstruction(component2);
			component2.AddNeighbourConstruction(segment.Construction);
		}
		Vector3 vector = (segment.EndPosition - segment.StartPosition).normalized * _waypointSize;
		if (hookToEnd)
		{
			segment.SetEndHookable(component, -vector);
		}
		else
		{
			segment.SetStartHookable(component, vector);
		}
	}

	protected void Reset()
	{
		_iteration = Iteration.StartPreview;
		RemoveConstructionPreview(ref _segmentPreview);
		_currentSegment = null;
	}

	private void UpdateLinePreview(Vector2 startPosition, Vector2 endPosition)
	{
		_wantedLength = Vector2.Distance(startPosition, endPosition);
		Vector2 vector = (endPosition - startPosition).normalized;
		if (vector == Vector2.zero)
		{
			vector = Vector2.up;
		}
		WalkwaySegment walkwaySegment = ReturnSegment(_wantedLength);
		if (_currentSegment != walkwaySegment)
		{
			if (_currentSegment == null || walkwaySegment.Length >= _currentSegment.Length)
			{
				AudioManager.PlayOneShot(_increaseLengthEvent);
			}
			else
			{
				AudioManager.PlayOneShot(_decreaseLengthEvent);
			}
			UpdateSegment(walkwaySegment);
			_currentSegment = walkwaySegment;
		}
		Quaternion rotation = Quaternion.LookRotation(vector.Vector3TopDown());
		rotation.eulerAngles = rotation.eulerAngles.SetX(0f).SetZ(0f);
		_endWaypointPreview.Transform.transform.rotation = rotation;
		float num = _startWaypointPreview.Hookable.Buildable.SpawnedVisual.transform.position.y + ReturnStartWaypointHeightOffset();
		Vector3 firstPoint = _startPosition.Vector3TopDown(num);
		float num2 = ReturnEndWaypointHeightOffset();
		num2 = ((!_endWaypointPreview.IsHooked) ? (num2 + _endWaypointPreview.Transform.transform.position.y) : (num2 + _endWaypointPreview.Hookable.Buildable.SpawnedVisual.transform.position.y));
		Vector3 secondPoint = _endPosition.Vector3TopDown(num2);
		_segmentPreview.Transform.transform.rotation = FlotsamGame.PointsToRotation(firstPoint, secondPoint, level: false);
		Vector3 position = Vector2.Lerp(_startPosition, _endPosition, 0.5f).Vector3TopDown(Mathf.Lerp(num, num2, 0.5f));
		_segmentPreview.Transform.transform.position = position;
		_segmentPreview.Boundary.SetSize(_buildable.Properties.Width, _wantedLength / 2f);
		WalkwayScalable.SetZScale(_scalables, _wantedLength / (float)_currentSegment.Length);
	}

	private void UpdateOutline()
	{
		Vector2 normalized = (_endPosition - _startPosition).normalized;
		Vector2 vector = new Vector2(normalized.y, 0f - normalized.x);
		float num = _currentSegment.Width;
		_segmentPreview.OutlineCorners[0].position = (_startPosition + vector * num).Vector3TopDown();
		_segmentPreview.OutlineCorners[1].position = (_startPosition - vector * num).Vector3TopDown();
		_segmentPreview.OutlineCorners[2].position = (_endPosition - vector * num).Vector3TopDown();
		_segmentPreview.OutlineCorners[3].position = (_endPosition + vector * num).Vector3TopDown();
	}

	private bool Iterate()
	{
		switch (_iteration)
		{
		case Iteration.StartPreview:
			_iteration++;
			_startWaypointPreview.Disable();
			_endWaypointPreview.Enable();
			break;
		case Iteration.LinePreview:
		{
			if (!TryToSpawnResources())
			{
				return true;
			}
			bool button = FlotsamInputManager.RewiredPlayer.GetButton("Continuous Building");
			if (!PlaceLine(_currentSegment, button))
			{
				return true;
			}
			if (!button)
			{
				CancelIteration();
			}
			return false;
		}
		}
		return false;
	}

	private bool CancelIteration()
	{
		switch (_iteration)
		{
		case Iteration.StartPreview:
			return true;
		case Iteration.LinePreview:
			_startWaypointPreview.Enable();
			Reset();
			_visualIndex = _buildable.ReturnVisualIndex(-1);
			RemoveConstructionPreview(ref _endWaypointPreview);
			_endWaypointPreview = CreateConstructionVisual(_buildable, _visualIndex);
			_endWaypointPreview.Disable();
			return false;
		default:
			return false;
		}
	}

	private void UpdateCanSegmentBePlaced(ConstructionPreview preview, Vector2 startPosition, Vector2 endPosition)
	{
		Vector2 normalized = (endPosition - startPosition).normalized;
		Vector2 vector = new Vector2(normalized.y, 0f - normalized.x);
		float num = Vector2.Angle(normalized, _startWaypointPreview.Hook.Right.Vector2TopDown());
		float num2 = (_endWaypointPreview.IsHooked ? Vector2.Angle(normalized, _endWaypointPreview.Hook.Right.Vector2TopDown()) : 0f);
		float num3 = _currentSegment.Width;
		if (!Mathf.Approximately(num, 0f))
		{
			num3 = (float)_currentSegment.Width / Mathf.Sin(num * (MathF.PI / 180f));
		}
		Vector2 origin;
		Vector2 origin2;
		if (_startWaypointPreview.Hookable.RotateAroundHook)
		{
			origin = startPosition - vector * _currentSegment.Width;
			origin2 = startPosition + vector * _currentSegment.Width;
		}
		else if (num < 90f)
		{
			origin = startPosition + _startWaypointPreview.Hook.Right.Vector2TopDown() * num3;
			origin2 = startPosition + vector * _currentSegment.Width;
		}
		else
		{
			origin = startPosition - vector * _currentSegment.Width;
			origin2 = startPosition - _startWaypointPreview.Hook.Right.Vector2TopDown() * num3;
		}
		Vector2 end;
		Vector2 end2;
		if (_endWaypointPreview.IsHooked)
		{
			if (num2 < 90f)
			{
				end = endPosition - _endWaypointPreview.Hook.Right.Vector2TopDown() * num3;
				end2 = endPosition + vector * _currentSegment.Width;
			}
			else
			{
				end = endPosition - vector * _currentSegment.Width;
				end2 = endPosition + _endWaypointPreview.Hook.Right.Vector2TopDown() * num3;
			}
		}
		else
		{
			end = endPosition - vector * _currentSegment.Width;
			end2 = endPosition + vector * _currentSegment.Width;
		}
		bool flag = preview.Transform.transform.position.IsInRange(Construction.TownheartPosition, GameSettings.Instance.GameplaySettings.ConstructionRadius);
		bool flag2 = false;
		foreach (Polygon blockingPolygon in Buildable.BlockingPolygons)
		{
			blockingPolygon.FastUpdate();
			if (blockingPolygon.ReturnIsLineIntersecting(origin, end))
			{
				flag2 = true;
				break;
			}
			if (blockingPolygon.ReturnIsLineIntersecting(origin2, end2))
			{
				flag2 = true;
				break;
			}
			if (blockingPolygon.ReturnIsLineIntersecting(origin, end2))
			{
				flag2 = true;
				break;
			}
		}
		preview.SetCanPlace(flag && !flag2);
	}

	private void UpdateSegment(WalkwaySegment segment)
	{
		TransformData transformData = new TransformData(Vector3.zero, Vector3.zero, Vector3.one);
		if (_segmentPreview != null)
		{
			transformData = new TransformData(_segmentPreview.Transform.transform);
			RemoveConstructionPreview(ref _segmentPreview);
		}
		_segmentPreview = CreateConstructionVisual(segment.Buildable, -1, isHooked: true);
		_scalables = _segmentPreview.Visual.GetComponentsInChildren<WalkwayScalable>(includeInactive: true);
		_segmentPreview.Hook = _startWaypointPreview.Hook;
		transformData.Apply(_segmentPreview.Transform.transform);
	}

	private void UpdateEndWaypoint(bool gridSnapping)
	{
		Vector2 vector = _startPosition;
		Vector2 endPosition = CursorManager.BuildingPosition.Vector2TopDown();
		Vector2 vector2 = _startWaypointPreview.Hook.Forward.Vector2TopDown();
		Vector2 rightVector = _startWaypointPreview.Hook.Right.Vector2TopDown();
		if (_startWaypointPreview.Hookable.RotateAroundHook)
		{
			vector = _startWaypointPreview.Hookable.transform.position.Vector2TopDown();
		}
		Vector2 vector3 = ReturnLengthConstrainedPosition(_minimumLength, _maximumLength, vector, endPosition, -vector2, rightVector, gridSnapping);
		if (Hookable.TryReturnClosestIntersection(out var closestIntersection, vector, vector3, _startWaypointPreview.Hookable))
		{
			if (Vector2.Distance(vector, closestIntersection) >= (float)_minimumLength)
			{
				vector3 = ReturnAngleConstrainedPosition(vector, closestIntersection, -vector2, rightVector);
			}
		}
		else
		{
			vector3 = ReturnAngleConstrainedPosition(vector, vector3, -vector2, rightVector);
		}
		UpdateTransform(_endWaypointPreview, vector3.Vector3TopDown(), -vector2.Vector3TopDown(), Settings.Instance.GameplayPlayerData.SnapBuilding, _startWaypointPreview.Hookable);
		if (!_endWaypointPreview.IsHooked)
		{
			Vector2 vector4 = _endWaypointPreview.Transform.transform.position.Vector2TopDown();
			Vector2 normalized = (vector4 - _startPosition).normalized;
			vector3 = ReturnAngleConstrainedPosition(vector, vector4 - normalized * _waypointSize, -vector2, rightVector);
			_endWaypointPreview.Transform.transform.position = WorldManager.WaterAdjustedPosition(vector3);
		}
		if (_endWaypointPreview.Transform.gameObject.activeSelf == _endWaypointPreview.IsHooked)
		{
			_endWaypointPreview.Transform.gameObject.SetActive(!_endWaypointPreview.IsHooked);
		}
	}

	private bool CanPlaceEndWaypoint()
	{
		if (_endWaypointPreview.IsHooked)
		{
			return true;
		}
		_endWaypointPreview.UpdateCanBePlaced(needsHook: false, !Settings.Instance.GameplayPlayerData.SnapBuilding);
		return _endWaypointPreview.CanPlace;
	}

	private Vector2 ReturnLineEndPosition()
	{
		if (_endWaypointPreview.IsHooked)
		{
			return Math3d.ProjectPointOnLineSegment(_endWaypointPreview.Hook.Edge.StartPoint, _endWaypointPreview.Hook.Edge.EndPoint, _endWaypointPreview.Transform.transform.position).Vector2TopDown();
		}
		Vector2 vector = _endWaypointPreview.Transform.transform.position.Vector2TopDown();
		Vector2 normalized = (vector - _startPosition).normalized;
		return vector - normalized * _waypointSize;
	}

	private float ReturnStartWaypointHeightOffset()
	{
		return _startWaypointPreview.Hookable.HookHeightOffset;
	}

	private float ReturnEndWaypointHeightOffset()
	{
		if (_endWaypointPreview.IsHooked)
		{
			return _endWaypointPreview.Hookable.HookHeightOffset;
		}
		return _waypointHookable.HookHeightOffset;
	}

	private WalkwaySegment ReturnSegment(float length)
	{
		WalkwaySegment result = _segments[0];
		float num = float.MaxValue;
		for (int i = 0; i < _segments.Length; i++)
		{
			WalkwaySegment walkwaySegment = _segments[i];
			if (MathExtensions.Approximately(length, walkwaySegment.Length))
			{
				return walkwaySegment;
			}
			float num2 = Mathf.Abs(length - (float)walkwaySegment.Length);
			if (num2 < num)
			{
				num = num2;
				result = walkwaySegment;
			}
		}
		return result;
	}

	private Vector2 ReturnLengthConstrainedPosition(int minLength, int maxLength, Vector2 startPosition, Vector2 endPosition, Vector2 forwardVector, Vector2 rightVector, bool gridSnapping)
	{
		if (_startWaypointPreview.IsHooked && _startWaypointPreview.Hookable.RotateAroundHook)
		{
			minLength += (int)_startWaypointPreview.Hookable.RotateRadius;
			maxLength += (int)_startWaypointPreview.Hookable.RotateRadius;
		}
		Vector2 vector = endPosition - startPosition;
		Vector2 normalized = vector.normalized;
		float num = Mathf.Max(minLength, vector.magnitude);
		int gridSize = GameSettings.Instance.BuildableSettings.GridSize;
		num = ((!gridSnapping) ? Mathf.Clamp(num, minLength, maxLength) : ((float)Mathf.Clamp((int)(num / (float)gridSize) * gridSize, minLength, maxLength)));
		return startPosition + normalized * num;
	}

	private Vector2 ReturnAngleConstrainedPosition(Vector2 startPosition, Vector2 endPosition, Vector2 forwardVector, Vector2 rightVector)
	{
		Vector2 vector = endPosition - startPosition;
		float magnitude = vector.magnitude;
		Vector2 normalized = vector.normalized;
		float num = Vector2.Angle(normalized, forwardVector);
		if (num > _angleLimit.Maximum)
		{
			if (Vector2.Angle(rightVector, normalized) < Vector2.Angle(-rightVector, normalized))
			{
				return startPosition + Vector2.Lerp(forwardVector, rightVector, _angleLimit.Maximum / 90f).normalized * magnitude;
			}
			return startPosition + Vector2.Lerp(forwardVector, -rightVector, _angleLimit.Maximum / 90f).normalized * magnitude;
		}
		if (num < _angleLimit.Minimum)
		{
			return startPosition + forwardVector * magnitude;
		}
		return startPosition + normalized * magnitude;
	}

	protected void UpdateTransform(ConstructionPreview preview, Vector3 inputPosition, Vector3 lineDirection, bool gridSnapping = false, Hookable illegalHook = null)
	{
		Vector3 position = WorldManager.WaterAdjustedPosition(inputPosition);
		bool isHooked = preview.IsHooked;
		preview.IsHooked = Hookable.TryHook(out var closestHook, out preview.Hookable, _hookSnapDistance, inputPosition, illegalHook, construction: false, lineDirection, (!_segments.IsNullOrEmpty()) ? ((float)_segments[0].Width) : 0f);
		preview.Hook = closestHook;
		if (preview.IsHooked)
		{
			int gridIndex;
			Vector3 position2 = preview.Hook.ReturnPosition(inputPosition, gridSnapping, out gridIndex);
			position = WorldManager.WaterAdjustedPosition(preview.Hook.ReturnHookedPosition(position2, _hookDistance));
			if (!isHooked)
			{
				AudioManager.PlayOneShot(_hookEvent);
			}
		}
		preview.Transform.transform.SetPositionAndRotation(position, Quaternion.identity);
	}

	public override CountedItemProperty[] ReturnRequiredResources(BuildableProperties buildableProperties)
	{
		return _requiredResources;
	}
}
