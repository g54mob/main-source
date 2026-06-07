using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest
{
	[AddComponentMenu("Crest/Crest Query Events")]
	public sealed class QueryEvents : ManagedBehaviour<WaterRenderer>
	{
		[Tooltip("What transform should the queries be based on.\n\n\"Viewer\" will reuse queries already performed by the Water Renderer")]
		[SerializeField]
		private QuerySource _Source;

		[Tooltip("The viewer as the source of the queries.\n\nOnly needs to be set if using multiple viewpoints on the Water Renderer.")]
		[SerializeField]
		private Camera _Viewer;

		[Tooltip("Which water collision layer to target.")]
		[SerializeField]
		internal CollisionLayer _Layer;

		[Header("Distance From Water Surface")]
		[Tooltip("The minimum wavelength for queries.\n\nThe higher the value, the more smaller waves will be ignored when sampling the water surface.")]
		[SerializeField]
		private float _MinimumWavelength = 1f;

		[Tooltip("Whether to keep the sign of the value (ie positive/negative).\n\nA positive value means the query point is above the surface, while a negative means it below the surface.")]
		[SerializeField]
		private bool _DistanceFromSurfaceSigned;

		[Tooltip("The maximum distance.\n\nAlways use a real distance in real units (ie not normalized).")]
		[FormerlySerializedAs("_MaximumDistance")]
		[SerializeField]
		private float _DistanceFromSurfaceMaximum = 100f;

		[Tooltip("Whether to apply a curve to the distance.\n\nNormalizes and inverts the distance to be between zero and one, then applies a curve.")]
		[FormerlySerializedAs("_NormaliseDistance")]
		[SerializeField]
		private bool _DistanceFromSurfaceUseCurve = true;

		[Tooltip("Apply a curve to the distance.\n\nValues towards \"one\" means closer to the water surface.")]
		[FormerlySerializedAs("_DistanceCurve")]
		[SerializeField]
		private AnimationCurve _DistanceFromSurfaceCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[Header("Distance From Water Edge")]
		[Tooltip("Whether to keep the sign of the value (ie positive/negative).\n\nA positive value means the query point is over water, while a negative means it is over land.")]
		[SerializeField]
		private bool _DistanceFromEdgeSigned;

		[Tooltip("The maximum distance.\n\nAlways use a real distance in real units (ie not normalized).")]
		[SerializeField]
		private float _DistanceFromEdgeMaximum = 100f;

		[Tooltip("Apply a curve to the distance.\n\nNormalizes and inverts the distance to be between zero and one, then applies a curve.")]
		[SerializeField]
		private bool _DistanceFromEdgeUseCurve = true;

		[Tooltip("Apply a curve to the distance.\n\nValues towards \"one\" means closer to the water's edge.")]
		[SerializeField]
		private AnimationCurve _DistanceFromEdgeCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

		[Header("Events")]
		[Tooltip("Triggers when game object goes below water surface.\n\nTriggers once per state change.")]
		[SerializeField]
		private UnityEvent _OnBelowWater = new UnityEvent();

		[Tooltip("Triggers when game object goes above water surface.\n\nTriggers once per state change.")]
		[SerializeField]
		private UnityEvent _OnAboveWater = new UnityEvent();

		[Tooltip("Sends the distance from the water surface.")]
		[FormerlySerializedAs("_DistanceFromWater")]
		[SerializeField]
		internal UnityEvent<float> _DistanceFromSurface = new UnityEvent<float>();

		[Tooltip("Sends the distance from the water's edge.")]
		[SerializeField]
		internal UnityEvent<float> _DistanceFromEdge = new UnityEvent<float>();

		private bool _IsAboveSurface;

		private bool _IsFirstUpdate = true;

		private readonly SampleCollisionHelper _SampleHeightHelper = new SampleCollisionHelper();

		private readonly SampleDepthHelper _SampleDepthHelper = new SampleDepthHelper();

		private bool HasOnBelowWater
		{
			get
			{
				if (OnBelowWater == null)
				{
					return !_OnBelowWater.IsEmpty();
				}
				return true;
			}
		}

		private bool HasOnAboveWater
		{
			get
			{
				if (OnAboveWater == null)
				{
					return !_OnAboveWater.IsEmpty();
				}
				return true;
			}
		}

		private bool HasDistanceFromSurface
		{
			get
			{
				if (DistanceFromSurface == null)
				{
					return !_DistanceFromSurface.IsEmpty();
				}
				return true;
			}
		}

		private bool HasDistanceFromEdge
		{
			get
			{
				if (DistanceFromEdge == null)
				{
					return !_DistanceFromEdge.IsEmpty();
				}
				return true;
			}
		}

		private protected override Action<WaterRenderer> OnUpdateMethod => OnUpdate;

		private protected override Action<WaterRenderer> OnLateUpdateMethod => OnLateUpdate;

		public Action<float> DistanceFromEdge { get; set; }

		public AnimationCurve DistanceFromEdgeCurve
		{
			get
			{
				return _DistanceFromEdgeCurve;
			}
			set
			{
				_DistanceFromEdgeCurve = value;
			}
		}

		public float DistanceFromEdgeMaximum
		{
			get
			{
				return _DistanceFromEdgeMaximum;
			}
			set
			{
				_DistanceFromEdgeMaximum = value;
			}
		}

		public bool DistanceFromEdgeSigned
		{
			get
			{
				return _DistanceFromEdgeSigned;
			}
			set
			{
				_DistanceFromEdgeSigned = value;
			}
		}

		public bool DistanceFromEdgeUseCurve
		{
			get
			{
				return _DistanceFromEdgeUseCurve;
			}
			set
			{
				_DistanceFromEdgeUseCurve = value;
			}
		}

		public Action<float> DistanceFromSurface { get; set; }

		public AnimationCurve DistanceFromSurfaceCurve
		{
			get
			{
				return _DistanceFromSurfaceCurve;
			}
			set
			{
				_DistanceFromSurfaceCurve = value;
			}
		}

		public float DistanceFromSurfaceMaximum
		{
			get
			{
				return _DistanceFromSurfaceMaximum;
			}
			set
			{
				_DistanceFromSurfaceMaximum = value;
			}
		}

		public bool DistanceFromSurfaceSigned
		{
			get
			{
				return _DistanceFromSurfaceSigned;
			}
			set
			{
				_DistanceFromSurfaceSigned = value;
			}
		}

		public bool DistanceFromSurfaceUseCurve
		{
			get
			{
				return _DistanceFromSurfaceUseCurve;
			}
			set
			{
				_DistanceFromSurfaceUseCurve = value;
			}
		}

		public CollisionLayer Layer
		{
			get
			{
				return _Layer;
			}
			set
			{
				_Layer = value;
			}
		}

		public float MinimumWavelength
		{
			get
			{
				return _MinimumWavelength;
			}
			set
			{
				_MinimumWavelength = value;
			}
		}

		public Action OnAboveWater { get; set; }

		public Action OnBelowWater { get; set; }

		public QuerySource Source
		{
			get
			{
				return _Source;
			}
			set
			{
				_Source = value;
			}
		}

		public Camera Viewer
		{
			get
			{
				return _Viewer;
			}
			set
			{
				_Viewer = value;
			}
		}

		private void OnUpdate(WaterRenderer water)
		{
			if (_Source == QuerySource.Transform)
			{
				SendDistanceFromSurface(water);
				SendDistanceFromEdge(water);
			}
		}

		private void OnLateUpdate(WaterRenderer water)
		{
			if (_Source == QuerySource.Viewer)
			{
				SendDistanceFromSurface(water);
				SendDistanceFromEdge(water);
			}
		}

		private void SendDistanceFromSurface(WaterRenderer water)
		{
			if (!HasDistanceFromSurface && !HasOnAboveWater && !HasOnBelowWater)
			{
				return;
			}
			float height = water.ViewerHeightAboveWater;
			if (water.MultipleViewpoints && (_Viewer == null || !water.GetViewerHeightAboveWater(_Viewer, out height)))
			{
				return;
			}
			if (_Source == QuerySource.Transform)
			{
				if (!_SampleHeightHelper.SampleHeight(base.transform.position, out var height2, 2f * _MinimumWavelength, _Layer))
				{
					return;
				}
				height = base.transform.position.y - height2;
			}
			bool flag = height > 0f;
			if (_IsAboveSurface != flag || _IsFirstUpdate)
			{
				_IsAboveSurface = flag;
				_IsFirstUpdate = false;
				if (_IsAboveSurface)
				{
					_OnAboveWater?.Invoke();
					OnAboveWater?.Invoke();
				}
				else
				{
					_OnBelowWater?.Invoke();
					OnBelowWater?.Invoke();
				}
			}
			if (HasDistanceFromSurface)
			{
				height = Mathf.Clamp(height, 0f - _DistanceFromSurfaceMaximum, _DistanceFromSurfaceMaximum);
				if (!_DistanceFromSurfaceSigned || _DistanceFromSurfaceUseCurve)
				{
					height = Mathf.Abs(height);
				}
				if (_DistanceFromSurfaceUseCurve)
				{
					height = _DistanceFromSurfaceCurve.Evaluate(1f - height / _DistanceFromSurfaceMaximum);
				}
				_DistanceFromSurface?.Invoke(height);
				DistanceFromSurface?.Invoke(height);
			}
		}

		private void SendDistanceFromEdge(WaterRenderer water)
		{
			if (!HasDistanceFromEdge)
			{
				return;
			}
			float distance = water.ViewerDistanceToShoreline;
			if ((!water.MultipleViewpoints || (!(_Viewer == null) && water.GetViewerDistanceToShoreline(_Viewer, out distance))) && (_Source != QuerySource.Transform || _SampleDepthHelper.SampleDistanceToWaterEdge(base.transform.position, out distance)))
			{
				distance = Mathf.Clamp(distance, 0f - _DistanceFromEdgeMaximum, _DistanceFromEdgeMaximum);
				if (!_DistanceFromEdgeSigned || _DistanceFromEdgeUseCurve)
				{
					distance = Mathf.Abs(distance);
				}
				if (_DistanceFromEdgeUseCurve)
				{
					distance = _DistanceFromEdgeCurve.Evaluate(1f - distance / _DistanceFromEdgeMaximum);
				}
				_DistanceFromEdge?.Invoke(distance);
				DistanceFromEdge?.Invoke(distance);
			}
		}
	}
}
