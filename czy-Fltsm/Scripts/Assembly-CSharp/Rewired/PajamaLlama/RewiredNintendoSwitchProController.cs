using System;
using UnityEngine;

namespace Rewired.PajamaLlama
{
	[CreateAssetMenu(menuName = "Pajama Llama/Rewired/Nintendo Switch Pro Controller")]
	public class RewiredNintendoSwitchProController : RewiredJoystickGlyphs<RewiredNintendoSwitchProControllerElements>
	{
		public static readonly Guid GUID = new Guid("d74a350e-fe8b-4e9e-bbcd-efff16d34115");

		public override Guid Guid => GUID;
	}
}
