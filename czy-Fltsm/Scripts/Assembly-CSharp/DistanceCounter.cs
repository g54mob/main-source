using UnityEngine;
using UnityEngine.UI;

public class DistanceCounter : MonoBehaviour
{
	[Tooltip("The text component attached to this counter.")]
	[SerializeField]
	private Text _counterText;

	private const float _nauticalMile = 1852f;

	private float _distanceTravelled;

	private float _speed;

	private GameData _gameData;

	private StringFormatter _stringFormatter;

	private void Start()
	{
		Initialize();
	}

	private void Initialize()
	{
		_gameData = GameManager.GameStatsManager.GameData;
		_stringFormatter = new StringFormatter(128);
	}

	private void LateUpdate()
	{
		UpdateCounter();
	}

	private void UpdateCounter()
	{
		if (!Mathf.Approximately(_gameData.DistanceTravelled, _distanceTravelled))
		{
			_speed = _gameData.CurrentVelocity / 1852f * 3600f;
			_distanceTravelled = _gameData.DistanceTravelled / 1852f;
			_counterText.text = _stringFormatter.Format("{0:F3} M ({1:F1} kn)", _distanceTravelled, _speed);
		}
	}
}
