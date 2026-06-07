namespace Rewired.Utils.Interfaces
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal interface IAddValue<TValue>
	{
		void Add(TValue value);
	}
}
