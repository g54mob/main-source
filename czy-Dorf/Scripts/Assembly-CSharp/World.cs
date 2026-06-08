using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class World : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<Tile, bool> _003C_003E9__18_0;

		internal bool _003CGetAllPlacedTiles_003Eb__18_0(Tile x)
		{
			return x.State == TileState.placed;
		}
	}

	private sealed class _003C_003Ec__DisplayClass19_0
	{
		public Predicate<Tile> predicate;

		internal bool _003CGetTileCount_003Eb__0(Tile x)
		{
			return predicate(x);
		}
	}

	private sealed class _003CUpdatingBiomes_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public World _003C_003E4__this;

		private List<Tile>.Enumerator _003C_003E7__wrap1;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CUpdatingBiomes_003Ed__21(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
			switch (_003C_003E1__state)
			{
			case -3:
			case 1:
				try
				{
					break;
				}
				finally
				{
					_003C_003Em__Finally1();
				}
			case -4:
			case 2:
				try
				{
					break;
				}
				finally
				{
					_003C_003Em__Finally2();
				}
			case -2:
			case -1:
			case 0:
				break;
			}
		}

		private bool MoveNext()
		{
			try
			{
				int num = _003C_003E1__state;
				World world = _003C_003E4__this;
				switch (num)
				{
				default:
					return false;
				case 0:
					_003C_003E1__state = -1;
					world.updatingBiomes = true;
					world.updatingBiomesStopwatch.Restart();
					_003C_003E7__wrap1 = world.InitialTiles.GetEnumerator();
					_003C_003E1__state = -3;
					goto IL_00ac;
				case 1:
					_003C_003E1__state = -3;
					world.updatingBiomesStopwatch.Restart();
					goto IL_00ac;
				case 2:
					{
						_003C_003E1__state = -4;
						world.updatingBiomesStopwatch.Restart();
						break;
					}
					IL_00ac:
					while (_003C_003E7__wrap1.MoveNext())
					{
						Tile current = _003C_003E7__wrap1.Current;
						world.biomeManager.ApplyBiome(current);
						if (world.updatingBiomesStopwatch.ElapsedMilliseconds > 15)
						{
							_003C_003E2__current = null;
							_003C_003E1__state = 1;
							return true;
						}
					}
					_003C_003Em__Finally1();
					_003C_003E7__wrap1 = default(List<Tile>.Enumerator);
					_003C_003E7__wrap1 = world.GetAllPlacedTiles().GetEnumerator();
					_003C_003E1__state = -4;
					break;
				}
				while (_003C_003E7__wrap1.MoveNext())
				{
					Tile current2 = _003C_003E7__wrap1.Current;
					world.biomeManager.ApplyBiome(current2);
					if (world.updatingBiomesStopwatch.ElapsedMilliseconds > 15)
					{
						_003C_003E2__current = null;
						_003C_003E1__state = 2;
						return true;
					}
				}
				_003C_003Em__Finally2();
				_003C_003E7__wrap1 = default(List<Tile>.Enumerator);
				world.updatingBiomesStopwatch.Stop();
				world.updatingBiomes = false;
				return false;
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		private void _003C_003Em__Finally1()
		{
			_003C_003E1__state = -1;
			((IDisposable)_003C_003E7__wrap1/*cast due to .constrained prefix*/).Dispose();
		}

		private void _003C_003Em__Finally2()
		{
			_003C_003E1__state = -1;
			((IDisposable)_003C_003E7__wrap1/*cast due to .constrained prefix*/).Dispose();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	private Dictionary<Vector2Int, Tile> tiles;

	private ElementGroupManager elementGroupManager;

	private BiomeManager biomeManager;

	private List<Tile> _003CInitialTiles_003Ek__BackingField;

	private bool updatingBiomes;

	private Coroutine updatingBiomeCoroutine;

	private Stopwatch updatingBiomesStopwatch = new Stopwatch();

	public List<Tile> InitialTiles
	{
		get
		{
			return _003CInitialTiles_003Ek__BackingField;
		}
		private set
		{
			_003CInitialTiles_003Ek__BackingField = value;
		}
	}

	public int TotalTileCount => tiles.Count;

	private void Awake()
	{
		tiles = new Dictionary<Vector2Int, Tile>();
		elementGroupManager = GetComponent<ElementGroupManager>();
		biomeManager = GetComponent<BiomeManager>();
		InitialTiles = new List<Tile>();
	}

	private List<Tile> GetTileNeighbors(Vector2Int gridPos)
	{
		List<Tile> list = new List<Tile>();
		Vector2Int[] array = GridCalculator.NeighborDirections(gridPos);
		foreach (Vector2Int vector2Int in array)
		{
			Tile tile = GetTile(gridPos + vector2Int);
			if ((bool)tile)
			{
				list.Add(tile);
			}
		}
		return list;
	}

	public Tile[] GetTileNeighborsArray(Vector2Int gridPos)
	{
		Tile[] array = new Tile[6];
		Vector2Int[] array2 = GridCalculator.NeighborDirections(gridPos);
		for (int i = 0; i < 6; i++)
		{
			Tile tile = GetTile(gridPos + array2[i]);
			array[i] = tile;
		}
		return array;
	}

	public void AddTile(Tile tileToAdd, bool potentialBiomeChange = true)
	{
		if (tileToAdd.IsInitialTile)
		{
			InitialTiles.Add(tileToAdd);
		}
		if (!tiles.ContainsKey(tileToAdd.GridPos))
		{
			tiles.Add(tileToAdd.GridPos, tileToAdd);
			tileToAdd.SetNeighbors(GetTileNeighborsArray(tileToAdd.GridPos));
		}
		else
		{
			Debug.LogWarning("there's already a tile at " + tileToAdd.GridPos.ToString() + ": " + tiles[tileToAdd.GridPos], tileToAdd);
		}
		elementGroupManager.CombineWithNeighborGroups(tileToAdd);
		if (potentialBiomeChange)
		{
			biomeManager.ApplyBiome(tileToAdd);
		}
	}

	public Tile GetTile(Vector2Int gridPos)
	{
		if (tiles.ContainsKey(gridPos))
		{
			return tiles[gridPos];
		}
		return null;
	}

	public void RemoveTile(Tile tileToRemove)
	{
		if (tiles.ContainsKey(tileToRemove.GridPos) && tiles[tileToRemove.GridPos] == tileToRemove)
		{
			tiles.Remove(tileToRemove.GridPos);
		}
		tileToRemove.RemoveFromNeighborsNeighbors();
		elementGroupManager.Remove(tileToRemove);
		tileToRemove.SetNeighbors(new Tile[6]);
	}

	public List<Tile> GetAllPlacedTiles()
	{
		return Enumerable.ToList(Enumerable.Where(tiles.Values, (Tile x) => x.State == TileState.placed));
	}

	public int GetTileCount(Predicate<Tile> predicate)
	{
		_003C_003Ec__DisplayClass19_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass19_0();
		CS_0024_003C_003E8__locals2.predicate = predicate;
		return Enumerable.Count(tiles.Values, (Tile x) => CS_0024_003C_003E8__locals2.predicate(x));
	}

	public void UpdateBiomesForAllTiles()
	{
		if (updatingBiomes)
		{
			StopCoroutine(updatingBiomeCoroutine);
			updatingBiomesStopwatch.Stop();
		}
		updatingBiomeCoroutine = StartCoroutine(UpdatingBiomes());
	}

	private IEnumerator UpdatingBiomes()
	{
		return new _003CUpdatingBiomes_003Ed__21(0)
		{
			_003C_003E4__this = this
		};
	}

	private void OnDestroy()
	{
		if (updatingBiomes)
		{
			if (updatingBiomeCoroutine != null)
			{
				StopCoroutine(updatingBiomeCoroutine);
			}
			updatingBiomesStopwatch.Stop();
		}
		tiles.Clear();
	}
}
