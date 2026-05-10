using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("Input (Legacy System)")]
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
