using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;

namespace Microsoft.VisualBasic
{
	internal class VBCodeGenerator : CodeGenerator
	{
		private enum LineHandling
		{
			InLine = 0,
			ContinueLine = 1,
			NewLine = 2
		}

		private string[] Keywords = new string[139]
		{
			"AddHandler", "AddressOf", "Alias", "And", "AndAlso", "Ansi", "As", "Assembly", "Auto", "Boolean",
			"ByRef", "Byte", "ByVal", "Call", "Case", "Catch", "CBool", "CByte", "CChar", "CDate",
			"CDec", "CDbl", "Char", "CInt", "Class", "CLng", "CObj", "Const", "CShort", "CSng",
			"CStr", "CType", "Date", "Decimal", "Declare", "Default", "Delegate", "Dim", "DirectCast", "Do",
			"Double", "Each", "Else", "ElseIf", "End", "Enum", "Erase", "Error", "Event", "Exit",
			"False", "Finally", "For", "Friend", "Function", "Get", "GetType", "Global", "GoSub", "GoTo",
			"Handles", "If", "Implements", "Imports", "In", "Inherits", "Integer", "Interface", "Is", "Let",
			"Lib", "Like", "Long", "Loop", "Me", "Mod", "Module", "MustInherit", "MustOverride", "MyBase",
			"MyClass", "Namespace", "New", "Next", "Not", "Nothing", "NotInheritable", "NotOverridable", "Object", "On",
			"Option", "Optional", "Or", "OrElse", "Overloads", "Overridable", "Overrides", "ParamArray", "Partial", "Preserve",
			"Private", "Property", "Protected", "Public", "RaiseEvent", "ReadOnly", "ReDim", "REM", "RemoveHandler", "Resume",
			"Return", "Select", "Set", "Shadows", "Shared", "Short", "Single", "Static", "Step", "Stop",
			"String", "Structure", "Sub", "SyncLock", "Then", "Throw", "To", "True", "Try", "TypeOf",
			"Unicode", "Until", "Variant", "When", "While", "With", "WithEvents", "WriteOnly", "Xor"
		};

		private CodeAttributeDeclarationCollection assemblyCustomAttributes;

		protected override string NullToken
		{
			get
			{
				return "Nothing";
			}
		}

		protected override void ContinueOnNewLine(string st)
		{
			base.Output.Write(st);
			base.Output.WriteLine(" _");
		}

		protected override void GenerateBinaryOperatorExpression(CodeBinaryOperatorExpression e)
		{
			bool flag = false;
			bool flag2 = false;
			if (e.Operator == CodeBinaryOperatorType.IdentityInequality)
			{
				CodePrimitiveExpression codePrimitiveExpression = e.Left as CodePrimitiveExpression;
				if (codePrimitiveExpression == null)
				{
					codePrimitiveExpression = e.Right as CodePrimitiveExpression;
				}
				else
				{
					flag2 = true;
				}
				flag = codePrimitiveExpression != null && codePrimitiveExpression.Value == null;
			}
			if (flag)
			{
				TextWriter textWriter = base.Output;
				textWriter.Write("(Not (");
				GenerateExpression(flag2 ? e.Right : e.Left);
				textWriter.Write(") Is ");
				GenerateExpression(flag2 ? e.Left : e.Right);
				textWriter.Write(')');
			}
			else
			{
				base.GenerateBinaryOperatorExpression(e);
			}
		}

		protected override void GenerateArrayCreateExpression(CodeArrayCreateExpression expression)
		{
			TextWriter textWriter = base.Output;
			textWriter.Write("New ");
			CodeExpressionCollection initializers = expression.Initializers;
			CodeTypeReference codeTypeReference = expression.CreateType;
			if (initializers.Count > 0)
			{
				OutputType(codeTypeReference);
				textWriter.Write("() {");
				int indent = base.Indent + 1;
				base.Indent = indent;
				OutputExpressionList(initializers);
				indent = base.Indent - 1;
				base.Indent = indent;
				textWriter.Write("}");
				return;
			}
			for (CodeTypeReference arrayElementType = codeTypeReference.ArrayElementType; arrayElementType != null; arrayElementType = arrayElementType.ArrayElementType)
			{
				codeTypeReference = arrayElementType;
			}
			OutputType(codeTypeReference);
			textWriter.Write("((");
			CodeExpression sizeExpression = expression.SizeExpression;
			if (sizeExpression != null)
			{
				GenerateExpression(sizeExpression);
			}
			else
			{
				textWriter.Write(expression.Size);
			}
			textWriter.Write(") - 1) {}");
		}

		protected override void GenerateBaseReferenceExpression(CodeBaseReferenceExpression expression)
		{
			base.Output.Write("MyBase");
		}

		protected override void GenerateCastExpression(CodeCastExpression expression)
		{
			TextWriter textWriter = base.Output;
			textWriter.Write("CType(");
			GenerateExpression(expression.Expression);
			textWriter.Write(", ");
			OutputType(expression.TargetType);
			textWriter.Write(")");
		}

		private bool AsBool(object datavalue)
		{
			if (datavalue != null && datavalue is bool)
			{
				return (bool)datavalue;
			}
			return false;
		}

		private string OnOff(bool datavalue)
		{
			if (!datavalue)
			{
				return "Off";
			}
			return "On";
		}

		protected override void GenerateCompileUnitStart(CodeCompileUnit compileUnit)
		{
			GenerateComment(new CodeComment("------------------------------------------------------------------------------"));
			GenerateComment(new CodeComment(" <autogenerated>"));
			GenerateComment(new CodeComment("     This code was generated by a tool."));
			GenerateComment(new CodeComment("     Mono Runtime Version: " + Environment.Version));
			GenerateComment(new CodeComment(""));
			GenerateComment(new CodeComment("     Changes to this file may cause incorrect behavior and will be lost if "));
			GenerateComment(new CodeComment("     the code is regenerated."));
			GenerateComment(new CodeComment(" </autogenerated>"));
			GenerateComment(new CodeComment("------------------------------------------------------------------------------"));
			base.Output.WriteLine();
			if (AsBool(compileUnit.UserData["AllowLateBound"]))
			{
				base.Output.WriteLine("Option Explicit {0}", OnOff(AsBool(compileUnit.UserData["RequireVariableDeclaration"])));
				base.Output.WriteLine("Option Strict Off");
			}
			else
			{
				base.Output.WriteLine("Option Explicit On");
				base.Output.WriteLine("Option Strict On");
			}
			base.Output.WriteLine();
		}

