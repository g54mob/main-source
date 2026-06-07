using DG.Tweening;
using TMPro;

namespace VampireSurvivors.Objects.Stages
{
	public class RuneText : GameMonoBehaviour
	{
		public TextMeshPro TextRenderer { get; set; }

		public Tween ZTween { get; set; }

		public Tween AlphaTween { get; set; }

		public float Z { get; set; }

		private void Awake()
		{
		}
	}
}
