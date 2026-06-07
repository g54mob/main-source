using System;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class UpdatesRepository : TRepository<UpdatesRepository>
	{
		public const string REPOSITORY_ID = "core.updates";

		public override string RepositoryID => "core.updates";
	}
}
