using System;
using UnityEngine;

namespace Rewired.PajamaLlama
{
	[CreateAssetMenu(menuName = "Pajama Llama/Rewired/Steam Controller")]
	public class RewiredSteamController : RewiredJoystickGlyphs<RewiredSteamcontrollerElements>
	{
		public static readonly Guid GUID = new Guid("2694f4b9-9d84-4f55-9ee8-78fbba744b7d");

		public override Guid Guid => GUID;
	}
}
