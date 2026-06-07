using System;
using System.Collections;
using System.Collections.Generic;
using UI.Elements;
using UnityEngine;
using UnityEngine.Localization;

namespace UI.Modal
{
	public class UIProgressBarModal : UIModal<UIProgressBarModalInitParameters>
	{
		private LocalizedString localizedStringTitle;

		private LocalizedString localizedStringMessage;

		[SerializeField]
		public UIText message;

		[SerializeField]
		private UISlider progress;

		private Action OnErrorClose;

		private Action OnStart;

		private Coroutine waitCo;

		public override void Init(UIModalManager modalManager, UIProgressBarModalInitParameters initParameters, List<UIButton> modalOpenButton)
		{
		}

		public override void Set()
		{
		}

		public override void OnOpen()
		{
		}

		public override void OnClose()
		{
		}

		public override void DisablePanel()
		{
		}

		public override void EnablePanel()
		{
		}

		public void StartWaiting()
		{
		}

		public void StopWaiting()
		{
		}

		public IEnumerator WaitCO()
		{
			return null;
		}

		private void StopCoroutines()
		{
		}
	}
}
