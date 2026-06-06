using System;
using UnityEngine;

namespace Rewired.PajamaLlama
{
	[CreateAssetMenu(menuName = "Pajama Llama/Rewired/Standard Gamepad")]
	public class RewiredStandardizedGamepad : RewiredJoystickGlyphs<RewiredStandardizedGamepadElements>
	{
		public static readonly Guid GUID = new Guid("04c23ab3-2b99-4404-a5c4-f0df7e62938f");

		public override Guid Guid => GUID;

		public override bool SupportsGuid(Guid guid)
		{
			return guid == GUID;
		}
	}
}
