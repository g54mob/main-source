using System.Collections.Generic;
using System.Linq;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using UnityEngine;

namespace NSEipix
{
	public static class AnimatorExtension
	{
		public static bool HasParameter(this Animator animator, string paramName)
		{
			return animator.parameters.Any((AnimatorControllerParameter param) => param.name == paramName);
		}

		public static void ResetTriggers(this Animator animator)
		{
			AnimatorControllerParameter[] parameters = animator.parameters;
			foreach (AnimatorControllerParameter animatorControllerParameter in parameters)
			{
				if (animatorControllerParameter.type == AnimatorControllerParameterType.Trigger)
				{
					animator.ResetTrigger(animatorControllerParameter.name);
				}
			}
		}

		public static bool IsInTagWithoutTransition(this Animator animator, int tagHash)
		{
			if (!animator.enabled)
			{
				return true;
			}
			if (animator.IsInTransition(0))
			{
				return false;
			}
			if (animator.GetCurrentAnimatorStateInfo(0).tagHash == tagHash)
			{
				return true;
			}
			return false;
		}

		public static void RebindKeepState(this Animator animator)
		{
			using PooledList<KeyValuePair<string, float>> pooledList = ListPool<KeyValuePair<string, float>>.GetJanitor();
			using PooledList<KeyValuePair<string, int>> pooledList2 = ListPool<KeyValuePair<string, int>>.GetJanitor();
			using PooledList<KeyValuePair<string, bool>> pooledList3 = ListPool<KeyValuePair<string, bool>>.GetJanitor();
			AnimatorControllerParameter[] parameters = animator.parameters;
			foreach (AnimatorControllerParameter animatorControllerParameter in parameters)
			{
				switch (animatorControllerParameter.type)
				{
				case AnimatorControllerParameterType.Float:
					pooledList.Add(new KeyValuePair<string, float>(animatorControllerParameter.name, animator.GetFloat(animatorControllerParameter.name)));
					break;
				case AnimatorControllerParameterType.Int:
					pooledList2.Add(new KeyValuePair<string, int>(animatorControllerParameter.name, animator.GetInteger(animatorControllerParameter.name)));
					break;
				case AnimatorControllerParameterType.Bool:
					pooledList3.Add(new KeyValuePair<string, bool>(animatorControllerParameter.name, animator.GetBool(animatorControllerParameter.name)));
					break;
				}
			}
			animator.Rebind();
			foreach (KeyValuePair<string, float> item in pooledList)
			{
				animator.SetFloat(item.Key, item.Value);
			}
			foreach (KeyValuePair<string, int> item2 in pooledList2)
			{
				animator.SetInteger(item2.Key, item2.Value);
			}
			foreach (KeyValuePair<string, bool> item3 in pooledList3)
			{
				animator.SetBool(item3.Key, item3.Value);
			}
		}
	}
}
