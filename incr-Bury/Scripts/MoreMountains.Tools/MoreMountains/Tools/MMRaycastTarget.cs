using UnityEngine;
using UnityEngine.UI;

namespace MoreMountains.Tools
{
	[AddComponentMenu("More Mountains/Tools/GUI/MM Raycast Target")]
	public class MMRaycastTarget : Graphic
	{
		public override void SetVerticesDirty()
		{
		}

		public override void SetMaterialDirty()
		{
		}

		protected override void OnPopulateMesh(VertexHelper vh)
		{
			vh.Clear();
		}
	}
}
