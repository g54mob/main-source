using UnityEngine;

namespace FractureField.DrillSite.UI
{
	public class DrillSiteTileController : MonoBehaviour
	{
		[Header("Variables")]
		public int Index;

		public int Layer;

		public int Step;

		[Header("References")]
		[SerializeField]
		private Animator _animator;

		[SerializeField]
		private SpriteRenderer _backgroundSR;

		[SerializeField]
		private ParticleSystemRenderer _fogRenderer;

		[SerializeField]
		private SpriteMask _maskSR;

		[SerializeField]
		private SpriteRenderer _borderSR;

		public void Setup(int index, int layer, int step)
		{
		}
	}
}
