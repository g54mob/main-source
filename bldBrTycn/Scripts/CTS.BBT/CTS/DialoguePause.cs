using CTS.BBT;
using CTS.Core;
using CTS.UI;
using PixelCrushers.DialogueSystem;

namespace CTS
{
	public class DialoguePause : CTSBehaviour
	{
		private CanvasGroupController _controller;

		private LockToggle _uiToggler;

		protected override void OnAwake()
		{
			if ((bool)MonoSingleton<UIMainCanvas>.Instance)
			{
				_uiToggler = new LockToggle(MonoSingleton<UIMainCanvas>.Instance, MonoSingleton<TimeController>.Instance);
			}
		}

		public void Pause()
		{
			_uiToggler?.Lock();
		}

		public void Unpause()
		{
			_uiToggler?.Unlock();
		}

		protected override void OnDisabled()
		{
			_controller.CanvasShowned -= OnCanvasShowned;
			DialogueTime.Mode = DialogueTime.TimeMode.Realtime;
		}

		protected override void OnEnabled()
		{
			_controller = BBTUI.GetCanvas(BBTUI.Instance.PanelID_PauseMenu);
			_controller.CanvasShowned += OnCanvasShowned;
			OnCanvasShowned(BBTUI.GetCanvas(BBTUI.Instance.PanelID_PauseMenu).IsShown);
		}

		private void OnTimeModeChanged(ETimeModes mode)
		{
			PauseDialogues(mode == ETimeModes.Pause);
		}

		private void OnCanvasShowned(bool shown)
		{
			PauseDialogues(shown);
		}

		private void PauseDialogues(bool pause)
		{
			DialogueTime.Mode = (pause ? DialogueTime.TimeMode.Gameplay : DialogueTime.TimeMode.Realtime);
		}
	}
}
