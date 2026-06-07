using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Namotion.Reflection.Infrastructure;

namespace Namotion.Reflection
{
	public static class XmlDocsExtensions
	{
		private static readonly ConcurrentDictionary<string, CachingXDocument?> Cache = new ConcurrentDictionary<string, CachingXDocument>(StringComparer.OrdinalIgnoreCase);

		private static readonly char[] ToXmlDocsContentTrimChars = new char[2] { '!', ':' };

		private static readonly char[] RemoveLineBreakWhiteSpacesTrimChars = new char[1] { '\n' };

		private static readonly Regex LineBreakRegex = new Regex("(\\n[ \\t]*)", RegexOptions.Compiled);

		private static readonly Regex runtimeConfigRegex = new Regex("\"((.*?)((\\\\\\\\)|(////))(.*?))\"", RegexOptions.IgnoreCase);

		internal static void ClearCache()
		{
			Cache.Clear();
		}

		public static string GetXmlDocsSummary(this CachedType type, XmlDocsOptions? options = null)
		{
			return type.Type.GetXmlDocsSummary(options);
		}

		public static string GetXmlDocsRemarks(this CachedType type, XmlDocsOptions? options = null)
		{
			return type.Type.GetXmlDocsRemarks(options);
		}

		public static string GetXmlDocsTag(this CachedType type, string tagName, XmlDocsOptions? options = null)
		{
			return type.Type.GetXmlDocsTag(tagName, options);
		}

		public static string GetXmlDocsSummary(this ContextualMemberInfo member, XmlDocsOptions? options = null)
		{
			return member.MemberInfo.GetXmlDocsSummary(options);
		}

		public static string GetXmlDocsRemarks(this ContextualMemberInfo member, XmlDocsOptions? options = null)
		{
			return member.MemberInfo.GetXmlDocsRemarks(options);
		}

		public static string GetXmlDocsTag(this ContextualMemberInfo member, string tagName, XmlDocsOptions? options = null)
		{
			return member.MemberInfo.GetXmlDocsTag(tagName, options);
		}

		public static string GetXmlDocs(this ContextualParameterInfo parameter, XmlDocsOptions? options = null)
		{
			return parameter.ParameterInfo.GetXmlDocs(options);
		}

		public static string GetXmlDocsSummary(this Type type, XmlDocsOptions? options = null)
		{
			return ((MemberInfo)type.GetTypeInfo()).GetXmlDocsTag("summary", options);
		}

		public static string GetXmlDocsRemarks(this Type type, XmlDocsOptions? options = null)
		{
			return ((MemberInfo)type.GetTypeInfo()).GetXmlDocsTag("remarks", options);
		}

		public static string GetXmlDocsTag(this Type type, string tagName, XmlDocsOptions? options = null)
		{
			return ((MemberInfo)type.GetTypeInfo()).GetXmlDocsTag(tagName, options);
		}

		public static string GetXmlDocsSummary(this MemberInfo member, XmlDocsOptions? options = null)
		{
			string xmlDocsTag = member.GetXmlDocsTag("summary", options);
			if (string.IsNullOrEmpty(xmlDocsTag) && member is PropertyInfo member2)
			{
				return member2.GetXmlDocsRecordPropertySummary(options);
			}
			return xmlDocsTag;
		}

		public static string GetXmlDocsRemarks(this MemberInfo member, XmlDocsOptions? options = null)
		{
			return member.GetXmlDocsTag("remarks", options);
		}

		public static XElement? GetXmlDocsElement(this MemberInfo member, XmlDocsOptions? options = null)
		{
			options = options ?? XmlDocsOptions.Default;
			if (!DynamicApis.SupportsXPathApis || !DynamicApis.SupportsFileApis || !DynamicApis.SupportsPathApis)
			{
				return null;
			}
			if (IsAssemblyIgnored(member.Module.Assembly.GetName(), options.ResolveExternalXmlDocs))
			{
				return null;
			}
			string xmlDocsPath = GetXmlDocsPath(member.Module.Assembly, options);
			return member.GetXmlDocsElement(xmlDocsPath, options);
		}

