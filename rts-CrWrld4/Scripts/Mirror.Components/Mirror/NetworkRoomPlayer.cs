using System.Runtime.InteropServices;
using UnityEngine;

namespace Mirror
{
	[DisallowMultipleComponent]
	public class NetworkRoomPlayer : NetworkBehaviour
	{
		public bool showRoomGUI;

		[SyncVar]
		public bool readyToBegin;

		[SyncVar]
		public int index;

		public bool NetworkreadyToBegin
		{
			get
			{
				return false;
			}
			[param: In]
			set
			{
			}
		}

		public int Networkindex
		{
			get
			{
				return 0;
			}
			[param: In]
			set
			{
			}
		}

		public void Start()
		{
		}

		public virtual void OnDisable()
		{
		}

		[Command]
		public void CmdChangeReadyState(bool readyState)
		{
		}

		public virtual void IndexChanged(int oldIndex, int newIndex)
		{
		}

		public virtual void ReadyStateChanged(bool oldReadyState, bool newReadyState)
		{
		}

		public virtual void OnClientEnterRoom()
		{
		}

		public virtual void OnClientExitRoom()
		{
		}

		public virtual void OnGUI()
		{
		}

		private void DrawPlayerReadyState()
		{
		}

		private void DrawPlayerReadyButton()
		{
		}

		private void MirrorProcessed()
		{
		}

		public void UserCode_CmdChangeReadyState(bool readyState)
		{
		}

		protected static void InvokeUserCode_CmdChangeReadyState(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static NetworkRoomPlayer()
		{
		}

		public override bool SerializeSyncVars(NetworkWriter writer, bool forceAll)
		{
			return false;
		}

		public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
		}
	}
}
