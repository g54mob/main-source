using DV.CabControls.Spec;
using UnityEngine;

namespace DV.Items.Snapping
{
	public class SnapPointAnchor : MonoBehaviour
	{
		[SerializeField]
		protected SnapPointTypes type;

		public SnapPointTypes Type => type;

		public void ForceSetType(SnapPointTypes desiredType)
		{
			type = desiredType;
		}
	}
}
