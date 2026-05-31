using System;
using System.Collections.Generic;
using UnityEngine;

namespace Photon.Pun
{
	[AddComponentMenu("Photon Networking/Photon Animator View")]
	public class PhotonAnimatorView : MonoBehaviourPun, IPunObservable
	{
		public enum ParameterType
		{
			Float = 1,
			Int = 3,
			Bool = 4,
			Trigger = 9
		}

		public enum SynchronizeType
		{
			Disabled = 0,
			Discrete = 1,
			Continuous = 2
		}

		[Serializable]
		public class SynchronizedParameter
		{
			public ParameterType Type;

			public SynchronizeType SynchronizeType;

			public string Name;
		}

		[Serializable]
		public class SynchronizedLayer
		{
			public SynchronizeType SynchronizeType;

			public int LayerIndex;
		}

		private bool TriggerUsageWarningDone;

		private Animator m_Animator;

		private PhotonStreamQueue m_StreamQueue;

		[HideInInspector]
		[SerializeField]
		private bool ShowLayerWeightsInspector;

		[HideInInspector]
		[SerializeField]
		private bool ShowParameterInspector;

		[HideInInspector]
		[SerializeField]
		private List<SynchronizedParameter> m_SynchronizeParameters;

		[HideInInspector]
		[SerializeField]
		private List<SynchronizedLayer> m_SynchronizeLayers;

		private Vector3 m_ReceiverPosition;

		private float m_LastDeserializeTime;

		private bool m_WasSynchronizeTypeChanged;

		private List<string> m_raisedDiscreteTriggersCache;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void CacheDiscreteTriggers()
		{
		}

		public bool DoesLayerSynchronizeTypeExist(int layerIndex)
		{
			return false;
		}

		public bool DoesParameterSynchronizeTypeExist(string name)
		{
			return false;
		}

		public List<SynchronizedLayer> GetSynchronizedLayers()
		{
			return null;
		}

		public List<SynchronizedParameter> GetSynchronizedParameters()
		{
			return null;
		}

		public SynchronizeType GetLayerSynchronizeType(int layerIndex)
		{
			return default(SynchronizeType);
		}

		public SynchronizeType GetParameterSynchronizeType(string name)
		{
			return default(SynchronizeType);
		}

		public void SetLayerSynchronized(int layerIndex, SynchronizeType synchronizeType)
		{
		}

		public void SetParameterSynchronized(string name, ParameterType type, SynchronizeType synchronizeType)
		{
		}

		private void SerializeDataContinuously()
		{
		}

		private void DeserializeDataContinuously()
		{
		}

		private void SerializeDataDiscretly(PhotonStream stream)
		{
		}

		private void DeserializeDataDiscretly(PhotonStream stream)
		{
		}

		private void SerializeSynchronizationTypeState(PhotonStream stream)
		{
		}

		private void DeserializeSynchronizationTypeState(PhotonStream stream)
		{
		}

		public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
		{
		}
	}
}
