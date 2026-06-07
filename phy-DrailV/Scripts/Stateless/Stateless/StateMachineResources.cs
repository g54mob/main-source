using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;

namespace Stateless
{
	[DebuggerNonUserCode]
	public class StateMachineResources
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceManager ResourceManager
		{
			get
			{
				if (resourceMan == null)
				{
					resourceMan = new ResourceManager("Stateless.StateMachineResources", typeof(StateMachineResources).Assembly);
				}
				return resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static CultureInfo Culture
		{
			get
			{
				return resourceCulture;
			}
			set
			{
				resourceCulture = value;
			}
		}

		public static string CannotReconfigureParameters => ResourceManager.GetString("CannotReconfigureParameters", resourceCulture);

		public static string NoTransitionsPermitted => ResourceManager.GetString("NoTransitionsPermitted", resourceCulture);

		public static string NoTransitionsUnmetGuardConditions => ResourceManager.GetString("NoTransitionsUnmetGuardConditions", resourceCulture);

		internal StateMachineResources()
		{
		}
	}
}
