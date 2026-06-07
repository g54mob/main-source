using Boxophobic.StyledGUI;
using UnityEngine;

namespace PolyverseSkiesAsset
{
	[HelpURL("https://docs.google.com/document/d/1z7A_xKNa2mXhvTRJqyu-ZQsAtbV32tEZQbO1OmPS_-s/edit?usp=sharing")]
	[DisallowMultipleComponent]
	[ExecuteInEditMode]
	public class PolyverseSkies : StyledMonoBehaviour
	{
		[StyledBanner(0.968f, 0.572f, 0.89f, "Polyverse Skies")]
		public bool styledBanner;

		[StyledCategory("Scene", 5f, 10f)]
		public bool categoryScene;

		public GameObject sunDirection;

		public GameObject moonDirection;

		[StyledCategory("Time Of Day")]
		public bool categoryTime;

		[StyledMessage("Info", "The Time Of Day feature will interpolate between two Polyverse Skies materials. Please note that material properties such as textures and keywords will not be interpolated! You will need to enable the same features on both materials in order for the interpolation to work! Toggle Update Lighting to enable Unity's realtime environment lighting! ", 0f, 10f)]
		public bool categoryTimeMessage;

		public Material skyboxDay;

		public Material skyboxNight;

		[Range(0f, 1f)]
		public float timeOfDay;

		[Space(10f)]
		public bool updateLighting;

		[StyledSpace(5)]
		public bool styledSpace0;

		private Material skyboxMaterial;

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
