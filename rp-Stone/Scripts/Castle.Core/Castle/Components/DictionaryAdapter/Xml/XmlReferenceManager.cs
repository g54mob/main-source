using System;
using System.Collections.Generic;
using System.Reflection;
using Castle.Core;
using Castle.Core.Internal;

namespace Castle.Components.DictionaryAdapter.Xml
{
	public class XmlReferenceManager
	{
		private class Entry
		{
			public int Id;

			public IXmlNode Node;

			private List<IXmlNode> references;

			private List<EntryValue> values;

			public List<IXmlNode> References => references;

			public List<EntryValue> Values => values;

			public Entry(IXmlNode node)
			{
				Node = node.Save();
			}

			public Entry(int id, IXmlNode node)
				: this(node)
			{
				Id = id;
			}

			public void AddReference(IXmlNode node)
			{
				if (references == null)
				{
					references = new List<IXmlNode>();
				}
				references.Add(node);
			}

			public IXmlNode RemoveReference(IXmlNode node)
			{
				for (int i = 0; i < references.Count; i++)
				{
					if (references[i].PositionEquals(node))
					{
						return RemoveReference(i);
					}
				}
				return node;
			}

			public IXmlNode RemoveReference(int index)
			{
				IXmlNode result = references[index];
				references.RemoveAt(index);
				if (references.Count == 0)
				{
					references = null;
				}
				return result;
			}

			public void AddValue(Type type, object value, bool isInGraph)
			{
				if (values == null)
				{
					values = new List<EntryValue>();
				}
				values.Add(new EntryValue(type, value, isInGraph));
			}
		}

		private struct Reference
		{
			public readonly int Id;

			public readonly IXmlNode Node;

			public Reference(int id, IXmlNode node)
			{
				Id = id;
				Node = node;
			}
		}

		private struct EntryValue
		{
			public readonly Type Type;

			public readonly WeakReference Value;

			public readonly bool IsInGraph;

			public EntryValue(Type type, object value, bool isInGraph)
				: this(type, new WeakReference(value), isInGraph)
			{
			}

			public EntryValue(Type type, WeakReference value, bool isInGraph)
			{
				Type = type;
				Value = value;
				IsInGraph = isInGraph;
			}
		}

		private readonly Dictionary<int, Entry> entriesById;

		private readonly WeakKeyDictionary<object, Entry> entriesByValue;

		private readonly IXmlReferenceFormat format;

		private int nextId;

		private static readonly Type StringType = typeof(string);

		private static readonly object CreateEntryToken = new object();

		public XmlReferenceManager(IXmlNode root, IXmlReferenceFormat format)
		{
			entriesById = new Dictionary<int, Entry>();
			entriesByValue = new WeakKeyDictionary<object, Entry>(ReferenceEqualityComparer<object>.Instance);
			this.format = format;
			nextId = 1;
			Populate(root);
		}

		private void Populate(IXmlNode node)
		{
			List<Reference> references = new List<Reference>();
			IXmlIterator xmlIterator = node.SelectSubtree();
			while (xmlIterator.MoveNext())
			{
				PopulateFromNode(xmlIterator, references);
			}
			PopulateDeferredReferences(references);
		}

		private void PopulateFromNode(IXmlIterator node, ICollection<Reference> references)
		{
			if (format.TryGetIdentity(node, out var id))
			{
				PopulateIdentity(id, node.Save());
			}
			else if (format.TryGetReference(node, out id))
			{
				PopulateReference(id, node.Save(), references);
			}
		}

		private void PopulateIdentity(int id, IXmlNode node)
		{
			if (!entriesById.TryGetValue(id, out var _))
			{
				entriesById.Add(id, new Entry(id, node));
			}
			if (nextId <= id)
			{
				nextId = ++id;
			}
		}

		private void PopulateReference(int id, IXmlNode node, ICollection<Reference> references)
		{
			if (entriesById.TryGetValue(id, out var value))
			{
				value.AddReference(node);
			}
			else
			{
				references.Add(new Reference(id, node));
			}
		}

		private void PopulateDeferredReferences(ICollection<Reference> references)
		{
			foreach (Reference reference in references)
			{
				if (entriesById.TryGetValue(reference.Id, out var value))
				{
					value.AddReference(reference.Node);
				}
			}
		}

		public bool TryGet(object keyObject, out object inGraphObject)
		{
			if (entriesByValue.TryGetValue(keyObject, out var value))
			{
				inGraphObject = keyObject;
				TryGetCompatibleValue(value, keyObject.GetComponentType(), ref inGraphObject);
				return true;
			}
			inGraphObject = null;
			return false;
		}

