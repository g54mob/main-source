using System.Collections.Generic;
using UnityEngine;

public class CharacterExplosionPush : MonoBehaviour
{
	private struct PushParameters
	{
		public Vector3 direction;

		public float force;

		public PushParameters(Vector3 direction, float force)
		{
			this.direction = direction;
			this.force = force;
		}
	}

	public const float EXPLOSION_FORCE_MULTIPLIER = 45f;

	private const float FORCE_DECAY_RATE = 0.05f;

	private CustomFirstPersonController customFirstPersonController;

	private CharacterController characterController;

	private bool shouldPushPlayer;

	private bool initialized;

	private List<PushParameters> allPushParams = new List<PushParameters>();

	private void Start()
	{
		customFirstPersonController = GetComponent<CustomFirstPersonController>();
		characterController = GetComponent<CharacterController>();
		customFirstPersonController.provider.TrainCarExplosion_Register(OnPlayerInExplosion);
		if (customFirstPersonController == null)
		{
			Debug.LogError("CharacterExplosionPush requires CustomFirstPersonController reference. Destroying self.", this);
			Object.Destroy(this);
		}
		else
		{
			initialized = true;
		}
	}

	private void OnEnable()
	{
		if (initialized)
		{
			customFirstPersonController.provider.TrainCarExplosion_Register(OnPlayerInExplosion);
		}
	}

	private void OnDisable()
	{
		if (initialized)
		{
			customFirstPersonController.provider.TrainCarExplosion_Unregister(OnPlayerInExplosion);
			ResetPushParameters();
		}
	}

	public void OnPlayerInExplosion(Vector3 direction, float force)
	{
		shouldPushPlayer = (customFirstPersonController.isRepositioning = true);
		allPushParams.Add(new PushParameters(direction, force));
	}

	private void Update()
	{
		if (!shouldPushPlayer)
		{
			return;
		}
		if (!characterController.enabled)
		{
			characterController.enabled = true;
		}
		Vector3 zero = Vector3.zero;
		for (int i = 0; i < allPushParams.Count; i++)
		{
			if (allPushParams[i].force > float.Epsilon)
			{
				PushParameters value = allPushParams[i];
				zero += value.direction * value.force;
				value.force -= 0.05f * value.force;
				allPushParams[i] = value;
			}
		}
		if (zero.sqrMagnitude > 0.04f)
		{
			Vector3 vector = zero * 45f + Physics.gravity;
			characterController.Move(vector * Time.deltaTime);
		}
		else
		{
			ResetPushParameters();
		}
	}

	private void ResetPushParameters()
	{
		shouldPushPlayer = (customFirstPersonController.isRepositioning = false);
		allPushParams.Clear();
	}
}