		protected override void GenerateCompileUnit(CodeCompileUnit compileUnit)
		{
			assemblyCustomAttributes = compileUnit.AssemblyCustomAttributes;
			GenerateCompileUnitStart(compileUnit);
			GenerateNamespaces(compileUnit);
			if (assemblyCustomAttributes != null)
			{
				GenerateAssemblyAttributes();
			}
			GenerateCompileUnitEnd(compileUnit);
		}

		protected override void GenerateDelegateCreateExpression(CodeDelegateCreateExpression expression)
		{
			TextWriter textWriter = base.Output;
			textWriter.Write("AddressOf ");
			CodeExpression targetObject = expression.TargetObject;
			if (targetObject != null)
			{
				GenerateExpression(targetObject);
				base.Output.Write('.');
			}
			textWriter.Write(expression.MethodName);
		}

		protected override void GenerateFieldReferenceExpression(CodeFieldReferenceExpression expression)
		{
			CodeExpression targetObject = expression.TargetObject;
			if (targetObject != null)
			{
				GenerateExpression(targetObject);
				base.Output.Write('.');
			}
			base.Output.Write(CreateEscapedIdentifier(expression.FieldName));
		}

		protected override void GenerateArgumentReferenceExpression(CodeArgumentReferenceExpression expression)
		{
			base.Output.Write(CreateEscapedIdentifier(expression.ParameterName));
		}

		protected override void GenerateVariableReferenceExpression(CodeVariableReferenceExpression expression)
		{
			base.Output.Write(CreateEscapedIdentifier(expression.VariableName));
		}

		protected override void GenerateIndexerExpression(CodeIndexerExpression expression)
		{
			TextWriter textWriter = base.Output;
			GenerateExpression(expression.TargetObject);
			textWriter.Write('(');
			OutputExpressionList(expression.Indices);
			textWriter.Write(')');
		}

		protected override void GenerateArrayIndexerExpression(CodeArrayIndexerExpression expression)
		{
			TextWriter textWriter = base.Output;
			GenerateExpression(expression.TargetObject);
			textWriter.Write("(");
			OutputExpressionList(expression.Indices);
			textWriter.Write(')');
		}

		protected override void GenerateSnippetExpression(CodeSnippetExpression expression)
		{
			base.Output.Write(expression.Value);
		}

		protected override void GenerateMethodInvokeExpression(CodeMethodInvokeExpression expression)
		{
			TextWriter textWriter = base.Output;
			GenerateMethodReferenceExpression(expression.Method);
			textWriter.Write('(');
			OutputExpressionList(expression.Parameters);
			textWriter.Write(')');
		}

		protected override void GenerateMethodReferenceExpression(CodeMethodReferenceExpression expression)
		{
			if (expression.TargetObject != null)
			{
				GenerateExpression(expression.TargetObject);
				base.Output.Write('.');
			}
			base.Output.Write(CreateEscapedIdentifier(expression.MethodName));
		}

		protected override void GenerateEventReferenceExpression(CodeEventReferenceExpression expression)
		{
			if (expression.TargetObject != null)
			{
				GenerateExpression(expression.TargetObject);
				base.Output.Write('.');
				if (expression.TargetObject is CodeThisReferenceExpression)
				{
					base.Output.Write(expression.EventName + "Event");
				}
				else
				{
					base.Output.Write(CreateEscapedIdentifier(expression.EventName));
				}
			}
			else
			{
				base.Output.Write(CreateEscapedIdentifier(expression.EventName + "Event"));
			}
		}

		protected override void GenerateDelegateInvokeExpression(CodeDelegateInvokeExpression expression)
		{
			CodeEventReferenceExpression codeEventReferenceExpression = expression.TargetObject as CodeEventReferenceExpression;
			if (codeEventReferenceExpression != null)
			{
				base.Output.Write("RaiseEvent ");
				if (codeEventReferenceExpression.TargetObject != null && !(codeEventReferenceExpression.TargetObject is CodeThisReferenceExpression))
				{
					GenerateExpression(codeEventReferenceExpression.TargetObject);
					base.Output.Write(".");
				}
				base.Output.Write(codeEventReferenceExpression.EventName);
			}
			else if (expression.TargetObject != null)
			{
				GenerateExpression(expression.TargetObject);
			}
			base.Output.Write('(');
			OutputExpressionList(expression.Parameters);
			base.Output.Write(')');
		}

		protected override void GenerateObjectCreateExpression(CodeObjectCreateExpression expression)
		{
			base.Output.Write("New ");
			OutputType(expression.CreateType);
			base.Output.Write('(');
			OutputExpressionList(expression.Parameters);
			base.Output.Write(')');
		}

		protected override void GenerateParameterDeclarationExpression(CodeParameterDeclarationExpression e)
		{
			OutputAttributes(e.CustomAttributes, null, LineHandling.InLine);
			OutputDirection(e.Direction);
			OutputTypeNamePair(e.Type, e.Name);
		}

		protected override void GeneratePrimitiveExpression(CodePrimitiveExpression e)
		{
			if (e.Value is char)
			{
				int num = (char)e.Value;
				base.Output.Write("Global.Microsoft.VisualBasic.ChrW(" + num.ToString(CultureInfo.InvariantCulture) + ")");
			}
			else if (e.Value is ushort)
			{
				ushort num2 = (ushort)e.Value;
				base.Output.Write(num2.ToString(CultureInfo.InvariantCulture));
				base.Output.Write("US");
			}
			else if (e.Value is uint)
			{
				uint num3 = (uint)e.Value;
				base.Output.Write(num3.ToString(CultureInfo.InvariantCulture));
				base.Output.Write("UI");
			}
			else if (e.Value is ulong)
			{
				ulong num4 = (ulong)e.Value;
				base.Output.Write(num4.ToString(CultureInfo.InvariantCulture));
				base.Output.Write("UL");
			}
			else if (e.Value is sbyte)
			{
				sbyte b = (sbyte)e.Value;
				base.Output.Write("CSByte(");
				base.Output.Write(b.ToString(CultureInfo.InvariantCulture));
				base.Output.Write(')');
			}
			else
			{
				base.GeneratePrimitiveExpression(e);
			}
		}

		protected override void GenerateSingleFloatValue(float s)
		{
			base.GenerateSingleFloatValue(s);
			base.Output.Write('!');
		}

