using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Factory
{
	public class ImportContext
	{
		private class UnmappedDictionary
		{
			private readonly IDictionary _dictionary;

			private readonly List<object> _keys;

			private readonly List<object> _values;

			public UnmappedDictionary(IDictionary dictionary, List<object> keys, List<object> values)
			{
				_dictionary = dictionary;
				_keys = keys;
				_values = values;
			}

			public void Map()
			{
				int count = _keys.Count;
				for (int i = 0; i < count; i++)
				{
					_dictionary.Add(_keys[i], _values[i]);
				}
			}
		}

		private readonly BinaryReader _reader;

		private readonly IScope _scope;

		private readonly List<object> _objectLibrary = new List<object>();

		private readonly List<UnmappedDictionary> _unmappedDictionaries = new List<UnmappedDictionary>();

		public BinaryReader Reader => _reader;

		public IScope Scope => _scope;

		public ImportContext(BinaryReader reader, IScope scope)
		{
			_reader = reader;
			_scope = scope;
			_objectLibrary.Add(null);
		}

		public void AddObject(object obj)
		{
			_objectLibrary.Add(obj);
		}

		public object GetObject(int objectIndex)
		{
			if (Diagnostics.Verify(objectIndex < _objectLibrary.Count, "Cannot find object with index {0}, as the library contains only {1}.", objectIndex, _objectLibrary.Count))
			{
				return _objectLibrary[objectIndex];
			}
			return null;
		}

		public void AddUnmappedDictionary(IDictionary dictionary, List<object> keys, List<object> values)
		{
			_unmappedDictionaries.Add(new UnmappedDictionary(dictionary, keys, values));
		}

		public void MapDictionaries()
		{
			foreach (UnmappedDictionary unmappedDictionary in _unmappedDictionaries)
			{
				unmappedDictionary.Map();
			}
			_unmappedDictionaries.Clear();
		}
	}
}
