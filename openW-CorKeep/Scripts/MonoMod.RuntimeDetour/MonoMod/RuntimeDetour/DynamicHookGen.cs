using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using MonoMod.Cil;
using MonoMod.RuntimeDetour.HookGen;
using MonoMod.Utils;

namespace MonoMod.RuntimeDetour
{
	public sealed class DynamicHookGen : DynamicObject
	{
		private enum ActionType
		{
			Add = 0,
			Remove = 1
		}

		public enum HookType
		{
			OnOrIL = 0,
			On = 1,
			IL = 2
		}

		private DynamicHookGen Parent;

		private string Name;

		private Type Type;

		private HookType NodeHookType;

		public static dynamic On = new DynamicHookGen(HookType.On);

		public static dynamic IL = new DynamicHookGen(HookType.IL);

		public static dynamic OnOrIL = new DynamicHookGen(HookType.OnOrIL);

		private int OwnLendID;

		private int NextLendID;

		private List<Tuple<ActionType, Delegate>> Actions = new List<Tuple<ActionType, Delegate>>();

		private string Path
		{
			get
			{
				if (Parent?.Name == null)
				{
					return Name;
				}
				List<string> list = new List<string>();
				DynamicHookGen dynamicHookGen = this;
				while (dynamicHookGen != null && dynamicHookGen.Name != null)
				{
					list.Add(dynamicHookGen.Name);
					dynamicHookGen = dynamicHookGen.Parent;
				}
				list.Reverse();
				return string.Join(".", list);
			}
		}

		private DynamicHookGen(HookType hookType)
		{
			NodeHookType = hookType;
		}

		private DynamicHookGen(DynamicHookGen parent, string name)
		{
			Parent = parent;
			Name = name;
			NodeHookType = parent.NodeHookType;
			OwnLendID = parent.NextLendID++;
		}

		private DynamicHookGen(DynamicHookGen source)
		{
			Parent = source.Parent;
			Name = source.Name;
			NodeHookType = source.NodeHookType;
			OwnLendID = source.OwnLendID;
			Actions.AddRange(source.Actions);
		}

		public DynamicHookGen(Type type)
			: this(type, HookType.OnOrIL)
		{
		}

		public DynamicHookGen(Type type, HookType hookType)
		{
			Name = type.FullName;
			Type = type;
			NodeHookType = hookType;
		}

		private void Apply()
		{
			string path = Parent.Path;
			Type type = Parent.Type ?? ReflectionHelper.GetType(path);
			if (type == null)
			{
				throw new ArgumentException("Couldn't find type " + path);
			}
			MethodBase methodBase = null;
			methodBase = ((!(Name == "ctor")) ? ((MethodBase)type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).FirstOrDefault((MethodInfo m) => m.Name == Name)) : ((MethodBase)type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).FirstOrDefault()));
			if (methodBase == null)
			{
				throw new ArgumentException("Couldn't find method " + path + "::" + Name);
			}
			foreach (Tuple<ActionType, Delegate> action in Actions)
			{
				Delegate item = action.Item2;
				HookType hookType = NodeHookType;
				if (hookType == HookType.OnOrIL)
				{
					MethodInfo method = item.GetType().GetMethod("Invoke");
					ParameterInfo[] parameters = method.GetParameters();
					hookType = ((!(method.ReturnType == typeof(void)) || parameters.Length != 1 || !parameters[0].ParameterType.IsCompatible(typeof(ILContext)) || parameters[0].IsOut) ? HookType.On : HookType.IL);
				}
				switch (action.Item1)
				{
				case ActionType.Add:
					if (hookType == HookType.IL)
					{
						HookEndpointManager.Modify(methodBase, item);
					}
					else
					{
						HookEndpointManager.Add(methodBase, item);
					}
					break;
				case ActionType.Remove:
					if (hookType == HookType.IL)
					{
						HookEndpointManager.Unmodify(methodBase, item);
					}
					else
					{
						HookEndpointManager.Remove(methodBase, item);
					}
					break;
				}
			}
			Actions.Clear();
		}

		public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
		{
			if (args.Length != 1 || !(args[0] is Type type))
			{
				throw new ArgumentException("Expected type.");
			}
			result = new DynamicHookGen(type, NodeHookType);
			return true;
		}

		public override bool TryGetMember(GetMemberBinder binder, out object result)
		{
			result = new DynamicHookGen(this, binder.Name);
			return true;
		}

		public override bool TrySetMember(SetMemberBinder binder, object value)
		{
			DynamicHookGen obj = (value as DynamicHookGen) ?? throw new ArgumentException("Incompatible dynamic hooks type. Did you use += / -= properly?");
			if (obj.Parent != this)
			{
				throw new ArgumentException("Dynamic hooks target parent not matching.");
			}
			if (obj.Name != binder.Name)
			{
				throw new ArgumentException("Dynamic hooks target name not matching.");
			}
			if (obj.OwnLendID != NextLendID++ - 1)
			{
				throw new ArgumentException("Dynamic hooks object expired.");
			}
			obj.Apply();
			return true;
		}

		public static DynamicHookGen operator +(DynamicHookGen ctx, Delegate target)
		{
			ctx = new DynamicHookGen(ctx);
			ctx.Actions.Add(new Tuple<ActionType, Delegate>(ActionType.Add, target));
			return ctx;
		}

		public static DynamicHookGen operator -(DynamicHookGen ctx, Delegate target)
		{
			ctx = new DynamicHookGen(ctx);
			ctx.Actions.Add(new Tuple<ActionType, Delegate>(ActionType.Remove, target));
			return ctx;
		}
	}
}
