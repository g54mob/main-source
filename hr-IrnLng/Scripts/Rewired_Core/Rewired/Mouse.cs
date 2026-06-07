using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired
{
	public sealed class Mouse : ControllerWithAxes
	{
		private TimerAbs kjFyODgmKDweJfkGmSoUwuxaeAj;

		private float[] KHoDVTczkeBJZBZhEEpZBAMmeIeB;

		private Vector2 SgmruLUfjiptJwhePdtLduLQWPZa;

		private Vector2 ABhJzHOuOswluSMhiiSiHGxulSiJ;

		private int gTAurqbiqkBJykmXOxpxScnqJJsc;

		private readonly IUnifiedMouseSource fzzXbvFoZzdAqHDolrszRhFTkOz;

		private static Guid aDUsEiUYonPfaVuLAuUCTJVjSYF;

		public Vector2 screenPosition
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return Vector2.zero;
				}
				return SgmruLUfjiptJwhePdtLduLQWPZa;
			}
		}

		public Vector2 screenPositionPrev
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return Vector2.zero;
				}
				return ABhJzHOuOswluSMhiiSiHGxulSiJ;
			}
		}

		public Vector2 screenPositionDelta
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return Vector2.zero;
				}
				return SgmruLUfjiptJwhePdtLduLQWPZa - ABhJzHOuOswluSMhiiSiHGxulSiJ;
			}
		}

		public override Guid deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return Guid.Empty;
				}
				return aDUsEiUYonPfaVuLAuUCTJVjSYF;
			}
		}

		internal Mouse(string name, IUnifiedMouseSource source)
			: this(0, source.inputSource, name, InputTools.FormatHardwareIdentifierString(name), source.axisCount, source.buttonCount, source.hardwareMap, source?.controllerExtension, new ControllerDataUpdater(source.inputSource, source.axisCount, source.buttonCount, null))
		{
			fzzXbvFoZzdAqHDolrszRhFTkOz = source;
			aDUsEiUYonPfaVuLAuUCTJVjSYF = MiscTools.CreateGuidHashSHA1("[Universal Mouse]");
			ANKdbHXpmTNShTcixGbSxMIpqJK();
		}

		private Mouse(int controllerId, InputSource inputSource, string name, string hardwareIdentifier, int axisCount, int buttonCount, HardwareControllerMap_Game hardwareMap, Extension extension, ControllerDataUpdater dataUpdater)
			: base(controllerId, inputSource, name, name, hardwareIdentifier, ControllerType.Mouse, Consts.hardwareTypeGuid_universalMouse, axisCount, buttonCount, null, hardwareMap, extension, dataUpdater)
		{
		}

		internal override void KcNfORqUkjxfSzjWExwXXCRKlZu(UpdateLoopType P_0)
		{
			fzzXbvFoZzdAqHDolrszRhFTkOz.UpdateInputData(QlXkhNBHPYUNWwhKurdwrqFgWTf);
			base.KcNfORqUkjxfSzjWExwXXCRKlZu(P_0);
			piSzEIrnzrXllnGGfSpfGStKDZrg();
		}

		protected override bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
		{
			pole = Pole.Positive;
			elementIdentifierId = -1;
			if (KHoDVTczkeBJZBZhEEpZBAMmeIeB == null)
			{
				KHoDVTczkeBJZBZhEEpZBAMmeIeB = new float[_axisCount];
			}
			if (kjFyODgmKDweJfkGmSoUwuxaeAj == null)
			{
				kjFyODgmKDweJfkGmSoUwuxaeAj = new TimerAbs(1.0);
			}
			if (kjFyODgmKDweJfkGmSoUwuxaeAj.Update() || !kjFyODgmKDweJfkGmSoUwuxaeAj.running)
			{
				kjFyODgmKDweJfkGmSoUwuxaeAj.Start();
				Array.Clear(KHoDVTczkeBJZBZhEEpZBAMmeIeB, 0, KHoDVTczkeBJZBZhEEpZBAMmeIeB.Length);
			}
			if (ReInput.currentUpdateLoop == UpdateLoopType.OnGUI && !ReInput.configVars.GetPlatformVar_useNativeMouse())
			{
				KHoDVTczkeBJZBZhEEpZBAMmeIeB[index] += axes[index].valueRaw * 0.5f;
			}
			else
			{
				KHoDVTczkeBJZBZhEEpZBAMmeIeB[index] += axes[index].valueRaw;
			}
			float num = KHoDVTczkeBJZBZhEEpZBAMmeIeB[index];
			if (MathTools.Abs(num) <= axes[index].effectivePollingDeadZone)
			{
				return false;
			}
			pole = ((!(num >= 0f)) ? Pole.Negative : Pole.Positive);
			elementIdentifierId = rEqQznEUmYwtoLNJsErzjlKjjYY.axisElementIdentifierIds[index];
			if (elementIdentifierId < 0)
			{
				return false;
			}
			kjFyODgmKDweJfkGmSoUwuxaeAj.running = false;
			return true;
		}

		internal override void VcHhfbFqwxAmqhwBHKVJpDjlfufe()
		{
			base.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
			if (kjFyODgmKDweJfkGmSoUwuxaeAj != null)
			{
				kjFyODgmKDweJfkGmSoUwuxaeAj.Clear();
			}
			SgmruLUfjiptJwhePdtLduLQWPZa = Vector2.zero;
			ABhJzHOuOswluSMhiiSiHGxulSiJ = Vector2.zero;
		}

		internal override bool WyEAtncPpRVmZFtqAefsZKfkUci(bool P_0)
		{
			if (!base.WyEAtncPpRVmZFtqAefsZKfkUci(P_0))
			{
				return false;
			}
			if (P_0)
			{
				piSzEIrnzrXllnGGfSpfGStKDZrg();
				ABhJzHOuOswluSMhiiSiHGxulSiJ = screenPosition;
			}
			return true;
		}

		private void piSzEIrnzrXllnGGfSpfGStKDZrg()
		{
			int currentUnityFrame = ReInput.currentUnityFrame;
			if (currentUnityFrame != gTAurqbiqkBJykmXOxpxScnqJJsc)
			{
				ABhJzHOuOswluSMhiiSiHGxulSiJ = SgmruLUfjiptJwhePdtLduLQWPZa;
				SgmruLUfjiptJwhePdtLduLQWPZa = fzzXbvFoZzdAqHDolrszRhFTkOz.mousePosition;
				gTAurqbiqkBJykmXOxpxScnqJJsc = currentUnityFrame;
			}
		}
	}
}
