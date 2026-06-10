using System;
using NSEipix.Model;
using NSMedieval.Model;
using NSMedieval.UI.Utils;

namespace NSMedieval.UI.ScenarioEditor
{
	public class ScenarioEditResourceView : ScenarioEditIntIconView
	{
		protected string ResourceID { get; private set; }

		public new event Action<string, int, ScenarioEditEntryView> ValueChanged;

		public void SetDefaults(Resource resource, IntRange minMaxRange, int currentValue)
		{
			ResourceID = resource.GetID();
			SetDefaults(ResourceUtils.GetIconPath(ResourceID), ResourceUtils.GetIconColor(ResourceID), ResourceUtils.GetLocalizedResourceName(resource), minMaxRange, currentValue);
		}

		protected override void OnInputValueChanged(string value)
		{
			int value2 = ScenarioEditEntryView.Clamp(value, base.MinMaxRange);
			base.IntInput.SetTextWithoutNotify(value2.ToString());
			Notify(value2, ResourceID);
		}

		protected void Notify(int value, string resourceId)
		{
			this.ValueChanged?.Invoke(resourceId, value, this);
		}
	}
}
