using System.Collections.Generic;
using UnityEngine;

namespace Photon.Pun.UtilityScripts
{
	[RequireComponent(typeof(PhotonView))]
	public class CullingHandler : MonoBehaviour, IPunObservable
	{
		private int orderIndex;

		private CullArea cullArea;

		private List<byte> previousActiveCells;

		private List<byte> activeCells;

		private PhotonView pView;

		private Vector3 lastPosition;

		private Vector3 currentPosition;

		private float timeSinceUpdate;

		private float timeBetweenUpdatesMin;

		private void OnEnable()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void OnGUI()
		{
		}

		private bool HaveActiveCellsChanged()
		{
			return false;
		}

		private void UpdateInterestGroups()
		{
		}

		public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
		{
		}
	}
}
