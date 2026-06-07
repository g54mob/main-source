using System;

namespace Gh.Tk
{
	[Serializable]
	public class AnimationBoolLog : IPersistable
	{
		public string Animation;

		public bool Value;

		private AnimationBoolLog()
		{
		}

		public AnimationBoolLog(string animation, bool value)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
