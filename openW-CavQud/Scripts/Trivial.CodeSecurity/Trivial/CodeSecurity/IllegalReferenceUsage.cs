using System.Text;
using Trivial.Mono.Cecil;
using Trivial.Mono.Cecil.Cil;

namespace Trivial.CodeSecurity
{
	public struct IllegalReferenceUsage
	{
		public enum UsageType
		{
			Unknown = 0,
			UsedByModule = 1,
			UsedByType = 2,
			UsedByMethodSignature = 3,
			UsedByMethodBody = 4,
			UsedByPropertySignature = 5,
			UsedByFieldSignature = 6,
			UsedByEventSignature = 7,
			UsedByLocalSignature = 8,
			UsedByParameterSignature = 9
		}

		private static StringBuilder builder = new StringBuilder();

		private UsageType usageType;

		private ModuleDefinition usingModule;

		private TypeDefinition usingType;

		private MethodDefinition usingMethod;

		private MethodBody usingMethodBody;

		private Instruction usingInstruction;

		private PropertyDefinition usingProperty;

		private FieldDefinition usingField;

		private EventDefinition usingEvent;

		private VariableDefinition usingLocal;

		private ParameterDefinition usingParameter;

		public UsageType UsageContext => usageType;

		public ModuleDefinition UsingModule => usingModule;

		public TypeDefinition UsingType => usingType;

		public MethodDefinition UsingMethod => usingMethod;

		public MethodBody UsingMethodBody => usingMethodBody;

		public Instruction UsingInstruction => usingInstruction;

		public PropertyDefinition UsingProperty => usingProperty;

		public FieldDefinition UsingField => usingField;

		public EventDefinition UsingEvent => usingEvent;

		public VariableDefinition UsingLocal => usingLocal;

		public ParameterDefinition UsingParameter => usingParameter;

		internal IllegalReferenceUsage(ModuleDefinition usingModule)
		{
			usageType = UsageType.UsedByModule;
			this.usingModule = usingModule;
			usingType = null;
			usingMethod = null;
			usingMethodBody = null;
			usingInstruction = null;
			usingProperty = null;
			usingField = null;
			usingEvent = null;
			usingLocal = null;
			usingParameter = null;
		}

		internal IllegalReferenceUsage(TypeDefinition usingType)
		{
			usageType = UsageType.UsedByType;
			this.usingType = usingType;
			usingModule = null;
			usingMethod = null;
			usingMethodBody = null;
			usingInstruction = null;
			usingProperty = null;
			usingField = null;
			usingEvent = null;
			usingLocal = null;
			usingParameter = null;
		}

		internal IllegalReferenceUsage(MethodDefinition usingMethod)
		{
			usageType = UsageType.UsedByMethodSignature;
			usingType = usingMethod.DeclaringType;
			this.usingMethod = usingMethod;
			usingMethodBody = usingMethod.Body;
			usingModule = null;
			usingInstruction = null;
			usingProperty = null;
			usingField = null;
			usingEvent = null;
			usingLocal = null;
			usingParameter = null;
		}

		internal IllegalReferenceUsage(MethodBody usingMethodBody, Instruction usingInstruction)
		{
			usageType = UsageType.UsedByMethodBody;
			usingType = usingMethodBody.Method.DeclaringType;
			usingMethod = usingMethodBody.Method;
			this.usingMethodBody = usingMethodBody;
			this.usingInstruction = usingInstruction;
			usingModule = null;
			usingProperty = null;
			usingField = null;
			usingEvent = null;
			usingLocal = null;
			usingParameter = null;
		}

		internal IllegalReferenceUsage(PropertyDefinition usingProperty)
		{
			usageType = UsageType.UsedByPropertySignature;
			usingType = usingProperty.DeclaringType;
			this.usingProperty = usingProperty;
			usingModule = null;
			usingMethod = null;
			usingMethodBody = null;
			usingInstruction = null;
			usingField = null;
			usingEvent = null;
			usingLocal = null;
			usingParameter = null;
		}

