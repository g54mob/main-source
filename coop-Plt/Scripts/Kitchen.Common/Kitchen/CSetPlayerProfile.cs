using KitchenData;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public struct CSetPlayerProfile : IComponentData
	{
		public int PlayerID;

		public Color Colour;

		public DataObjectList Cosmetics;
	}
}
