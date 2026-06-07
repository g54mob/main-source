using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;

namespace Stateless
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	internal class StateRepresentationResources
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (resourceMan == null)
				{
					resourceMan = new ResourceManager("Stateless.StateRepresentationResources", typeof(StateRepresentationResources).Assembly);
				}
				return resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
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

		internal static string MultipleTransitionsPermitted => ResourceManager.GetString("MultipleTransitionsPermitted", resourceCulture);

		internal StateRepresentationResources()
		{
		}
	}
}
