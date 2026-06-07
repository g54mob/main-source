using DV.Customization.Gadgets;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class ConnectGadgetsStep : AQuickTutorialStep
	{
		public delegate GadgetWiringTool GetToolDelegate();

		private readonly GetToolDelegate toolProvider;

		private readonly AQuickTutorialMessage message1;

		private readonly AQuickTutorialMessage message2;

		private readonly GadgetBase[] gadgets = new GadgetBase[2];

		private readonly GadgetWiringModule.WireLinkPort[] ports = new GadgetWiringModule.WireLinkPort[2];

		private GadgetWiringTool tool;

		private int closest;

		private bool wasStarted;

		public ConnectGadgetsStep(GadgetWiringTool tool, GadgetBase gadget1, GadgetBase gadget2, AQuickTutorialMessage message1, AQuickTutorialMessage message2, bool shouldRecheck = true)
			: base(message1, null, Vector3.zero, shouldRecheck)
		{
			toolProvider = null;
			this.tool = tool;
			this.message1 = message1;
			this.message2 = message2;
			gadgets[0] = gadget1;
			gadgets[1] = gadget2;
		}

		public ConnectGadgetsStep(GetToolDelegate toolProvider, GadgetBase gadget1, GadgetBase gadget2, AQuickTutorialMessage message1, AQuickTutorialMessage message2, bool shouldRecheck = true)
			: base(message1, null, Vector3.zero, shouldRecheck)
		{
			this.toolProvider = toolProvider;
			tool = null;
			this.message1 = message1;
			this.message2 = message2;
			gadgets[0] = gadget1;
			gadgets[1] = gadget2;
		}

		private int GetClosestUnconnected()
		{
			if (GadgetWiringModule.WireLinkPort.AreWired(ports[0], ports[1]))
			{
				return -1;
			}
			if (tool.Source == gadgets[0])
			{
				return 1;
			}
			if (tool.Source == gadgets[1])
			{
				return 0;
			}
			if (PlayerManager.PlayerTransform != null)
			{
				Vector3 position = PlayerManager.PlayerTransform.position;
				if ((position - gadgets[0].transform.position).sqrMagnitude < (position - gadgets[1].transform.position).sqrMagnitude)
				{
					return 0;
				}
				return 1;
			}
			return closest;
		}

		protected override void InternalMakeCurrent()
		{
			if (toolProvider != null)
			{
				tool = toolProvider();
			}
			gadgets[0].TryGetCompatiblePorts(gadgets[1], out ports[0], out ports[1]);
			closest = GetClosestUnconnected();
			wasStarted = tool.Source == gadgets[0] || tool.Source == gadgets[1];
			Message = (wasStarted ? message2 : message1);
			AttentionPoint = ((closest >= 0) ? gadgets[closest].transform : null);
			base.InternalMakeCurrent();
		}

		protected override bool InternalCheck()
		{
			int closestUnconnected = GetClosestUnconnected();
			bool flag = tool.Source == gadgets[0] || tool.Source == gadgets[1];
			if (closestUnconnected != closest || flag != wasStarted)
			{
				closest = closestUnconnected;
				wasStarted = flag;
				if (closest >= 0)
				{
					Message = (wasStarted ? message2 : message1);
					AttentionPoint = gadgets[closest].transform;
					ShowVisual();
				}
			}
			return GadgetWiringModule.WireLinkPort.AreWired(ports[0], ports[1]);
		}
	}
}
