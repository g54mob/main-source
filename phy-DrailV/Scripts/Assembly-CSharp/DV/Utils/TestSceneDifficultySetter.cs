using UnityEngine;

namespace DV.Utils
{
	public class TestSceneDifficultySetter : MonoBehaviour
	{
		public enum Difficulty
		{
			None = 0,
			Comfort = 1,
			Standard = 2,
			Realistic = 3
		}

		public Difficulty difficulty;

		private void Awake()
		{
			switch (difficulty)
			{
			case Difficulty.Comfort:
				DifficultyParamsSetter.SetDifficultyParams(DifficultyParamsSetter.Comfort);
				break;
			case Difficulty.Standard:
				DifficultyParamsSetter.SetDifficultyParams(DifficultyParamsSetter.Standard);
				break;
			case Difficulty.Realistic:
				DifficultyParamsSetter.SetDifficultyParams(DifficultyParamsSetter.Realistic);
				break;
			case Difficulty.None:
				return;
			}
			Debug.Log($"Set difficulty in test scene to {difficulty}");
		}
	}
}
