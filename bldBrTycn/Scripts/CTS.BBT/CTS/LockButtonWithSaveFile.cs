using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class LockButtonWithSaveFile : CTSBehaviour
	{
		[SerializeField]
		private string _saveName;

		[SerializeField]
		[Inject(false)]
		private ISelectable _selectable;

		[InjectScope(EGetScope.Parent)]
		[Inject(false)]
		private CanvasGroupController _canvas;

		private readonly LockToggle _lockToggle = new LockToggle();

		protected override void OnAwake()
		{
			base.OnAwake();
			if (!string.IsNullOrEmpty(_saveName))
			{
				if ((bool)_canvas)
				{
					_canvas.CanvasShowning += OnCanvasShowing;
				}
				_lockToggle.Add(_selectable);
				UpdateButton();
				ProfileManager.Saved += UpdateButton;
			}
		}

		private void OnCanvasShowing(bool obj)
		{
			UpdateButton();
		}

		private void OnDestroy()
		{
			ProfileManager.Saved -= UpdateButton;
			if ((object)_canvas != null)
			{
				_canvas.CanvasShowning -= OnCanvasShowing;
			}
		}

		private void UpdateButton()
		{
			if (CTSSingleton<ProfileManager>.Instance.ProfileExists(_saveName))
			{
				_lockToggle.Unlock();
			}
			else
			{
				_lockToggle.Lock();
			}
		}
	}
}
