using System;
using System.Collections.Generic;
using Client;
using Easing;
using Factory;
using Factory.Pools;
using Motorways.Utility;
using UnityEngine;

namespace Motorways.Views
{
	public class DeadEndRoadView : MonoBehaviour, IView, IReusable, IReleasedFromScopeHandler
	{
		public interface IObserver
		{
			void OnDeadEndReleased(DeadEndRoadView deadEnd);
		}

		private TileDirection _direction;

		private RoadTileConnectionStrokePath _straightStrokePath;

		private Spline.BezierSpline _distortedSpline;

		private TileDirection _autoDistortionTarget = TileDirection.None;

		private Spline.BezierSpline _autoDistortionSpline;

		private readonly TweenFloat _autoDistortionTween = new TweenFloat();

		private float _autoDistortionTweenTime;

		private bool _isManuallyDistorting;

		private TileDirection _manualDistortionTarget = TileDirection.None;

		private Spline.BezierSpline _manualDistortionSpline;

		private float _manualDistortionFactor;

		private float _manualDistortionFactorScale;

		private readonly TweenFloat _manualDistortionFactorScaleTween = new TweenFloat();

		private Spline.BezierSpline _previousManualDistortionSpline;

		private readonly TweenFloat _manualDistortionTargetTween = new TweenFloat();

		private RoadAnimationDirection _animationDirection;

		private float _widthFactor;

		private readonly TweenFloat _widthTween = new TweenFloat();

		private bool _isDynamic;

		[SerializeField]
		private DynamicRoadMesh _dynamicRoadMesh;

		private RoadView _staticView;

		private RoadState _roadState;

		private readonly ObserverList<IObserver> _observers = new ObserverList<IObserver>();

		[Dependency]
		private RoadTileAtlas _roadTileAtlas;

		[Dependency]
		private IScope _scope;

		[Dependency]
		private VisualConstantsData _visualConstants;

		[Dependency]
		private City _city;

		[Dependency]
		private PermanenceZoneTextureLibrary _permanenceZoneTextureLibrary;

		public TileDirection Direction => _direction;

		public Spline.BezierSpline MedianSpline
		{
			get
			{
				if (_isDynamic && _distortedSpline != null)
				{
					return _distortedSpline;
				}
				return _straightStrokePath.pathSpline;
			}
		}

		public TileDirection AutoDistortionTarget => _autoDistortionTarget;

		public bool IsBeingReplaced { get; private set; }

		public bool IsReplacing { get; private set; }

		public TileDirection ManualDistortionTarget => _manualDistortionTarget;

		public float ManualDistortionFactor
		{
			get
			{
				return _manualDistortionFactor;
			}
			set
			{
				_manualDistortionFactor = Mathf.Clamp01(value);
				if (_manualDistortionFactorScaleTween.IsActive && _manualDistortionFactorScaleTween.End <= 0f)
				{
					_manualDistortionFactorScaleTween.Stop();
				}
			}
		}

		public RoadState RoadState => _roadState;

		public float WidthFactor
		{
			get
			{
				return _widthFactor;
			}
			set
			{
				_widthFactor = value;
				_widthTween.Stop();
				_animationDirection = RoadAnimationDirection.None;
			}
		}

		public bool IsDynamic
		{
			get
			{
				return _isDynamic;
			}
			private set
			{
				_isDynamic = value;
				_dynamicRoadMesh.gameObject.SetActive(_isDynamic);
				_staticView.gameObject.SetActive(!_isDynamic && _roadState != RoadState.None && !IsBeingReplaced);
				if (_isDynamic)
				{
					_staticView.tileView.ResumeTicking();
				}
			}
		}

		public void Initialize(TileView tileView, TileDirection direction)
		{
			_direction = direction;
			RoadTileConnection connection = new RoadTileConnection(new RoadTileNode(direction), new RoadTileNode(direction));
			RoadTileConnectionStrokePath strokePathForConnection = _roadTileAtlas.GetStrokePathForConnection(connection);
			_straightStrokePath = strokePathForConnection;
			using RoadTileSignature roadTileSignature = _scope.Get<RoadTileSignature>();
			roadTileSignature.AddConnection(connection);
			_staticView = _scope.Get<RoadView>();
			_staticView.tileView = tileView;
			_staticView.SetSignature(roadTileSignature);
			_staticView.transform.SetParent(base.transform, worldPositionStays: false);
			_staticView.gameObject.SetActive(value: false);
			_dynamicRoadMesh.Initialize(tileView, _permanenceZoneTextureLibrary, _city.Rules.RoadsBecomePermanentOverTime);
		}

		public void ReconfigurePermanenceVisibility()
		{
			_dynamicRoadMesh.SetPermanenceVisibility(_city.Rules.RoadsBecomePermanentOverTime);
			_staticView.ReconfigurePermanenceVisibility();
		}

