using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired
{
	public sealed class Mouse : ControllerWithAxes
	{
		private TimerAbs CNsBHrFzYECOLhFvbkoucFIXdyPZA;

		private float[] lcqVrBeXGuhKwDwJcRkrBHktIzYbA;

		private Vector2 noFalwtNSCkWajnhRhSCAJQlffOk;

		private Vector2 rdMkpGOOspMBrsmGWKykQfvBiFD;

		private int VNwcCFxSGjBxwbFlbJSKyVehrLIv;

		private readonly IUnifiedMouseSource WMMwraPtnHXzKyoOzcattDrCcDvX;

		private static Guid pUFulsGJMgUPrXZDncNKOYVFGhzN;

		public Vector2 screenPosition
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return Vector2.zero;
				}
				return noFalwtNSCkWajnhRhSCAJQlffOk;
			}
		}

		public Vector2 screenPositionPrev
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return Vector2.zero;
				}
				return rdMkpGOOspMBrsmGWKykQfvBiFD;
			}
		}

		public Vector2 screenPositionDelta
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return Vector2.zero;
				}
				return noFalwtNSCkWajnhRhSCAJQlffOk - rdMkpGOOspMBrsmGWKykQfvBiFD;
			}
		}

		Guid Controller.deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return Guid.Empty;
				}
				return pUFulsGJMgUPrXZDncNKOYVFGhzN;
			}
		}

		internal Mouse(string P_0, IUnifiedMouseSource P_1)
			: this(0, P_1.inputSource, P_0, InputTools.FormatHardwareIdentifierString(P_0), P_1.axisCount, P_1.buttonCount, P_1.hardwareMap, P_1?.controllerExtension, new ControllerDataUpdater(P_1.inputSource, P_1.axisCount, P_1.buttonCount, null))
		{
			WMMwraPtnHXzKyoOzcattDrCcDvX = P_1;
			pUFulsGJMgUPrXZDncNKOYVFGhzN = MiscTools.CreateGuidHashSHA1("[Universal Mouse]");
			blqnoKjqhVSIFnqRKLejmqEtdoFaA();
		}

		private Mouse(int P_0, InputSource P_1, string P_2, string P_3, int P_4, int P_5, HardwareControllerMap_Game P_6, Extension P_7, ControllerDataUpdater P_8)
			: base(P_0, P_1, P_2, P_2, P_3, ControllerType.Mouse, Consts.hardwareTypeGuid_universalMouse, P_4, P_5, null, P_6, P_7, P_8)
		{
		}

		internal void fYMzuZcyujNmyKdKjOPvtnRGfdMH(UpdateLoopType P_0)
		{
			WMMwraPtnHXzKyoOzcattDrCcDvX.UpdateInputData(rGVdhXruOTgLzoPtrwxfhKmroixX);
			KcxabjhCuUxlxWHNCxIliMVWtSiM(P_0);
			kMtueROiZjDOhffMTDSgJgUZBzoH();
		}

		protected override bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
		{
			pole = Pole.Positive;
			elementIdentifierId = -1;
			if (lcqVrBeXGuhKwDwJcRkrBHktIzYbA == null)
			{
				lcqVrBeXGuhKwDwJcRkrBHktIzYbA = new float[_axisCount];
			}
			if (CNsBHrFzYECOLhFvbkoucFIXdyPZA == null)
			{
				CNsBHrFzYECOLhFvbkoucFIXdyPZA = new TimerAbs(1.0);
			}
			if (CNsBHrFzYECOLhFvbkoucFIXdyPZA.Update() || !CNsBHrFzYECOLhFvbkoucFIXdyPZA.running)
			{
				CNsBHrFzYECOLhFvbkoucFIXdyPZA.Start();
				Array.Clear(lcqVrBeXGuhKwDwJcRkrBHktIzYbA, 0, lcqVrBeXGuhKwDwJcRkrBHktIzYbA.Length);
			}
			if (ReInput.currentUpdateLoop == UpdateLoopType.OnGUI && !ReInput.configVars.GetPlatformVar_useNativeMouse())
			{
				lcqVrBeXGuhKwDwJcRkrBHktIzYbA[index] += axes[index].valueRaw * 0.5f;
			}
			else
			{
				lcqVrBeXGuhKwDwJcRkrBHktIzYbA[index] += axes[index].valueRaw;
			}
			float num = lcqVrBeXGuhKwDwJcRkrBHktIzYbA[index];
			if (MathTools.Abs(num) <= axes[index].GZzcNiDwCSefGXRigFePGjvNjfbIb)
			{
				return false;
			}
			pole = ((!(num >= 0f)) ? Pole.Negative : Pole.Positive);
			elementIdentifierId = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.axisElementIdentifierIds[index];
			if (elementIdentifierId < 0)
			{
				return false;
			}
			CNsBHrFzYECOLhFvbkoucFIXdyPZA.running = false;
			return true;
		}

		internal void GJcgbTQkxhJcCkqVpTKgPKpbDKAP()
		{
			eQlPXXtIjTBbUuFweKqVJFyUmYbL();
			if (CNsBHrFzYECOLhFvbkoucFIXdyPZA != null)
			{
				CNsBHrFzYECOLhFvbkoucFIXdyPZA.Clear();
			}
			noFalwtNSCkWajnhRhSCAJQlffOk = Vector2.zero;
			rdMkpGOOspMBrsmGWKykQfvBiFD = Vector2.zero;
		}

		internal bool etFwSmgmISVDgMzaOmBhMMVdrucY(bool P_0)
		{
			if (!base.BXxyidqXWhYGVbTpYPscakwYIxji(P_0))
			{
				return false;
			}
			if (WMMwraPtnHXzKyoOzcattDrCcDvX is IGetSetEnabled)
			{
				(WMMwraPtnHXzKyoOzcattDrCcDvX as IGetSetEnabled).enabled = P_0;
			}
			if (P_0)
			{
				kMtueROiZjDOhffMTDSgJgUZBzoH();
				rdMkpGOOspMBrsmGWKykQfvBiFD = screenPosition;
			}
			return true;
		}

		private void kMtueROiZjDOhffMTDSgJgUZBzoH()
		{
			int currentUnityFrame = ReInput.currentUnityFrame;
			if (currentUnityFrame != VNwcCFxSGjBxwbFlbJSKyVehrLIv)
			{
				rdMkpGOOspMBrsmGWKykQfvBiFD = noFalwtNSCkWajnhRhSCAJQlffOk;
				noFalwtNSCkWajnhRhSCAJQlffOk = WMMwraPtnHXzKyoOzcattDrCcDvX.mousePosition;
				VNwcCFxSGjBxwbFlbJSKyVehrLIv = currentUnityFrame;
			}
		}
	}
}
