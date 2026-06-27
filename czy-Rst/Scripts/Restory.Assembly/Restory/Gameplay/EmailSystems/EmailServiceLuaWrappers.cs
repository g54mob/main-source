using System;
using PixelCrushers.DialogueSystem;
using Restory.AssetManagement;
using Restory.Data.Email;
using Zenject;

namespace Restory.Gameplay.EmailSystems
{
	public class EmailServiceLuaWrappers : IInitializable, IDisposable
	{
		private static class LuaNames
		{
			public static readonly string SendMessageToPlayer = "Email_SendMessageToPlayer";

			public static readonly string HasPlayerSeenMessage = "Email_HasPlayerSeenMessage";

			public static readonly string HasPlayerPressedOkButton = "Email_HasPlayerPressedOkButton";

			public static readonly string HasPlayerPressedYesButton = "Email_HasPlayerPressedYesButton";

			public static readonly string HasPlayerPressedNoButton = "Email_HasPlayerPressedNoButton";
		}

		private EmailService emailService;

		private GameEntityDataBaseProvider gameEntityDataBaseProvider;

		public EmailServiceLuaWrappers(EmailService emailService, GameEntityDataBaseProvider gameEntityDataBaseProvider)
		{
			this.gameEntityDataBaseProvider = gameEntityDataBaseProvider;
			this.emailService = emailService;
		}

		public void Initialize()
		{
			Subscribe();
		}

		public void Dispose()
		{
			Unsubscribe();
		}

		private void Subscribe()
		{
			Lua.RegisterFunction(LuaNames.SendMessageToPlayer, this, SymbolExtensions.GetMethodInfo(() => SendMessageToPlayer(string.Empty, 0f)));
			Lua.RegisterFunction(LuaNames.HasPlayerSeenMessage, this, SymbolExtensions.GetMethodInfo(() => HasPlayerSeenMessage(string.Empty)));
			Lua.RegisterFunction(LuaNames.HasPlayerPressedOkButton, this, SymbolExtensions.GetMethodInfo(() => HasPlayerPressedOkButton(string.Empty)));
			Lua.RegisterFunction(LuaNames.HasPlayerPressedYesButton, this, SymbolExtensions.GetMethodInfo(() => HasPlayerPressedYesButton(string.Empty)));
			Lua.RegisterFunction(LuaNames.HasPlayerPressedNoButton, this, SymbolExtensions.GetMethodInfo(() => HasPlayerPressedNoButton(string.Empty)));
		}

		private void Unsubscribe()
		{
			Lua.UnregisterFunction(LuaNames.SendMessageToPlayer);
			Lua.UnregisterFunction(LuaNames.HasPlayerSeenMessage);
			Lua.UnregisterFunction(LuaNames.HasPlayerPressedOkButton);
			Lua.UnregisterFunction(LuaNames.HasPlayerPressedYesButton);
			Lua.UnregisterFunction(LuaNames.HasPlayerPressedNoButton);
		}

		private void SendMessageToPlayer(string emailMessageID, float minutesBeforeSending)
		{
			if (gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<EmailMessageInfo>(emailMessageID, out var entityInfo))
			{
				emailService.SendEmailMessageToPlayer(entityInfo, minutesBeforeSending, out var _);
			}
		}

		private bool HasPlayerSeenMessage(string emailMessageID)
		{
			if (!gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<EmailMessageInfo>(emailMessageID, out var _))
			{
				return false;
			}
			if (emailService.TryGetNarrativeEmailLetterRecordByID(emailMessageID, out var foundLetterRecord))
			{
				return emailService.WasMessageRead(foundLetterRecord);
			}
			return false;
		}

		private bool HasPlayerPressedOkButton(string emailMessageID)
		{
			if (!gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<EmailMessageInfo>(emailMessageID, out var _))
			{
				return false;
			}
			if (emailService.TryGetNarrativeEmailLetterRecordByID(emailMessageID, out var foundLetterRecord))
			{
				return foundLetterRecord.PressedButton == PressedEmailButtons.OkButton;
			}
			return false;
		}

		private bool HasPlayerPressedYesButton(string emailMessageID)
		{
			if (!gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<EmailMessageInfo>(emailMessageID, out var _))
			{
				return false;
			}
			if (emailService.TryGetNarrativeEmailLetterRecordByID(emailMessageID, out var foundLetterRecord))
			{
				return foundLetterRecord.PressedButton == PressedEmailButtons.YesButton;
			}
			return false;
		}

		private bool HasPlayerPressedNoButton(string emailMessageID)
		{
			if (!gameEntityDataBaseProvider.Asset.TryToGetEntityInfo<EmailMessageInfo>(emailMessageID, out var _))
			{
				return false;
			}
			if (emailService.TryGetNarrativeEmailLetterRecordByID(emailMessageID, out var foundLetterRecord))
			{
				return foundLetterRecord.PressedButton == PressedEmailButtons.NoButton;
			}
			return false;
		}
	}
}
