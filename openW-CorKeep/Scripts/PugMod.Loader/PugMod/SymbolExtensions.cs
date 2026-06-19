using System.Collections.Immutable;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using UnityEngine;

namespace PugMod
{
	public static class SymbolExtensions
	{
		private static string ToFullNameIL(this ITypeSymbol symbol)
		{
			StringBuilder stringBuilder = new StringBuilder((symbol is INamedTypeSymbol namedTypeSymbol) ? string.Join(",", namedTypeSymbol.TypeArguments.Select((ITypeSymbol t) => t.ToFullNameIL())) : string.Empty);
			string value = ((symbol is IArrayTypeSymbol arrayTypeSymbol) ? (arrayTypeSymbol.ElementType.ToFullNameIL() + "[" + ((arrayTypeSymbol.Rank == 1) ? string.Empty : string.Join(",", from _ in Enumerable.Range(0, arrayTypeSymbol.Rank)
				select "0...")) + "]") : ((symbol is IFunctionPointerTypeSymbol functionPointerTypeSymbol) ? ("method " + functionPointerTypeSymbol.Signature.ReturnType.ToFullNameIL() + " *(" + string.Join(",", functionPointerTypeSymbol.Signature.Parameters.Select((IParameterSymbol p) => p.Type.ToFullNameIL())) + ")") : ((!(symbol is IPointerTypeSymbol pointerTypeSymbol)) ? symbol.MetadataName : (pointerTypeSymbol.PointedAtType.ToFullNameIL() + "*"))));
			StringBuilder stringBuilder2 = new StringBuilder(value);
			for (ISymbol containingSymbol = symbol.ContainingSymbol; containingSymbol != null; containingSymbol = containingSymbol.ContainingSymbol)
			{
				ISymbol symbol2 = containingSymbol;
				if (!(symbol2 is INamedTypeSymbol namedTypeSymbol2) || symbol is ITypeParameterSymbol)
				{
					if (symbol2 is INamespaceSymbol namespaceSymbol && !(symbol is ITypeParameterSymbol) && !namespaceSymbol.IsGlobalNamespace)
					{
						stringBuilder2.Insert(0, namespaceSymbol.MetadataName + ".");
					}
				}
				else
				{
					stringBuilder2.Insert(0, containingSymbol.MetadataName + "/");
					if (namedTypeSymbol2.TypeArguments.Length > 0)
					{
						string text = string.Join(",", namedTypeSymbol2.TypeArguments.Select((ITypeSymbol t) => t.ToFullNameIL()));
						if (stringBuilder.Length == 0)
						{
							stringBuilder.Append(text);
						}
						else
						{
							stringBuilder.Insert(0, text + ",");
						}
					}
				}
			}
			if (stringBuilder.Length > 0)
			{
				stringBuilder2.Append('<');
				stringBuilder2.Append(stringBuilder);
				stringBuilder2.Append('>');
			}
			return stringBuilder2.ToString();
		}

		public static string GetMethodAndParamsAsString(this IMethodSymbol methodSymbol)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(methodSymbol.Name);
			stringBuilder.Append($"_T{methodSymbol.TypeParameters.Length}");
			ImmutableArray<IParameterSymbol>.Enumerator enumerator = methodSymbol.Parameters.GetEnumerator();
			while (enumerator.MoveNext())
			{
				IParameterSymbol current = enumerator.Current;
				if (current.RefKind == RefKind.In && !methodSymbol.IsOverride)
				{
					stringBuilder.Append("_in");
				}
				else if (current.RefKind == RefKind.Out)
				{
					stringBuilder.Append("_out");
				}
				else if (current.RefKind == RefKind.Ref)
				{
					stringBuilder.Append("_ref");
				}
				string text = current.Type.ToFullNameIL();
				if (!string.IsNullOrEmpty(text))
				{
					stringBuilder.Append("_" + text);
					if (current.RefKind != RefKind.None)
					{
						stringBuilder.Append('&');
					}
					if (methodSymbol.IsOverride && current.RefKind == RefKind.In)
					{
						stringBuilder.Append(" modreq(System.Runtime.InteropServices.InAttribute)");
					}
					continue;
				}
				Debug.Log("Failed to get IL name for parameter " + current.Name);
				return "";
			}
			return stringBuilder.ToString();
		}
	}
}
