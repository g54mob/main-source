using UnityEngine;

namespace Dorfromantik
{
	public class InstancingInfo : ScriptableObject
	{
		public InstanceableCategoryId category;

		public bool updateVisualOnBiomeChanged = true;

		public bool hideWhileStacked = true;

		public bool softBiomeTransitionsEnabled;

		public bool isDecoration;

		public Material instancedMaterial;

		public Material nonInstancedMaterial;

		public bool randomizeRotation = true;

		public bool randomRotationIn60DegreeSteps;

		public Vector2 minMaxTilt;

		public bool ignoresPlacementAnimation;
	}
}
