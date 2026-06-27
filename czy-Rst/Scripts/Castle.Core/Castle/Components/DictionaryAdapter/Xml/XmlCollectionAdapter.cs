using System;
using System.Collections.Generic;

namespace Castle.Components.DictionaryAdapter.Xml
{
	internal class XmlCollectionAdapter<T> : ICollectionAdapter<T>, IXmlNodeSource
	{
		private List<XmlCollectionItem<T>> items;

		private List<XmlCollectionItem<T>> snapshot;

		private ICollectionAdapterObserver<T> advisor;

		private readonly IXmlCursor cursor;

		private readonly IXmlCollectionAccessor accessor;

		private readonly IXmlNode parentNode;

		private readonly IDictionaryAdapter parentObject;

		private readonly XmlReferenceManager references;

		public IXmlNode Node => parentNode;

		public XmlReferenceManager References => references;

		public int Count => items.Count;

		public T this[int index]
		{
			get
			{
				XmlCollectionItem<T> xmlCollectionItem = items[index];
				if (!xmlCollectionItem.HasValue)
				{
					xmlCollectionItem = (items[index] = xmlCollectionItem.WithValue(GetValue(xmlCollectionItem.Node)));
				}
				return xmlCollectionItem.Value;
			}
			set
			{
				XmlCollectionItem<T> xmlCollectionItem = items[index];
				cursor.MoveTo(xmlCollectionItem.Node);
				SetValue(cursor, xmlCollectionItem.Value, ref value);
				if (advisor.OnReplacing(xmlCollectionItem.Value, value))
				{
					items[index] = xmlCollectionItem.WithValue(value);
					advisor.OnReplaced(xmlCollectionItem.Value, value, index);
				}
				else
				{
					T value2 = xmlCollectionItem.Value;
					SetValue(cursor, value, ref value2);
					items[index] = xmlCollectionItem.WithValue(value2);
				}
			}
		}

		public IEqualityComparer<T> Comparer => null;

		public bool HasSnapshot => snapshot != null;

		public int SnapshotCount => snapshot.Count;

		public XmlCollectionAdapter(IXmlNode parentNode, IDictionaryAdapter parentObject, IXmlCollectionAccessor accessor)
		{
			items = new List<XmlCollectionItem<T>>();
			this.accessor = accessor;
			cursor = accessor.SelectCollectionItems(parentNode, mutable: true);
			this.parentNode = parentNode;
			this.parentObject = parentObject;
			references = XmlAdapter.For(parentObject).References;
			while (cursor.MoveNext())
			{
				items.Add(new XmlCollectionItem<T>(cursor.Save()));
			}
		}

		public void Initialize(ICollectionAdapterObserver<T> advisor)
		{
			this.advisor = advisor;
		}

		public T AddNew()
		{
			cursor.MoveToEnd();
			cursor.Create(typeof(T));
			IXmlNode node = cursor.Save();
			T value = GetValue(node);
			int count = items.Count;
			CommitInsert(count, node, value, append: true);
			return value;
		}

		public bool Add(T value)
		{
			return InsertCore(Count, value, append: true);
		}

		public bool Insert(int index, T value)
		{
			return InsertCore(index, value, append: false);
		}

		private bool InsertCore(int index, T value, bool append)
		{
			if (append)
			{
				cursor.MoveToEnd();
			}
			else
			{
				cursor.MoveTo(items[index].Node);
			}
			cursor.Create(GetTypeOrDefault(value));
			IXmlNode node = cursor.Save();
			SetValue(cursor, default(T), ref value);
			if (!advisor.OnInserting(value))
			{
				return RollbackInsert();
			}
			return CommitInsert(index, node, value, append);
		}

		private bool CommitInsert(int index, IXmlNode node, T value, bool append)
		{
			XmlCollectionItem<T> item = new XmlCollectionItem<T>(node, value);
			if (append)
			{
				items.Add(item);
			}
			else
			{
				items.Insert(index, item);
			}
			advisor.OnInserted(value, index);
			return true;
		}

		private bool RollbackInsert()
		{
			cursor.Remove();
			return false;
		}

		public void Remove(int index)
		{
			XmlCollectionItem<T> item = items[index];
			OnRemoving(item);
			cursor.MoveTo(item.Node);
			cursor.Remove();
			items.RemoveAt(index);
			advisor.OnRemoved(item.Value, index);
		}

		public void Clear()
		{
			foreach (XmlCollectionItem<T> item in items)
			{
				OnRemoving(item);
			}
			cursor.Reset();
			cursor.RemoveAllNext();
			items.Clear();
		}

		public void ClearReferences()
		{
			if (!accessor.IsReference)
			{
				return;
			}
			foreach (XmlCollectionItem<T> item in items)
			{
				references.OnAssigningNull(item.Node, item.Value);
			}
		}

		private void OnRemoving(XmlCollectionItem<T> item)
		{
			advisor.OnRemoving(item.Value);
			if (accessor.IsReference)
			{
				references.OnAssigningNull(item.Node, item.Value);
			}
		}

		private T GetValue(IXmlNode node)
		{
			return (T)(accessor.GetValue(node, parentObject, references, nodeExists: true, orStub: true) ?? ((object)default(T)));
		}

		private void SetValue(IXmlCursor cursor, object oldValue, ref T value)
		{
			object newValue = value;
			accessor.SetValue(cursor, parentObject, references, hasCurrent: true, oldValue, ref newValue);
			value = (T)(newValue ?? ((object)default(T)));
		}

		private static Type GetTypeOrDefault(T value)
		{
			if (value != null)
			{
				return value.GetComponentType();
			}
			return typeof(T);
		}

		public T GetCurrentItem(int index)
		{
			return items[index].Value;
		}

		public T GetSnapshotItem(int index)
		{
			return snapshot[index].Value;
		}

		public void SaveSnapshot()
		{
			snapshot = new List<XmlCollectionItem<T>>(items);
		}

		public void LoadSnapshot()
		{
			items = snapshot;
		}

		public void DropSnapshot()
		{
			snapshot = null;
		}
	}
}
