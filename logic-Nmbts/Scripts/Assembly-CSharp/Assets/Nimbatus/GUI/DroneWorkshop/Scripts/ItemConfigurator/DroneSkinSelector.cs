using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.DroneSkins;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator
{
	public class DroneSkinSelector : MonoBehaviour
	{
		[HideInInspector]
		public EDroneSkinSet SelectedSet;

		[HideInInspector]
		public DroneSkinItem SelectedItem;

		public DroneSkinItem ItemPrefab;

		public UITable SubTablePrefab;

		public UITable ParentTable;

		public UIScrollView ScrollView;

		private List<DroneSkinItem> _skinItems;

		private int _previousWidth;

		private int _previousHeight;

		public event Action<DroneSkinItem, bool> SelectionChanged;

		public void Init(EDroneSkinSet set, bool selectPrevious = false)
		{
			SelectedSet = set;
			base.gameObject.SetActive(set != EDroneSkinSet.None);
			if (SelectedSet == EDroneSkinSet.None)
			{
				SelectedItem = null;
				Action<DroneSkinItem, bool> action = this.SelectionChanged;
				if (action != null)
				{
					action(null, false);
				}
				return;
			}
			List<DroneSkin> droneSkins = BaseSingleton<DroneSkinManager>.Instance.GetDroneSkins(set);
			ParentTable.transform.DestroyAllChildren();
			_skinItems = new List<DroneSkinItem>();
			for (int i = 0; i < 6; i++)
			{
				UITable uITable = UnityEngine.Object.Instantiate(SubTablePrefab);
				uITable.transform.position = ParentTable.transform.position;
				uITable.transform.parent = ParentTable.transform;
				uITable.transform.localScale = ItemPrefab.transform.localScale;
				uITable.columns = 4;
				int height = i + 1;
				if (i == 4)
				{
					height = 6;
				}
				if (i == 5)
				{
					height = 8;
				}
				IOrderedEnumerable<DroneSkin> subSkinSet = from s in droneSkins
					where s.Height == height && s.Width <= 5
					orderby s.Width
					select s;
				FillSubtable(uITable, subSkinSet, 1.4f);
			}
			for (int num = 0; num < 6; num++)
			{
				UITable uITable2 = UnityEngine.Object.Instantiate(SubTablePrefab);
				uITable2.transform.position = ParentTable.transform.position;
				uITable2.transform.parent = ParentTable.transform;
				uITable2.transform.localScale = ItemPrefab.transform.localScale;
				uITable2.columns = 2;
				int height2 = num + 1;
				if (num == 4)
				{
					height2 = 6;
				}
				if (num == 5)
				{
					height2 = 8;
				}
				IOrderedEnumerable<DroneSkin> subSkinSet2 = from s in droneSkins
					where s.Height == height2 && s.Width > 5
					orderby s.Width
					select s;
				FillSubtable(uITable2, subSkinSet2, 1f);
			}
			ParentTable.Reposition();
			ScrollView.ResetPosition();
			ScrollView.UpdateScrollbars(true);
			if (selectPrevious && _previousHeight != 0 && _previousWidth != 0)
			{
				SelectedItem = _skinItems.FirstOrDefault((DroneSkinItem droneSkinItem) => droneSkinItem.Skin.Width == _previousWidth && droneSkinItem.Skin.Height == _previousHeight);
				Select(SelectedItem, false);
			}
			else
			{
				SelectedItem = _skinItems.FirstOrDefault();
				Select(SelectedItem, false);
			}
		}

		private void FillSubtable(UITable table, IOrderedEnumerable<DroneSkin> subSkinSet, float scale)
		{
			foreach (DroneSkin item in subSkinSet)
			{
				DroneSkinItem droneSkinItem = UnityEngine.Object.Instantiate(ItemPrefab);
				droneSkinItem.Init(this, item);
				droneSkinItem.transform.position = table.transform.position;
				droneSkinItem.transform.parent = table.transform;
				droneSkinItem.transform.localScale = new Vector3((float)item.Width * scale, (float)item.Height * scale, 1f);
				_skinItems.Add(droneSkinItem);
			}
			table.Reposition();
		}

		public void Select(DroneSkinItem droneSkinItem, bool storeChange = true)
		{
			SelectedItem = droneSkinItem;
			Action<DroneSkinItem, bool> action = this.SelectionChanged;
			if (action != null)
			{
				action(SelectedItem, storeChange);
			}
			_previousWidth = SelectedItem.Skin.Width;
			_previousHeight = SelectedItem.Skin.Height;
		}

		public void ResetPreviousValues()
		{
			_previousWidth = 0;
			_previousHeight = 0;
		}

		public void SetPreviousValues(int height, int width)
		{
			_previousHeight = height;
			_previousWidth = width;
		}
	}
}
