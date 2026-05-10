using System;
using AeLa.EasyFeedback.UI.Interfaces;
using UnityEngine;

namespace AeLa.EasyFeedback.UI
{
	internal abstract class UIInteropWrapper<T> : IUIInteropWrapper where T : Component
	{
		protected readonly T InternalTarget;

		public static Type TargetType => null;

		public Component Target => null;

		public static T GetTarget(GameObject go)
		{
			return null;
		}

		internal UIInteropWrapper(T internalTarget)
		{
		}
	}
}
