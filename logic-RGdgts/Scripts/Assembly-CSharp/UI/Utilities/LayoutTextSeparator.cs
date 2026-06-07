using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Utilities
{
	public class LayoutTextSeparator : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI text;

		[SerializeField]
		private Image separatorRight;

		[SerializeField]
		private Image separatorLeft;

		private int delta;

		private IEnumerator waitCo;

		public void SetSize()
		{
		}

		public void Set()
		{
		}

		private IEnumerator WaitSizeCO()
		{
			return null;
		}
	}
}
