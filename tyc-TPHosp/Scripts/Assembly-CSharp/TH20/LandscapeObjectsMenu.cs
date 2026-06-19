using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class LandscapeObjectsMenu : MenuBase
	{
		[SerializeField]
		private GameObject _prefabListItem;

		[SerializeField]
		private GameObject _listContent;

		[SerializeField]
		private TMP_InputField _searchBox;

		[SerializeField]
		private Image _creatingListIcon;

		private FloorPlan _floorPlan;

		private BuildEvents _buildEvents;

		private string _filter;

		private List<RoomItemDefinition> _items;

		private List<RoomItemDefinition> _itemsToCreate;

		private readonly List<GameObject> _listObjects = new List<GameObject>();

		private readonly List<LandscapeObjectListItem> _listItems = new List<LandscapeObjectListItem>();

		public void Setup(FloorPlan floorPlan, WorldState worldState, BuildEvents buildEvents)
		{
			_floorPlan = floorPlan;
			_buildEvents = buildEvents;
			if (_items == null)
			{
				worldState.GetLandscapeItems(out _itemsToCreate);
				_itemsToCreate.Sort((RoomItemDefinition def1, RoomItemDefinition def2) => string.Compare(def1.DebugTag, def2.DebugTag, StringComparison.Ordinal));
				_items = new List<RoomItemDefinition>(_itemsToCreate.Count);
				for (int num = 0; num < _listContent.transform.childCount; num++)
				{
					_listContent.transform.GetChild(num).gameObject.SetActive(value: false);
				}
			}
			_searchBox.onValueChanged.AddListener(delegate(string filter)
			{
				_filter = filter;
			});
		}

		public override void Destroy()
		{
			_listItems.Clear();
			_listObjects.ClearAndDestroy();
		}

		protected override void Update()
		{
			base.Update();
			int num = 0;
			while (_itemsToCreate.Count != 0 && num < 4)
			{
				int count = _items.Count;
				RoomItemDefinition item = _itemsToCreate[0];
				GameObject gameObject = UnityEngine.Object.Instantiate(_prefabListItem, _listContent.transform, worldPositionStays: false);
				LandscapeObjectListItem component = gameObject.GetComponent<LandscapeObjectListItem>();
				component.SetDefinition(item, count);
				component.Button.onClick.AddListener(delegate
				{
					_buildEvents.OnStopRoomAutoFlow.InvokeSafe();
					_buildEvents.OnBeginItemPlacement.InvokeSafe(item, _floorPlan, param3: false);
				});
				_listItems.Add(component);
				_listObjects.Add(gameObject);
				_items.Add(item);
				_itemsToCreate.RemoveAt(0);
				num++;
			}
			Filter();
			GameObjectUtils.SetActive(_creatingListIcon.gameObject, _itemsToCreate.Count != 0);
		}

		private void Filter()
		{
			for (int i = 0; i < _items.Count; i++)
			{
				RoomItemDefinition roomItemDefinition = _items[i];
				GameObject obj = _listObjects[i];
				bool isActive = string.IsNullOrEmpty(_filter) || roomItemDefinition.DebugTag.ContainsCaseInsensitive(_filter);
				GameObjectUtils.SetActive(obj, isActive);
			}
		}
	}
}
