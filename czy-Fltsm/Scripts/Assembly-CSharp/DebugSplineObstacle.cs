using UnityEngine;
using UnityEngine.UI;

public class DebugSplineObstacle : MonoBehaviour
{
	[SerializeField]
	private Image _radiusImage;

	public MapObstacle Obstacle { get; private set; }

	public void Initialize(MapObstacle obstacle)
	{
		Obstacle = obstacle;
		base.transform.localPosition = obstacle.Position;
		_radiusImage.rectTransform.sizeDelta = Vector2.one * obstacle.Radius * 2f;
	}

	public void SetColor(Color color)
	{
		_radiusImage.color = color;
	}
}
