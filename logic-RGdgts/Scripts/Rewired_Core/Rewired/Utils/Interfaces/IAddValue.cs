namespace Rewired.Utils.Interfaces
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal interface IAddValue<TValue>
	{
		void Add(TValue value);
	}
}
