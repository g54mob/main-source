using System;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public static class Tween
	{
		public static void To(GameObject gameObject, ITweenInput input)
		{
			TweenRunner tweenRunner = gameObject.Get<TweenRunner>();
			if (tweenRunner == null)
			{
				tweenRunner = gameObject.Add<TweenRunner>();
			}
			tweenRunner.To(input);
		}

		public static void Cancel(GameObject gameObject, int hash)
		{
			TweenRunner tweenRunner = gameObject.Get<TweenRunner>();
			if (!(tweenRunner == null))
			{
				tweenRunner.Cancel(hash);
			}
		}

		public static void CancelAll(GameObject gameObject)
		{
			TweenRunner tweenRunner = gameObject.Get<TweenRunner>();
			if (!(tweenRunner == null))
			{
				tweenRunner.CancelAll();
			}
		}

		public static int GetHash(Type type, string member)
		{
			if (type == null)
			{
				return 0;
			}
			string text = type.Name.ToLowerInvariant();
			string text2 = member.ToLowerInvariant();
			return (text + "." + text2).GetHashCode();
		}

		public static int GetHash(Type type, Component instance, string member)
		{
			if (type == null)
			{
				return 0;
			}
			if (instance == null)
			{
				return 0;
			}
			string arg = type.Name.ToLowerInvariant();
			string arg2 = member.ToLowerInvariant();
			return $"{arg}.{instance.GetInstanceID()}.{arg2}".GetHashCode();
		}
	}
}
