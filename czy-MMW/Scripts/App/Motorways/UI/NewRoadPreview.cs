using System;
using System.Collections.Generic;
using Client;
using Easing;
using Factory;
using Factory.Pools;
using Motorways.Utility;
using Motorways.Views;
using UnityEngine;

namespace Motorways.UI
{
	public class NewRoadPreview : MonoBehaviour, IReusable, IView, ICreatedInScopeHandler, IReleasedFromScopeHandler, DeadEndRoadView.IObserver
	{
		[SerializeField]
		private DynamicRoadMesh _roadMesh;

		[SerializeField]
		[Min(0.001f)]
		private float ScaleInDuration = 0.3f;

		[SerializeField]
		private AnimationCurve ScaleInCurve;

		[SerializeField]
		[Min(0.001f)]
		private float ScaleOutDuration = 0.1f;

		[SerializeField]
		private AnimationCurve ScaleOutCurve;

		[SerializeField]
		private float MaximumLength = 4f;

		[SerializeField]
		private float FadeoutStartLength = 4f;

		[SerializeField]
		private float FadeLength = 0.5f;

		private bool _isVisible;

		private Vector2Int _originCoordinates;

		private Vector2 _pointerPosition;

		private TileDirection _direction = TileDirection.None;

		private float _previewLength;

		private float _directionScale;

		private DeadEndRoadView _distortingDeadEnd;

		[Tooltip("How much the preview should distort a dead end to match the preview's direction. The x-axis is the preview's length in world-space. The y-axis is the distortion factor (0 is no distortion, 1 is full distortion).")]
		[SerializeField]
		private AnimationCurve DeadEndDistortionCurve;

		private TileDirection _directionWhenOriginChanged = TileDirection.None;

		private Vector2 _pointerPositionWhenOriginChanged;

		private float _pointerMovementSinceOriginChanged;

		[Tooltip("How far the pointer must move after a road is built before the direction of the preview can be changed. Lower this to make the preview more responsive to direction changes after a road is built, at the expense of risking rapid changes in direction if the player's input is twitchy.")]
		[SerializeField]
		private float DirectionChangeThreshold = 0.4f;

		private readonly TweenFloat _widthTween = new TweenFloat();

		private RoadAnimationDirection _widthCurveDirection;

		private bool _hasExtended;

		private readonly TweenFloat _extensionTween = new TweenFloat();

		private Vector2Int _coordinatesWhenMinified;

		private Vector2 _pointerPositionWhenMinified;

		[SerializeField]
		[Tooltip("How far the pointer must move from its original position before the preview extends. Each tile is two units wide.")]
		private float ExtensionMovementThreshold = 0.1f;

		[Tooltip("The maximum distance the pointer can be from the centre of its original tile before the preview extends, regardless of how far it has moved.")]
		[SerializeField]
		private float ExtensionDistanceThreshold = 0.1f;

		[SerializeField]
		[Tooltip("The duration of the tween out when the preview extends from a dot to a line.")]
		private float ExtensionTweenDuration = 0.3f;

		[Tooltip("The easing function used when the preview extends from a dot to a line.")]
		[SerializeField]
		private Easings.Functions ExtensionTweenEaseType;

		[Tooltip("The duration of the tween out when the preview contracts from a line back into a dot.")]
		[SerializeField]
		private float ContractionTweenDuration = 0.3f;

		[Tooltip("The easing function used when the preview contracts from a line back into a dot.")]
		[SerializeField]
		private Easings.Functions ContractionTweenEaseType;

		private float _angle;

		private readonly TweenRadians _angleTween = new TweenRadians();

		[SerializeField]
		[Tooltip("The duration of the tween when the preview changes in direction.")]
		private float AngleTweenDuration = 0.07f;

		[Tooltip("The easing function used when the preview changes in direction.")]
		[SerializeField]
		private Easings.Functions AngleTweenEaseType;

		private bool _isRemoving;

		[Dependency]
		private TilemapView _tilemap;

		private const float HazardStripeAngleOffset = (float)Math.PI / 4f;

		private bool IsVisible
		{
			get
			{
				return _isVisible;
			}
			set
			{
				if (value != _isVisible)
				{
					_isVisible = value;
					if (!_widthTween.IsActive)
					{
						_widthCurveDirection = (_isVisible ? RoadAnimationDirection.AnimatingIn : RoadAnimationDirection.AnimatingOut);
					}
					if (_isVisible)
					{
						_widthTween.Start(_widthTween.Value, 0f, 1f, ScaleInDuration);
					}
					else if (_hasExtended)
					{
						_extensionTween.Start(_extensionTween.Value, 0f, ContractionTweenDuration, _extensionTween.IsActive ? ExtensionTweenEaseType : ContractionTweenEaseType);
						_widthTween.Start(_widthTween.Value, 0f, ScaleOutDuration, Easings.Functions.Linear, _extensionTween.Duration);
					}
					else
					{
						_widthTween.Start(_widthTween.Value, 1f, 0f, ScaleOutDuration);
					}
				}
			}
		}

