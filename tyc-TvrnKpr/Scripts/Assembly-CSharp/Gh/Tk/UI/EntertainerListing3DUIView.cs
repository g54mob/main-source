using System.Collections.Generic;
using I18n;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class EntertainerListing3DUIView : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProI18n _nameText;

		[SerializeField]
		private TextMeshProI18n _timeText;

		[SerializeField]
		private List<GameObject> _stars;

		public void SetData(string entertainerNameKey, string timeKey, int stars)
		{
		}
	}
}
