namespace Rewired.Utils.Interfaces
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal interface IGetSetValue<T> : IGetValue<T>, ISetValue<T>
	{
	}
}