		public void SetPosition(Vector2Int fromCoordinates, Vector2 toPosition)
		{
			bool flag = _originCoordinates != fromCoordinates;
			if (flag)
			{
				if (IsVisible)
				{
					_directionWhenOriginChanged = TileUtilities.GetDirectionBetweenAdjacentCoordinates(_originCoordinates, fromCoordinates);
					if (_directionWhenOriginChanged == TileDirection.None)
					{
						_directionWhenOriginChanged = TileUtilities.GetClosestDirection(fromCoordinates - _originCoordinates);
					}
					_pointerPositionWhenOriginChanged = _pointerPosition;
					_pointerMovementSinceOriginChanged = 0f;
				}
				_originCoordinates = fromCoordinates;
				base.transform.position = TilemapView.GetWorldPositionForCoordinates(fromCoordinates);
				if (_distortingDeadEnd != null)
				{
					_distortingDeadEnd.Unsubscribe(this);
					_distortingDeadEnd.CancelManualDistortion();
					_distortingDeadEnd = null;
				}
			}
			if (!IsVisible)
			{
				_coordinatesWhenMinified = fromCoordinates;
				_pointerPositionWhenMinified = toPosition;
				IsVisible = true;
			}
			Vector2 vector = TilemapView.GetWorldPositionForCoordinates(_originCoordinates);
			Vector2 direction = toPosition - vector;
			TileDirection tileDirection = TileUtilities.GetClosestDirection(direction);
			_previewLength = Mathf.Min(direction.magnitude, MaximumLength);
			if (_directionWhenOriginChanged != TileDirection.None)
			{
				_pointerMovementSinceOriginChanged += Vector2.Distance(toPosition, _pointerPosition);
				Vector2 direction2 = toPosition - _pointerPositionWhenOriginChanged;
				if (_pointerMovementSinceOriginChanged < DirectionChangeThreshold || direction2.sqrMagnitude <= 0f || TileUtilities.GetClosestDirection(direction2) == _directionWhenOriginChanged)
				{
					tileDirection = _directionWhenOriginChanged;
				}
				else
				{
					_directionWhenOriginChanged = TileDirection.None;
				}
			}
			bool flag2 = false;
			if (tileDirection != _direction)
			{
				flag2 = true;
				_direction = tileDirection;
			}
			TileView tileView = _tilemap.GetTileView(fromCoordinates);
			DeadEndRoadView deadEndRoadView = ((tileView == null || tileView.Tile.ContentType == TileContentType.House || !tileView.CanAnimateNewConnections) ? null : tileView.ActiveDeadEnd);
			if (deadEndRoadView != null && !deadEndRoadView.IsBeingReplaced)
			{
				if (deadEndRoadView != _distortingDeadEnd)
				{
					CancelDeadEndDistortion();
				}
				if (deadEndRoadView.Direction != _direction)
				{
					if (deadEndRoadView.ManualDistortionTarget != _direction)
					{
						deadEndRoadView.SetManualDistortionTarget(_direction, AngleTweenDuration, AngleTweenEaseType);
					}
					deadEndRoadView.ManualDistortionFactor = DeadEndDistortionCurve.Evaluate(_previewLength * _directionScale);
					if (_distortingDeadEnd == null)
					{
						_distortingDeadEnd = deadEndRoadView;
						_distortingDeadEnd.Subscribe(this);
					}
				}
				else
				{
					deadEndRoadView.CancelManualDistortion();
					CancelDeadEndDistortion();
				}
			}
			else
			{
				CancelDeadEndDistortion();
			}
			_directionScale = 1f;
			if (_direction != TileDirection.None)
			{
				Vector2 vectorForDirection = TileUtilities.GetVectorForDirection(_direction);
				_directionScale = Mathf.Clamp01(Vector2.Dot(direction.normalized, vectorForDirection));
				if (_directionScale <= 0f && _distortingDeadEnd == null)
				{
					_hasExtended = false;
					_coordinatesWhenMinified = _originCoordinates;
					_pointerPositionWhenMinified = toPosition;
					_extensionTween.Stop();
				}
			}
			if (!_hasExtended && (_distortingDeadEnd != null || _coordinatesWhenMinified != _originCoordinates || ((Vector2.Distance(_pointerPositionWhenMinified, toPosition) >= ExtensionMovementThreshold || _previewLength >= ExtensionDistanceThreshold) && _directionScale > 0f)))
			{
				_hasExtended = true;
				_extensionTween.Start(0f, 1f, ExtensionTweenDuration, ExtensionTweenEaseType);
			}
			if (flag2)
			{
				float num = (float)tileDirection * (-(float)Math.PI / 4f);
				if (flag || _direction == TileDirection.None || !_hasExtended)
				{
					_angle = num;
				}
				else
				{
					_angleTween.Start(_angle, num, AngleTweenDuration, AngleTweenEaseType);
				}
			}
			_pointerPosition = toPosition;
		}

