using System;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Jet
{
	[Flags]
	public enum JetEngineType
	{
		None = 0,
		Legacy = 1,
		Civilian = 2,
		Military = 4
	}
}
