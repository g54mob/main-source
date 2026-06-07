using UnityEngine;

namespace AdvancedDissolve_Example
{
	[ExecuteInEditMode]
	public class Controller_Mask_Cone : MonoBehaviour
	{
		public static Controller_Mask_Cone get;

		public bool updateGlobal;

		public Material[] materials;

		public Light spotLight1;

		public Light spotLight2;

		public Light spotLight3;

		public Light spotLight4;

		[Space(10f)]
		public bool invert;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void UpdateShaderData(int maskID, Light spotLight)
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
