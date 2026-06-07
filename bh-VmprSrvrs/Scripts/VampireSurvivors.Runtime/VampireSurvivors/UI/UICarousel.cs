using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace VampireSurvivors.UI
{
	public class UICarousel : MonoBehaviour
	{
		public enum CarouselAxis
		{
			X = 0,
			Y = 1
		}

		public delegate void OnSelectionChanged(int index);

		[SerializeField]
		private RectTransform _TopSlot;

		[SerializeField]
		private RectTransform _BottomSlot;

		[SerializeField]
		private RectTransform _Disabled;

		[SerializeField]
		private RectTransform _Container;

		[SerializeField]
		private float _Padding;

		[SerializeField]
		private float _MaxDistance;

		[SerializeField]
		private float _ItemsToShow;

		[SerializeField]
		private CarouselAxis _Axis;

		private RectTransform _rTrans;

		private float _size;

		private float _itemCount;

		private float _spacing;

		private int _halfSize;

		private int _midIndex;

		private float _itemHeight;

		private float _itemWidth;

		private List<GameObject> _cachedItems;

		private List<Transform> _slots;

		private List<GameObject> _spawnedItems;

		private int _currentIndex;

		public event OnSelectionChanged SelectionChanged
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

		public void Initialize(List<GameObject> carouselItems, int selectedIndex = 0)
		{
		}

		public void Clear()
		{
		}

		public void MoveNext()
		{
		}

		public GameObject GetSelectedItem()
		{
			return null;
		}

		public void MovePrevious()
		{
		}

		private void CreateItems()
		{
		}

		private GameObject CreateInitialItem(int spawnIndex, int slotIndex)
		{
			return null;
		}

		private GameObject SpawnNewItem(int spawnIndex, int slotIndex)
		{
			return null;
		}

		private void CreateSlots2()
		{
		}

		private void ApplyScales()
		{
		}

		private void ApplyPositions()
		{
		}

		private void AdjustMask()
		{
		}

		private GameObject CreateSlot2()
		{
			return null;
		}

		private GameObject GetNextItem()
		{
			return null;
		}

		private GameObject GetPreviousItem()
		{
			return null;
		}

		private GameObject GetCurrentItem()
		{
			return null;
		}
	}
}
