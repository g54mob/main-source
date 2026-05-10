using System.Collections.Generic;
using UnityEngine;

namespace AmplifyImpostors
{
	[CreateAssetMenu(fileName = "New Impostor", order = 85)]
	public class AmplifyImpostorAsset : ScriptableObject
	{
		[SerializeField]
		public Material Material;

		[SerializeField]
		public Mesh Mesh;

		[HideInInspector]
		[SerializeField]
		public int Version;

		[SerializeField]
		public ImpostorType ImpostorType;

		[HideInInspector]
		[SerializeField]
		public bool LockedSizes;

		[SerializeField]
		[HideInInspector]
		public int SelectedSize;

		[SerializeField]
		public Vector2 TexSize;

		[HideInInspector]
		[SerializeField]
		public bool DecoupleAxisFrames;

		[Range(1f, 32f)]
		[SerializeField]
		public int HorizontalFrames;

		[Range(1f, 33f)]
		[SerializeField]
		public int VerticalFrames;

		[Range(0f, 64f)]
		[SerializeField]
		public int PixelPadding;

		[Range(4f, 16f)]
		[SerializeField]
		public int MaxVertices;

		[SerializeField]
		[Range(0f, 0.2f)]
		public float Tolerance;

		[Range(0f, 1f)]
		[SerializeField]
		public float NormalScale;

		[SerializeField]
		public Vector2[] ShapePoints;

		[SerializeField]
		public AmplifyImpostorBakePreset Preset;

		[SerializeField]
		public List<TextureOutput> OverrideOutput;
	}
}
