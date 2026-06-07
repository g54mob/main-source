using UnityEngine;

namespace Assets.Scripts.Character.FacialExpression
{
	[CreateAssetMenu(fileName = "Expression", menuName = "SimplePlanes 2/FacialExpressionObject")]
	public class FacialExpressionObject : ScriptableObject
	{
		[SerializeField]
		private FacialExpression _expression;

		public FacialExpression Expression => _expression;
	}
}
