using Assets.Scripts.Craft.Parts.Modifiers.Mfd;
using MoonSharp.Interpreter;

namespace Assets.Scripts.Lua.Proxies
{
	[MoonSharpUserData]
	public class MfdProxy
	{
		private ProxyFactory _factory;

		private MfdProgram _program;

		public WidgetProxy RootWidget => _factory.GetOrCreateProxy<WidgetProxy>(_program.RootWidget);

		[MoonSharpHidden]
		public MfdProxy(MfdProgram program, ProxyFactory factory)
		{
			_program = program;
			_factory = factory;
		}

		public void SelectPage(string id)
		{
			_program.SelectPage(id);
		}
	}
}
