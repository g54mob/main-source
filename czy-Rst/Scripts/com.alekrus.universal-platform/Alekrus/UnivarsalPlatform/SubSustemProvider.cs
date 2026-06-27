using System;
using System.Collections.Generic;
using UnityEngine;

namespace Alekrus.UnivarsalPlatform
{
	public class SubSustemProvider
	{
		protected static Dictionary<Type, SubInterfaceProviderGetEventHandler> _subInterfaces = new Dictionary<Type, SubInterfaceProviderGetEventHandler>();

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void OnSubsystemRegistration()
		{
			_subInterfaces.Clear();
		}

		public static void SetGetEventHandler<TSubInterface>(SubInterfaceProviderGetEventHandler parGetEventHandler) where TSubInterface : ISubInterface<IMain>
		{
			Type typeFromHandle = typeof(TSubInterface);
			_subInterfaces[typeFromHandle] = parGetEventHandler;
		}

		public static TSubInterface Get<TSubInterface>(IMain parMain) where TSubInterface : ISubInterface<IMain>
		{
			Type typeFromHandle = typeof(TSubInterface);
			if (_subInterfaces.TryGetValue(typeFromHandle, out var value) && value != null)
			{
				return (TSubInterface)value(parMain);
			}
			return default(TSubInterface);
		}

		public static bool TryGet<TSubInterface>(IMain parMain, out TSubInterface outSubInterface) where TSubInterface : ISubInterface<IMain>
		{
			Type typeFromHandle = typeof(TSubInterface);
			if (_subInterfaces.TryGetValue(typeFromHandle, out var value) && value != null)
			{
				outSubInterface = (TSubInterface)value(parMain);
				return true;
			}
			outSubInterface = default(TSubInterface);
			return false;
		}
	}
}
