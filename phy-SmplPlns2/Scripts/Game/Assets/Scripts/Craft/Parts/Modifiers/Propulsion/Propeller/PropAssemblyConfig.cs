using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Propeller
{
	public class PropAssemblyConfig : MonoBehaviour
	{
		[SerializeField]
		private Transform _propsContainer;

		public Transform PropsContainer => _propsContainer;
	}
}
