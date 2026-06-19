using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Unity.Entities;
using UnityEngine;

namespace PugMod
{
	public static class SourceGenPatch
	{
		private struct ReplaceNode
		{
			public SyntaxNode NodeToReplace;

			public SyntaxNode NewNode;
		}

		private static readonly SymbolDisplayFormat _fullNameDisplayFormat = new SymbolDisplayFormat(SymbolDisplayGlobalNamespaceStyle.Omitted, SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces, SymbolDisplayGenericsOptions.IncludeTypeParameters);

		private static readonly StringBuilder _stringBuilder = new StringBuilder();

		public static bool Patch(string identifier, List<string> sourceCodes, bool safetyCheck)
		{
			List<SyntaxTree> list = new List<SyntaxTree>(sourceCodes.Count);
			foreach (string sourceCode in sourceCodes)
			{
				list.Add(CSharpSyntaxTree.ParseText(sourceCode));
			}
			CSharpCompilation cSharpCompilation = CSharpCompilation.Create(identifier + "_SourceGenPatch", list, new PortableExecutableReference[1] { MetadataReference.CreateFromFile(typeof(Entity).Assembly.Location) });
			List<SemanticModel> list2 = new List<SemanticModel>(sourceCodes.Count);
			foreach (SyntaxTree item in list)
			{
				list2.Add(cSharpCompilation.GetSemanticModel(item));
			}
			List<ReplaceNode> list3 = new List<ReplaceNode>();
			for (int i = 0; i < sourceCodes.Count; i++)
			{
				SyntaxTree syntaxTree = list[i];
				SemanticModel semanticModel = list2[i];
				List<(string, MethodDeclarationSyntax)> list4 = new List<(string, MethodDeclarationSyntax)>();
				List<(string, PropertyDeclarationSyntax)> list5 = new List<(string, PropertyDeclarationSyntax)>();
				Dictionary<string, IMethodSymbol> dictionary = new Dictionary<string, IMethodSymbol>();
				Dictionary<string, IPropertySymbol> dictionary2 = new Dictionary<string, IPropertySymbol>();
				SyntaxNode root = syntaxTree.GetRoot();
				foreach (MethodDeclarationSyntax item2 in root.DescendantNodes().OfType<MethodDeclarationSyntax>())
				{
					AttributeSyntax attributeSyntax = item2.AttributeLists.SelectMany((AttributeListSyntax attr) => attr.Attributes).FirstOrDefault((AttributeSyntax attr) => attr.Name.ToString().Contains("DOTSCompilerPatchedMethod"));
					if (attributeSyntax != null)
					{
						if (!(item2.Parent is TypeDeclarationSyntax declarationSyntax))
						{
							Debug.Log("Method " + item2.Identifier.Text + " is not a member of a class");
							continue;
						}
						INamedTypeSymbol? declaredSymbol = semanticModel.GetDeclaredSymbol(declarationSyntax);
						string fullName = GetFullName(declaredSymbol);
						list4.Add((fullName + "/" + attributeSyntax.ArgumentList.Arguments[0].GetText().ToString().Trim('"'), item2));
						AddAllOriginalMethodsAndProperties(declaredSymbol, fullName, dictionary, dictionary2);
					}
				}
				foreach (PropertyDeclarationSyntax item3 in root.DescendantNodes().OfType<PropertyDeclarationSyntax>())
				{
					AttributeSyntax attributeSyntax2 = item3.AttributeLists.SelectMany((AttributeListSyntax attr) => attr.Attributes).FirstOrDefault((AttributeSyntax attr) => attr.Name.ToString().Contains("DOTSCompilerPatchedProperty"));
					if (attributeSyntax2 != null)
					{
						if (!(item3.Parent is TypeDeclarationSyntax declarationSyntax2))
						{
							Debug.Log("Property " + item3.Identifier.Text + " is not a member of a class");
							continue;
						}
						INamedTypeSymbol? declaredSymbol2 = semanticModel.GetDeclaredSymbol(declarationSyntax2);
						string fullName2 = GetFullName(declaredSymbol2);
						list5.Add((fullName2 + "/" + attributeSyntax2.ArgumentList.Arguments[0].GetText().ToString().Trim('"'), item3));
						AddAllOriginalMethodsAndProperties(declaredSymbol2, fullName2, dictionary, dictionary2);
					}
				}
				foreach (var (text, methodDeclarationSyntax) in list4)
				{
					if (!dictionary.TryGetValue(text, out var value))
					{
						Debug.Log("Couldn't find target method " + text);
						continue;
					}
					MethodDeclarationSyntax methodDeclarationSyntax2 = value.DeclaringSyntaxReferences.Select((SyntaxReference reference) => reference.GetSyntax()).OfType<MethodDeclarationSyntax>().FirstOrDefault();
					if (methodDeclarationSyntax2 == null)
					{
						Debug.Log("Couldn't find syntax node for target property " + text);
						continue;
					}
					Debug.Log("Replacing method " + text + " with " + methodDeclarationSyntax.Identifier.Text);
					MethodDeclarationSyntax newNode = methodDeclarationSyntax2.WithBody(methodDeclarationSyntax.Body);
					list3.Add(new ReplaceNode
					{
						NodeToReplace = methodDeclarationSyntax2,
						NewNode = newNode
					});
				}
				foreach (var (text2, propertyDeclarationSyntax) in list5)
				{
					if (!dictionary2.TryGetValue(text2, out var value2))
					{
						Debug.Log("Couldn't find target property " + text2);
						continue;
					}
					PropertyDeclarationSyntax propertyDeclarationSyntax2 = value2.DeclaringSyntaxReferences.Select((SyntaxReference reference) => reference.GetSyntax()).OfType<PropertyDeclarationSyntax>().FirstOrDefault();
					if (propertyDeclarationSyntax2 == null)
					{
						Debug.Log("Couldn't find syntax node for target property " + text2);
						continue;
					}
					Debug.Log("Replacing property " + text2 + " with " + propertyDeclarationSyntax.Identifier.Text);
					PropertyDeclarationSyntax newNode2 = propertyDeclarationSyntax2.WithAccessorList(propertyDeclarationSyntax.AccessorList).WithInitializer(propertyDeclarationSyntax.Initializer);
					list3.Add(new ReplaceNode
					{
						NodeToReplace = propertyDeclarationSyntax2,
						NewNode = newNode2
					});
				}
			}
			ReplaceNodesInAllTrees(list, sourceCodes, list3.Select((ReplaceNode x) => x.NodeToReplace).ToList(), list3.Select((ReplaceNode x) => x.NewNode).ToList());
			return true;
		}

