using Rewired.Config;

namespace Rewired
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal class ButtonLoopSet : UpdateLoopDataSet<ButtonLoopSet.ButtonData>
	{
		[CustomClassObfuscation]
		[CustomObfuscation]
		public class ButtonData
		{
			public readonly UpdateLoopType updateLoop;

			public readonly bool[] values;

			public readonly bool[] wasTrueThisFrame;

			private bool[] NErnepFdKinsIHjQocWHLiPbXMF;

			private int YBzxXTwKgGQByJABTWLCZUAgVRi;

			private readonly bool[] vNPAItaQKQbuhDAdBQvrnEvtXeUn;

			private readonly bool[] SWuLUAfRfubJBzjuotiZrbVMlRb;

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

			private void yYoRfNvPPvpDnZVrxhuroGvbKUj()
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
