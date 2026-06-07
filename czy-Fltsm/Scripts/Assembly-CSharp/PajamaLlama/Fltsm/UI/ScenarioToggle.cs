using UnityEngine;

namespace PajamaLlama.Fltsm.UI
{
	public class ScenarioToggle : AnimatedToggle
	{
		[Header("Scenario Toggle")]
		[SerializeField]
		private TileProperties _tileProperties;

		[SerializeField]
		private bool _isTutorial;

		public TileProperties TileProperties => _tileProperties;

		public bool IsTutorial => _isTutorial;
	}
}
