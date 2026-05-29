using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Photon.Pun.Demo.Procedural
{
	public class WorldGenerator : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CGenerateWorld_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public WorldGenerator _003C_003E4__this;

			private Dictionary<int, GameObject>.ValueCollection.Enumerator _003C_003E7__wrap1;

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
			public _003CGenerateWorld_003Ed__31(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
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

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public readonly string SeedPropertiesKey;

		public readonly string WorldSizePropertiesKey;

		public readonly string ClusterSizePropertiesKey;

		public readonly string WorldTypePropertiesKey;

		private static WorldGenerator instance;

		private Dictionary<int, GameObject> clusterList;

		public Material[] WorldMaterials;

		public static WorldGenerator Instance => null;

		public int Seed { get; set; }

		public WorldSize WorldSize { get; set; }

		public ClusterSize ClusterSize { get; set; }

		public WorldType WorldType { get; set; }

		public void Awake()
		{
		}

		public void CreateWorld()
		{
		}

		private void DestroyWorld()
		{
		}

		public void ConfirmAndUpdateProperties()
		{
		}

		public void DecreaseBlockHeight(int clusterId, int blockId)
		{
		}

		public void IncreaseBlockHeight(int clusterId, int blockId)
		{
		}

		[IteratorStateMachine(typeof(_003CGenerateWorld_003Ed__31))]
		private IEnumerator GenerateWorld()
		{
			return null;
		}
	}
}
