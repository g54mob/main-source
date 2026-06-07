using System;
using System.Collections.Generic;
using R3;
using UnityEngine;
using UnityEngine.Pool;
using ZLinq;
using ZLinq.Linq;

public class DatabaseModifiers : IDisposable
{
	private readonly Dictionary<ModifierType, double> _defaultBaseValues = new Dictionary<ModifierType, double>();

	private readonly Dictionary<ModifierType, (ModifierFormat, int)> _defaultBaseFormat = new Dictionary<ModifierType, (ModifierFormat, int)>();

	private readonly Dictionary<ModifierType, List<ModifierEntry>> _entriesByType = new Dictionary<ModifierType, List<ModifierEntry>>(256);

	private readonly Dictionary<ModifierSourceId, List<ModifierType>> _typesBySource = new Dictionary<ModifierSourceId, List<ModifierType>>(256);

	private readonly Dictionary<ModifierType, ReactiveProperty<double>> _valuesByType = new Dictionary<ModifierType, ReactiveProperty<double>>(256);

	private readonly HashSet<ModifierType> _dirtyTypes = new HashSet<ModifierType>();

	public DatabaseModifiers()
	{
		LoadDefaultValues();
		InitializeReactiveOutputs();
		RefreshFull();
	}

	public void Dispose()
	{
		foreach (ReactiveProperty<double> value in _valuesByType.Values)
		{
			value.Dispose();
		}
		_entriesByType.Clear();
		_typesBySource.Clear();
		_valuesByType.Clear();
		_dirtyTypes.Clear();
	}

	public void AddSource(ModifierSourceId source, IReadOnlyList<Modifier> modifiers, bool recompute = true)
	{
		if (modifiers == null || modifiers.Count == 0)
		{
			return;
		}
		if (_typesBySource.ContainsKey(source))
		{
			RemoveSource(source);
		}
		List<ModifierType> list = new List<ModifierType>(modifiers.Count);
		foreach (Modifier modifier in modifiers)
		{
			ModifierType type = modifier.type;
			if (!_entriesByType.TryGetValue(type, out var value))
			{
				value = new List<ModifierEntry>(4);
				_entriesByType[type] = value;
			}
			value.Add(new ModifierEntry(modifier, source));
			list.Add(type);
			_dirtyTypes.Add(type);
		}
		_typesBySource[source] = list;
		if (recompute)
		{
			RecomputeDirty();
		}
	}

	public void RemoveSource(ModifierSourceId source, bool recompute = true)
	{
		if (!_typesBySource.TryGetValue(source, out var value))
		{
			return;
		}
		foreach (ModifierType item in value)
		{
			if (!_entriesByType.TryGetValue(item, out var value2))
			{
				continue;
			}
			for (int num = value2.Count - 1; num >= 0; num--)
			{
				if (value2[num].SourceId.Equals(source))
				{
					value2.RemoveAt(num);
				}
			}
			_dirtyTypes.Add(item);
		}
		_typesBySource.Remove(source);
		if (recompute)
		{
			RecomputeDirty();
		}
	}

	public void RefreshFull()
	{
		_entriesByType.Clear();
		_typesBySource.Clear();
		_dirtyTypes.Clear();
		using (ValueEnumerator<Select<FromEnumerable<ResearchNode>, ResearchNode, ResearchNodeData>, ResearchNodeData> valueEnumerator = (from r in Database.State.Research.Unlocked.AsValueEnumerable()
			select r.Data()).GetEnumerator<Select<FromEnumerable<ResearchNode>, ResearchNode, ResearchNodeData>, ResearchNodeData>())
		{
			while (valueEnumerator.MoveNext())
			{
				ResearchNodeData current = valueEnumerator.Current;
				AddSource(new ModifierSourceId(ModifierSourceType.Research, (int)current.ID), current.modifiers, recompute: false);
			}
		}
		using (ValueEnumerator<Select<FromEnumerable<UpgradeNode>, UpgradeNode, UpgradeNodeData>, UpgradeNodeData> valueEnumerator2 = (from u in Database.State.Upgrades.Unlocked.AsValueEnumerable()
			select u.Data()).GetEnumerator<Select<FromEnumerable<UpgradeNode>, UpgradeNode, UpgradeNodeData>, UpgradeNodeData>())
		{
			while (valueEnumerator2.MoveNext())
			{
				UpgradeNodeData current2 = valueEnumerator2.Current;
				AddSource(new ModifierSourceId(ModifierSourceType.Upgrade, (int)current2.ID), current2.modifiers, recompute: false);
			}
		}
		RecomputeFull();
	}

	public Observable<double> Observe(ModifierType type)
	{
		if (!_valuesByType.TryGetValue(type, out var value))
		{
			value = new ReactiveProperty<double>(GetDefaultBase(type));
			_valuesByType[type] = value;
		}
		return value;
	}

	public Observable<float> ObserveAsFloat(ModifierType type)
	{
		return Observe(type).AsFloat();
	}

	public Observable<int> ObserveAsInt(ModifierType type)
	{
		return Observe(type).AsInt();
	}

	public Observable<Unit> ObserveMultiple(params ModifierType[] type)
	{
		return from _ in type.AsValueEnumerable().Select(Observe).AsEnumerable()
				.Merge()
			select Unit.Default;
	}

	public double GetDouble(ModifierType type)
	{
		if (_valuesByType.TryGetValue(type, out var value))
		{
			return value.Value;
		}
		return EvaluateDouble(type, GetDefaultBase(type));
	}

	public float GetFloat(ModifierType type)
	{
		return (float)GetDouble(type);
	}

