using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Rewired;
using Rewired.Dev;
using RewiredConsts;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Restory.Utils
{
	public static class RewiredExtensions
	{
		public static string CurrentTag(this Rewired.Player player)
		{
			return player.controllers.maps.mapEnabler.ruleSets.First((ControllerMapEnabler.RuleSet x) => x.enabled).tag;
		}

		public static bool SwitchRuleWithTag(this Rewired.Player player, string newTag)
		{
			ControllerMapEnabler mapEnabler = player.controllers.maps.mapEnabler;
			bool flag = ChangeRuleSet(newTag, mapEnabler.ruleSets, mapEnabler);
			Debug.Log($"<color=white><b>[Input]</b></color> Switching tag to {newTag}, any rule change: {flag}");
			return flag;
		}

		private static bool ChangeRuleSet(string newTag, IEnumerable<ControllerMapEnabler.RuleSet> mapEnablerRuleSets, ControllerMapEnabler mapEnabler)
		{
			bool result = false;
			foreach (ControllerMapEnabler.RuleSet mapEnablerRuleSet in mapEnablerRuleSets)
			{
				bool flag = mapEnablerRuleSet.tag == newTag;
				if (mapEnablerRuleSet.enabled != flag)
				{
					mapEnablerRuleSet.enabled = flag;
					result = true;
				}
			}
			mapEnabler.Apply();
			return result;
		}

		public static void ResetToDefaults(this Rewired.Player player, ControllerType controllerType)
		{
			string newTag = player.CurrentTag();
			player.controllers.maps.LoadDefaultMaps(controllerType);
			player.SwitchRuleWithTag(newTag);
		}

		public static IEnumerable<ValueDropdownItem<int>> GetAllCategories()
		{
			return GetAllActionsInClass(typeof(Category));
		}

		public static IEnumerable<ValueDropdownItem<int>> GetAllActions()
		{
			return GetAllActionsInClass(typeof(RewiredConsts.Action));
		}

		private static IEnumerable<ValueDropdownItem<int>> GetAllActionsInClass(Type type)
		{
			FieldInfo[] fields = type.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
			foreach (FieldInfo fieldInfo in fields)
			{
				if (!(fieldInfo.FieldType != typeof(int)))
				{
					if (fieldInfo.GetCustomAttribute(typeof(ActionIdFieldInfoAttribute)) is ActionIdFieldInfoAttribute actionIdFieldInfoAttribute)
					{
						yield return new ValueDropdownItem<int>(actionIdFieldInfoAttribute.categoryName + "/" + actionIdFieldInfoAttribute.friendlyName, (int)fieldInfo.GetRawConstantValue());
					}
					else
					{
						yield return new ValueDropdownItem<int>(fieldInfo.Name ?? "", (int)fieldInfo.GetRawConstantValue());
					}
				}
			}
			Type[] nestedTypes = type.GetNestedTypes();
			foreach (Type type2 in nestedTypes)
			{
				foreach (ValueDropdownItem<int> item in GetAllActionsInClass(type2))
				{
					yield return item;
				}
			}
		}
	}
}
