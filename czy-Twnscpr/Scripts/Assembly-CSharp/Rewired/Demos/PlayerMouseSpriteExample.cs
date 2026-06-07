using System;
using UnityEngine;

namespace Rewired.Demos
{
	public class PlayerMouseSpriteExample : MonoBehaviour
	{
		public int playerId;

		public string horizontalAction;

		public string verticalAction;

		public string wheelAction;

		public string leftButtonAction;

		public string rightButtonAction;

		public string middleButtonAction;

		public float distanceFromCamera;

		public float spriteScale;

		public GameObject pointerPrefab;

		public GameObject clickEffectPrefab;

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
