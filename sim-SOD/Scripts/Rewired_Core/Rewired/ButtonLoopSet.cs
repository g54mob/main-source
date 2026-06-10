using Rewired.Config;

namespace Rewired
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	internal class ButtonLoopSet : UpdateLoopDataSet<ButtonLoopSet.ButtonData>
	{
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public class ButtonData
		{
			public readonly UpdateLoopType updateLoop;

			public readonly bool[] values;

			public readonly bool[] wasTrueThisFrame;

			private bool[] MrhEJBGLFoWqoGWjYENmWtBilBSJ;

			private int LNQDHidMemIZovBSXfdaOvbJZRge;

			private readonly bool[] cIeJsGElscfbpjSfJwGHMgQKjaCm;

			private readonly bool[] LsDnbjHULUEoZpYuqOOrRjyvnzv;

			public bool[] effectiveValue => null;

			public ButtonData(int count, UpdateLoopType updateLoop)
			{
			}

			public void SetValue(int index, bool value)
			{
			}

			public void ClearWasTrueThisFrame()
			{
			}

			public void Clear()
			{
			}

			public void Import(ButtonData source)
			{
			}

			private void zpJRzkNbbZYHvPbllBNRAwAYpQl()
			{
			}
		}

		public readonly int buttonCount;

		public ButtonLoopSet(UpdateLoopSetting updateLoops, int buttonCount)
			: base(default(UpdateLoopSetting))
		{
		}

		public void SetValue(int index, bool value, double timestamp)
		{
		}

		public void Clear()
		{
		}

		public void Import(ButtonLoopSet set)
		{
		}
	}
}
