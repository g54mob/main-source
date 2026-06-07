using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ModularOptions
{
	[AddComponentMenu("Modular Options/Scroll View On Select")]
	[RequireComponent(typeof(Selectable))]
	public class ScrollViewOnSelect : MonoBehaviour, ISelectHandler, IEventSystemHandler
	{
		[Tooltip("When selected the view will scroll to show this rect. Defaults to itself, but can be changed to include things like labels.")]
		public RectTransform rectToScrollTo;

		[Tooltip("ScrollRect viewport that will be scrolled.")]
		public ScrollRect scrollRect;

		public void OnSelect(BaseEventData _eventData)
		{
		}
	}
}
