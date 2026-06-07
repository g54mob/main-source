using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GameCreator.Runtime.Characters;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("Sort List by Distance")]
	[Description("Sorts the List Variable elements based on their distance to a given position")]
	[Image(typeof(IconSort), ColorTheme.Type.Teal)]
	[Category("Variables/Sort List by Distance")]
	[Parameter("List Variable", "Local List or Global List which elements are sorted")]
	[Parameter("Position", "The reference position that is used to measure the sorting distance")]
	[Parameter("Order", "From Closest to Farthest puts the closest elements to the Position first")]
	[Keywords(new string[] { "Order", "Organize", "Array", "List", "Variables" })]
	public class InstructionVariablesSortDistance : Instruction
	{
		private enum Order
		{
			ClosestToFarthest = 0,
			FarthestToClosest = 1
		}

		[SerializeField]
		private CollectorListVariable m_ListVariable = new CollectorListVariable();

		[SerializeField]
		private PropertyGetPosition m_Position = GetPositionCharacter.Create;

		[SerializeField]
		private Order m_Order;

		private Args m_Args;

		public override string Title => $"Sort {m_ListVariable} by Distance to {m_Position}";

		protected override Task Run(Args args)
		{
			List<object> list = m_ListVariable.Get(args);
			m_Args = args;
			list.Sort(SortingMethod);
			m_ListVariable.Fill(list.ToArray(), args);
			return Instruction.DefaultResult;
		}

		private int SortingMethod(object a, object b)
		{
			IdString typeId = m_ListVariable.GetTypeId(m_Args);
			Vector3 a2 = m_Position.Get(m_Args);
			if (typeId.Hash == ValueVector3.TYPE_ID.Hash)
			{
				float value = Vector3.Distance(a2, (Vector3)a);
				float value2 = Vector3.Distance(a2, (Vector3)b);
				if (m_Order != Order.ClosestToFarthest)
				{
					return value2.CompareTo(value);
				}
				return value.CompareTo(value2);
			}
			if (typeId.Hash == ValueGameObject.TYPE_ID.Hash)
			{
				GameObject gameObject = a as GameObject;
				GameObject gameObject2 = b as GameObject;
				if (gameObject == null && gameObject2 == null)
				{
					return 0;
				}
				if (gameObject == null)
				{
					return 1;
				}
				if (gameObject2 == null)
				{
					return -1;
				}
				float value3 = Vector3.Distance(a2, gameObject.transform.position);
				float value4 = Vector3.Distance(a2, gameObject2.transform.position);
				if (m_Order != Order.ClosestToFarthest)
				{
					return value4.CompareTo(value3);
				}
				return value3.CompareTo(value4);
			}
			return 0;
		}
	}
}