		protected override void GeneratePropertyReferenceExpression(CodePropertyReferenceExpression expression)
		{
			if (expression.TargetObject != null)
			{
				GenerateMemberReferenceExpression(expression.TargetObject, expression.PropertyName);
			}
			else
			{
				base.Output.Write(CreateEscapedIdentifier(expression.PropertyName));
			}
		}

		protected override void GeneratePropertySetValueReferenceExpression(CodePropertySetValueReferenceExpression expression)
		{
			base.Output.Write("Value");
		}

		protected override void GenerateThisReferenceExpression(CodeThisReferenceExpression expression)
		{
			base.Output.Write("Me");
		}

		protected override void GenerateExpressionStatement(CodeExpressionStatement statement)
		{
			GenerateExpression(statement.Expression);
			base.Output.WriteLine();
		}

		protected override void GenerateIterationStatement(CodeIterationStatement statement)
		{
			TextWriter textWriter = base.Output;
			GenerateStatement(statement.InitStatement);
			textWriter.Write("Do While ");
			GenerateExpression(statement.TestExpression);
			textWriter.WriteLine();
			base.Indent++;
			GenerateStatements(statement.Statements);
			GenerateStatement(statement.IncrementStatement);
			base.Indent--;
			textWriter.WriteLine("Loop");
		}

		protected override void GenerateThrowExceptionStatement(CodeThrowExceptionStatement statement)
		{
			base.Output.Write("Throw");
			if (statement.ToThrow != null)
			{
				base.Output.Write(' ');
				GenerateExpression(statement.ToThrow);
			}
			base.Output.WriteLine();
		}

		protected override void GenerateComment(CodeComment comment)
		{
			TextWriter textWriter = base.Output;
			string text = null;
			text = ((!comment.DocComment) ? "'" : "'''");
			textWriter.Write(text);
			string text2 = comment.Text;
			for (int i = 0; i < text2.Length; i++)
			{
				textWriter.Write(text2[i]);
				if (text2[i] == '\r')
				{
					if (i >= text2.Length - 1 || text2[i + 1] != '\n')
					{
						textWriter.Write(text);
					}
				}
				else if (text2[i] == '\n')
				{
					textWriter.Write(text);
				}
			}
			textWriter.WriteLine();
		}

		protected override void GenerateMethodReturnStatement(CodeMethodReturnStatement statement)
		{
			TextWriter textWriter = base.Output;
			if (statement.Expression != null)
			{
				textWriter.Write("Return ");
				GenerateExpression(statement.Expression);
				textWriter.WriteLine();
			}
			else
			{
				textWriter.WriteLine("Return");
			}
		}

		protected override void GenerateConditionStatement(CodeConditionStatement statement)
		{
			TextWriter textWriter = base.Output;
			textWriter.Write("If ");
			GenerateExpression(statement.Condition);
			textWriter.WriteLine(" Then");
			int indent = base.Indent + 1;
			base.Indent = indent;
			GenerateStatements(statement.TrueStatements);
			indent = base.Indent - 1;
			base.Indent = indent;
			CodeStatementCollection falseStatements = statement.FalseStatements;
			if (falseStatements.Count > 0)
			{
				textWriter.WriteLine("Else");
				indent = base.Indent + 1;
				base.Indent = indent;
				GenerateStatements(falseStatements);
				indent = base.Indent - 1;
				base.Indent = indent;
			}
			else if (base.Options.ElseOnClosing)
			{
				textWriter.WriteLine("Else");
			}
			textWriter.WriteLine("End If");
		}

		protected override void GenerateTryCatchFinallyStatement(CodeTryCatchFinallyStatement statement)
		{
			TextWriter textWriter = base.Output;
			textWriter.WriteLine("Try ");
			int indent = base.Indent + 1;
			base.Indent = indent;
			GenerateStatements(statement.TryStatements);
			indent = base.Indent - 1;
			base.Indent = indent;
			foreach (CodeCatchClause catchClause in statement.CatchClauses)
			{
				textWriter.Write("Catch ");
				OutputTypeNamePair(catchClause.CatchExceptionType, catchClause.LocalName);
				textWriter.WriteLine();
				indent = base.Indent + 1;
				base.Indent = indent;
				GenerateStatements(catchClause.Statements);
				indent = base.Indent - 1;
				base.Indent = indent;
			}
			CodeStatementCollection finallyStatements = statement.FinallyStatements;
			if (finallyStatements.Count > 0)
			{
				textWriter.WriteLine("Finally");
				indent = base.Indent + 1;
				base.Indent = indent;
				GenerateStatements(finallyStatements);
				indent = base.Indent - 1;
				base.Indent = indent;
			}
			textWriter.WriteLine("End Try");
		}

		protected override void GenerateAssignStatement(CodeAssignStatement statement)
		{
			TextWriter textWriter = base.Output;
			GenerateExpression(statement.Left);
			textWriter.Write(" = ");
			GenerateExpression(statement.Right);
			textWriter.WriteLine();
		}

		protected override void GenerateAttachEventStatement(CodeAttachEventStatement statement)
		{
			TextWriter textWriter = base.Output;
			base.Output.Write("AddHandler ");
			if (statement.Event.TargetObject != null)
			{
				GenerateEventReferenceExpression(statement.Event);
			}
			else
			{
				base.Output.Write(CreateEscapedIdentifier(statement.Event.EventName));
			}
			base.Output.Write(", ");
			GenerateExpression(statement.Listener);
			textWriter.WriteLine();
		}

		protected override void GenerateRemoveEventStatement(CodeRemoveEventStatement statement)
		{
			TextWriter textWriter = base.Output;
			base.Output.Write("RemoveHandler ");
			if (statement.Event.TargetObject != null)
			{
				GenerateEventReferenceExpression(statement.Event);
			}
			else
			{
				base.Output.Write(CreateEscapedIdentifier(statement.Event.EventName));
			}
			base.Output.Write(", ");
			GenerateExpression(statement.Listener);
			textWriter.WriteLine();
		}

		protected override void GenerateGotoStatement(CodeGotoStatement statement)
		{
			TextWriter textWriter = base.Output;
			textWriter.Write("goto ");
			textWriter.Write(statement.Label);
			textWriter.WriteLine();
		}

		protected override void GenerateLabeledStatement(CodeLabeledStatement statement)
		{
			TextWriter textWriter = base.Output;
			base.Indent--;
			textWriter.WriteLine(statement.Label + ":");
			base.Indent++;
			if (statement.Statement != null)
			{
				GenerateStatement(statement.Statement);
			}
		}

