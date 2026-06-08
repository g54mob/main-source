using KitchenData;
using Platforms;

namespace Kitchen
{
	public static class GlobalLocalisationExtensions
	{
		public static string Name(this GlobalLocalisation gl, NetworkPermissions perm)
		{
			return perm switch
			{
				NetworkPermissions.Private => gl["MENU_PERMISSION_PRIVATE"], 
				NetworkPermissions.InviteOnly => gl["MENU_PERMISSION_INVITE_ONLY"], 
				NetworkPermissions.Open => gl["MENU_PERMISSION_OPEN"], 
				_ => "?", 
			};
		}
	}
}
