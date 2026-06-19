using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WispCreatureAnimator : MonoBehaviour
{
	[SerializeField]
	private GameObject _wispHitEffect;

	public Light2D Light;

	public Transform Transform;

	public float GrowAnimationTime;

	public void OnHit()
	{
	}

	private void Start()
	{
	}
}
