using System;
using System.Collections;
using System.Collections.Generic;
using UI.Elements;
using UnityEngine;
using UnityEngine.Localization;

namespace UI.Modal
{
	public class UITextModal : UIModal<UIWriteModalInitParameters>
	{
		public UIInputField nameBar;

		public UIButton openButton;

		public UIButton closeButton;

		private LocalizedString localizedString;

		private Action<string> OnClickAction;

		private string oldText;

		private Coroutine waitToWriteCo;

		public override void Init(UIModalManager modalManager, UIWriteModalInitParameters initParameters, List<UIButton> modalOpenButton)
		{
		}

		public override void OnOpen()
		{
		}

		private IEnumerator WaitToWriteCO()
		{
			return null;
		}

		private void StopCoroutines()
		{
		}

		public void OnSelectionConfirmed()
		{
		}

		public override void OnClose()
		{
		}

		public void Close()
		{
		}

		public override void DisablePanel()
		{
		}

		public override void EnablePanel()
		{
		}

		public override void Set()
		{
		}
	}
}
