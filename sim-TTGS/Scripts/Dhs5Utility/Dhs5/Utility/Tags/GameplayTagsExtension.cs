using UnityEngine;

namespace Dhs5.Utility.Tags
{
	public static class GameplayTagsExtension
	{
		public static void RegisterGameplayTags(this GameObject gameObject, GameplayTagsList tagsList)
		{
			GameplayTags.Register(gameObject, tagsList);
		}

		public static void RegisterGameplayTags(this Component component, GameplayTagsList tagsList)
		{
			GameplayTags.Register(component, tagsList);
		}

		public static void UnregisterGameplayTags(this GameObject gameObject)
		{
			GameplayTags.Unregister(gameObject);
		}

		public static void UnregisterGameplayTags(this Component component)
		{
			GameplayTags.Unregister(component);
		}

		public static GameplayTagsList GetGameplayTags(this GameObject gameObject)
		{
			return GameplayTags.Get(gameObject);
		}

		public static GameplayTagsList GetGameplayTags(this Component component)
		{
			return GameplayTags.Get(component);
		}

		public static void AddGameplayTags(this GameObject gameObject, GameplayTagsList tagsList)
		{
			GameplayTags.AddTags(gameObject, tagsList);
		}

		public static void AddGameplayTags(this Component component, GameplayTagsList tagsList)
		{
			GameplayTags.AddTags(component, tagsList);
		}

		public static void RemoveGameplayTags(this GameObject gameObject, GameplayTagsList tagsList)
		{
			GameplayTags.RemoveTags(gameObject, tagsList);
		}

		public static void RemoveGameplayTags(this Component component, GameplayTagsList tagsList)
		{
			GameplayTags.RemoveTags(component, tagsList);
		}

		public static bool ContainsGameplayTags(this GameObject gameObject, GameplayTagsList tagsList)
		{
			return GameplayTags.Contains(gameObject, tagsList);
		}

		public static bool ContainsGameplayTags(this Component component, GameplayTagsList tagsList)
		{
			return GameplayTags.Contains(component, tagsList);
		}

		public static bool ContainsAnyGameplayTags(this GameObject gameObject, GameplayTagsList tagsList)
		{
			return GameplayTags.ContainsAny(gameObject, tagsList);
		}

		public static bool ContainsAnyGameplayTags(this Component component, GameplayTagsList tagsList)
		{
			return GameplayTags.ContainsAny(component, tagsList);
		}
	}
}
