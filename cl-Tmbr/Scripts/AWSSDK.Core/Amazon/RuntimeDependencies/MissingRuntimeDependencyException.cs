using Amazon.Runtime;

namespace Amazon.RuntimeDependencies
{
	public class MissingRuntimeDependencyException : AmazonClientException
	{
		public string PackageName { get; set; }

		public string ClassName { get; set; }

		public string RegisterMethod { get; set; }

		public MissingRuntimeDependencyException(string packageName, string className, string registerMethod)
			: base("Operation failed because of a missing runtime dependency. In Native AOT builds runtime dependencies can not be dynamically loaded from assembles. Instead the runtime dependency needs to be explicitly registered. To complete this operation register an instance of " + className + " from package " + packageName + " using the operation " + typeof(GlobalRuntimeDependencyRegistry).FullName + ".Instance." + registerMethod + ".")
		{
			PackageName = packageName;
			ClassName = className;
			RegisterMethod = registerMethod;
		}
	}
}
