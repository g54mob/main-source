using System.Collections.Generic;
using MyBox;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace __Project__.Scripts.Multiplayer
{
	public class NetworkWholeSaleOfferCanvas : MonoBehaviourPunCallbacks
	{
		private PhotonView m_PhotonView;

		[Separator("Vote Icons", false)]
		[SerializeField]
		private List<Image> m_AcceptVotes;

		[SerializeField]
		private List<Image> m_DeclineVotes;

		public Dictionary<string, bool?> votes;

		public int ViewId => 0;

		public string UserId => null;

		public PhotonView PhotonView => null;

		private void Awake()
		{
		}

		public void Vote_Request(string userId, bool vote)
		{
		}

		[PunRPC]
		public void Vote_Response(string userId, bool vote)
		{
		}

		[PunRPC]
		public void Vote_RPC(string userId, bool vote)
		{
		}

		public void ResetVotes()
		{
		}

		public void FinishVotes()
		{
		}

		public void UpdateVoteIcons()
		{
		}

		[PunRPC]
		public void ResetVoteIcons()
		{
		}
	}
}
