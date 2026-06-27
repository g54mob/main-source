using System;
using System.Collections.Generic;
using UnityEngine;

namespace Mandragora.ResourceUtils
{
	[Serializable]
	public abstract class LinkBank<T> : MonoBehaviour where T : UnityEngine.Object
	{
		private enum SortingType
		{
			None = 0,
			ByName = 1,
			ByPath = 2
		}

		public string PathToFolder;

		[HideInInspector]
		[SerializeField]
		public UnityEngine.Object directory;

		[HideInInspector]
		[SerializeField]
		public List<ResourceData> list;

		private CompareByNameGameResource _comparerByName = new CompareByNameGameResource();

		private CompareByPathGameResource _comparerByPath = new CompareByPathGameResource();

		private ResourceData _findItem = new ResourceData();

		private SortingType _currentSorting;

		private void Sorting(SortingType type, IComparer<ResourceData> comparison)
		{
			if (_currentSorting != type)
			{
				_currentSorting = type;
				list.Sort(comparison);
			}
		}

		public virtual T FindResourceByName(string name)
		{
			Sorting(SortingType.ByName, _comparerByName);
			_findItem.Name = name;
			int num = list.BinarySearch(_findItem, _comparerByName);
			if (num < 0)
			{
				Debug.Log("Not found name " + name);
				return null;
			}
			return list[num].Resource as T;
		}

		public virtual T FindResourceByID(int id)
		{
			return list[id].Resource as T;
		}

		public virtual T FindResourceByPath(string path)
		{
			Sorting(SortingType.ByPath, _comparerByPath);
			_findItem.Path = path;
			int num = list.BinarySearch(_findItem, _comparerByPath);
			if (num < 0)
			{
				Debug.Log("Not found path " + path);
				return null;
			}
			return list[num].Resource as T;
		}
	}
}
