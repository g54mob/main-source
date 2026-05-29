using UnityEngine;

namespace CTS
{
	public class CocktailVisualElement : MonoBehaviour
	{
		[SerializeField]
		public Renderer _glassRenderer;

		[SerializeField]
		public Renderer _liquidRenderer;

		[SerializeField]
		private Renderer[] _deco;

		public void HideAll()
		{
			_glassRenderer.enabled = false;
			_liquidRenderer.enabled = false;
			for (int i = 0; i < _deco.Length; i++)
			{
				_deco[i].enabled = false;
			}
		}

		public void Show(Color? liquid, int decoIdx)
		{
			_glassRenderer.enabled = true;
			_liquidRenderer.enabled = liquid.HasValue;
			if (liquid.HasValue)
			{
				_liquidRenderer.material.color = liquid.Value;
			}
			for (int i = 0; i < _deco.Length; i++)
			{
				_deco[i].enabled = i == decoIdx;
			}
		}
	}
}
