namespace Rewired.Utils.Interfaces
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal interface IGetSetValue<T> : IGetValue<T>, ISetValue<T>
	{
	}
}
