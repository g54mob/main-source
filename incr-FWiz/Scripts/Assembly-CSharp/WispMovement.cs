using System.Collections.Generic;
using UnityEngine;

public class WispMovement : MonoBehaviour
{
	[Header("Movement")]
	public float Speed;

	public float NoiseScale;

	private float _noiseX;

	private float _noiseY;

	public Vector2 MoveSpace;

	private float _effectiveSpeed;

	public float SpeedBumpOnHit;

	public float SpeedBumpOnHitDuration;

	private Vector2 _basePosition;

	public List<ParticleSystem> MovementParticles;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void UpdatePosition()
	{
	}

	public void OnHit()
	{
	}
}
