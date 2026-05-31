using UnityEngine;

namespace CTS
{
	public class ShaderRandomInteger : MonoBehaviour
	{
		private MaterialPropertyBlock _propertyBlock;

		private Renderer _renderer;

		[SerializeField]
		private string _key;

		[SerializeField]
		private Vector2Int _range;

		private void Awake()
		{
			ValidateRenderer();
			_propertyBlock = new MaterialPropertyBlock();
			UpdateValues();
		}

		private void ValidateRenderer()
		{
			if (!_renderer)
			{
				_renderer = GetComponent<Renderer>();
			}
		}

		private void UpdateValues()
		{
			_renderer.GetPropertyBlock(_propertyBlock);
			_propertyBlock.SetInt(_key, Random.Range(_range.x, _range.y));
			_renderer.SetPropertyBlock(_propertyBlock);
		}

		private void OnValidate()
		{
			if (_propertyBlock == null)
			{
				_propertyBlock = new MaterialPropertyBlock();
			}
			ValidateRenderer();
			UpdateValues();
		}
	}
}
