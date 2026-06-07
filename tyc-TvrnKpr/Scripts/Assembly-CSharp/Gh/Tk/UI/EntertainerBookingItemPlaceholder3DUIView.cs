using System.Collections.Generic;
using I18n;
using TMPro;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class EntertainerBookingItemPlaceholder3DUIView : MonoBehaviour
	{
		[SerializeField]
		private Container3DUIView _starsContainer;

		[SerializeField]
		private List<GameObject> _stars;

		[SerializeField]
		private TextMeshProI18n _nameText;

		[SerializeField]
		private TextMeshPro _costText;

		public void SetData(EntertainerProfile profile)
		{
		}
	}
}
