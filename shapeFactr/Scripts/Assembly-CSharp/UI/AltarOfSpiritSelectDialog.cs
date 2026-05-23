using System;
using Factory.FieldData;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
	public class AltarOfSpiritSelectDialog : BaseDialog
	{
		[Serializable]
		private class AltarOfSpiritSelectItemInfo
		{
			public FactoryContext.AltarOfSpiritType type;

			public AltarOfSpiritSelectItem item;
		}

		[SerializeField]
		private GameObject closeButton;

		[SerializeField]
		private AltarOfSpiritSelectItemInfo[] altarOfSpiritSelectItems;

		private UnityAction closeAction;

		public override void Init()
		{
		}

		public override void Open()
		{
		}

		public override void Init<T>(T args)
		{
		}

		public override void Open<T>(T args)
		{
		}

		private void InitItems()
		{
		}

		public void UpdateItems()
		{
		}

		public override void Back()
		{
		}
	}
}
