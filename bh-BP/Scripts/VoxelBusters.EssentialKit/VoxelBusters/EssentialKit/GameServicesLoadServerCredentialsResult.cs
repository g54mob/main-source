using System.Collections.Generic;

namespace VoxelBusters.EssentialKit
{
	public class GameServicesLoadServerCredentialsResult
	{
		public ServerCredentials ServerCredentials { get; private set; }

		public List<ServerCredentialAdditionalScope> AdditionalGrantedScopes { get; private set; }

		internal GameServicesLoadServerCredentialsResult(ServerCredentials serverCredentials, List<ServerCredentialAdditionalScope> additionalGrantedScopes)
		{
		}
	}
}