		public static XElement? GetXmlDocsElement(this MemberInfo member, string pathToXmlFile, XmlDocsOptions? options = null)
		{
			try
			{
				options = options ?? XmlDocsOptions.Default;
				if (!DynamicApis.SupportsXPathApis || !DynamicApis.SupportsFileApis || !DynamicApis.SupportsPathApis)
				{
					return null;
				}
				CachingXDocument cachingXDocument = TryGetXmlDocsDocument(member.Module.Assembly.GetName(), pathToXmlFile, options.ResolveExternalXmlDocs);
				if (cachingXDocument == null)
				{
					return null;
				}
				XElement xmlDocsElement = member.GetXmlDocsElement(cachingXDocument);
				member.ReplaceInheritdocElements(xmlDocsElement, options);
				return xmlDocsElement;
			}
			catch
			{
				return null;
			}
		}

		public static string GetXmlDocsTag(this MemberInfo member, string tagName, XmlDocsOptions? options = null)
		{
			options = options ?? XmlDocsOptions.Default;
			if (!DynamicApis.SupportsXPathApis || !DynamicApis.SupportsFileApis || !DynamicApis.SupportsPathApis)
			{
				return string.Empty;
			}
			if ((object)member == null)
			{
				throw new ArgumentNullException("member");
			}
			if (tagName == null)
			{
				throw new ArgumentNullException("tagName");
			}
			if (IsAssemblyIgnored(member.Module.Assembly.GetName(), options.ResolveExternalXmlDocs))
			{
				return string.Empty;
			}
			string xmlDocsPath = GetXmlDocsPath(member.Module.Assembly, options);
			return (member.GetXmlDocsElement(xmlDocsPath, options)?.Element(tagName)).ToXmlDocsContent(options);
		}

		public static string GetXmlDocsRecordPropertySummary(this PropertyInfo member, XmlDocsOptions? options = null)
		{
			options = options ?? XmlDocsOptions.Default;
			if (!DynamicApis.SupportsXPathApis || !DynamicApis.SupportsFileApis || !DynamicApis.SupportsPathApis)
			{
				return string.Empty;
			}
			if ((object)member == null)
			{
				throw new ArgumentNullException("member");
			}
			if (IsAssemblyIgnored(member.Module.Assembly.GetName(), options.ResolveExternalXmlDocs))
			{
				return string.Empty;
			}
			string xmlDocsPath = GetXmlDocsPath(member.Module.Assembly, options);
			XElement xElement = member.DeclaringType.GetTypeInfo().GetXmlDocsElement(xmlDocsPath, options)?.Elements("param")?.FirstOrDefault((XElement x) => x.Attribute("name")?.Value == member.Name);
			if (xElement == null)
			{
				return string.Empty;
			}
			return xElement.ToXmlDocsContent(options);
		}

		public static string GetXmlDocs(this ParameterInfo parameter, XmlDocsOptions? options = null)
		{
			options = options ?? XmlDocsOptions.Default;
			if (!DynamicApis.SupportsXPathApis || !DynamicApis.SupportsFileApis || !DynamicApis.SupportsPathApis)
			{
				return string.Empty;
			}
			if (IsAssemblyIgnored(parameter.Member.Module.Assembly.GetName(), options.ResolveExternalXmlDocs))
			{
				return string.Empty;
			}
			string xmlDocsPath = GetXmlDocsPath(parameter.Member.Module.Assembly, options);
			return parameter.GetXmlDocs(xmlDocsPath, options).ToXmlDocsContent(options);
		}

		public static XElement? GetXmlDocsElement(this ParameterInfo parameter, string pathToXmlFile, XmlDocsOptions? options = null)
		{
			try
			{
				if (pathToXmlFile == null || !DynamicApis.SupportsXPathApis || !DynamicApis.SupportsFileApis || !DynamicApis.SupportsPathApis)
				{
					return null;
				}
				return parameter.GetXmlDocs(pathToXmlFile, options ?? XmlDocsOptions.Default);
			}
			catch
			{
				return null;
			}
		}

