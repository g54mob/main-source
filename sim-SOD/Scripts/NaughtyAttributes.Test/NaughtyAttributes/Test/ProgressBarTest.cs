using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class ProgressBarTest : MonoBehaviour
	{
		[ProgressBar("Health", 100f, EColor.Red)]
		[Header("Constant ProgressBar")]
		public float health;

		[Header("Nested ProgressBar")]
		public ProgressBarNest1 nest1;

		[Header("Dynamic ProgressBar")]
		[ProgressBar("Elixir", "maxElixir", EColor.Violet)]
		public int elixir;

		public int maxElixir;
	}
}
