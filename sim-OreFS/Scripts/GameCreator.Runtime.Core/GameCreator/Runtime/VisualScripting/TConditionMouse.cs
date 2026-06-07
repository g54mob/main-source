using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Parameter("Button", "The Mouse button that is checked")]
	[Keywords(new string[] { "Cursor" })]
	public abstract class TConditionMouse : Condition
	{
		protected enum Button
		{
			Left = 0,
			Right = 1,
			Middle = 2,
			Forward = 3,
			Back = 4
		}

		[SerializeField]
		protected Button m_Button;
	}
}
