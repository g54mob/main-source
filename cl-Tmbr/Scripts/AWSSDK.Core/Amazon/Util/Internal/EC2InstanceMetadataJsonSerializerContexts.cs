namespace Amazon.Util.Internal
{
	[JsonSerializable(typeof(IAMInstanceProfileMetadata))]
	[JsonSerializable(typeof(IAMSecurityCredentialMetadata))]
	public class EC2InstanceMetadataJsonSerializerContexts : JsonSerializerContext
	{
	}
}
