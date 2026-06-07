using Data.Variables;
using UnityEngine;

namespace Events.UI.TechTree
{
	public class NodeRevealedData
	{
		public BoolVariableSO RevealBoolSO;

		public Material RevealMat;

		public NodeRevealedData(BoolVariableSO techTreeShowBool, Material nodeRevealedMaterial)
		{
			RevealBoolSO = techTreeShowBool;
			RevealMat = nodeRevealedMaterial;
		}
	}
}
