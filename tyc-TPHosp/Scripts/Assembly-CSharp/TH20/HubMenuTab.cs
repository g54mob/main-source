using TH20.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TH20
{
	public class HubMenuTab : MonoBehaviour, IPointerDownHandler, IEventSystemHandler
	{
		[SerializeField]
		private DynamicButton _tabButton;

		[SerializeField]
		private float _tabWidthOffset;

		private HubMenuTabs _hubMenuTabs;

		public float TabWidthOffset => _tabWidthOffset;

		protected void Start()
		{
			if (_tabButton != null)
			{
				_tabButton.onPrimaryDown.AddListener(OnButtonIconClick);
			}
		}

		private void OnButtonIconClick()
		{
			if (_hubMenuTabs != null)
			{
				_hubMenuTabs.ToggleTab(this);
			}
		}

		public void AssignHubMenuTabs(HubMenuTabs hubMenuTabs)
		{
			_hubMenuTabs = hubMenuTabs;
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			_hubMenuTabs.ToggleTab(this);
		}
	}
}
