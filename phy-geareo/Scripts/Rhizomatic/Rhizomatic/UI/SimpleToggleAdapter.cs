using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Rhizomatic.UI
{
	public class SimpleToggleAdapter : ToggleAdapter, IPointerClickHandler, IEventSystemHandler
	{
		public GameObject off;

		public GameObject on;

		public Selectable selectable;

		private void Awake()
		{
		}

		public void OnPointerClick(PointerEventData eventData)
		{
		}

		protected override void UpdateView()
		{
		}
	}
}
