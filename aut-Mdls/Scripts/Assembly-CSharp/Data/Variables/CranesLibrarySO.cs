using System.Collections.Generic;
using Data.FactoryFloor.Buildings;
using UnityEngine;

namespace Data.Variables
{
	[CreateAssetMenu(menuName = "Variables/CranesLibrarySO", fileName = "CranesLibrarySO", order = 0)]
	public class CranesLibrarySO : ScriptableObject
	{
		private readonly Dictionary<Vector3Int, (BuildingCranesBehaviour behaviour, BuildingCranesBehaviour.Crane crane)> _cranes = new Dictionary<Vector3Int, (BuildingCranesBehaviour, BuildingCranesBehaviour.Crane)>();

		private HashSet<Vector3Int> _rails = new HashSet<Vector3Int>();

		public Dictionary<Vector3Int, (BuildingCranesBehaviour behaviour, BuildingCranesBehaviour.Crane crane)> Cranes => _cranes;

		public HashSet<Vector3Int> Rails => _rails;

		private void OnEnable()
		{
			_cranes.Clear();
		}

		public void AddCrane(BuildingCranesBehaviour buildingCranesBehaviour, BuildingCranesBehaviour.Crane crane)
		{
			int num = (int)(crane.PickupPosition - crane.Position).magnitude;
			for (int i = 1; i <= num; i++)
			{
				Vector3Int vector3Int = crane.Position + crane.Direction * i;
				if (i < num)
				{
					_rails.Add(vector3Int);
				}
				_cranes.Add(vector3Int, (buildingCranesBehaviour, crane));
			}
		}

		public void RemoveCraneFromLibrary(Vector3Int position)
		{
			BuildingCranesBehaviour.Crane item = _cranes[position].crane;
			int num = (int)(item.PickupPosition - item.Position).magnitude;
			for (int i = 1; i <= num; i++)
			{
				Vector3Int vector3Int = item.Position + item.Direction * i;
				if (i < num)
				{
					_rails.Remove(vector3Int);
				}
				_cranes.Remove(vector3Int);
			}
		}

		public bool TryGetCrane(Vector3Int position, out (BuildingCranesBehaviour behaviour, BuildingCranesBehaviour.Crane crane) crane)
		{
			return _cranes.TryGetValue(position, out crane);
		}

		public bool TryGetRail(Vector3Int position)
		{
			return _rails.Contains(position);
		}

		public int GetUniqueCranesAmount()
		{
			List<Vector3Int> list = new List<Vector3Int>();
			foreach (KeyValuePair<Vector3Int, (BuildingCranesBehaviour, BuildingCranesBehaviour.Crane)> crane in _cranes)
			{
				if (!list.Contains(crane.Value.Item2.PickupPosition))
				{
					list.Add(crane.Value.Item2.PickupPosition);
				}
			}
			return list.Count;
		}
	}
}
