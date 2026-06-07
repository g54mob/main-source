using CLanguage.Interpreter;
using CLanguage.Syntax;
using CLanguage.Types;

namespace CLanguage.Compiler
{
	public abstract class EmitContext
	{
		public EmitContext? ParentContext { get; }

		public CompiledFunction? FunctionDecl { get; private set; }

		public Report Report { get; private set; }

		public MachineInfo MachineInfo { get; private set; }

		public virtual LoopContext? Loop => null;

		protected EmitContext(EmitContext parentContext)
		{
		}

		protected EmitContext(MachineInfo machineInfo, Report report, CompiledFunction? fdecl, EmitContext? parentContext)
		{
		}

		public virtual CType ResolveTypeName(TypeName typeName)
		{
			return null;
		}

		public virtual CType ResolveTypeName(string typeName)
		{
			return null;
		}

		public ResolvedVariable ResolveVariable(VariableExpression variable, CType[]? argTypes)
		{
			return null;
		}

		public EmitContext PushLoop(CLangLabel breakLabel, CLangLabel continueLabel)
		{
			return null;
		}

		public virtual ResolvedVariable TryResolveVariable(string name, CType[]? argTypes)
		{
			return null;
		}

		public virtual ResolvedVariable ResolveMethodFunction(CStructType structType, CStructMethod method)
		{
			return null;
		}

		public virtual void BeginBlock(Block b)
		{
		}

		public virtual void EndBlock()
		{
		}

		public virtual CLangLabel DefineLabel()
		{
			return null;
		}

		public virtual void EmitLabel(CLangLabel l)
		{
		}

		public void EmitCast(CType fromType, CType toType)
		{
		}

		public void EmitCastToBoolean(CType fromType)
		{
		}

		public virtual void Emit(Instruction instruction)
		{
		}

		public void Emit(OpCode op, Value x)
		{
		}

		public void Emit(OpCode op, CLangLabel label)
		{
		}

		public void Emit(OpCode op)
		{
		}

		public virtual Value GetConstantMemory(string stringConstant)
		{
			return default(Value);
		}

		public int GetInstructionOffset(CType cType)
		{
			return 0;
		}

		public CType? MakeCType(DeclarationSpecifiers specs, Declarator? decl, Initializer? init, Block? block)
		{
			return null;
		}

		private CType? MakeCType(CType type, Declarator? decl, Initializer? init, Block? block)
		{
			return null;
		}

		private CType MakeCFunctionType(CType returnType, Declarator decl, Block? block)
		{
			return null;
		}

		public CType MakeCType(DeclarationSpecifiers specs, Initializer? init, Block? block)
		{
			return null;
		}

		private void AddStructMember(CStructType st, Statement s, Block? block)
		{
		}

		private void AddEnumMember(CEnumType st, Statement s, Block? block, EnumContext context)
		{
		}
	}
}
