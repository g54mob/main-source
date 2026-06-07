using UnityEngine;

namespace AdvancedDissolve_Example
{
	[ExecuteInEditMode]
	public class Controller_Mask_XYZ_Axis : MonoBehaviour
	{
		public enum AXIS
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		public enum SPACE
		{
			World = 0,
			Local = 1
		}

		public static Controller_Mask_XYZ_Axis get;

		public bool updateGlobal;

		public Material[] materials;

		[Space(10f)]
		public AXIS axis;

		public SPACE space;

		public float offset;

		public bool invert;

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void EnableMaskKeyword()
		{
		}

		private void UpdateShaderData()
		{
		}
	}
}
