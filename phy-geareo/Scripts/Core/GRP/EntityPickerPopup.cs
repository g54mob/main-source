using System;
using Rhizomatic;
using Rhizomatic.Pooling;
using Rhizomatic.UI;
using Rhizomatic.Utility;
using UnityEngine;

namespace GRP
{
	public class EntityPickerPopup : PoolObject
	{
		public Transform panel;

		public InputFieldAdapter search;

		public RecyclerLayout layout;

		public EntityPickerView picker;

		public Id id;

		private Action<Id> onSelect;

		private Debouncer debouncer;

		private BackHandlerItem item;

		protected override void OnCreated()
		{
		}

		protected override void OnSpawned()
		{
		}

		protected override void OnPooled()
		{
		}

		public void Setup(EntityPickerView picker, Id id, Action<Id> onSelect)
		{
		}

		public void UpdateList()
		{
		}

		public void Close()
		{
		}
	}
}
