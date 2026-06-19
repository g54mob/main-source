using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace FullSerializerSave.Internal
{
	public class fsCyclicReferenceManager
	{
		private class ObjectReferenceEqualityComparator : IEqualityComparer<object>
		{
			public static readonly IEqualityComparer<object> Instance = new ObjectReferenceEqualityComparator();

			bool IEqualityComparer<object>.Equals(object x, object y)
			{
				return x == y;
			}

			int IEqualityComparer<object>.GetHashCode(object obj)
			{
				return RuntimeHelpers.GetHashCode(obj);
			}
		}

		private readonly Dictionary<object, int> _objectIds = new Dictionary<object, int>(ObjectReferenceEqualityComparator.Instance);

		private Dictionary<object, int> _objectIdsExternal = new Dictionary<object, int>(ObjectReferenceEqualityComparator.Instance);

		private int _nextId;

		private readonly Dictionary<int, object> _marked = new Dictionary<int, object>();

		private Dictionary<int, object> _markedExternal = new Dictionary<int, object>();

		private int _depth;

		public int Depth => _depth;

		public void Enter()
		{
			_depth++;
		}

		public bool Exit()
		{
			_depth--;
			if (_depth == 0)
			{
				_objectIds.Clear();
				_nextId = 0;
				_marked.Clear();
			}
			if (_depth < 0)
			{
				_depth = 0;
				throw new InvalidOperationException("Internal Error - Mismatched Enter/Exit. Please report a bug at https://github.com/jacobdufault/fullserializer/issues with the serialization data.");
			}
			return _depth == 0;
		}

		public object GetReferenceObject(int id, fsConfig config)
		{
			if (!_marked.TryGetValue(id, out var value) && !_markedExternal.TryGetValue(id, out value))
			{
				if (config.DeserializeMissingNegativeObjectIDsAsNull && id < 0)
				{
					return null;
				}
				throw new InvalidOperationException("Internal Deserialization Error - Object definition has not been encountered for object with id=" + id + "; have you reordered or modified the serialized data? If this is an issue with an unmodified Full Serializer implementation and unmodified serialization data, please report an issue with an included test case.");
			}
			return value;
		}

		public void AddReferenceWithId(int id, object reference)
		{
			_marked[id] = reference;
		}

		public int GetReferenceId(object item)
		{
			if (!_objectIds.TryGetValue(item, out var value) && !_objectIdsExternal.TryGetValue(item, out value))
			{
				value = _nextId++;
				_objectIds[item] = value;
			}
			return value;
		}

		public bool IsReference(object item)
		{
			int referenceId = GetReferenceId(item);
			if (!_marked.ContainsKey(referenceId))
			{
				return _markedExternal.ContainsKey(referenceId);
			}
			return true;
		}

		public void MarkSerialized(object item)
		{
			int referenceId = GetReferenceId(item);
			if (_marked.ContainsKey(referenceId))
			{
				throw new InvalidOperationException("Internal Error - " + item?.ToString() + " has already been marked as serialized");
			}
			_marked[referenceId] = item;
		}

		public void AddExternallyStoredReferenceWithId(int id, object reference)
		{
			if (_objectIdsExternal.ContainsKey(reference))
			{
				throw new InvalidOperationException("Object being flagged as externally stored, when it's already flagged.");
			}
			if (_markedExternal.ContainsKey(id))
			{
				throw new InvalidOperationException("Object being flagged as externally stored with an ID, but that ID is already in use.");
			}
			_objectIdsExternal[reference] = id;
			_markedExternal[id] = reference;
		}

		public void SetIDObjectMapping(Dictionary<int, object> idObjectMapping, Dictionary<object, int> objectIdMapping)
		{
			_markedExternal = new Dictionary<int, object>(idObjectMapping);
			_objectIdsExternal = new Dictionary<object, int>(objectIdMapping, ObjectReferenceEqualityComparator.Instance);
		}
	}
}
