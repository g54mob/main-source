using System;
using System.Collections.Generic;
using System.Linq;
using Platforms;
using UnityEngine;

namespace KitchenData
{
	public class GameData : IEquatable<GameData>, IDisposable
	{
		public static GameData Main;

		public StringSubstitutor Substitutions;

		public GlobalLocalisation GlobalLocalisation;

		public ProcessesView ProcessesView;

		public ItemSetView ItemSetView;

		public DecoratorPrefabView DecoratorPrefabView;

		public bool IsUserGeneratedContentAllowed = PlatformSettings.AllowUGC;

		public GameDifficultySettings Difficulty;

		public Dictionary<int, GameDataObject> Objects;

		public Dictionary<int, GameObject> Prefabs;

		public ReferableObjects ReferableObjects;

		public List<FontLookup> Fonts;

		public string Parse(string str)
		{
			return Substitutions.Parse(str);
		}

		public GameData(int size)
		{
			Prefabs = new Dictionary<int, GameObject>();
			ReferableObjects = default(ReferableObjects);
			Objects = new Dictionary<int, GameDataObject>();
		}

		public void InitialiseViews()
		{
			ProcessesView = new ProcessesView();
			ProcessesView.Initialise(this);
			ItemSetView = new ItemSetView();
			ItemSetView.Initialise(this);
			DecoratorPrefabView = new DecoratorPrefabView();
			DecoratorPrefabView.Initialise(this);
		}

		public void Dispose()
		{
			ProcessesView.Dispose();
			ItemSetView.Dispose();
			DecoratorPrefabView.Dispose();
		}

		public void ReLocalise(Locale l)
		{
			if ((bool)GlobalLocalisation)
			{
				GlobalLocalisation.Localise(l, Substitutions);
			}
			if (Objects != null)
			{
				foreach (KeyValuePair<int, GameDataObject> @object in Objects)
				{
					try
					{
						@object.Value.Localise(l, Substitutions);
					}
					catch (Exception arg)
					{
						Debug.LogWarning($"Failed to localise {@object.Value.name} to {l}: {arg}");
						try
						{
							@object.Value.Localise(Locale.English, Substitutions);
						}
						catch (Exception arg2)
						{
							Debug.LogWarning($"Failed to localise {@object.Value.name} to {Locale.English}: {arg2}");
						}
					}
				}
			}
			if (Fonts == null)
			{
				return;
			}
			foreach (FontLookup font in Fonts)
			{
				font.SetLocale(l);
			}
		}

		public T Get<T>(int id) where T : GameDataObject
		{
			return (T)Objects[id];
		}

		public ICard GetCard(int id)
		{
			return (ICard)Objects[id];
		}

		public GameDataObject Get(int id)
		{
			return Objects[id];
		}

		public bool Has(int id)
		{
			return Objects.ContainsKey(id);
		}

		public bool Has<T>(int id)
		{
			if (Objects.ContainsKey(id))
			{
				return Objects[id] is T;
			}
			return false;
		}

		public bool TryGet<T>(int id, out T output, bool warn_if_fail = false)
		{
			if (Objects.TryGetValue(id, out var value) && value is T val)
			{
				output = val;
				return true;
			}
			if (warn_if_fail)
			{
				Debug.LogError($"Failed to find {typeof(T)} with ID {id}");
			}
			output = default(T);
			return false;
		}

		public IEnumerable<ICard> GetCards()
		{
			return (from o in Objects
				where o.Value is ICard
				select o.Value).Cast<ICard>();
		}

		public IEnumerable<T> Get<T>() where T : GameDataObject
		{
			return (from o in Objects
				where o.Value is T
				select o.Value).Cast<T>();
		}

		public GameObject GetPrefab(int item)
		{
			return Prefabs[item];
		}

		public bool Equals(GameData other)
		{
			if ((object)other == null)
			{
				return false;
			}
			if ((object)this == other)
			{
				return true;
			}
			return object.Equals(Objects, other.Objects);
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
			return Equals((GameData)obj);
		}

		public override int GetHashCode()
		{
			if (Objects == null)
			{
				return 0;
			}
			return Objects.GetHashCode();
		}

		public static bool operator ==(GameData left, GameData right)
		{
			return object.Equals(left, right);
		}

		public static bool operator !=(GameData left, GameData right)
		{
			return !object.Equals(left, right);
		}
	}
}