		public static string ToXmlDocsContent(this XElement? element, XmlDocsOptions? options = null)
		{
			if (options == null)
			{
				options = XmlDocsOptions.Default;
			}
			if (element != null)
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (XNode item in element.Nodes())
				{
					if (item is XElement xElement)
					{
						if (xElement.Name == "see")
						{
							XAttribute xAttribute = xElement.Attribute("langword");
							if (xAttribute != null)
							{
								stringBuilder.Append(xAttribute.Value);
								continue;
							}
							if (!string.IsNullOrEmpty(xElement.Value))
							{
								stringBuilder.Append(xElement.Value);
								continue;
							}
							xAttribute = xElement.Attribute("cref");
							if (xAttribute != null)
							{
								string s = xAttribute.Value.Trim(ToXmlDocsContentTrimChars).Trim();
								s = s.FirstToken('(');
								s = s.LastToken('.');
								stringBuilder.Append(s);
							}
							else
							{
								xAttribute = xElement.Attribute("href");
								if (xAttribute != null)
								{
									stringBuilder.Append(xAttribute.Value);
								}
							}
						}
						else if (xElement.Name == "paramref")
						{
							stringBuilder.Append(xElement.Attribute("name")?.Value ?? xElement.Value);
						}
						else
						{
							stringBuilder.AppendFormattedElement(xElement, options.FormattingMode);
						}
					}
					else if (item is XText xText)
					{
						stringBuilder.Append(xText.Value);
					}
					else
					{
						stringBuilder.Append(item);
					}
				}
				return RemoveLineBreakWhiteSpaces(stringBuilder.ToString());
			}
			return string.Empty;
		}

		private static XElement? GetXmlDocs(this ParameterInfo parameter, string? pathToXmlFile, XmlDocsOptions options)
		{
			try
			{
				if (!DynamicApis.SupportsXPathApis || !DynamicApis.SupportsFileApis || !DynamicApis.SupportsPathApis)
				{
					return null;
				}
				CachingXDocument cachingXDocument = TryGetXmlDocsDocument(parameter.Member.Module.Assembly.GetName(), pathToXmlFile, options.ResolveExternalXmlDocs);
				if (cachingXDocument == null)
				{
					return null;
				}
				return parameter.GetXmlDocsElement(cachingXDocument, options);
			}
			catch
			{
				return null;
			}
		}

		private static CachingXDocument? TryGetXmlDocsDocument(AssemblyName assemblyName, string? pathToXmlFile, bool resolveExternalXmlDocs)
		{
			string cacheKey = GetCacheKey(assemblyName.FullName, resolveExternalXmlDocs);
			if (Cache.TryGetValue(cacheKey, out CachingXDocument value))
			{
				return value;
			}
			if (pathToXmlFile == null)
			{
				return null;
			}
			if (!DynamicApis.FileExists(pathToXmlFile))
			{
				Cache[cacheKey] = null;
				return null;
			}
			value = new CachingXDocument(pathToXmlFile);
			Cache[cacheKey] = value;
			return value;
		}

		private static bool IsAssemblyIgnored(AssemblyName assemblyName, bool resolveExternalXmlDocs)
		{
			if (Cache.TryGetValue(GetCacheKey(assemblyName.FullName, resolveExternalXmlDocs), out CachingXDocument value))
			{
				return value == null;
			}
			return false;
		}

		private static XElement? GetXmlDocsElement(this MemberInfo member, CachingXDocument xml)
		{
			string memberElementName = GetMemberElementName(member);
			return xml.GetXmlDocsElement(memberElementName);
		}

		internal static XElement? GetXmlDocsElement(this XDocument xml, string name)
		{
			return CachingXDocument.GetXmlDocsElement(xml, name);
		}

		private static XElement? GetXmlDocsElement(this ParameterInfo parameter, CachingXDocument xml, XmlDocsOptions options)
		{
			string memberElementName = GetMemberElementName(parameter.Member);
			XElement xmlDocsElement = xml.GetXmlDocsElement(memberElementName);
			if (xmlDocsElement != null)
			{
				parameter.Member.ReplaceInheritdocElements(xmlDocsElement, options);
				IEnumerable source = ((!parameter.IsRetval && !string.IsNullOrEmpty(parameter.Name)) ? (from x in xmlDocsElement.Elements("param")
					where x.Attribute("name")?.Value == parameter.Name
					select x) : xmlDocsElement.Elements("returns"));
				return source.OfType<XElement>().FirstOrDefault();
			}
			return null;
		}

