using TMPro;
using UnityEngine;

namespace DV.UIFramework
{
	[RequireComponent(typeof(TMP_Text))]
	public class TMProAddMark : MonoBehaviour
	{
		public const string COLOR = "#58C";

		private TMP_Text tmPro;

		private string originalText = "";

		private string currentMark = "";

		private string currentTag = "";

		private string markColor = "#58C";

		private void Awake()
		{
			tmPro = GetComponent<TMP_Text>();
			if (tmPro == null)
			{
				Debug.LogError("TMProAddMark couldn't find a TMP_Text component, removing self.", base.gameObject);
				Object.Destroy(this);
			}
		}

		private void OnEnable()
		{
			OnTextChanged(tmPro);
			TMPro_EventManager.TEXT_CHANGED_EVENT.Add(OnTextChanged);
		}

		private void OnDisable()
		{
			TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(OnTextChanged);
		}

		private void OnTextChanged(Object obj)
		{
			if (!(obj != tmPro) && (string.IsNullOrEmpty(currentTag) || !tmPro.text.EndsWith(currentTag)))
			{
				originalText = tmPro.text;
				UpdateTextWithMark();
			}
		}

		public void SetMark(string mark)
		{
			currentMark = mark;
			UpdateTextWithMark();
		}

		public void ClearMark()
		{
			currentMark = "";
			UpdateTextWithMark();
		}

		private void UpdateTextWithMark()
		{
			string text = ((string.IsNullOrWhiteSpace(currentMark) || string.IsNullOrWhiteSpace(originalText) || originalText.EndsWith(" ")) ? "" : " ");
			currentTag = (string.IsNullOrWhiteSpace(currentMark) ? "" : (text + "<color=" + markColor + ">" + currentMark + "</color>"));
			string text2 = originalText + currentTag;
			if (!(tmPro.text == text2))
			{
				tmPro.text = text2;
				tmPro.ForceMeshUpdate();
			}
		}
	}
}
