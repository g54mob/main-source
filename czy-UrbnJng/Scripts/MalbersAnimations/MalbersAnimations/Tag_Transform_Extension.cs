using UnityEngine;

namespace MalbersAnimations
{
	public static class Tag_Transform_Extension
	{
		public static bool HasMalbersTag(this Transform t, Tag tag)
		{
			return Tags.TagsHolders.Exists((Tags x) => x.transform == t && x.HasTag(tag));
		}

		public static bool HasMalbersTag(this Transform t, params Tag[] tags)
		{
			return Tags.TagsHolders.Exists((Tags x) => x.transform == t && x.HasTag(tags));
		}

		public static bool HasMalbersTag(this GameObject t, Tag tag)
		{
			return t.transform.HasMalbersTag(tag);
		}

		public static bool HasMalbersTag(this Component t, Tag tag)
		{
			return t.transform.HasMalbersTag(tag);
		}

		public static bool HasMalbersTag(this GameObject t, params Tag[] tags)
		{
			return t.transform.HasMalbersTag(tags);
		}

		private static Tags GetTag(GameObject t)
		{
			return t.GetComponentInParent<Tags>(includeInactive: false);
		}

		public static GameObject FindWithMalbersTag(this GameObject t, Tag tag)
		{
			Tags[] componentsInChildren = t.GetComponentsInChildren<Tags>(includeInactive: false);
			if (componentsInChildren != null)
			{
				Tags[] array = componentsInChildren;
				foreach (Tags tags in array)
				{
					if (tags.HasTag(tag))
					{
						return tags.gameObject;
					}
				}
			}
			return null;
		}

		public static Transform FindWithMalbersTag(this Transform t, Tag tag)
		{
			Tags[] componentsInChildren = t.GetComponentsInChildren<Tags>(includeInactive: false);
			if (componentsInChildren != null)
			{
				Tags[] array = componentsInChildren;
				foreach (Tags tags in array)
				{
					if (tags.HasTag(tag))
					{
						return tags.transform;
					}
				}
			}
			return null;
		}

		public static bool HasMalbersTagInParent(this Transform t, Tag tag)
		{
			Tags tag2 = GetTag(t.gameObject);
			if (tag2 != null)
			{
				return tag2.HasTag(tag);
			}
			return false;
		}

		public static bool HasMalbersTagInParent(this Transform t, params Tag[] tags)
		{
			Tags tag = GetTag(t.gameObject);
			if (tag != null)
			{
				return tag.HasTag(tags);
			}
			return false;
		}

		public static bool HasMalbersTagInParent(this GameObject t, Tag tag)
		{
			Tags tag2 = GetTag(t);
			if (tag2 != null)
			{
				return tag2.HasTag(tag);
			}
			return false;
		}

		public static bool HasMalbersTagInParent(this GameObject t, params Tag[] tags)
		{
			Tags tag = GetTag(t);
			if (tag != null)
			{
				return tag.HasTag(tags);
			}
			return false;
		}
	}
}
