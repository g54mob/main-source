using System;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired.Data
{
	[CustomClassObfuscation]
	public abstract class UserDataStore : MonoBehaviour, IUserDataStore, IControllerMapStore
	{
		private void OnDestroy()
		{
		}

		internal void Initialize()
		{
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

		[Obsolete]
		protected virtual void OnControllerPreDiscconnect(ControllerStatusChangedEventArgs args)
		{
		}

		protected virtual void OnControllerPreDisconnect(ControllerStatusChangedEventArgs args)
		{
		}
	}
}
