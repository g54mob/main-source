using Restory.Data.Decors;
using UnityEngine;

namespace Restory.Gameplay.InteractiveObjects
{
	public class DecorObject : MonoBehaviour
	{
		[SerializeField]
		private InteractiveObject interactiveObject;

		[SerializeField]
		private DecorInfo decorInfo;

		public InteractiveObject InteractiveObject => interactiveObject;

		public DecorInfo Info => decorInfo;
	}
}
