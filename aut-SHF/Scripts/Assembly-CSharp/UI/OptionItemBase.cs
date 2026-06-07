using UnityEngine;
using UnityEngine.Events;

namespace UI
{
	public abstract class OptionItemBase : MonoBehaviour
	{
		protected UnityAction<OptionItemBase> onChangeValueAction;

		public virtual void Init(UnityAction<OptionItemBase> onChangeValueAction)
		{
		}

		public abstract int GetValue();

		public abstract void SetValue(int value);

		public abstract void DisableItem(bool disable);
	}
}
