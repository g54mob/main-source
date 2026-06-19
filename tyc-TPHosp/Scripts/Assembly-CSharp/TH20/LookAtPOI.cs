using UnityEngine;

namespace TH20
{
	public class LookAtPOI
	{
		private ComponentReference _sourceRef;

		[DontSave]
		private LookAtPOISourceComponent _source;

		private readonly float _radius;

		private readonly float _strength;

		private readonly float _duration;

		public LookAtPOISourceComponent Source => _source;

		public float Duration => _duration;

		public float Radius => _radius;

		public Vector3 Position => _source.LookAtPosition();

		public LookAtPOI(LookAtPOISourceComponent source, float radius, float strength, float duration = float.MaxValue)
		{
			_sourceRef.Component = source;
			_source = source;
			_radius = radius;
			_strength = strength;
			_duration = duration;
		}

		public void RestoreFromSave(EntityManager entityManager)
		{
			_sourceRef.RestoreFromSave(entityManager);
			_source = _sourceRef.Component as LookAtPOISourceComponent;
		}

		public Vector3 GetLookAt(Vector3 from, out float weight)
		{
			Vector3 vector = _source.LookAtPosition();
			weight = Mathf.Max(GetInterest(from), 1f);
			return (vector - from).normalized;
		}

		public virtual float GetInterest(Vector3 from)
		{
			Vector3 b = _source.LookAtPosition();
			float b2 = Vector3.Distance(from, b);
			return (_radius - Mathf.Min(_radius, b2)) / _radius * _strength;
		}

		public bool HasBeenDestroyed()
		{
			if (_source != null)
			{
				return _source.HasBeenDestroyed();
			}
			return true;
		}
	}
}
