using UnityEngine;

namespace TH20
{
	public class SmallTropicalTornado : MonoBehaviour
	{
		[SerializeField]
		private Renderer _renderer;

		[SerializeField]
		private float _lifetime = 14f;

		private float _elapsedTime;

		private MaterialPropertyBlock _materialPropertyBlock;

		private void Start()
		{
			_materialPropertyBlock = new MaterialPropertyBlock();
		}

		private void Update()
		{
			_elapsedTime += Time.deltaTime;
			_materialPropertyBlock.SetFloat("_ElapsedTime", _elapsedTime);
			_renderer.SetPropertyBlock(_materialPropertyBlock);
			if (_elapsedTime > _lifetime)
			{
				_renderer.enabled = false;
			}
		}
	}
}
