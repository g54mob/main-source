using System.Collections.Generic;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit.GameServicesCore
{
	public delegate void LoadServerCredentialsInternalCallback(ServerCredentials credentials, List<ServerCredentialAdditionalScope> additionalGrantedScopes, Error error);
}
