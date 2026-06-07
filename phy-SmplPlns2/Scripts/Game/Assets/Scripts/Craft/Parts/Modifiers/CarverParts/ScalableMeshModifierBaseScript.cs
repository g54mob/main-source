using Unity.Mathematics;

namespace Assets.Scripts.Craft.Parts.Modifiers.CarverParts
{
	public abstract class ScalableMeshModifierBaseScript : MeshModifierBaseScript
	{
		public virtual bool ApplyScaleToManifold => false;

		public new ScalableMeshModifierBaseData Data
		{
			get
			{
				return (ScalableMeshModifierBaseData)base.Data;
			}
			set
			{
				base.Data = value;
			}
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();
			Data.OnScaleChanged += OnScaleChanged;
		}

		protected override void UpdateEditorCollider()
		{
			if (ApplyScaleToManifold)
			{
				float3 scale = Data.Scale;
				base.EditorCollider.center = base.ManifoldLocalBounds.center * scale;
				base.EditorCollider.size = base.ManifoldLocalBounds.size * scale;
			}
			else
			{
				base.UpdateEditorCollider();
			}
		}

		private void OnScaleChanged()
		{
			if (!ApplyScaleToManifold)
			{
				UpdateManifoldShape();
			}
			UpdateEditorCollider();
			NotifyAffectedParts();
		}
	}
}
