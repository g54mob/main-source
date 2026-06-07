using System.Collections;
using UnityEngine;

namespace Assets.Scripts.GuiNew
{
	public class UIInfo : MonoBehaviour
	{
		private int _countdownToFalse;

		public bool IsInteracting { get; private set; }

		public static UIInfo Create()
		{
			UIInfo uIInfo = Game.Instance.PersistentScriptsContainer.AddComponent<UIInfo>();
			uIInfo.Initialize();
			return uIInfo;
		}

		public void SetIsInteracting()
		{
			_countdownToFalse = 1;
			IsInteracting = true;
		}

		protected virtual void OnEnable()
		{
			StartCoroutine(EndOfFrame());
		}

		private IEnumerator EndOfFrame()
		{
			WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
			while (true)
			{
				yield return waitForEndOfFrame;
				if (_countdownToFalse <= 0)
				{
					IsInteracting = false;
				}
				_countdownToFalse = Mathf.Max(0, _countdownToFalse - 1);
			}
		}

		private void Initialize()
		{
		}
	}
}
