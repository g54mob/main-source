using Simulator.GameWorld;
using UnityEngine.EventSystems;

namespace Simulator
{
	public class NavBoxCategory : NavBox, IUIShouldersInputReceiver
	{
		public override void SetActive()
		{
			base.SetActive();
			IUIShouldersInputReceiver.SetCurrent(this);
		}

		public override void SetInactive()
		{
			base.SetInactive();
			IUIShouldersInputReceiver.SetCurrent(null);
		}

		public void OnUIInput_GamepadShoulders(float value)
		{
			OnChildMove(new AxisEventData(EventSystem.current)
			{
				moveDir = ((!(value < 0f)) ? MoveDirection.Right : MoveDirection.Left)
			});
		}
	}
}
