using System.Collections.Generic;

namespace TH20
{
	public class ArrivalVehicleFlowControl
	{
		private readonly List<KeyValuePair<int, ArrivalBaseComponent>> _free = new List<KeyValuePair<int, ArrivalBaseComponent>>();

		private readonly List<KeyValuePair<int, ArrivalBaseComponent>> _reserved = new List<KeyValuePair<int, ArrivalBaseComponent>>();

		public void Add(ArrivalBaseComponent arrivalComponent)
		{
			_free.Add(new KeyValuePair<int, ArrivalBaseComponent>(arrivalComponent.GetID(), arrivalComponent));
		}

		public void Remove(ArrivalBaseComponent arrivalComponent)
		{
			foreach (KeyValuePair<int, ArrivalBaseComponent> item in _free)
			{
				if (item.Value == arrivalComponent)
				{
					_free.Remove(item);
					return;
				}
			}
			foreach (KeyValuePair<int, ArrivalBaseComponent> item2 in _reserved)
			{
				if (item2.Value == arrivalComponent)
				{
					_reserved.Remove(item2);
					break;
				}
			}
		}

		public bool IsSpawnPointFree()
		{
			return _free.Count != 0;
		}

		public int Reserve()
		{
			if (_free.Count == 0)
			{
				return -1;
			}
			KeyValuePair<int, ArrivalBaseComponent> item = _free.RandomItem();
			_free.Remove(item);
			_reserved.Add(item);
			return item.Key;
		}

		public void Free(int id)
		{
			foreach (KeyValuePair<int, ArrivalBaseComponent> item in _reserved)
			{
				if (item.Key == id)
				{
					_free.Add(item);
					_reserved.Remove(item);
					break;
				}
			}
		}

		public void RestoreFromSave(int id)
		{
			foreach (KeyValuePair<int, ArrivalBaseComponent> item in _free)
			{
				if (item.Key == id)
				{
					_free.Remove(item);
					_reserved.Add(item);
					break;
				}
			}
		}

		public int TotalFree()
		{
			return _free.Count;
		}

		private ArrivalBaseComponent GetComponentInternal(int id)
		{
			foreach (KeyValuePair<int, ArrivalBaseComponent> item in _free)
			{
				if (item.Key == id)
				{
					return item.Value;
				}
			}
			foreach (KeyValuePair<int, ArrivalBaseComponent> item2 in _reserved)
			{
				if (item2.Key == id)
				{
					return item2.Value;
				}
			}
			return null;
		}

		public ArrivalBaseComponent GetComponent(int id)
		{
			return GetComponentInternal(id);
		}

		public bool ValidComponent(int id)
		{
			return GetComponentInternal(id) != null;
		}
	}
}
