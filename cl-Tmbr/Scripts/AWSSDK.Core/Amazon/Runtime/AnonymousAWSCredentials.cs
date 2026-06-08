namespace Amazon.Runtime
{
	public class AnonymousAWSCredentials : AWSCredentials
	{
		public override ImmutableCredentials GetCredentials()
		{
			return null;
		}
	}
}
