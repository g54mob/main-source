using UnityEngine;
using VRTK.Highlighters;

namespace VRTK.Examples
{
	public class VRTKExample_PointerObjectHighlighterActivator : MonoBehaviour
	{
		public VRTK_DestinationMarker pointer;

		public Color hoverColor = Color.cyan;

		public Color selectColor = Color.yellow;

		public bool logEnterEvent = true;

		public bool logHoverEvent;

		public bool logExitEvent = true;

		public bool logSetEvent = true;

		protected virtual void OnEnable()
		{
			pointer = ((pointer == null) ? GetComponent<VRTK_DestinationMarker>() : pointer);
			if (pointer != null)
			{
				pointer.DestinationMarkerEnter += DestinationMarkerEnter;
				pointer.DestinationMarkerHover += DestinationMarkerHover;
				pointer.DestinationMarkerExit += DestinationMarkerExit;
				pointer.DestinationMarkerSet += DestinationMarkerSet;
			}
			else
			{
				VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTKExample_PointerObjectHighlighterActivator", "VRTK_DestinationMarker", "the Controller Alias"));
			}
		}

		protected virtual void OnDisable()
		{
			if (pointer != null)
			{
				pointer.DestinationMarkerEnter -= DestinationMarkerEnter;
				pointer.DestinationMarkerHover -= DestinationMarkerHover;
				pointer.DestinationMarkerExit -= DestinationMarkerExit;
				pointer.DestinationMarkerSet -= DestinationMarkerSet;
			}
		}

		protected virtual void DestinationMarkerEnter(object sender, DestinationMarkerEventArgs e)
		{
			ToggleHighlight(e.target, hoverColor);
			if (logEnterEvent)
			{
				DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "POINTER ENTER", e.target, e.raycastHit, e.distance, e.destinationPosition);
			}
		}

		private void DestinationMarkerHover(object sender, DestinationMarkerEventArgs e)
		{
			if (logHoverEvent)
			{
				DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "POINTER HOVER", e.target, e.raycastHit, e.distance, e.destinationPosition);
			}
		}

		protected virtual void DestinationMarkerExit(object sender, DestinationMarkerEventArgs e)
		{
			ToggleHighlight(e.target, Color.clear);
			if (logExitEvent)
			{
				DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "POINTER EXIT", e.target, e.raycastHit, e.distance, e.destinationPosition);
			}
		}

		protected virtual void DestinationMarkerSet(object sender, DestinationMarkerEventArgs e)
		{
			ToggleHighlight(e.target, selectColor);
			if (logSetEvent)
			{
				DebugLogger(VRTK_ControllerReference.GetRealIndex(e.controllerReference), "POINTER SET", e.target, e.raycastHit, e.distance, e.destinationPosition);
			}
		}

		protected virtual void ToggleHighlight(Transform target, Color color)
		{
			VRTK_BaseHighlighter vRTK_BaseHighlighter = ((target != null) ? target.GetComponentInChildren<VRTK_BaseHighlighter>() : null);
			if (vRTK_BaseHighlighter != null)
			{
				vRTK_BaseHighlighter.Initialise();
				if (color != Color.clear)
				{
					vRTK_BaseHighlighter.Highlight(color);
				}
				else
				{
					vRTK_BaseHighlighter.Unhighlight();
				}
			}
		}

		protected virtual void DebugLogger(uint index, string action, Transform target, RaycastHit raycastHit, float distance, Vector3 tipPosition)
		{
			string text = (target ? target.name : "<NO VALID TARGET>");
			string text2 = (raycastHit.collider ? raycastHit.collider.name : "<NO VALID COLLIDER>");
			VRTK_Logger.Info("Controller on index '" + index + "' is " + action + " at a distance of " + distance + " on object named [" + text + "] on the collider named [" + text2 + "] - the pointer tip position is/was: " + tipPosition);
		}
	}
}
