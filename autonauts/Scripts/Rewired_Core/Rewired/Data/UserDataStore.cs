using System;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired.Data
{
	[RequireComponent(typeof(InputManager_Base))]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public abstract class UserDataStore : MonoBehaviour, IUserDataStore, IControllerMapStore
	{
		private void OnDestroy()
		{
			if (!ReInput.isReady)
			{
				goto IL_0007;
			}
			goto IL_0031;
			IL_0007:
			int num = -211337335;
			goto IL_000c;
			IL_000c:
			switch (num ^ -211337333)
			{
			case 3:
				break;
			case 2:
				return;
			case 1:
				goto IL_0031;
			default:
				ReInput.ControllerDisconnectedEvent -= OnControllerDisconnected;
				ReInput.ControllerPreDisconnectEvent -= OnControllerPreDisconnect;
				return;
			}
			goto IL_0007;
			IL_0031:
			ReInput.ControllerConnectedEvent -= OnControllerConnected;
			num = -211337333;
			goto IL_000c;
		}

		internal void Initialize()
		{
			ReInput.ControllerConnectedEvent += OnControllerConnected;
			while (true)
			{
				int num = -322140512;
				while (true)
				{
					switch (num ^ -322140510)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						ReInput.ControllerDisconnectedEvent += OnControllerDisconnected;
						ReInput.ControllerPreDisconnectEvent += OnControllerPreDisconnect;
						num = -322140509;
						continue;
					case 1:
						OnInitialize();
						num = -322140511;
						continue;
					case 3:
						return;
					}
					break;
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
