using System;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired
{
	public sealed class Mouse : ControllerWithAxes
	{
		private TimerAbs kXnCtwnLvHGhGCIwSPJBqICbxnqp;

		private float[] KdIaYwcCJgIoUcuByYpYwyhjbrj;

		private Vector2 YtUNbqZGnkskMBQgbSDOQHkDukG;

		private Vector2 SZJMQgNjXigjzfAPUjxfouMhdTx;

		private int qIoSuZucDscAdTjtafGaEXExheza;

		private readonly IUnifiedMouseSource tfTCEMKNedpBjaNONhTolgkIZhi;

		private static Guid oYunZpJTAzmevafAkzSDraYkhYX;

		public Vector2 screenPosition => default(Vector2);

		public Vector2 screenPositionPrev => default(Vector2);

		public Vector2 screenPositionDelta => default(Vector2);

		public override Guid deviceInstanceGuid => default(Guid);

		internal Mouse(string name, IUnifiedMouseSource source)
			: base(0, default(InputSource), null, null, null, default(ControllerType), default(Guid), 0, 0, null, null, null, null)
		{
		}

		private Mouse(int controllerId, InputSource inputSource, string name, string hardwareIdentifier, int axisCount, int buttonCount, HardwareControllerMap_Game hardwareMap, Extension extension, ControllerDataUpdater dataUpdater)
			: base(0, default(InputSource), null, null, null, default(ControllerType), default(Guid), 0, 0, null, null, null, null)
		{
		}

		internal override void IdvXxslbVpgePKGcszHAudaDgmvT(UpdateLoopType P_0)
		{
		}

		protected override bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
		{
			pole = default(Pole);
			elementIdentifierId = default(int);
			return false;
		}

		internal override void DcbUeIfyTfvTrRQxceAMfGCsJNs()
		{
		}

		internal override bool WCkUbKnZwdSTjaEPCIHcdGhehrxE(bool P_0)
		{
			return false;
		}

		private void vxybhpuxSvocqKMeXUOycrODCok()
		{
		}
	}
}
