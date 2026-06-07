using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Jet
{
	public interface IJetEngineComponents
	{
		Vector3 DesignerCenterOfThrust { get; }

		void AnimateComponents(bool active, float throttle, float afterburner);

		void Initialize(JetEngineScript jetEngine, AttachPointScript attachPointFront);

		void UpdateComponents();

		void UpdateStyles();
	}
}
