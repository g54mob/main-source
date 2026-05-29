namespace Rewired.Utils.Interfaces
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal interface IGetValue<T>
	{
		T GetValue();
	}
}