		public void Remove()
		{
			TileView tileView = _tilemap.GetTileView(_originCoordinates);
			DeadEndRoadView deadEndRoadView = ((tileView == null) ? null : tileView.ActiveDeadEnd);
			if (deadEndRoadView != null)
			{
				deadEndRoadView.CancelManualDistortion();
			}
			IsVisible = false;
			_isRemoving = true;
		}

		public TickResult Tick(TimeInterval tickTime, float stepAlpha)
		{
			if (_widthTween.IsActive)
			{
				float num = _widthTween.Tick(tickTime.Delta);
				float cursorWidthFactor = ((_widthCurveDirection != RoadAnimationDirection.AnimatingIn) ? ScaleOutCurve.Evaluate(1f - num) : ScaleInCurve.Evaluate(num));
				_roadMesh.CursorWidthFactor = cursorWidthFactor;
			}
			float num2 = ((_hasExtended && !_isRemoving) ? 1 : 0);
			if (_extensionTween.IsActive)
			{
				num2 = _extensionTween.Tick(tickTime.Delta);
			}
			if (_angleTween.IsActive)
			{
				_angle = _angleTween.Tick(tickTime.Delta);
			}
			float num3 = _previewLength * num2 * _directionScale;
			if (_distortingDeadEnd != null)
			{
				Spline.BezierSpline medianSpline = _distortingDeadEnd.MedianSpline;
				num3 += medianSpline.inPoint.magnitude;
				Spline.RasterizedSpline rasterizedSpline = medianSpline.Rasterize(25);
				rasterizedSpline.Truncate(num3);
				List<Vector2> positions = rasterizedSpline.Positions;
				float length = rasterizedSpline.Length;
				if (length < num3)
				{
					Vector2 normalized = (medianSpline.outPoint - medianSpline.outHandle).normalized;
					positions.Add(positions[positions.Count - 1] + normalized * (num3 - length));
				}
				_roadMesh.SetPathPoints(positions);
			}
			else
			{
				Vector2 item = TileUtilities.GetVectorForDirection(TileDirection.North).Rotated(_angle);
				item *= num3;
				_roadMesh.SetPathPoints(new List<Vector2>
				{
					Vector2.zero,
					item
				});
			}
			_roadMesh.SetCursorRendererHazardStripesAngle(_angle + (float)Math.PI / 4f);
			float num4 = Mathf.Max(num3 - FadeLength, FadeoutStartLength);
			float p = 1f - Mathf.Clamp01((num3 - FadeoutStartLength) / FadeLength);
			p = Easings.CubicEaseOut(p);
			_roadMesh.SetCursorRendererFadeout(Mathf.Clamp01(num4 / num3), 1f, p);
			if (_widthTween.IsActive || !_isRemoving)
			{
				return TickResult.ContinueTicking;
			}
			return TickResult.Destroy;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		public void SetHazardStripesEnabled(bool stripesEnabled, bool tween = false)
		{
			_roadMesh.SetCursorRendererHazardStripesEnabled(stripesEnabled, tween);
		}

		public void OnCreatedInScope(IScope scope)
		{
			_roadMesh.HasEndCap = true;
			SetHazardStripesEnabled(stripesEnabled: false);
		}

		public void OnReleasedFromScope(IScope scope)
		{
			if (_distortingDeadEnd != null)
			{
				_distortingDeadEnd.Unsubscribe(this);
				_distortingDeadEnd = null;
			}
		}

		public void OnDeadEndReleased(DeadEndRoadView deadEnd)
		{
			if (deadEnd == _distortingDeadEnd)
			{
				_distortingDeadEnd.Unsubscribe(this);
				_distortingDeadEnd = null;
			}
		}

		public void Reset()
		{
			base.transform.localPosition = Vector3.zero;
			_isVisible = false;
			_originCoordinates = default(Vector2Int);
			_pointerPosition = default(Vector2);
			_direction = TileDirection.None;
			_previewLength = 0f;
			_directionScale = 0f;
			_distortingDeadEnd = null;
			_directionWhenOriginChanged = TileDirection.None;
			_pointerPositionWhenOriginChanged = default(Vector2);
			_pointerMovementSinceOriginChanged = 0f;
			_widthTween.Reset();
			_widthCurveDirection = RoadAnimationDirection.None;
			_hasExtended = false;
			_extensionTween.Reset();
			_coordinatesWhenMinified = default(Vector2Int);
			_pointerPositionWhenMinified = default(Vector2);
			_angle = 0f;
			_angleTween.Reset();
			_isRemoving = false;
		}

		private void CancelDeadEndDistortion()
		{
			if (_distortingDeadEnd != null)
			{
				_distortingDeadEnd.CancelManualDistortion();
				_distortingDeadEnd.Unsubscribe(this);
				_distortingDeadEnd = null;
			}
		}
	}
}
