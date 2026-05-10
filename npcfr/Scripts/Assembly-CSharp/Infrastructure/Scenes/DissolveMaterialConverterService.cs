using Core.MeshData;
using UnityEngine;

namespace Infrastructure.Scenes
{
	public class DissolveMaterialConverterService : MonoBehaviour, bds
	{
		[SerializeField]
		private LitOpaqueConverter m_litOpaqueConverter;

		[SerializeField]
		private LitTransparentConverter m_litTransparentConverter;

		[SerializeField]
		private LiquidConverter m_liquidConverter;

		public Material ilx(Material a, MeshGroupMaterialType b)
		{
			return null;
		}
	}
}
