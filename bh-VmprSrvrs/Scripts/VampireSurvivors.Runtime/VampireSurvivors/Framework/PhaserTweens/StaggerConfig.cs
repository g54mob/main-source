using DG.Tweening;
using JetBrains.Annotations;

namespace VampireSurvivors.Framework.PhaserTweens
{
	public class StaggerConfig
	{
		public float start;

		public Ease ease;

		public int? fromInt;

		public string fromStr;

		[CanBeNull]
		public int[] grid;
	}
}
