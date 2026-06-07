using System;
using UnityEngine;

namespace viperOSK
{
	[Serializable]
	public struct HexRange
	{
		[Tooltip("Start (hex), e.g., 0370 or 0x0370")]
		public string startHex;

		[Tooltip("End (hex), inclusive, e.g., 03FF or 0x03FF")]
		public string endHex;
	}
}
