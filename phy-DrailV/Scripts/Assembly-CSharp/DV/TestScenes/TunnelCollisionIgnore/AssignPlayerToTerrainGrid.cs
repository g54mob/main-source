using DV.TerrainSystem;
using DV.Utils;
using UnityEngine;

namespace DV.TestScenes.TunnelCollisionIgnore
{
	public class AssignPlayerToTerrainGrid : MonoBehaviour
	{
		private void Awake()
		{
			if ((bool)PlayerManager.PlayerTransform)
			{
				SetPlayer();
			}
			else
			{
				PlayerManager.PlayerChanged += SetPlayer;
			}
		}

		private void SetPlayer()
		{
			SingletonBehaviour<TerrainGrid>.Instance.trackingReference = PlayerManager.PlayerTransform;
			PlayerManager.PlayerChanged -= SetPlayer;
			Object.Destroy(this);
		}

		private void OnDestroy()
		{
			PlayerManager.PlayerChanged -= SetPlayer;
		}
	}
}
