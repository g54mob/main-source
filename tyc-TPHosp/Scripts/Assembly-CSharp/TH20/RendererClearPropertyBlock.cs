using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RendererClearPropertyBlock : MonoBehaviour
	{
		private Renderer _renderer;

		public void Setup(Renderer rendererToClear, float delayInSeconds)
		{
			_renderer = rendererToClear;
			float num = ((Time.timeScale > 0f) ? Time.timeScale : 1f);
			Object.Destroy(this, delayInSeconds * num);
		}

		private void OnDestroy()
		{
			_renderer.SetPropertyBlock(null);
		}
	}
}
