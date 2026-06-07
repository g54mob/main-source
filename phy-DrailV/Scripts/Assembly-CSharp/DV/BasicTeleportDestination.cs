using DV.Interaction.Inputs;
using DV.Localization;
using DV.Utils;
using UnityEngine;

namespace DV
{
	public class BasicTeleportDestination : MonoBehaviour, ITeleportDestination, IPointable
	{
		public Transform teleportPoint;

		public TeleportHoverGlow hoverGlow;

		public void Hover(Vector3 point, Vector3 normal, HandIPointableSource _)
		{
			if (!VRManager.IsVREnabled())
			{
				SingletonBehaviour<InteractionTextControllerNonVr>.Instance.DisplayText(GetHoverText());
			}
			hoverGlow.Hover();
		}

		public void Unhover()
		{
			hoverGlow.Unhover();
		}

		public string GetHoverText()
		{
			return LocalizationAPI.L("interaction/enter", InputManager.Actions.Teleport.LocalizeInput());
		}

		public bool IsTeleportAllowed()
		{
			return true;
		}

		public bool ShouldRotatePlayerOnTeleport()
		{
			return true;
		}

		public (Vector3 pos, Quaternion rot) GetTeleportPose()
		{
			return (pos: teleportPoint.position, rot: teleportPoint.rotation);
		}

		public void AfterPlayerTeleported()
		{
		}
	}
}
