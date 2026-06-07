using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Save Game")]
	[Description("Saves the current state of the game")]
	[Category("Storage/Save Game")]
	[Parameter("Save Slot", "ID number to save the game. It can range between 1 and 9999")]
	[Keywords(new string[] { "Load", "Save", "Profile", "Slot", "Game", "Session" })]
	[Image(typeof(IconDiskSolid), ColorTheme.Type.Green)]
	public class InstructionCommonSaveGame : Instruction
	{
		[SerializeField]
		private PropertyGetInteger m_SaveSlot = new PropertyGetInteger(1);

		public override string Title => $"Save game in slot {m_SaveSlot}";

		protected override async Task Run(Args args)
		{
			int slot = (int)m_SaveSlot.Get(args);
			await Singleton<SaveLoadManager>.Instance.Save(slot);
		}
	}
}
