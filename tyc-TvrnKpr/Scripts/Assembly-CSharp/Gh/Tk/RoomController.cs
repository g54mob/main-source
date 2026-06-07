using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class RoomController : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass20_0
		{
			public ListPoolX.DisposablePooledList<int> roomsToInvalidate;

			public ListPoolX.DisposablePooledList<int> roomIds;

			public Func<TileData, bool> _003C_003E9__9;

			internal bool _003CInvalidateRooms_003Eb__9(TileData e)
			{
				return false;
			}

			internal bool _003CInvalidateRooms_003Eb__6(KeyValuePair<int, Room> x)
			{
				return false;
			}

			internal bool _003CInvalidateRooms_003Eb__7(KeyValuePair<int, Room> e)
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass20_4
		{
			public KeyValuePair<int, Room> room;

			public Func<GameObjectX, bool> _003C_003E9__22;

			internal bool _003CInvalidateRooms_003Eb__22(GameObjectX x)
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003CInvalidateRooms_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public RoomController _003C_003E4__this;

			public IEnumerable<TileData> toInvalidate;

			private _003C_003Ec__DisplayClass20_0 _003C_003E8__1;

			private _003C_003Ec__DisplayClass20_4 _003C_003E8__2;

			private TileData[] _003Ctiles_003E5__2;

			private Dictionary<int, TileData[]> _003ColdRoomInfo_003E5__3;

			private IEnumerator _003Cenumerator_003E5__4;

			private ListPoolX.DisposablePooledList<int> _003CneedsRefreshingTiles_003E5__5;

			private ListPoolX.DisposablePooledList<KeyValuePair<int, Room>> _003CroomsToDestroy_003E5__6;

			private List<int>.Enumerator _003C_003E7__wrap6;

			private List<KeyValuePair<int, Room>>.Enumerator _003C_003E7__wrap7;

			private IEnumerator<KeyValuePair<int, Room>> _003C_003E7__wrap8;

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
			public _003CInvalidateRooms_003Ed__20(int _003C_003E1__state)
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

			private void _003C_003Em__Finally2()
			{
			}

			private void _003C_003Em__Finally3()
			{
			}

			private void _003C_003Em__Finally4()
			{
			}

			private void _003C_003Em__Finally5()
			{
			}

			private void _003C_003Em__Finally6()
			{
			}

			private void _003C_003Em__Finally7()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		public RoomZone[] availableZones;

		public GameObject wallSkeletonPrefab;

		private GameObject _parent;

		private IEnumerator _roomValidationEnumerator;

		private readonly Stopwatch _stopwatch;

		private Dictionary<int, Room> _rooms;

		private List<TileData> _tilesChanged;

		private bool _isRoomInvalidationInProgress;

		private FrameCachedValue<List<RoomZone>> _frameCachedAvailableZones;

		public GameObject WallsAndDoorsParent { get; set; }

		public bool IsRoomCalculationInProgress => false;

		public List<RoomZone> AvailableZones => null;

		public static event EventHandler<EventArgs> RoomsChanged
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

		public void Awake()
		{
		}

		public void RefreshPrefabs()
		{
		}

		private void LateUpdate()
		{
		}

		public void StopRoomValidation()
		{
		}

		public void RefreshRooms()
		{
		}

		public void InvalidateRoomsImmediate(IEnumerable<TileData> toInvalidate = null)
		{
		}

		[IteratorStateMachine(typeof(_003CInvalidateRooms_003Ed__20))]
		public IEnumerator InvalidateRooms(IEnumerable<TileData> toInvalidate = null)
		{
			return null;
		}

		private void UpdatePolishTrait(Room room, Dictionary<int, TileData[]> oldRoomInfo)
		{
		}

		public void RefreshTiles()
		{
		}

		public void InvalidateRoomsLazy(List<TileData> tiles)
		{
		}

		public void AddRoom(Room room)
		{
		}

		public GameObject HitTestRoom()
		{
			return null;
		}

		public IEnumerable<Room> GetRoomsZonedAs(string zone)
		{
			return null;
		}

		public IEnumerable<string> GetZoneNamesInTavern()
		{
			return null;
		}

		public IEnumerable<Room> GetRooms()
		{
			return null;
		}

		public Room GetRoom(int id)
		{
			return null;
		}

		public Room GetRoom(Vector3 position)
		{
			return null;
		}

		public List<string> GetRequiredPropsForZone(string zone, int tavernStars)
		{
			return null;
		}

		public IEnumerable<RoomZone> CalculateAvailableZones()
		{
			return null;
		}

		public static bool IsZoneAvailableWithStarRating(string zoneName, float tavernStarRating)
		{
			return false;
		}

		public static float GetStarRatingForZone(string zoneId)
		{
			return 0f;
		}

		internal void ClearRooms()
		{
		}

		public GameObject InstantiateWallTile(Vector3 position, bool rotate, bool alreadyBuilt = false, bool outerWall = false)
		{
			return null;
		}
	}
}
