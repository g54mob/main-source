using ModIO.Implementation.API;

namespace ModIO.Implementation
{
	internal class ModManagementJob
	{
		public ProgressHandle progressHandle;

		public ModCollectionEntry mod;

		public ModManagementOperationType type;

		public RequestHandle<Result> downloadWebRequest;

		public IModIOZipOperation zipOperation;
	}
}
