using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SaintsField.Interfaces;
using SaintsField.Playa;
using SaintsField.SaintsXPathParser.Optimization;
using SaintsField.Utils;
using UnityEngine;

namespace SaintsField
{
	[Conditional("UNITY_EDITOR")]
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
	public class GetByXPathAttribute : PropertyAttribute, ISaintsAttribute, IPlayaAttribute, IPlayaArraySizeAttribute
	{
		public struct XPathInfo
		{
			public bool IsCallback;

			public string Callback;
		}

		public bool InitSign;

		public bool AutoResignToValue;

		public bool AutoResignToNull;

		public bool UseResignButton;

		public bool UsePickerButton;

		public bool UseErrorMessage;

		public bool KeepOriginalPicker;

		public bool ForceReOrder;

		public IReadOnlyList<IReadOnlyList<XPathInfo>> XPathInfoAndList;

		public SaintsAttributeType AttributeType => SaintsAttributeType.Other;

		public virtual string GroupBy => "";

		public OptimizationPayload OptimizationPayload { get; protected set; }

		protected void ParseOptions(EXP config)
		{
			InitSign = !config.HasFlagFast(EXP.NoInitSign);
			UsePickerButton = !config.HasFlagFast(EXP.NoPicker);
			KeepOriginalPicker = !UsePickerButton || config.HasFlagFast(EXP.KeepOriginalPicker);
			AutoResignToValue = !config.HasFlagFast(EXP.NoAutoResignToValue);
			AutoResignToNull = !config.HasFlagFast(EXP.NoAutoResignToNull);
			if (AutoResignToValue && AutoResignToNull)
			{
				UseResignButton = false;
			}
			else
			{
				UseResignButton = !config.HasFlagFast(EXP.NoResignButton);
			}
			if (config.HasFlagFast(EXP.NoMessage))
			{
				UseErrorMessage = false;
			}
			else
			{
				UseErrorMessage = !UseResignButton;
			}
			ForceReOrder = config.HasFlagFast(EXP.ForceReOrder);
		}

		public GetByXPathAttribute(EXP config, params string[] ePaths)
		{
			ParseOptions(config);
			ParseXPaths(ePaths);
		}

		protected void ParseXPaths(params string[] ePaths)
		{
			XPathInfo[] array = ((ePaths.Length != 0) ? ePaths.Select(delegate(string ePath)
			{
				var (callback, isCallback) = RuntimeUtil.ParseCallback(ePath);
				return new XPathInfo
				{
					IsCallback = isCallback,
					Callback = callback
				};
			}).ToArray() : new XPathInfo[1]
			{
				new XPathInfo
				{
					IsCallback = false,
					Callback = ""
				}
			});
			XPathInfoAndList = new XPathInfo[1][] { array };
		}

		public GetByXPathAttribute(params string[] ePaths)
			: this(SaintsFieldConfigUtil.GetByXPathExp(EXP.None), ePaths)
		{
		}

		protected static string GetComponentFilter(Type compType)
		{
			if (compType == null)
			{
				return "";
			}
			string text = compType.Namespace;
			string name = compType.Name;
			return "[@{GetComponents(" + text + "." + name + ")}]";
		}
	}
}
