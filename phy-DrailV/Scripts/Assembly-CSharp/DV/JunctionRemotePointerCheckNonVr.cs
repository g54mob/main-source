using DV.CabControls;
using DV.Utils;
using UnityEngine;

namespace DV
{
	public class JunctionRemotePointerCheckNonVr : MonoBehaviour
	{
		private JunctionRemoteLogic remote;

		private ItemBase item;

		private void Awake()
		{
			remote = GetComponent<JunctionRemoteLogic>();
			item = GetComponentInParent<ItemBase>();
			if (remote == null || item == null)
			{
				Debug.LogError("Couldn't extract JunctionRemoteLogic or ItemBase. Destroying self!", this);
				Object.Destroy(this);
			}
		}

		private void Update()
		{
			if (remote.enabled && item.IsGrabbed() && (bool)SingletonBehaviour<InteractionTextControllerNonVr>.Instance && remote.IsPointingToSwitch())
			{
				SingletonBehaviour<InteractionTextControllerNonVr>.Instance.DisplayText(InteractionInfoType.JunctionRemoteSwitchUse);
			}
		}
	}
}
