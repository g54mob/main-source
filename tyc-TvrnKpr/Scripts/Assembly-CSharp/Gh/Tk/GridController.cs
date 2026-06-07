using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;

namespace Gh.Tk
{
	[PersistenceOptIn]
	public class GridController : IPersistable, IDisposable, ICustomSaveState
	{
		[CompilerGenerated]
		private sealed class _003CDetectRooms_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TileData startTile;

			public GridController _003C_003E4__this;

			private IEnumerator _003Cenumerator_003E5__2;

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
			public _003CDetectRooms_003Ed__21(int _003C_003E1__state)
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
		private sealed class _003CFloodFillArea_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public TileData start;

			public GridController _003C_003E4__this;

			private int _003CroomId_003E5__2;

			private Queue<TileData> _003Ctiles_003E5__3;

			private HashSet<TileData> _003CcheckedTiles_003E5__4;

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
			public _003CFloodFillArea_003Ed__25(int _003C_003E1__state)
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
		private sealed class _003CGetTilesInLine_003Ed__35 : IEnumerable<TileData>, IEnumerable, IEnumerator<TileData>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private TileData _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private Vector3 start;

			public Vector3 _003C_003E3__start;

			private Vector3 end;

			public Vector3 _003C_003E3__end;

			public GridController _003C_003E4__this;

			private int _003CendX_003E5__2;

			private int _003CtileY_003E5__3;

			private bool _003Csteep_003E5__4;

			private int _003Cdx_003E5__5;

			private int _003Cdz_003E5__6;

			private int _003Cerror_003E5__7;

			private int _003CzStep_003E5__8;

			private int _003Cz_003E5__9;

			private int _003Cx_003E5__10;

			TileData IEnumerator<TileData>.Current
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
			public _003CGetTilesInLine_003Ed__35(int _003C_003E1__state)
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

			[DebuggerHidden]
			IEnumerator<TileData> IEnumerable<TileData>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		internal TileData[,,] _tilesArray;

		internal int[] _tilesArrayLength;

		internal TileData[] _flatTileArray;

		private int _offsetX;

		private int _offsetY;

		private int _offsetZ;

		private GameObject _parent;

		internal int sessionId;

		public static EventHandler<EventArgs> GridChanged;

		public int WallGenerationSeed;

		internal TileData[] _atmosphereGridTiles;

		internal Dictionary<Vector3Int, int> _atmosphereGridTileIndex;

		public Dictionary<string, AtmosphereGrid> _atmosphereData;

		public NativeArray<Neighbours> neighbours;

		private Dictionary<(string zone, string effectType), sbyte> _zoneEquilibirumModifiersCache;

		public TileData[,,] GetTilesArray()
		{
			return null;
		}

		public TileData[] GetAllTiles()
		{
			return null;
		}

		public Vector3 GetTileArraySize()
		{
			return default(Vector3);
		}

		public Vector3 GetOffsets()
		{
			return default(Vector3);
		}

		public TileData GetTileOrDefault(int x, int y, int z)
		{
			return null;
		}

		public void CreateWallGenerationRng()
		{
		}

		public void ResetGridVisual()
		{
		}

		public void ResetGrid(bool isNewGame)
		{
		}

		public void CreateTileArray(TileData[] tiles)
		{
		}

		public void Add(TileData tile)
		{
		}

		public void Remove(TileData tile)
		{
		}

		[IteratorStateMachine(typeof(_003CDetectRooms_003Ed__21))]
		public IEnumerator DetectRooms(TileData startTile = null)
		{
			return null;
		}

		private void CheckAndEnqueueConnectingTile(TileData current, int xOffset, int zOffset, Queue<TileData> queue, HashSet<TileData> checkedTiles)
		{
		}

		private bool AreInside(params TileData[] tiles)
		{
			return false;
		}

		public ListPoolX.DisposablePooledList<(int, int)> GetActualWallPostPositionsAsDisposableList()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CFloodFillArea_003Ed__25))]
		private IEnumerator FloodFillArea(TileData start)
		{
			return null;
		}

		public TileData HitTest()
		{
			return null;
		}

		public Vector3 GetGridPosition(GameObjectX obj)
		{
			return default(Vector3);
		}

		public Vector3 GetGridPosition(GameObject obj)
		{
			return default(Vector3);
		}

		public void CreateFloorTiles(IEnumerable<TileData> data)
		{
		}

		public TileData GetTileOrDefault(Vector3Int position)
		{
			return null;
		}

		public TileData GetTileOrDefault(Vector3 position)
		{
			return null;
		}

		public void SaveState(IDataStore data)
		{
		}

		public void RestoreState(IDataStore data)
		{
		}

		[IteratorStateMachine(typeof(_003CGetTilesInLine_003Ed__35))]
		public IEnumerable<TileData> GetTilesInLine(Vector3 start, Vector3 end)
		{
			return null;
		}

		public bool IsTilesArrayPopulated()
		{
			return false;
		}

		public void Dispose()
		{
		}

		private void DestroyAtmosphereData()
		{
		}

		private void CreateAtmosphereData()
		{
		}

		internal void CreateNeighbourInfo(TileData tile, int index)
		{
		}

		private NeighbourInfo GetNeighbourInfo(TileData tile, string wall)
		{
			return default(NeighbourInfo);
		}

		private void SaveAtmosphereData(IDataStore data)
		{
		}

		private void RestoreAtmosphereData(IDataStore data)
		{
		}

		private void RefreshZoneEquilibriumCache()
		{
		}

		public void InvalidateAtmopshereEquilibriumValues(int roomId = 0)
		{
		}
	}
}
