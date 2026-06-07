using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class CursorSideCtrl : MonoBehaviour
	{
		[SerializeField]
		private RectTransform mattock;

		[SerializeField]
		private RectTransform timer;

		private RectTransform _menu_Mouse;

		private RectTransform _gamePadGuide;

		private RectTransform _menu_Replace;

		public Image timerImage;

		public TMP_Text timerText;

		private int lastUpdateTimerFrame;

		public bool EnableSettingMenuInfo => false;

		public void SetActive(bool enableMattock = false, bool enableTimer = false, bool enableSettingMenu = false, bool enableBeltReplace = false)
		{
		}

		public void SetPosition(Vector3 position)
		{
		}

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void UpdateTimer(bool enable, double timeNow, double timeMax, bool displayText)
		{
		}

		public void ResetTimer()
		{
		}
	}
}
