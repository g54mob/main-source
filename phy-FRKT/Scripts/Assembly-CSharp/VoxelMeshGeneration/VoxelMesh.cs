using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using VoxelMeshGeneration.Chunks;
using VoxelMeshGeneration.Tools.Morphs;

namespace VoxelMeshGeneration
{
	public sealed class VoxelMesh : MonoBehaviour
	{
		[BurstCompile]
		public struct Voxels
		{
			public readonly int length;

			public readonly int height;

			public readonly int width;

			public readonly int xMaxIndex;

			public readonly int yMaxIndex;

			public readonly int zMaxIndex;

			private NativeArray<Voxel> m_voxels;

			public int wua => 0;

			public int3 wub => default(int3);

			public Voxel this[int x, int y, int z] => default(Voxel);

			public Voxel this[Vector3Int index] => default(Voxel);

			public Voxel this[int3 index] => default(Voxel);

			public Voxel this[int index] => default(Voxel);

			public Voxels(Voxels copySource, NativeHashSet<int> enabledVoxelIndexes)
			{
				length = 0;
				height = 0;
				width = 0;
				xMaxIndex = 0;
				yMaxIndex = 0;
				zMaxIndex = 0;
				m_voxels = default(NativeArray<Voxel>);
			}

			public Voxels(NativeArray<Voxel> voxelsArray, int length, int height, int width)
			{
				this.length = 0;
				this.height = 0;
				this.width = 0;
				xMaxIndex = 0;
				yMaxIndex = 0;
				zMaxIndex = 0;
				m_voxels = default(NativeArray<Voxel>);
			}

			public Voxels(Voxels copySource)
			{
				length = 0;
				height = 0;
				width = 0;
				xMaxIndex = 0;
				yMaxIndex = 0;
				zMaxIndex = 0;
				m_voxels = default(NativeArray<Voxel>);
			}

			public static int dez(int a, int b, int c, int d, int e)
			{
				return 0;
			}

			public bool dfa(Vector3Int a)
			{
				return false;
			}

			public bool dfb(int3 a)
			{
				return false;
			}

			public void dfc(int a, int b, int c, Voxel d)
			{
			}

			public int dfd(Vector3Int a)
			{
				return 0;
			}

			public int dfe(int3 a)
			{
				return 0;
			}

			public int dff(int a, int b, int c)
			{
				return 0;
			}

			public void dfg(int3 a, Voxel b)
			{
			}

			public void dfh()
			{
			}
		}

		public readonly struct Voxel : IEquatable<Voxel>
		{
			public readonly bool enabled;

			public readonly RGBAtlasColor color;

			public Voxel(bool enabled, RGBAtlasColor color)
			{
				this.enabled = false;
				this.color = default(RGBAtlasColor);
			}

			[SpecialName]
			public static bool dfi(Voxel a, Voxel b)
			{
				return false;
			}

			[SpecialName]
			public static bool dfj(Voxel a, Voxel b)
			{
				return false;
			}

			public bool Equals(Voxel other)
			{
				return false;
			}

			public override bool Equals(object obj)
			{
				return false;
			}

			public override int GetHashCode()
			{
				return 0;
			}
		}

		private sealed class cg : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int piv;

			private object piw;

			public er pix;

			public VoxelMesh piy;

			private IReadOnlyList<ej> piz;

			private int pja;

			private int pjb;

			private JobHandle pjc;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public cg(int a)
			{
			}

			[DebuggerHidden]
			private void dfk()
			{
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in dfk
				this.dfk();
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			private void dfm()
			{
			}

			void IEnumerator.Reset()
			{
				//ILSpy generated this explicit interface implementation from .override directive in dfm
				this.dfm();
			}
		}

		private sealed class ch : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int pjd;

			private object pje;

			public VoxelMesh pjf;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public ch(int a)
			{
			}

			[DebuggerHidden]
			private void dfo()
			{
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in dfo
				this.dfo();
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			private void dfq()
			{
			}

			void IEnumerator.Reset()
			{
				//ILSpy generated this explicit interface implementation from .override directive in dfq
				this.dfq();
			}
		}

		[SerializeField]
		private Vector3 m_meshDisplacement;

		[SerializeField]
		private Material m_material;

		private Transform pjk;

		private cc pjl;

		private er pjm;

		private Coroutine pjn;

		private Coroutine pjo;

		private readonly List<er> pjp;

		private readonly Dictionary<int3, ej> pjq;

		private readonly List<ej> pjr;

		private readonly List<ek> pjs;

		private cr pjt;

		public bool pju
		{
			[CompilerGenerated]
			get
			{
				return false;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public Vector3 pjv
		{
			[CompilerGenerated]
			get
			{
				return default(Vector3);
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public Voxels pjw
		{
			[CompilerGenerated]
			get
			{
				return default(Voxels);
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public Voxels pjx
		{
			[CompilerGenerated]
			get
			{
				return default(Voxels);
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public Vector3 pjy
		{
			[CompilerGenerated]
			get
			{
				return default(Vector3);
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public cq wug => null;

		public IReadOnlyDictionary<int3, ej> wuh => null;

		public int wui => 0;

		public Transform wuj => null;

		public event Action pjg
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action pjh
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<hz<int3, Voxel>> pji
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<el> pjj
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void dgo(ek a)
		{
		}

		public IReadOnlyList<ek> dgp()
		{
			return null;
		}

		public void dgq(Voxels a, Vector3 b, bool c)
		{
		}

		public void dgr(int a)
		{
		}

		public void dgs(VoxelMorphData a)
		{
		}

		public void dgt(int a = 0)
		{
		}

		public void dgu(VoxelMorphData[] a, int b = 0)
		{
		}

		public void dgv()
		{
		}

		public void dgw()
		{
		}

		private void dgx(Action a)
		{
		}

		private void dgy(hx<int3, Voxel> a, int b, Action<el> c, Action<el> d)
		{
		}

		private void dgz(er a)
		{
		}

		[IteratorStateMachine(typeof(ch))]
		private IEnumerator dha()
		{
			return null;
		}

		private er dhb()
		{
			return null;
		}

		[IteratorStateMachine(typeof(cg))]
		private IEnumerator dhc(er a)
		{
			return null;
		}

		private void dhd(el a)
		{
		}

		private void dhe()
		{
		}

		private void dhf(el a)
		{
		}

		private void dhg()
		{
		}

		private void dhh()
		{
		}

		[BurstCompile]
		private NativeList<VoxelMeshChunkData> dhi()
		{
			return default(NativeList<VoxelMeshChunkData>);
		}

		private ej dhj(VoxelMeshChunkData a)
		{
			return null;
		}

		private Transform dhk()
		{
			return null;
		}

		private void OnDestroy()
		{
		}

		private void dhl()
		{
		}
	}
}
