using UnityEngine;

namespace Dreamteck.Splines
{
	[RequireComponent(typeof(MeshFilter))]
	[RequireComponent(typeof(MeshRenderer))]
	[AddComponentMenu("Dreamteck/Splines/Users/Waveform Generator")]
	public class WaveformGenerator : MeshGenerator
	{
		public enum Axis
		{
			X = 0,
			Y = 1,
			Z = 2
		}

		public enum Space
		{
			World = 0,
			Local = 1
		}

		public enum UVWrapMode
		{
			Clamp = 0,
			UniformX = 1,
			UniformY = 2,
			Uniform = 3
		}

		[SerializeField]
		[HideInInspector]
		private Axis _axis;

		[SerializeField]
		[HideInInspector]
		private bool _symmetry;

		[SerializeField]
		[HideInInspector]
		private UVWrapMode _uvWrapMode;

		[SerializeField]
		[HideInInspector]
		private int _slices;

		public Axis axis
		{
			get
			{
				return default(Axis);
			}
			set
			{
			}
		}

		public bool symmetry
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public UVWrapMode uvWrapMode
		{
			get
			{
				return default(UVWrapMode);
			}
			set
			{
			}
		}

		public int slices
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		protected override string meshName => null;

		protected override void BuildMesh()
		{
		}

		protected override void Build()
		{
		}

		protected override void LateRun()
		{
		}

		private void Generate()
		{
		}
	}
}
