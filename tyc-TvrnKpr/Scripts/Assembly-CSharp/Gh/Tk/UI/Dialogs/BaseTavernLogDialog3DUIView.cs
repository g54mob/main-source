using System;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class BaseTavernLogDialog3DUIView : BaseDialog3DUIView
	{
		[SerializeField]
		protected Container3DUIView _logContainer;

		private bool _isLayoutDirty;

		protected override void Awake()
		{
		}

		protected void MarkLayoutDirty(object sender, EventArgs e)
		{
		}

		protected void MarkLayoutDirty()
		{
		}

		private void LateUpdate()
		{
		}
	}
}
