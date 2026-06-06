using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Text;
using UnityEngine.Localization;
using UnityEngine.Localization.SmartFormat.Core.Extensions;
using UnityEngine.Localization.SmartFormat.PersistentVariables;
using ZLinq;

[Serializable]
public class LocalizedModifierList : IVariable
{
	public OperationData operation;

	public List<Modifier> modifiers;

	public bool previewChange;

	public LocalizedModifierList()
	{
		modifiers = new List<Modifier>();
	}

	public LocalizedModifierList(UpgradeNodeData upgrade, bool preview)
		: this(upgrade.operation, upgrade.modifiers, preview)
	{
	}

	public LocalizedModifierList(ResearchNodeData research, bool preview)
		: this(research.operation, research.modifiers, preview)
	{
	}

	public LocalizedModifierList(Operation operation, List<Modifier> modifiers, bool preview)
	{
		operation.TryGetData(out this.operation);
		this.modifiers = modifiers;
		previewChange = preview;
	}

	public object GetSourceValue(ISelectorInfo selector)
	{
		List<string> list = modifiers.AsValueEnumerable().Select(ParseModifier).Prepend(ParseOperation())
			.IsNotNullOrEmpty()
			.ToList();
		if (list.Count == 0)
		{
			list.Add(" ");
		}
		return list;
	}

	private string ParseOperation()
	{
		if (!operation)
		{
			return string.Empty;
		}
		return LocalizationUtility.Find(LocTable.General, "research_operation_unlock").GetLocalizedString(operation.TitleLocalized.GetLocalizedString());
	}

	private string ParseModifier(Modifier modifier)
	{
		if (modifier.format == ModifierFormat.Hidden)
		{
			return string.Empty;
		}
		LocalizedString localizedString = LocalizationUtility.For(modifier);
		if (localizedString.IsEmpty)
		{
			return modifier.type.ToString() ?? "";
		}
		string localizedString2 = localizedString.GetLocalizedString();
		string arg = FormatModifier(modifier.value, modifier.digits, modifier.format);
		if (modifier.hidePreview)
		{
			return ZString.Format("{0}: {1}", localizedString2, arg);
		}
		if (!previewChange)
		{
			return ZString.Format("{0}: {1} ({2})", localizedString2, arg, FormatModifier(Database.Modifiers.GetDouble(modifier.type), modifier.type));
		}
		(double, double) tuple = Database.Modifiers.PreviewDeterministic(modifier);
		return ZString.Format("{0}: {1} ({2} -> {3})", localizedString2, arg, FormatModifier(tuple.Item1, modifier.type), FormatModifier(tuple.Item2, modifier.type));
	}

	public static string FormatModifier(double value, ModifierType type)
	{
		(ModifierFormat, int) formatting = Database.Modifiers.GetFormatting(type);
		return FormatModifier(value, formatting.Item2, formatting.Item1);
	}

	public static string FormatModifier(double value, int digits, ModifierFormat format)
	{
		return format switch
		{
			ModifierFormat.Flat => ZString.Format("{0}{1}", Sign(value), Round(value, digits)), 
			ModifierFormat.FlatNoSign => ZString.Format("{0}", Round(value, digits)), 
			ModifierFormat.Multiplier => ZString.Format("x{0}", Round(value, digits)), 
			ModifierFormat.Percentage => ZString.Format("{0}{1}%", Sign(value), Round(value * 100.0, digits)), 
			ModifierFormat.Time => ZString.Format("{0}s", Round(value, digits)), 
			ModifierFormat.Rate => ZString.Format("{0}{1}/s", Sign(value), Round(value, digits)), 
			ModifierFormat.Currency => ZString.Format("<#2E8E34>${0:N0}</color>", value), 
			ModifierFormat.Hidden => string.Empty, 
			_ => throw new ArgumentOutOfRangeException("format", format, null), 
		};
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static string Sign(double value)
	{
		return string.Empty;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static double Round(double value, int digits)
	{
		return Math.Round(value, digits, MidpointRounding.AwayFromZero);
	}
}
