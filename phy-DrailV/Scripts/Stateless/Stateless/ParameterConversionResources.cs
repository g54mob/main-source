using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;

namespace Stateless
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	internal class ParameterConversionResources
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
					resourceMan = new ResourceManager("Stateless.ParameterConversionResources", typeof(ParameterConversionResources).Assembly);
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

		internal static string ArgOfTypeRequiredInPosition => ResourceManager.GetString("ArgOfTypeRequiredInPosition", resourceCulture);

		internal static string TooManyParameters => ResourceManager.GetString("TooManyParameters", resourceCulture);

		internal static string WrongArgType => ResourceManager.GetString("WrongArgType", resourceCulture);

		internal ParameterConversionResources()
		{
		}
	}
}
