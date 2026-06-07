using System;
using UnityEngine;

namespace Rewired.PajamaLlama
{
	[CreateAssetMenu(menuName = "Pajama Llama/Rewired/Xbox One")]
	public class RewiredXboxOne : RewiredJoystickGlyphs<RewiredXboxOneElements>
	{
		public static readonly Guid GUID = new Guid("19002688-7406-4f4a-8340-8d25335406c8");

		public override Guid Guid => GUID;
	}
}
