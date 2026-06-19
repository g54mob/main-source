using System.Linq;
using System.Reflection;

namespace SickDev.CommandSystem
{
	public class Signature
	{
		private CommandBase command;

		private string _raw;

		private static ArgumentsParser _parser;

		public ParameterInfo[] parameters { get; private set; }

		public string raw
		{
			get
			{
				if (_raw == null)
				{
					_raw = SignatureBuilder.Build(command.method.Method, command.name);
				}
				return _raw;
			}
		}

		private static ArgumentsParser parser
		{
			get
			{
				if (_parser == null)
				{
					_parser = new ArgumentsParser();
				}
				return _parser;
			}
		}

		internal Signature(CommandBase command)
		{
			this.command = command;
			parameters = command.method.Method.GetParameters();
		}

		internal bool Matches(string[] args)
		{
			return args.Length == parameters.Length || args.Length == parameters.Count((ParameterInfo x) => !x.IsOptional);
		}

		internal object[] Convert(string[] args)
		{
			return GetArguments(args);
		}

		private object[] GetArguments(string[] args)
		{
			object[] array = new object[parameters.Length];
			for (int i = 0; i < array.Length; i++)
			{
				if (args.Length > i)
				{
					array[i] = parser.Parse(args[i], parameters[i].ParameterType);
				}
				else
				{
					array[i] = parameters[i].DefaultValue;
				}
			}
			return array;
		}
	}
}
