using System.Collections.Generic;
using Assets.Source.Item;
using UnityEngine;

namespace Assets.Behaviour.Frame.Parts
{
	public class T12WidgetEntrance : MonoBehaviour
	{
		[SerializeField]
		private T7FuelRodItem _itemPrefab;

		[SerializeField]
		private float _spawnDelay;

		[SerializeField]
		private Vector2 _spawnPosition;

		private float _spawnTimer;

		private ActiveWorldFrame _parent;

		private List<ItemType> _allItems;

		private List<ItemType> _widgetItems;

		private void Start()
		{
			_spawnTimer = _spawnDelay / 4f;
			_parent = GetComponentInParent<ActiveWorldFrame>();
			_allItems = new List<ItemType>();
			_widgetItems = new List<ItemType>();
			foreach (ItemType item in ItemType.All)
			{
				if (item.Tier < 12 && item.Identifier.EndsWith("widget"))
				{
					_widgetItems.Add(item);
				}
				else if (item.Tier < 12)
				{
					_allItems.Add(item);
				}
			}
		}

		public void Delay(float time)
		{
			_spawnTimer += time;
		}

		private void Update()
		{
			_spawnTimer -= Time.deltaTime;
			if (_spawnTimer < 0f)
			{
				T7FuelRodItem t7FuelRodItem = Object.Instantiate(_itemPrefab, _parent.transform);
				t7FuelRodItem.SetItem(SeededRandom.Global.Choose(SeededRandom.Global.RandomBool() ? _widgetItems : _allItems));
				t7FuelRodItem.transform.localPosition = _spawnPosition;
				t7FuelRodItem.transform.localEulerAngles = new Vector3(0f, 0f, SeededRandom.Global.RandomRange(0, 360));
				_spawnTimer = SeededRandom.Global.RandomRange(_spawnDelay * 0.75f, _spawnDelay / 0.75f);
			}
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if ((bool)collision.GetComponent<T7FuelRodItem>())
			{
				Object.Destroy(collision.gameObject);
			}
		}
	}
}
