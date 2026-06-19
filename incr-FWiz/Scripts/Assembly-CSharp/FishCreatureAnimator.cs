using DG.Tweening;
using UnityEngine;

public class FishCreatureAnimator : MonoBehaviour
{
	[SerializeField]
	private FishCreature _fishCreature;

	[SerializeField]
	private Transform _targetTransform;

	[SerializeField]
	private Vector2 _onHitScaleModifier;

	[SerializeField]
	private float _onHitAnimationDuration;

	private Tween _tween;

	[SerializeField]
	private float _damageSizeModifier;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public void OnHit(bool finished)
	{
	}
}
