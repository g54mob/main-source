namespace Bindito.Core
{
	public interface IScopeAssignee
	{
		IExportAssignee AsSingleton();

		IExportAssignee AsTransient();
	}
}
