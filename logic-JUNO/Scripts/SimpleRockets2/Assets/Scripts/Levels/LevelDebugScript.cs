using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Levels
{
	public class LevelDebugScript : MonoBehaviour
	{
		[SerializeField]
		private string _levelId = string.Empty;

		[SerializeField]
		private bool _startInFlight = true;

		protected virtual void Start()
		{
			Game.EnsureInitialized();
			LevelManager levelManager = Game.Instance.LevelManager as LevelManager;
			LevelData levelData = levelManager.Levels.Where((LevelData x) => x.Id == _levelId).FirstOrDefault();
			if (levelData != null)
			{
				levelManager.DebuggingFlightScene = _startInFlight;
				Game.Instance.LevelManager.StartLevel(levelData);
			}
			else
			{
				Debug.LogError("Could not find level with ID: " + _levelId);
			}
		}
	}
}
