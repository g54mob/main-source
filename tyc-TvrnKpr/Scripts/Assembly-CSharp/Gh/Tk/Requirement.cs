using System;
using System.Runtime.CompilerServices;

namespace Gh.Tk
{
	public abstract class Requirement
	{
		private bool _isDirty;

		protected bool _isDone;

		protected string _titleKey;

		private float? _currentProgress;

		private string _currentProgressText;

		public virtual bool IsDone
		{
			get
			{
				return false;
			}
			protected set
			{
			}
		}

		public Func<bool> IsEnabledCheck { get; set; }

		public event EventHandler<EventArgs> StatusChanged
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

		protected void RaiseStatusChanged()
		{
		}

		public void MarkAsDirty()
		{
		}

		public virtual bool IsDirty()
		{
			return false;
		}

		protected void UpdateProgressInfo(float current, float desired)
		{
		}

		public virtual string GetToolTip()
		{
			return null;
		}

		protected Requirement()
		{
		}

		protected Requirement(string titleKey)
		{
		}

		~Requirement()
		{
		}

		public virtual void Init()
		{
		}

		public void Invalidate()
		{
		}

		protected virtual void InvalidateInternal()
		{
		}

		protected abstract void CheckIfDoneInternal();

		protected virtual void AttachListeners()
		{
		}

		protected virtual void DetachListeners()
		{
		}

		public bool IsEnabled()
		{
			return false;
		}
	}
}
