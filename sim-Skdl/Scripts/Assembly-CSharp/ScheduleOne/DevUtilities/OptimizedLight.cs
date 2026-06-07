using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

namespace ScheduleOne.DevUtilities
{
	[RequireComponent(typeof(Light))]
	[ExecuteInEditMode]
	public class OptimizedLight : MonoBehaviour
	{
		[FormerlySerializedAs("Enabled")]
		[SerializeField]
		private bool _Enabled;

		[SerializeField]
		[HideInInspector]
		[FormerlySerializedAs("DisabledForOptimization")]
		private bool _DisabledForOptimization;

		[Range(10f, 500f)]
		public float MaxDistance;

		public Light _Light;

		[SerializeField]
		private LensFlareComponentSRP _lensFlare;

		private bool culled;

		private float maxDistanceSquared;

		public bool Enabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool DisabledForOptimization
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void UpdateCull()
		{
		}

		public void SetEnabled(bool enabled)
		{
		}

		private void UpdateLightState()
		{
		}
	}
}
