using Libs;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
	public class BlockRaycasterCtrl : SingletonMonoBehaviour<BlockRaycasterCtrl>
	{
		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private float delay;

		private void Awake()
		{
		}

		public void UntouchableTimer(UnityAction callback, UnityAction initAction = null, float? delayArg = null)
		{
		}
	}
}
