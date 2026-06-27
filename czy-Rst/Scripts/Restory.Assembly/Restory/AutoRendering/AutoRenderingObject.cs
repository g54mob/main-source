using System;
using Restory.Data.Devices;
using UnityEngine;

namespace Restory.AutoRendering
{
	public class AutoRenderingObject : MonoBehaviour
	{
		private enum TintColorSelectionOptions
		{
			NoTint = 0,
			ColorFromDeviceInfo = 1,
			CustomColor = 2
		}

		[SerializeField]
		private GameObject[] childObjects = Array.Empty<GameObject>();

		[SerializeField]
		private TintColorSelectionOptions tintColorSelectionOption = TintColorSelectionOptions.ColorFromDeviceInfo;

		[SerializeField]
		private Color tintColor;

		[SerializeField]
		private DeviceInfo deviceInfo;

		public GameObject[] ChildObjects => childObjects;

		public void SetAllChildObjects()
		{
			childObjects = new GameObject[base.transform.childCount];
			for (int i = 0; i < base.transform.childCount; i++)
			{
				childObjects[i] = base.transform.GetChild(i).gameObject;
			}
		}

		public bool TryGetTintColor(out Color color)
		{
			if (tintColorSelectionOption == TintColorSelectionOptions.NoTint)
			{
				color = Color.clear;
				return false;
			}
			color = ((tintColorSelectionOption == TintColorSelectionOptions.CustomColor) ? tintColor : deviceInfo.DefaultColor);
			return true;
		}
	}
}
