using UnityEngine;
using UnityEngine.UI;

namespace Tabletop.GameWorld
{
	public class UI_CollectionScoreStar : MonoBehaviour
	{
		[SerializeField]
		private Image m_starImage;

		[SerializeField]
		private Sprite m_gainedStarSprite;

		[SerializeField]
		private Sprite m_lostStarSprite;

		public void SetGained(bool gained)
		{
			m_starImage.sprite = (gained ? m_gainedStarSprite : m_lostStarSprite);
		}
	}
}
