using System.Collections.Generic;
using UnityEngine;

namespace Presentation.FactoryFloor.Toolbar
{
	[CreateAssetMenu(menuName = "UI/Toolbar/OperatorBarDatabase", fileName = "OperatorBarDatabase", order = 0)]
	public class OperatorBarDatabase : ScriptableObject
	{
		[SerializeField]
		private List<OperatorBarCategory> _operatorBarCategories = new List<OperatorBarCategory>();

		public List<OperatorBarCategory> OperatorBarCategories => _operatorBarCategories;
	}
}
