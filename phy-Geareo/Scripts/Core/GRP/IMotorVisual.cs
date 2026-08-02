using UnityEngine;

namespace GRP
{
	public interface IMotorVisual : ISizedVisual
	{
		void SetMotorMaterial(Material material);

		void SetMotorInverted(bool inverted);

		void SetMotorMirror(bool mirror);
	}
}