		protected override void GenerateTypeOfExpression(CodeTypeOfExpression e)
		{
			TextWriter textWriter = base.Output;
			textWriter.Write("GetType(");
			OutputType(e.Type);
			textWriter.Write(")");
		}

		protected override void GenerateVariableDeclarationStatement(CodeVariableDeclarationStatement statement)
		{
			TextWriter textWriter = base.Output;
			textWriter.Write("Dim ");
			OutputTypeNamePair(statement.Type, statement.Name);
			CodeExpression initExpression = statement.InitExpression;
			if (initExpression != null)
			{
				textWriter.Write(" = ");
				GenerateExpression(initExpression);
			}
			textWriter.WriteLine();
		}

		protected override void GenerateLinePragmaStart(CodeLinePragma linePragma)
		{
			base.Output.WriteLine();
			base.Output.Write("#ExternalSource(\"");
			base.Output.Write(linePragma.FileName);
			base.Output.Write("\",");
			base.Output.Write(linePragma.LineNumber);
			base.Output.WriteLine(")");
			base.Output.WriteLine("");
		}

		protected override void GenerateLinePragmaEnd(CodeLinePragma linePragma)
		{
			base.Output.WriteLine("#End ExternalSource");
		}

		protected override void GenerateEvent(CodeMemberEvent eventRef, CodeTypeDeclaration declaration)
		{
			if (!base.IsCurrentDelegate && !base.IsCurrentEnum)
			{
				TextWriter textWriter = base.Output;
				OutputAttributes(eventRef.CustomAttributes, null, LineHandling.ContinueLine);
				OutputMemberAccessModifier(eventRef.Attributes);
				textWriter.Write("Event ");
				OutputTypeNamePair(eventRef.Type, GetEventName(eventRef));
				if (eventRef.ImplementationTypes.Count > 0)
				{
					OutputImplementationTypes(eventRef.ImplementationTypes, eventRef.Name);
				}
				else if (eventRef.PrivateImplementationType != null)
				{
					textWriter.Write(" Implements ");
					OutputType(eventRef.PrivateImplementationType);
					textWriter.Write('.');
					textWriter.Write(eventRef.Name);
				}
				textWriter.WriteLine();
			}
		}

		protected override void GenerateField(CodeMemberField field)
		{
			if (!base.IsCurrentDelegate && !base.IsCurrentInterface)
			{
				TextWriter textWriter = base.Output;
				OutputAttributes(field.CustomAttributes, null, LineHandling.ContinueLine);
				if (base.IsCurrentEnum)
				{
					textWriter.Write(field.Name);
				}
				else
				{
					MemberAttributes attributes = field.Attributes;
					OutputMemberAccessModifier(attributes);
					OutputVTableModifier(attributes);
					OutputFieldScopeModifier(attributes);
					OutputTypeNamePair(field.Type, field.Name);
				}
				CodeExpression initExpression = field.InitExpression;
				if (initExpression != null)
				{
					textWriter.Write(" = ");
					GenerateExpression(initExpression);
				}
				textWriter.WriteLine();
			}
		}

		protected override void GenerateSnippetMember(CodeSnippetTypeMember member)
		{
			base.Output.Write(member.Text);
		}

		protected override void GenerateEntryPointMethod(CodeEntryPointMethod method, CodeTypeDeclaration declaration)
		{
			OutputAttributes(method.CustomAttributes, null, LineHandling.ContinueLine);
			base.Output.WriteLine("Public Shared Sub Main()");
			base.Indent++;
			GenerateStatements(method.Statements);
			base.Indent--;
			base.Output.WriteLine("End Sub");
		}

		[System.MonoTODO("partially implemented")]
		protected override void GenerateMethod(CodeMemberMethod method, CodeTypeDeclaration declaration)
		{
			if (base.IsCurrentDelegate || base.IsCurrentEnum)
			{
				return;
			}
			bool flag = method.ReturnType.BaseType == typeof(void).FullName;
			TextWriter textWriter = base.Output;
			OutputAttributes(method.CustomAttributes, null, LineHandling.ContinueLine);
			MemberAttributes attributes = method.Attributes;
			if (!base.IsCurrentInterface)
			{
				if (method.PrivateImplementationType == null)
				{
					OutputMemberAccessModifier(attributes);
					if (IsOverloaded(method, declaration))
					{
						textWriter.Write("Overloads ");
					}
				}
				OutputVTableModifier(attributes);
				OutputMemberScopeModifier(attributes);
			}
			else
			{
				OutputVTableModifier(attributes);
			}
			if (flag)
			{
				textWriter.Write("Sub ");
			}
			else
			{
				textWriter.Write("Function ");
			}
			textWriter.Write(GetMethodName(method));
			OutputTypeParameters(method.TypeParameters);
			textWriter.Write('(');
			OutputParameters(method.Parameters);
			textWriter.Write(')');
			if (!flag)
			{
				textWriter.Write(" As ");
				OutputAttributes(method.ReturnTypeCustomAttributes, null, LineHandling.InLine);
				OutputType(method.ReturnType);
			}
			if (method.ImplementationTypes.Count > 0)
			{
				OutputImplementationTypes(method.ImplementationTypes, method.Name);
			}
			else if (method.PrivateImplementationType != null)
			{
				textWriter.Write(" Implements ");
				OutputType(method.PrivateImplementationType);
				textWriter.Write('.');
				textWriter.Write(method.Name);
			}
			textWriter.WriteLine();
			if (!base.IsCurrentInterface && (attributes & MemberAttributes.ScopeMask) != MemberAttributes.Abstract)
			{
				int indent = base.Indent + 1;
				base.Indent = indent;
				GenerateStatements(method.Statements);
				indent = base.Indent - 1;
				base.Indent = indent;
				if (flag)
				{
					textWriter.WriteLine("End Sub");
				}
				else
				{
					textWriter.WriteLine("End Function");
				}
			}
		}

