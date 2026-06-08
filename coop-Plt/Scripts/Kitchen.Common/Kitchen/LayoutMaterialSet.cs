using System.Collections.Generic;
using Kitchen.Layouts;
using KitchenData;
using UnityEngine;

namespace Kitchen
{
	public class LayoutMaterialSet
	{
		public Dictionary<LayoutPrefabSet.MaterialType, Material> Defaults;

		public Dictionary<int, Dictionary<LayoutMaterialType, Material>> Materials;

		public LayoutMaterialSet(Dictionary<LayoutPrefabSet.MaterialType, Material> defaults)
		{
			Defaults = defaults;
			Materials = new Dictionary<int, Dictionary<LayoutMaterialType, Material>>();
		}

		public Material Get(Room room, LayoutMaterialType mat_type)
		{
			return Get(room.ID, mat_type, room.Type);
		}

		public Material Get(int room, LayoutMaterialType mat_type, RoomType room_type)
		{
			if (!Materials.ContainsKey(room))
			{
				Materials[room] = new Dictionary<LayoutMaterialType, Material>();
			}
			if (!Materials[room].ContainsKey(mat_type))
			{
				LayoutPrefabSet.MaterialType key = new LayoutPrefabSet.MaterialType
				{
					Room = room_type,
					Type = mat_type
				};
				if (Defaults.TryGetValue(key, out var value))
				{
					Materials[room][mat_type] = new Material(value);
				}
				else
				{
					key.Room = RoomType.Unassigned;
					Materials[room][mat_type] = new Material(Defaults[key]);
				}
			}
			return Materials[room][mat_type];
		}

		public void Dispose()
		{
			if (Materials == null)
			{
				return;
			}
			foreach (KeyValuePair<int, Dictionary<LayoutMaterialType, Material>> material in Materials)
			{
				foreach (KeyValuePair<LayoutMaterialType, Material> item in material.Value)
				{
					Object.Destroy(item.Value);
				}
			}
		}
	}
}
