using System;
using DistantLands.Cozy.Data;
using UnityEngine;

namespace DistantLands.Cozy
{
	[Serializable]
	[CreateAssetMenu(menuName = "Distant Lands/Cozy/Plume Profile", order = 361)]
	public class PlumeProfile : CozyProfile
	{
		[Range(1f, 30f)]
		[Tooltip("Controls how many particles the individual cloud chunks will spawn")]
		public float cloudDensity = 10f;

		[Tooltip("Controls the size of the cloud particles")]
		[Range(10f, 200f)]
		public float cloudParticleSize = 100f;

		[Range(50f, 500f)]
		[Tooltip("Controls the size of the individual cloud chunks")]
		public float chunkSize = 150f;

		[Tooltip("Controls the minimum vertical size that a cloud chunk will be")]
		[Range(0f, 100f)]
		public float minChunkHeight = 10f;

		[Tooltip("Controls the maximum vertical size that a cloud chunk will be")]
		[Range(10f, 1000f)]
		public float maxChunkHeight = 300f;

		[Range(1f, 20f)]
		[Tooltip("Controls how many chunks in the distance PLUME will generate. High values will lower performance")]
		public int renderDistance = 10;

		[Tooltip("Controls the height that clouds spawn at")]
		public float cloudHeight = 300f;

		[Range(0f, 500f)]
		[Tooltip("Controls a nosie profile that changes the height that clouds spawn at")]
		public float cloudHeightDistrubution = 100f;

		[Range(1f, 10f)]
		[Tooltip("Controls the size of the noise that spawns clouds")]
		public float noiseScale = 5f;

		[Tooltip("Controls the seed of the noise that spawns clouds")]
		public float seed;

		[Tooltip("Controls noise scrolling speed for the cloud generation")]
		public Vector3 windSpeed = new Vector3(0.2f, 0f, 0.5f);

		[Range(10f, 5000f)]
		[Tooltip("Controls the maximum distance for normal combination (combining the normals of individual clouds reduces contrast and makes the clouds seem larger")]
		public float normalizedDistance = 5000f;

		[Tooltip("Controls height (0-1) that causes a cloud to be determined as a \"center\" for combination")]
		[Range(0f, 1f)]
		public float normalReferenceHeight = 0.5f;

		[Tooltip("Multiplies the color that clouds will have in the sun")]
		[Range(0.5f, 3f)]
		public float cloudColorMultiplier = 1.2f;

		[Tooltip("Multiplies the color that clouds will have in the shade")]
		[Range(0.5f, 3f)]
		public float cloudShadowColorMultiplier = 1f;
	}
}