		private static void ReplaceNodesInAllTrees(List<SyntaxTree> syntaxTrees, List<string> sourceCodes, List<SyntaxNode> nodesToReplace, List<SyntaxNode> newNodes)
		{
			for (int i = 0; i < syntaxTrees.Count; i++)
			{
				SyntaxNode root = syntaxTrees[i].GetRoot();
				SyntaxNode syntaxNode = root.ReplaceNodes(nodesToReplace, delegate(SyntaxNode originalNode, SyntaxNode updatedNode)
				{
					int num = nodesToReplace.IndexOf(originalNode);
					return (num == -1) ? updatedNode : newNodes[num];
				});
				if (root != syntaxNode)
				{
					syntaxTrees[i] = syntaxNode.SyntaxTree;
					sourceCodes[i] = syntaxNode.ToFullString();
				}
			}
		}

		private static void AddAllOriginalMethodsAndProperties(INamedTypeSymbol classSymbol, string classIdentifier, Dictionary<string, IMethodSymbol> methodLookup, Dictionary<string, IPropertySymbol> propertyLookup)
		{
			ImmutableArray<ISymbol>.Enumerator enumerator = classSymbol.GetMembers().GetEnumerator();
			while (enumerator.MoveNext())
			{
				ISymbol current = enumerator.Current;
				if (current is IMethodSymbol methodSymbol)
				{
					methodLookup.TryAdd(classIdentifier + "/" + methodSymbol.GetMethodAndParamsAsString(), methodSymbol);
				}
				if (current is IPropertySymbol propertySymbol)
				{
					propertyLookup.TryAdd(classIdentifier + "/" + GetPropertyName(propertySymbol), propertySymbol);
				}
			}
		}

