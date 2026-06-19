namespace TH20
{
	public abstract class CursorMode : MustCallDestroy
	{
		protected readonly CursorManager _cursorManager;

		public CursorManager Manager => _cursorManager;

		protected CursorMode(CursorManager cursorManager)
		{
			_cursorManager = cursorManager;
		}

		public virtual void OnBecomeActive()
		{
		}

		public virtual void OnBecomeInactive()
		{
		}

		public virtual void CursorUpdate(InputManager inputManager)
		{
		}

		public virtual void OnGUI()
		{
		}

		public virtual void DebugDraw()
		{
		}
	}
}
