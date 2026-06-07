using System;
using System.Diagnostics;

namespace WaveHarmonic.Crest
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
	internal sealed class ExecuteDuringEditMode : Attribute
	{
		[Flags]
		public enum Include
		{
			None = 0,
			PrefabStage = 1,
			BuildPipeline = 2,
			All = 3
		}

		[Flags]
		public enum Options
		{
			None = 0,
			Singleton = 1
		}

		public Include _Including;

		public Options _Options;

		public ExecuteDuringEditMode(Include including = Include.PrefabStage, Options options = Options.None)
		{
			_Including = including;
			_Options = options;
		}
	}
}
