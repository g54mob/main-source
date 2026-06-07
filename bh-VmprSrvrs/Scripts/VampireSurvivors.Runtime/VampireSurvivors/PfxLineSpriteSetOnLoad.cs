using UnityEngine;

namespace VampireSurvivors
{
	public class PfxLineSpriteSetOnLoad : MonoBehaviour
	{
		[DualToggleBoolButton("Line 1", "Line 2", "Select Line", true, false)]
		public bool _line1;

		private void Awake()
		{
		}
	}
}
