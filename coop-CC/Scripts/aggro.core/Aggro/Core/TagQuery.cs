using System;
using UnityEngine;

namespace Aggro.Core
{
	[Serializable]
	public class TagQuery
	{
		[SerializeField]
		private TagList _requiredTags;

		[SerializeField]
		private TagList _anyTags;

		[SerializeField]
		private TagList _excludeTags;

		public static readonly TagQuery ALL_QUERY = new TagQuery();

		public TagQuery()
		{
			_requiredTags = new TagList();
			_anyTags = new TagList();
			_excludeTags = new TagList();
		}

		public TagQuery(TagList requiredTags, TagList anyTags, TagList excludeTags)
			: this()
		{
			_requiredTags.SetTags(requiredTags);
			_anyTags.SetTags(anyTags);
			_excludeTags.SetTags(excludeTags);
		}

		public TagQuery(TagList requiredTags, TagList excludeTags)
			: this()
		{
			_requiredTags.SetTags(requiredTags);
			_excludeTags.SetTags(excludeTags);
		}

		public bool IsEmpty()
		{
			if (_requiredTags.IsEmpty())
			{
				return _anyTags.IsEmpty();
			}
			return false;
		}

		public bool Evaluate(TagList tags)
		{
			if (!tags.HasAll(_requiredTags))
			{
				return false;
			}
			if (!tags.HasNone(_excludeTags))
			{
				return false;
			}
			if (!_anyTags.IsEmpty() && !tags.HasAny(_anyTags))
			{
				return false;
			}
			return true;
		}

		public bool Evaluate(EntityTag entityTags)
		{
			return Evaluate(entityTags.activeTags);
		}

		public bool Evaluate(Entity entity)
		{
			return Evaluate(entity.tags.activeTags);
		}
	}
}
