using UnityEngine;
using UnityEngine.UI;

namespace Coffee.UIEffects
{
	[ExecuteAlways]
	public class UISyncEffect : BaseMaterialEffect
	{
		[Tooltip("The target effect to synchronize.")]
		[SerializeField]
		private BaseMeshEffect m_TargetEffect;

		public BaseMeshEffect targetEffect
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		public override Hash128 GetMaterialHash(Material baseMaterial)
		{
			return default(Hash128);
		}

		public override void ModifyMaterial(Material newMaterial, Graphic graphic)
		{
		}

		public override void ModifyMesh(VertexHelper vh, Graphic graphic)
		{
		}
	}
}
