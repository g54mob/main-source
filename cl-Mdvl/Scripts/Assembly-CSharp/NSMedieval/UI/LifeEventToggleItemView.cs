using NSEipix.View.UI;
using NSMedieval.Enums;
using UnityEngine.Events;

namespace NSMedieval.UI
{
	public class LifeEventToggleItemView : LayoutGroupItemView
	{
		private readonly int textIndex;

		private readonly int toggleIndex = 1;

		private CustomToggle toggle;

		public LifeEventType LifeEventType { get; private set; }

		public CustomToggle Toggle
		{
			get
			{
				if (toggle == null)
				{
					toggle = base.GroupItems[toggleIndex].GetComponent<CustomToggle>();
				}
				return toggle;
			}
		}

		public void SetData(LifeEventType type, UnityAction<bool> toggleCallback)
		{
			LifeEventType = type;
			SetText(textIndex, base.Localize.GetText($"life_event_type_{LifeEventType}"));
			Toggle.SetIsOnWithoutNotify(value: true);
			Toggle.onValueChanged.AddListener(toggleCallback);
		}
	}
}
