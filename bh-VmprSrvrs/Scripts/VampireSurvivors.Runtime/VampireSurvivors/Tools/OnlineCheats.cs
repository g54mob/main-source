using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.Tools
{
	public class OnlineCheats : GameMonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _authEnemiesCount;

		[SerializeField]
		private TextMeshProUGUI _nonAuthEnemiesCount;

		[SerializeField]
		private Slider _slider;

		[SerializeField]
		private TextMeshProUGUI _sliderTitle;

		protected override void OnUpdate()
		{
		}

		public void ToggleNetStats()
		{
		}

		public void DebugEnemyRemotePosition()
		{
		}

		public void DebugEnemyAuthority()
		{
		}
	}
}
