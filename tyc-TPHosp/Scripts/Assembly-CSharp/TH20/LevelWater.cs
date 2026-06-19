using UnityEngine;

namespace TH20
{
	[ExecuteInEditMode]
	public class LevelWater : MonoBehaviour
	{
		private enum UpdateMode
		{
			Normal = 0,
			UnscaledTime = 1
		}

		[SerializeField]
		private bool _skyboxReflection = true;

		[SerializeField]
		private UpdateMode _updateMode;

		[SerializeField]
		private Cubemap _skyboxCubemap;

		private MaterialPropertyBlock _materialPropertyBlock;

		private RenderTexture _reflectionTexture;

		private Renderer _renderer;

		private float _elapsedTime;

		protected void OnEnable()
		{
			_elapsedTime = 0f;
			_materialPropertyBlock = new MaterialPropertyBlock();
			_renderer = GetComponent<Renderer>();
			if (_skyboxReflection && _skyboxCubemap != null)
			{
				_materialPropertyBlock.SetTexture("_SkyboxCubemap", _skyboxCubemap);
			}
			_renderer.SetPropertyBlock(_materialPropertyBlock);
		}

		protected void Update()
		{
			if (_updateMode == UpdateMode.Normal)
			{
				_elapsedTime += Time.deltaTime * 0.05f;
			}
			if (_updateMode == UpdateMode.UnscaledTime)
			{
				_elapsedTime += Time.unscaledDeltaTime;
			}
			_materialPropertyBlock.SetFloat("_ElapsedTime", _elapsedTime);
			_renderer.SetPropertyBlock(_materialPropertyBlock);
		}
	}
}
