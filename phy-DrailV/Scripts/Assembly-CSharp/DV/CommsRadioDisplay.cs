using System.Collections;
using TMPro;
using UnityEngine;

namespace DV
{
	public class CommsRadioDisplay : MonoBehaviour
	{
		public TextMeshPro title;

		public TextMeshPro content;

		public TextMeshPro action;

		private bool finishedSetupHack = true;

		private IEnumerator Start()
		{
			finishedSetupHack = false;
			title.gameObject.SetActive(value: false);
			content.gameObject.SetActive(value: false);
			action.gameObject.SetActive(value: false);
			yield return null;
			title.gameObject.SetActive(value: true);
			content.gameObject.SetActive(value: true);
			action.gameObject.SetActive(value: true);
			finishedSetupHack = true;
		}

		private void OnEnable()
		{
			if (!finishedSetupHack)
			{
				title.gameObject.SetActive(value: true);
				content.gameObject.SetActive(value: true);
				action.gameObject.SetActive(value: true);
				finishedSetupHack = true;
			}
		}

		public void SetDisplay(string title, string content = "", string action = "", FontStyles contentStyle = FontStyles.UpperCase)
		{
			this.title.text = title;
			this.content.fontStyle = contentStyle;
			this.content.text = content;
			this.action.text = action;
		}

		public void SetContentAndAction(string content, string action = "", FontStyles contentStyle = FontStyles.UpperCase)
		{
			this.content.fontStyle = contentStyle;
			this.content.text = content;
			this.action.text = action;
		}

		public void SetContent(string content, FontStyles contentStyle = FontStyles.UpperCase)
		{
			this.content.fontStyle = contentStyle;
			this.content.text = content;
		}

		public void SetAction(string action)
		{
			this.action.text = action;
		}
	}
}
