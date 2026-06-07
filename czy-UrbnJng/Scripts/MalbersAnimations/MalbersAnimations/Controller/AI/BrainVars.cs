using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[Serializable]
	public struct BrainVars
	{
		public int intValue;

		public float floatValue;

		public bool boolValue;

		public Vector3 vector3;

		public Component[] Components;

		public MonoBehaviour mono;

		public GameObject[] gameobjects;

		public Dictionary<int, int> ints;

		public Dictionary<int, float> floats;

		public Dictionary<int, bool> bools;

		public void SetVar(int key, bool value)
		{
			bools[key] = value;
		}

		public void SetVar(int key, int value)
		{
			ints[key] = value;
		}

		public void SetVar(int key, float value)
		{
			floats[key] = value;
		}

		public bool GetBool(int key)
		{
			return bools[key];
		}

		public int GetInt(int key)
		{
			return ints[key];
		}

		public float GetFloat(int key)
		{
			return floats[key];
		}

		public bool TryGetBool(int key, out bool value)
		{
			return bools.TryGetValue(key, out value);
		}

		public bool TryGetInt(int key, out int value)
		{
			return ints.TryGetValue(key, out value);
		}

		public bool TryGetFloat(int key, out float value)
		{
			return floats.TryGetValue(key, out value);
		}

		public void AddVar(int key, bool value)
		{
			if (bools == null)
			{
				bools = new Dictionary<int, bool>();
			}
			bools.Add(key, value);
		}

		public void AddVar(int key, int value)
		{
			if (ints == null)
			{
				ints = new Dictionary<int, int>();
			}
			ints.Add(key, value);
		}

		public void AddVar(int key, float value)
		{
			if (floats == null)
			{
				floats = new Dictionary<int, float>();
			}
			floats.Add(key, value);
		}

		public void AddComponents(Component[] components)
		{
			if (Components == null || Components.Length == 0)
			{
				Components = components;
			}
			else
			{
				Components = Components.Concat(components).ToArray();
			}
		}

		public void AddComponent(Component comp)
		{
			if (Components == null || Components.Length == 0)
			{
				Components = new Component[1] { comp };
			}
			else
			{
				List<Component> list = Components.ToList();
				list.Add(comp);
				Components = list.ToArray();
			}
		}
	}
}
