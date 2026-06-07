using DG.Tweening;
using UnityEngine;

namespace VampireSurvivors.App.Graphics
{
	public class ExplodingCoffin : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _lid;

		[SerializeField]
		private SpriteRenderer _base;

		private Sequence _lidTween;

		public void Explode(Color lidColour)
		{
		}
	}
}
