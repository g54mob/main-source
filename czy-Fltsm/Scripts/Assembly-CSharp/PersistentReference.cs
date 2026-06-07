using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

[Serializable]
public abstract class PersistentReference<T> where T : IPersistentReference
{
	[Serializable]
	public class Reference : ISerializable
	{
		public delegate void RestoreReferenceCallback(T reference);

		public int PersistentIndex = -1;

		[NonSerialized]
		private T _reference;

		public Reference(T reference)
		{
			_reference = reference;
			if (_reference == null)
			{
				PersistentIndex = -1;
			}
			else
			{
				PersistentIndex = reference.PersistentIndex;
			}
		}

		public Reference(SerializationInfo info, StreamingContext context)
		{
			PersistentIndex = info.GetInt32("PersistentIndex");
		}

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (_reference == null)
			{
				info.AddValue("PersistentIndex", -1);
			}
			else
			{
				info.AddValue("PersistentIndex", _reference.PersistentIndex);
			}
		}

		public void Restore(RestoreReferenceCallback restoreCallback)
		{
			if (PersistentReference<T>.TryReturnReference(PersistentIndex, out T reference))
			{
				restoreCallback(reference);
			}
		}

		public bool TryReturnInstance(out T reference)
		{
			return PersistentReference<T>.TryReturnReference(PersistentIndex, out reference);
		}

		public static implicit operator Reference(T reference)
		{
			if (reference == null)
			{
				return null;
			}
			return new Reference(reference);
		}

		public static implicit operator T(Reference field)
		{
			if (field == null)
			{
				return default(T);
			}
			if (PersistentReference<T>.TryReturnReference(field.PersistentIndex, out T reference))
			{
				return reference;
			}
			return default(T);
		}
	}

	public delegate void OnReferenceRestored(T reference);

	[OptionalField]
	public int PersistentIndex;

	public static int _referenceCount;

	public static List<PersistentReference<T>> _references;

	[NonSerialized]
	private T _instance;

	public T Instance
	{
		get
		{
			return _instance;
		}
		protected set
		{
			_instance = value;
		}
	}

	public PersistentReference(T reference)
	{
		Initialize(reference);
	}

	protected virtual void Initialize(T reference)
	{
		if (reference == null)
		{
			PersistentIndex = -1;
			return;
		}
		Instance = reference;
		T instance = Instance;
		instance.PersistentIndex = (PersistentIndex = _referenceCount++);
		if (_references == null)
		{
			_references = new List<PersistentReference<T>>();
		}
		_references.Add(this);
	}

	public virtual void Restore()
	{
		if (PersistentIndex >= 0)
		{
			if (_references == null)
			{
				_references = new List<PersistentReference<T>>();
			}
			_references.Add(this);
		}
	}

	public static void OnPrePersistenceOperation()
	{
		_referenceCount = 0;
		if (_references == null)
		{
			_references = ListPool<PersistentReference<T>>.Get();
		}
		else
		{
			ClearReferences();
		}
	}

	public static void OnPostPersistenceOperation()
	{
		if (_references != null)
		{
			ClearReferences();
			ListPool<PersistentReference<T>>.Add(_references);
			_references = null;
		}
	}

	private static void ClearReferences()
	{
		foreach (PersistentReference<T> reference in _references)
		{
			reference.PersistentIndex = -1;
			if (reference.Instance != null)
			{
				T instance = reference.Instance;
				instance.PersistentIndex = -1;
				reference.Instance = default(T);
			}
		}
		_references.Clear();
	}

	public static bool TryReturnReference(int persistentIndex, out T reference)
	{
		if (_references == null)
		{
			throw new NotSupportedException("Persistent reference for type '" + typeof(T)?.ToString() + "' has not been initialized! Are you missing a call to OnPreLoad()?");
		}
		int count = _references.Count;
		if (-1 < persistentIndex)
		{
			if (persistentIndex < _references.Count)
			{
				PersistentReference<T> persistentReference = _references[persistentIndex];
				if (persistentReference.PersistentIndex == persistentIndex)
				{
					reference = persistentReference.Instance;
					return reference != null;
				}
			}
			for (int i = 0; i < count; i++)
			{
				PersistentReference<T> persistentReference = _references[i];
				if (persistentReference.PersistentIndex == persistentIndex)
				{
					reference = persistentReference.Instance;
					return reference != null;
				}
			}
		}
		reference = default(T);
		return false;
	}
}
