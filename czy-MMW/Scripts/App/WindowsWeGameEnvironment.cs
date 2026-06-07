using Factory;
using Factory.Allocators;

public class WindowsWeGameEnvironment : WindowsBaseEnvironment
{
	public override void PopulateAppAssembler(Assembler baseAssembler)
	{
		base.PopulateAppAssembler(baseAssembler);
		baseAssembler.Register<IContentProfile, RetailContentProfile>().Allocator(new HeapAllocator<RetailContentProfile>()).Binding(Binding.Scope);
		baseAssembler.Register<ISoftwareCapabilities, WeGameSoftwareCapabilities>().Allocator(new HeapAllocator<WeGameSoftwareCapabilities>()).Binding(Binding.Scope);
	}
}
