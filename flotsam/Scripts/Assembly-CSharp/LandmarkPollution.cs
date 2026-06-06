using PajamaLlama.Math;
using UnityEngine;

[DisallowMultipleComponent]
public class LandmarkPollution : MonoBehaviour
{
	[SerializeField]
	private Landmark _landmark;

	[SerializeField]
	private float _pollutionPerDay;

	private Polygon _polygon;

	private float _pollutionPerSecond;

	private void OnValidate()
	{
		if (_landmark == null)
		{
			_landmark = GetComponent<Landmark>();
		}
	}

	private void Awake()
	{
		OnValidate();
		base.enabled = (bool)_landmark && _landmark.IsInteractable;
		if (base.enabled)
		{
			if (0f < _landmark.Behaviour.PollutionPerDay)
			{
				_pollutionPerDay = _landmark.Behaviour.PollutionPerDay;
			}
			_pollutionPerSecond = _pollutionPerDay / TimeManager.DayDuration;
			_polygon = _landmark.Obstacle.Polygon;
		}
	}

	private void LateUpdate()
	{
		foreach (Agent agent in Community.PlayerCommunity.Agents)
		{
			Vector2 point = agent.transform.position.Vector2TopDown();
			if (_polygon.Bounds.Contains(point) && _polygon.ReturnPointIsOverlapping(point))
			{
				agent.Vitals.Pollution.Increase(_pollutionPerSecond * Time.deltaTime);
			}
		}
	}
}