	public int GetInt(ModifierType type)
	{
		return (int)Math.Round(GetDouble(type), MidpointRounding.AwayFromZero);
	}

	public double EvaluateDouble(ModifierType type, double baseValue)
	{
		if (!_entriesByType.TryGetValue(type, out var value) || value.Count == 0)
		{
			return baseValue;
		}
		return ApplyDeterministic(value, baseValue);
	}

	public float EvaluateFloat(ModifierType type, float baseValue)
	{
		return (float)EvaluateDouble(type, baseValue);
	}

	public int EvaluateInt(ModifierType type, int baseValue)
	{
		return (int)Math.Round(EvaluateDouble(type, baseValue), MidpointRounding.AwayFromZero);
	}

	public (ModifierFormat format, int digits) GetFormatting(ModifierType type)
	{
		return _defaultBaseFormat.GetValueOrDefault(type, (ModifierFormat.Flat, 0));
	}

	public IReadOnlyList<ModifierEntry> GetContributors(ModifierType type)
	{
		if (_entriesByType.TryGetValue(type, out var value))
		{
			return value;
		}
		return Array.Empty<ModifierEntry>();
	}

	private void LoadDefaultValues()
	{
		ModifierDefaults modifierDefaults = Resources.Load<ModifierDefaults>("ModifierDefaults");
		if (!modifierDefaults)
		{
			Debug.LogError("ModifierDefaults asset not found at Resources/ModifierDefaults");
			return;
		}
		foreach (ModifierDefaults.Entry @default in modifierDefaults.defaults)
		{
			_defaultBaseValues[@default.modifier] = @default.value;
			_defaultBaseFormat[@default.modifier] = (@default.format, @default.digits);
		}
		Resources.UnloadAsset(modifierDefaults);
	}

	private void InitializeReactiveOutputs()
	{
		foreach (KeyValuePair<ModifierType, double> defaultBaseValue in _defaultBaseValues)
		{
			_valuesByType[defaultBaseValue.Key] = new ReactiveProperty<double>(defaultBaseValue.Value);
		}
	}

	private double GetDefaultBase(ModifierType type)
	{
		return _defaultBaseValues.GetValueOrDefault(type, 0.0);
	}

	private void RecomputeFull()
	{
		foreach (ModifierType key in _defaultBaseValues.Keys)
		{
			_dirtyTypes.Add(key);
		}
		foreach (ModifierType key2 in _entriesByType.Keys)
		{
			_dirtyTypes.Add(key2);
		}
		RecomputeDirty();
	}

	private void RecomputeDirty()
	{
		if (_dirtyTypes.Count == 0)
		{
			return;
		}
		foreach (ModifierType dirtyType in _dirtyTypes)
		{
			double defaultBase = GetDefaultBase(dirtyType);
			List<ModifierEntry> value;
			double num = ((_entriesByType.TryGetValue(dirtyType, out value) && value.Count > 0) ? ApplyDeterministic(value, defaultBase) : defaultBase);
			if (!_valuesByType.TryGetValue(dirtyType, out var value2))
			{
				value2 = new ReactiveProperty<double>(num);
				_valuesByType[dirtyType] = value2;
			}
			else if (Math.Abs(value2.Value - num) > 1E-07)
			{
				value2.Value = num;
			}
		}
		_dirtyTypes.Clear();
	}

	private static double ApplyDeterministic(List<ModifierEntry> entries, double baseValue)
	{
		List<ModifierEntry> list = CollectionPool<List<ModifierEntry>, ModifierEntry>.Get();
		try
		{
			foreach (ModifierEntry entry in entries)
			{
				list.Add(entry);
			}
			list.Sort(delegate(ModifierEntry a, ModifierEntry b)
			{
				int calculation = (int)a.Modifier.calculation;
				int calculation2 = (int)b.Modifier.calculation;
				if (calculation != calculation2)
				{
					return calculation.CompareTo(calculation2);
				}
				int num4 = a.SourceId.Id.CompareTo(b.SourceId.Id);
				return (num4 == 0) ? a.Modifier.GetHashCode().CompareTo(b.Modifier.GetHashCode()) : num4;
			});
			double num = baseValue;
			for (int num2 = 0; num2 < list.Count; num2++)
			{
				Modifier modifier = list[num2].Modifier;
				if (modifier.calculation == CalculationType.Addition)
				{
					num = modifier.Handle(num);
				}
			}
			for (int num3 = 0; num3 < list.Count; num3++)
			{
				Modifier modifier2 = list[num3].Modifier;
				if (modifier2.calculation == CalculationType.Multiplication)
				{
					num = modifier2.Handle(num);
				}
			}
			return num;
		}
		finally
		{
			CollectionPool<List<ModifierEntry>, ModifierEntry>.Release(list);
		}
	}

	public (double Current, double Preview) PreviewDeterministic(Modifier modifier)
	{
		ModifierType type = modifier.type;
		double defaultBase = GetDefaultBase(type);
		List<ModifierEntry> list = CollectionPool<List<ModifierEntry>, ModifierEntry>.Get();
		try
		{
			if (_entriesByType.TryGetValue(type, out var value) && value.Count > 0)
			{
				foreach (ModifierEntry item3 in value)
				{
					list.Add(item3);
				}
			}
			double item = ((list.Count == 0) ? defaultBase : ApplyDeterministic(list, defaultBase));
			list.Add(new ModifierEntry(modifier, default(ModifierSourceId)));
			double item2 = ApplyDeterministic(list, defaultBase);
			return (Current: item, Preview: item2);
		}
		finally
		{
			CollectionPool<List<ModifierEntry>, ModifierEntry>.Release(list);
		}
	}

	public void RefetchAllModifiers()
	{
	}
}
