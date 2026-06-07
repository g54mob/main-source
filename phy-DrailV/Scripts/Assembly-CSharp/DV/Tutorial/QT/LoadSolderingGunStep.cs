using DV.Customization.Gadgets;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class LoadSolderingGunStep : AQuickTutorialStep
	{
		public delegate GadgetSolderingTool ToolProvider();

		private GadgetSolderingTool solderingTool;

		private readonly ToolProvider provider;

		private readonly bool okIfFull;

		private readonly bool okIfNoCoil;

		private Transform attentionPointBackup;

		public LoadSolderingGunStep(GadgetSolderingTool solderingTool, AQuickTutorialMessage message, bool okIfFull, bool okIfNoCoil, bool shouldRecheck = true)
			: base(message, solderingTool.transform.FindChildRecursive("[reel_interaction_anchor]"), Vector3.zero, shouldRecheck)
		{
			this.solderingTool = solderingTool;
			this.okIfFull = okIfFull;
			this.okIfNoCoil = okIfNoCoil;
		}

		public LoadSolderingGunStep(ToolProvider provider, AQuickTutorialMessage message, bool okIfFull, bool okIfNoCoil, bool shouldRecheck = true)
			: base(message, null, Vector3.zero, shouldRecheck)
		{
			this.provider = provider;
			this.okIfFull = okIfFull;
			this.okIfNoCoil = okIfNoCoil;
		}

		protected override void InternalMakeCurrent()
		{
			if (provider != null)
			{
				solderingTool = provider();
				AttentionPoint = solderingTool.transform.FindChildRecursive("[reel_interaction_anchor]");
			}
			attentionPointBackup = AttentionPoint;
			base.InternalMakeCurrent();
		}

		protected override bool InternalCheck()
		{
			if (AttentionPoint != null && !AttentionPoint.gameObject.activeInHierarchy)
			{
				AttentionPoint = null;
				ShowVisual();
			}
			else if (AttentionPoint == null && attentionPointBackup != null && attentionPointBackup.gameObject.activeInHierarchy)
			{
				AttentionPoint = attentionPointBackup;
				ShowVisual();
			}
			if (!okIfFull || !solderingTool.CoilFull)
			{
				if (okIfNoCoil)
				{
					return !solderingTool.CoilLoaded;
				}
				return false;
			}
			return true;
		}
	}
}
