using ModApi.Planet;
using UnityEngine;

namespace Assets.Scripts.Flight.Sim
{
	public class DynamicColorMaterialScript : MonoBehaviour, IDynamicStructureMaterial
	{
		[SerializeField]
		private int _materialIndex = -1;

		private MaterialPropertyBlock _materialPropertyBlock;

		public void UpdateMaterial(float tiling, Color color)
		{
			if (_materialPropertyBlock == null)
			{
				_materialPropertyBlock = new MaterialPropertyBlock();
			}
			_materialPropertyBlock.SetColor("_colorMultiplier", color);
			MeshRenderer component = GetComponent<MeshRenderer>();
			if (_materialIndex == -1)
			{
				component.SetPropertyBlock(_materialPropertyBlock);
			}
			else
			{
				component.SetPropertyBlock(_materialPropertyBlock, _materialIndex);
			}
		}
	}
}