		public void AppearFromConnection(RoadTileConnection replacedConnection, float widthFactor = 1f)
		{
			if (SetAutoDistortionTarget(replacedConnection))
			{
				if (_animationDirection == RoadAnimationDirection.None)
				{
					WidthFactor = widthFactor;
				}
				_autoDistortionTween.Start(1f, 0f, _visualConstants.DeadEndEmergeDuration, _visualConstants.DeadEndEmergeEasingFunction);
				_autoDistortionTweenTime = _visualConstants.DeadEndEmergeDuration;
				IsDynamic = true;
				IsBeingReplaced = false;
				IsReplacing = true;
			}
		}

		public void ReplaceWithConnection(RoadTileConnection replacingConnection)
		{
			if (IsBeingReplaced)
			{
				return;
			}
			if (SetAutoDistortionTarget(replacingConnection))
			{
				float start = 0f;
				if (_isManuallyDistorting)
				{
					if (_autoDistortionTarget == _manualDistortionTarget)
					{
						start = _manualDistortionFactor;
						ClearManualDistortion();
					}
					else
					{
						CancelManualDistortion();
					}
				}
				_autoDistortionTween.Start(start, 1f, _visualConstants.DeadEndCollapseDuration, _visualConstants.DeadEndCollapseEasingFunction);
				_autoDistortionTweenTime = Mathf.Max(_visualConstants.DeadEndCollapseDuration, _visualConstants.AppearDuration);
				IsDynamic = true;
				IsBeingReplaced = true;
				IsReplacing = false;
			}
			else
			{
				CancelManualDistortion();
			}
		}

		public void SetManualDistortionTarget(TileDirection outputTarget, float easeDuration = 0f, Easings.Functions easeType = Easings.Functions.Linear)
		{
			if (_manualDistortionTarget != outputTarget)
			{
				Spline.BezierSpline splineForConnection = GetSplineForConnection(outputTarget);
				if (splineForConnection == null)
				{
					return;
				}
				if (_isManuallyDistorting)
				{
					if (easeDuration > 0f)
					{
						if (_previousManualDistortionSpline == null)
						{
							_previousManualDistortionSpline = _manualDistortionSpline;
						}
						else
						{
							_previousManualDistortionSpline = SlerpSpline(_previousManualDistortionSpline, _manualDistortionSpline, _manualDistortionTargetTween.Value);
						}
						_manualDistortionTargetTween.Start(0f, 1f, easeDuration, easeType);
					}
					else
					{
						_previousManualDistortionSpline = null;
						_manualDistortionTargetTween.Stop();
					}
				}
				if (_manualDistortionFactorScale <= 0f || (_manualDistortionFactorScaleTween.IsActive && _manualDistortionFactorScaleTween.End <= 0f))
				{
					_manualDistortionFactorScaleTween.Start(_manualDistortionFactorScale, 1f, _visualConstants.DeadEndEditDistortionStartDuration, _visualConstants.DeadEndEditDistortionStartEasingFunction);
				}
				_manualDistortionTarget = outputTarget;
				_manualDistortionSpline = splineForConnection;
			}
			_isManuallyDistorting = true;
			IsDynamic = true;
		}

		public void CancelManualDistortion()
		{
			if (_isManuallyDistorting && (!_manualDistortionFactorScaleTween.IsActive || _manualDistortionFactorScaleTween.End > 0f))
			{
				_manualDistortionFactorScaleTween.Start(_manualDistortionFactorScale, 0f, _visualConstants.DeadEndEditDistortionReturnDuration, _visualConstants.DeadEndEditDistortionReturnEasingFunction);
			}
		}

		public void SetRoadState(RoadState newRoadState, TransitionStyle transitionStyle = TransitionStyle.Tween)
		{
			if (_roadState == newRoadState)
			{
				return;
			}
			_dynamicRoadMesh.RoadState = newRoadState;
			_staticView.baseRenderer.material = ((newRoadState == RoadState.Mothballed) ? _staticView.mothballedMaterial : _staticView.activeMaterial);
			RoadState roadState = _roadState;
			_roadState = newRoadState;
			if (newRoadState != RoadState.None && roadState != RoadState.None)
			{
				return;
			}
			float widthFactor = ((newRoadState != RoadState.None) ? 1 : 0);
			if (transitionStyle == TransitionStyle.Snap)
			{
				WidthFactor = widthFactor;
				_animationDirection = RoadAnimationDirection.None;
				IsDynamic = false;
				return;
			}
			float rangeBegin;
			float rangeEnd;
			float rangeDuration;
			if (newRoadState == RoadState.None)
			{
				rangeBegin = 1f;
				rangeEnd = 0f;
				rangeDuration = _visualConstants.DisappearDuration;
				_animationDirection = RoadAnimationDirection.AnimatingOut;
				_dynamicRoadMesh.CursorWidthFactor = 0f;
			}
			else
			{
				rangeBegin = 0f;
				rangeEnd = 1f;
				rangeDuration = _visualConstants.AppearDuration;
				_animationDirection = RoadAnimationDirection.AnimatingIn;
				_dynamicRoadMesh.CursorWidthFactor = 1f;
			}
			_widthTween.Start(WidthFactor, rangeBegin, rangeEnd, rangeDuration);
			IsDynamic = true;
		}

