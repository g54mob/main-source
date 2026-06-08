using System.Collections.Generic;
using Controllers;
using Platforms;
using UnityEngine;

namespace Kitchen
{
	public class LocalInputRouter : IViewRouter
	{
		public IViewRouter InputTarget;

		private Dictionary<(SourceIdentifier id, int user), (float time, InputState state)> PreviousUpdates = new Dictionary<(SourceIdentifier, int), (float, InputState)>();

		public LocalInputRouter(IViewRouter target)
		{
			InputTarget = target;
		}

		private void EnsurePlayer(int player_id)
		{
			if (Players.Main.Has(player_id))
			{
				return;
			}
			if (!PlatformSettings.UseAdvancedProfilesMode)
			{
				PlatformUser platformUser = InputSourceIdentifier.Default.GetPlatformUser(player_id);
				if (platformUser.IsValidUser)
				{
					PlayerProfile playerProfile = ProfileAccessor.EnsureProfile(platformUser);
					Players.Main.AddLocalPlayer(player_id, playerProfile.Identifier);
					return;
				}
			}
			Players.Main.AddLocalPlayer(player_id);
		}

		private void RemovePlayer(int player_id)
		{
			Players.Main.RemoveLocalPlayer(player_id);
		}

		public void BroadcastCommand<T>(T update) where T : ICommandUpdate
		{
			if (update is UserInputUpdate userInputUpdate)
			{
				if (userInputUpdate.Data.State.Request == GameStateRequest.Disconnect)
				{
					RemovePlayer(userInputUpdate.Data.User);
				}
				else if (userInputUpdate.Data.State.IsAnyButtonHeldOrPressed)
				{
					EnsurePlayer(userInputUpdate.Data.User);
					Players.Main.ApplyBindings(userInputUpdate.Data.User);
				}
				(SourceIdentifier, int) key = (userInputUpdate.SourceIdentifier, userInputUpdate.Data.User);
				if (PreviousUpdates.TryGetValue(key, out (float, InputState) value) && Time.realtimeSinceStartup - value.Item1 < 1f && value.Item2.ApproximatelyEqual(userInputUpdate.Data.State))
				{
					return;
				}
				PreviousUpdates[key] = (Time.realtimeSinceStartup, userInputUpdate.Data.State);
			}
			InputTarget?.BroadcastCommand(update);
		}

		public void Update()
		{
			foreach (PlatformUser localUser in Players.Main.LocalUsers)
			{
				int userID = InputSourceIdentifier.Default.GetUserID(localUser);
				ProfileFlags flags = Players.Main.Get(userID).Profile.Flags;
				InputSourceIdentifier.Default.SetActHoldMode(userID, (flags & ProfileFlags.UseActHoldMode) != 0);
			}
		}

		public void BroadcastUpdate<T>(ViewIdentifier id, T data, MessageType type = MessageType.ViewUpdate) where T : IViewData
		{
		}

		public void Dispose()
		{
		}
	}
}
