using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T8QuantumWidgetSecretGem : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _renderer;

		public int GemType;

		public bool Connected { get; set; }

		public void SetColor(Color c)
		{
			_renderer.color = c;
		}
	}
}
