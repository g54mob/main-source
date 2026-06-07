using Simulator;
using UnityEngine;
using UnityEngine.UI;

namespace Tabletop.GameWorld
{
	public class UI_WargameValidateDiceButton : NavButton
	{
		[SerializeField]
		private Image m_image;

		[SerializeField]
		private Sprite m_interactableSprite;

		[SerializeField]
		private Sprite m_nonInteractableSprite;

		protected override void OnEnable()
		{
			base.OnEnable();
			base.InteractabilityChanged += OnInteractabilityChanged;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			base.InteractabilityChanged -= OnInteractabilityChanged;
		}

		private void OnInteractabilityChanged(bool newInteractable)
		{
			m_image.sprite = (newInteractable ? m_interactableSprite : m_nonInteractableSprite);
		}
	}
}
