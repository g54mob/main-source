using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;
using UnityEngine;

namespace Fullscreen.NanoSave.Runtime
{
	[Serializable]
	[Title("Refresh Save Slots UI")]
	[Description("Refreshes the Save Slots UI by reloading the available saves.")]
	[Category("NanoSave/Refresh UI")]
	[Keywords(new string[] { "Refresh", "UI", "Save", "Slots" })]
	[Image(typeof(IconNanoSave), ColorTheme.Type.White)]
	public class InstructionRefreshSaveSlotsUI : Instruction
	{
		[SerializeField]
		private PropertyGetGameObject m_SaveSlotLoader;

		public override string Title => "Refresh Save Slots UI";

		protected override Task Run(Args args)
		{
			GameObject gameObject = m_SaveSlotLoader.Get(args);
			if (gameObject == null)
			{
				return Task.CompletedTask;
			}
			SaveSlotLoaderUI component = gameObject.GetComponent<SaveSlotLoaderUI>();
			if (component == null)
			{
				return Task.CompletedTask;
			}
			component.RefreshUI();
			return Task.CompletedTask;
		}
	}
}
