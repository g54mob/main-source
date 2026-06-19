using DG.Tweening;
using UnityEngine;

public class UIBounceGrowAnimation : MonoBehaviour
{
	[SerializeField]
	private RectTransform _target;

	[SerializeField]
	private float _growScale;

	[SerializeField]
	private float _growDuration;

	private Tween _tween;

	private void Awake()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}
}