		protected override void GenerateProperty(CodeMemberProperty property, CodeTypeDeclaration declaration)
		{
			if (base.IsCurrentDelegate || base.IsCurrentEnum)
			{
				return;
			}
			TextWriter textWriter = base.Output;
			OutputAttributes(property.CustomAttributes, null, LineHandling.ContinueLine);
			MemberAttributes attributes = property.Attributes;
			if (!base.IsCurrentInterface)
			{
				if (property.PrivateImplementationType == null)
				{
					OutputMemberAccessModifier(attributes);
					if (IsOverloaded(property, declaration))
					{
						textWriter.Write("Overloads ");
					}
				}
				OutputVTableModifier(attributes);
				OutputMemberScopeModifier(attributes);
			}
			else
			{
				OutputVTableModifier(attributes);
			}
			if (string.Compare(GetPropertyName(property), "Item", true, CultureInfo.InvariantCulture) == 0 && property.Parameters.Count > 0)
			{
				textWriter.Write("Default ");
			}
			if (property.HasGet && !property.HasSet)
			{
				textWriter.Write("ReadOnly ");
			}
			if (property.HasSet && !property.HasGet)
			{
				textWriter.Write("WriteOnly ");
			}
			textWriter.Write("Property ");
			base.Output.Write(GetPropertyName(property));
			base.Output.Write('(');
			OutputParameters(property.Parameters);
			base.Output.Write(')');
			base.Output.Write(" As ");
			base.Output.Write(GetTypeOutput(property.Type));
			if (property.ImplementationTypes.Count > 0)
			{
				OutputImplementationTypes(property.ImplementationTypes, property.Name);
			}
			else if (property.PrivateImplementationType != null)
			{
				textWriter.Write(" Implements ");
				OutputType(property.PrivateImplementationType);
				textWriter.Write('.');
				textWriter.Write(property.Name);
			}
			textWriter.WriteLine();
			if (base.IsCurrentInterface)
			{
				return;
			}
			int indent = base.Indent + 1;
			base.Indent = indent;
			if (property.HasGet)
			{
				textWriter.WriteLine("Get");
				if (!IsAbstract(property.Attributes))
				{
					indent = base.Indent + 1;
					base.Indent = indent;
					GenerateStatements(property.GetStatements);
					indent = base.Indent - 1;
					base.Indent = indent;
					textWriter.WriteLine("End Get");
				}
			}
			if (property.HasSet)
			{
				textWriter.WriteLine("Set");
				if (!IsAbstract(property.Attributes))
				{
					indent = base.Indent + 1;
					base.Indent = indent;
					GenerateStatements(property.SetStatements);
					indent = base.Indent - 1;
					base.Indent = indent;
					textWriter.WriteLine("End Set");
				}
			}
			indent = base.Indent - 1;
			base.Indent = indent;
			textWriter.WriteLine("End Property");
		}

		protected override void GenerateConstructor(CodeConstructor constructor, CodeTypeDeclaration declaration)
		{
			if (base.IsCurrentDelegate || base.IsCurrentEnum || base.IsCurrentInterface)
			{
				return;
			}
			OutputAttributes(constructor.CustomAttributes, null, LineHandling.ContinueLine);
			OutputMemberAccessModifier(constructor.Attributes);
			base.Output.Write("Sub New(");
			OutputParameters(constructor.Parameters);
			base.Output.WriteLine(")");
			base.Indent++;
			CodeExpressionCollection chainedConstructorArgs = constructor.ChainedConstructorArgs;
			if (chainedConstructorArgs.Count > 0)
			{
				base.Output.Write("Me.New(");
				OutputExpressionList(chainedConstructorArgs);
				base.Output.WriteLine(")");
			}
			else
			{
				chainedConstructorArgs = constructor.BaseConstructorArgs;
				if (chainedConstructorArgs.Count > 0)
				{
					base.Output.Write("MyBase.New(");
					OutputExpressionList(chainedConstructorArgs);
					base.Output.WriteLine(")");
				}
				else if (base.IsCurrentClass)
				{
					base.Output.WriteLine("MyBase.New");
				}
			}
			GenerateStatements(constructor.Statements);
			base.Indent--;
			base.Output.WriteLine("End Sub");
		}

		protected override void GenerateTypeConstructor(CodeTypeConstructor constructor)
		{
			if (!base.IsCurrentDelegate && !base.IsCurrentEnum && !base.IsCurrentInterface)
			{
				OutputAttributes(constructor.CustomAttributes, null, LineHandling.ContinueLine);
				base.Output.WriteLine("Shared Sub New()");
				base.Indent++;
				GenerateStatements(constructor.Statements);
				base.Indent--;
				base.Output.WriteLine("End Sub");
			}
		}

		[System.MonoTODO("partially implemented")]
		protected override void GenerateTypeStart(CodeTypeDeclaration declaration)
		{
			TextWriter textWriter = base.Output;
			OutputAttributes(declaration.CustomAttributes, null, LineHandling.ContinueLine);
			TypeAttributes typeAttributes = declaration.TypeAttributes;
			if (base.IsCurrentDelegate)
			{
				CodeTypeDelegate codeTypeDelegate = (CodeTypeDelegate)declaration;
				if ((typeAttributes & TypeAttributes.VisibilityMask) == TypeAttributes.Public)
				{
					textWriter.Write("Public ");
				}
				bool num = codeTypeDelegate.ReturnType.BaseType == typeof(void).FullName;
				if (num)
				{
					textWriter.Write("Delegate Sub ");
				}
				else
				{
					textWriter.Write("Delegate Function ");
				}
				textWriter.Write(CreateEscapedIdentifier(codeTypeDelegate.Name));
				OutputTypeParameters(codeTypeDelegate.TypeParameters);
				textWriter.Write("(");
				OutputParameters(codeTypeDelegate.Parameters);
				base.Output.Write(")");
				if (!num)
				{
					base.Output.Write(" As ");
					OutputType(codeTypeDelegate.ReturnType);
				}
				base.Output.WriteLine("");
				return;
			}
			OutputTypeAttributes(declaration);
			textWriter.Write(CreateEscapedIdentifier(declaration.Name));
			OutputTypeParameters(declaration.TypeParameters);
			int indent;
			if (base.IsCurrentEnum)
			{
				if (declaration.BaseTypes.Count > 0)
				{
					textWriter.Write(" As ");
					OutputType(declaration.BaseTypes[0]);
				}
				textWriter.WriteLine();
				indent = base.Indent + 1;
				base.Indent = indent;
				return;
			}
			indent = base.Indent + 1;
			base.Indent = indent;
			bool flag = true;
			bool flag2 = true;
			for (int i = 0; i < declaration.BaseTypes.Count; i++)
			{
				CodeTypeReference codeTypeReference = declaration.BaseTypes[i];
				if (flag && !declaration.IsStruct && !codeTypeReference.IsInterface)
				{
					textWriter.WriteLine();
					textWriter.Write("Inherits ");
					flag = false;
				}
				else if (!declaration.IsInterface && flag2)
				{
					textWriter.WriteLine();
					textWriter.Write("Implements ");
					flag2 = false;
				}
				else
				{
					textWriter.Write(", ");
				}
				OutputType(codeTypeReference);
			}
			textWriter.WriteLine();
		}

