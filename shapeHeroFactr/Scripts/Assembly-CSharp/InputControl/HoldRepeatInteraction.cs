using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

namespace InputControl
{
	[DisplayName("Hold Repeat Interaction")]
	public class HoldRepeatInteraction : IInputInteraction
	{
		[Tooltip("長押しが有効になるまでの時間(秒)")]
		public float holdTime;

		[Tooltip("長押し有効後のリピート間隔(秒)")]
		public float repeatInterval;

		private bool hasPerformedOnPress;

		private bool isHolding;

		private double holdStartTime;

		[RuntimeInitializeOnLoadMethod]
		private static void Initialize()
		{
		}

		public void Process(ref InputInteractionContext ctx)
		{
		}

		public void Reset()
		{
		}
	}
}
