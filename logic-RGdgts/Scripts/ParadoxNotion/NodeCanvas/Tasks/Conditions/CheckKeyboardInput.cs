using NodeCanvas.Framework;
using ParadoxNotion;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	public class CheckKeyboardInput : ConditionTask
	{
		public PressTypes pressType;

		public KeyCode key;

		protected override string info => null;

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
