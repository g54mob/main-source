using System.Collections.Generic;
using UnityEngine;

namespace SpaceGraphicsToolkit
{
	[ExecuteInEditMode]
	public class SgtStarfieldCustom : SgtStarfield
	{
		public List<SgtStarfieldStar> Stars;

		public static SgtStarfieldCustom Create(int layer = 0, Transform parent = null)
		{
			return null;
		}

		public static SgtStarfieldCustom Create(int layer, Transform parent, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
		{
			return null;
		}

		protected override void OnDestroy()
		{
		}

		protected override int BeginQuads()
		{
			return 0;
		}

		protected override void NextQuad(ref SgtStarfieldStar quad, int starIndex)
		{
		}

		protected override void EndQuads()
		{
		}
	}
}
