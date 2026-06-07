using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NJsonSchema.Infrastructure;
using NJsonSchema.References;
using Namotion.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace NJsonSchema
{
	public class JsonReferenceResolver
	{
		private readonly JsonSchemaAppender _schemaAppender;

		private readonly Dictionary<string, IJsonReference> _resolvedObjects = new Dictionary<string, IJsonReference>();

		public JsonReferenceResolver(JsonSchemaAppender schemaAppender)
		{
			_schemaAppender = schemaAppender;
		}

		public static Func<JsonSchema, JsonReferenceResolver> CreateJsonReferenceResolverFactory(ITypeNameGenerator typeNameGenerator)
		{
			return ReferenceResolverFactory;
			JsonReferenceResolver ReferenceResolverFactory(JsonSchema schema)
			{
				return new JsonReferenceResolver(new JsonSchemaAppender(schema, typeNameGenerator));
			}
		}

		public void AddDocumentReference(string documentPath, IJsonReference schema)
		{
			_resolvedObjects[documentPath.Contains("://") ? documentPath : DynamicApis.GetFullPath(documentPath)] = schema;
		}

		public async Task<IJsonReference> ResolveReferenceAsync(object rootObject, string jsonPath, Type targetType, IContractResolver contractResolver, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await ResolveReferenceAsync(rootObject, jsonPath, targetType, contractResolver, append: true, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<IJsonReference> ResolveReferenceWithoutAppendAsync(object rootObject, string jsonPath, Type targetType, IContractResolver contractResolver, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await ResolveReferenceAsync(rootObject, jsonPath, targetType, contractResolver, append: false, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		public virtual IJsonReference ResolveDocumentReference(object rootObject, string jsonPath, Type targetType, IContractResolver contractResolver)
		{
			List<string> segments = jsonPath.Split(new char[1] { '/' }).Skip(1).ToList();
			IJsonReference jsonReference = ResolveDocumentReference(rootObject, segments, targetType, contractResolver, new HashSet<object>());
			if (jsonReference == null)
			{
				throw new InvalidOperationException("Could not resolve the path '" + jsonPath + "'.");
			}
			return jsonReference;
		}

		public virtual async Task<IJsonReference> ResolveFileReferenceAsync(string filePath, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await JsonSchema.FromFileAsync(filePath, (JsonSchema schema) => this, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		public virtual async Task<IJsonReference> ResolveUrlReferenceAsync(string url, CancellationToken cancellationToken = default(CancellationToken))
		{
			return await JsonSchema.FromUrlAsync(url, (JsonSchema schema) => this, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		private async Task<IJsonReference> ResolveReferenceAsync(object rootObject, string jsonPath, Type targetType, IContractResolver contractResolver, bool append, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (jsonPath == "#")
			{
				if (rootObject is IJsonReference)
				{
					return (IJsonReference)rootObject;
				}
				throw new InvalidOperationException("Could not resolve the JSON path '#' because the root object is not a JsonSchema4.");
			}
			if (jsonPath.StartsWith("#/"))
			{
				return ResolveDocumentReference(rootObject, jsonPath, targetType, contractResolver);
			}
			if (jsonPath.StartsWith("http://") || jsonPath.StartsWith("https://"))
			{
				return await ResolveUrlReferenceWithAlreadyResolvedCheckAsync(jsonPath, jsonPath, targetType, contractResolver, append, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			string text = ((rootObject is IDocumentPathProvider documentPathProvider) ? documentPathProvider.DocumentPath : null);
			if (text != null)
			{
				if (text.StartsWith("http://") || text.StartsWith("https://"))
				{
					string fullJsonPath = new Uri(new Uri(text), jsonPath).ToString();
					return await ResolveUrlReferenceWithAlreadyResolvedCheckAsync(fullJsonPath, jsonPath, targetType, contractResolver, append, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				string filePath = ResolveFilePath(text, jsonPath);
				return await ResolveFileReferenceWithAlreadyResolvedCheckAsync(filePath, targetType, contractResolver, jsonPath, append, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			throw new NotSupportedException("Could not resolve the JSON path '" + jsonPath + "' because no document path is available.");
		}

		public virtual string ResolveFilePath(string documentPath, string jsonPath)
		{
			string[] array = Regex.Split(jsonPath, "(?=#)");
			return DynamicApis.PathCombine(DynamicApis.PathGetDirectoryName(documentPath), array[0]);
		}

		private async Task<IJsonReference> ResolveFileReferenceWithAlreadyResolvedCheckAsync(string filePath, Type targetType, IContractResolver contractResolver, string jsonPath, bool append, CancellationToken cancellationToken)
		{
			_ = 1;
			try
			{
				string fullPath = DynamicApis.GetFullPath(filePath);
				string[] arr = Regex.Split(jsonPath, "(?=#)");
				fullPath = DynamicApis.HandleSubdirectoryRelativeReferences(fullPath, jsonPath);
				if (!_resolvedObjects.ContainsKey(fullPath))
				{
					IJsonReference jsonReference = await ResolveFileReferenceAsync(fullPath).ConfigureAwait(continueOnCapturedContext: false);
					jsonReference.DocumentPath = arr[0];
					_resolvedObjects[fullPath] = jsonReference;
				}
				IJsonReference referencedFile = _resolvedObjects[fullPath];
				IJsonReference jsonReference2 = ((arr.Length != 1) ? (await ResolveReferenceAsync(referencedFile, arr[1], targetType, contractResolver).ConfigureAwait(continueOnCapturedContext: false)) : referencedFile);
				IJsonReference jsonReference3 = jsonReference2;
				if (jsonReference3 is JsonSchema && append)
				{
					JsonSchema obj = _schemaAppender.RootObject as JsonSchema;
					if (obj == null || !obj.Definitions.Values.Contains(referencedFile))
					{
						string typeNameHint = jsonPath.Split('/', '\\').Last().Split(new char[1] { '.' })
							.First();
						_schemaAppender.AppendSchema((JsonSchema)jsonReference3, typeNameHint);
					}
				}
				return jsonReference3;
			}
			catch (Exception innerException)
			{
				throw new InvalidOperationException("Could not resolve the JSON path '" + jsonPath + "' within the file path '" + filePath + "'.", innerException);
			}
		}

		private async Task<IJsonReference> ResolveUrlReferenceWithAlreadyResolvedCheckAsync(string fullJsonPath, string jsonPath, Type targetType, IContractResolver contractResolver, bool append, CancellationToken cancellationToken)
		{
			_ = 1;
			try
			{
				string[] arr = fullJsonPath.Split(new char[1] { '#' });
				if (!_resolvedObjects.ContainsKey(arr[0]))
				{
					IJsonReference jsonReference = await ResolveUrlReferenceAsync(arr[0], cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					jsonReference.DocumentPath = arr[0];
					if (jsonReference is JsonSchema && append)
					{
						_schemaAppender.AppendSchema((JsonSchema)jsonReference, null);
					}
					_resolvedObjects[arr[0]] = jsonReference;
				}
				IJsonReference jsonReference2 = _resolvedObjects[arr[0]];
				return (arr.Length != 1) ? (await ResolveReferenceAsync(jsonReference2, "#" + arr[1], targetType, contractResolver, cancellationToken).ConfigureAwait(continueOnCapturedContext: false)) : jsonReference2;
			}
			catch (Exception innerException)
			{
				throw new InvalidOperationException("Could not resolve the JSON path '" + jsonPath + "' with the full JSON path '" + fullJsonPath + "'.", innerException);
			}
		}

		private IJsonReference ResolveDocumentReference(object obj, List<string> segments, Type targetType, IContractResolver contractResolver, HashSet<object> checkedObjects)
		{
			if (obj == null || obj is string || checkedObjects.Contains(obj))
			{
				return null;
			}
			if (obj is IJsonReference { Reference: not null } jsonReference)
			{
				IJsonReference jsonReference2 = ResolveDocumentReferenceWithoutDereferencing(jsonReference.Reference, segments, targetType, contractResolver, checkedObjects);
				if (jsonReference2 == null)
				{
					return ResolveDocumentReferenceWithoutDereferencing(obj, segments, targetType, contractResolver, checkedObjects);
				}
				return jsonReference2;
			}
			return ResolveDocumentReferenceWithoutDereferencing(obj, segments, targetType, contractResolver, checkedObjects);
		}

		private IJsonReference ResolveDocumentReferenceWithoutDereferencing(object obj, List<string> segments, Type targetType, IContractResolver contractResolver, HashSet<object> checkedObjects)
		{
			if (segments.Count == 0)
			{
				if (obj is IDictionary)
				{
					JsonSerializerSettings settings = new JsonSerializerSettings
					{
						ContractResolver = contractResolver
					};
					string value = JsonConvert.SerializeObject(obj, settings);
					return (IJsonReference)JsonConvert.DeserializeObject(value, targetType, settings);
				}
				return (IJsonReference)obj;
			}
			checkedObjects.Add(obj);
			string text = segments[0];
			if (obj is IDictionary dictionary)
			{
				if (dictionary.Contains(text))
				{
					return ResolveDocumentReference(dictionary[text], segments.Skip(1).ToList(), targetType, contractResolver, checkedObjects);
				}
			}
			else if (obj is IEnumerable)
			{
				if (int.TryParse(text, out var result))
				{
					object[] array = ((IEnumerable)obj).Cast<object>().ToArray();
					if (array.Length > result)
					{
						return ResolveDocumentReference(array[result], segments.Skip(1).ToList(), targetType, contractResolver, checkedObjects);
					}
				}
			}
			else
			{
				if (obj is IJsonExtensionObject jsonExtensionObject && jsonExtensionObject.ExtensionData?.ContainsKey(text) == true)
				{
					return ResolveDocumentReference(jsonExtensionObject.ExtensionData[text], segments.Skip(1).ToList(), targetType, contractResolver, checkedObjects);
				}
				foreach (ContextualAccessorInfo item in from p in obj.GetType().GetContextualAccessors()
					where p.AccessorType.GetInheritedAttribute<JsonIgnoreAttribute>() == null
					select p)
				{
					string name = item.GetName();
					if (name == text)
					{
						object value2 = item.GetValue(obj);
						return ResolveDocumentReference(value2, segments.Skip(1).ToList(), targetType, contractResolver, checkedObjects);
					}
				}
			}
			return null;
		}
	}
}
