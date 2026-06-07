using System.Collections.Generic;
using UnityEngine;
using VRTK.Highlighters;

public class VRTK_ConstantThicknessOutlineObjectCopySeeThroughHighlighter : VRTK_OutlineObjectCopyHighlighter
{
	private const string MATERIAL_NAME = "ConstantThicknessOutlineSeeThrough";

	public override void Initialise(Color? color = null, GameObject affectObject = null, Dictionary<string, object> options = null)
	{
		stencilOutline = Object.Instantiate(Resources.Load<Material>("ConstantThicknessOutlineSeeThrough"));
		base.Initialise(color, affectObject, options);
	}
}
