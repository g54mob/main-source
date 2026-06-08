using System;
using System.Linq;
using System.Reflection;
using Castle.Core.Internal;
using Castle.DynamicProxy.Generators.Emitters;

namespace Castle.DynamicProxy
{
	internal static class ExceptionMessageBuilder
	{
		internal static string CreateInstructionsToMakeVisible(Assembly targetAssembly)
		{
			string arg = " not";
			string arg2 = "\"DynamicProxyGenAssembly2\"";
			if (targetAssembly.IsAssemblySigned())
			{
				arg = "";
				arg2 = (ReferencesCastleCore(targetAssembly) ? "InternalsVisible.ToDynamicProxyGenAssembly2" : "\"DynamicProxyGenAssembly2, PublicKey=0024000004800000940000000602000000240000525341310004000001000100c547cac37abd99c8db225ef2f6c8a3602f3b3606cc9891605d02baa56104f4cfc0734aa39b93bf7852f7d9266654753cc297e7d2edfe0bac1cdcf9f717241550e0a7b191195b7667bb4f64bcb8e2121380fd1d9d46ad2d92d2d15605093924cceaf74c4861eff62abf69b9291ed0a340e113be11e6a7d3113e92484cf7045cc7\"");
			}
			return $"Make it public, or internal and mark your assembly with [assembly: InternalsVisibleTo({arg2})] attribute, because assembly {targetAssembly.GetName().Name} is{arg} strong-named.";
			static bool ReferencesCastleCore(Assembly ia)
			{
				return ia.GetReferencedAssemblies().Any((AssemblyName r) => r.FullName == Assembly.GetExecutingAssembly().FullName);
			}
		}

		public static string CreateMessageForInaccessibleType(Type inaccessibleType, Type typeToProxy)
		{
			Assembly assembly = typeToProxy.GetTypeInfo().Assembly;
			string arg = ((inaccessibleType == typeToProxy) ? "it" : ("type " + inaccessibleType.GetBestName()));
			string text = $"Can not create proxy for type {typeToProxy.GetBestName()} because {arg} is not accessible. ";
			string text2 = CreateInstructionsToMakeVisible(assembly);
			return text + text2;
		}
	}
}
