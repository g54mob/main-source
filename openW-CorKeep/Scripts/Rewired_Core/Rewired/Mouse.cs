using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired
{
	public sealed class Mouse : ControllerWithAxes
	{
		private TimerAbs KbwEDMLfgjYZNKKTpjvcNsRdFPYP;

		private float[] hDyxuqAxaLJkkGAhqnEdVQfJECNK;

		private Vector2 xbHXqDHoyvOnkaNXNHsSECZNdAVeA;

		private Vector2 lwhkMSyNyZmJXoxEWNLyenJFmtWE;

		private int ZtgcEuGRoGpWkOsNhJHEgobPWqHsA;

		private readonly IUnifiedMouseSource OaOYuBtYDcUvUrUitbqxnryagZqe;

		private static Guid zPHlcXcecNeApEWhhqQKImQneWuo;

		public Vector2 screenPosition
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return Vector2.zero;
				}
				return xbHXqDHoyvOnkaNXNHsSECZNdAVeA;
			}
		}

		public Vector2 screenPositionPrev
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return Vector2.zero;
				}
				return lwhkMSyNyZmJXoxEWNLyenJFmtWE;
			}
		}

		public Vector2 screenPositionDelta
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return Vector2.zero;
				}
				return xbHXqDHoyvOnkaNXNHsSECZNdAVeA - lwhkMSyNyZmJXoxEWNLyenJFmtWE;
			}
		}

		Guid Controller.deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return Guid.Empty;
				}
				return zPHlcXcecNeApEWhhqQKImQneWuo;
			}
		}

		internal Mouse(string P_0, IUnifiedMouseSource P_1)
			: this(0, P_1.inputSource, P_0, InputTools.FormatHardwareIdentifierString(P_0), P_1.axisCount, P_1.buttonCount, P_1.hardwareMap, P_1?.controllerExtension, new ControllerDataUpdater(P_1.inputSource, P_1.axisCount, P_1.buttonCount, null))
		{
			OaOYuBtYDcUvUrUitbqxnryagZqe = P_1;
			zPHlcXcecNeApEWhhqQKImQneWuo = MiscTools.CreateGuidHashSHA1("[Universal Mouse]");
			vXguOrVHQgZdRgenIvihyjDDIBEO();
		}

		private Mouse(int P_0, InputSource P_1, string P_2, string P_3, int P_4, int P_5, HardwareControllerMap_Game P_6, Extension P_7, ControllerDataUpdater P_8)
			: base(P_0, P_1, P_2, P_2, P_3, ControllerType.Mouse, Consts.hardwareTypeGuid_universalMouse, P_4, P_5, null, P_6, P_7, P_8)
		{
		}

		internal void hSGCxkaCOGQKcjFqhwXznfKkGSVfb(UpdateLoopType P_0)
		{
			OaOYuBtYDcUvUrUitbqxnryagZqe.UpdateInputData(zfVdfqKDuqZKjafBdqgdinjRQNeGb);
			OJfGzCVGKpDcleZnYjZrjqAkLxdVA(P_0);
			iYjPkecXjCeUfqIyRgCqJXNpQqtjA();
		}

		protected override bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
		{
			pole = Pole.Positive;
			elementIdentifierId = -1;
			if (hDyxuqAxaLJkkGAhqnEdVQfJECNK == null)
			{
				hDyxuqAxaLJkkGAhqnEdVQfJECNK = new float[_axisCount];
			}
			if (KbwEDMLfgjYZNKKTpjvcNsRdFPYP == null)
			{
				KbwEDMLfgjYZNKKTpjvcNsRdFPYP = new TimerAbs(1.0);
			}
			if (KbwEDMLfgjYZNKKTpjvcNsRdFPYP.Update() || !KbwEDMLfgjYZNKKTpjvcNsRdFPYP.running)
			{
				KbwEDMLfgjYZNKKTpjvcNsRdFPYP.Start();
				Array.Clear(hDyxuqAxaLJkkGAhqnEdVQfJECNK, 0, hDyxuqAxaLJkkGAhqnEdVQfJECNK.Length);
			}
			if (ReInput.currentUpdateLoop == UpdateLoopType.OnGUI && !ReInput.configVars.GetPlatformVar_useNativeMouse())
			{
				hDyxuqAxaLJkkGAhqnEdVQfJECNK[index] += axes[index].valueRaw * 0.5f;
			}
			else
			{
				hDyxuqAxaLJkkGAhqnEdVQfJECNK[index] += axes[index].valueRaw;
			}
			float num = hDyxuqAxaLJkkGAhqnEdVQfJECNK[index];
			if (MathTools.Abs(num) <= axes[index].SmvTuJjdsvGiWKjCocbBJtqzCOoGb)
			{
				return false;
			}
			pole = ((!(num >= 0f)) ? Pole.Negative : Pole.Positive);
			elementIdentifierId = LJmpCFrENABMhmUxmGaTconkDyoGA.axisElementIdentifierIds[index];
			if (elementIdentifierId < 0)
			{
				return false;
			}
			KbwEDMLfgjYZNKKTpjvcNsRdFPYP.running = false;
			return true;
		}

		internal void IQejgrkBuQzKztflvLaJVkcNfEBd()
		{
			cXfFDiJKTugPYjySyrZDVWvcbgyj();
			if (KbwEDMLfgjYZNKKTpjvcNsRdFPYP != null)
			{
				KbwEDMLfgjYZNKKTpjvcNsRdFPYP.Clear();
			}
			xbHXqDHoyvOnkaNXNHsSECZNdAVeA = Vector2.zero;
			lwhkMSyNyZmJXoxEWNLyenJFmtWE = Vector2.zero;
		}

		internal bool sfHASNKRqlAesLmWWEcpGcOFgFbX(bool P_0)
		{
			if (!base.XExEgWAUoYDZHOcZKsQgKkhupxolA(P_0))
			{
				return false;
			}
			if (OaOYuBtYDcUvUrUitbqxnryagZqe is IGetSetEnabled)
			{
				(OaOYuBtYDcUvUrUitbqxnryagZqe as IGetSetEnabled).enabled = P_0;
			}
			if (P_0)
			{
				iYjPkecXjCeUfqIyRgCqJXNpQqtjA();
				lwhkMSyNyZmJXoxEWNLyenJFmtWE = screenPosition;
			}
			return true;
		}

		private void iYjPkecXjCeUfqIyRgCqJXNpQqtjA()
		{
			int currentUnityFrame = ReInput.currentUnityFrame;
			if (currentUnityFrame != ZtgcEuGRoGpWkOsNhJHEgobPWqHsA)
			{
				lwhkMSyNyZmJXoxEWNLyenJFmtWE = xbHXqDHoyvOnkaNXNHsSECZNdAVeA;
				xbHXqDHoyvOnkaNXNHsSECZNdAVeA = OaOYuBtYDcUvUrUitbqxnryagZqe.mousePosition;
				ZtgcEuGRoGpWkOsNhJHEgobPWqHsA = currentUnityFrame;
			}
		}
	}
}
