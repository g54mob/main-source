using Assets.Scripts.Flight.Cameras;
using Assets.Scripts.Flight.Events;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	public class CannonTracerScript : MonoBehaviour
	{
		private float _frontDistanceFromCamera = 1f;

		private Keyframe _frontKey;

		private float _rearDistanceFromCamera = 1f;

		private Keyframe _rearKey;

		private float _scale;

		private TrailRenderer _tracer;

		private AnimationCurve _widthCurve;

		public bool AutoDestruct
		{
			get
			{
				return _tracer.autodestruct;
			}
			set
			{
				_tracer.autodestruct = value;
			}
		}

		public void Initialize(float length, Color colour, float scale)
		{
			_tracer = GetComponent<TrailRenderer>();
			_scale = scale;
			if (_tracer != null)
			{
				_widthCurve = _tracer.widthCurve;
				_frontKey = _widthCurve.keys[0];
				_rearKey = _widthCurve.keys[1];
				_tracer.time = length;
				_tracer.material.color = colour;
				_tracer.material.SetColor("_EmissionColor", colour);
			}
			GameWorld.Instance.FloatingOriginChanged += OnFloatingOriginChanged;
		}

		protected virtual void OnDestroy()
		{
			GameWorld.Instance.FloatingOriginChanged -= OnFloatingOriginChanged;
		}

		protected virtual void Update()
		{
			if (_tracer != null)
			{
				_frontDistanceFromCamera = 1f;
				_rearDistanceFromCamera = 1f;
				if (_tracer.positionCount > 1)
				{
					_frontDistanceFromCamera = Vector3.Distance(_tracer.GetPosition(_tracer.positionCount - 1), CameraManagerScript.Instance.CameraTransform.position);
					_rearDistanceFromCamera = Vector3.Distance(_tracer.GetPosition(0), CameraManagerScript.Instance.CameraTransform.position);
				}
				_frontKey.value = Mathf.Max(1f, 1f * _frontDistanceFromCamera / (100f * Mathf.Max(1f, _scale))) * _scale;
				_rearKey.value = Mathf.Max(0.95f, 0.95f * _rearDistanceFromCamera / (100f * Mathf.Max(1f, _scale))) * _scale;
				_widthCurve.MoveKey(0, _frontKey);
				_widthCurve.MoveKey(1, _rearKey);
				_tracer.widthCurve = _widthCurve;
			}
		}

		private void OnFloatingOriginChanged(object sender, FloatingOriginChangedEventArgs e)
		{
			if (!(_tracer == null) && base.gameObject.activeInHierarchy)
			{
				Vector3 vector = e.OldFloatingOriginOffset - e.NewFloatingOriginOffset;
				Vector3[] array = new Vector3[_tracer.positionCount];
				_tracer.GetPositions(array);
				for (int i = 0; i < array.Length; i++)
				{
					array[i] += vector;
				}
				_tracer.SetPositions(array);
			}
		}
	}
}
