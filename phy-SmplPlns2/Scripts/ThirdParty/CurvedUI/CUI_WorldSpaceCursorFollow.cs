using UnityEngine;

namespace CurvedUI
{
	public class CUI_WorldSpaceCursorFollow : MonoBehaviour
	{
		private CurvedUISettings mySettings;

		private void Start()
		{
			mySettings = GetComponentInParent<CurvedUISettings>();
			CurvedUIInputModule.Instance.WorldSpaceMouseInCanvasSpace -= (mySettings.transform as RectTransform).rect.size / 2f;
		}

		private void Update()
		{
			base.transform.localPosition = CurvedUIInputModule.Instance.WorldSpaceMouseInCanvasSpace;
		}
	}
}
