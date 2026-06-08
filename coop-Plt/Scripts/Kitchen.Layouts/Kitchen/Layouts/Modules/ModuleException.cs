namespace Kitchen.Layouts.Modules
{
	public class ModuleException : LayoutFailureException
	{
		public ModuleException(string message)
			: base(message)
		{
		}
	}
}
