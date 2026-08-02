using UnityEngine;

namespace Rhizomatic
{
	[CreateAssetMenu(menuName = "Rhizomatic/Assets/DefaultNumberFieldParser", fileName = "DefaultNumberFieldParser")]
	[AssetCreator(typeof(DefaultAssetCategory))]
	public class DefaultNumberFieldParser : NumberFieldParser
	{
		public override bool Parse(string value, out float result)
		{
			result = default(float);
			return false;
		}
	}
}
