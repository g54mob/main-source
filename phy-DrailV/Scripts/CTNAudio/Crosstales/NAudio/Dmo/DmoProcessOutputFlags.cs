using System;

namespace Crosstales.NAudio.Dmo
{
	[Flags]
	public enum DmoProcessOutputFlags
	{
		None = 0,
		DiscardWhenNoBuffer = 1
	}
}
