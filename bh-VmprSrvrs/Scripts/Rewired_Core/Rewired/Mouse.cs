using System;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired
{
	public sealed class Mouse : ControllerWithAxes
	{
		private TimerAbs YEiDwBhLvSjmgQBSzLxnCodZduoO;

		private float[] zcgOOpaBfuzqHQSmqFluCNDdshdR;

		private Vector2 nEFFGWtGbCOLRewMJcQXPpRltapf;

		private Vector2 zJhjHTGZlwRkwkDNSZvhfWtfPbcl;

		private int HMstdbfnSllBrwUzxZFQfPKdLfnc;

		private readonly IUnifiedMouseSource UFWDXIXMhHvJdtlTflvekCRWVMOe;

		private static Guid lqNLWKAivgOtKQbedaYXPwyJybUN;

		public Vector2 screenPosition => default(Vector2);

		public Vector2 screenPositionPrev => default(Vector2);

		public Vector2 screenPositionDelta => default(Vector2);

		public override Guid deviceInstanceGuid => default(Guid);

		internal Mouse(string P_0, IUnifiedMouseSource P_1)
			: base(0, default(InputSource), null, null, null, default(ControllerType), default(Guid), 0, 0, null, null, null, null)
		{
		}

		private Mouse(int P_0, InputSource P_1, string P_2, string P_3, int P_4, int P_5, HardwareControllerMap_Game P_6, Extension P_7, ControllerDataUpdater P_8)
			: base(0, default(InputSource), null, null, null, default(ControllerType), default(Guid), 0, 0, null, null, null, null)
		{
		}

		internal override void YKYVNphRaSYCICdOlkgpUiVDznty(UpdateLoopType P_0)
		{
		}

		protected override bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
		{
			pole = default(Pole);
			elementIdentifierId = default(int);
			return false;
		}

		internal override void qDCvRYqsIViBHdsnjFEZLKubCvtCA()
		{
		}

		internal override bool JbpBDYktpnwagiSlOUtczNfAEIQd(bool P_0)
		{
			return false;
		}

		private void aHrNKdGryjztMkRhHQqpGchTLfLH()
		{
		}
	}
}
