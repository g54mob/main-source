namespace DV.Customization
{
	public interface IStaticParentCustomization
	{
		bool IsLODEnabled { get; }

		void Enable();

		void Disable();
	}
}
