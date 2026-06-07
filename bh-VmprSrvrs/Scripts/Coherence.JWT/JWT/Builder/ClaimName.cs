using System.ComponentModel;

namespace JWT.Builder
{
	public enum ClaimName
	{
		[Description("iss")]
		Issuer = 0,
		[Description("sub")]
		Subject = 1,
		[Description("aud")]
		Audience = 2,
		[Description("exp")]
		ExpirationTime = 3,
		[Description("nbf")]
		NotBefore = 4,
		[Description("iat")]
		IssuedAt = 5,
		[Description("jti")]
		JwtId = 6,
		[Description("name")]
		FullName = 7,
		[Description("given_name")]
		GivenName = 8,
		[Description("family_name")]
		FamilyName = 9,
		[Description("middle_name")]
		MiddleName = 10,
		[Description("nickname")]
		CasualName = 11,
		[Description("preferred_username")]
		PreferredUsername = 12,
		[Description("profile")]
		ProfilePageUrl = 13,
		[Description("picture")]
		ProfilePictureUrl = 14,
		[Description("website")]
		Website = 15,
		[Description("email")]
		PreferredEmail = 16,
		[Description("email_verified")]
		VerifiedEmail = 17,
		[Description("gender")]
		Gender = 18,
		[Description("birthdate")]
		Birthday = 19,
		[Description("zoneinfo")]
		TimeZone = 20,
		[Description("locale")]
		Locale = 21,
		[Description("phone_number")]
		PreferredPhoneNumber = 22,
		[Description("phone_number_verified")]
		VerifiedPhoneNumber = 23,
		[Description("address")]
		Address = 24,
		[Description("update_at")]
		UpdatedAt = 25,
		[Description("azp")]
		AuthorizedParty = 26,
		[Description("nonce")]
		Nonce = 27,
		[Description("auth_time")]
		AuthenticationTime = 28,
		[Description("at_hash")]
		AccessTokenHash = 29,
		[Description("c_hash")]
		CodeHashValue = 30,
		[Description("acr")]
		Acr = 31,
		[Description("amr")]
		Amr = 32,
		[Description("sub_jwk")]
		PublicKey = 33,
		[Description("cnf")]
		Confirmation = 34,
		[Description("sip_from_tag")]
		SipFromTag = 35,
		[Description("sip_date")]
		SipDate = 36,
		[Description("sip_callid")]
		SipCallId = 37,
		[Description("sip_cseq_num")]
		SipCseqNumber = 38,
		[Description("sip_via_branch")]
		SipViaBranch = 39,
		[Description("orig")]
		OriginatingIdentityString = 40,
		[Description("dest")]
		DestinationIdentityString = 41,
		[Description("mky")]
		MediaKeyFingerprintString = 42
	}
}
