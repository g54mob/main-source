using System;

namespace Rewired.Utils.Attributes
{
	[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public class PreserveAttribute : Attribute
	{
	}
}
