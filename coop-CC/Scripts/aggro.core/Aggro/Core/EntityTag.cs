using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Aggro.Core
{
	public class EntityTag : EntityBehaviourBase, ITaggedAsset
	{
		[Serializable]
		private class TagListLayer
		{
			public string label;

			public TagList tags = new TagList();
		}

		[SerializeField]
		private TagList _baseTags;

		[SerializeField]
		private TagList _activeTags = new TagList();

		[SerializeField]
		private List<TagListLayer> _layers = new List<TagListLayer>();

		[NonSerialized]
		private bool _isDirty = true;

		public const int TAGS_LAYER_BASE = 0;

		internal TagList activeTags => _activeTags;

		public int tagVersion { get; private set; }

		protected override void OnInitializeBehaviour()
		{
			_layers.Clear();
			AddTags(0, _baseTags, updateActiveTags: false);
		}

		protected override void OnEntityCreated()
		{
			for (int i = 1; i < _layers.Count; i++)
			{
				TagListLayer tagListLayer = _layers[i];
				tagListLayer.label = "";
				tagListLayer.tags.Clear();
			}
			tagVersion = 0;
		}

		protected override void OnEntityStart()
		{
			UpdateActiveTags(forceUpdate: true);
		}

		public TagMask GetTagMask(TagContext context)
		{
			return _activeTags.GetTagMask(context);
		}

		public bool HasAny(TagMask mask)
		{
			return _activeTags.HasAny(mask);
		}

		public bool Has(Tag tag)
		{
			return _activeTags.Has(tag);
		}

		public bool HasAny(IList<Tag> list)
		{
			return _activeTags.HasAny(list);
		}

		public bool HasAny(TagList list)
		{
			return _activeTags.HasAny(list);
		}

		public bool HasAll(TagMask mask)
		{
			return _activeTags.HasAll(mask);
		}

		public bool HasAll(IList<Tag> list)
		{
			return _activeTags.HasAll(list);
		}

		public bool HasAll(TagList list)
		{
			return _activeTags.HasAll(list);
		}

		public bool HasNone(TagMask mask)
		{
			return _activeTags.HasNone(mask);
		}

		public bool DoesNotHave(Tag tag)
		{
			return _activeTags.DoesNotHave(tag);
		}

		public bool HasNone(IList<Tag> list)
		{
			return _activeTags.HasNone(list);
		}

		public bool HasNone(TagList list)
		{
			return _activeTags.HasNone(list);
		}

		[Conditional("UNITY_EDITOR")]
		public void SetLayerName(int layerIndex, string label)
		{
			CheckGrowLayers(layerIndex);
			_layers[layerIndex].label = label;
		}

		public void AddTag(int layerIndex, Tag tag, bool updateActiveTags = true)
		{
			tagVersion++;
			CheckGrowLayers(layerIndex);
			_isDirty = true;
			_layers[layerIndex].tags.AddTag(tag);
			if (updateActiveTags)
			{
				UpdateActiveTags();
			}
		}

		public void AddTags(int layerIndex, TagList tags, bool updateActiveTags = true)
		{
			tagVersion++;
			CheckGrowLayers(layerIndex);
			_isDirty = true;
			_layers[layerIndex].tags.AddTags(tags);
			if (updateActiveTags)
			{
				UpdateActiveTags();
			}
		}

		public void RemoveTag(int layerIndex, Tag tag, bool updateActiveTags = true)
		{
			tagVersion++;
			CheckGrowLayers(layerIndex);
			_isDirty = true;
			_layers[layerIndex].tags.RemoveTag(tag);
			if (updateActiveTags)
			{
				UpdateActiveTags();
			}
		}

		public void RemoveTags(int layerIndex, TagList tags, bool updateActiveTags = true)
		{
			tagVersion++;
			CheckGrowLayers(layerIndex);
			_isDirty = true;
			_layers[layerIndex].tags.RemoveTags(tags);
			if (updateActiveTags)
			{
				UpdateActiveTags();
			}
		}

		public void ResetTags(int layerIndex, bool updateActiveTags = true)
		{
			tagVersion++;
			CheckGrowLayers(layerIndex);
			_isDirty = true;
			_layers[layerIndex].tags.Clear();
			if (updateActiveTags)
			{
				UpdateActiveTags();
			}
		}

		public void UpdateActiveTags(bool forceUpdate = false)
		{
			if (_isDirty || forceUpdate)
			{
				_isDirty = false;
				_activeTags.Clear();
				int count = _layers.Count;
				for (int i = 0; i < count; i++)
				{
					_activeTags.AddTags(_layers[i].tags);
				}
				Tags.UpdateEntityTags(base.entity.key, _activeTags);
				EvGlobalTagChanged ev = new EvGlobalTagChanged
				{
					entity = base.entity
				};
				base.eventManager.QueueGlobalEvent(ev);
			}
		}

		public TagList GetActiveTags()
		{
			return _activeTags;
		}

		public void AddTo(TagList tags)
		{
			tags.AddTags(_activeTags);
		}

		TagList ITaggedAsset.GetAssetTagList()
		{
			return _baseTags;
		}

		private void CheckGrowLayers(int layerIndex)
		{
			while (_layers.Count <= layerIndex)
			{
				TagListLayer tagListLayer = new TagListLayer();
				tagListLayer.label = "";
				tagListLayer.tags.AddTags(_baseTags);
				_layers.Add(tagListLayer);
			}
		}

		private void OnValidate()
		{
			if (Application.isPlaying && Exists())
			{
				UpdateActiveTags();
			}
		}
	}
}
