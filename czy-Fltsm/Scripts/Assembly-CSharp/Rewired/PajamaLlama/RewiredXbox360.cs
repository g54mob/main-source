using System;
using UnityEngine;

namespace Rewired.PajamaLlama
{
	[CreateAssetMenu(menuName = "Pajama Llama/Rewired/Xbox 360")]
	public class RewiredXbox360 : RewiredJoystickGlyphs<RewiredXbox360Elements>
	{
		public static readonly Guid GUID = new Guid("d74a350e-fe8b-4e9e-bbcd-efff16d34115");

		public override Guid Guid => GUID;
	}
}
