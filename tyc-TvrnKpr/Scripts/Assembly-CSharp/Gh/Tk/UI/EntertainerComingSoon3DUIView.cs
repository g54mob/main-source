using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class EntertainerComingSoon3DUIView : MonoBehaviour
	{
		[SerializeField]
		private List<EntertainerListing3DUIView> _listings;

		[SerializeField]
		private TMP_Text _moreText;

		public void SetData(List<BookedEntertainerEvent> upcomingEvents)
		{
		}
	}
}
