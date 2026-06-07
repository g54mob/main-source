using System.Collections.Generic;
using I18n;
using UnityEngine;

namespace Gh.Tk
{
	public class Header3DUIView : MonoBehaviour
	{
		public List<GameObject> HeaderIcons;

		[SerializeField]
		private TextMeshProI18n _headerText;

		public void SetHeaderIcon(string iconName)
		{
		}

		public void SetHeaderText(string text)
		{
		}
	}
}
