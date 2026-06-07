using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
	private int score;

	public static ScoreCalculator Instance { get; private set; }

	private void Awake()
	{
		Instance = this;
	}

	public int CalculateScore(ObjectSO objectSO, EnvironmentSunlight.Sunlight sunlight, EnvironmentHumidity.Humidity humidity)
	{
		float num = score;
		if (objectSO != null)
		{
			num = objectSO.score;
			if (objectSO.sunlight == sunlight && objectSO.humidity == humidity)
			{
				num += num;
			}
			else if (objectSO.sunlight == sunlight || objectSO.humidity == humidity)
			{
				num += num / 2f;
			}
			score = Mathf.CeilToInt(num);
		}
		else
		{
			Debug.Log("objectSO is null!");
		}
		return score;
	}
}
