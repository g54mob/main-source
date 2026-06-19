using System.Collections.Generic;

namespace TH20
{
	public class GetProfilesRequest : GenericRequestBase
	{
		public EProfileRequestType RequestType { get; set; }

		public GetProfilesRequest(OnlinePlayerID playerID, List<OnlinePlayerID> profilesToGet, EProfileRequestType requestType)
		{
			base.UserID = playerID;
			RequestType = requestType;
		}
	}
}
