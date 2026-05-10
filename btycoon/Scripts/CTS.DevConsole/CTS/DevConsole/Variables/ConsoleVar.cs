using System;
using System.Collections.Generic;
using UnityEngine;

namespace CTS.DevConsole.Variables
{
	public abstract class ConsoleVar : ISerializationCallbackReceiver
	{
		internal static readonly SortedDictionary<string, CVarReference> Vars = new SortedDictionary<string, CVarReference>();

		[field: NonSerialized]
		public string ConsoleKey { get; private set; }

		public event Action OnValueChanged;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
		private static void Initialize()
		{
			Vars.Clear();
		}

		internal static void AddVariable(CVarReference varRef)
		{
			if (!varRef)
			{
				Debug.LogWarning("A CVar seems to be null");
				return;
			}
			string name = varRef.name;
			if (!string.IsNullOrEmpty(name))
			{
				ConsoleVar variable = varRef.GetVariable();
				if (variable != null)
				{
					variable.ConsoleKey = name;
					name = name.ToLowerInvariant();
					RemoveVariable(varRef);
					Vars.Add(name, varRef);
				}
			}
		}

		internal static void RemoveVariable(CVarReference var)
		{
			if ((bool)var && Vars.ContainsValue(var))
			{
				Vars.Remove(var.GetVariable().ConsoleKey.ToLowerInvariant());
			}
		}

		public static TVar GetVariable<TVar>(string key) where TVar : CVarReference
		{
			if (TryGetVariable(key, out var outVar) && outVar is TVar result)
			{
				return result;
			}
			return null;
		}

		public static bool TryGetVariable<TVar>(string key, out TVar outVar) where TVar : CVarReference
		{
			if (TryGetVariable(key, out var outVar2) && outVar2 is TVar val)
			{
				outVar = val;
				return true;
			}
			outVar = null;
			return false;
		}

		private static bool TryGetVariable(string key, out CVarReference outVar)
		{
			key = key.ToLowerInvariant();
			return Vars.TryGetValue(key, out outVar);
		}

		public void Subscribe(Action action)
		{
			OnValueChanged -= action;
			OnValueChanged += action;
		}

		public void Unsubscribe(Action action)
		{
			OnValueChanged -= action;
		}

		protected void TriggerValueChange()
		{
			this.OnValueChanged?.Invoke();
		}

		public abstract void Execute(string[] args);

		public abstract void SetDefaultValues();

		protected static bool IsStringReset(string p_s)
		{
			if (!(p_s == "reset"))
			{
				return p_s == "default";
			}
			return true;
		}

		internal abstract bool IsArgumentIndexOutOfBounds(int argIndex);

		internal abstract EValidity CheckArgumentValidity(ref DeveloperConsole.InputReport report, string arg, int selfArgIndex, int realArgIndex);

		public virtual void OnBeforeSerialize()
		{
		}

		public virtual void OnAfterDeserialize()
		{
		}
	}
}
