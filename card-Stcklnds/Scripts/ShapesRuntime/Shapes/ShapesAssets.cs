using TMPro;
using UnityEngine;

namespace Shapes
{
	public class ShapesAssets : ScriptableObject
	{
		private static class StaticLoader
		{
			public static readonly ShapesAssets instance = Resources.Load<ShapesAssets>("Shapes Assets");
		}

		[Header("Config")]
		public TMP_FontAsset defaultFont;

		[Header("Meshes")]
		public Mesh[] meshQuad = new Mesh[5];

		public Mesh[] meshTriangle = new Mesh[5];

		public Mesh[] meshCube = new Mesh[5];

		public Mesh[] meshSphere = new Mesh[5];

		public Mesh[] meshTorus = new Mesh[5];

		public Mesh[] meshCapsule = new Mesh[5];

		public Mesh[] meshCylinder = new Mesh[5];

		public Mesh[] meshCone = new Mesh[5];

		public Mesh[] meshConeUncapped = new Mesh[5];

		[Header("Misc")]
		public TextAsset packageJson;

		public static ShapesAssets Instance => StaticLoader.instance;
	}
}
