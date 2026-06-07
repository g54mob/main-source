using System;
using System.Collections.Generic;
using System.Linq;

namespace MoonSharp.Interpreter.CoreLib.IO
{
	internal abstract class FileUserDataBase : RefIdObject
	{
		public DynValue lines(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			List<DynValue> list = new List<DynValue>();
			DynValue dynValue = null;
			do
			{
				dynValue = read(executionContext, args);
				list.Add(dynValue);
			}
			while (dynValue.IsNotNil());
			return DynValue.FromObject(executionContext.GetScript(), list.Select((DynValue s) => s));
		}

		public DynValue read(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			if (args.Count == 0)
			{
				string text = ReadLine();
				if (text == null)
				{
					return DynValue.Nil;
				}
				text = text.TrimEnd('\n', '\r');
				return DynValue.NewString(text);
			}
			List<DynValue> list = new List<DynValue>();
			for (int i = 0; i < args.Count; i++)
			{
				DynValue item;
				if (args[i].Type == DataType.Number)
				{
					if (Eof())
					{
						return DynValue.Nil;
					}
					int p = (int)args[i].Number;
					string str = ReadBuffer(p);
					item = DynValue.NewString(str);
				}
				else
				{
					string text2 = args.AsType(i, "read", DataType.String).String;
					if (Eof())
					{
						item = (text2.StartsWith("*a") ? DynValue.NewString("") : DynValue.Nil);
					}
					else if (text2.StartsWith("*n"))
					{
						double? num = ReadNumber();
						item = ((!num.HasValue) ? DynValue.Nil : DynValue.NewNumber(num.Value));
					}
					else if (text2.StartsWith("*a"))
					{
						string str2 = ReadToEnd();
						item = DynValue.NewString(str2);
					}
					else if (text2.StartsWith("*l"))
					{
						string text3 = ReadLine();
						text3 = text3.TrimEnd('\n', '\r');
						item = DynValue.NewString(text3);
					}
					else
					{
						if (!text2.StartsWith("*L"))
						{
							throw ScriptRuntimeException.BadArgument(i, "read", "invalid option");
						}
						string text4 = ReadLine();
						text4 = text4.TrimEnd('\n', '\r');
						text4 += "\n";
						item = DynValue.NewString(text4);
					}
				}
				list.Add(item);
			}
			return DynValue.NewTuple(list.ToArray());
		}

		public DynValue write(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			try
			{
				for (int i = 0; i < args.Count; i++)
				{
					string value = args.AsType(i, "write", DataType.String).String;
					Write(value);
				}
				return UserData.Create(this);
			}
			catch (ScriptRuntimeException)
			{
				throw;
			}
			catch (Exception ex2)
			{
				return DynValue.NewTuple(DynValue.Nil, DynValue.NewString(ex2.Message));
			}
		}

		public DynValue close(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			try
			{
				string text = Close();
				if (text == null)
				{
					return DynValue.True;
				}
				return DynValue.NewTuple(DynValue.Nil, DynValue.NewString(text));
			}
			catch (ScriptRuntimeException)
			{
				throw;
			}
			catch (Exception ex2)
			{
				return DynValue.NewTuple(DynValue.Nil, DynValue.NewString(ex2.Message));
			}
		}

		private double? ReadNumber()
		{
			string text = "";
			while (!Eof())
			{
				char c = Peek();
				if (char.IsWhiteSpace(c))
				{
					ReadBuffer(1);
					continue;
				}
				if (!IsNumericChar(c, text))
				{
					break;
				}
				ReadBuffer(1);
				text += c;
			}
			double result;
			if (double.TryParse(text, out result))
			{
				return result;
			}
			return null;
		}

		private bool IsNumericChar(char c, string numAsFar)
		{
			if (char.IsDigit(c))
			{
				return true;
			}
			switch (c)
			{
			case '-':
				return numAsFar.Length == 0;
			case '.':
				return !numAsFar.Contains('.');
			case 'E':
			case 'e':
				if (!numAsFar.Contains('E'))
				{
					return !numAsFar.Contains('e');
				}
				return false;
			default:
				return false;
			}
		}

		protected abstract bool Eof();

		protected abstract string ReadLine();

		protected abstract string ReadBuffer(int p);

		protected abstract string ReadToEnd();

		protected abstract char Peek();

		protected abstract void Write(string value);

		protected internal abstract bool isopen();

		protected abstract string Close();

		public abstract bool flush();

		public abstract long seek(string whence, long offset);

		public abstract bool setvbuf(string mode);

		public override string ToString()
		{
			if (isopen())
			{
				return string.Format("file ({0:X8})", base.ReferenceID);
			}
			return "file (closed)";
		}
	}
}
