using Boxophobic.StyledGUI;
using UnityEngine;

namespace Boxophobic.Utils
{
	[ExecuteInEditMode]
	public class SceneSwitch : StyledMonoBehaviour
	{
		[StyledBanner("Switch")]
		public bool styledBanner;

		public GameObject setupStandard;

		public GameObject setupUniversal;

		public GameObject setupHD;

		[HideInInspector]
		public GameObject objectStandard;

		[HideInInspector]
		public GameObject objectUniversal;

		[HideInInspector]
		public GameObject objectHD;

		[Space(10f)]
		public bool setRenderSettings;

		[Space(10f)]
		public Material skyboxMaterial;

		[Range(0f, 8f)]
		public float skyboxAmbient;

		[Range(0f, 1f)]
		public float skyboxReflection;

		[StyledSpace(5)]
		public bool styledSpace;

		private void OnEnable()
		{
		}
	}
}
