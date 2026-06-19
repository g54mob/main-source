namespace TH20
{
	public class GetAllFriendsResponse : GenericResponseBase
	{
		public OnlinePlayerInfo[] ReturnedFriends { get; set; }

		public GetAllFriendsResponse(int requestID, OnlinePlayerInfo[] friends)
			: base(requestID)
		{
			ReturnedFriends = friends;
			base.RequestID = requestID;
		}
	}
}
