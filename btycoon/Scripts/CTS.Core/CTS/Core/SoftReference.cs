using System;
using UnityEngine;

namespace CTS.Core
{
	public static class SoftReference
	{
		public static SoftReference<TObject> Create<TObject>(TObject obj)
		{
			return new SoftReference<TObject>(obj);
		}

		public static SoftReference<TObject> Create<TObject>(IGive<TObject> obj)
		{
			return new SoftReference<TObject>((IGive<object>)obj);
		}

		public static SoftReference<TKey, TObject> Create<TKey, TObject>(TObject obj)
		{
			return new SoftReference<TKey, TObject>(obj);
		}

		public static SoftReference<TKey, TObject> Create<TKey, TObject>(IGive<TKey, TObject> giver)
		{
			return new SoftReference<TKey, TObject>((IGive<TKey, object>)giver);
		}

		public static SoftReference<TKey, TObject> Create<TKey, TObject>(IGive<TObject> giver)
		{
			return new SoftReference<TKey, TObject>((IGive<object>)giver);
		}
	}
	[Serializable]
	public struct SoftReference<TObject> : IGive<TObject>
	{
		[SerializeReference]
		private IGive _giver;

		public TObject Value
		{
			get
			{
				if (!HasValue)
				{
					return default(TObject);
				}
				return (TObject)_giver.Get();
			}
		}

		public bool HasValue
		{
			get
			{
				if (_giver != null)
				{
					return _giver.HasValue();
				}
				return false;
			}
		}

		public TObject Get()
		{
			return Value;
		}

		public static implicit operator TObject(SoftReference<TObject> obj)
		{
			return obj.Get();
		}

		public static implicit operator SoftReference<TObject>(TObject obj)
		{
			return SoftReference.Create(obj);
		}

		internal SoftReference(object obj)
		{
			IGive giver;
			if (!(obj is UnityEngine.Object obj2))
			{
				IGive give = new NonSerializableObjectGiver(obj);
				giver = give;
			}
			else
			{
				IGive give = new ObjectGiver(obj2);
				giver = give;
			}
			_giver = giver;
		}

		internal SoftReference(IGive<object> obj)
		{
			IGive giver2;
			if (!(obj is UnityEngine.Object giver))
			{
				IGive give = new NonSerializableInterfaceGiver(obj);
				giver2 = give;
			}
			else
			{
				IGive give = new InterfaceGiver(giver);
				giver2 = give;
			}
			_giver = giver2;
		}

		private SoftReference(IGive giver)
		{
			_giver = giver;
		}
	}
	[Serializable]
	public struct SoftReference<TKey, TObject> : IGive<TKey, TObject>
	{
		[SerializeReference]
		private IGiveWithKey _giver;

		public bool HasValue
		{
			get
			{
				if (_giver != null)
				{
					return _giver.HasValue();
				}
				return false;
			}
		}

		public TObject Get(TKey key)
		{
			if (!HasValue)
			{
				return default(TObject);
			}
			return (TObject)_giver.Get(key);
		}

		public static implicit operator SoftReference<TKey, TObject>(TObject obj)
		{
			return SoftReference.Create<TKey, TObject>(obj);
		}

		internal SoftReference(object obj)
		{
			IGiveWithKey giver;
			if (!(obj is UnityEngine.Object obj2))
			{
				IGiveWithKey giveWithKey = new NonSerializableObjectGiverKey(obj);
				giver = giveWithKey;
			}
			else
			{
				IGiveWithKey giveWithKey = new ObjectGiverKey(obj2);
				giver = giveWithKey;
			}
			_giver = giver;
		}

		internal SoftReference(IGive<TKey, object> obj)
		{
			IGiveWithKey giver2;
			if (!(obj is UnityEngine.Object giver))
			{
				IGiveWithKey giveWithKey = new NonSerializableInterfaceGiverKey(obj);
				giver2 = giveWithKey;
			}
			else
			{
				IGiveWithKey giveWithKey = new InterfaceGiverKey(giver);
				giver2 = giveWithKey;
			}
			_giver = giver2;
		}

		internal SoftReference(IGive<object> obj)
		{
			IGiveWithKey giver2;
			if (!(obj is UnityEngine.Object giver))
			{
				IGiveWithKey giveWithKey = new NonSerializableInterfaceGiverKey(obj);
				giver2 = giveWithKey;
			}
			else
			{
				IGiveWithKey giveWithKey = new InterfaceGiverKey(giver);
				giver2 = giveWithKey;
			}
			_giver = giver2;
		}

		private SoftReference(IGiveWithKey giver)
		{
			_giver = giver;
		}
	}
}
