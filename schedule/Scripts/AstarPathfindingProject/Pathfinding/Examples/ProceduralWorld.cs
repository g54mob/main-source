using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Pathfinding.Examples
{
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_examples_1_1_procedural_world.php")]
	public class ProceduralWorld : MonoBehaviour
	{
		public enum RotationRandomness
		{
			AllAxes = 0,
			Y = 1
		}

		[Serializable]
		public class ProceduralPrefab
		{
			public GameObject prefab;

			public float density;

			public float perlin;

			public float perlinPower;

			public Vector2 perlinOffset;

			public float perlinScale;

			public float random;

			public RotationRandomness randomRotation;

			public bool singleFixed;
		}

		private class ProceduralTile
		{
			[CompilerGenerated]
			private sealed class _003CGenerate_003Ed__11 : IEnumerator<object>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private object _003C_003E2__current;

				public ProceduralTile _003C_003E4__this;

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
				public _003CGenerate_003Ed__11(int _003C_003E1__state)
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

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}
			}

			[CompilerGenerated]
			private sealed class _003CInternalGenerate_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private object _003C_003E2__current;

				public ProceduralTile _003C_003E4__this;

				private int _003Ccounter_003E5__2;

				private float[,] _003CditherMap_003E5__3;

				private int _003Ci_003E5__4;

				private ProceduralPrefab _003Cpref_003E5__5;

				private float _003CsubSize_003E5__6;

				private int _003Csx_003E5__7;

				private int _003Csz_003E5__8;

				private float _003Cpx_003E5__9;

				private float _003Cpz_003E5__10;

				private int _003Ccount_003E5__11;

				private int _003Cj_003E5__12;

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
				public _003CInternalGenerate_003Ed__16(int _003C_003E1__state)
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

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}
			}

			private int x;

			private int z;

			private System.Random rnd;

			private ProceduralWorld world;

			private Transform root;

			private IEnumerator ie;

			public bool destroyed { get; private set; }

			public ProceduralTile(ProceduralWorld world, int x, int z)
			{
			}

			[IteratorStateMachine(typeof(_003CGenerate_003Ed__11))]
			public IEnumerator Generate()
			{
				return null;
			}

			public void ForceFinish()
			{
			}

			private Vector3 RandomInside()
			{
				return default(Vector3);
			}

			private Vector3 RandomInside(float px, float pz)
			{
				return default(Vector3);
			}

			private Quaternion RandomYRot(ProceduralPrefab prefab)
			{
				return default(Quaternion);
			}

			[IteratorStateMachine(typeof(_003CInternalGenerate_003Ed__16))]
			private IEnumerator InternalGenerate()
			{
				return null;
			}

			public void Destroy()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CGenerateTiles_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public ProceduralWorld _003C_003E4__this;

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
			public _003CGenerateTiles_003Ed__13(int _003C_003E1__state)
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

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public Transform target;

		public ProceduralPrefab[] prefabs;

		public int range;

		public int disableAsyncLoadWithinRange;

		public float tileSize;

		public int subTiles;

		public bool staticBatching;

		private Queue<IEnumerator> tileGenerationQueue;

		private Dictionary<Int2, ProceduralTile> tiles;

		private void Start()
		{
		}

		private void Update()
		{
		}

		[IteratorStateMachine(typeof(_003CGenerateTiles_003Ed__13))]
		private IEnumerator GenerateTiles()
		{
			return null;
		}
	}
}
