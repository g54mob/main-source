using CTS.BBT;
using CTS.UI;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class BuildFurnitureFilterBar : MonoBehaviour
	{
		[SerializeField]
		[BoxGroup("Filter")]
		private UI_Filter _filter;

		[SerializeField]
		[BoxGroup("Filter")]
		private FurnitureFilterElement[] _filterElements;

		[SerializeField]
		[BoxGroup("Filter")]
		private UI_Filter _styleFilter;

		[SerializeField]
		[BoxGroup("Filter")]
		private FurnitureStyleFilterElement[] _styleFilterElements;

		[SerializeField]
		private FurnitureShopPopulator _populator;

		private void Start()
		{
			if ((bool)_filter)
			{
				_filter.OnFilterUpdated += Filter_OnFilterUpdated;
				_filter.OnActiveFilterUpdated += Filter_OnActiveFilterUpdated;
				UI_Filter filter = _filter;
				AbsFilterElement[] filterElements = _filterElements;
				filter.Init(filterElements);
			}
			if ((bool)_styleFilter)
			{
				_styleFilter.OnFilterUpdated += StyleFilter_OnFilterUpdated;
				_styleFilter.OnActiveFilterUpdated += StyleFilter_OnActiveFilterUpdated;
				UI_Filter styleFilter = _styleFilter;
				AbsFilterElement[] filterElements = _styleFilterElements;
				styleFilter.Init(filterElements);
			}
		}

		private void Filter_OnFilterUpdated(bool active, int value)
		{
			if (active)
			{
				_populator.AddFilter((EFurnitureTags)value);
			}
			else
			{
				_populator.RemoveFilter((EFurnitureTags)value);
			}
		}

		private void Filter_OnActiveFilterUpdated(FilterButton obj)
		{
			_populator.SetFilter((EFurnitureTags)obj.ToggleValue);
		}

		private void StyleFilter_OnFilterUpdated(bool active, int value)
		{
			if (active)
			{
				_populator.SetFilter((EBarStyle)value);
			}
		}

		private void StyleFilter_OnActiveFilterUpdated(FilterButton obj)
		{
			_populator.SetFilter((EBarStyle)obj.ToggleValue);
		}

		private void SetFilter(bool p_value, int p_tag)
		{
			if (p_value)
			{
				_populator.AddFilter((EFurnitureTags)p_tag);
			}
			else
			{
				_populator.RemoveFilter((EFurnitureTags)p_tag);
			}
		}
	}
}
