using System;
using UnityEngine;

namespace Rewired.Demos
{
	[AddComponentMenu(null)]
	public class PlayerMouseSpriteExample : MonoBehaviour
	{
		[Tooltip("The Player that will control the mouse")]
		public int playerId;

		[Tooltip("The Rewired Action used for the mouse horizontal axis.")]
		public string horizontalAction;

		[Tooltip("The Rewired Action used for the mouse vertical axis.")]
		public string verticalAction;

		[Tooltip("The Rewired Action used for the mouse wheel axis.")]
		public string wheelAction;

		[Tooltip("The Rewired Action used for the mouse left button.")]
		public string leftButtonAction;

		[Tooltip("The Rewired Action used for the mouse right button.")]
		public string rightButtonAction;

		[Tooltip("The Rewired Action used for the mouse middle button.")]
		public string middleButtonAction;

		[Tooltip("The distance from the camera that the pointer will be drawn.")]
		public float distanceFromCamera;

		[Tooltip("The scale of the sprite pointer.")]
		public float spriteScale;

		[Tooltip("The pointer prefab.")]
		public GameObject pointerPrefab;

		[Tooltip("The click effect prefab.")]
		public GameObject clickEffectPrefab;

		[Tooltip("Should the hardware pointer be hidden?")]
		public bool hideHardwarePointer;

		[NonSerialized]
		private GameObject pointer;

		[NonSerialized]
		private PlayerMouse mouse;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void OnDestroy()
		{
		}

		private void CreateClickEffect(Color color)
		{
		}

		private void OnScreenPositionChanged(Vector2 position)
		{
		}
	}
}
