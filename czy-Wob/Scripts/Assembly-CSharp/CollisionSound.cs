using UnityEngine;

public class CollisionSound : MonoBehaviour
{
	public string mudThudID = "thud_mud";

	public string softThudID = "thud_soft";

	public string hardThudID = "thud_hard";

	private string customCollisionSound = "";

	private bool hasCustomCollisionSound;

	private float? customMinVelocity;

	private float? customMaxVelocity;

	private string customCollisionSoundFilterTag;

	private float minVelocity = 5f;

	private float maxVelocity = 35f;

	private float minimumVolume = 0.25f;

	private CollisionSoundManager collisionSoundManagerRef;

	private void Awake()
	{
		collisionSoundManagerRef = base.transform.root.GetComponent<CollisionSoundManager>();
		if (collisionSoundManagerRef == null)
		{
			collisionSoundManagerRef = base.transform.root.gameObject.AddComponent<CollisionSoundManager>();
		}
	}

	private void OnCollisionEnter(Collision c)
	{
		if (c.transform.root != base.transform.root)
		{
			PlayBodyCollisionSound(c);
		}
	}

	public void SetCustomCollisionSound(string newSound, string customTag = null, float? minVel = null, float? maxVel = null)
	{
		hasCustomCollisionSound = true;
		customCollisionSound = newSound;
		customCollisionSoundFilterTag = customTag;
		customMinVelocity = minVel;
		customMaxVelocity = maxVel;
	}

	private void PlayBodyCollisionSound(Collision c)
	{
		if (!collisionSoundManagerRef.CanPlayCollisionSound())
		{
			return;
		}
		collisionSoundManagerRef.OnCollisionSoundPlayed();
		float num = minVelocity;
		if (customMinVelocity.HasValue)
		{
			num = customMinVelocity.Value;
		}
		float num2 = maxVelocity;
		if (customMaxVelocity.HasValue)
		{
			num2 = customMaxVelocity.Value;
		}
		float magnitude = c.relativeVelocity.magnitude;
		if (magnitude < minVelocity || c.transform.root == base.transform.root)
		{
			return;
		}
		float volume = Mathf.Max((Mathf.Min(c.relativeVelocity.magnitude, maxVelocity) - minVelocity) / (maxVelocity - minVelocity), minimumVolume);
		Vector3 point = c.contacts[0].point;
		if (hasCustomCollisionSound && magnitude >= num)
		{
			float volume2 = Mathf.Max((Mathf.Min(c.relativeVelocity.magnitude, num2) - num) / (num2 - num), minimumVolume);
			if (customCollisionSoundFilterTag == null || c.transform.root.tag == customCollisionSoundFilterTag)
			{
				AudioController.Play(customCollisionSound, point, null, volume2);
			}
		}
		string audioIDForCollisionType = hardThudID;
		WallBase wallBase = null;
		if (c.transform.parent != null)
		{
			wallBase = c.transform.parent.GetComponent<WallBase>();
		}
		if (wallBase == null && base.transform.parent != null)
		{
			wallBase = base.transform.parent.GetComponent<WallBase>();
		}
		if (wallBase != null)
		{
			audioIDForCollisionType = GetAudioIDForCollisionType(wallBase.collisionType);
		}
		AudioController.Play(audioIDForCollisionType, point, null, volume);
	}

	public string GetAudioIDForCollisionType(CollisionType cType)
	{
		switch (cType)
		{
		case CollisionType.NORMAL:
			return hardThudID;
		case CollisionType.SOFT:
			return softThudID;
		case CollisionType.MUD:
			return mudThudID;
		default:
			Debug.LogError("No valid collision sound found for type: " + cType);
			return hardThudID;
		}
	}
}
