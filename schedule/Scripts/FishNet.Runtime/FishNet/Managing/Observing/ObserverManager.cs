using System.Collections.Generic;
using FishNet.Object;
using FishNet.Observing;
using UnityEngine;
using UnityEngine.Serialization;

namespace FishNet.Managing.Observing
{
	[AddComponentMenu("FishNet/Manager/ObserverManager")]
	[DisallowMultipleComponent]
	public sealed class ObserverManager : MonoBehaviour
	{
		[FormerlySerializedAs("_useNetworkLod")]
		[Tooltip("True to use the NetworkLOD system.")]
		[SerializeField]
		private bool _enableNetworkLod;

		[Tooltip("Distance for each level of detal.")]
		[SerializeField]
		private List<float> _levelOfDetailDistances;

		private List<float> _singleLevelOfDetailDistances;

		[SerializeField]
		[Tooltip("True to update visibility for clientHost based on if they are an observer or not.")]
		[FormerlySerializedAs("_setHostVisibility")]
		private bool _updateHostVisibility;

		[Tooltip("Default observer conditions for networked objects.")]
		[SerializeField]
		private List<ObserverCondition> _defaultConditions;

		private NetworkManager _networkManager;

		private uint[] _levelOfDetailIntervals;

		internal byte LevelOfDetailIndex { get; private set; }

		public bool UpdateHostVisibility
		{
			get
			{
				return false;
			}
			private set
			{
			}
		}

		internal bool GetEnableNetworkLod()
		{
			return false;
		}

		internal List<float> GetLevelOfDetailDistances()
		{
			return null;
		}

		internal void InitializeOnce_Internal(NetworkManager manager)
		{
		}

		public void SetUpdateHostVisibility(bool value, HostVisibilityUpdateTypes updateType)
		{
		}

		internal NetworkObserver AddDefaultConditions(NetworkObject nob)
		{
			return null;
		}

		public static byte GetLevelOfDetailInterval(byte lodIndex)
		{
			return 0;
		}

		internal void CalculateLevelOfDetail(uint tick)
		{
		}

		private void ValidateLevelOfDetails()
		{
		}
	}
}
