using UnityEngine;

namespace AdvancedDissolve_Example
{
	[ExecuteInEditMode]
	public class Controller_Mask_Cylinder_Alt : MonoBehaviour
	{
		public static Controller_Mask_Cylinder_Alt get;

		public bool updateGlobal;

		public Material[] materials;

		[Space(10f)]
		public CylinderParameters cylinder1;

		public CylinderParameters cylinder2;

		public CylinderParameters cylinder3;

		public CylinderParameters cylinder4;

		[Space(10f)]
		public bool invert;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void UpdateShaderData(int maskID, CylinderParameters cylinder)
		{
		}

		public void UpdateMaskKeyword()
		{
		}

		public void UpdateMaskCountKeyword(int count)
		{
		}
	}
}
