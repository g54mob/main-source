namespace Amazon.Runtime.Identity
{
	public interface IIdentityResolverConfiguration
	{
		IIdentityResolver GetIdentityResolver<T>() where T : BaseIdentity;
	}
}
