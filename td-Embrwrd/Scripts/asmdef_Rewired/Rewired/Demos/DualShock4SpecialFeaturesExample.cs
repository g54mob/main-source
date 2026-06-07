using System.Collections.Generic;
using Rewired.ControllerExtensions;
using UnityEngine;

namespace Rewired.Demos
{
	[AddComponentMenu(null)]
	public class DualShock4SpecialFeaturesExample : MonoBehaviour
	{
		private class Touch
		{
			public GameObject go;

			public int touchId;
		}

		private const int maxTouches = 2;

		public int playerId;

		public Transform touchpadTransform;

		public GameObject lightObject;

		public Transform accelerometerTransform;

		private List<Touch> touches;

		private Queue<Touch> unusedTouches;

		private bool isFlashing;

		private GUIStyle textStyle;

		private Player player => null;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void OnGUI()
		{
		}

		private void ResetOrientation()
		{
		}

		private void SetRandomLightColor()
		{
		}

		private void StartLightFlash()
		{
		}

		private void StopLightFlash()
		{
		}

		private IDualShock4Extension GetFirstDS4(Player player)
		{
			return null;
		}

		private void InitializeTouchObjects()
		{
		}

		private void HandleTouchpad(IDualShock4Extension ds4)
		{
		}
	}
}
