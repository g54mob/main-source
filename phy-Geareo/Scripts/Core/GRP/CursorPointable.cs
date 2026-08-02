namespace GRP
{
	public class CursorPointable : WorldPointable
	{
		public CursorPointableConfig config;

		public bool active { get; private set; }

		public bool isDown { get; private set; }

		public bool isHover { get; private set; }

		public override void OnHoverEnter(WorldPointerEvent evt)
		{
		}

		public override void OnHoverExit(WorldPointerEvent evt)
		{
		}

		public override void OnDown(WorldPointerEvent evt)
		{
		}

		public override void OnUp(WorldPointerEvent evt)
		{
		}

		public void UpdateCursor()
		{
		}

		private void OnDisable()
		{
		}

		public void SetActive(bool active)
		{
		}
	}
}
