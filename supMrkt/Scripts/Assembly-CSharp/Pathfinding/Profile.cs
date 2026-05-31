using System;
using System.Diagnostics;

namespace Pathfinding
{
	public class Profile
	{
		private const bool PROFILE_MEM = false;

		public readonly string name;

		private readonly Stopwatch watch;

		private int counter;

		private long mem;

		private long smem;

		private int control;

		private const bool dontCountFirst = false;

		public int ControlValue()
		{
			return 0;
		}

		public Profile(string name)
		{
		}

		public static void WriteCSV(string path, params Profile[] profiles)
		{
		}

		public void Run(Action action)
		{
		}

		[Conditional("PROFILE")]
		public void Start()
		{
		}

		[Conditional("PROFILE")]
		public void Stop()
		{
		}

		[Conditional("PROFILE")]
		public void Log()
		{
		}

		[Conditional("PROFILE")]
		public void ConsoleLog()
		{
		}

		[Conditional("PROFILE")]
		public void Stop(int control)
		{
		}

		[Conditional("PROFILE")]
		public void Control(Profile other)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