		internal IllegalReferenceUsage(FieldDefinition usingField)
		{
			usageType = UsageType.UsedByFieldSignature;
			usingType = usingField.DeclaringType;
			this.usingField = usingField;
			usingModule = null;
			usingMethod = null;
			usingMethodBody = null;
			usingInstruction = null;
			usingProperty = null;
			usingEvent = null;
			usingLocal = null;
			usingParameter = null;
		}

		internal IllegalReferenceUsage(EventDefinition usingEvent)
		{
			usageType = UsageType.UsedByEventSignature;
			usingType = usingEvent.DeclaringType;
			this.usingEvent = usingEvent;
			usingModule = null;
			usingMethod = null;
			usingMethodBody = null;
			usingInstruction = null;
			usingProperty = null;
			usingField = null;
			usingLocal = null;
			usingParameter = null;
		}

		internal IllegalReferenceUsage(MethodDefinition usingMethod, VariableDefinition usingLocal)
		{
			usageType = UsageType.UsedByLocalSignature;
			usingType = usingMethod.DeclaringType;
			this.usingMethod = usingMethod;
			usingMethodBody = usingMethod.Body;
			this.usingLocal = usingLocal;
			usingModule = null;
			this.usingMethod = null;
			usingInstruction = null;
			usingProperty = null;
			usingField = null;
			usingEvent = null;
			usingParameter = null;
		}

		internal IllegalReferenceUsage(MethodDefinition usingMethod, ParameterDefinition usingParameter)
		{
			usageType = UsageType.UsedByParameterSignature;
			usingType = usingMethod.DeclaringType;
			this.usingMethod = usingMethod;
			usingMethodBody = usingMethod.Body;
			this.usingParameter = usingParameter;
			usingModule = null;
			usingInstruction = null;
			usingProperty = null;
			usingField = null;
			usingEvent = null;
			usingLocal = null;
		}

		public override string ToString()
		{
			return GetFullUsageString();
		}

		public string GetFullUsageString()
		{
			switch (usageType)
			{
			default:
				builder.Append("Usage context is unknown");
				break;
			case UsageType.UsedByEventSignature:
				builder.Append("Referenced in event definition signature: '");
				builder.Append(usingEvent);
				builder.Append("'");
				break;
			case UsageType.UsedByFieldSignature:
				builder.Append("Referenced in field definition signature: '");
				builder.Append(usingField);
				builder.Append("'");
				break;
			case UsageType.UsedByLocalSignature:
				builder.Append("Referenced in method body: '");
				builder.Append(usingMethod);
				builder.Append("' at local variable definition: '");
				builder.Append(usingLocal.Index);
				builder.Append("' of type: '");
				builder.Append(usingMethodBody.Variables[usingLocal.Index].VariableType);
				builder.Append("'");
				break;
			case UsageType.UsedByMethodBody:
				builder.Append("Referenced in method body: '");
				builder.Append(usingMethod);
				builder.Append("' at instruction: '");
				builder.Append(GetInstructionString(usingInstruction));
				builder.Append("'");
				break;
			case UsageType.UsedByMethodSignature:
				builder.Append("Referenced in method definition signature: '");
				builder.Append(usingMethod);
				builder.Append("'");
				break;
			case UsageType.UsedByModule:
				builder.Append("Referenced by module assembly references: '");
				builder.Append(usingModule);
				builder.Append("'");
				break;
			case UsageType.UsedByParameterSignature:
				builder.Append("Referenced in method definition signature: '");
				builder.Append(usingMethod);
				builder.Append("' as parameter definition: '");
				builder.Append(usingParameter);
				builder.Append("' at index: '");
				builder.Append(usingParameter.Sequence - 1);
				builder.Append("' of type '");
				builder.Append(usingParameter.ParameterType);
				builder.Append("'");
				break;
			case UsageType.UsedByPropertySignature:
				builder.Append("Referenced in property definition signature: '");
				builder.Append(usingProperty);
				builder.Append("'");
				break;
			case UsageType.UsedByType:
				builder.Append("Referenced in type definition: '");
				builder.Append(usingType);
				builder.Append("'");
				break;
			}
			if (usageType != UsageType.Unknown)
			{
				CodeSecurityLocation usageLocation = GetUsageLocation();
				builder.Append(" in source file: '");
				builder.Append(usageLocation.FileLocation);
				builder.Append("'");
				if (usageLocation.LineNumber != -1 && usageLocation.ColumnNumber != -1)
				{
					builder.Append(" at line: '");
					builder.Append(usageLocation.LineNumber);
					builder.Append("', column: '");
					builder.Append(usageLocation.ColumnNumber);
					builder.Append("'");
				}
			}
			string result = builder.ToString();
			builder.Length = 0;
			return result;
		}

