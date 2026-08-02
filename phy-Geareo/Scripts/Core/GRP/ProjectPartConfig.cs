using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/ProjectPartConfig", fileName = "ProjectPartConfig")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class ProjectPartConfig : ScriptableObject
	{
		[Header("Materials")]
		public MaterialTable basicMaterialTable;

		public MaterialTable bearingMaterialTable;

		public MaterialTable shaftMaterialTable;

		public MaterialTable gearMaterialTable;

		public string basicMaterial;

		public string shaftMaterial;

		public string gearMaterial;

		public string textMaterial;

		[Header("Colors")]
		public Color basicColor;

		public Color bearingColor;

		public Color shaftColor;

		public Color gearColor;

		public Color braceColor;

		public Color lightColor;

		public Color springColor;

		public Color wingColor;

		public Color globalChannelColor;

		[Header("General")]
		public float minSize;

		public float maxSize;

		public float size;

		public float smallSize;

		public float radius;

		public int snapPoint;

		[Header("Cylinder")]
		public int cylinderSegments;

		public float cylinderHeight;

		[Header("Bearing")]
		public float bearingHeight;

		public Vector3 linearBearingSize;

		[Header("Shaft")]
		public float shaftRadius;

		public float shaftHeight;

		[Header("Ring")]
		public int ringSegments;

		public float ringHeight;

		public float ringRadius;

		public float ringThickness;

		[Header("Spring")]
		public float springRadius;

		public float springHeight;

		[Header("Gear")]
		public float gearHeight;

		public int gearTeeth;

		public int ringGearTeeth;

		public float gearThickness;

		public string gearInlay;

		public GearInlayContainer inlayContainer;

		[Header("Other")]
		public float rocketHeight;

		[Header("Text")]
		public float textSize;

		public float textDepth;

		[Header("Cam")]
		public int camSegments;

		public float camHeight;

		public float camThickness;

		public AnimationCurve curveData;
	}
}