		private static void ReplaceInheritdocElements(this MemberInfo member, XElement? element, XmlDocsOptions options)
		{
			if (element == null)
			{
				return;
			}
			foreach (XElement item in element.Nodes().ToList().OfType<XElement>())
			{
				if (!(item.Name.LocalName.ToLowerInvariant() == "inheritdoc"))
				{
					continue;
				}
				if (item.HasAttributes)
				{
					MemberTypes memberType = member.MemberType;
					if (memberType == MemberTypes.TypeInfo || memberType == MemberTypes.Property)
					{
						member.ProcessInheritDocTypeElements(item, options);
						continue;
					}
				}
				MemberInfo memberInfo = member.DeclaringType.GetTypeInfo().BaseType?.GetTypeInfo().DeclaredMembers.SingleOrDefault((MemberInfo m) => m.Name == member.Name);
				if (memberInfo != null)
				{
					XElement xmlDocsElement = memberInfo.GetXmlDocsElement(options);
					if (xmlDocsElement != null)
					{
						object[] content = xmlDocsElement.Nodes().OfType<object>().ToArray();
						item.ReplaceWith(content);
					}
					else
					{
						member.ProcessInheritdocInterfaceElements(item, options);
					}
				}
				else
				{
					member.ProcessInheritdocInterfaceElements(item, options);
				}
			}
		}

		private static void ProcessInheritdocInterfaceElements(this MemberInfo member, XElement child, XmlDocsOptions options)
		{
			if (member.DeclaringType.GetTypeInfo().ImplementedInterfaces == null)
			{
				return;
			}
			foreach (Type implementedInterface in member.DeclaringType.GetTypeInfo().ImplementedInterfaces)
			{
				MemberInfo memberInfo = implementedInterface?.GetTypeInfo().DeclaredMembers.SingleOrDefault((MemberInfo m) => m.Name == member.Name);
				if (memberInfo != null)
				{
					XElement xmlDocsElement = memberInfo.GetXmlDocsElement(options);
					if (xmlDocsElement != null)
					{
						object[] content = xmlDocsElement.Nodes().OfType<object>().ToArray();
						child.ReplaceWith(content);
					}
				}
			}
		}

		private static string RemoveLineBreakWhiteSpaces(string? documentation)
		{
			if (string.IsNullOrEmpty(documentation))
			{
				return string.Empty;
			}
			documentation = "\n" + documentation.Replace("\r", string.Empty).Trim(RemoveLineBreakWhiteSpacesTrimChars);
			string value = LineBreakRegex.Match(documentation).Value;
			documentation = documentation.Replace(value, "\n");
			return documentation.Trim(RemoveLineBreakWhiteSpacesTrimChars);
		}

