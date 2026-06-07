using TMPro;
using UnityEngine;

namespace UI
{
	public class ChangeLogItem : MonoBehaviour
	{
		[SerializeField]
		private TMP_Text timeText;

		[SerializeField]
		private TMP_Text titleText;

		[SerializeField]
		private TMP_Text bodyText;

		public void SetText(string title, string body, string updatedTime)
		{
		}
	}
}
