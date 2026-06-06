using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations
{
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/scriptable-architecture/mlocal-variables")]
	[AddComponentMenu("Malbers/Runtime Vars/Local Variables")]
	public class MLocalVars : MonoBehaviour
	{
		public (string name, object value) list;

		public List<LocalVar> variables = new List<LocalVar>();

		public Dictionary<string, object> vars;

		private (string name, int index) PinVar;

		public void Start()
		{
			vars = new Dictionary<string, object>();
			foreach (LocalVar variable in variables)
			{
				vars.Add(variable.name, variable.GetValue());
			}
			PinVar.name = string.Empty;
			PinVar.index = -1;
		}

		public void SetVar(LocalVar newvar)
		{
			object value = newvar.GetValue();
			if (vars.ContainsKey(newvar.name))
			{
				vars[base.name] = value;
				return;
			}
			vars.Add(newvar.name, value);
			Debug.Log("Variable " + newvar.name + " Added to the Local Vars");
		}

		public void SetVar<T>(string name, T value)
		{
			if (vars.ContainsKey(name))
			{
				vars[name] = value;
			}
			else
			{
				vars.Add(name, value);
			}
		}

		public T GetVar<T>(string name)
		{
			Pin_Var(name);
			if (PinVar.index == -1)
			{
				return default(T);
			}
			return vars.Get<T>(name);
		}

		public virtual bool HasVar(string name)
		{
			return vars.ContainsKey(name);
		}

		public virtual bool HasVar(LocalVar var)
		{
			return vars.ContainsKey(var.name);
		}

		public void Pin_Var(string name)
		{
			if (vars.ContainsKey(name))
			{
				PinVar.name = name;
				PinVar.index = variables.FindIndex((LocalVar x) => x.name == name);
				return;
			}
			Debug.LogWarning("[" + base.transform.name + "] - [Local Variables]  does not contain the var <" + name + ">", this);
			PinVar.name = string.Empty;
			PinVar.index = -1;
		}

		public void SetTrue(string name)
		{
			Var_Set_True(name);
		}

		public void Var_Set_True(string name)
		{
			Pin_Var(name);
			if (!string.IsNullOrEmpty(PinVar.name))
			{
				SetVar(name, value: true);
			}
		}

		public void SetFalse(string name)
		{
			Var_Set_True(name);
		}

		public void Var_Set_False(string name)
		{
			Pin_Var(name);
			if (!string.IsNullOrEmpty(PinVar.name))
			{
				SetVar(name, value: false);
			}
		}

		public virtual void Pin_SetValue(int value)
		{
			if (!string.IsNullOrEmpty(PinVar.name))
			{
				vars[PinVar.name] = value;
				if (PinVar.index != -1)
				{
					variables[PinVar.index].intValue = value;
				}
			}
		}

		public virtual void Pin_SetValue(float value)
		{
			if (!string.IsNullOrEmpty(PinVar.name))
			{
				vars[PinVar.name] = value;
				if (PinVar.index != -1)
				{
					variables[PinVar.index].floatValue = value;
				}
			}
		}

		public virtual void Pin_SetValue(bool value)
		{
			if (!string.IsNullOrEmpty(PinVar.name))
			{
				vars[PinVar.name] = value;
				if (PinVar.index != -1)
				{
					variables[PinVar.index].boolValue = value;
				}
			}
		}

		public virtual void Pin_SetValue(string value)
		{
			if (!string.IsNullOrEmpty(PinVar.name))
			{
				vars[PinVar.name] = value;
				if (PinVar.index != -1)
				{
					variables[PinVar.index].stringValue = value;
				}
			}
		}

		public virtual void Pin_SetValue(Vector2 value)
		{
			if (!string.IsNullOrEmpty(PinVar.name))
			{
				vars[PinVar.name] = value;
				if (PinVar.index != -1)
				{
					variables[PinVar.index].vector2Value = value;
				}
			}
		}

		public virtual void Pin_SetValue(Vector3 value)
		{
			if (!string.IsNullOrEmpty(PinVar.name))
			{
				vars[PinVar.name] = value;
				if (PinVar.index != -1)
				{
					variables[PinVar.index].vector3Value = value;
				}
			}
		}

		public virtual void Pin_SetValue(GameObject value)
		{
			if (!string.IsNullOrEmpty(PinVar.name))
			{
				vars[PinVar.name] = value;
				if (PinVar.index != -1)
				{
					variables[PinVar.index].gameObjectValue.Value = value;
				}
			}
		}

		public virtual void Pin_SetValue(Transform value)
		{
			if (!string.IsNullOrEmpty(PinVar.name))
			{
				vars[PinVar.name] = value;
				if (PinVar.index != -1)
				{
					variables[PinVar.index].transformValue.Value = value;
				}
			}
		}

		public virtual void Pin_SetValue(Material value)
		{
			if (!string.IsNullOrEmpty(PinVar.name))
			{
				vars[PinVar.name] = value;
				if (PinVar.index != -1)
				{
					variables[PinVar.index].materialValue = value;
				}
			}
		}

		public virtual void Pin_SetValue(Object value)
		{
			if (!string.IsNullOrEmpty(PinVar.name))
			{
				vars[PinVar.name] = value;
				if (PinVar.index != -1)
				{
					variables[PinVar.index].objectValue = value;
				}
			}
		}

		public bool Compare(LocalVar value, ComparerInt compare = ComparerInt.Equal)
		{
			switch (value.type)
			{
			case LocalVar.VarType.Int:
			{
				int var9 = GetVar<int>(value.name);
				return value.intValue.CompareInt(var9, compare);
			}
			case LocalVar.VarType.Float:
			{
				float var8 = GetVar<float>(value.name);
				return value.floatValue.CompareFloat(var8, compare);
			}
			case LocalVar.VarType.Bool:
			{
				bool var7 = GetVar<bool>(value.name);
				return value.boolValue == var7;
			}
			case LocalVar.VarType.String:
			{
				string var6 = GetVar<string>(value.name);
				return value.stringValue == var6;
			}
			case LocalVar.VarType.Vector3:
			{
				Vector3 var5 = GetVar<Vector3>(value.name);
				return value.vector3Value == var5;
			}
			case LocalVar.VarType.Vector2:
			{
				Vector2 var4 = GetVar<Vector2>(value.name);
				return value.vector2Value == var4;
			}
			case LocalVar.VarType.GameObject:
			{
				GameObject var3 = GetVar<GameObject>(value.name);
				return value.gameObjectValue.Value == var3;
			}
			case LocalVar.VarType.Transform:
				return GetVar<Transform>(value.name) == value.transformValue.Value;
			case LocalVar.VarType.Material:
			{
				Material var2 = GetVar<Material>(value.name);
				return value.materialValue == var2;
			}
			case LocalVar.VarType.UnityObject:
			{
				Object var = GetVar<Object>(value.name);
				return value.objectValue == var;
			}
			default:
				return false;
			}
		}
	}
}
