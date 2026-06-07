using System;

namespace Rewired.Utils.Attributes
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	public class PreserveAttribute : Attribute
	{
	}
}
