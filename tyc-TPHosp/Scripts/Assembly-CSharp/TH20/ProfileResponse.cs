using System.Collections.Generic;

namespace TH20
{
	[DontSave]
	public class ProfileResponse
	{
		public readonly string UserID;

		public readonly string Email;

		public readonly string Name;

		public ProfileResponse(Dictionary<string, object> responseData)
		{
			UserID = (string)responseData["user_id"];
			Name = (string)responseData["name"];
			Email = (string)responseData["email"];
		}
	}
}
