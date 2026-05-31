using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class UI_WorkerMgr_Locator : UI_WorkerMgr_WorkerInfoBase
	{
		[SerializeField]
		[Inject(false)]
		private CTSButton _button;

		private static readonly StringKey _mainCanvasesKey = "MainCanvases";

		public override void Repaint()
		{
		}

		protected override void OnAwake()
		{
			base.OnAwake();
			_button.onClick.AddListener(OnButtonClick);
		}

		private void OnDestroy()
		{
			_button.onClick.RemoveListener(OnButtonClick);
		}

		private void OnButtonClick()
		{
			if ((object)base._worker != null)
			{
				CanvasExclusivity.Close(null, _mainCanvasesKey);
				WorldSelector.SelectObject(base._worker.Selection.SelectableObject);
				MonoSingleton<CameraFollowing>.Instance.EventLock(base._worker.transform);
			}
		}
	}
}