		public TickResult Tick(TimeInterval tickTime, float stepAlpha)
		{
			if (_isDynamic)
			{
				List<Vector2> list = _straightStrokePath.pathPoints;
				bool flag = false;
				if (_autoDistortionTweenTime > 0f || _isManuallyDistorting)
				{
					_distortedSpline = _straightStrokePath.pathSpline;
					if (_autoDistortionTweenTime > 0f)
					{
						if (_autoDistortionTween.IsActive)
						{
							_autoDistortionTween.Tick(tickTime.Delta);
						}
						float value = _autoDistortionTween.Value;
						_distortedSpline = SlerpSpline(_straightStrokePath.pathSpline, _autoDistortionSpline, value);
						_autoDistortionTweenTime -= tickTime.Delta;
						flag |= _autoDistortionTweenTime > 0f;
					}
					if (_isManuallyDistorting)
					{
						bool flag2 = false;
						if (_manualDistortionFactorScaleTween.IsActive)
						{
							_manualDistortionFactorScale = _manualDistortionFactorScaleTween.Tick(tickTime.Delta);
							if (!_manualDistortionFactorScaleTween.IsActive && _manualDistortionFactorScale <= 0f)
							{
								flag2 = true;
								ClearManualDistortion();
							}
						}
						if (!flag2)
						{
							Spline.BezierSpline b = _manualDistortionSpline;
							if (_manualDistortionTargetTween.IsActive)
							{
								float t = _manualDistortionTargetTween.Tick(tickTime.Delta);
								b = SlerpSpline(_previousManualDistortionSpline, _manualDistortionSpline, t);
								if (!_manualDistortionTargetTween.IsActive)
								{
									_previousManualDistortionSpline = null;
								}
							}
							_distortedSpline = SlerpSpline(_distortedSpline, b, _manualDistortionFactor * _manualDistortionFactorScale);
							flag = true;
						}
					}
					Spline.RasterizedSpline rasterizedSpline = _distortedSpline.Rasterize(25);
					float magnitude = (_straightStrokePath.pathSpline.inPoint - _straightStrokePath.pathSpline.outPoint).magnitude;
					rasterizedSpline.Truncate(magnitude);
					list = rasterizedSpline.Positions;
					if (TileUtilities.IsDirectionDiagonal(_direction))
					{
						list.Insert(0, _straightStrokePath.pathPoints[0]);
					}
				}
				else
				{
					_distortedSpline = null;
				}
				if (_widthTween.IsActive)
				{
					_widthFactor = _widthTween.Tick(tickTime.Delta);
					_dynamicRoadMesh.OutlineWidthFactor = _widthFactor;
					_dynamicRoadMesh.RoadWidthFactor = _widthFactor;
					if (_widthTween.IsActive)
					{
						flag = true;
					}
					else
					{
						_animationDirection = RoadAnimationDirection.None;
					}
				}
				else
				{
					_dynamicRoadMesh.OutlineWidthFactor = _widthFactor;
					_dynamicRoadMesh.RoadWidthFactor = _widthFactor;
				}
				if (!flag)
				{
					IsDynamic = false;
				}
				else
				{
					_dynamicRoadMesh.SetPathPoints(list);
				}
			}
			if (_city.Rules.RoadsBecomePermanentOverTime)
			{
				_dynamicRoadMesh.UpdatePermanenceShaderValues();
				_staticView.Tick(tickTime, stepAlpha);
				return TickResult.ContinueTicking;
			}
			if (!_isDynamic)
			{
				return TickResult.StopTicking;
			}
			return TickResult.ContinueTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		public void Subscribe(IObserver observer)
		{
			_observers.Subscribe(observer);
		}

		public void Unsubscribe(IObserver observer)
		{
			_observers.Unsubscribe(observer);
		}

		public void Reset()
		{
			_roadState = RoadState.None;
			_direction = TileDirection.North;
			_distortedSpline = null;
			_straightStrokePath = null;
			IsBeingReplaced = false;
			IsReplacing = false;
			_autoDistortionTarget = TileDirection.None;
			_autoDistortionSpline = null;
			_autoDistortionTween.Reset();
			_autoDistortionTweenTime = 0f;
			_manualDistortionFactor = 0f;
			_isManuallyDistorting = false;
			_manualDistortionTarget = TileDirection.None;
			_manualDistortionSpline = null;
			_manualDistortionFactorScale = 0f;
			_manualDistortionFactorScaleTween.Reset();
			_manualDistortionTargetTween.Reset();
			_animationDirection = RoadAnimationDirection.None;
			_widthFactor = 0f;
			_widthTween.Reset();
			_widthTween.Reset();
			_isDynamic = false;
			_dynamicRoadMesh.Reset();
			base.transform.position = Vector3.zero;
		}

		public void OnReleasedFromScope(IScope scope)
		{
			if (_staticView != null)
			{
				_staticView.transform.SetParent(null, worldPositionStays: false);
				_staticView.gameObject.SetActive(value: true);
				_scope.Release(_staticView);
				_staticView = null;
			}
			ObserverList<IObserver>.Enumerator enumerator = _observers.GetEnumerator();
			while (enumerator.MoveNext())
			{
				enumerator.Current.OnDeadEndReleased(this);
			}
		}

		private bool SetAutoDistortionTarget(RoadTileConnection connection)
		{
			TileDirection tileDirection = ((connection.input.direction == _direction) ? connection.output.direction : connection.input.direction);
			if (_autoDistortionTarget == tileDirection)
			{
				return true;
			}
			Spline.BezierSpline splineForConnection = GetSplineForConnection(tileDirection);
			if (splineForConnection != null)
			{
				_autoDistortionTarget = tileDirection;
				_autoDistortionSpline = splineForConnection;
				return true;
			}
			return false;
		}

		private void ClearManualDistortion()
		{
			_manualDistortionFactor = 0f;
			_isManuallyDistorting = false;
			_manualDistortionTarget = TileDirection.None;
			_manualDistortionSpline = null;
			_manualDistortionFactorScale = 0f;
			_manualDistortionFactorScaleTween.Stop();
			_manualDistortionTargetTween.Stop();
			_previousManualDistortionSpline = null;
		}

		private Spline.BezierSpline GetSplineForConnection(TileDirection outputDirection)
		{
			RoadTileConnection roadTileConnection = new RoadTileConnection(_direction, outputDirection);
			RoadTileConnectionStrokePath strokePathForConnection = _roadTileAtlas.GetStrokePathForConnection(roadTileConnection);
			if (!Diagnostics.Verify(strokePathForConnection != null, "Unable to find mesh for distortion connection {0}.", roadTileConnection))
			{
				return null;
			}
			return strokePathForConnection.pathSpline;
		}

		private Spline.BezierSpline SlerpSpline(Spline.BezierSpline a, Spline.BezierSpline b, float t)
		{
			return Spline.BezierSpline.Lerp(a, b, t);
		}

		private Vector2 SlerpVector(Vector2 a, Vector2 b, float t)
		{
			float f = Mathf.LerpAngle(Mathf.Atan2(a.y, a.x) * 57.29578f, Mathf.Atan2(b.y, b.x) * 57.29578f, t) * ((float)Math.PI / 180f);
			float num = Mathf.Lerp(a.magnitude, b.magnitude, t);
			return new Vector2(Mathf.Cos(f) * num, Mathf.Sin(f) * num);
		}

		public void OnDrawGizmosSelected()
		{
			Vector3 position = base.transform.position;
			if (_straightStrokePath?.pathSpline != null)
			{
				Gizmos.color = Color.red;
				Gizmos.DrawLine(position + (Vector3)_straightStrokePath.pathSpline.inPoint, position + (Vector3)_straightStrokePath.pathSpline.inHandle);
				Gizmos.DrawLine(position + (Vector3)_straightStrokePath.pathSpline.inHandle, position + (Vector3)_straightStrokePath.pathSpline.outHandle);
				Gizmos.DrawLine(position + (Vector3)_straightStrokePath.pathSpline.outHandle, position + (Vector3)_straightStrokePath.pathSpline.outPoint);
			}
			if (_autoDistortionSpline != null)
			{
				Gizmos.color = Color.blue;
				Gizmos.DrawLine(position + (Vector3)_autoDistortionSpline.inPoint, position + (Vector3)_autoDistortionSpline.inHandle);
				Gizmos.DrawLine(position + (Vector3)_autoDistortionSpline.inHandle, position + (Vector3)_autoDistortionSpline.outHandle);
				Gizmos.DrawLine(position + (Vector3)_autoDistortionSpline.outHandle, position + (Vector3)_autoDistortionSpline.outPoint);
			}
		}
	}
}
