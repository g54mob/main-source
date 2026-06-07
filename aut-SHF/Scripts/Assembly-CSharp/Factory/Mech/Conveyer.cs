using Factory.FieldData;
using UnityEngine;

namespace Factory.Mech
{
	public class Conveyer : MechBase
	{
		public const string DefaultName = "SoloR";

		public Conveyer(Structure[] structures)
			: base(null)
		{
		}

		public static bool CalcPartsName(Vector2Int routeAddr, Vector2Int? input, Vector2Int? output, out string partsName, out bool isAnimation)
		{
			partsName = null;
			isAnimation = default(bool);
			return false;
		}
	}
}
