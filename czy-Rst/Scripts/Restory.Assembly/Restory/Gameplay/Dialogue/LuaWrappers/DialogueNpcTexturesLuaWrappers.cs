using System;
using PixelCrushers.DialogueSystem;
using Restory.Gameplay.NPCs;
using Zenject;

namespace Restory.Gameplay.Dialogue.LuaWrappers
{
	public class DialogueNpcTexturesLuaWrappers : IInitializable, IDisposable
	{
		private static class LuaNames
		{
			public static readonly string SetTexture = "NpcSkins_SetTexture";

			public static readonly string SetDefaultTexture = "NpcSkins_SetDefaultTexture";
		}

		private readonly NpcServiceMain npcServiceMain;

		public DialogueNpcTexturesLuaWrappers(NpcServiceMain npcServiceMain)
		{
			this.npcServiceMain = npcServiceMain;
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
			Lua.RegisterFunction(LuaNames.SetTexture, this, SymbolExtensions.GetMethodInfo(() => SetNpcTexture(string.Empty)));
			Lua.RegisterFunction(LuaNames.SetDefaultTexture, this, SymbolExtensions.GetMethodInfo(() => SetDefaultNpcTexture()));
		}

		private void Unsubscribe()
		{
			Lua.UnregisterFunction(LuaNames.SetTexture);
			Lua.UnregisterFunction(LuaNames.SetDefaultTexture);
		}

		private void SetNpcTexture(string npcTextureID)
		{
			npcServiceMain.ChangeCurrentNpcTexture(npcTextureID);
		}

		private void SetDefaultNpcTexture()
		{
			npcServiceMain.ChangeCurrentNpcTexture(string.Empty);
		}
	}
}
