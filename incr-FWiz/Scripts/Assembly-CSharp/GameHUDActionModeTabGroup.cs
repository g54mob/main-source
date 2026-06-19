using DG.Tweening;
using UnityEngine;

public class GameHUDActionModeTabGroup : MonoBehaviour
{
	[SerializeField]
	private RectTransform _target;

	[SerializeField]
	private Vector2 _activeOffset;

	[SerializeField]
	private Vector2 _disabledOffset;

	private Vector2 _basePosition;

	[SerializeField]
	private float _animationSpeed;

	private Tween _tween;

	private void Start()
	{
	}

	public void Initiate()
	{
	}

	private void OnDestroy()
	{
	}

	public void OnModeActive()
	{
	}

	public void OnModeInactive()
	{
	}

	private void EvaluateState(bool animation = true)
	{
	}
}
