using UnityEngine;

namespace Presentation.FactoryFloor.FactoryObjectViews.OperatorViews.VFX
{
	public class ShaderPropertyAnimation : MonoBehaviour
	{
		[SerializeField]
		private float _animationControl;

		[SerializeField]
		private MeshRenderer _meshRenderer;

		[SerializeField]
		private string _shaderPropertyName;

		private int _shaderProperty;

		private Material _materialInstance;

		public void Start()
		{
			_materialInstance = _meshRenderer.material;
			_meshRenderer.material = _materialInstance;
			_shaderProperty = Shader.PropertyToID(_shaderPropertyName);
		}

		private void Update()
		{
			_materialInstance.SetFloat(_shaderProperty, _animationControl);
		}
	}
}
