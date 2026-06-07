using System;
using System.Collections;
using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;
using UnityEngine.Pool;

namespace CTS.BBT
{
	[Serializable]
	public class BarFurnitures : CTSSingleton<BarFurnitures>
	{
		private static class FurnitureFilter<TFurniture> where TFurniture : class, IInteractiveFurniture
		{
			private static readonly HashSet<TFurniture> _prefilteredFurnitures = new HashSet<TFurniture>();

			private static readonly HashSet<TFurniture> _filteredFurnitures = new HashSet<TFurniture>();

			private static void PrefilterFurnitures(Dictionary<Type, List<Furniture>> furnitureDictionary)
			{
				_filteredFurnitures.Clear();
				_prefilteredFurnitures.Clear();
				foreach (TFurniture item in Enumerate<TFurniture>(furnitureDictionary))
				{
					if (item.CanBeUsed())
					{
						_prefilteredFurnitures.Add(item);
					}
				}
			}

			public static ReadOnlyHashSet<TFurniture> FilterFurnitures(Dictionary<Type, List<Furniture>> furnitureDictionary)
			{
				PrefilterFurnitures(furnitureDictionary);
				return _prefilteredFurnitures;
			}

			public static ReadOnlyHashSet<TFurniture> FilterFurnitures(Dictionary<Type, List<Furniture>> furnitureDictionary, Func<TFurniture, bool> filter)
			{
				PrefilterFurnitures(furnitureDictionary);
				foreach (TFurniture prefilteredFurniture in _prefilteredFurnitures)
				{
					if (filter(prefilteredFurniture))
					{
						_filteredFurnitures.Add(prefilteredFurniture);
					}
				}
				return _filteredFurnitures;
			}

			public static ReadOnlyHashSet<TFurniture> FilterFurnitures<TArg1>(Dictionary<Type, List<Furniture>> furnitureDictionary, Func<TFurniture, TArg1, bool> filter, TArg1 arg1)
			{
				PrefilterFurnitures(furnitureDictionary);
				foreach (TFurniture prefilteredFurniture in _prefilteredFurnitures)
				{
					if (filter(prefilteredFurniture, arg1))
					{
						_filteredFurnitures.Add(prefilteredFurniture);
					}
				}
				return _filteredFurnitures;
			}

			public static ReadOnlyHashSet<TFurniture> FilterFurnitures<TArg1, TArg2>(Dictionary<Type, List<Furniture>> furnitureDictionary, Func<TFurniture, TArg1, TArg2, bool> filter, TArg1 arg1, TArg2 arg2)
			{
				PrefilterFurnitures(furnitureDictionary);
				foreach (TFurniture prefilteredFurniture in _prefilteredFurnitures)
				{
					if (filter(prefilteredFurniture, arg1, arg2))
					{
						_filteredFurnitures.Add(prefilteredFurniture);
					}
				}
				return _filteredFurnitures;
			}

			public static ReadOnlyHashSet<TFurniture> FilterFurnitures<TArg1, TArg2, TArg3>(Dictionary<Type, List<Furniture>> furnitureDictionary, Func<TFurniture, TArg1, TArg2, TArg3, bool> filter, TArg1 arg1, TArg2 arg2, TArg3 arg3)
			{
				PrefilterFurnitures(furnitureDictionary);
				foreach (TFurniture prefilteredFurniture in _prefilteredFurnitures)
				{
					if (filter(prefilteredFurniture, arg1, arg2, arg3))
					{
						_filteredFurnitures.Add(prefilteredFurniture);
					}
				}
				return _filteredFurnitures;
			}
		}

