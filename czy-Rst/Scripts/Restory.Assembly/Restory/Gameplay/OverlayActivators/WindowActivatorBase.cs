namespace Restory.Gameplay.OverlayActivators
{
	public abstract class WindowActivatorBase
	{
		private bool isBlocked;

		public abstract bool IsActivated { get; }

		public bool IsBlocked
		{
			get
			{
				return isBlocked;
			}
			set
			{
				isBlocked = value;
				ResolveOnIsBlockedChanged(isBlocked);
			}
		}

		protected virtual void ResolveOnIsBlockedChanged(bool isBlocked)
		{
		}
	}
}
