using System;
using System.Collections.Generic;
using Controllers;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public class PerformCommandRouter : IViewRouter
	{
		private PlayerManager PlayerManager;

		private PlayerPauseManager PauseManager;

		private EntityViewManager EntityViewManager;

		private Dictionary<Type, IHandleStateUpdates> Handlers;

		public PerformCommandRouter(PlayerManager pm, World world)
		{
			PlayerManager = pm;
			PauseManager = world.GetExistingSystem<PlayerPauseManager>();
			EntityViewManager = world.GetExistingSystem<EntityViewManager>();
			UpdateHandlers(world);
		}

		public void BroadcastCommand<T>(T update) where T : ICommandUpdate
		{
			if (update is UserInputUpdate update2)
			{
				PlayerManager.HandleNewInputData(update2);
			}
			if (update is ResponseUpdateCommand responseUpdateCommand)
			{
				if (Handlers.TryGetValue(responseUpdateCommand.HandleType, out var value))
				{
					value.HandleStateUpdate(responseUpdateCommand.ViewSourceIdentifier, responseUpdateCommand.Data);
				}
				else
				{
					Debug.LogError($"No handler for type {responseUpdateCommand.HandleType}");
				}
			}
			if (!(update is ControlCommand controlCommand))
			{
				return;
			}
			switch (controlCommand.Type)
			{
			case CommandType.RequestPause:
				PauseManager.RequestPause(controlCommand.SourceIdentifier);
				break;
			case CommandType.RequestUnpause:
				PauseManager.RequestUnpause(controlCommand.SourceIdentifier);
				break;
			case CommandType.Disconnecting:
				PlayerManager.DisconnectPlayersOfSource(controlCommand.SourceIdentifier);
				break;
			case CommandType.RequestFullRefresh:
				if (controlCommand.SourceIdentifier != InputSourceIdentifier.Identifier)
				{
					EntityViewManager.PerformFullRefresh();
				}
				break;
			}
		}

		private void UpdateHandlers(World world)
		{
			Handlers = new Dictionary<Type, IHandleStateUpdates>();
			foreach (ComponentSystemBase system in world.Systems)
			{
				if (system is IHandleStateUpdates handleStateUpdates)
				{
					Handlers[handleStateUpdates.HandleType] = handleStateUpdates;
				}
			}
		}

		public void BroadcastUpdate<T>(ViewIdentifier e, T data, MessageType type = MessageType.ViewUpdate) where T : IViewData
		{
		}

		public void Update()
		{
		}

		public void Dispose()
		{
		}
	}
}
