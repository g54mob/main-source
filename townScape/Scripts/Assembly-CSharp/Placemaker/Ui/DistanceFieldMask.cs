using UnityEngine;
using UnityEngine.UI;

namespace Placemaker.Ui
{
	public class DistanceFieldMask : BaseMeshEffect
	{
		[SerializeField]
		private Vector4 offset;

		[SerializeField]
		private Vector4 anchor;

		public void SetDirty()
		{
		}

		public override void ModifyMesh(VertexHelper vh)
		{
		}
	}
}
