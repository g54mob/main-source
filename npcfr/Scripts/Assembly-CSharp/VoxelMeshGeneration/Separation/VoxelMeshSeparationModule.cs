using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TripledoseLibs.Collections;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using VoxelMeshGeneration.Separation.Performing;

namespace VoxelMeshGeneration.Separation
{
	public class VoxelMeshSeparationModule : MonoBehaviour
	{
		private sealed class di : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int plt;

			private object plu;

			public VoxelMeshSeparationModule plv;

			public ReadOnlyNativeHashSet<int3> plw;

			public ReadOnlyNativeHashSet<int3> plx;

			public Action ply;

			private List<NativeHashSet<int3>> plz;

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
			public di(int a)
			{
			}

			[DebuggerHidden]
			private void dkk()
			{
			}

			void IDisposable.Dispose()
			{
				//ILSpy generated this explicit interface implementation from .override directive in dkk
				this.dkk();
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
			private void dkm()
			{
			}

			void IEnumerator.Reset()
			{
				//ILSpy generated this explicit interface implementation from .override directive in dkm
				this.dkm();
			}
		}

		[SerializeField]
		private VoxelMesh m_mesh;

		[SerializeField]
		private VoxelMesh m_meshPrefab;

		private Coroutine pma;

		private bool pmb;

		private eb pmc;

		private dm pmd;

		private bool pme;

		private NativeHashSet<int3> pmf;

		private bool pmg;

		private bool pmh;

		public void dko(int3 a)
		{
		}

		public void dkp(Action<IReadOnlyList<SeparatedMeshData>, IReadOnlyCollection<int3>> a)
		{
		}

		public void dkq(int a)
		{
		}

		private void Awake()
		{
		}

		private void dkr(el a)
		{
		}

		[IteratorStateMachine(typeof(di))]
		private IEnumerator dks(ReadOnlyNativeHashSet<int3> a, ReadOnlyNativeHashSet<int3> b, Action c = null)
		{
			return null;
		}

		private void dkt()
		{
		}

		private bool dku()
		{
			return false;
		}

		private void dkv()
		{
		}

		private void dkw()
		{
		}

		private void dkx()
		{
		}
	}
}
