using UnityEngine;

namespace Brewery.Calendar
{
	public class CalendarDesyncBanner : MonoBehaviour
	{
		[SerializeField]
		private CalendarManager m_Manager;

		private bool _visible;

		private string _reason;

		private string[] _failingIds;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void HandleDesync(CalendarManager.DesyncReason reason, string[] failingIds)
		{
		}
	}
}
