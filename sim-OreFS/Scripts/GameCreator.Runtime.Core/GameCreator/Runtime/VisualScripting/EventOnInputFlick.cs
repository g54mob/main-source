using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Title("On Input Flick")]
	[Category("Input/On Input Flick")]
	[Description("Detects when Input (Vector 2) is flicked")]
	[Image(typeof(IconJoystick), ColorTheme.Type.Yellow)]
	public class EventOnInputFlick : TEventValue
	{
		[SerializeField]
		private InputPropertyValueVector2 m_Input = new InputPropertyValueVector2();

		[SerializeField]
		private CompareMinDistanceOrNone m_MinDistance = new CompareMinDistanceOrNone();

		protected override float Value => m_Input.Read().magnitude;

		protected override CompareMinDistanceOrNone MinDistance => m_MinDistance;

		protected internal override void OnAwake(Trigger trigger)
		{
			base.OnAwake(trigger);
			m_Input.OnStartup();
		}

		protected internal override void OnDestroy(Trigger trigger)
		{
			base.OnDestroy(trigger);
			m_Input.OnDispose();
		}

		protected internal override void OnUpdate(Trigger trigger)
		{
			base.OnUpdate(trigger);
			m_Input.OnUpdate();
			CheckExecute();
		}
	}
}
