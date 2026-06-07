using UnityEngine;

namespace AdvancedDissolve_Example
{
	[ExecuteInEditMode]
	public class Controller_Mask_Sphere : MonoBehaviour
	{
		public static Controller_Mask_Sphere get;

		public bool updateGlobal;

		public Material[] materials;

		[Space(10f)]
		public GameObject sphere1;

		public GameObject sphere2;

		public GameObject sphere3;

		public GameObject sphere4;

		[Space(10f)]
		public bool invert;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void UpdateShaderData(int maskID, GameObject sphere)
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
