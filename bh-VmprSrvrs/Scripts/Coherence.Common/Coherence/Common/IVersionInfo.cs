namespace Coherence.Common
{
	public interface IVersionInfo
	{
		string Sdk { get; }

		string SdkRevisionHash { get; }

		string SdkRevisionOrVersion { get; }

		string Engine { get; }

		string DocsSlug { get; }
	}
}
