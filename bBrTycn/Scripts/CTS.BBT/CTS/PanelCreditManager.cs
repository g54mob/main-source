using UnityEngine;

namespace CTS
{
	public class PanelCreditManager : MonoBehaviour
	{
		public delegate void Credit();

		private UI_ScrollCredit _mainScriptScrolling;

		private Coroutine _creditScroll;

		public static event Credit LaunchCredits;

		public static event Credit QuitCredits;

		private void Awake()
		{
			_mainScriptScrolling = GetComponentInParent<UI_ScrollCredit>();
			_mainScriptScrolling.GetRefChild(this);
		}

		private void OnEnable()
		{
			if (_creditScroll != null)
			{
				_mainScriptScrolling.StopThecoroutine(_creditScroll);
			}
			_creditScroll = _mainScriptScrolling.LaunchCoroutine(_creditScroll);
			PanelCreditManager.LaunchCredits?.Invoke();
		}

		private void OnDisable()
		{
			if (_creditScroll != null)
			{
				_mainScriptScrolling.StopThecoroutine(_creditScroll);
			}
			PanelCreditManager.QuitCredits?.Invoke();
		}

		public void NullCoroutine()
		{
			_creditScroll = null;
		}
	}
}
