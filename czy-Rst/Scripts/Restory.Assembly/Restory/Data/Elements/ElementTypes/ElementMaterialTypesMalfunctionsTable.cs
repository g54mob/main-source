using System;
using System.Collections.Generic;
using Restory.Data.GameEntities;
using UnityEngine;

namespace Restory.Data.Elements.ElementTypes
{
	[CreateAssetMenu(menuName = "Restory/Elements/ElementTypes/ElementTypesMalfunctionsTable", fileName = "ElementTypesMalfunctionsTable")]
	public class ElementMaterialTypesMalfunctionsTable : ScriptableObject
	{
		[Serializable]
		private class Entry
		{
			public ElementMaterialType elementMaterialType;

			public DirtType[] ApplicableDirtTypes = new DirtType[0];
		}

		[SerializeField]
		private Entry[] entries = new Entry[0];

		[SerializeField]
		private int singleDirtTypeChance = 70;

		[SerializeField]
		private int doubleDirtTypeChance = 20;

		[SerializeField]
		private GameEntityDataBase database;

		[SerializeField]
		private ElementMaterialType plastic;

		[SerializeField]
		private ElementMaterialType metal;

		[SerializeField]
		private ElementMaterialType screen;

		[SerializeField]
		private ElementMaterialType circuit;

		[SerializeField]
		[HideInInspector]
		private Dictionary<ElementMaterialType, DirtType[]> dictionary = new Dictionary<ElementMaterialType, DirtType[]>();

		public int SingleDirtTypeChance => singleDirtTypeChance;

		public int DoubleDirtTypeChance => doubleDirtTypeChance;

		public bool TryGetApplicableDirtTypesByElementType(ElementMaterialType elementMaterialType, out IReadOnlyList<DirtType> dirtTypes)
		{
			if (!elementMaterialType)
			{
				dirtTypes = null;
				return false;
			}
			Entry[] array = entries;
			foreach (Entry entry in array)
			{
				if (entry != null && (bool)entry.elementMaterialType && entry.elementMaterialType.ID == elementMaterialType.ID)
				{
					dirtTypes = entry.ApplicableDirtTypes;
					return true;
				}
			}
			dirtTypes = null;
			return false;
		}
	}
}
