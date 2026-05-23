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

			private bool[] CUrntHxqMiibflXFNXeBLXmsmtHC;

			private int MnWYpzLEfCCMmkYfBDxefwpbqQaSb;

			private readonly bool[] nnEGJoOrfWgasotOVIQZbnPYwTDh;

			private readonly bool[] lRGACChaTiAWthNdnEAKdGbbvrmhB;

			public bool[] effectiveValue => null;

			public ButtonData(int P_0, UpdateLoopType P_1)
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

			private void xlDmlnayAzEQycnQUGRzbHxYvLkoA()
			{
			}
		}

		public readonly int buttonCount;

		public ButtonLoopSet(UpdateLoopSetting P_0, int P_1)
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
