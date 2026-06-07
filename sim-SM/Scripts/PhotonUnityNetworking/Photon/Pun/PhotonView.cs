using System;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.Serialization;

namespace Photon.Pun
{
	[AddComponentMenu("Photon Networking/Photon View")]
	public class PhotonView : MonoBehaviour
	{
		public enum ObservableSearch
		{
			Manual = 0,
			AutoFindActive = 1,
			AutoFindAll = 2
		}

		private struct CallbackTargetChange
		{
			public IPhotonViewCallback obj;

			public Type type;

			public bool add;

			public CallbackTargetChange(IPhotonViewCallback obj, Type type, bool add)
			{
				this.obj = null;
				this.type = null;
				this.add = false;
			}
		}

		[FormerlySerializedAs("group")]
		public byte Group;

		[FormerlySerializedAs("prefixBackup")]
		public int prefixField;

		internal object[] instantiationDataField;

		protected internal List<object> lastOnSerializeDataSent;

		protected internal List<object> syncValues;

		protected internal object[] lastOnSerializeDataReceived;

		[FormerlySerializedAs("synchronization")]
		public ViewSynchronization Synchronization;

		protected internal bool mixedModeIsReliable;

		[FormerlySerializedAs("ownershipTransfer")]
		public OwnershipOption OwnershipTransfer;

		public ObservableSearch observableSearch;

		public List<Component> ObservedComponents;

		internal MonoBehaviour[] RpcMonoBehaviours;

		[NonSerialized]
		private int ownerActorNr;

		[NonSerialized]
		private int controllerActorNr;

		[SerializeField]
		[FormerlySerializedAs("viewIdField")]
		[HideInInspector]
		public int sceneViewId;

		[NonSerialized]
		private int viewIdField;

		[FormerlySerializedAs("instantiationId")]
		public int InstantiationId;

		[SerializeField]
		[HideInInspector]
		public bool isRuntimeInstantiated;

		protected internal bool removedFromLocalViewList;

		private Queue<CallbackTargetChange> CallbackChangeQueue;

		private List<IOnPhotonViewPreNetDestroy> OnPreNetDestroyCallbacks;

		private List<IOnPhotonViewOwnerChange> OnOwnerChangeCallbacks;

		private List<IOnPhotonViewControllerChange> OnControllerChangeCallbacks;

		public int Prefix
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public object[] InstantiationData
		{
			get
			{
				return null;
			}
			protected internal set
			{
			}
		}

		[Obsolete("Renamed. Use IsRoomView instead")]
		public bool IsSceneView => false;

		public bool IsRoomView => false;

		public bool IsOwnerActive => false;

		public bool IsMine { get; private set; }

		public bool AmController => false;

		public Player Controller { get; private set; }

		public int CreatorActorNr { get; private set; }

		public bool AmOwner { get; private set; }

		public Player Owner { get; private set; }

		public int OwnerActorNr
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int ControllerActorNr
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int ViewID
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		protected internal void Awake()
		{
		}

		internal void ResetPhotonView(bool resetOwner)
		{
		}

		internal void RebuildControllerCache(bool ownerHasChanged = false)
		{
		}

		public void OnPreNetDestroy(PhotonView rootView)
		{
		}

		protected internal void OnDestroy()
		{
		}

		public void RequestOwnership()
		{
		}

		public void TransferOwnership(Player newOwner)
		{
		}

		public void TransferOwnership(int newOwnerId)
		{
		}

		public void FindObservables(bool force = false)
		{
		}

		public void SerializeView(PhotonStream stream, PhotonMessageInfo info)
		{
		}

		public void DeserializeView(PhotonStream stream, PhotonMessageInfo info)
		{
		}

		protected internal void DeserializeComponent(Component component, PhotonStream stream, PhotonMessageInfo info)
		{
		}

		protected internal void SerializeComponent(Component component, PhotonStream stream, PhotonMessageInfo info)
		{
		}

		public void RefreshRpcMonoBehaviourCache()
		{
		}

		public void RPC(string methodName, RpcTarget target, params object[] parameters)
		{
		}

		public void RpcSecure(string methodName, RpcTarget target, bool encrypt, params object[] parameters)
		{
		}

		public void RPC(string methodName, Player targetPlayer, params object[] parameters)
		{
		}

		public void RpcSecure(string methodName, Player targetPlayer, bool encrypt, params object[] parameters)
		{
		}

		public static PhotonView Get(Component component)
		{
			return null;
		}

		public static PhotonView Get(GameObject gameObj)
		{
			return null;
		}

		public static PhotonView Find(int viewID)
		{
			return null;
		}

		public void AddCallbackTarget(IPhotonViewCallback obj)
		{
		}

		public void RemoveCallbackTarget(IPhotonViewCallback obj)
		{
		}

		public void AddCallback<T>(IPhotonViewCallback obj) where T : class
		{
		}

		public void RemoveCallback<T>(IPhotonViewCallback obj) where T : class
		{
		}

		private void UpdateCallbackLists()
		{
		}

		private void TryRegisterCallback<T>(IPhotonViewCallback obj, ref List<T> list, bool add) where T : class
		{
		}

		private void RegisterCallback<T>(T obj, ref List<T> list, bool add) where T : class
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
