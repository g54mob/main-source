using System;
using System.Collections.Generic;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MalbersAnimations.InputSystem
{
	[Serializable]
	public class MInputActionMap
	{
		public int Index;

		[Tooltip("Action for Moving the Character\n(X:Horizontal; Y:Forward)")]
		public InputActionReference Move;

		[Tooltip("Action for Moving Up and Down the Character")]
		public InputActionReference UpDown;

		[Tooltip("Multiplier for the Move value (X: Horizontal, Y: UpDown, Z:Forward/Vertical")]
		public Vector3Reference MoveMult = new Vector3Reference(Vector3.one);

		internal InputAction MoveAction;

		internal InputAction UpDownAction;

		public InputActionMap ActionMap;

		public List<MInputAction> buttons;

		public string Name => ActionMap.name;

		public MInputActionMap(InputActionMap map, int index)
		{
			Index = index;
			buttons = new List<MInputAction>();
			ActionMap = map;
		}
	}
}
