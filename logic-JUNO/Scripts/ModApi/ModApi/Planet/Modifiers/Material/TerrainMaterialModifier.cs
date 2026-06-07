using UnityEngine;

namespace ModApi.Planet.Modifiers.Material
{
	public class TerrainMaterialModifier : PlanetModifier
	{
		[SerializeField]
		private UnityEngine.Material _sharedMaterial;

		protected UnityEngine.Material SharedMaterial
		{
			get
			{
				return _sharedMaterial;
			}
			set
			{
				_sharedMaterial = value;
			}
		}

		public TerrainMaterialModifier()
			: base(PlanetModifierType.TerrainMaterial)
		{
		}

		public virtual UnityEngine.Material GetMaterial(IQuadSphereQuad quad)
		{
			return _sharedMaterial;
		}

		public override QuadMeshDataFlags GetRequiredTerrainMeshData()
		{
			return QuadMeshDataFlags.Color;
		}

		public virtual void InitializeQuadSphere(IQuadSphere quadSphere)
		{
			_sharedMaterial = Object.Instantiate(Game.Instance.ResourceLoader.LoadMaterial("Planets/Materials/PlanetQuadTerrainMaterial"));
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (_sharedMaterial != null)
			{
				Object.Destroy(_sharedMaterial);
			}
		}

		[ContextMenu("Create Renderer")]
		private void CreateRenderer()
		{
			base.gameObject.AddComponent<MeshRenderer>().sharedMaterial = _sharedMaterial;
		}
	}
}
