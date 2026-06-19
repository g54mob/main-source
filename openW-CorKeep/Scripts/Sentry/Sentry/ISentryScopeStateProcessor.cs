namespace Sentry
{
	public interface ISentryScopeStateProcessor
	{
		void Apply(Scope scope, object state);
	}
}
