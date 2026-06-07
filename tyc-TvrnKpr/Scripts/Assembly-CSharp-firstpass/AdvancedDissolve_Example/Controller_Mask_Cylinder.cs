using UnityEngine;

namespace AdvancedDissolve_Example
{
	[ExecuteInEditMode]
	public class Controller_Mask_Cylinder : MonoBehaviour
	{
		public static Controller_Mask_Cylinder get;

		public bool updateGlobal;

		public Material[] materials;

		public GameObject cylinder1;

		public GameObject cylinder2;

		public GameObject cylinder3;

		public GameObject cylinder4;

		[Space(10f)]
		public bool invert;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void UpdateShaderData(int maskID, GameObject cylinder)
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
