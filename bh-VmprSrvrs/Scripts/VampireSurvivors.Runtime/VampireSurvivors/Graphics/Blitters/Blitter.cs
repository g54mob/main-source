using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.IL2CPP.CompilerServices;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Rendering;
using VampireSurvivors.Framework.Particles;

namespace VampireSurvivors.Graphics.Blitters
{
	[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
	public class Blitter : GameMonoBehaviour
	{
		[StructLayout((LayoutKind)0, Pack = 2, Size = 12)]
		private struct Index
		{
			public ushort b1;

			public ushort b2;

			public ushort b3;

			public ushort b4;

			public ushort b5;

			public ushort b6;

			public void Setup()
			{
			}

			public void Increment()
			{
			}
		}

		private MeshFilter _meshFilter;

		private MeshRenderer _meshRenderer;

		private BlitterRenderMode _renderMode;

		private readonly List<Bob> _bobs;

		private Texture2D _atlasTexture;

		private Mesh _mesh;

		private static Transform _blittersSceneParent;

		private NativeArray<BobFullVertex> vertices;

		private NativeArray<ushort> indices;

		private VertexAttributeDescriptor[] meshDescriptor;

		private static readonly ProfilerMarker s_updateMarker;

		private static readonly ProfilerMarker s_updateClearMarker;

		private static readonly ProfilerMarker s_updateApplyMeshMarker;

		public List<Bob> Children => null;

		public Mesh Mesh => null;

		public Material Material => null;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void OnDestroy()
		{
		}

		private void OnDrawGizmosSelected()
		{
		}

		public static Blitter CreateBlitter(VampireSurvivors.Framework.Particles.BlendMode blendMode = VampireSurvivors.Framework.Particles.BlendMode.Normal, Texture2D atlasTexture = null)
		{
			return null;
		}

		public Bob CreateBob(Vector2 pos, Sprite sprite)
		{
			return null;
		}

		public void RemoveBob(Bob bob)
		{
		}

		public void SetAtlasTexture(Texture2D atlasTexture)
		{
		}

		public void SetRenderMode(BlitterRenderMode renderMode)
		{
		}

		public void SetBlendMode(VampireSurvivors.Framework.Particles.BlendMode blendMode)
		{
		}

		public void SetDepth(int depth)
		{
		}

		public void ForceUpdate()
		{
		}

		private void GrabComponents()
		{
		}

		private void EnsureArraySizes(int numQuads)
		{
		}

		private void Init()
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Il2CppSetOption(/*Could not decode attribute arguments.*/)]
		private ref BobVertexData GetBobVertexData(Bob bob, int idx)
		{
			throw null;
		}

		public void ManualUpdate()
		{
		}

		private void UpdateBobs()
		{
		}

		private bool IsMeshOk(Mesh mesh)
		{
			return false;
		}

		private static void EnsureSceneParent()
		{
		}
	}
}
