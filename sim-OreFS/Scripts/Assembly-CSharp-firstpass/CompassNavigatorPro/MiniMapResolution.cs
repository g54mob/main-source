using UnityEngine;

namespace CompassNavigatorPro
{
	public enum MiniMapResolution
	{
		[InspectorName("64")]
		_64 = 0x40,
		[InspectorName("128")]
		_128 = 0x80,
		[InspectorName("256")]
		_256 = 0x100,
		[InspectorName("512")]
		_512 = 0x200,
		[InspectorName("1024")]
		_1024 = 0x400,
		[InspectorName("2048")]
		_2048 = 0x800,
		[InspectorName("4096")]
		_4096 = 0x1000,
		[InspectorName("8192")]
		_8192 = 0x2000
	}
}
