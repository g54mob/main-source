using UnityEngine;

namespace Dreamteck.Splines
{
	[RequireComponent(typeof(MeshFilter))]
	[RequireComponent(typeof(MeshRenderer))]
	[AddComponentMenu("Dreamteck/Splines/Users/Tube Generator")]
	public class TubeGenerator : MeshGenerator
	{
		public enum CapMethod
		{
			None = 0,
			Flat = 1,
			Round = 2
		}

		[SerializeField]
		[HideInInspector]
		private int _sides;

		[SerializeField]
		[HideInInspector]
		private int _roundCapLatitude;

		[SerializeField]
		[HideInInspector]
		private CapMethod _capMode;

		[SerializeField]
		[HideInInspector]
		[Range(0f, 360f)]
		private float _revolve;

		[SerializeField]
		[HideInInspector]
		private float _capUVScale;

		[SerializeField]
		[HideInInspector]
		private float _uvTwist;

		private int bodyVertexCount;

		private int bodyTrisCount;

		private int capVertexCount;

		private int capTrisCount;

		public int sides
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public CapMethod capMode
		{
			get
			{
				return default(CapMethod);
			}
			set
			{
			}
		}

		public int roundCapLatitude
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float revolve
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float capUVScale
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float uvTwist
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private bool useCap => false;

		protected override string meshName => null;

		protected override void Reset()
		{
		}

		protected override void BuildMesh()
		{
		}

		private void Generate()
		{
		}

		private void GenerateFlatCaps()
		{
		}

		private void GenerateRoundCaps()
		{
		}
	}
}
