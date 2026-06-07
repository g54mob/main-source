using System;
using System.Collections.Generic;
using System.IO;

namespace Factory
{
	public class ExportContext
	{
		public class ObjectLibrary
		{
			private class TypedObjectCollection
			{
				public int baseObjectId;

				public List<object> objects = new List<object>();

				public Dictionary<object, int> objectIndex = new Dictionary<object, int>();
			}

			private List<Type> _types = new List<Type>();

			private Dictionary<Type, TypedObjectCollection> _typedObjects = new Dictionary<Type, TypedObjectCollection>();

			public ICollection<Type> Types => _types;

			public bool ContainsObject(object obj)
			{
				Type type = obj.GetType();
				if (!_typedObjects.ContainsKey(type))
				{
					return false;
				}
				return _typedObjects[type].objectIndex.ContainsKey(obj);
			}

			public void AddObject(object obj)
			{
				Type type = obj.GetType();
				if (!_typedObjects.TryGetValue(type, out var value))
				{
					value = new TypedObjectCollection();
					_typedObjects[type] = value;
					_types.Add(type);
				}
				value.objectIndex[obj] = value.objects.Count;
				value.objects.Add(obj);
			}

			public void BuildIndex()
			{
				int num = 1;
				foreach (Type type in _types)
				{
					TypedObjectCollection typedObjectCollection = _typedObjects[type];
					typedObjectCollection.baseObjectId = num;
					num += typedObjectCollection.objects.Count;
				}
			}

			public ICollection<object> GetObjectsOfType(Type objType)
			{
				return _typedObjects[objType].objects;
			}

			public int GetObjectId(object obj)
			{
				if (!Diagnostics.Verify(_typedObjects.TryGetValue(obj.GetType(), out var value)))
				{
					return -1;
				}
				return value.baseObjectId + value.objectIndex[obj];
			}
		}

		private readonly BinaryWriter _writer;

		private IScope _scope;

		private ObjectLibrary _objectLibrary = new ObjectLibrary();

		public BinaryWriter Writer => _writer;

		public IScope Scope => _scope;

		public ObjectLibrary Library => _objectLibrary;

		public ExportContext(BinaryWriter writer, IScope scope)
		{
			_writer = writer;
			_scope = scope;
		}
	}
}
