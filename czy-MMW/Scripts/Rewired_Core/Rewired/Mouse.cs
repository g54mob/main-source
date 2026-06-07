using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired
{
	public sealed class Mouse : ControllerWithAxes
	{
		private TimerAbs YGhlIvsPZgEtMXBsBUDpbVsGnAtW;

		private float[] vfzhwFtmLYHtxZqCAEJglUAabXkU;

		private Vector2 jHGrqUwRRgTtMvasbCBnceggFmGB;

		private Vector2 zHiTXpBgNMQXKvPhmjFhSskczatk;

		private int FrzXMNejNPeJbzbmFzrJUeKgnPyj;

		private readonly IUnifiedMouseSource SgRzgQOikviFbuBVBBwPBVrRzTob;

		private static Guid loOekmVePOgsqhFSTnaJGoxIIXTpB;

		public Vector2 screenPosition
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return Vector2.zero;
				}
				return jHGrqUwRRgTtMvasbCBnceggFmGB;
			}
		}

		public Vector2 screenPositionPrev
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return Vector2.zero;
				}
				return zHiTXpBgNMQXKvPhmjFhSskczatk;
			}
		}

		public Vector2 screenPositionDelta
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return Vector2.zero;
				}
				return jHGrqUwRRgTtMvasbCBnceggFmGB - zHiTXpBgNMQXKvPhmjFhSskczatk;
			}
		}

		Guid Controller.deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return Guid.Empty;
				}
				return loOekmVePOgsqhFSTnaJGoxIIXTpB;
			}
		}

		internal Mouse(string P_0, IUnifiedMouseSource P_1)
			: this(0, P_1.inputSource, P_0, InputTools.FormatHardwareIdentifierString(P_0), P_1.axisCount, P_1.buttonCount, P_1.hardwareMap, P_1?.controllerExtension, new ControllerDataUpdater(P_1.inputSource, P_1.axisCount, P_1.buttonCount, null))
		{
			SgRzgQOikviFbuBVBBwPBVrRzTob = P_1;
			loOekmVePOgsqhFSTnaJGoxIIXTpB = MiscTools.CreateGuidHashSHA1("[Universal Mouse]");
			rHrZhWmlidFfQIdUaELuLMacpKhFA();
		}

		private Mouse(int P_0, InputSource P_1, string P_2, string P_3, int P_4, int P_5, HardwareControllerMap_Game P_6, Extension P_7, ControllerDataUpdater P_8)
			: base(P_0, P_1, P_2, P_2, P_3, ControllerType.Mouse, Consts.hardwareTypeGuid_universalMouse, P_4, P_5, null, P_6, P_7, P_8)
		{
		}

		internal void xRFahBbArTsinIfDBtkgVqdJHCqK(UpdateLoopType P_0)
		{
			SgRzgQOikviFbuBVBBwPBVrRzTob.UpdateInputData(jaSaHPudVtcyecnoPKkgZIAqgGJr);
			SVeqpnebqgINoIMLuzyySxsVmmWd(P_0);
			aJgpWLTdAFdukhpJpUorxvwAAhMs();
		}

		protected override bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
		{
			pole = Pole.Positive;
			elementIdentifierId = -1;
			if (vfzhwFtmLYHtxZqCAEJglUAabXkU == null)
			{
				vfzhwFtmLYHtxZqCAEJglUAabXkU = new float[_axisCount];
			}
			if (YGhlIvsPZgEtMXBsBUDpbVsGnAtW == null)
			{
				YGhlIvsPZgEtMXBsBUDpbVsGnAtW = new TimerAbs(1.0);
			}
			if (YGhlIvsPZgEtMXBsBUDpbVsGnAtW.Update() || !YGhlIvsPZgEtMXBsBUDpbVsGnAtW.running)
			{
				YGhlIvsPZgEtMXBsBUDpbVsGnAtW.Start();
				Array.Clear(vfzhwFtmLYHtxZqCAEJglUAabXkU, 0, vfzhwFtmLYHtxZqCAEJglUAabXkU.Length);
			}
			if (ReInput.currentUpdateLoop == UpdateLoopType.OnGUI && !ReInput.configVars.GetPlatformVar_useNativeMouse())
			{
				vfzhwFtmLYHtxZqCAEJglUAabXkU[index] += axes[index].valueRaw * 0.5f;
			}
			else
			{
				vfzhwFtmLYHtxZqCAEJglUAabXkU[index] += axes[index].valueRaw;
			}
			float num = vfzhwFtmLYHtxZqCAEJglUAabXkU[index];
			if (MathTools.Abs(num) <= axes[index].StwpIgWxDqfQXZRhKpNYDDFYqJRQ)
			{
				return false;
			}
			pole = ((!(num >= 0f)) ? Pole.Negative : Pole.Positive);
			elementIdentifierId = XRregwEugLWeubJCKxSQAwUDapNP.axisElementIdentifierIds[index];
			if (elementIdentifierId < 0)
			{
				return false;
			}
			YGhlIvsPZgEtMXBsBUDpbVsGnAtW.running = false;
			return true;
		}

		internal void YPfxaVJicZVSLiaMTpvprCBqHmow()
		{
			ankcONBsyjJMRKuhOFZSQbGRfwHsA();
			if (YGhlIvsPZgEtMXBsBUDpbVsGnAtW != null)
			{
				YGhlIvsPZgEtMXBsBUDpbVsGnAtW.Clear();
			}
			jHGrqUwRRgTtMvasbCBnceggFmGB = Vector2.zero;
			zHiTXpBgNMQXKvPhmjFhSskczatk = Vector2.zero;
		}

		internal bool swKhTyxeDaHyvQWpwHqoFkneMQSCA(bool P_0)
		{
			if (!base.LAwnernCBTrnUblykcVvSoWLkSFf(P_0))
			{
				return false;
			}
			if (SgRzgQOikviFbuBVBBwPBVrRzTob is IGetSetEnabled)
			{
				(SgRzgQOikviFbuBVBBwPBVrRzTob as IGetSetEnabled).enabled = P_0;
			}
			if (P_0)
			{
				aJgpWLTdAFdukhpJpUorxvwAAhMs();
				zHiTXpBgNMQXKvPhmjFhSskczatk = screenPosition;
			}
			return true;
		}

		private void aJgpWLTdAFdukhpJpUorxvwAAhMs()
		{
			int currentUnityFrame = ReInput.currentUnityFrame;
			if (currentUnityFrame != FrzXMNejNPeJbzbmFzrJUeKgnPyj)
			{
				zHiTXpBgNMQXKvPhmjFhSskczatk = jHGrqUwRRgTtMvasbCBnceggFmGB;
				jHGrqUwRRgTtMvasbCBnceggFmGB = SgRzgQOikviFbuBVBBwPBVrRzTob.mousePosition;
				FrzXMNejNPeJbzbmFzrJUeKgnPyj = currentUnityFrame;
			}
		}
	}
}
