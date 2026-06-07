using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Fuselage
{
	public class MeshDefinitionScript : MonoBehaviour
	{
		[SerializeField]
		private bool _anchorsEnabled;

		[SerializeField]
		private AnimationCurve _depthCurve;

		[SerializeField]
		private bool _flattenBottomNormals;

		[SerializeField]
		private bool _flattenTopNormals;

		[SerializeField]
		private float _massMultiplier = 1f;

		[SerializeField]
		private float _massMultiplierV2 = 1f;

		[SerializeField]
		private float _massMultiplierV3 = 1f;

		[SerializeField]
		private float _priceMultiplier = 1f;

		[SerializeField]
		private FuselageMeshType _meshType;

		[SerializeField]
		private string _name = string.Empty;

		[SerializeField]
		private bool _useSimpleRadialScaling;

		public bool AnchorsEnabled => _anchorsEnabled;

		public AnimationCurve DepthCurve => _depthCurve;

		public bool FlattenBottomNormals
		{
			get
			{
				return _flattenBottomNormals;
			}
			set
			{
				_flattenBottomNormals = value;
			}
		}

		public bool FlattenTopNormals
		{
			get
			{
				return _flattenTopNormals;
			}
			set
			{
				_flattenTopNormals = value;
			}
		}

		public FuselageMeshType FuselageMeshType => _meshType;

		public string Id { get; set; }

		public float MassMultiplier => _massMultiplier;

		public float MassMultiplierV2 => _massMultiplierV2;

		public float MassMultiplierV3 => _massMultiplierV3;

		public string Name => _name;

		public float PriveMultiplier => _priceMultiplier;

		public bool UseSimpleRadialScaling => _useSimpleRadialScaling;
	}
}
