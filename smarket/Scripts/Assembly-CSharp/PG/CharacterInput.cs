using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace PG
{
	public class CharacterInput : MonoBehaviour
	{
		[Header("Device input settings")]
		public string HorizontalMoveAxis;

		public string VerticalMoveAxis;

		public string HorizontalViewAxis;

		public string VerticalViewAxis;

		public KeyCode EnterExitKeyboardKey;

		public KeyCode EnterExitGamepadKey;

		[Header("UI input settings")]
		public GameObject PfrentForUI;

		public MobileStickUI MoveStick;

		public MobileStickUI ViewStick;

		public float MobileViewMultiplier;

		public ButtonCustom EntrerInCarBtn;

		public Vector2 MoveInput { get; private set; }

		public Vector2 ViewInput { get; private set; }

		public event Action OnEntrerInCar
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