		protected override void GenerateTypeEnd(CodeTypeDeclaration declaration)
		{
			if (!base.IsCurrentDelegate)
			{
				string value = string.Empty;
				int indent = base.Indent - 1;
				base.Indent = indent;
				if (declaration.IsStruct)
				{
					value = "End Structure";
				}
				if (declaration.IsInterface)
				{
					value = "End Interface";
				}
				if (declaration.IsEnum)
				{
					value = "End Enum";
				}
				if (declaration.IsClass)
				{
					value = "End Class";
				}
				base.Output.WriteLine(value);
			}
		}

		protected override void GenerateNamespace(CodeNamespace ns)
		{
			GenerateNamespaceImports(ns);
			if (assemblyCustomAttributes != null)
			{
				GenerateAssemblyAttributes();
			}
			base.Output.WriteLine();
			GenerateCommentStatements(ns.Comments);
			GenerateNamespaceStart(ns);
			GenerateTypes(ns);
			GenerateNamespaceEnd(ns);
		}

		protected override void GenerateNamespaceStart(CodeNamespace ns)
		{
			TextWriter textWriter = base.Output;
			string name = ns.Name;
			if (name != null && name != string.Empty)
			{
				textWriter.Write("Namespace ");
				textWriter.WriteLine(name);
				int indent = base.Indent + 1;
				base.Indent = indent;
			}
		}

		protected override void GenerateNamespaceEnd(CodeNamespace ns)
		{
			string name = ns.Name;
			if (name != null && name != string.Empty)
			{
				int indent = base.Indent - 1;
				base.Indent = indent;
				base.Output.WriteLine("End Namespace");
			}
		}

		protected override void GenerateNamespaceImport(CodeNamespaceImport import)
		{
			TextWriter textWriter = base.Output;
			textWriter.Write("Imports ");
			textWriter.Write(import.Namespace);
			textWriter.WriteLine();
		}

		protected override void GenerateAttributeDeclarationsStart(CodeAttributeDeclarationCollection attributes)
		{
			base.Output.Write('<');
		}

		protected override void GenerateAttributeDeclarationsEnd(CodeAttributeDeclarationCollection attributes)
		{
			base.Output.Write(">");
		}

		private void OutputAttributes(CodeAttributeDeclarationCollection attributes, string prefix, LineHandling lineHandling)
		{
			if (attributes.Count == 0)
			{
				return;
			}
			GenerateAttributeDeclarationsStart(attributes);
			IEnumerator enumerator = attributes.GetEnumerator();
			if (enumerator.MoveNext())
			{
				CodeAttributeDeclaration attribute = (CodeAttributeDeclaration)enumerator.Current;
				if (prefix != null)
				{
					base.Output.Write(prefix);
				}
				OutputAttributeDeclaration(attribute);
				while (enumerator.MoveNext())
				{
					base.Output.Write(", ");
					if (lineHandling != LineHandling.InLine)
					{
						ContinueOnNewLine("");
						base.Output.Write(" ");
					}
					attribute = (CodeAttributeDeclaration)enumerator.Current;
					if (prefix != null)
					{
						base.Output.Write(prefix);
					}
					OutputAttributeDeclaration(attribute);
				}
			}
			GenerateAttributeDeclarationsEnd(attributes);
			base.Output.Write(" ");
			switch (lineHandling)
			{
			case LineHandling.ContinueLine:
				ContinueOnNewLine("");
				break;
			case LineHandling.NewLine:
				base.Output.WriteLine();
				break;
			}
		}

		protected override void OutputAttributeArgument(CodeAttributeArgument argument)
		{
			string name = argument.Name;
			if (name != null && name.Length > 0)
			{
				base.Output.Write(name);
				base.Output.Write(":=");
			}
			GenerateExpression(argument.Value);
		}

		private void OutputAttributeDeclaration(CodeAttributeDeclaration attribute)
		{
			base.Output.Write(attribute.Name.Replace('+', '.'));
			base.Output.Write('(');
			IEnumerator enumerator = attribute.Arguments.GetEnumerator();
			if (enumerator.MoveNext())
			{
				CodeAttributeArgument arg = (CodeAttributeArgument)enumerator.Current;
				OutputAttributeArgument(arg);
				while (enumerator.MoveNext())
				{
					base.Output.Write(", ");
					arg = (CodeAttributeArgument)enumerator.Current;
					OutputAttributeArgument(arg);
				}
			}
			base.Output.Write(')');
		}

		protected override void OutputDirection(FieldDirection direction)
		{
			switch (direction)
			{
			case FieldDirection.In:
				base.Output.Write("ByVal ");
				break;
			case FieldDirection.Out:
			case FieldDirection.Ref:
				base.Output.Write("ByRef ");
				break;
			}
		}

		protected override void OutputFieldScopeModifier(MemberAttributes attributes)
		{
			switch (attributes & MemberAttributes.ScopeMask)
			{
			case MemberAttributes.Static:
				base.Output.Write("Shared ");
				break;
			case MemberAttributes.Const:
				base.Output.Write("Const ");
				break;
			}
		}

		private void OutputImplementationTypes(CodeTypeReferenceCollection implementationTypes, string member)
		{
			IEnumerator enumerator = implementationTypes.GetEnumerator();
			if (enumerator.MoveNext())
			{
				base.Output.Write(" Implements ");
				CodeTypeReference typeRef = (CodeTypeReference)enumerator.Current;
				OutputType(typeRef);
				base.Output.Write('.');
				OutputIdentifier(member);
				while (enumerator.MoveNext())
				{
					base.Output.Write(" , ");
					typeRef = (CodeTypeReference)enumerator.Current;
					OutputType(typeRef);
					base.Output.Write('.');
					OutputIdentifier(member);
				}
			}
		}

		protected override void OutputMemberAccessModifier(MemberAttributes attributes)
		{
			switch (attributes & MemberAttributes.AccessMask)
			{
			case MemberAttributes.Assembly:
			case MemberAttributes.FamilyAndAssembly:
				base.Output.Write("Friend ");
				break;
			case MemberAttributes.Family:
				base.Output.Write("Protected ");
				break;
			case MemberAttributes.FamilyOrAssembly:
				base.Output.Write("Protected Friend ");
				break;
			case MemberAttributes.Private:
				base.Output.Write("Private ");
				break;
			case MemberAttributes.Public:
				base.Output.Write("Public ");
				break;
			}
		}

