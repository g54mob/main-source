using DV.UIFramework;
using DV.Utils;
using DV.VRTK_Extensions;
using UnityEngine;

namespace DV.UI
{
	public class PopupMouseHandler : MonoBehaviour
	{
		private CustomMouseLook playerMouseLook;

		private void Awake()
		{
			PopupManager component = GetComponent<PopupManager>();
			if (VRManager.IsVREnabled())
			{
				component.PopupChanged += OnPopupChangedVR;
				return;
			}
			component.PopupChanged += OnPopupChangedNonVR;
			if ((bool)PlayerManager.PlayerTransform)
			{
				GetMouseLookReference();
			}
			else
			{
				PlayerManager.PlayerChanged += GetMouseLookReference;
			}
		}

		private void OnDestroy()
		{
			if (!VRManager.IsVREnabled())
			{
				PlayerManager.PlayerChanged -= GetMouseLookReference;
			}
		}

		private void GetMouseLookReference()
		{
			PlayerManager.PlayerChanged -= GetMouseLookReference;
			playerMouseLook = PlayerManager.PlayerTransform.GetComponent<CustomFirstPersonController>().m_MouseLook;
		}

		private void OnPopupChangedVR(Popup popup)
		{
			if ((bool)popup)
			{
				SingletonBehaviour<VRTK_SinglePointerControllerDV>.Instance.RequestPointerState(this, state: true);
			}
			else
			{
				SingletonBehaviour<VRTK_SinglePointerControllerDV>.Instance.RequestPointerState(this, state: false);
			}
		}

		private void OnPopupChangedNonVR(Popup popup)
		{
			if ((bool)popup)
			{
				SingletonBehaviour<CursorManager>.Instance.RequestCursor(this, visible: true);
				playerMouseLook?.RequestMouseSensitivityState(this, MouseSensitivityState.Locked);
			}
			else
			{
				SingletonBehaviour<CursorManager>.Instance.RemoveRequest(this);
				playerMouseLook?.RemoveRequest(this);
			}
		}
	}
}
