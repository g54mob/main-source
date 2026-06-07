using System;

namespace ScriptableObjects.ScriptableObjectScripts.Tile
{
	[Flags]
	public enum eTileAppendKind
	{
		None = 0,
		PortR = 0x10,
		PortU = 0x20,
		PortL = 0x40,
		PortD = 0x80,
		AllPorts = 0xF0,
		PortGuideConveyer = 0x100,
		PortGuidePipe = 0x200,
		PortGuideProduct = 0x800
	}
}
