using System;
using UnityEngine;

namespace DG.Tweening.Timeline.Core.Plugins
{
	public class PlugDataAction : IPluginData
	{
		public readonly Action<object, bool, string, UnityEngine.Object, float, float, float, float, int> action;

		public readonly Action<object, bool, string, UnityEngine.Object, float, float, float, float, int> onCreation;

		public bool wantsTarget { get; private set; }

		public string guid { get; private set; }

		public string label { get; private set; }

		public string targetLabel { get; private set; }

		public string boolOptionLabel { get; private set; }

		public string stringOptionLabel { get; private set; }

		public string float0OptionLabel { get; private set; }

		public string float1OptionLabel { get; private set; }

		public string float2OptionLabel { get; private set; }

		public string float3OptionLabel { get; private set; }

		public string intOptionLabel { get; private set; }

		public string objOptionLabel { get; private set; }

		public DOTweenClipElement.PropertyType propertyType { get; private set; }

		public Type targetType { get; private set; }

		public Type intOptionAsEnumType { get; private set; }

		public Type objOptionType { get; private set; }

		public bool defBoolValue { get; private set; }

		public string defStringValue { get; private set; }

		public float defFloat0Value { get; private set; }

		public float defFloat1Value { get; private set; }

		public float defFloat2Value { get; private set; }

		public float defFloat3Value { get; private set; }

		public int defIntValue { get; private set; }

		public PlugDataAction(string guid, string label, Type targetType, Action<object, bool, string, UnityEngine.Object, float, float, float, float, int> action, Action<object, bool, string, UnityEngine.Object, float, float, float, float, int> onCreation = null, string targetLabel = null, bool defBoolValue = false, string boolOptionLabel = null, string defStringValue = null, string stringOptionLabel = null, float defFloat0Value = 0f, string float0OptionLabel = null, float defFloat1Value = 0f, string float1OptionLabel = null, float defFloat2Value = 0f, string float2OptionLabel = null, float defFloat3Value = 0f, string float3OptionLabel = null, int defIntValue = 0, string intOptionLabel = null, Type intOptionAsEnumType = null, Type objOptionType = null, string objOptionLabel = null)
		{
		}
	}
}
