using UnityEngine;
using VRTK.Controllables;
using VRTK.Controllables.ArtificialBased;
using VRTK.Controllables.PhysicsBased;

namespace VRTK.Examples
{
	public class PusherStickyToggle : MonoBehaviour
	{
		public VRTK_BaseControllable buttonOne;

		public VRTK_BaseControllable buttonTwo;

		public Color onColor = Color.green;

		public Color offColor = Color.red;

		protected bool buttonOnePressed;

		protected bool buttonTwoPressed;

		protected virtual void OnEnable()
		{
			SetStayPressed(buttonOne, state: true);
			SetStayPressed(buttonTwo, state: true);
			buttonOne.MaxLimitReached += ButtonOne_MaxLimitReached;
			buttonTwo.MaxLimitReached += ButtonTwo_MaxLimitReached;
			buttonOne.MaxLimitExited += ButtonOne_MaxLimitExited;
			buttonTwo.MaxLimitExited += ButtonTwo_MaxLimitExited;
		}

		protected virtual void OnDisable()
		{
			buttonOne.MaxLimitReached -= ButtonOne_MaxLimitReached;
			buttonTwo.MaxLimitReached -= ButtonTwo_MaxLimitReached;
			buttonOne.MaxLimitExited -= ButtonOne_MaxLimitExited;
			buttonTwo.MaxLimitExited -= ButtonTwo_MaxLimitExited;
		}

		protected virtual void ButtonOne_MaxLimitReached(object sender, ControllableEventArgs e)
		{
			if (buttonTwoPressed)
			{
				SetStayPressed(buttonTwo, state: false);
			}
			buttonOnePressed = true;
			SetPositionTarget(buttonOne, 0f);
			ChangeColor(buttonOne.gameObject, onColor);
		}

		protected virtual void ButtonTwo_MaxLimitReached(object sender, ControllableEventArgs e)
		{
			if (buttonOnePressed)
			{
				SetStayPressed(buttonOne, state: false);
			}
			buttonTwoPressed = true;
			SetPositionTarget(buttonTwo, 0f);
			ChangeColor(buttonTwo.gameObject, onColor);
		}

		protected virtual void ButtonOne_MaxLimitExited(object sender, ControllableEventArgs e)
		{
			SetStayPressed(buttonOne, state: true);
			buttonOnePressed = false;
			ChangeColor(buttonOne.gameObject, offColor);
		}

		protected virtual void ButtonTwo_MaxLimitExited(object sender, ControllableEventArgs e)
		{
			SetStayPressed(buttonTwo, state: true);
			buttonTwoPressed = false;
			ChangeColor(buttonTwo.gameObject, offColor);
		}

		protected virtual void ChangeColor(GameObject obj, Color col)
		{
			obj.GetComponent<Renderer>().material.color = col;
		}

		protected virtual void SetStayPressed(VRTK_BaseControllable obj, bool state)
		{
			if (obj.GetType() == typeof(VRTK_PhysicsPusher))
			{
				(obj as VRTK_PhysicsPusher).stayPressed = state;
			}
			else if (obj.GetType() == typeof(VRTK_ArtificialPusher))
			{
				(obj as VRTK_ArtificialPusher).SetStayPressed(state);
			}
		}

		protected virtual void SetPositionTarget(VRTK_BaseControllable obj, float newTarget)
		{
			if (obj.GetType() == typeof(VRTK_PhysicsPusher))
			{
				(obj as VRTK_PhysicsPusher).positionTarget = newTarget;
			}
			else if (obj.GetType() == typeof(VRTK_ArtificialPusher))
			{
				(obj as VRTK_ArtificialPusher).SetPositionTarget(newTarget);
			}
		}
	}
}
