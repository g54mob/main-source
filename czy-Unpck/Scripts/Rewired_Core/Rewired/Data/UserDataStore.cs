using System;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired.Data
{
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	[RequireComponent(typeof(InputManager_Base))]
	public abstract class UserDataStore : MonoBehaviour, IUserDataStore, IControllerMapStore
	{
		private void OnDestroy()
		{
			if (!ReInput.isReady)
			{
				while (true)
				{
					switch (-1760218903 ^ -1760218901)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			ReInput.ControllerConnectedEvent -= OnControllerConnected;
			ReInput.ControllerDisconnectedEvent -= OnControllerDisconnected;
			ReInput.ControllerPreDisconnectEvent -= OnControllerPreDisconnect;
		}

		internal void Initialize()
		{
			ReInput.ControllerConnectedEvent += OnControllerConnected;
			while (true)
			{
				int num = 355051430;
				while (true)
				{
					switch (num ^ 0x1529A7A4)
					{
					case 0:
						break;
					case 2:
						goto IL_0030;
					default:
						ReInput.ControllerPreDisconnectEvent += OnControllerPreDisconnect;
						OnInitialize();
						return;
					}
					break;
					IL_0030:
					ReInput.ControllerDisconnectedEvent += OnControllerDisconnected;
					num = 355051429;
				}
			}
		}

		public abstract void Load();

		public abstract void LoadControllerData(int playerId, ControllerType controllerType, int controllerId);

		public abstract void LoadControllerData(ControllerType controllerType, int controllerId);

		public abstract void LoadPlayerData(int playerId);

		public abstract void LoadInputBehavior(int playerId, int behaviorId);

		public abstract void Save();

		public abstract void SaveControllerData(int playerId, ControllerType controllerType, int controllerId);

		public abstract void SaveControllerData(ControllerType controllerType, int controllerId);

		public abstract void SavePlayerData(int playerId);

		public abstract void SaveInputBehavior(int playerId, int behaviorId);

		public virtual void SaveControllerMap(int playerId, ControllerMap controllerMap)
		{
		}

		public virtual ControllerMap LoadControllerMap(int playerId, ControllerIdentifier controllerIdentifier, int categoryId, int layoutId)
		{
			return null;
		}

		protected abstract void OnInitialize();

		protected abstract void OnControllerConnected(ControllerStatusChangedEventArgs args);

		protected abstract void OnControllerDisconnected(ControllerStatusChangedEventArgs args);

		[Obsolete("This method is deprecated and will be removed in a future version. Use OnControllerPreDisconnect instead.", false)]
		protected virtual void OnControllerPreDiscconnect(ControllerStatusChangedEventArgs args)
		{
		}

		protected virtual void OnControllerPreDisconnect(ControllerStatusChangedEventArgs args)
		{
			OnControllerPreDiscconnect(args);
		}
	}
}