		private void OutputVTableModifier(MemberAttributes attributes)
		{
			if ((attributes & MemberAttributes.VTableMask) == MemberAttributes.New)
			{
				base.Output.Write("Shadows ");
			}
		}

		protected override void OutputMemberScopeModifier(MemberAttributes attributes)
		{
			switch (attributes & MemberAttributes.ScopeMask)
			{
			case MemberAttributes.Abstract:
				base.Output.Write("MustOverride ");
				break;
			case MemberAttributes.Static:
				base.Output.Write("Shared ");
				break;
			case MemberAttributes.Override:
				base.Output.Write("Overrides ");
				break;
			case MemberAttributes.Overloaded:
			{
				base.Output.Write("Overloads ");
				MemberAttributes memberAttributes2 = attributes & MemberAttributes.AccessMask;
				if (memberAttributes2 == MemberAttributes.Public || memberAttributes2 == MemberAttributes.Family)
				{
					base.Output.Write("Overridable ");
				}
				break;
			}
			default:
			{
				MemberAttributes memberAttributes = attributes & MemberAttributes.AccessMask;
				if (memberAttributes == MemberAttributes.Public || memberAttributes == MemberAttributes.Family || memberAttributes == MemberAttributes.Assembly)
				{
					base.Output.Write("Overridable ");
				}
				break;
			}
			case MemberAttributes.Final:
				break;
			}
		}

		protected override void OutputOperator(CodeBinaryOperatorType op)
		{
			switch (op)
			{
			case CodeBinaryOperatorType.Add:
				base.Output.Write("+");
				break;
			case CodeBinaryOperatorType.Subtract:
				base.Output.Write("-");
				break;
			case CodeBinaryOperatorType.Multiply:
				base.Output.Write("*");
				break;
			case CodeBinaryOperatorType.Divide:
				base.Output.Write("/");
				break;
			case CodeBinaryOperatorType.Modulus:
				base.Output.Write("Mod");
				break;
			case CodeBinaryOperatorType.Assign:
				base.Output.Write("=");
				break;
			case CodeBinaryOperatorType.IdentityInequality:
				base.Output.Write("<>");
				break;
			case CodeBinaryOperatorType.IdentityEquality:
				base.Output.Write("Is");
				break;
			case CodeBinaryOperatorType.ValueEquality:
				base.Output.Write("=");
				break;
			case CodeBinaryOperatorType.BitwiseOr:
				base.Output.Write("Or");
				break;
			case CodeBinaryOperatorType.BitwiseAnd:
				base.Output.Write("And");
				break;
			case CodeBinaryOperatorType.BooleanOr:
				base.Output.Write("OrElse");
				break;
			case CodeBinaryOperatorType.BooleanAnd:
				base.Output.Write("AndAlso");
				break;
			case CodeBinaryOperatorType.LessThan:
				base.Output.Write("<");
				break;
			case CodeBinaryOperatorType.LessThanOrEqual:
				base.Output.Write("<=");
				break;
			case CodeBinaryOperatorType.GreaterThan:
				base.Output.Write(">");
				break;
			case CodeBinaryOperatorType.GreaterThanOrEqual:
				base.Output.Write(">=");
				break;
			}
		}

		private void OutputTypeAttributes(CodeTypeDeclaration declaration)
		{
			TextWriter textWriter = base.Output;
			TypeAttributes typeAttributes = declaration.TypeAttributes;
			if (declaration.IsPartial)
			{
				textWriter.Write("Partial ");
			}
			switch (typeAttributes & TypeAttributes.VisibilityMask)
			{
			case TypeAttributes.Public:
			case TypeAttributes.NestedPublic:
				textWriter.Write("Public ");
				break;
			case TypeAttributes.NestedPrivate:
				textWriter.Write("Private ");
				break;
			case TypeAttributes.NotPublic:
			case TypeAttributes.NestedAssembly:
			case TypeAttributes.NestedFamANDAssem:
				textWriter.Write("Friend ");
				break;
			case TypeAttributes.NestedFamily:
				textWriter.Write("Protected ");
				break;
			case TypeAttributes.VisibilityMask:
				textWriter.Write("Protected Friend ");
				break;
			}
			if (declaration.IsStruct)
			{
				textWriter.Write("Structure ");
				return;
			}
			if (declaration.IsEnum)
			{
				textWriter.Write("Enum ");
				return;
			}
			if ((typeAttributes & TypeAttributes.ClassSemanticsMask) != TypeAttributes.NotPublic)
			{
				textWriter.Write("Interface ");
				return;
			}
			if ((typeAttributes & TypeAttributes.Sealed) != TypeAttributes.NotPublic)
			{
				textWriter.Write("NotInheritable ");
			}
			if ((typeAttributes & TypeAttributes.Abstract) != TypeAttributes.NotPublic)
			{
				textWriter.Write("MustInherit ");
			}
			textWriter.Write("Class ");
		}

		private void OutputTypeParameters(CodeTypeParameterCollection parameters)
		{
			int count = parameters.Count;
			if (count == 0)
			{
				return;
			}
			base.Output.Write("(Of ");
			for (int i = 0; i < count; i++)
			{
				if (i > 0)
				{
					base.Output.Write(", ");
				}
				CodeTypeParameter codeTypeParameter = parameters[i];
				base.Output.Write(codeTypeParameter.Name);
				OutputTypeParameterConstraints(codeTypeParameter);
			}
			base.Output.Write(')');
		}

		private void OutputTypeParameterConstraints(CodeTypeParameter parameter)
		{
			int num = parameter.Constraints.Count + (parameter.HasConstructorConstraint ? 1 : 0);
			if (num == 0)
			{
				return;
			}
			base.Output.Write(" As ");
			if (num > 1)
			{
				base.Output.Write(" {");
			}
			for (int i = 0; i < parameter.Constraints.Count; i++)
			{
				if (i > 0)
				{
					base.Output.Write(", ");
				}
				OutputType(parameter.Constraints[i]);
			}
			if (parameter.HasConstructorConstraint)
			{
				if (num > 1)
				{
					base.Output.Write(", ");
				}
				base.Output.Write("New");
			}
			if (num > 1)
			{
				base.Output.Write("}");
			}
		}

