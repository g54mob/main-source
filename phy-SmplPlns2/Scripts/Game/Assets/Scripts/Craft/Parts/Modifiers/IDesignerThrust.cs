using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public interface IDesignerThrust
	{
		Vector3 DesignerCenterOfThrust { get; }

		float DesignerThrust { get; }

		DesignerThrustTypes DesignerThrustType { get; }
	}
}
