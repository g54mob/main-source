using System.Collections.Generic;

namespace TH20
{
	public class GetProfilesResponse : GenericResponseBase
	{
		public EProfileRequestType RequestType { get; set; }

		public List<OnlinePlayerInfo> Profiles { get; set; }

		public GetProfilesResponse(int requestID, List<OnlinePlayerInfo> profiles)
			: base(requestID)
		{
			base.RequestID = requestID;
			Profiles = profiles;
		}
	}
}
