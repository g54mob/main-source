using UnityEngine;

namespace UI
{
	public abstract class BaseDialog : MonoBehaviour
	{
		[Header("大きいほど前面にSort")]
		public int sortDialog;

		private bool _enableEscape;

		private DialogManager.OpenMode _openMode;

		public bool EnableEscape
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public eDialog DialogType { get; set; }

		public DialogManager.OpenMode OpenMode
		{
			get
			{
				return default(DialogManager.OpenMode);
			}
			set
			{
			}
		}

		public virtual void Init()
		{
		}

		public virtual void Init<T>(T args) where T : class
		{
		}

		public virtual void Open()
		{
		}

		public virtual void Open<T>(T args) where T : class
		{
		}

		public virtual void Back()
		{
		}

		public virtual void PushEscape()
		{
		}

		public virtual void SetInFront()
		{
		}

		public virtual void OnBackOpen()
		{
		}

		public virtual void PlayOpenSound()
		{
		}

		public virtual void PlayCloseSound()
		{
		}
	}
}
