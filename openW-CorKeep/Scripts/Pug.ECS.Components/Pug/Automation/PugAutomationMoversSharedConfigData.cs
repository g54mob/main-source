namespace Pug.Automation
{
	public struct PugAutomationMoversSharedConfigData
	{
		public int moveTime;

		public int cooldownTime;

		public bool pickUp;

		public bool allowOnlyOneActiveMoverAtATime;

		public bool enableAllMoversAfterActivation;

		public bool enableInRoundRobinAfterActivation;

		public bool splitOnMove;

		public bool allowPickupFromInventories;
	}
}
