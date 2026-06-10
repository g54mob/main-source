using System;
using NSEipix.Model;
using NSMedieval.UI.Utils;

namespace NSMedieval.UI.ScenarioEditor
{
	public class ScenarioEditStructurePileView : ScenarioEditIntIconView
	{
		public string StructurePileID { get; private set; }

		public new event Action<string, int, ScenarioEditEntryView> ValueChanged;

		public void SetDefaults(string id, IntRange minMaxRange, int currentValue)
		{
			StructurePileID = id;
			SetDefaults(BuildingUtils.GetIconPath(id), BuildingUtils.GetIconPath(id), BuildingUtils.GetLocalizedName(id), minMaxRange, currentValue);
		}

		protected override void OnInputValueChanged(string value)
		{
			int value2 = ScenarioEditEntryView.Clamp(value, base.MinMaxRange);
			base.IntInput.SetTextWithoutNotify(value2.ToString());
			Notify(value2, StructurePileID);
		}

		protected void Notify(int value, string resourceId)
		{
			this.ValueChanged?.Invoke(resourceId, value, this);
		}
	}
}
