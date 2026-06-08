using System.Runtime.InteropServices;

namespace Amazon.Util.Internal
{
	internal class RuntimeInformationWrapper : IRuntimeInformationWrapper
	{
		public string FrameworkDescription => RuntimeInformation.FrameworkDescription;
	}
}
