using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Sensors/AIM Planar Shaper")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-planarshaper.html")]
	[DisallowMultipleComponent]
	public sealed class AIMPlanarShaper : MonoBehaviour
	{
		[Tooltip("The sensor asset to form a custom shape for.")]
		public AIMPlanarSensor PlanarSensor;

		[SerializeField]
		[HideInInspector]
		private bool baseSensorFoldout = true;

		[SerializeField]
		[HideInInspector]
		private bool manipulationFoldout = true;

		[SerializeField]
		[HideInInspector]
		private bool receptorFoldout = true;
	}
}
