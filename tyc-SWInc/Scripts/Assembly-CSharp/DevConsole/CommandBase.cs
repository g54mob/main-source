using System;
using System.Collections.Generic;

namespace DevConsole
{
	[Serializable]
	public abstract class CommandBase
	{
		public delegate void HelpMethod();

		public bool Hide;

		public bool AvailableOnline = true;

		public Func<string[], IEnumerable<string>>[] ParamHelp;

		private HelpMethod helpMethod;

		private Delegate method;

		public static Dictionary<string, string> TypeAlias = new Dictionary<string, string>
		{
			{ "Single", "Decimal number" },
			{ "String", "Text" },
			{ "Int32", "Whole number" },
			{ "Boolean", "Y/N" }
		};

		public string name { get; private set; }

		public string helpText { get; private set; }

		public bool CanExecuteOnline()
		{
			if (!AvailableOnline && !GameSettings.Instance.IsReferenceNull())
			{
				return GameSettings.Instance.NetworkData == null;
			}
			return true;
		}

		public bool ShouldHide()
		{
			if (Hide)
			{
				return true;
			}
			if (!CanExecuteOnline())
			{
				return true;
			}
			return false;
		}

		public CommandBase(string name, Delegate method, Func<string[], IEnumerable<string>>[] pHelp)
		{
			this.name = name;
			this.method = method;
			ParamHelp = pHelp;
		}

		public CommandBase(string name, Delegate method, string helpText, Func<string[], IEnumerable<string>>[] pHelp)
			: this(name, method, null)
		{
			this.helpText = helpText;
			ParamHelp = pHelp;
		}

		public CommandBase(string name, Delegate method, HelpMethod helpMethod, Func<string[], IEnumerable<string>>[] pHelp)
			: this(name, method, null)
		{
			this.helpMethod = helpMethod;
			ParamHelp = pHelp;
		}

		public CommandBase(Delegate method)
			: this(method.Method.DeclaringType.Name + "." + method.Method.Name, method, null)
		{
		}

		public CommandBase(Delegate method, string helpText)
			: this(method.Method.DeclaringType.Name + "." + method.Method.Name, method, helpText, null)
		{
		}

		public CommandBase(Delegate method, HelpMethod helpMethod)
			: this(method.Method.DeclaringType.Name + "." + method.Method.Name, method, helpMethod, null)
		{
		}

		public void Execute(string args)
		{
			try
			{
				method.Method.Invoke(method.Target, ParseArguments(args));
			}
			catch (Exception innerException)
			{
				if (innerException is ArgumentException)
				{
					Console.LogError("Expected: " + ArgumentList());
					return;
				}
				int num = 0;
				while (innerException.InnerException != null && num < 50)
				{
					innerException = innerException.InnerException;
					num++;
				}
				Console.LogError(innerException.Message + (Console.verbose ? ("\n" + innerException.StackTrace) : string.Empty));
			}
		}

		protected abstract object[] ParseArguments(string args);

		protected abstract string ArgumentList();

		public virtual void ShowHelp()
		{
			if (helpMethod != null)
			{
				helpMethod();
			}
			else
			{
				Console.LogInfo("Command Info: " + (helpText ?? "There's no help for this command"));
			}
		}

		protected T GetValueType<T>(string arg)
		{
			Type typeFromHandle = typeof(T);
			try
			{
				if (typeof(bool) == typeFromHandle)
				{
					bool result;
					if (StringToBool(arg, out result))
					{
						return (T)(object)result;
					}
					throw new ArgumentException("The entered value is not a valid");
				}
				return (T)Convert.ChangeType(arg, typeFromHandle);
			}
			catch
			{
				throw new ArgumentException("The entered value is not a valid");
			}
		}

		protected bool StringToBool(string value, out bool result)
		{
			result = false;
			switch (value.ToLower().Trim())
			{
			case "true":
			case "yes":
			case "y":
			case "1":
				result = true;
				break;
			case "false":
			case "no":
			case "n":
			case "0":
				result = false;
				break;
			default:
				return false;
			}
			return true;
		}

		public IEnumerable<string> GetParamHelp(string[] input, int param)
		{
			if (ParamHelp != null && param < ParamHelp.Length && ParamHelp[param] != null)
			{
				try
				{
					return ParamHelp[param](input);
				}
				catch (Exception)
				{
					return null;
				}
			}
			return null;
		}

		protected string GetTypeName(Type t)
		{
			return TypeAlias.GetOrDefault(t.Name, t.Name);
		}
	}
}
