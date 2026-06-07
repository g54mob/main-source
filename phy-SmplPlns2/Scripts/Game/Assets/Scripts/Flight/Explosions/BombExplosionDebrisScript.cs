using UnityEngine;

namespace Assets.Scripts.Flight.Explosions
{
	public class BombExplosionDebrisScript : ExplosionDebrisScript
	{
		private float _dragLerpCurrentTime;

		private float _dragLerpEnd;

		private float _dragLerpStart;

		private float _dragLerpTotalTime;

		public float RigidBodyDrag
		{
			get
			{
				return base.Rigidbody.linearDamping;
			}
			set
			{
				base.Rigidbody.linearDamping = value;
			}
		}

		public void LerpDrag(float startDrag, float endDrag, float time)
		{
			_dragLerpStart = startDrag;
			_dragLerpEnd = endDrag;
			_dragLerpTotalTime = time;
			_dragLerpCurrentTime = 0f;
		}

		protected virtual void FixedUpdate()
		{
			if ((double)_dragLerpTotalTime > 0.01)
			{
				_dragLerpCurrentTime += Time.deltaTime;
				RigidBodyDrag = Mathf.Lerp(_dragLerpStart, _dragLerpEnd, _dragLerpCurrentTime / _dragLerpTotalTime);
				if (_dragLerpCurrentTime >= _dragLerpTotalTime)
				{
					_dragLerpTotalTime = 0f;
				}
			}
			float? floatingOriginSeaLevel = GameWorld.Instance.FloatingOriginSeaLevel;
			if (floatingOriginSeaLevel.HasValue && base.transform.position.y < floatingOriginSeaLevel.Value)
			{
				ParticleSystem.EmissionModule emission = base.ParticleSystem.emission;
				emission.enabled = false;
			}
		}
	}
}
