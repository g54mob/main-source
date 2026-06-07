using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using NJsonSchema.References;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace NJsonSchema.Infrastructure
{
	public class JsonSchemaSerialization
	{
		[ThreadStatic]
		private static SchemaType _currentSchemaType;

		[ThreadStatic]
		private static bool _isWriting;

		[ThreadStatic]
		private static JsonSerializerSettings _currentSerializerSettings;

		public static SchemaType CurrentSchemaType
		{
			get
			{
				return _currentSchemaType;
			}
			private set
			{
				_currentSchemaType = value;
			}
		}

		public static JsonSerializerSettings CurrentSerializerSettings
		{
			get
			{
				return _currentSerializerSettings;
			}
			private set
			{
				_currentSerializerSettings = value;
			}
		}

		public static bool IsWriting
		{
			get
			{
				return _isWriting;
			}
			private set
			{
				_isWriting = value;
			}
		}

		public static string ToJson(object obj, SchemaType schemaType, IContractResolver contractResolver, Formatting formatting)
		{
			IsWriting = false;
			CurrentSchemaType = schemaType;
			JsonSchemaReferenceUtilities.UpdateSchemaReferencePaths(obj, removeExternalReferences: false, contractResolver);
			IsWriting = false;
			CurrentSerializerSettings = new JsonSerializerSettings
			{
				ContractResolver = contractResolver
			};
			string result = JsonConvert.SerializeObject(obj, formatting, CurrentSerializerSettings);
			CurrentSerializerSettings = null;
			CurrentSchemaType = SchemaType.JsonSchema;
			return result;
		}

		[Obsolete("Use FromJsonAsync with cancellation token instead.")]
		public static Task<T> FromJsonAsync<T>(string json, SchemaType schemaType, string documentPath, Func<T, JsonReferenceResolver> referenceResolverFactory, IContractResolver contractResolver)
		{
			return FromJsonAsync(json, schemaType, documentPath, referenceResolverFactory, contractResolver, CancellationToken.None);
		}

		public static Task<T> FromJsonAsync<T>(string json, SchemaType schemaType, string documentPath, Func<T, JsonReferenceResolver> referenceResolverFactory, IContractResolver contractResolver, CancellationToken cancellationToken = default(CancellationToken))
		{
			Func<T> loader = () => FromJson<T>(json, contractResolver);
			return FromJsonWithLoaderAsync(loader, schemaType, documentPath, referenceResolverFactory, contractResolver, cancellationToken);
		}

		public static Task<T> FromJsonAsync<T>(Stream stream, SchemaType schemaType, string documentPath, Func<T, JsonReferenceResolver> referenceResolverFactory, IContractResolver contractResolver, CancellationToken cancellationToken = default(CancellationToken))
		{
			Func<T> loader = () => FromJson<T>(stream, contractResolver);
			return FromJsonWithLoaderAsync(loader, schemaType, documentPath, referenceResolverFactory, contractResolver, cancellationToken);
		}

		private static async Task<T> FromJsonWithLoaderAsync<T>(Func<T> loader, SchemaType schemaType, string documentPath, Func<T, JsonReferenceResolver> referenceResolverFactory, IContractResolver contractResolver, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			CurrentSchemaType = schemaType;
			try
			{
				T schema = loader();
				if (schema is IDocumentPathProvider documentPathProvider)
				{
					documentPathProvider.DocumentPath = documentPath;
				}
				JsonReferenceResolver jsonReferenceResolver = referenceResolverFactory(schema);
				if (schema is IJsonReference schema2 && !string.IsNullOrEmpty(documentPath))
				{
					jsonReferenceResolver.AddDocumentReference(documentPath, schema2);
				}
				await JsonSchemaReferenceUtilities.UpdateSchemaReferencesAsync(schema, jsonReferenceResolver, contractResolver, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				return schema;
			}
			finally
			{
				CurrentSchemaType = SchemaType.JsonSchema;
			}
		}

		public static T FromJson<T>(string json, IContractResolver contractResolver)
		{
			IsWriting = true;
			UpdateCurrentSerializerSettings<T>(contractResolver);
			try
			{
				return JsonConvert.DeserializeObject<T>(json, CurrentSerializerSettings);
			}
			finally
			{
				CurrentSerializerSettings = null;
			}
		}

		public static T FromJson<T>(Stream stream, IContractResolver contractResolver)
		{
			IsWriting = true;
			UpdateCurrentSerializerSettings<T>(contractResolver);
			try
			{
				using StreamReader reader = new StreamReader(stream);
				using JsonTextReader reader2 = new JsonTextReader(reader);
				JsonSerializer jsonSerializer = JsonSerializer.Create(CurrentSerializerSettings);
				return jsonSerializer.Deserialize<T>(reader2);
			}
			finally
			{
				CurrentSerializerSettings = null;
			}
		}

		private static void UpdateCurrentSerializerSettings<T>(IContractResolver contractResolver)
		{
			CurrentSerializerSettings = new JsonSerializerSettings
			{
				ContractResolver = contractResolver,
				MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
				ConstructorHandling = ConstructorHandling.Default,
				ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
				PreserveReferencesHandling = PreserveReferencesHandling.None
			};
		}
	}
}
