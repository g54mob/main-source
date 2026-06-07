using System;
using UnityEngine;

namespace Rewired.PajamaLlama
{
	[CreateAssetMenu(menuName = "Pajama Llama/Rewired/Sony DualShock 4")]
	public class RewiredSonyDualShock4 : RewiredJoystickGlyphs<RewiredSonyDualShock4Elements>
	{
		public static readonly Guid GUID = new Guid("cd9718bf-a87a-44bc-8716-60a0def28a9f");

		public override Guid Guid => GUID;
	}
}
