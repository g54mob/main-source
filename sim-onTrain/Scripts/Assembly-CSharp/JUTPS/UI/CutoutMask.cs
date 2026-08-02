using UnityEngine;
using UnityEngine.UI;

namespace JUTPS.UI
{
	[AddComponentMenu("JU TPS/UI/CutoutMask")]
	public class CutoutMask : Image
	{
		public override Material materialForRendering
		{
			get
			{
				Material obj = new Material(base.materialForRendering);
				obj.SetInt("_StencilComp", 6);
				return obj;
			}
		}
	}
}
