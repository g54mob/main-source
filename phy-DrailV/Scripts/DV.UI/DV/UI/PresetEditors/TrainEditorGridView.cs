using System;
using DV.Scenarios.Common;
using DV.ThingTypes;
using DV.UIFramework;

namespace DV.UI.PresetEditors
{
	public class TrainEditorGridView : AGridView<ICar>
	{
		public Func<TrainCarLivery, bool> IsLiveryUnlocked { get; set; } = (TrainCarLivery _) => true;
	}
}
