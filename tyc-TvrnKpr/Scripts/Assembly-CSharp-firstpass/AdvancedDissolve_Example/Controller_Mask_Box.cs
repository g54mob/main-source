using System.Collections.Generic;
using UnityEngine;

namespace AdvancedDissolve_Example
{
	[ExecuteInEditMode]
	public class Controller_Mask_Box : MonoBehaviour
	{
		public bool updateGlobal;

		private List<Material> _materials;

		public GameObject box1;

		public GameObject box2;

		public GameObject box3;

		public GameObject box4;

		[Space(10f)]
		public bool invert;

		private void Start()
		{
		}

		private void LateUpdate()
		{
		}

		private void UpdateShaderData(int maskID, GameObject box)
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