		private static string GetFullName(ITypeSymbol typeSymbol)
		{
			return typeSymbol.ToDisplayString(_fullNameDisplayFormat);
		}

		private static string GetPropertyName(IPropertySymbol property)
		{
			return GetFullName(property.ContainingType).Replace('/', '.') + "." + property.Name;
		}

		private static string GetMethodNameAndParamsAsString(IMethodSymbol method)
		{
			_stringBuilder.Clear();
			StringBuilder stringBuilder = _stringBuilder;
			stringBuilder.Append(method.Name);
			stringBuilder.Append($"_T{method.TypeParameters.Length}");
			ImmutableArray<IParameterSymbol>.Enumerator enumerator = method.Parameters.GetEnumerator();
			while (enumerator.MoveNext())
			{
				IParameterSymbol current = enumerator.Current;
				if (current.Type.IsReferenceType)
				{
					switch (current.RefKind)
					{
					case RefKind.In:
						stringBuilder.Append("_in");
						break;
					case RefKind.Out:
						stringBuilder.Append("_out");
						break;
					case RefKind.Ref:
						stringBuilder.Append("_ref");
						break;
					default:
						Debug.Log($"unknown refkind for {current.Name}: {current.RefKind}");
						break;
					case RefKind.None:
						break;
					}
				}
				stringBuilder.Append("_" + CleanupParameterTypeName(GetFullName(current.Type)));
			}
			return stringBuilder.ToString();
		}

		private static string CleanupParameterTypeName(string typeName)
		{
			typeName = Regex.Replace(typeName, "System\\.Nullable`1<(.*)>", (Match m) => m.Groups[1].Value + "?");
			typeName = typeName.Replace("0...", string.Empty).Replace('/', '.').Replace("&", "")
				.Replace(" ", string.Empty);
			int num = typeName.IndexOf('`');
			if (num == -1)
			{
				return typeName;
			}
			int num2 = typeName.IndexOf('<');
			int index = num + 2;
			if (typeName[index] == '.' && num2 != -1)
			{
				int num3 = typeName.IndexOf('>');
				string[] array = typeName.Substring(num2 + 1, num3 - (num2 + 1)).Split(',');
				int num4 = 0;
				_stringBuilder.Clear();
				StringBuilder stringBuilder = _stringBuilder;
				Match[] array2 = Regex.Matches(typeName, "[.]*(?<genericTypeName>[a-zA-Z_0-9.]+)`(?<numTypeParameters>\\d+)*|[.]*(?<nonGenericTypeName>[a-zA-Z_0-9]+)(?=<)").ToArray();
				for (int num5 = 0; num5 < array2.Length; num5++)
				{
					Match obj = array2[num5];
					int num6 = 0;
					string value = null;
					string text = null;
					foreach (Group group in obj.Groups)
					{
						switch (group.Name)
						{
						case "numTypeParameters":
						{
							if (int.TryParse(group.Value, out var result))
							{
								num6 = result;
							}
							break;
						}
						case "genericTypeName":
							value = group.Value;
							break;
						case "nonGenericTypeName":
							text = group.Value;
							break;
						}
					}
					if (num5 > 0)
					{
						stringBuilder.Append('.');
					}
					if (!string.IsNullOrEmpty(value))
					{
						stringBuilder.Append(value);
						stringBuilder.Append('<');
						for (int num7 = num4; num7 < num4 + num6; num7++)
						{
							stringBuilder.Append(array[num7]);
							if (num7 < num4 + num6 - 1)
							{
								stringBuilder.Append(',');
							}
						}
						stringBuilder.Append('>');
						num4 += num6;
					}
					else if (!string.IsNullOrEmpty(text))
					{
						stringBuilder.Append(text ?? "");
					}
				}
				return stringBuilder.ToString();
			}
			if (num2 == -1)
			{
				return typeName;
			}
			return typeName.Remove(num, num2 - num);
		}
	}
}