		public readonly struct FurnitureEnumerator<TFurn> : IEnumerable<TFurn>, IEnumerable where TFurn : class, IInteractiveFurniture
		{
			public struct Enumerator : IEnumerator<TFurn>, IEnumerator, IDisposable
			{
				private readonly Dictionary<Type, List<Furniture>> _furnitures;

				private Type _baseType;

				private List<Type> _checkedTypes;

				private Type _currentType;

				private List<Furniture> _currentList;

				private int _listIndex;

				public TFurn Current { get; private set; }

				object IEnumerator.Current => Current;

				public Enumerator(Dictionary<Type, List<Furniture>> furnitures)
				{
					_furnitures = furnitures;
					_baseType = typeof(TFurn);
					_currentType = null;
					_checkedTypes = null;
					_currentList = null;
					Current = null;
					_listIndex = 0;
				}

				public bool MoveNext()
				{
					if (_checkedTypes == null)
					{
						_checkedTypes = CollectionPool<List<Type>, Type>.Get();
					}
					if ((object)_currentType == null)
					{
						if (_checkedTypes.Contains(_baseType))
						{
							_currentType = GetNewUncheckedType();
							_checkedTypes.Add(_currentType);
							if ((object)_currentType == null)
							{
								return false;
							}
						}
						else
						{
							_checkedTypes.Add(_baseType);
							_currentType = _baseType;
						}
					}
					if (_currentList == null)
					{
						if (!_furnitures.TryGetValue(_currentType, out _currentList) || _currentList.Count <= 0)
						{
							_currentList = null;
							_currentType = null;
							return MoveNext();
						}
						Current = _currentList[0].Interactor as TFurn;
						_listIndex = 0;
						return true;
					}
					_listIndex++;
					if (_listIndex >= _currentList.Count)
					{
						_currentType = null;
						_currentList = null;
						return MoveNext();
					}
					Current = _currentList[_listIndex].Interactor as TFurn;
					return true;
				}

				public void Reset()
				{
					ReleaseList();
				}

				public void Dispose()
				{
					ReleaseList();
				}

				private void ReleaseList()
				{
					if (_checkedTypes != null)
					{
						CollectionPool<List<Type>, Type>.Release(_checkedTypes);
						_checkedTypes = null;
					}
				}

				private Type GetNewUncheckedType()
				{
					Type result = null;
					foreach (Type key in _furnitures.Keys)
					{
						if (_baseType.IsAssignableFrom(key) && !_checkedTypes.Contains(key))
						{
							_checkedTypes.Add(key);
							result = key;
							break;
						}
					}
					return result;
				}
			}

			private readonly Dictionary<Type, List<Furniture>> _furnitures;

			public FurnitureEnumerator(Dictionary<Type, List<Furniture>> furnitures)
			{
				_furnitures = furnitures;
			}

			public Enumerator GetEnumerator()
			{
				return new Enumerator(_furnitures);
			}

			IEnumerator<TFurn> IEnumerable<TFurn>.GetEnumerator()
			{
				return GetEnumerator();
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		[SerializeField]
		private float _differentRoomWeight = 3f;

		[SerializeField]
		private float _differentFloorWeight = 10f;

		private Dictionary<Type, List<Furniture>> _furnitures = new Dictionary<Type, List<Furniture>>();

		private static readonly Type BasicType = typeof(Furniture);

		public static event Action<Furniture> OnFurnitureAdded;

		public static event Action<Furniture> OnFurnitureRemoved;

		protected override void SingletonAwake()
		{
			FurnitureController.FurniturePickedUp += OnFurniturePickUp;
			FurnitureController.PlacingFurniture += OnFurniturePlaced;
		}

		private void Start()
		{
			UpdateFurnitureList();
		}

		protected override void OnSingletonDestroy()
		{
			FurnitureController.FurniturePickedUp -= OnFurniturePickUp;
			FurnitureController.PlacingFurniture -= OnFurniturePlaced;
		}

		public void ClearNullFurnitures()
		{
			List<Type> list = CollectionPool<List<Type>, Type>.Get();
			list.AddRange(_furnitures.Keys);
			foreach (Type item in list)
			{
				if (!_furnitures.TryGetValue(item, out var value))
				{
					continue;
				}
				for (int num = value.Count - 1; num >= 0; num--)
				{
					if (value[num] == null)
					{
						value.RemoveAt(num);
					}
				}
			}
		}

		private void OnFurniturePickUp(FurnitureController furnitureController)
		{
			RemoveFurniture(furnitureController.Furniture);
		}

		private void OnFurniturePlaced(FurnitureController furnitureController)
		{
			AddFurniture(furnitureController.Furniture);
		}

		public FurnitureEnumerator<TFurn> Enumerate<TFurn>() where TFurn : class, IInteractiveFurniture
		{
			return Enumerate<TFurn>(_furnitures);
		}

		private static FurnitureEnumerator<TFurn> Enumerate<TFurn>(Dictionary<Type, List<Furniture>> furnitures) where TFurn : class, IInteractiveFurniture
		{
			return new FurnitureEnumerator<TFurn>(furnitures);
		}

		private void UpdateFurnitureList()
		{
			Furniture[] array = UnityEngine.Object.FindObjectsOfType<Furniture>(includeInactive: false);
			_furnitures.Clear();
			Furniture[] array2 = array;
			foreach (Furniture furniture in array2)
			{
				furniture.MarkAsBought();
				if ((bool)furniture.Interactor)
				{
					furniture.Interactor.OnFurniturePlaced();
				}
			}
		}

		public void AddFurniture(Furniture furniture)
		{
			Type key = (furniture.Interactor ? furniture.Interactor.GetType() : BasicType);
			if (!_furnitures.ContainsKey(key))
			{
				_furnitures.Add(key, new List<Furniture>());
			}
			if (!_furnitures[key].Contains(furniture))
			{
				_furnitures[key].Add(furniture);
				BarFurnitures.OnFurnitureAdded?.Invoke(furniture);
			}
		}

		public void RemoveFurniture(Furniture furniture)
		{
			Type key = (furniture.Interactor ? furniture.Interactor.GetType() : BasicType);
			if (_furnitures.TryGetValue(key, out var value) && value.Contains(furniture))
			{
				_furnitures[key].Remove(furniture);
				BarFurnitures.OnFurnitureRemoved?.Invoke(furniture);
			}
		}

		public bool TryGetInteractor<TFurniture>(out TFurniture outFurniture) where TFurniture : FurnitureInteractor
		{
			outFurniture = null;
			foreach (TFurniture item in Enumerate<TFurniture>())
			{
				if (item.CanBeUsed())
				{
					outFurniture = item;
					return true;
				}
			}
			return false;
		}

		public bool TryGetInteractor<TFurniture>(out TFurniture outFurniture, Func<TFurniture, bool> filter) where TFurniture : FurnitureInteractor
		{
			outFurniture = null;
			foreach (TFurniture item in Enumerate<TFurniture>())
			{
				if (item.CanBeUsed() && filter(item))
				{
					outFurniture = item;
					return true;
				}
			}
			return false;
		}

		public bool TryGetInteractor<TFurniture, TArg1>(out TFurniture outFurniture, Func<TFurniture, TArg1, bool> filter, TArg1 arg1) where TFurniture : FurnitureInteractor
		{
			outFurniture = null;
			foreach (TFurniture item in Enumerate<TFurniture>())
			{
				if (item.CanBeUsed() && filter(item, arg1))
				{
					outFurniture = item;
					return true;
				}
			}
			return false;
		}

		public bool TryGetNearestInteractor<TFurniture>(RoomObject roomData, out TFurniture outFurniture, out float outDistance) where TFurniture : class, IInteractiveFurniture
		{
			return BBTCollections<TFurniture>.TryGetNearest(roomData, FurnitureFilter<TFurniture>.FilterFurnitures(_furnitures), out outFurniture, out outDistance);
		}

		public bool TryGetNearestInteractor<TFurniture>(RoomObject roomData, out TFurniture outFurniture, out float outDistance, Func<TFurniture, bool> filter) where TFurniture : class, IInteractiveFurniture
		{
			return BBTCollections<TFurniture>.TryGetNearest(roomData, FurnitureFilter<TFurniture>.FilterFurnitures(_furnitures, filter), out outFurniture, out outDistance);
		}

		public bool TryGetNearestInteractor<TFurniture, TArg1>(RoomObject roomData, out TFurniture outFurniture, out float outDistance, Func<TFurniture, TArg1, bool> filter, TArg1 arg1) where TFurniture : class, IInteractiveFurniture
		{
			return BBTCollections<TFurniture>.TryGetNearest(roomData, FurnitureFilter<TFurniture>.FilterFurnitures(_furnitures, filter, arg1), out outFurniture, out outDistance);
		}

		public bool TryGetNearestInteractor<TFurniture, TArg1, TArg2>(RoomObject roomData, out TFurniture outFurniture, out float outDistance, Func<TFurniture, TArg1, TArg2, bool> filter, TArg1 arg1, TArg2 arg2) where TFurniture : class, IInteractiveFurniture
		{
			return BBTCollections<TFurniture>.TryGetNearest(roomData, FurnitureFilter<TFurniture>.FilterFurnitures(_furnitures, filter, arg1, arg2), out outFurniture, out outDistance);
		}

		public bool TryGetNearestInteractor<TFurniture, TArg1, TArg2, TArg3>(RoomObject roomData, out TFurniture outFurniture, out float outDistance, Func<TFurniture, TArg1, TArg2, TArg3, bool> filter, TArg1 arg1, TArg2 arg2, TArg3 arg3) where TFurniture : class, IInteractiveFurniture
		{
			return BBTCollections<TFurniture>.TryGetNearest(roomData, FurnitureFilter<TFurniture>.FilterFurnitures(_furnitures, filter, arg1, arg2, arg3), out outFurniture, out outDistance);
		}

		public int GetAvailableCount<TFurniture>() where TFurniture : class, IInteractiveFurniture
		{
			int num = 0;
			foreach (TFurniture item in Enumerate<TFurniture>())
			{
				if (item.CanBeUsed())
				{
					num++;
				}
			}
			return num;
		}

		public int GetCount<TFurniture>() where TFurniture : class, IInteractiveFurniture
		{
			int num = 0;
			foreach (TFurniture item in Enumerate<TFurniture>())
			{
				_ = item;
				num++;
			}
			return num;
		}

		public bool IsAnyAvailable<TFurniture>() where TFurniture : FurnitureInteractor
		{
			Type typeFromHandle = typeof(TFurniture);
			if (!_furnitures.ContainsKey(typeFromHandle))
			{
				return false;
			}
			foreach (Furniture item in _furnitures[typeFromHandle])
			{
				if (item.Interactor.CanBeUsed())
				{
					return true;
				}
			}
			return false;
		}

		public bool IsAnyAvailable<T>(Func<T, bool> p_filter) where T : FurnitureInteractor
		{
			Type typeFromHandle = typeof(T);
			if (!_furnitures.ContainsKey(typeFromHandle))
			{
				return false;
			}
			foreach (Furniture item in _furnitures[typeFromHandle])
			{
				if (item.Interactor.CanBeUsed() && p_filter((T)item.Interactor))
				{
					return true;
				}
			}
			return false;
		}

		public bool IsAnyAvailable<TFurniture, TArg1>(Func<TFurniture, TArg1, bool> filter, TArg1 arg1) where TFurniture : FurnitureInteractor
		{
			Type typeFromHandle = typeof(TFurniture);
			if (!_furnitures.ContainsKey(typeFromHandle))
			{
				return false;
			}
			foreach (Furniture item in _furnitures[typeFromHandle])
			{
				if (item.Interactor.CanBeUsed() && filter((TFurniture)item.Interactor, arg1))
				{
					return true;
				}
			}
			return false;
		}

		public bool IsAnyAvailable<TFurniture, TArg1, TArg2>(Func<TFurniture, TArg1, TArg2, bool> filter, TArg1 arg1, TArg2 arg2) where TFurniture : FurnitureInteractor
		{
			Type typeFromHandle = typeof(TFurniture);
			if (!_furnitures.ContainsKey(typeFromHandle))
			{
				return false;
			}
			foreach (Furniture item in _furnitures[typeFromHandle])
			{
				if (item.Interactor.CanBeUsed() && filter((TFurniture)item.Interactor, arg1, arg2))
				{
					return true;
				}
			}
			return false;
		}

		public bool DoesAnyExist<TFurniture>() where TFurniture : class, IInteractiveFurniture
		{
			foreach (TFurniture item in Enumerate<TFurniture>())
			{
				if (item.EqualsNull())
				{
					return true;
				}
			}
			return false;
		}

		public bool DoesAnyExist<TFurniture>(Func<TFurniture, bool> p_filter) where TFurniture : class, IInteractiveFurniture
		{
			foreach (TFurniture item in Enumerate<TFurniture>())
			{
				if (p_filter(item))
				{
					return true;
				}
			}
			return false;
		}

		public bool DoesAnyExist<TFurniture, TArg>(Func<TFurniture, TArg, bool> filter, TArg filterArg) where TFurniture : class, IInteractiveFurniture
		{
			foreach (TFurniture item in Enumerate<TFurniture>())
			{
				if (filter(item, filterArg))
				{
					return true;
				}
			}
			return false;
		}

		public bool DoesAnyExist<TFurniture, TArg1, TArg2>(Func<TFurniture, TArg1, TArg2, bool> filter, TArg1 arg1, TArg2 arg2) where TFurniture : class, IInteractiveFurniture
		{
			foreach (TFurniture item in Enumerate<TFurniture>())
			{
				if (filter(item, arg1, arg2))
				{
					return true;
				}
			}
			return false;
		}
	}
}
