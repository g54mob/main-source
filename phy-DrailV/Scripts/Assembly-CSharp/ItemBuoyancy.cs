using DV.Utils;
using UnityEngine;

public class ItemBuoyancy : MonoBehaviour
{
	private const float BUOYANCY_MULTIPLIER = 60f;

	private const float DISABLE_HEIGHT_THRESHOLD = 0.5f;

	private const float MAX_VELOCITY = 4f;

	public float buoyancy = 1f;

	public float drag = 0.14f;

	private Rigidbody rb;

	private bool underwater;

	private float aboveWaterAngDrag;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		if (!rb)
		{
			Debug.LogError("Missing Rigidbody component");
		}
	}

	private void OnDisable()
	{
		underwater = false;
	}

	private void FixedUpdate()
	{
		Vector3 position = base.transform.TransformPoint(rb.centerOfMass);
		float num = LevelInfo.WaterLevel - position.y;
		if (num > 0f)
		{
			rb.AddForceAtPosition(Vector3.up * num * buoyancy * 60f, position, ForceMode.Acceleration);
			rb.AddForceAtPosition(-rb.velocity * drag * 0.5f, position, ForceMode.VelocityChange);
			Vector3 velocity = rb.velocity;
			velocity.y = Mathf.Min(velocity.y, 4f);
			rb.velocity = velocity;
			if (!underwater)
			{
				underwater = true;
				aboveWaterAngDrag = rb.angularDrag;
				rb.angularDrag = 1f;
				SingletonBehaviour<AudioManager>.Instance.waterSplashItemClip.Play(position, 1f, Random.Range(0.8f, 1.2f));
				if ((bool)SingletonBehaviour<ParticlePool>.Instance)
				{
					SingletonBehaviour<ParticlePool>.Instance.SpawnParticleOnWater("WaterSplashItem", position);
				}
			}
		}
		else
		{
			if (underwater)
			{
				underwater = false;
				rb.angularDrag = aboveWaterAngDrag;
			}
			if (num < -0.5f)
			{
				base.enabled = false;
			}
		}
	}
}
