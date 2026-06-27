using UnityEngine;

namespace Restory.Gameplay.InteractiveObjects
{
	public abstract class PersonalObjectBase : MonoBehaviour
	{
		[SerializeField]
		private InteractiveObject interactiveObject;

		public InteractiveObject InteractiveObject => interactiveObject;
	}
}
