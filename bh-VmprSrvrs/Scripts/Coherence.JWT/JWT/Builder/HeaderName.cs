using System.ComponentModel;

namespace JWT.Builder
{
	public enum HeaderName
	{
		[Description("typ")]
		Type = 0,
		[Description("cty")]
		ContentType = 1,
		[Description("alg")]
		Algorithm = 2,
		[Description("kid")]
		KeyId = 3,
		[Description("x5u")]
		X5u = 4,
		[Description("x5c")]
		X5c = 5,
		[Description("x5t")]
		X5t = 6
	}
}
