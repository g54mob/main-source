using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;

namespace Photon.Pun.Demo.Procedural
{
	public class Cluster : MonoBehaviourPunCallbacks
	{
		private string propertiesKey;

		private Dictionary<int, float> propertiesValue;

		public int ClusterId { get; set; }

		public Dictionary<int, GameObject> Blocks { get; private set; }

		public void Awake()
		{
		}

		private void Start()
		{
		}

		public void AddBlock(int blockId, GameObject block)
		{
		}

		public void DestroyCluster()
		{
		}

		public void DecreaseBlockHeight(int blockId)
		{
		}

		public void IncreaseBlockHeight(int blockId)
		{
		}

		public void SetBlockHeightRemote(int blockId, float height)
		{
		}

		private void SetBlockHeightLocal(int blockId, float height)
		{
		}

		private void UpdateRoomProperties(int blockId, float height)
		{
		}

		private void RemoveClusterFromRoomProperties()
		{
		}

		public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
		{
		}
	}
}
