using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Load Game")]
	[Description("Loads a previously saved state of a game")]
	[Category("Storage/Load Game")]
	[Parameter("Save Slot", "ID number to load the game from. It can range between 1 and 9999")]
	[Keywords(new string[] { "Load", "Save", "Profile", "Slot", "Game", "Session" })]
	[Image(typeof(IconDiskSolid), ColorTheme.Type.Blue)]
	public class InstructionCommonLoadGame : Instruction
	{
		[SerializeField]
		private PropertyGetInteger m_SaveSlot = new PropertyGetInteger(1);

		public override string Title => $"Load game from slot {m_SaveSlot}";

		protected override async Task Run(Args args)
		{
			int slot = (int)m_SaveSlot.Get(args);
			await Singleton<SaveLoadManager>.Instance.Load(slot);
		}
	}
}
