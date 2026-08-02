namespace MoonSharp.Interpreter.CoreLib.IO
{
	internal abstract class FileUserDataBase : RefIdObject
	{
		public DynValue lines(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		public DynValue read(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		public DynValue write(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		public DynValue close(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		private double? ReadNumber()
		{
			return null;
		}

		private bool IsNumericChar(char c, string numAsFar)
		{
			return false;
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
			return null;
		}
	}
}
