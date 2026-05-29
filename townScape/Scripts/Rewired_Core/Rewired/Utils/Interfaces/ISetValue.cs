namespace Rewired.Utils.Interfaces
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal interface ISetValue<T>
	{
		void SetValue(T value);
	}
}
