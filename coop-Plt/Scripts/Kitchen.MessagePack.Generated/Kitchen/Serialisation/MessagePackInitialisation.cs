using Kitchen.Resolvers;
using MessagePack;
using MessagePack.Resolvers;
using MessagePack.Unity;
using MessagePack.Unity.Extension;
using Networking.Resolver;
using UnityEngine;

namespace Kitchen.Serialisation
{
	public static class MessagePackInitialisation
	{
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		public static void Initialise()
		{
			if (MessagePackUtility.DefaultOptions == null)
			{
				StaticCompositeResolver.Instance.Register(CustomResolver.Instance, UnityResolver.Instance, UnityBlitWithPrimitiveArrayResolver.Instance, GeneratedResolver.Instance, StandardResolver.Instance);
				MessagePackUtility.DefaultOptions = MessagePackSerializerOptions.Standard.WithResolver(StaticCompositeResolver.Instance);
				MessagePackSerializer.DefaultOptions = MessagePackUtility.DefaultOptions;
			}
			if (MessagePackUtility.ObsoleteOptionsWithoutAOT == null)
			{
				MessagePackUtility.ObsoleteOptionsWithoutAOT = MessagePackSerializerOptions.Standard;
			}
		}
	}
}
