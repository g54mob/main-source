using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class EntertainerBookingControls3DUIView : MonoBehaviour
	{
		[SerializeField]
		private EntertainerTimeline3DUIView _timeline;

		[SerializeField]
		private BaseInteractable3DUIView _toggleBookingOptionsButton;

		[SerializeField]
		private GameObject _bookingOptionsPanel;

		public Container3DUIView bookingOptionContainer;

		private List<(EntertainerBookingItem3DUIView bookingItem, GameObject placeholder)> _bookingEntries;

		[SerializeField]
		private Transform _middleBacker;

		[SerializeField]
		private Transform _bottomPosition;

		[SerializeField]
		private Transform _bottomBacker;

		[SerializeField]
		private GameObject _placeholderPrefab;

		private void Start()
		{
		}

		private void ToggleBookingOptions()
		{
		}

		public void ShowBookingOptions()
		{
		}

		public void HideBookingOptions()
		{
		}

		public void SetBookingItems(List<EntertainerBookingItem3DUIView> bookingItems)
		{
		}

		private GameObject CreatePlaceholder(EntertainerBookingItem3DUIView bookingItem)
		{
			return null;
		}

		public void ReturnBookingItem(EntertainerBookingItem3DUIView returningItem)
		{
		}

		public void TakeBookingItem(EntertainerBookingItem3DUIView itemToTake)
		{
		}

		public void Enable()
		{
		}

		public void Disable()
		{
		}
	}
}
