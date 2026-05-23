using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(MeshFusionSource))]
	public class SourceTracker : MonoBehaviour
	{
		[SerializeField]
		private MeshFusionSource _source;

		[SerializeField]
		private bool _isDynamicObject;

		[SerializeField]
		private Rigidbody _rigidbody;

		private IEnumerable<ICombinedObjectPart> _parts;

		private ISourceTrackingStrategy _trackingStrategy;

		private float _idleTime;

		private Action _updateFunc;

		public bool IsDynamicObject => _isDynamicObject;

		[field: SerializeField]
		public TrackingTarget TrackingTarget { get; set; }

		[field: SerializeField]
		public bool DisableWhenIdle { get; set; } = true;

		[field: SerializeField]
		[field: Min(0.01f)]
		public float MaxIdleTime { get; set; } = 5f;

		[field: SerializeField]
		public bool WakeUpWhenCollision { get; set; } = true;

		[field: SerializeField]
		public bool TrackingDestroy { get; set; } = true;

		public void WakeUp()
		{
			base.enabled = true;
			_idleTime = 0f;
		}

		private void Reset()
		{
			_source = GetComponent<MeshFusionSource>();
			_isDynamicObject = _source is DynamicMeshFusionSource;
			if (TryGetComponent<Rigidbody>(out _rigidbody))
			{
				TrackingTarget = TrackingTarget.Rigidbody;
			}
		}

		private void Awake()
		{
			if (_source == null)
			{
				_source = GetComponent<MeshFusionSource>();
				_isDynamicObject = _source is DynamicMeshFusionSource;
			}
			_source.onCombineFinished += OnCombineFinished;
			base.enabled = false;
		}

		private void Update()
		{
			try
			{
				_updateFunc?.Invoke();
			}
			catch
			{
				if (!_isDynamicObject)
				{
					base.enabled = false;
					return;
				}
				throw;
			}
		}

		private void OnCollisionEnter(Collision collision)
		{
			if (_isDynamicObject && WakeUpWhenCollision && _parts != null)
			{
				WakeUp();
			}
		}

		private void OnDestroy()
		{
			if (!base.gameObject.scene.isLoaded || !TrackingDestroy || _parts == null)
			{
				return;
			}
			foreach (ICombinedObjectPart part in _parts)
			{
				if (part != null && part.Root != null)
				{
					part.Destroy();
				}
			}
		}

		private void OnCombineFinished(MeshFusionSource source, IEnumerable<ICombinedObjectPart> parts)
		{
			_parts = parts;
			_source.onCombineFinished -= OnCombineFinished;
			if (!_isDynamicObject)
			{
				return;
			}
			_updateFunc = UpdateMoveTracker;
			if (TrackingTarget == TrackingTarget.Rigidbody && _rigidbody != null)
			{
				_trackingStrategy = new RigidbodyTrackingStrategy(_rigidbody, parts.Select((ICombinedObjectPart p) => (DynamicCombinedObjectPart)p).ToArray());
				if (DisableWhenIdle)
				{
					_updateFunc = UpdateMoveTrackerAndCheckIdle;
				}
			}
			else
			{
				_trackingStrategy = new TransformTrackingStrategy(base.transform, parts.Select((ICombinedObjectPart p) => (DynamicCombinedObjectPart)p).ToArray());
			}
			base.enabled = true;
		}

		private void UpdateMoveTracker()
		{
			_trackingStrategy.OnUpdate();
		}

		private void UpdateMoveTrackerAndCheckIdle()
		{
			if (_trackingStrategy.OnUpdate())
			{
				_idleTime = 0f;
				return;
			}
			_idleTime += Time.deltaTime;
			if (_idleTime > MaxIdleTime)
			{
				_idleTime = 0f;
				base.enabled = false;
			}
		}
	}
}
