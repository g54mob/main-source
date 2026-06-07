using UnityEngine;

namespace VampireSurvivors
{
	public class ReportDeadBodyDisplay : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _BubbleSpriteRenderer;

		[SerializeField]
		private SpriteRenderer _SkullSpriteRenderer;

		[SerializeField]
		private SpriteRenderer _Line1Renderer;

		[SerializeField]
		private SpriteRenderer _Line2Renderer;

		private void Awake()
		{
		}
	}
}
