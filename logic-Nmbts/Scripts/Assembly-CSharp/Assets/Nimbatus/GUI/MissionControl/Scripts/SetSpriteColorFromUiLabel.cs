using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionControl.Scripts
{
	public class SetSpriteColorFromUiLabel : MonoBehaviour
	{
		public UILabel ColoredLabel;

		private SpriteRenderer _spriteRenderer;

		private void Start()
		{
			_spriteRenderer = GetComponent<SpriteRenderer>();
		}

		private void Update()
		{
			if (ColoredLabel != null && _spriteRenderer != null)
			{
				_spriteRenderer.color = ColoredLabel.color;
			}
		}
	}
}
