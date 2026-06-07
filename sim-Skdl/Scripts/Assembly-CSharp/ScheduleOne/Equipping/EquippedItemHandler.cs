using System;
using System.Runtime.CompilerServices;
using FishNet.Component.Ownership;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.Serializing;
using ScheduleOne.Core.Equipping.Framework;
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.Equipping.Framework;
using UnityEngine;

namespace ScheduleOne.Equipping
{
	[RequireComponent(typeof(PredictedSpawn))]
	public class EquippedItemHandler : NetworkBehaviour, IEquippedItemHandler
	{
		[SyncVar]
		public INetworkedEquippableUser _user;

		[SyncVar]
		[HideInInspector]
		public EquippableData _equippableData;

		public SyncVar<INetworkedEquippableUser> syncVar____user;

		public SyncVar<EquippableData> syncVar____equippableData;

		private bool NetworkInitialize___EarlyScheduleOne_002EEquipping_002EEquippedItemHandlerAssembly_002DCSharp_002Edll_Excuted;

		private bool NetworkInitialize__LateScheduleOne_002EEquipping_002EEquippedItemHandlerAssembly_002DCSharp_002Edll_Excuted;

		public IEquippableUser User => null;

		public EquippableData EquippableData => null;

		public bool IsEquipped { get; private set; }

		public INetworkedEquippableUser SyncAccessor__user
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public EquippableData SyncAccessor__equippableData
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		GameObject IEquippedItemHandler.gameObject => null;

		public event Action OnUnequipped
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public virtual void Equipped(IEquippableUser user, EquippableData data)
		{
		}

		public virtual void EquippedWithItem(IEquippableUser user, EquippableData data, BaseItemInstance itemInstance)
		{
		}

		public virtual void Unequipped()
		{
		}

		public override void OnStartClient()
		{
		}

		private void SetupParent()
		{
		}

		protected virtual void SetupThirdPerson()
		{
		}

		protected virtual void SetupFirstPerson()
		{
		}

		protected virtual void Update()
		{
		}

		protected virtual void UserUpdate()
		{
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

		public virtual bool ReadSyncVar___ScheduleOne_002EEquipping_002EEquippedItemHandler(PooledReader PooledReader0, uint UInt321, bool Boolean2)
		{
			return false;
		}

		public virtual void Awake()
		{
		}
	}
}