		public CodeSecurityLocation GetUsageLocation()
		{
			switch (usageType)
			{
			case UsageType.UsedByType:
				return GetLocationForType(usingType);
			case UsageType.UsedByEventSignature:
				return GetLocationForEvent(usingEvent);
			case UsageType.UsedByFieldSignature:
				return GetLocationForField(usingField);
			case UsageType.UsedByPropertySignature:
				return GetLocationForProperty(usingProperty);
			case UsageType.UsedByMethodSignature:
			case UsageType.UsedByMethodBody:
			case UsageType.UsedByLocalSignature:
			case UsageType.UsedByParameterSignature:
				return GetLocationForMethod(usingMethod, usingInstruction);
			default:
				return CodeSecurityLocation.defaultLocation;
			}
		}

		public static string GetInstructionString(Instruction instruction)
		{
			string arg = string.Empty;
			switch (instruction.OpCode.OperandType)
			{
			case OperandType.InlineField:
			case OperandType.InlineMethod:
			case OperandType.InlineType:
			case OperandType.InlineVar:
			case OperandType.InlineArg:
			case OperandType.ShortInlineVar:
				arg = " " + instruction.Operand.ToString();
				break;
			}
			return string.Format("IL_{0}: {1}{2}", instruction.Offset.ToString("x4"), instruction.OpCode.Code, arg);
		}

		public static CodeSecurityLocation GetLocationForType(TypeDefinition type)
		{
			foreach (MethodDefinition method in type.Methods)
			{
				if (method.DebugInformation.HasSequencePoints)
				{
					return new CodeSecurityLocation(method.DebugInformation.SequencePoints[0].Document.Url);
				}
			}
			return CodeSecurityLocation.defaultLocation;
		}

		public static CodeSecurityLocation GetLocationForMethod(MethodDefinition method, Instruction usingInstruction)
		{
			if (usingInstruction != null)
			{
				SequencePoint sequencePoint = method.DebugInformation.GetSequencePoint(usingInstruction);
				if (sequencePoint != null)
				{
					return new CodeSecurityLocation(sequencePoint.Document.Url, sequencePoint.StartLine, sequencePoint.StartColumn);
				}
			}
			if (method.DebugInformation.HasSequencePoints)
			{
				return new CodeSecurityLocation(method.DebugInformation.SequencePoints[0].Document.Url);
			}
			return CodeSecurityLocation.defaultLocation;
		}

		public static CodeSecurityLocation GetLocationForProperty(PropertyDefinition property)
		{
			MethodDefinition methodDefinition = property.GetMethod;
			if (methodDefinition == null)
			{
				methodDefinition = property.SetMethod;
			}
			if (methodDefinition != null && methodDefinition.HasBody && methodDefinition.DebugInformation.HasSequencePoints)
			{
				return new CodeSecurityLocation(methodDefinition.DebugInformation.SequencePoints[0].Document.Url);
			}
			return CodeSecurityLocation.defaultLocation;
		}

		public static CodeSecurityLocation GetLocationForField(FieldDefinition field)
		{
			return GetLocationForType(field.DeclaringType);
		}

		public static CodeSecurityLocation GetLocationForEvent(EventDefinition evt)
		{
			return GetLocationForType(evt.DeclaringType);
		}
	}
}
