using System;
using UnityEngine;

namespace Rewired.PajamaLlama
{
	[CreateAssetMenu(menuName = "Pajama Llama/Rewired/Sony Dual Sense")]
	public class RewiredSonyDualSense : RewiredJoystickGlyphs<RewiredSonyDualSenseElements>
	{
		public static readonly Guid GUID = new Guid("5286706d-19b4-4a45-b635-207ce78d8394");

		public override Guid Guid => GUID;
	}
}
