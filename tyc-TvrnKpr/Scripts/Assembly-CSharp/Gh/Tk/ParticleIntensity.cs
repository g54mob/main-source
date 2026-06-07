using UnityEngine;

namespace Gh.Tk
{
	public class ParticleIntensity : MonoBehaviour
	{
		public float intensity;

		public bool size;

		public bool size3D;

		public bool rate;

		public bool randomRate;

		public AnimationCurve randomRateCurve;

		public Vector2 randomRateStart;

		public Vector2 randomRateEnd;

		public bool emitterShapeScale;

		public bool life;

		public bool force;

		public bool speed;

		public AnimationCurve sizeCurve;

		public AnimationCurve rateCurve;

		public AnimationCurve shapeScaleXCurve;

		public AnimationCurve shapeScaleYCurve;

		public AnimationCurve shapeScaleZCurve;

		public AnimationCurve lifetimeMaxCurve;

		public AnimationCurve forceOverLifeCurve;

		public AnimationCurve speedCurve;

		private ParticleSystem ps;

		private float sizeMin;

		private float sizeMax;

		private float rateMin;

		private float rateMax;

		private float lifeMin;

		private float lifeMax;

		public AnimationCurve size3DCurve;

		public Vector3 sizeStart3DMin;

		public Vector3 sizeStart3DMax;

		public Vector3 sizeEnd3DMin;

		public Vector3 sizeEnd3DMax;

		private Vector3 shapeScale;

		private float forceOverLifeMinY;

		private float forceOverLifeMaxY;

		private ParticleSystem.EmissionModule emissionModule;

		public void Start()
		{
		}

		public void Update()
		{
		}

		public void SetIntensity(float intensity)
		{
		}
	}
}
