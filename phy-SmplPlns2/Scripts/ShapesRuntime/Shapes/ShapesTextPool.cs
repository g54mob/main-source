using TMPro;
using UnityEngine;

namespace Shapes
{
	[ExecuteAlways]
	public class ShapesTextPool : ShapesObjPool<TextMeshProShapes, ShapesTextPool>
	{
		public override string PoolTypeName => "Text";

		public override void OnCreatedNewComponent(TextMeshProShapes comp)
		{
			comp.textWrappingMode = TextWrappingModes.NoWrap;
			comp.overflowMode = TextOverflowModes.Overflow;
			comp.GetComponent<MeshRenderer>().enabled = false;
		}
	}
}
