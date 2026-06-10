using System;
using NSEipix.View.UI;
using UnityEngine.Events;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class ObjectiveSelectLayoutItemView : LayoutGroupItemView
	{
		private readonly int toggleIndex = 1;

		private UnityAction<string, bool> onToggle;

		private string id;

		[NonSerialized]
		private CustomToggle toggle;

		public Image Background => GetComponent<Image>();

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

		public void SetData(string id, string nameText, string descText, bool selected, UnityAction<string, bool> toggleCallback)
		{
			this.id = id;
			SetText(nameText);
			Toggle.SetIsOnWithoutNotify(selected);
			onToggle = toggleCallback;
			base.TooltipNew.ClearLines();
			base.TooltipNew.AppendLine(nameText, TooltipStyles.TooltipTitle);
			base.TooltipNew.AppendLine(descText, TooltipStyles.TooltipDescriptionLine);
		}

		private void Start()
		{
			Toggle.onValueChanged.AddListener(OnToggleValueChanged);
		}

		private void OnToggleValueChanged(bool isOn)
		{
			onToggle?.Invoke(id, isOn);
		}
	}
}
