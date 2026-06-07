using System;
using Cysharp.Text;
using UnityEngine;

public static class Version
{
	[Flags]
	public enum Build
	{
		Full = 1,
		Demo = 2
	}

	[Flags]
	public enum Dlc
	{
		None = 0,
		Supporter = 1
	}

	public const int DemoAppId = 4375460;

	public const int FullAppId = 3907940;

	public const int SupporterAppId = 4510400;

	public const bool IS_DEMO = false;

	public const bool IS_FULL = true;

	public const Build TYPE = Build.Full;

	public const string FORMAT = "v-{0}";

	public const int AppId = 3907940;

	public static string VERSION => ZString.Format("v-{0}", Application.version);
}
