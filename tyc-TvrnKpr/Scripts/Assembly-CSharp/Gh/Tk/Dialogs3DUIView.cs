using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class Dialogs3DUIView : MonoBehaviour
	{
		public BaseDialog3DUIView ActiveDialog;

		private Dictionary<string, BaseDialog3DUIView> _dialogs;

		[SerializeField]
		private Button3DUIView _gameOverlay;

		public bool IsDialogOpen => false;

		public bool HideAllTavernUI => false;

		public bool RequireStatusBar => false;

		public static event EventHandler DialogOpening
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler DialogOpened
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler DialogClosing
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler DialogClosed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public bool IsDialogOpenWithId(string id)
		{
			return false;
		}

		public BaseDialog3DUIView GetDialog(string id)
		{
			return null;
		}

		private void Start()
		{
		}

		private void OnLevelUnloaded(object sender, EventArgs e)
		{
		}

		public void OnDialogOpening(BaseDialog3DUIView dialog)
		{
		}

		public void OnDialogOpened(BaseDialog3DUIView dialog)
		{
		}

		public void OnDialogClosing(BaseDialog3DUIView dialog)
		{
		}

		public void OnDialogClosed(BaseDialog3DUIView dialog)
		{
		}
	}
}
