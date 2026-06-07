using Easing;
using Factory;
using Factory.Pools;
using NaughtyAttributes;
using UnityEngine;

namespace Motorways.Views
{
	public class AnimatedRoadTileConnectionView : MonoBehaviour, IReusable
	{
		private RoadTileConnection _connection;

		[ShowNonSerializedField]
		private RoadAnimationDirection _animationDirection;

		[ShowNonSerializedField]
		private float _outlineWidthFactor;

		[ShowNonSerializedField]
		private readonly TweenFloat _outlineWidthTween = new TweenFloat();

		[ShowNonSerializedField]
		private float _roadWidthFactor;

		[ShowNonSerializedField]
		private readonly TweenFloat _roadWidthTween = new TweenFloat();

		[SerializeField]
		private DynamicRoadMesh _dynamicRoadMesh;

		[Dependency]
		private VisualConstantsData _visualConstants;

		[Dependency]
		private RoadTileAtlas _atlas;

		public RoadTileConnection Connection => _connection;

		public RoadAnimationDirection AnimationDirection
		{
			get
			{
				return _animationDirection;
			}
			set
			{
				if (value != _animationDirection && value != RoadAnimationDirection.None)
				{
					_animationDirection = value;
					if (_animationDirection == RoadAnimationDirection.AnimatingIn)
					{
						_outlineWidthTween.Start(_outlineWidthFactor, 0f, 1f, _visualConstants.AppearDuration);
						_roadWidthTween.Start(_roadWidthFactor, 0f, 1f, _visualConstants.AppearDuration);
					}
					else
					{
						_outlineWidthTween.Start(_outlineWidthFactor, 1f, 0f, _visualConstants.DisappearDuration);
						_roadWidthTween.Start(_roadWidthFactor, 1f, 0f, _visualConstants.DisappearDuration);
					}
				}
			}
		}

		public RoadState RoadState
		{
			get
			{
				return _dynamicRoadMesh.RoadState;
			}
			set
			{
				_dynamicRoadMesh.RoadState = value;
			}
		}

		public float RoadWidthFactor => _roadWidthFactor;

		public float OutlineWidthFactor => _outlineWidthFactor;

		public bool IsComplete => !_roadWidthTween.IsActive;

		public bool IsConnectedToDirection(TileDirection direction)
		{
			if (_connection.input.direction != direction)
			{
				return _connection.output.direction == direction;
			}
			return true;
		}

		public void Tick(TimeInterval tickTime)
		{
			if (_outlineWidthTween.IsActive)
			{
				_outlineWidthFactor = _outlineWidthTween.Tick(tickTime.Delta);
				_dynamicRoadMesh.OutlineWidthFactor = _outlineWidthFactor;
			}
			if (_roadWidthTween.IsActive)
			{
				_roadWidthFactor = _roadWidthTween.Tick(tickTime.Delta);
				_dynamicRoadMesh.RoadWidthFactor = _roadWidthFactor;
			}
			_dynamicRoadMesh.UpdatePermanenceShaderValues();
		}

		public void Reset()
		{
			base.transform.localPosition = Vector3.zero;
			_connection = default(RoadTileConnection);
			_animationDirection = RoadAnimationDirection.None;
			_outlineWidthFactor = 0f;
			_outlineWidthTween.Reset();
			_roadWidthFactor = 0f;
			_roadWidthTween.Reset();
		}

		public void SetPermanenceVisibility(bool isPermanenceVisible)
		{
			_dynamicRoadMesh.SetPermanenceVisibility(isPermanenceVisible);
		}

		private static AnimatedRoadTileConnectionView CreateAnimation(IScope scope, TileView tileView, RoadState state)
		{
			AnimatedRoadTileConnectionView animatedRoadTileConnectionView = scope.Get<AnimatedRoadTileConnectionView>();
			animatedRoadTileConnectionView.transform.position = TilemapView.GetWorldPositionForCoordinates(tileView.Coordinates);
			animatedRoadTileConnectionView.RoadState = state;
			PermanenceZoneTextureLibrary permanenceZoneTextureLibrary = scope.Get<PermanenceZoneTextureLibrary>();
			animatedRoadTileConnectionView._dynamicRoadMesh.Initialize(tileView, permanenceZoneTextureLibrary, scope.Get<City>().Rules.RoadsBecomePermanentOverTime);
			return animatedRoadTileConnectionView;
		}

		public static AnimatedRoadTileConnectionView CreateAnimationIn(IScope scope, TileView tileView, RoadTileConnection connection, RoadState state, RoadState previousState)
		{
			float initialOutlineWidthFactor = ((previousState == RoadState.Mothballed) ? 1 : 0);
			AnimatedRoadTileConnectionView animatedRoadTileConnectionView = CreateAnimation(scope, tileView, state);
			animatedRoadTileConnectionView.AnimateConnectionIn(connection, initialOutlineWidthFactor);
			return animatedRoadTileConnectionView;
		}

		public static AnimatedRoadTileConnectionView CreateAnimationOut(IScope scope, TileView tileView, RoadTileConnection connection, RoadState state = RoadState.Mothballed)
		{
			AnimatedRoadTileConnectionView animatedRoadTileConnectionView = CreateAnimation(scope, tileView, state);
			animatedRoadTileConnectionView.AnimateConnectionOut(connection);
			return animatedRoadTileConnectionView;
		}

		public static AnimatedRoadTileConnectionView CreateStaticAnimation(IScope scope, TileView tileView, RoadTileConnection connection, RoadState state)
		{
			AnimatedRoadTileConnectionView animatedRoadTileConnectionView = CreateAnimation(scope, tileView, state);
			animatedRoadTileConnectionView.AnimateConnectionIn(connection, 1f, 1f);
			return animatedRoadTileConnectionView;
		}

		private void AnimateConnectionIn(RoadTileConnection connection, float initialOutlineWidthFactor = 0f, float initialRoadWidthFactor = 0f)
		{
			_connection = connection;
			RoadTileConnectionStrokePath strokePathForConnection = _atlas.GetStrokePathForConnection(connection);
			_dynamicRoadMesh.SetPathPoints(strokePathForConnection.pathPoints);
			_dynamicRoadMesh.CursorWidthFactor = 1f;
			_animationDirection = RoadAnimationDirection.AnimatingIn;
			_outlineWidthFactor = initialOutlineWidthFactor;
			_outlineWidthTween.Start(initialOutlineWidthFactor, 1f, _visualConstants.AppearDuration, Easings.Functions.Linear);
			_roadWidthFactor = initialRoadWidthFactor;
			_roadWidthTween.Start(initialRoadWidthFactor, 1f, _visualConstants.AppearDuration, Easings.Functions.Linear);
		}

		private void AnimateConnectionOut(RoadTileConnection connection)
		{
			_connection = connection;
			RoadTileConnectionStrokePath strokePathForConnection = _atlas.GetStrokePathForConnection(connection);
			_dynamicRoadMesh.SetPathPoints(strokePathForConnection.pathPoints);
			_dynamicRoadMesh.CursorWidthFactor = 0f;
			_animationDirection = RoadAnimationDirection.AnimatingOut;
			_outlineWidthFactor = 1f;
			_outlineWidthTween.Start(1f, 0f, _visualConstants.DisappearDuration, Easings.Functions.Linear);
			_roadWidthFactor = 1f;
			_roadWidthTween.Start(1f, 0f, _visualConstants.DisappearDuration, Easings.Functions.Linear);
		}
	}
}
