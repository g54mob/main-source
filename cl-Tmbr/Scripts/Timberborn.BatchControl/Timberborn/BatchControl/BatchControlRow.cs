using System;
using System.Collections.Generic;
using Timberborn.BlockSystem;
using Timberborn.EntitySystem;
using UnityEngine.UIElements;

namespace Timberborn.BatchControl
{
	public class BatchControlRow
	{
		private readonly List<IBatchControlRowItem> _batchControlRowItems = new List<IBatchControlRowItem>();

		private readonly List<IUpdatableBatchControlRowItem> _updatableBatchControlRowItems = new List<IUpdatableBatchControlRowItem>();

		private readonly List<IClearableBatchControlRowItem> _clearableBatchControlRowItems = new List<IClearableBatchControlRowItem>();

		private readonly List<IFinishableBatchControlRowItem> _finishableBatchControlRowItems = new List<IFinishableBatchControlRowItem>();

		private bool _loaded;

		public VisualElement Root { get; }

		public EntityComponent Entity { get; }

		public Func<bool> VisibilityGetter { get; } = () => true;

		public BatchControlRow(VisualElement root, params IBatchControlRowItem[] batchControlRowItems)
		{
			Root = root;
			foreach (IBatchControlRowItem batchControlRowItem in batchControlRowItems)
			{
				AddItem(batchControlRowItem);
			}
		}

		public BatchControlRow(VisualElement root, EntityComponent entity, params IBatchControlRowItem[] batchControlRowItems)
			: this(root, batchControlRowItems)
		{
			Entity = entity;
		}

		public BatchControlRow(VisualElement root, EntityComponent entity, Func<bool> visibilityGetter, params IBatchControlRowItem[] batchControlRowItems)
			: this(root, batchControlRowItems)
		{
			Entity = entity;
			VisibilityGetter = visibilityGetter;
		}

		public void UpdateItems()
		{
			LoadItems();
			foreach (IUpdatableBatchControlRowItem updatableBatchControlRowItem in _updatableBatchControlRowItems)
			{
				updatableBatchControlRowItem.UpdateRowItem();
			}
		}

		public void ClearItems()
		{
			if (!_loaded)
			{
				return;
			}
			foreach (IClearableBatchControlRowItem clearableBatchControlRowItem in _clearableBatchControlRowItems)
			{
				clearableBatchControlRowItem.ClearRowItem();
			}
		}

		public void SetEntityBatchControlsFinishedState(bool isFinished)
		{
			foreach (IFinishableBatchControlRowItem finishableBatchControlRowItem in _finishableBatchControlRowItems)
			{
				finishableBatchControlRowItem.SetFinishedState(isFinished);
			}
		}

		private void AddItem(IBatchControlRowItem batchControlRowItem)
		{
			if (batchControlRowItem != null)
			{
				_batchControlRowItems.Add(batchControlRowItem);
				if (batchControlRowItem is IUpdatableBatchControlRowItem item)
				{
					_updatableBatchControlRowItems.Add(item);
				}
				if (batchControlRowItem is IClearableBatchControlRowItem item2)
				{
					_clearableBatchControlRowItems.Add(item2);
				}
				if (batchControlRowItem is IFinishableBatchControlRowItem item3)
				{
					_finishableBatchControlRowItems.Add(item3);
				}
			}
		}

		private void LoadItems()
		{
			if (_loaded)
			{
				return;
			}
			foreach (IBatchControlRowItem batchControlRowItem in _batchControlRowItems)
			{
				Root.Add(batchControlRowItem.Root);
			}
			if ((bool)Entity)
			{
				BlockObject component = Entity.GetComponent<BlockObject>();
				if (component != null)
				{
					SetEntityBatchControlsFinishedState(component.IsFinished);
				}
			}
			_loaded = true;
		}
	}
}
