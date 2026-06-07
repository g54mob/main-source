using Motorways.Constants;
using Rendering.RenderFeatures;
using UnityEngine;

namespace Motorways.Views
{
	[RequireComponent(typeof(MeshRenderer))]
	public class ShadowFadeoutInfo : MonoBehaviour
	{
		public ShadowTypeRenderPass.ShadowType shadowType;

		private MeshRenderer _meshRenderer;

		private static MaterialPropertyBlock _materialProperty;

		private void Awake()
		{
			if (_materialProperty == null)
			{
				_materialProperty = new MaterialPropertyBlock();
			}
			_meshRenderer = GetComponent<MeshRenderer>();
			_meshRenderer.GetPropertyBlock(_materialProperty);
			_materialProperty.SetFloat(ShaderConstants.ShadowType, (float)shadowType);
			_meshRenderer.SetPropertyBlock(_materialProperty);
		}
	}
}
