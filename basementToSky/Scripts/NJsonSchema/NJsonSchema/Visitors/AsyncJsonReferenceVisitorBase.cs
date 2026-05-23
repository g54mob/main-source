using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NJsonSchema.References;
using Namotion.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace NJsonSchema.Visitors
{
	public abstract class AsyncJsonReferenceVisitorBase
	{
		private readonly IContractResolver _contractResolver;

		protected AsyncJsonReferenceVisitorBase()
			: this(new DefaultContractResolver())
		{
		}

		protected AsyncJsonReferenceVisitorBase(IContractResolver contractResolver)
		{
			_contractResolver = contractResolver;
		}

		[Obsolete("VisitAsync is deprecated, please use VisitAsync with cancellation token insteaed.")]
		public virtual async Task VisitAsync(object obj)
		{
			await VisitAsync(obj, "#", null, new HashSet<object>(), delegate
			{
				throw new NotSupportedException("Cannot replace the root.");
			}, CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false);
		}

		public virtual async Task VisitAsync(object obj, CancellationToken cancellationToken)
		{
			await VisitAsync(obj, "#", null, new HashSet<object>(), delegate
			{
				throw new NotSupportedException("Cannot replace the root.");
			}, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		protected abstract Task<IJsonReference> VisitJsonReferenceAsync(IJsonReference reference, string path, string typeNameHint, CancellationToken cancellationToken);

		protected virtual async Task VisitAsync(object obj, string path, string typeNameHint, ISet<object> checkedObjects, Action<object> replacer, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			if (obj == null || checkedObjects.Contains(obj))
			{
				return;
			}
			checkedObjects.Add(obj);
			if (obj is IJsonReference reference)
			{
				IJsonReference jsonReference = await VisitJsonReferenceAsync(reference, path, typeNameHint, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				if (jsonReference != reference)
				{
					replacer(jsonReference);
					return;
				}
			}
			JsonSchema schema = obj as JsonSchema;
			if (schema != null)
			{
				if (schema.AdditionalItemsSchema != null)
				{
					await VisitAsync(schema.AdditionalItemsSchema, path + "/additionalItems", null, checkedObjects, delegate(object o)
					{
						schema.AdditionalItemsSchema = (JsonSchema)o;
					}, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				if (schema.AdditionalPropertiesSchema != null)
				{
					await VisitAsync(schema.AdditionalPropertiesSchema, path + "/additionalProperties", null, checkedObjects, delegate(object o)
					{
						schema.AdditionalPropertiesSchema = (JsonSchema)o;
					}, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				if (schema.Item != null)
				{
					await VisitAsync(schema.Item, path + "/items", null, checkedObjects, delegate(object o)
					{
						schema.Item = (JsonSchema)o;
					}, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				ObservableCollection<JsonSchema> items = schema._items;
				for (int i = 0; i < items.Count; i++)
				{
					int index = i;
					await VisitAsync(items[i], path + "/items[" + i + "]", null, checkedObjects, delegate(object o)
					{
						ReplaceOrDelete(items, index, (JsonSchema)o);
					}, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				ObservableCollection<JsonSchema> allOf = schema._allOf;
				for (int i = 0; i < allOf.Count; i++)
				{
					int index2 = i;
					await VisitAsync(allOf[i], path + "/allOf[" + i + "]", null, checkedObjects, delegate(object o)
					{
						ReplaceOrDelete(allOf, index2, (JsonSchema)o);
					}, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				ObservableCollection<JsonSchema> anyOf = schema._anyOf;
				for (int i = 0; i < anyOf.Count; i++)
				{
					int index3 = i;
					await VisitAsync(anyOf[i], path + "/anyOf[" + i + "]", null, checkedObjects, delegate(object o)
					{
						ReplaceOrDelete(anyOf, index3, (JsonSchema)o);
					}, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				ObservableCollection<JsonSchema> oneOf = schema._oneOf;
				for (int i = 0; i < oneOf.Count; i++)
				{
					int index4 = i;
					await VisitAsync(oneOf[i], path + "/oneOf[" + i + "]", null, checkedObjects, delegate(object o)
					{
						ReplaceOrDelete(oneOf, index4, (JsonSchema)o);
					}, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				if (schema.Not != null)
				{
					await VisitAsync(schema.Not, path + "/not", null, checkedObjects, delegate(object o)
					{
						schema.Not = (JsonSchema)o;
					}, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				if (schema.DictionaryKey != null)
				{
					await VisitAsync(schema.DictionaryKey, path + "/x-dictionaryKey", null, checkedObjects, delegate(object o)
					{
						schema.DictionaryKey = (JsonSchema)o;
					}, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				if (schema.DiscriminatorRaw != null)
				{
					await VisitAsync(schema.DiscriminatorRaw, path + "/discriminator", null, checkedObjects, delegate(object o)
					{
						schema.DiscriminatorRaw = o;
					}, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				KeyValuePair<string, JsonSchemaProperty>[] array = schema.Properties.ToArray();
				for (int i = 0; i < array.Length; i++)
				{
					KeyValuePair<string, JsonSchemaProperty> p = array[i];
					await VisitAsync(p.Value, path + "/properties/" + p.Key, p.Key, checkedObjects, delegate(object o)
					{
						schema.Properties[p.Key] = (JsonSchemaProperty)o;
					}, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				array = schema.PatternProperties.ToArray();
				for (int i = 0; i < array.Length; i++)
				{
					KeyValuePair<string, JsonSchemaProperty> p2 = array[i];
					await VisitAsync(p2.Value, path + "/patternProperties/" + p2.Key, null, checkedObjects, delegate(object o)
					{
						schema.PatternProperties[p2.Key] = (JsonSchemaProperty)o;
					}, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				KeyValuePair<string, JsonSchema>[] array2 = schema.Definitions.ToArray();
				for (int i = 0; i < array2.Length; i++)
				{
					KeyValuePair<string, JsonSchema> p3 = array2[i];
					await VisitAsync(p3.Value, path + "/definitions/" + p3.Key, p3.Key, checkedObjects, delegate(object o)
					{
						if (o != null)
						{
							schema.Definitions[p3.Key] = (JsonSchema)o;
						}
						else
						{
							schema.Definitions.Remove(p3.Key);
						}
					}, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			if (obj is string || obj is JToken || !(obj.GetType() != typeof(JsonSchema)))
			{
				return;
			}
			if (_contractResolver.ResolveContract(obj.GetType()) is JsonObjectContract jsonObjectContract)
			{
				foreach (JsonProperty property in jsonObjectContract.Properties.Where((JsonProperty jsonProperty) => (!(obj is JsonSchema) || !JsonSchema.JsonSchemaPropertiesCache.Contains(jsonProperty.UnderlyingName)) && !jsonProperty.Ignored && (jsonProperty.ShouldSerialize?.Invoke(obj) ?? true)))
				{
					object value = property.ValueProvider.GetValue(obj);
					if (value != null)
					{
						await VisitAsync(value, path + "/" + property.PropertyName, property.PropertyName, checkedObjects, delegate(object o)
						{
							property.ValueProvider.SetValue(obj, o);
						}, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					}
				}
				return;
			}
			IDictionary dictionary = obj as IDictionary;
			if (dictionary != null)
			{
				object[] array3 = dictionary.Keys.OfType<object>().ToArray();
				foreach (object key in array3)
				{
					await VisitAsync(dictionary[key], path + "/" + key, key.ToString(), checkedObjects, delegate(object o)
					{
						if (o != null)
						{
							dictionary[key] = (JsonSchema)o;
						}
						else
						{
							dictionary.Remove(key);
						}
					}, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				ContextualType contextualType = obj.GetType().ToContextualType();
				if (!contextualType.InheritedAttributes.OfType<JsonConverterAttribute>().Any())
				{
					return;
				}
				foreach (ContextualPropertyInfo property2 in from contextualPropertyInfo in contextualType.Type.GetContextualProperties()
					where contextualPropertyInfo.MemberInfo.DeclaringType == contextualType.Type && !contextualPropertyInfo.GetContextAttributes<JsonIgnoreAttribute>().Any()
					select contextualPropertyInfo)
				{
					object value2 = property2.GetValue(obj);
					if (value2 != null)
					{
						await VisitAsync(value2, path + "/" + property2.Name, property2.Name, checkedObjects, delegate(object o)
						{
							property2.SetValue(obj, o);
						}, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					}
				}
				return;
			}
			IList list = obj as IList;
			if (list != null)
			{
				object[] array3 = list.OfType<object>().ToArray();
				for (int i = 0; i < array3.Length; i++)
				{
					int index5 = i;
					await VisitAsync(array3[i], path + "[" + i + "]", null, checkedObjects, delegate(object o)
					{
						ReplaceOrDelete(list, index5, o);
					}, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			else
			{
				if (!(obj is IEnumerable source))
				{
					return;
				}
				object[] array3 = source.OfType<object>().ToArray();
				for (int i = 0; i < array3.Length; i++)
				{
					await VisitAsync(array3[i], path + "[" + i + "]", null, checkedObjects, delegate
					{
						throw new NotSupportedException("Cannot replace enumerable item.");
					}, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
			}
		}

		private static void ReplaceOrDelete<T>(ObservableCollection<T> collection, int index, T obj)
		{
			collection.RemoveAt(index);
			if (obj != null)
			{
				collection.Insert(index, obj);
			}
		}

		private static void ReplaceOrDelete(IList collection, int index, object obj)
		{
			collection.RemoveAt(index);
			if (obj != null)
			{
				collection.Insert(index, obj);
			}
		}
	}
}
