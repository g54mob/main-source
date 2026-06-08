using System.Collections.Generic;
using Controllers;
using UnityEngine;

namespace Kitchen
{
	public abstract class BaseDismissableView<Tview, Tresp> : ResponsiveObjectView<Tview, Tresp> where Tview : IViewData where Tresp : IResponseData, IDismissableResponse, new()
	{
		protected float CreationTime;

		protected float GracePeriod = 2f;

		public virtual bool IsComplete { get; set; }

		public override void Initialise()
		{
			base.Initialise();
			CreationTime = Time.realtimeSinceStartup;
		}

		public override bool HasStateUpdate(out IResponseData state)
		{
			state = null;
			if (IsComplete)
			{
				state = new Tresp
				{
					IsComplete = true
				};
			}
			return IsComplete;
		}

		protected void CheckForDismissal(List<PlayerInputData> inputs)
		{
			if (IsComplete || !(Time.realtimeSinceStartup - CreationTime > GracePeriod))
			{
				return;
			}
			foreach (PlayerInputData input in inputs)
			{
				if (input.Input.State.MenuSelect == ButtonState.Pressed || input.Input.State.MenuCancel == ButtonState.Pressed || input.Input.State.MenuTrigger == ButtonState.Pressed || input.Input.State.InteractAction == ButtonState.Pressed || input.Input.State.GrabAction == ButtonState.Pressed)
				{
					IsComplete = true;
					break;
				}
			}
		}
	}
}
