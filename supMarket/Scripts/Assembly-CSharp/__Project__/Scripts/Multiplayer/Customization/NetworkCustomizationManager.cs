using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Photon.Pun;
using __Project__.Scripts.Cameras;

namespace __Project__.Scripts.Multiplayer.Customization
{
	public class NetworkCustomizationManager : NoktaSingletonPunCallbacks<NetworkCustomizationManager>
	{
		[CompilerGenerated]
		private sealed class _003CPaintManagerSyncCoroutine_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public NetworkCustomizationManager _003C_003E4__this;

			public string userId;

			private JsonSerializerSettings _003Csettings_003E5__2;

			private int _003CmaxChunkSize_003E5__3;

			private string _003CfloorDataJson_003E5__4;

			private string _003Cchunk_003E5__5;

			private int _003CcurrentCount_003E5__6;

			private int _003CcurrentChunkIndex_003E5__7;

			private List<SaveChunkData> _003Cchunks_003E5__8;

			private int _003CchunkCountToSend_003E5__9;

			private string _003CwallDataJson_003E5__10;

			private int _003Cindex_003E5__11;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CPaintManagerSyncCoroutine_003Ed__4(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private int m_TryCount;

		private int m_TargetChunkCountToReceive;

		private int m_ReceivedChunkCount;

		private List<SaveChunkData> m_ReceivedChunks;

		private string m_ReceivedFloorJson;

		private DoorSwitchCamera m_SwitchCamera;

		public DoorSwitchCamera SwitchCamera => null;

		private void Start()
		{
		}

		private void CustomizationSync_Broadcast(string userId)
		{
		}

		[PunRPC]
		public void CustomizationSync_RPC(string json)
		{
		}

		private void PaintManagerSync_Broadcast(string userId)
		{
		}

		[IteratorStateMachine(typeof(_003CPaintManagerSyncCoroutine_003Ed__4))]
		private IEnumerator PaintManagerSyncCoroutine(string userId)
		{
			return null;
		}

		[PunRPC]
		public void StartGettingPaintManagerFloorData_RPC(int chunkCount)
		{
		}

		[PunRPC]
		public void GetPaintManagerFloorData_RPC(int chunkIndex, string jsonChunk)
		{
		}

		public void PaintManagerFloorSync(string floorJson)
		{
		}

		[PunRPC]
		public void PaintManagerWallsSyncTry_RPC(string wallJson)
		{
		}

		private void PaintManagerWallsSync(string wallDataJson)
		{
		}

		public void ApproveStoreName_Broadcast(NameCustomizationData data)
		{
		}

		[PunRPC]
		public void ApproveStoreName_RPC(string nameDataJson)
		{
		}

		public void SelectDoorPosition_Broadcast(int index)
		{
		}

		[PunRPC]
		public void SelectDoorPosition_RPC(int index)
		{
		}

		public void ChangeEntranceVariant_Broadcast(int currentEntranceID)
		{
		}

		[PunRPC]
		public void ChangeEntranceVariant_RPC(int currentEntranceID)
		{
		}
	}
}
