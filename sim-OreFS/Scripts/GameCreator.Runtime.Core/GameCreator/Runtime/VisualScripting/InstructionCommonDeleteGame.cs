using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 1, 1)]
	[Title("Delete Game")]
	[Description("Deletes a previously saved game state")]
	[Category("Storage/Delete Game")]
	[Parameter("Save Slot", "Slot number that is erased. Default is 1")]
	[Keywords(new string[] { "Load", "Save", "Delete", "Profile", "Slot", "Game", "Session" })]
	[Image(typeof(IconDiskOutline), ColorTheme.Type.Red, typeof(OverlayCross))]
	public class InstructionCommonDeleteGame : Instruction
	{
		[SerializeField]
		private PropertyGetInteger m_SaveSlot = new PropertyGetInteger(1);

		public override string Title => $"Delete game from slot {m_SaveSlot}";

		protected override async Task Run(Args args)
		{
			int slot = (int)m_SaveSlot.Get(args);
			await Singleton<SaveLoadManager>.Instance.Delete(slot);
		}
	}
}
