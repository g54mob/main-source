using System.Collections.Generic;
using Coherence.Toolkit;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Stages
{
	[DefaultExecutionOrder(899)]
	public class PlatformZoneMovement : GameMonoBehaviour
	{
		public class JumpInfo
		{
			public float _fallingTimer;

			public bool _hasJumped;
		}

		public struct ClosestEdge
		{
			public StageEdge _edge;

			public float2 _point;

			public float _distSqrd;

			public float _yDistance;
		}

		private List<StageEdge> _stageEdges;

		private ParticleEmitterManager _pfxEmitterManager;

		private ParticleSystem _smokeEmitter;

		private List<JumpInfo> _characterInfo;

		private bool _limitCameraPosition;

		private bool _blendAfterCameraLimitsDisabled;

		private Vector2 _cameraBlendVelocity;

		private float _cameraXVelocity;

		private float _cameraYVelocity;

		private CoherenceSync _sync;

		public float? MinCameraX;

		public float? MinCameraY;

		public float? MaxCameraX;

		public float? MaxCameraY;

		public List<StageEdge> StageEdges => null;

		public static PlatformZoneMovement Instance { get; private set; }

		public bool MoveCameraInsideLimitsOnLimitsEnabled { get; set; }

		public bool LimitCameraPosition
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public void SetCameraLimits(Rectangle cameraLimitsRectangle)
		{
		}

		private void Awake()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected override void OnUpdate()
		{
		}

		private void LateUpdate()
		{
		}

		public void LoadStageEdges(PolygonGroupComponent polygonGroup)
		{
		}

		private ClosestEdge FindClosestEdge(float2 position, float rangeSqrd = 3.4028235E+38f, bool includeFalling = false)
		{
			return default(ClosestEdge);
		}

		public ClosestEdge FindClosestWalkableEdgeBelow(float2 position)
		{
			return default(ClosestEdge);
		}

		private void RunEdgeLogic()
		{
		}

		public bool IsInFallZone(float2 position)
		{
			return false;
		}

		public float2 ApplyMovement(ArcadeSprite character, JumpInfo info, float2 lastFacingDirection, bool tryingToJump)
		{
			return default(float2);
		}

		private void TriggerSmokeEmitter(Vector2 position, int count)
		{
		}

		[Command]
		public void ActivateSmokeEmitter(Vector2 position, int count)
		{
		}

		private void LockToEdge(ArcadeSprite character, JumpInfo info, StageEdge edge, float2 lastFacingDirection)
		{
		}

		private void InitJumpParticles()
		{
		}

		private void UpdateCameraTarget()
		{
		}

		private void ActualUpdateCameraTarget()
		{
		}
	}
}
