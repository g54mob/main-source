using UnityEngine;

namespace Data.Variables
{
	[CreateAssetMenu(menuName = "Variables/IsDemo", fileName = "IsDemo", order = 0)]
	public class IsDemoVariableSO : BoolVariableSO
	{
		public override bool Value => true;
	}
}