		internal static string GetMemberElementName(dynamic member)
		{
			if ((object)member == null)
			{
				throw new ArgumentNullException("member");
			}
			if (member is MemberInfo memberInfo && memberInfo.DeclaringType != null && memberInfo.DeclaringType.GetTypeInfo().IsGenericType)
			{
				member = ((!(member is PropertyInfo propertyInfo)) ? member.Module.ResolveMember(member.MetadataToken) : propertyInfo.DeclaringType.GetRuntimeProperty(propertyInfo.Name));
			}
			Type type = ((object)member).GetType();
			string text;
			string text2;
			if (type.FullName.Contains(".Cecil."))
			{
				text = (type.IsAssignableToTypeName("TypeDefinition", TypeNameStyle.Name) ? member.FullName : (member.DeclaringType.FullName + "." + member.Name));
				text = text.Replace("/", ".").Replace('+', '.');
				text2 = ((!type.IsAssignableToTypeName("MethodDefinition", TypeNameStyle.Name)) ? (type.IsAssignableToTypeName("PropertyDefinition", TypeNameStyle.Name) ? "Property" : "TypeInfo") : (text.EndsWith("..ctor") ? "Constructor" : "Method"));
			}
			else
			{
				text = ((member is Type type2 && !string.IsNullOrEmpty(type.FullName)) ? type2.FullName.FirstToken('[') : (((string)member.DeclaringType.FullName).FirstToken('[') + "." + member.Name));
				text2 = (string)member.MemberType.ToString();
			}
			char c;
			switch (text2)
			{
			case "Constructor":
				text = text.Replace(".ctor", "#ctor");
				goto case "Method";
			case "Method":
			{
				c = 'M';
				Func<object, string> func = (dynamic p) => (!(p.ParameterType.ContainsGenericParameter ? true : false)) ? ((string)p.ParameterType.FullName) : ((ObjectExtensions.HasProperty(p.ParameterType, "GenericArguments") && p.ParameterType.GenericArguments.Count > 0) ? (((string)p.ParameterType.FullName).FirstToken('`') + "{" + string.Join(",", from object u in (ICollection)p.ParameterType.GenericArguments
					select "||" + u.Position) + "}") : ("||" + p.ParameterType.Position));
				IEnumerable<string> enumerable2;
				if (!(member is MethodBase))
				{
					IEnumerable<string> enumerable = (IEnumerable<string>)Enumerable.Select<object, string>(member.Parameters, func);
					enumerable2 = enumerable;
				}
				else
				{
					enumerable2 = ((MethodBase)member).GetParameters().Select(delegate(ParameterInfo x)
					{
						string text4 = x.ParameterType.FullName;
						if (text4 == null)
						{
							if (!((((dynamic)x.ParameterType).GenericTypeArguments.Length > 0) ? true : false))
							{
								return "||" + x.ParameterType.GenericParameterPosition;
							}
							text4 = x.ParameterType.Namespace + "." + x.ParameterType.Name.FirstToken('`') + "{" + string.Join(",", ((Type[])((dynamic)x.ParameterType).GenericTypeArguments).Select((Type a) => (!a.IsGenericParameter) ? (a.Namespace + "." + a.Name + "[[||0]]") : ("||" + a.GenericParameterPosition))) + "}";
						}
						return text4;
					});
				}
				IEnumerable<string> source = enumerable2;
				string text3 = string.Join(",", source.Select((string x) => Regex.Replace(x, "(`[0-9]+)|(, .*?PublicKeyToken=[0-9a-z]*)", string.Empty).Replace("],[", ",").Replace("||", "`")
					.Replace("[[", "{")
					.Replace("]]", "}")).ToArray());
				if (!string.IsNullOrEmpty(text3))
				{
					text = text + "(" + text3 + ")";
				}
				break;
			}
			case "Event":
				c = 'E';
				break;
			case "Field":
				c = 'F';
				break;
			case "NestedType":
				text = text.Replace('+', '.');
				goto case "TypeInfo";
			case "TypeInfo":
				c = 'T';
				break;
			case "Property":
				c = 'P';
				break;
			default:
				throw new ArgumentException("Unknown member type.", "member");
			}
			return string.Format("{0}:{1}", c, text.Replace("+", "."));
		}

		public static string? GetXmlDocsPath(Assembly? assembly, XmlDocsOptions options)
		{
			try
			{
				if (assembly == null)
				{
					return null;
				}
				AssemblyName name = assembly.GetName();
				if (string.IsNullOrEmpty(name.Name))
				{
					return null;
				}
				string cacheKey = GetCacheKey(name.FullName, options.ResolveExternalXmlDocs);
				if (Cache.ContainsKey(cacheKey))
				{
					return null;
				}
				try
				{
					string pathByOs;
					if (!string.IsNullOrEmpty(assembly.Location))
					{
						pathByOs = GetPathByOs(assembly, name);
						if (DynamicApis.FileExists(pathByOs))
						{
							return pathByOs;
						}
					}
					if (assembly.HasProperty("CodeBase"))
					{
						string codeBase = assembly.CodeBase;
						if (!string.IsNullOrEmpty(codeBase))
						{
							pathByOs = DynamicApis.PathCombine(DynamicApis.PathGetDirectoryName(codeBase.Replace("file:///", string.Empty)), name.Name + ".xml").Replace("file:\\", string.Empty);
							if (DynamicApis.FileExists(pathByOs))
							{
								return pathByOs;
							}
						}
					}
					object obj = Type.GetType("System.AppDomain")?.GetRuntimeProperty("CurrentDomain")?.GetValue(null);
					if (obj != null && obj.HasProperty("BaseDirectory"))
					{
						string text = obj.TryGetPropertyValue("BaseDirectory", "");
						if (!string.IsNullOrEmpty(text))
						{
							pathByOs = DynamicApis.PathCombine(text, name.Name + ".xml");
							if (DynamicApis.FileExists(pathByOs))
							{
								return pathByOs;
							}
							pathByOs = DynamicApis.PathCombine(text, "bin/" + name.Name + ".xml");
							if (DynamicApis.FileExists(pathByOs))
							{
								return pathByOs;
							}
						}
					}
					string path = DynamicApis.DirectoryGetCurrentDirectory();
					pathByOs = DynamicApis.PathCombine(path, assembly.GetName().Name + ".xml");
					if (DynamicApis.FileExists(pathByOs))
					{
						return pathByOs;
					}
					pathByOs = DynamicApis.PathCombine(path, "bin/" + assembly.GetName().Name + ".xml");
					if (DynamicApis.FileExists(pathByOs))
					{
						return pathByOs;
					}
					if (options.ResolveExternalXmlDocs)
					{
						dynamic val = typeof(Assembly).GetRuntimeMethod("GetExecutingAssembly", new Type[0])?.Invoke(null, new object[0]);
						if ((!string.IsNullOrEmpty(val?.Location)))
						{
							pathByOs = GetXmlDocsPathFromNuGetCacheOrDotNetSdk(DynamicApis.PathGetDirectoryName((string)val.Location), name);
							if (pathByOs != null && DynamicApis.FileExists(pathByOs))
							{
								return pathByOs;
							}
						}
					}
					Cache[cacheKey] = null;
					return null;
				}
				catch
				{
					Cache[cacheKey] = null;
					return null;
				}
			}
			catch
			{
				return null;
			}
		}

