using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NJsonSchema.References;
using Namotion.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace NJsonSchema.Visitors
{
	public abstract class JsonReferenceVisitorBase
	{
		private readonly IContractResolver _contractResolver;

		protected JsonReferenceVisitorBase()
			: this(new DefaultContractResolver())
		{
		}

		protected JsonReferenceVisitorBase(IContractResolver contractResolver)
		{
			_contractResolver = contractResolver;
		}

		public virtual void Visit(object obj)
		{
			Visit(obj, "#", null, new HashSet<object>(), delegate
			{
				throw new NotSupportedException("Cannot replace the root.");
			});
		}

		protected abstract IJsonReference VisitJsonReference(IJsonReference reference, string path, string typeNameHint);

		protected virtual void Visit(object obj, string path, string typeNameHint, ISet<object> checkedObjects, Action<object> replacer)
		{
			if (obj == null || !checkedObjects.Add(obj))
			{
				return;
			}
			if (obj is IJsonReference jsonReference)
			{
				IJsonReference jsonReference2 = VisitJsonReference(jsonReference, path, typeNameHint);
				if (jsonReference2 != jsonReference)
				{
					replacer(jsonReference2);
					return;
				}
			}
			JsonSchema schema = obj as JsonSchema;
			if (schema != null)
			{
				if (schema.Reference != null)
				{
					Visit(schema.Reference, path, null, checkedObjects, delegate(object o)
					{
						schema.Reference = (JsonSchema)o;
					});
				}
				if (schema.AdditionalItemsSchema != null)
				{
					Visit(schema.AdditionalItemsSchema, path + "/additionalItems", null, checkedObjects, delegate(object o)
					{
						schema.AdditionalItemsSchema = (JsonSchema)o;
					});
				}
				if (schema.AdditionalPropertiesSchema != null)
				{
					Visit(schema.AdditionalPropertiesSchema, path + "/additionalProperties", null, checkedObjects, delegate(object o)
					{
						schema.AdditionalPropertiesSchema = (JsonSchema)o;
					});
				}
				if (schema.Item != null)
				{
					Visit(schema.Item, path + "/items", null, checkedObjects, delegate(object o)
					{
						schema.Item = (JsonSchema)o;
					});
				}
				ObservableCollection<JsonSchema> items = schema._items;
				for (int num = 0; num < items.Count; num++)
				{
					int index = num;
					Visit(items[num], path + "/items[" + num + "]", null, checkedObjects, delegate(object o)
					{
						ReplaceOrDelete(items, index, (JsonSchema)o);
					});
				}
				ObservableCollection<JsonSchema> allOf = schema._allOf;
				for (int num2 = 0; num2 < allOf.Count; num2++)
				{
					int index2 = num2;
					Visit(allOf[num2], path + "/allOf[" + num2 + "]", null, checkedObjects, delegate(object o)
					{
						ReplaceOrDelete(allOf, index2, (JsonSchema)o);
					});
				}
				ObservableCollection<JsonSchema> anyOf = schema._anyOf;
				for (int num3 = 0; num3 < anyOf.Count; num3++)
				{
					int index3 = num3;
					Visit(anyOf[num3], path + "/anyOf[" + num3 + "]", null, checkedObjects, delegate(object o)
					{
						ReplaceOrDelete(anyOf, index3, (JsonSchema)o);
					});
				}
				ObservableCollection<JsonSchema> oneOf = schema._oneOf;
				for (int num4 = 0; num4 < oneOf.Count; num4++)
				{
					int index4 = num4;
					Visit(oneOf[num4], path + "/oneOf[" + num4 + "]", null, checkedObjects, delegate(object o)
					{
						ReplaceOrDelete(oneOf, index4, (JsonSchema)o);
					});
				}
				if (schema.Not != null)
				{
					Visit(schema.Not, path + "/not", null, checkedObjects, delegate(object o)
					{
						schema.Not = (JsonSchema)o;
					});
				}
				if (schema.DictionaryKey != null)
				{
					Visit(schema.DictionaryKey, path + "/x-dictionaryKey", null, checkedObjects, delegate(object o)
					{
						schema.DictionaryKey = (JsonSchema)o;
					});
				}
				if (schema.DiscriminatorRaw != null)
				{
					Visit(schema.DiscriminatorRaw, path + "/discriminator", null, checkedObjects, delegate(object o)
					{
						schema.DiscriminatorRaw = o;
					});
				}
				KeyValuePair<string, JsonSchemaProperty>[] array = schema.Properties.ToArray();
				for (int num5 = 0; num5 < array.Length; num5++)
				{
					KeyValuePair<string, JsonSchemaProperty> p = array[num5];
					Visit(p.Value, path + "/properties/" + p.Key, p.Key, checkedObjects, delegate(object o)
					{
						schema.Properties[p.Key] = (JsonSchemaProperty)o;
					});
				}
				KeyValuePair<string, JsonSchemaProperty>[] array2 = schema.PatternProperties.ToArray();
				for (int num6 = 0; num6 < array2.Length; num6++)
				{
					KeyValuePair<string, JsonSchemaProperty> p2 = array2[num6];
					Visit(p2.Value, path + "/patternProperties/" + p2.Key, null, checkedObjects, delegate(object o)
					{
						schema.PatternProperties[p2.Key] = (JsonSchemaProperty)o;
					});
				}
				KeyValuePair<string, JsonSchema>[] array3 = schema.Definitions.ToArray();
				for (int num7 = 0; num7 < array3.Length; num7++)
				{
					KeyValuePair<string, JsonSchema> p3 = array3[num7];
					Visit(p3.Value, path + "/definitions/" + p3.Key, p3.Key, checkedObjects, delegate(object o)
					{
						if (o != null)
						{
							schema.Definitions[p3.Key] = (JsonSchema)o;
						}
						else
						{
							schema.Definitions.Remove(p3.Key);
						}
					});
				}
			}
			if (obj is string || obj is JToken || !(obj.GetType() != typeof(JsonSchema)))
			{
				return;
			}
			if (_contractResolver.ResolveContract(obj.GetType()) is JsonObjectContract jsonObjectContract)
			{
				{
					foreach (JsonProperty property in jsonObjectContract.Properties.Where((JsonProperty jsonProperty) => (!(obj is JsonSchema) || !JsonSchema.JsonSchemaPropertiesCache.Contains(jsonProperty.UnderlyingName)) && !jsonProperty.Ignored && (jsonProperty.ShouldSerialize?.Invoke(obj) ?? true)))
					{
						object value = property.ValueProvider.GetValue(obj);
						if (value != null)
						{
							Visit(value, path + "/" + property.PropertyName, property.PropertyName, checkedObjects, delegate(object o)
							{
								property.ValueProvider.SetValue(obj, o);
							});
						}
					}
					return;
				}
			}
			IDictionary dictionary = obj as IDictionary;
			if (dictionary != null)
			{
				object[] array4 = dictionary.Keys.OfType<object>().ToArray();
				foreach (object key in array4)
				{
					Visit(dictionary[key], path + "/" + key, key.ToString(), checkedObjects, delegate(object o)
					{
						if (o != null)
						{
							dictionary[key] = (JsonSchema)o;
						}
						else
						{
							dictionary.Remove(key);
						}
					});
				}
				ContextualType contextualType = obj.GetType().ToContextualType();
				if (!contextualType.GetInheritedAttributes<JsonConverterAttribute>().Any())
				{
					return;
				}
				{
					foreach (ContextualPropertyInfo property2 in from contextualPropertyInfo in contextualType.Type.GetContextualProperties()
						where contextualPropertyInfo.MemberInfo.DeclaringType == contextualType.Type && !contextualPropertyInfo.GetContextAttributes<JsonIgnoreAttribute>().Any()
						select contextualPropertyInfo)
					{
						object value2 = property2.GetValue(obj);
						if (value2 != null)
						{
							Visit(value2, path + "/" + property2.Name, property2.Name, checkedObjects, delegate(object o)
							{
								property2.SetValue(obj, o);
							});
						}
					}
					return;
				}
			}
			IList list = obj as IList;
			if (list != null)
			{
				object[] array5 = list.OfType<object>().ToArray();
				for (int num9 = 0; num9 < array5.Length; num9++)
				{
					int index5 = num9;
					Visit(array5[num9], path + "[" + num9 + "]", null, checkedObjects, delegate(object o)
					{
						ReplaceOrDelete(list, index5, o);
					});
				}
			}
			else
			{
				if (!(obj is IEnumerable source))
				{
					return;
				}
				object[] array6 = source.OfType<object>().ToArray();
				for (int num10 = 0; num10 < array6.Length; num10++)
				{
					Visit(array6[num10], path + "[" + num10 + "]", null, checkedObjects, delegate
					{
						throw new NotSupportedException("Cannot replace enumerable item.");
					});
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
