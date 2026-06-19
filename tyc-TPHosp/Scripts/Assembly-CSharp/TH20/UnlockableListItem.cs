using UnityEngine;

namespace TH20
{
	public class UnlockableListItem : MonoBehaviour
	{
		[SerializeField]
		private GameObject LockedImage;

		[SerializeField]
		private Material LockedMaterial;

		protected bool _unlocked;

		protected Material GetLockedMaterial()
		{
			if (!_unlocked)
			{
				return LockedMaterial;
			}
			return null;
		}

		protected bool IsUnlocked()
		{
			return _unlocked;
		}

		protected virtual void SetUnlocked(bool unlocked)
		{
			_unlocked = unlocked;
			GameObjectUtils.SetActive(LockedImage, !unlocked);
		}
	}
}
