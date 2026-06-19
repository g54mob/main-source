using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Michsky.DreamOS
{
	public class MultiInstanceManager : MonoBehaviour
	{
		[Serializable]
		public class InstanceItem
		{
			public WorldSpaceManager worldSpaceManager;

			public Canvas instanceCanvas;

			public UserManager userManager;
		}

		public Camera playerCamera;

		public List<InstanceItem> instances = new List<InstanceItem>();

		private void Awake()
		{
			for (int i = 0; i < instances.Count; i++)
			{
				instances[i].userManager.disableUserCreating = true;
				UnityEngine.Object.Destroy(instances[i].instanceCanvas.GetComponentInChildren<EventSystem>().gameObject);
			}
		}

		public void AutoWizard(int instanceIndex)
		{
			AutoFindResources(instanceIndex);
		}

		private void AutoFindResources(int index)
		{
			instances[index].userManager = instances[index].instanceCanvas.GetComponentInChildren<UserManager>();
			instances[index].userManager.disableUserCreating = true;
			if (playerCamera == null)
			{
				playerCamera = Camera.main;
			}
			for (int i = 0; i < instances.Count; i++)
			{
				if (playerCamera != null)
				{
					instances[i].worldSpaceManager.mainCamera = playerCamera;
					continue;
				}
				Debug.LogWarning("<b>[DreamOS]</b> No main camera found, player camera is missing.", this);
				break;
			}
		}
	}
}
