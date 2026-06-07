using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UIElements;

namespace DevTools
{
	public class DevToolsController : MonoBehaviour
	{
		private NetworkObject _networkObject;

		private bool _uiHidden;

		private bool _nameTagsHidden;

		private readonly List<(UIDocument doc, DisplayStyle prevStyle)> _hiddenUIDocuments;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void ToggleUI()
		{
		}

		private void ToggleNameTags()
		{
		}

		private void DisableAllUIDocuments()
		{
		}

		private void RestoreAllUIDocuments()
		{
		}

		private void ToggleVehicleBounce()
		{
		}

		private void OnDisable()
		{
		}
	}
}