		public void Add(IXmlNode node, object keyValue, object newValue, bool isInGraph)
		{
			if (keyValue == null)
			{
				throw Error.ArgumentNull("keyValue");
			}
			if (newValue == null)
			{
				throw Error.ArgumentNull("newValue");
			}
			Type componentType = newValue.GetComponentType();
			if (ShouldExclude(componentType) || entriesByValue.ContainsKey(newValue))
			{
				return;
			}
			if (entriesByValue.TryGetValue(keyValue, out var value))
			{
				if (newValue == keyValue)
				{
					return;
				}
			}
			else
			{
				if (node == null)
				{
					return;
				}
				if (!TryGetEntry(node, out value, out var _))
				{
					value = new Entry(node);
				}
			}
			AddValueCore(value, componentType, newValue, isInGraph);
		}

		public bool OnGetStarting(ref IXmlNode node, ref object value, out object token)
		{
			if (ShouldExclude(node.ClrType))
			{
				token = null;
				return true;
			}
			if (!TryGetEntry(node, out var entry, out var reference))
			{
				token = CreateEntryToken;
				return true;
			}
			if (reference)
			{
				RedirectNode(ref node, entry);
			}
			bool flag = !TryGetCompatibleValue(entry, node.ClrType, ref value);
			token = (flag ? entry : null);
			return flag;
		}

		public void OnGetCompleted(IXmlNode node, object value, object token)
		{
			if (value == null)
			{
				return;
			}
			Type clrType = node.ClrType;
			if (!ShouldExclude(clrType) && !entriesByValue.ContainsKey(value))
			{
				Entry entry = ((token == CreateEntryToken) ? new Entry(node) : (token as Entry));
				if (entry != null)
				{
					AddValue(entry, clrType, value, null);
				}
			}
		}

		public bool OnAssigningNull(IXmlNode node, object oldValue)
		{
			object newValue = null;
			object token;
			return OnAssigningValue(node, oldValue, ref newValue, out token);
		}

		public bool OnAssigningValue(IXmlNode node, object oldValue, ref object newValue, out object token)
		{
			if (newValue == oldValue && newValue != null)
			{
				token = null;
				return false;
			}
			Entry entry = OnReplacingValue(node, oldValue);
			if (newValue == null)
			{
				return ShouldAssignmentProceed(entry, null, token = null);
			}
			Type componentType = newValue.GetComponentType();
			if (ShouldExclude(componentType))
			{
				return ShouldAssignmentProceed(entry, null, token = null);
			}
			XmlAdapter xmlAdapter = XmlAdapter.For(newValue, required: false);
			if (entriesByValue.TryGetValue(xmlAdapter ?? newValue, out var value))
			{
				TryGetCompatibleValue(value, componentType, ref newValue);
				AddReference(node, value);
				token = null;
			}
			else
			{
				value = entry ?? new Entry(node);
				AddValue(value, componentType, newValue, xmlAdapter);
				format.ClearIdentity(node);
				format.ClearReference(node);
				token = value;
			}
			return ShouldAssignmentProceed(entry, value, token);
		}

		private bool ShouldAssignmentProceed(Entry oldEntry, Entry newEntry, object token)
		{
			if (oldEntry != null && oldEntry != newEntry && oldEntry.Id > 0)
			{
				entriesById.Remove(oldEntry.Id);
			}
			if (token == null)
			{
				return newEntry == null;
			}
			return true;
		}

		private Entry OnReplacingValue(IXmlNode node, object oldValue)
		{
			Entry value;
			bool reference;
			if (oldValue == null)
			{
				if (!TryGetEntry(node, out value, out reference))
				{
					return null;
				}
			}
			else
			{
				if (!entriesByValue.TryGetValue(oldValue, out value))
				{
					return null;
				}
				reference = !value.Node.PositionEquals(node);
			}
			if (reference)
			{
				value.RemoveReference(node);
				ClearReference(value, node);
				return null;
			}
			if (value.References != null)
			{
				node = value.RemoveReference(0);
				ClearReference(value, node);
				value.Node.CopyTo(node);
				value.Node.Clear();
				value.Node = node;
				return null;
			}
			PrepareForReuse(value);
			return value;
		}

		public void OnAssignedValue(IXmlNode node, object givenValue, object storedValue, object token)
		{
			if (token is Entry entry && givenValue != storedValue)
			{
				SetNotInGraph(entry, givenValue);
				if (!entriesByValue.ContainsKey(storedValue))
				{
					AddValue(entry, node.ClrType, storedValue, null);
				}
			}
		}

		private void AddReference(IXmlNode node, Entry entry)
		{
			if (!entry.Node.PositionEquals(node))
			{
				if (entry.References == null)
				{
					GenerateId(entry);
					format.SetIdentity(entry.Node, entry.Id);
				}
				node.Clear();
				entry.AddReference(node);
				format.SetReference(node, entry.Id);
			}
		}

