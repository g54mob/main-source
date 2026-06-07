using DV.Utils;
using UnityEngine;

namespace DV.Interaction
{
	public class KeyUse : MonoBehaviour, IItemUse
	{
		private PadlockKey key;

		private void Awake()
		{
			key = GetComponent<PadlockKey>();
		}

		public bool HandleHover(ItemUseTarget target)
		{
			if (VRManager.IsVREnabled())
			{
				return false;
			}
			SingletonBehaviour<InteractionTextControllerNonVr>.Instance.DisplayText(InteractionInfoType.KeyPadlockUse);
			return true;
		}

		public bool HandleUse(ItemUseTarget target)
		{
			Padlock component = target.GetComponent<Padlock>();
			if (component == null)
			{
				return false;
			}
			component.TryToUnlock(key);
			return true;
		}

		public bool IsHoverCompatible(ItemUseTarget target)
		{
			return IsUseCompatible(target);
		}

		public bool IsUseCompatible(ItemUseTarget target)
		{
			Padlock component = target.GetComponent<Padlock>();
			if (component != null && component.IsLocked)
			{
				return component.unlockingKey == key.keyType;
			}
			return false;
		}
	}
}