		private static void ProcessInheritDocTypeElements(this MemberInfo member, XElement child, XmlDocsOptions options)
		{
			string text = child.Attribute("cref")?.Value;
			if (text == null)
			{
				return;
			}
			MemberInfo referencedType = null;
			Assembly assembly = null;
			string text2 = ((text[0] != 'P') ? Regex.Match(text, "[A-Z]:(?<FullName>(?<Namespace>[a-zA-Z.]*)\\.(?<TypeName>[a-zA-Z]*))").Groups["FullName"].Value : Regex.Match(text, "(?<FullName>(?<FullTypeName>(?<AssemblyName>[a-zA-Z.]*)\\.(?<TypeName>[a-zA-Z]*))\\.(?<MemberName>[a-zA-Z]*))").Groups["FullTypeName"].Value);
			if ((object)assembly == null && text2 != null)
			{
				assembly = member.Module.Assembly;
				referencedType = assembly.GetType(text2);
				if ((object)referencedType == null)
				{
					Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
					foreach (Assembly assembly2 in assemblies)
					{
						if (text.Contains(assembly2.GetName().Name))
						{
							referencedType = GetTypeByXmlDocTypeName(text2, assembly2);
							if (referencedType != null)
							{
								assembly = assembly2;
								break;
							}
						}
					}
				}
			}
			if ((object)referencedType == null || (object)assembly == null)
			{
				return;
			}
			XElement xElement = TryGetXmlDocsDocument(assembly.GetName(), GetXmlDocsPath(assembly, options), resolveExternalXmlDocs: true)?.GetXmlDocsElement(text);
			if (xElement == null && referencedType.MemberType == MemberTypes.Property)
			{
				string xmlDocsPath = GetXmlDocsPath(member.Module.Assembly, options);
				if (xmlDocsPath != null)
				{
					xElement = referencedType.DeclaringType.GetTypeInfo().GetXmlDocsElement(xmlDocsPath, options)?.Elements("param")?.FirstOrDefault((XElement x) => x.Attribute("name")?.Value == referencedType.Name);
					child.ReplaceWith(xElement);
				}
			}
			else if (xElement != null)
			{
				object[] content = xElement.Nodes().OfType<object>().ToArray();
				child.ReplaceWith(content);
			}
		}

		private static Type? GetTypeByXmlDocTypeName(string xmlDocTypeName, Assembly assembly)
		{
			(from type in assembly.GetTypes()
				select new KeyValuePair<string, Type>(NormalizeTypeName(type.FullName), type)).ToDictionary((KeyValuePair<string, Type> x) => x.Key, (KeyValuePair<string, Type> x) => x.Value).TryGetValue(NormalizeTypeName(xmlDocTypeName), out var value);
			return value;
		}

		private static string NormalizeTypeName(string typeName)
		{
			return typeName.Replace(".", string.Empty).Replace("+", string.Empty);
		}

