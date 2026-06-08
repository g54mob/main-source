namespace Amazon.RuntimeDependencies
{
	public class SigV4aCrtSignerContext
	{
		public bool SignPayload { get; set; }

		public SigV4aCrtSignerContext(bool signPayload)
		{
			SignPayload = signPayload;
		}
	}
}
