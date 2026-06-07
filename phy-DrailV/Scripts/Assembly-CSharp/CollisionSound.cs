using System.Collections.Generic;
using DV.CabControls.Spec;
using UnityEngine;

public class CollisionSound : DebouncedSound
{
	public AudioClip sound;

	private Collider[] colliders;

	private static readonly Dictionary<Collider, CollisionSound> colliderToSoundMapping = new Dictionary<Collider, CollisionSound>();

	[SerializeField]
	private ItemCollisionSoundCategory itemCollisionSoundCategory;

	[SerializeField]
	private ItemCollisionSoundCategory ignoredCollisionSoundCategory;

	private void Start()
	{
		if (!sound && itemCollisionSoundCategory != ItemCollisionSoundCategory.NeverPlayCollisionSounds)
		{
			Debug.LogWarning("CollisionSound has no sound assigned", base.gameObject);
		}
		colliders = GetComponentsInChildren<Collider>(includeInactive: true);
		Collider[] array = colliders;
		foreach (Collider key in array)
		{
			colliderToSoundMapping[key] = this;
		}
	}

	public void InitializeCollisionSoundCategory(ItemCollisionSoundCategory itemCollisionSoundCategory, ItemCollisionSoundCategory ignoredCollisionSoundCategory)
	{
		this.itemCollisionSoundCategory = itemCollisionSoundCategory;
		this.ignoredCollisionSoundCategory = ignoredCollisionSoundCategory;
	}

	private void OnDestroy()
	{
		if (colliders != null)
		{
			Collider[] array = colliders;
			foreach (Collider key in array)
			{
				colliderToSoundMapping.Remove(key);
			}
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.relativeVelocity.sqrMagnitude < 0.0001f || itemCollisionSoundCategory == ItemCollisionSoundCategory.NeverPlayCollisionSounds)
		{
			return;
		}
		float value = (collision.relativeVelocity.magnitude - 0.01f) / 3f;
		Vector3 point = collision.GetContact(0).point;
		float volume = Mathf.Clamp01(value);
		if (colliderToSoundMapping.TryGetValue(collision.collider, out var value2))
		{
			if (ShouldPlayCollisionSelf(value2.itemCollisionSoundCategory))
			{
				PlayDebounced(sound, point, volume);
			}
			if (ShouldPlayCollisionOther(value2.itemCollisionSoundCategory, value2.ignoredCollisionSoundCategory))
			{
				PlayDebounced(value2.sound, point, volume);
			}
		}
		else
		{
			PlayDebounced(sound, point, volume);
		}
	}

	private bool ShouldPlayCollisionSelf(ItemCollisionSoundCategory otherSoundCategory)
	{
		switch (otherSoundCategory)
		{
		case ItemCollisionSoundCategory.NeverPlayCollisionSounds:
			return false;
		case ItemCollisionSoundCategory.Generic:
			return true;
		default:
			if (ignoredCollisionSoundCategory == otherSoundCategory)
			{
				return false;
			}
			return true;
		}
	}

	private bool ShouldPlayCollisionOther(ItemCollisionSoundCategory otherSoundCategory, ItemCollisionSoundCategory otherIgnoredSoundCategory)
	{
		if (otherSoundCategory == ItemCollisionSoundCategory.NeverPlayCollisionSounds)
		{
			return false;
		}
		if (otherIgnoredSoundCategory == ItemCollisionSoundCategory.Generic)
		{
			return true;
		}
		if (itemCollisionSoundCategory == otherIgnoredSoundCategory)
		{
			return false;
		}
		return true;
	}
}