		private static string? GetPathByOs(dynamic? assembly, AssemblyName assemblyName)
		{
			if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
			{
				string text = (assembly as Assembly)?.GetCustomAttribute<AssemblyFileVersionAttribute>()?.Version;
				if (text == null)
				{
					return null;
				}
				Version version = new Version(text);
				string text2 = $"{version.Major}.{version.Minor}.{version.Build}";
				string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".nuget", "packages", assemblyName.Name, text2);
				if (!Directory.Exists(path))
				{
					return null;
				}
				return (from f in Directory.GetFiles(path, "*.xml", SearchOption.AllDirectories)
					orderby f descending
					select f).FirstOrDefault();
			}
			return XmlDocsExtensions.GetXmlAssemblyFilePathForWindows(assembly, assemblyName);
		}

		private static string GetXmlAssemblyFilePathForWindows(dynamic? assembly, AssemblyName assemblyName)
		{
			return DynamicApis.PathCombine(DynamicApis.PathGetDirectoryName((string)assembly.Location), assemblyName.Name + ".xml");
		}

		private static string? GetXmlDocsPathFromNuGetCacheOrDotNetSdk(string assemblyDirectory, AssemblyName assemblyName)
		{
			string[] source = DynamicApis.DirectoryGetFiles(assemblyDirectory, "*.runtimeconfig.dev.json");
			if (source.Any())
			{
				try
				{
					string input = DynamicApis.FileReadAllText(source.First());
					MatchCollection matchCollection = runtimeConfigRegex.Matches(input);
					if (matchCollection.Count > 0)
					{
						foreach (Match item in matchCollection)
						{
							string text = item.Groups[1].Value.Replace("\\\\", "/").Replace("//", "/").Replace("\\|arch|", "")
								.Replace("\\|tfm|", "")
								.Replace("/|arch|", "")
								.Replace("/|tfm|", "");
							if (DynamicApis.DirectoryExists(text))
							{
								try
								{
									string text2 = DynamicApis.PathCombine(text, assemblyName.Name + "/" + assemblyName.Version.ToString(3));
									if (DynamicApis.DirectoryExists(text2))
									{
										string text3 = (from f in DynamicApis.DirectoryGetAllFiles(text2, assemblyName.Name + ".xml")
											orderby f descending
											select f).FirstOrDefault();
										if (text3 != null)
										{
											return text3;
										}
									}
								}
								catch
								{
								}
							}
							if (!text.Contains("/dotnet/sdk"))
							{
								continue;
							}
							while ((text = DynamicApis.PathGetDirectoryName(text).Replace('\\', '/')) != null)
							{
								if (!text.EndsWith("/dotnet"))
								{
									continue;
								}
								try
								{
									text = DynamicApis.PathCombine(text, "packs");
									string search = "/" + assemblyName.Version.ToString(2);
									string text4 = (from f in DynamicApis.DirectoryGetAllFiles(text, assemblyName.Name + ".xml")
										where f.Replace('\\', '/').Contains(search)
										orderby f descending
										select f).FirstOrDefault();
									if (text4 != null)
									{
										return text4;
									}
								}
								catch
								{
								}
								break;
							}
						}
					}
				}
				catch
				{
				}
			}
			string text5 = DynamicApis.PathCombine(assemblyDirectory, "../../obj/project.nuget.cache");
			if (DynamicApis.FileExists(text5))
			{
				return GetXmlDocsPathFromNuGetCacheFile(text5, assemblyName);
			}
			text5 = DynamicApis.PathCombine(assemblyDirectory, "../../../obj/project.nuget.cache");
			if (DynamicApis.FileExists(text5))
			{
				return GetXmlDocsPathFromNuGetCacheFile(text5, assemblyName);
			}
			return null;
		}

		private static string? GetXmlDocsPathFromNuGetCacheFile(string nuGetCacheFile, AssemblyName assemblyName)
		{
			try
			{
				MatchCollection matchCollection = Regex.Matches(DynamicApis.FileReadAllText(nuGetCacheFile), "\"((.*?)" + assemblyName.Name + "((\\\\\\\\)|(////))" + assemblyName.Version.ToString(3) + ")((\\\\\\\\)|(////))(.*?)\"", RegexOptions.IgnoreCase);
				if (matchCollection.Count > 0)
				{
					string[] source = DynamicApis.DirectoryGetAllFiles(matchCollection[0].Groups[1].Value.Replace("\\\\", "\\").Replace("//", "/"), assemblyName.Name + ".xml");
					if (source.Any())
					{
						return source.Last();
					}
				}
				return null;
			}
			catch
			{
				return null;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static string GetCacheKey(string assemblyFullName, bool resolveExternalXmlDocs)
		{
			return $"{assemblyFullName}:{resolveExternalXmlDocs}";
		}
	}
}
