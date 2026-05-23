#define ENABLE_DEBUG_WARNINGS
using Data.FactoryFloor.FactoryObjectBehaviours;
using UnityEngine;
using Utils;

namespace Presentation.FactoryFloor.FactoryObjectViews.OperatorViews
{
	public class PointerView : FactoryBehaviorView<PointerBehaviour>
	{
		[SerializeField]
		private MeshRenderer[] _meshRenderers;

		protected override void Init()
		{
			base.Init();
			_behaviour.OnPointerColorChanged.RegisterMainThread(HandleColorChanged);
			HandleColorChanged(_behaviour.CurrentMaterials);
		}

		private void HandleColorChanged(PointerBehaviour.MaterialPack materials)
		{
			if (_meshRenderers.Length != materials.MaterialsPerMesh.Length)
			{
				this.LogWarning("The number of mesh renderers doesn't match the number of materials for this colour pack. Some meshes maybe getting missed", "HandleColorChanged", 23);
			}
			for (int i = 0; i < Mathf.Min(_meshRenderers.Length, materials.MaterialsPerMesh.Length); i++)
			{
				_meshRenderers[i].material = materials.MaterialsPerMesh[i];
			}
		}

		protected override void OnDestroy()
		{
			if (_behaviour != null)
			{
				_behaviour.OnPointerColorChanged.UnRegisterMainThread(HandleColorChanged);
			}
			base.OnDestroy();
		}
	}
}
