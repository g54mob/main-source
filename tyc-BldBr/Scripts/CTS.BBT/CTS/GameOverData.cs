using System.Collections.Generic;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Game Over/Manager Data")]
	public class GameOverData : ScriptableObject
	{
		[SerializeField]
		private List<GameOverUIData> _gameOverList = new List<GameOverUIData>();

		[field: SerializeField]
		public float LooseTimerDuration { get; private set; } = 60f;

		[field: SerializeField]
		public float GraceTimerDuration { get; private set; } = 10f;

		public ReadOnlyList<GameOverUIData> GameOverList => _gameOverList;
	}
}
