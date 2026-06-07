using System;
using CLanguage.Compiler;
using CLanguage.Syntax;

namespace CLanguage.Types
{
	public abstract class CType
	{
		public static readonly CVoidType Void;

		private readonly Lazy<CPointerType> pointer;

		public TypeQualifiers TypeQualifiers { get; set; }

		public abstract int NumValues { get; }

		public virtual bool IsIntegral => false;

		public virtual bool IsVoid => false;

		public CPointerType Pointer => null;

		public abstract int GetByteSize(EmitContext c);

		public CType()
		{
		}

		protected virtual CPointerType CreatePointerType()
		{
			return null;
		}

		public virtual int ScoreCastTo(CType otherType)
		{
			return 0;
		}

		public virtual object GetClrValue(Value[] values, MachineInfo machineInfo)
		{
			return null;
		}
	}
}
