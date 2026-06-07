using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class MaterialOffsetter : MonoBehaviour
	{
		public float materialOffsetStart;

		public float materialOffsetEnd;

		public float materialOffsetDisabled;

		public List<GameObject> animatedMaterialObjects;

		private List<Material> _animatedMats;

		private static readonly int MainTex;

		public void SetDisabled()
		{
		}

		public void SetPercentageOffset(float offsetPercentage)
		{
		}

		private void SetMaterialOffset(Vector2 materialOffset)
		{
		}
	}
}
