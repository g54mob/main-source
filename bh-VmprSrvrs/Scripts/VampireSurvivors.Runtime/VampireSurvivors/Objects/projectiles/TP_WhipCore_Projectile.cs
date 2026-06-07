using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_WhipCore_Projectile : Projectile
	{
		public LineRenderer _lineRenderer;

		protected WhipVerletNode[] _nodes;

		protected Projectile[] _nodeProjectiles;

		protected float2 _gravity;

		protected float _flipNum;

		protected bool _applyNodeControl;

		protected float _nodeDistance;

		protected float2 _characterOffset;

		protected float _whipSize;

		protected float _timeStartAttack;

		protected float _timeFadeOut;

		protected float _delayFadeOut;

		protected float _timeLerpRatio;

		public virtual int Nodes => 0;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		protected virtual float WhipLength()
		{
			return 0f;
		}

		protected virtual float2 GetCharacterOffset()
		{
			return default(float2);
		}

		protected virtual void InitWhips()
		{
		}

		protected virtual Projectile CreateNodeProjectile(float2 pos)
		{
			return null;
		}

		protected void bodyEnabled(bool enable)
		{
		}

		protected void ApplyGravity()
		{
		}

		protected void ApplyVerletConstraints()
		{
		}

		protected virtual float CalculateIndexNodeDistance(int index)
		{
			return 0f;
		}

		protected float2 MultiLerp(List<Vector2> waypoints, float lerp)
		{
			return default(float2);
		}

		protected int GetVectorIndexFromDistanceTravelled(List<Vector2> waypoints, float distanceTravelled)
		{
			return 0;
		}

		protected float MultiDistance(List<Vector2> waypoints)
		{
			return 0f;
		}

		public static List<Vector2> GenerateSpline(WhipVerletNode[] points, int stepsPerCurve = 5, float tension = 1f)
		{
			return null;
		}

		public override void Despawn()
		{
		}
	}
}
