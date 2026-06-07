using System;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.VisualScripting;

namespace Fullscreen.NanoSave.Runtime
{
	[Serializable]
	[Title("On Corrupted Save Detected")]
	[Category("NanoSave/On Corrupted Save Detected")]
	[Description("Triggers when a corrupted save file is detected by NanoSave.")]
	[Image(typeof(IconNanoSave), ColorTheme.Type.White)]
	[Keywords(new string[] { "Save", "Corrupt", "NanoSave" })]
	public class EventOnCorruptedSaveDetected : Event
	{
		protected override void OnEnable(Trigger trigger)
		{
			NanoSave.OnCorruptedSaveDetected += HandleCorruptedSave;
		}

		protected override void OnDisable(Trigger trigger)
		{
			NanoSave.OnCorruptedSaveDetected -= HandleCorruptedSave;
		}

		private void HandleCorruptedSave()
		{
			m_Trigger.Execute(base.Self);
		}
	}
}
