using TMPro;
using UnityEngine;

namespace VampireSurvivors.Framework
{
	public class GlimmerTechniqueCarouselItem : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI m_Text;

		[SerializeField]
		private SpriteRenderer m_Background;

		public float Age;

		public void Activate(string glimmerTechniqueText)
		{
		}

		public void Hide()
		{
		}
	}
}
