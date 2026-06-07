using System.Collections.Generic;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using UnityEngine;

namespace ScheduleOne.Weather
{
	public class WeatherVolume : NetworkBehaviour
	{
		[SerializeField]
		[Header("Controllers")]
		private List<WeatherEffectController> _effectControllers;

		[Header("Profile")]
		[SerializeField]
		private WeatherProfile _weatherProfile;

		[Header("Debugging & Development")]
		[SerializeField]
		private bool _showGizmos;

		private Vector3 _weatherBounds;

		private Vector3 _volumeSize;

		private Vector3 _blendSize;

		private Vector3 _anchorPosition;

		private float _blendAmount;

		private bool _isInitialized;

		private Vector3 _velocity;

		private bool NetworkInitialize___EarlyScheduleOne_002EWeather_002EWeatherVolumeAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002EWeather_002EWeatherVolumeAssembly_002DCSharp_002Edll_Excuted;

		public float BlendAmount => 0f;

		public Vector3 WeatherBounds => default(Vector3);

		public Vector3 BlendSize => default(Vector3);

		public Vector3 VolumeSize => default(Vector3);

		public Vector3 Center => default(Vector3);

		public Vector3 MinBounds => default(Vector3);

		public Vector3 MaxBounds => default(Vector3);

		public List<WeatherEffectController> EffectControllers => null;

		public WeatherProfile WeatherProfile => null;

		protected Vector3 TopRightBlendCorner => default(Vector3);

		protected Vector3 BottomRightBlendCorner => default(Vector3);

		protected Vector3 TopLeftBlendCorner => default(Vector3);

		protected Vector3 BottomLeftBlendCorner => default(Vector3);

		[ObserversRpc(BufferLast = true, RunLocally = true)]
		public void Initialise(Vector3 weatherBounds, Vector3 volumeSize, Vector3 blendSize, float blendAmount, Vector3 anchorPosition, float heightMapWorldSize)
		{
		}

		private void Update()
		{
		}

		public void SetAnchor(Vector3 anchorPosition)
		{
		}

		public void SetNeighbourVolume(WeatherVolume neighbourVolume)
		{
		}

		public void BlendEffects(float blend, AnimationCurve blendCurve)
		{
		}

		public void SetShaderNumericParameter(string paramater, float value)
		{
		}

		public void SetShaderColorParameter(string paramater, Color value)
		{
		}

		public void SetVisualEffectNumericParameter(string paramater, float value)
		{
		}

		public void UpdateVolume(Vector3 playerPosition, float enclosureBlend)
		{
		}

		public bool IsInRightHalf(Vector3 point)
		{
			return false;
		}

		public Vector2 GetClosestPointOnLeft(Vector3 point)
		{
			return default(Vector2);
		}

		public Vector2 GetClosestPointOnRight(Vector3 point)
		{
			return default(Vector2);
		}

		private void OnDrawGizmos()
		{
		}

		public virtual void NetworkInitialize___Early()
		{
		}

		public virtual void NetworkInitialize__Late()
		{
		}

		public override void NetworkInitializeIfDisabled()
		{
		}

		private void RpcWriter___Observers_Initialise_1999361799(Vector3 weatherBounds, Vector3 volumeSize, Vector3 blendSize, float blendAmount, Vector3 anchorPosition, float heightMapWorldSize)
		{
		}

		public void RpcLogic___Initialise_1999361799(Vector3 weatherBounds, Vector3 volumeSize, Vector3 blendSize, float blendAmount, Vector3 anchorPosition, float heightMapWorldSize)
		{
		}

		private void RpcReader___Observers_Initialise_1999361799(PooledReader PooledReader0, Channel channel)
		{
		}

		public virtual void Awake()
		{
		}
	}
}
