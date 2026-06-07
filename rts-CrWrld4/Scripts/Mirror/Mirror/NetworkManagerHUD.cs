using System;
using UnityEngine;

namespace Mirror
{
	[DisallowMultipleComponent]
	public class NetworkManagerHUD : MonoBehaviour
	{
		private NetworkManager manager;

		[Obsolete]
		public bool showGUI;

		public int offsetX;

		public int offsetY;

		private void Awake()
		{
		}

		private void OnGUI()
		{
		}

		private void StartButtons()
		{
		}

		private void StatusLabels()
		{
		}

		private void StopButtons()
		{
		}
	}
}
