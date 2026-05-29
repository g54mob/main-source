using UnityEngine;
using UnityEngine.UI;

public class TCP2_Demo_InvertedMaskImage : Image
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
