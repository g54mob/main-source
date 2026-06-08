using System;
using Rhizomatic.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Rhizomatic.ImUI
{
	public class KeyCodeView : ImUIView<KeyCodeViewState>
	{
		public Button button;

		public GameObject target;

		public TextAdapter text;

		public Key keyCode;

		public Button clear;

		private IDisposable keyHandler;

		protected override void OnCreated()
		{
		}

		private void OnDestroy()
		{
		}

		protected override void LoadState(KeyCodeViewState state)
		{
		}

		public override ImUIViewState GetState()
		{
			return null;
		}
	}
}
