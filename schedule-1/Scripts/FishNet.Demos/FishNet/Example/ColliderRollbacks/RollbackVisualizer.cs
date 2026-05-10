using System.Collections.Generic;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Object;
using FishNet.Serializing;
using FishNet.Transporting;
using UnityEngine;

namespace FishNet.Example.ColliderRollbacks
{
	public class RollbackVisualizer : NetworkBehaviour
	{
		[SerializeField]
		private GameObject _originalPrefab;

		[SerializeField]
		private GameObject _rollbackPrefab;

		[SerializeField]
		private TextCanvas _textCanvasPrefab;

		private List<float> _accuracyAverage;

		private bool NetworkInitialize___EarlyFishNet_002EExample_002EColliderRollbacks_002ERollbackVisualizerFishNet_002EDemos_002Edll_Excuted;

		private bool NetworkInitialize__LateFishNet_002EExample_002EColliderRollbacks_002ERollbackVisualizerFishNet_002EDemos_002Edll_Excuted;

		private void OnDisable()
		{
		}

		[Server]
		public void ShowDifference(NetworkObject clientObject, Vector3 original, Vector3 rolledBack)
		{
		}

		[TargetRpc]
		private void TargetShowDifference(NetworkConnection conn, Vector3 original, Vector3 rollback)
		{
		}

		private string PrintAverage(bool fromServer, float difference, NetworkManager nm)
		{
			return null;
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

		private void RpcWriter___Target_TargetShowDifference_2390343144(NetworkConnection conn, Vector3 original, Vector3 rollback)
		{
		}

		private void RpcLogic___TargetShowDifference_2390343144(NetworkConnection conn, Vector3 original, Vector3 rollback)
		{
		}

		private void RpcReader___Target_TargetShowDifference_2390343144(PooledReader PooledReader0, Channel channel)
		{
		}

		public virtual void Awake()
		{
		}
	}
}
