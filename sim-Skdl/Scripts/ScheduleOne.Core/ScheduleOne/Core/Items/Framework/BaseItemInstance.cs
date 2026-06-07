using System;
using System.Runtime.CompilerServices;
using ScheduleOne.Core.Equipping.Framework;
using UnityEngine;

namespace ScheduleOne.Core.Items.Framework
{
	[Serializable]
	public abstract class BaseItemInstance
	{
		public const int ApproximateByteSize = 80;

		protected BaseItemDefinition _definition;

		public string ID => null;

		public int Quantity { get; protected set; }

		public virtual string Name => null;

		public virtual string Description => null;

		public virtual Sprite Icon => null;

		public virtual EItemCategory Category => default(EItemCategory);

		public virtual int StackLimit => 0;

		public virtual EquippableData EquippableData => null;

		public event Action onDataChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action requestClearSlot
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public BaseItemInstance(BaseItemDefinition definition, int quantity)
		{
		}

		public virtual bool CanStackWith(BaseItemInstance other, bool checkQuantities = true)
		{
			return false;
		}

		public virtual bool IsValidInstance()
		{
			return false;
		}

		protected void InvokeDataChange()
		{
		}

		public void SetQuantity(int quantity)
		{
		}

		public void ChangeQuantity(int change)
		{
		}

		public virtual float GetMonetaryValue()
		{
			return 0f;
		}

		public void RequestClearSlot()
		{
		}

		public virtual int GetTotalAmount()
		{
			return 0;
		}
	}
}
