namespace Sentry
{
	public interface IScopeObserver
	{
		void AddBreadcrumb(Breadcrumb breadcrumb);

		void SetExtra(string key, object? value);

		void SetTag(string key, string value);

		void UnsetTag(string key);

		void SetUser(SentryUser? user);
	}
}
