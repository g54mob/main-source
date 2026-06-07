using FMODUnity;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingSFXPalette", menuName = "Bouncer/BuildingSFXPalette")]
public class BuildingSFXPalette : ScriptableObject
{
	public EventReference SFXOnHit;

	public EventReference SFXOnPickup;

	public EventReference SFXOnPlace;

	public EventReference SFXOnHover;

	public EventReference SFXOnDismantle;

	public void PlayHitSFX(Transform xfm)
	{
	}

	public void PlayPickupSFX(float size)
	{
	}

	public void PlayPlaceSFX(float size)
	{
	}

	public void PlayHoverSFX(Transform xfm)
	{
	}

	public void PlayDismantleSFX(float size)
	{
	}
}
