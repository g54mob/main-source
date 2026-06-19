using Loxodon.Framework.Execution;
using Loxodon.Framework.Prefs;
using Loxodon.Framework.Services;

namespace Loxodon.Framework.Contexts
{
	public class ApplicationContext : Context
	{
		private IMainLoopExecutor mainLoopExecutor;

		public ApplicationContext()
			: this(null, null)
		{
		}

		public ApplicationContext(IServiceContainer container, IMainLoopExecutor mainLoopExecutor)
			: base(container, null)
		{
			this.mainLoopExecutor = mainLoopExecutor;
		}

		public virtual IMainLoopExecutor GetMainLoopExcutor()
		{
			if (mainLoopExecutor == null)
			{
				mainLoopExecutor = new MainLoopExecutor();
			}
			return mainLoopExecutor;
		}

		public virtual Preferences GetGlobalPreferences()
		{
			return Preferences.GetGlobalPreferences();
		}

		public virtual Preferences GetUserPreferences(string name)
		{
			return Preferences.GetPreferences(name);
		}
	}
}
