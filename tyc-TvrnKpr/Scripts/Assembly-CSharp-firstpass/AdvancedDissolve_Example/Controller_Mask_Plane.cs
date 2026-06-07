using UnityEngine;

namespace AdvancedDissolve_Example
{
	[ExecuteInEditMode]
	public class Controller_Mask_Plane : MonoBehaviour
	{
		public static Controller_Mask_Plane get;

		public bool updateGlobal;

		public Material[] materials;

		public GameObject plane1;

		public GameObject plane2;

		public GameObject plane3;

		public GameObject plane4;

		[Space(10f)]
		public bool invert;

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void UpdateMaskKeyword()
		{
		}

		public void UpdateMaskCountKeyword(int count)
		{
		}

		private void UpdateShaderData(int maskID, GameObject plane)
		{
		}
	}
}
