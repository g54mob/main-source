using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.State;
using NSMedieval.StatsSystem;
using NSMedieval.UI.Utils;

namespace NSMedieval.UI
{
	public class AttributeLayoutItemView : LayoutGroupItemView
	{
		private readonly int decreaseButtonIndex = 3;

		private readonly int increaseButtonIndex = 2;

		private const float ModificationStep = 100f;

		private readonly int titleIndex;

		private readonly int valueIndex = 1;

		private AttributeInstance attribute;

		private CreatureBase creatureBase;

		private AttributeTooltipView tooltipView;

		public AttributeTooltipView TooltipView => tooltipView = ((tooltipView == null) ? base.gameObject.GetComponent<AttributeTooltipView>() : tooltipView);

		private SoundButton IncreaseButton => base.GroupItems[increaseButtonIndex].GetComponent<SoundButton>();

		private SoundButton DecreaseButton => base.GroupItems[decreaseButtonIndex].GetComponent<SoundButton>();

		private void Start()
		{
			IncreaseButton.gameObject.SetActive(value: false);
			DecreaseButton.gameObject.SetActive(value: false);
		}

		public void SetGroup(string localizedGroup, int index)
		{
			attribute = null;
			creatureBase = null;
			SetText(titleIndex, "<style=\"AlmEntrySubtitle\">" + localizedGroup + "</style>");
			SetText(valueIndex, string.Empty);
			SetBackground(index);
			OnDevToolsActive(active: false);
		}

		public void SetStatData(AttributeLocalized attribute, CreatureBase creature, int index)
		{
			creatureBase = creature;
			TooltipView.SetTooltipData(attribute.Attribute.Blueprint.GetID(), creature);
			SetStatData(attribute, index);
		}

		private void SetStatData(AttributeLocalized attribute, int index)
		{
			this.attribute = attribute.Attribute;
			SetText(titleIndex, "<indent=10%><style=\"Normal\">" + attribute.LocalizedName + "</style></indent>");
			SetText(valueIndex, attribute.LocalizedValue);
			SetBackground(index);
			OnDevToolsActive(MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.DevTools);
		}

		private void OnDevToolsActive(bool active)
		{
		}

		private void OnClickModifyValue(int sign)
		{
		}
	}
}
