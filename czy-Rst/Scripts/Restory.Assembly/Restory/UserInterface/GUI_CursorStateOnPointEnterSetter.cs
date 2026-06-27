using UnityEngine;

namespace Restory.UserInterface
{
	public class GUI_CursorStateOnPointEnterSetter : MonoBehaviour
	{
		[SerializeField]
		private GUICursorState stateForSet;

		public virtual bool CanSwitchState { get; set; } = true;

		public GUICursorState State => stateForSet;
	}
}
