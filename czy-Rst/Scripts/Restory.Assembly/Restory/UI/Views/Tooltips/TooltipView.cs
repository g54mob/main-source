using Restory.UserInterface;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Restory.UI.Views.Tooltips
{
	public abstract class TooltipView : UIBehaviour
	{
		[SerializeField]
		private GUI_ScreenObjectModelFollower follower;

		protected void SetFollowTransform(Transform followTransform)
		{
			if ((bool)followTransform && !follower)
			{
				Debug.LogError("Tooltip " + base.gameObject.name + " has lost reference to GUI_ScreenObjectModelFollower component");
			}
			else
			{
				follower.FollowTransform = followTransform;
			}
		}
	}
}
