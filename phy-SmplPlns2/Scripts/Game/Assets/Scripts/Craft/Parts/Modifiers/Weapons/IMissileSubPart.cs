using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	public interface IMissileSubPart
	{
		Transform Transform { get; }

		void OnMissileBuilt(ProceduralMissileScript missile);

		void OnMissileChanged(ProceduralMissileScript missile);
	}
}
