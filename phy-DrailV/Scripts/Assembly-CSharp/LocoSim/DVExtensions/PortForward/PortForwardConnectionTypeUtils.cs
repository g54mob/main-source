namespace LocoSim.DVExtensions.PortForward
{
	public static class PortForwardConnectionTypeUtils
	{
		public static bool IsCouplerCompatibleWithConnectionType(PortForwardConnectionType connectionType, Coupler c)
		{
			switch (connectionType)
			{
			case PortForwardConnectionType.COUPLED_FRONT:
				return c.isFrontCoupler;
			case PortForwardConnectionType.COUPLED_REAR:
				return !c.isFrontCoupler;
			case PortForwardConnectionType.COUPLED_ANY:
				return true;
			default:
				return false;
			}
		}
	}
}
