using System.Collections.Generic;
using UnityEngine;
using VRTK.Highlighters;

public class VRTK_OutlineObjectCopySeeThroughHighlighter : VRTK_OutlineObjectCopyHighlighter
{
	private const string MATERIAL_NAME = "OutlineSeeThrough";

	public override void Initialise(Color? color = null, GameObject affectObject = null, Dictionary<string, object> options = null)
	{
		stencilOutline = Object.Instantiate(Resources.Load<Material>("OutlineSeeThrough"));
		base.Initialise(color, affectObject, options);
	}
}
