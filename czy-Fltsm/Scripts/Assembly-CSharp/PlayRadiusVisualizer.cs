using System;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class PlayRadiusVisualizer : MonoBehaviour
{
	public enum RadiusType
	{
		Construction = 0,
		Map = 1,
		Interaction = 2,
		Swim = 3,
		MarkerRadius = 4
	}

	[SerializeField]
	private int _points = 32;

	[SerializeField]
	private RadiusType _radiusType;

	private void Awake()
	{
		float radius = 0f;
		switch (_radiusType)
		{
		case RadiusType.Construction:
			radius = GameSettings.Instance.GameplaySettings.ConstructionRadius;
			break;
		case RadiusType.Map:
			radius = GameSettings.Instance.GameplaySettings.MapRadius;
			break;
		case RadiusType.Interaction:
			radius = GameSettings.Instance.GameplaySettings.InteractionRadius;
			break;
		case RadiusType.Swim:
			radius = GameSettings.Instance.GameplaySettings.SwimmingRadius;
			break;
		case RadiusType.MarkerRadius:
		{
			GameplaySettings gameplaySettings = GameSettings.Instance.GameplaySettings;
			Community playerCommunity = Community.PlayerCommunity;
			radius = (playerCommunity.HasBoat() ? gameplaySettings.InteractionRadius : gameplaySettings.SwimmingRadius);
			playerCommunity.BoatsUpdatedEvent += OnBoatBuilt;
			break;
		}
		}
		SetRadius(radius);
	}

	private void OnDestroy()
	{
		if (_radiusType == RadiusType.MarkerRadius)
		{
			Community.PlayerCommunity.BoatsUpdatedEvent -= OnBoatBuilt;
		}
	}

	private void SetRadius(float radius)
	{
		float num = 360f / (float)_points;
		Vector3[] array = new Vector3[_points];
		float y = base.transform.position.y;
		for (int i = 0; i < _points; i++)
		{
			array[i] = new Vector3(Mathf.Cos(num * (float)i * (MathF.PI / 180f)) * radius, Mathf.Sin(num * (float)i * (MathF.PI / 180f)) * radius, 0f - y);
		}
		LineRenderer component = GetComponent<LineRenderer>();
		component.positionCount = _points;
		component.SetPositions(array);
	}

	private void OnBoatBuilt()
	{
		if (_radiusType == RadiusType.MarkerRadius)
		{
			GameplaySettings gameplaySettings = GameManager.Settings.GameplaySettings;
			Community playerCommunity = Community.PlayerCommunity;
			SetRadius(playerCommunity.HasBoat() ? gameplaySettings.InteractionRadius : gameplaySettings.SwimmingRadius);
		}
	}
}
