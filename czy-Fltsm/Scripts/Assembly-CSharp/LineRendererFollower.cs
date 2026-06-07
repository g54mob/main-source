using UnityEngine;

public class LineRendererFollower : MonoBehaviour
{
	[SerializeField]
	private LineRenderer _lineRenderer;

	[SerializeField]
	private SpriteRenderer _spriteRenderer;

	private Transform _transform;

	private void Awake()
	{
		_transform = base.transform;
	}

	private void Update()
	{
		int positionCount = _lineRenderer.positionCount;
		if (positionCount >= 2)
		{
			_transform.position = _lineRenderer.GetPosition(positionCount - 1);
			_transform.rotation = Quaternion.LookRotation(_lineRenderer.GetPosition(positionCount - 1) - _lineRenderer.GetPosition(positionCount - 2));
		}
	}

	public void SetColor(Color color)
	{
		_spriteRenderer.color = color;
	}
}