		private void GenerateId(Entry entry)
		{
			if (entry.Id == 0)
			{
				entry.Id = nextId++;
				entriesById.Add(entry.Id, entry);
			}
		}

		private void AddValue(Entry entry, Type type, object value, XmlAdapter xmlAdapter)
		{
			if (xmlAdapter == null)
			{
				xmlAdapter = XmlAdapter.For(value, required: false);
			}
			AddValueCore(entry, type, value, isInGraph: true);
			if (xmlAdapter != null)
			{
				AddValueCore(entry, typeof(XmlAdapter), xmlAdapter, isInGraph: true);
			}
		}

		private void AddValueCore(Entry entry, Type type, object value, bool isInGraph)
		{
			entry.AddValue(type, value, isInGraph);
			entriesByValue.Add(value, entry);
		}

		private void ClearReference(Entry entry, IXmlNode node)
		{
			format.ClearReference(node);
			if (entry.References == null)
			{
				format.ClearIdentity(entry.Node);
			}
		}

		private void PrepareForReuse(Entry entry)
		{
			foreach (EntryValue value in entry.Values)
			{
				object target = value.Value.Target;
				if (target != null)
				{
					entriesByValue.Remove(target);
				}
			}
			entry.Values.Clear();
			format.ClearIdentity(entry.Node);
		}

		private bool TryGetEntry(IXmlNode node, out Entry entry, out bool reference)
		{
			if (format.TryGetIdentity(node, out var id))
			{
				reference = false;
			}
			else
			{
				if (!format.TryGetReference(node, out id))
				{
					reference = false;
					entry = null;
					return false;
				}
				reference = true;
			}
			if (!entriesById.TryGetValue(id, out entry))
			{
				throw IdNotFoundError(id);
			}
			return true;
		}

		private bool TryGetCompatibleValue(Entry entry, Type type, ref object value)
		{
			List<EntryValue> values = entry.Values;
			if (values == null)
			{
				return false;
			}
			IDictionaryAdapter dictionaryAdapter = null;
			foreach (EntryValue item in values)
			{
				if (!item.IsInGraph)
				{
					continue;
				}
				object target = item.Value.Target;
				if (target != null)
				{
					if (type.IsAssignableFrom(item.Type) && target != null)
					{
						return Try.Success(out value, target);
					}
					if (dictionaryAdapter == null)
					{
						dictionaryAdapter = target as IDictionaryAdapter;
					}
				}
			}
			if (dictionaryAdapter != null)
			{
				value = dictionaryAdapter.Coerce(type);
				entry.AddValue(type, value, isInGraph: true);
				return true;
			}
			return false;
		}

		private static void SetNotInGraph(Entry entry, object value)
		{
			XmlAdapter xmlAdapter = XmlAdapter.For(value, required: false);
			SetNotInGraphCore(entry, value);
			if (xmlAdapter != null)
			{
				SetNotInGraphCore(entry, xmlAdapter);
			}
		}

		private static bool ShouldExclude(Type type)
		{
			if (!type.GetTypeInfo().IsValueType)
			{
				return type == StringType;
			}
			return true;
		}

		private static void SetNotInGraphCore(Entry entry, object value)
		{
			List<EntryValue> values = entry.Values;
			for (int i = 0; i < values.Count; i++)
			{
				EntryValue entryValue = values[i];
				if (entryValue.Value.Target == value)
				{
					entryValue = new EntryValue(entryValue.Type, entryValue.Value, isInGraph: false);
					values[i] = entryValue;
					break;
				}
			}
		}

		private static IXmlNode RedirectNode(ref IXmlNode node, Entry entry)
		{
			IXmlCursor xmlCursor = entry.Node.SelectSelf(node.ClrType);
			xmlCursor.MoveNext();
			return node = xmlCursor;
		}

		public void UnionWith(XmlReferenceManager other)
		{
			HashSet<Entry> hashSet = null;
			foreach (KeyValuePair<object, Entry> item in other.entriesByValue)
			{
				if (!entriesByValue.TryGetValue(item.Key, out var value))
				{
					continue;
				}
				if (hashSet == null)
				{
					hashSet = new HashSet<Entry>(ReferenceEqualityComparer<Entry>.Instance);
				}
				else if (hashSet.Contains(value))
				{
					continue;
				}
				hashSet.Add(value);
				foreach (EntryValue value2 in item.Value.Values)
				{
					object target = value2.Value.Target;
					if (target != null && target != item.Key && !entriesByValue.ContainsKey(target))
					{
						AddValueCore(value, value2.Type, target, isInGraph: false);
					}
				}
			}
		}

		private static Exception IdNotFoundError(int id)
		{
			return new KeyNotFoundException($"The given ID ({id}) was not present in the underlying data.");
		}
	}
}
