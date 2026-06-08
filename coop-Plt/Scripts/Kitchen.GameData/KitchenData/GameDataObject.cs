using System;
using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;
using Sirenix.Utilities;
using UnityEngine;

namespace KitchenData
{
	public abstract class GameDataObject : KitchenObject, IEquatable<GameDataObject>
	{
		[HideInInspector]
		public int ID;

		private int _ID
		{
			get
			{
				return ID;
			}
			set
			{
			}
		}

		private void GenerateID()
		{
			ID = UnityEngine.Random.Range(int.MinValue, int.MaxValue);
		}

		private void SetID(int id)
		{
			ID = id;
		}

		private void Awake()
		{
			if (ID == 0)
			{
				GenerateID();
				InitialiseDefaults();
			}
		}

		protected abstract void InitialiseDefaults();

		public virtual void SetupForGame()
		{
		}

		public virtual void SetupFinal()
		{
			HandlePostSerialization();
		}

		public virtual bool Localise(Locale locale, StringSubstitutor subs)
		{
			return true;
		}

		public static explicit operator int(GameDataObject gdo)
		{
			return gdo.ID;
		}

		protected virtual void HandlePostSerialization()
		{
			FieldInfo[] fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (FieldInfo fieldInfo in fields)
			{
				if (fieldInfo.FieldType.IsGenericType && fieldInfo.FieldType.GetGenericTypeDefinition() == typeof(HashSet<>))
				{
					Type[] genericArguments = fieldInfo.FieldType.GetGenericArguments();
					typeof(GameDataObject).GetMethod("Rehash")?.MakeGenericMethod(genericArguments).Invoke(this, new object[1] { fieldInfo.GetValue(this) });
				}
			}
		}

		[UsedImplicitly]
		public static void Rehash<T>(HashSet<T> set)
		{
			if (set != null)
			{
				HashSet<T> hashSet = new HashSet<T>();
				hashSet.AddRange(set);
				set.Clear();
				set.AddRange(hashSet);
			}
		}

		public void UsedOnlyForAOTCodeGeneration()
		{
			Rehash(new HashSet<Dish.IngredientUnlock>());
			throw new InvalidOperationException("This method is used for AOT code generation only. Do not call it at runtime.");
		}

		public bool Equals(GameDataObject other)
		{
			if ((object)other == null)
			{
				return false;
			}
			if ((object)this == other)
			{
				return true;
			}
			if (base.Equals((object)other))
			{
				return ID == other.ID;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (this == obj)
			{
				return true;
			}
			if (obj.GetType() != GetType())
			{
				return false;
			}
			return Equals((GameDataObject)obj);
		}

		public override int GetHashCode()
		{
			return ID;
		}

		public static bool operator ==(GameDataObject left, GameDataObject right)
		{
			return object.Equals(left, right);
		}

		public static bool operator !=(GameDataObject left, GameDataObject right)
		{
			return !object.Equals(left, right);
		}
	}
}
