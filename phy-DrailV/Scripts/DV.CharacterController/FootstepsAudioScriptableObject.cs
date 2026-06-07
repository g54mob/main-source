using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "DV/Footsteps Audio")]
public class FootstepsAudioScriptableObject : ScriptableObject
{
	public enum SurfaceType
	{
		None = 0,
		Grass = 1,
		Forest = 2,
		Gravel = 3,
		Ballast = 4,
		Rock = 5,
		Liquid = 6,
		Wood = 7,
		Metal = 8,
		Scrap = 9,
		Snow = 10,
		PineNeedles = 11,
		Yard = 12,
		Water = 13,
		Asphalt = 14,
		Ladder = 15
	}

	public enum MovementType
	{
		Walking = 0,
		Running = 1,
		Crouching = 2,
		Landing = 3
	}

	[Serializable]
	public struct FootstepsData
	{
		public SurfaceType surface;

		public List<AudioClip> footstepSoundClips;

		[Range(0f, 0.2f)]
		public float maxPitchShift;
	}

	[Header("Footsteps Settings")]
	public float runFootstepVolume = 1f;

	public float walkFootstepVolume = 0.5f;

	public float crouchFootstepVolume = 0.2f;

	public AudioClip landingSoundSoft;

	public AudioClip landingSoundHard;

	public LayerMask traversableLayers;

	[Layer]
	public int terrainLayer;

	[Header("Default Footsteps")]
	public FootstepsData defaultFootstepsData;

	public FootstepsData[] allData;
}
