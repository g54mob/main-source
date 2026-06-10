using NSEipix.Base;
using NSEipix.View.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class ScheduleHourLayoutItemView : LayoutGroupItemView, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		public delegate void HourButton(SoundButton button);

		private int button;

		private int hoverImage = 1;

		private SoundButton Button => base.GroupItems[button].GetComponent<SoundButton>();

		public void OnPointerEnter(PointerEventData eventData)
		{
			base.GroupItems[hoverImage].SetActive(value: true);
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				MonoSingleton<UIController>.Instance.OnScheduleHourButtonHover(base.transform.position, enabled: true);
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			base.GroupItems[hoverImage].SetActive(value: false);
			if (MonoSingleton<UIController>.IsInstantiated())
			{
				MonoSingleton<UIController>.Instance.OnScheduleHourButtonHover(base.transform.position, enabled: true);
			}
		}

		public void SetHoverColor(Color color)
		{
			base.GroupItems[hoverImage].GetComponent<Image>().color = color;
		}
	}
}