		protected override void OutputTypeNamePair(CodeTypeReference typeRef, string name)
		{
			if (name.Length == 0)
			{
				name = "__exception";
			}
			base.Output.Write(CreateEscapedIdentifier(name) + " As " + GetTypeOutput(typeRef));
		}

		protected override void OutputType(CodeTypeReference type)
		{
			base.Output.Write(GetTypeOutput(type));
		}

		protected override string QuoteSnippetString(string value)
		{
			StringBuilder stringBuilder = new StringBuilder(value.Length);
			stringBuilder.Append("\"");
			bool flag = true;
			for (int i = 0; i < value.Length; i++)
			{
				if (value[i] == '"')
				{
					if (!flag)
					{
						stringBuilder.Append("&\"");
						flag = true;
					}
					stringBuilder.Append(value[i]);
					stringBuilder.Append(value[i]);
					continue;
				}
				if (value[i] >= ' ')
				{
					if (!flag)
					{
						stringBuilder.Append("&\"");
						flag = true;
					}
					stringBuilder.Append(value[i]);
					continue;
				}
				if (flag)
				{
					stringBuilder.Append("\"");
					flag = false;
				}
				stringBuilder.Append("&Microsoft.VisualBasic.ChrW(");
				stringBuilder.Append((int)value[i]);
				stringBuilder.Append(")");
			}
			if (flag)
			{
				stringBuilder.Append("\"");
			}
			return stringBuilder.ToString();
		}

		private void GenerateMemberReferenceExpression(CodeExpression targetObject, string memberName)
		{
			GenerateExpression(targetObject);
			base.Output.Write('.');
			base.Output.Write(memberName);
		}

		protected override string CreateEscapedIdentifier(string value)
		{
			for (int i = 0; i < Keywords.Length; i++)
			{
				if (value.ToLower().Equals(Keywords[i].ToLower()))
				{
					return "[" + value + "]";
				}
			}
			return value;
		}

		protected override string CreateValidIdentifier(string value)
		{
			for (int i = 0; i < Keywords.Length; i++)
			{
				if (value.ToLower().Equals(Keywords[i].ToLower()))
				{
					return "_" + value;
				}
			}
			return value;
		}

		protected override string GetTypeOutput(CodeTypeReference type)
		{
			CodeTypeReference arrayElementType = type.ArrayElementType;
			string text;
			if (arrayElementType != null)
			{
				text = GetTypeOutput(arrayElementType);
			}
			else
			{
				switch (type.BaseType)
				{
				case "System.DateTime":
					text = "Date";
					break;
				case "System.Decimal":
					text = "Decimal";
					break;
				case "System.Double":
					text = "Double";
					break;
				case "System.Single":
					text = "Single";
					break;
				case "System.Byte":
					text = "Byte";
					break;
				case "System.Int32":
					text = "Integer";
					break;
				case "System.Int64":
					text = "Long";
					break;
				case "System.Int16":
					text = "Short";
					break;
				case "System.Boolean":
					text = "Boolean";
					break;
				case "System.Char":
					text = "Char";
					break;
				case "System.String":
					text = "String";
					break;
				case "System.Object":
					text = "Object";
					break;
				case "System.SByte":
					text = "SByte";
					break;
				case "System.UInt16":
					text = "UShort";
					break;
				case "System.UInt32":
					text = "UInteger";
					break;
				case "System.UInt64":
					text = "ULong";
					break;
				default:
					text = type.BaseType.Replace('+', '.');
					text = CreateEscapedIdentifier(text);
					break;
				}
			}
			int arrayRank = type.ArrayRank;
			if (arrayRank > 0)
			{
				text += "(";
				for (arrayRank--; arrayRank > 0; arrayRank--)
				{
					text += ",";
				}
				text += ")";
			}
			return text;
		}

		protected override bool IsValidIdentifier(string identifier)
		{
			for (int i = 0; i < Keywords.Length; i++)
			{
				if (identifier.ToLower().Equals(Keywords[i].ToLower()))
				{
					return false;
				}
			}
			return true;
		}

		protected override bool Supports(GeneratorSupport supports)
		{
			return true;
		}

		private bool IsOverloaded(CodeMemberProperty property, CodeTypeDeclaration type)
		{
			if ((property.Attributes & MemberAttributes.Overloaded) == MemberAttributes.Overloaded)
			{
				return true;
			}
			foreach (CodeTypeMember member in type.Members)
			{
				CodeMemberProperty codeMemberProperty = member as CodeMemberProperty;
				if (codeMemberProperty != null && codeMemberProperty != property && codeMemberProperty.Name == property.Name && codeMemberProperty.PrivateImplementationType == null)
				{
					return true;
				}
			}
			return false;
		}

		private bool IsOverloaded(CodeMemberMethod method, CodeTypeDeclaration type)
		{
			if ((method.Attributes & MemberAttributes.Overloaded) == MemberAttributes.Overloaded)
			{
				return true;
			}
			foreach (CodeTypeMember member in type.Members)
			{
				CodeMemberMethod codeMemberMethod = member as CodeMemberMethod;
				if (codeMemberMethod != null && !(codeMemberMethod is CodeTypeConstructor) && !(codeMemberMethod is CodeConstructor) && codeMemberMethod != method && codeMemberMethod.Name == method.Name && codeMemberMethod.PrivateImplementationType == null)
				{
					return true;
				}
			}
			return false;
		}

		private string GetEventName(CodeMemberEvent evt)
		{
			if (evt.PrivateImplementationType == null)
			{
				return evt.Name;
			}
			return evt.PrivateImplementationType.BaseType.Replace('.', '_') + "_" + evt.Name;
		}

		private string GetMethodName(CodeMemberMethod method)
		{
			if (method.PrivateImplementationType == null)
			{
				return method.Name;
			}
			return method.PrivateImplementationType.BaseType.Replace('.', '_') + "_" + method.Name;
		}

		private string GetPropertyName(CodeMemberProperty property)
		{
			if (property.PrivateImplementationType == null)
			{
				return property.Name;
			}
			return property.PrivateImplementationType.BaseType.Replace('.', '_') + "_" + property.Name;
		}

		private static bool IsAbstract(MemberAttributes attributes)
		{
			return (attributes & MemberAttributes.ScopeMask) == MemberAttributes.Abstract;
		}

		private void GenerateAssemblyAttributes()
		{
			OutputAttributes(assemblyCustomAttributes, "Assembly: ", LineHandling.NewLine);
			assemblyCustomAttributes = null;
		}
	}
}
