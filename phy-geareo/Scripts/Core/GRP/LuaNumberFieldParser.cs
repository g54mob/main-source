using MoonSharp.Interpreter;
using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/LuaNumberFieldParser", fileName = "LuaNumberFieldParser")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class LuaNumberFieldParser : NumberFieldParser
	{
		private Script script;

		public override bool Parse(string value, out float result)
		{
			result = default(float);
			return false;
		}
	}
}
