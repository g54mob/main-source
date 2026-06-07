using System;
using UnityEngine;

namespace Simulator.GameWorld
{
	public abstract class ExtensionModifier : MonoBehaviour
	{
		public enum EModification
		{
			REMOVE = 0,
			ADD = 1
		}

		[Header("Parameters")]
		[Tooltip("Level of extension at which this object's modification will be applied")]
		[SerializeField]
		private int m_level;

		[SerializeField]
		private EModification m_modification;

		protected int Level => m_level;

		protected EModification Modification => m_modification;

		public event Action<bool> Modified;

		protected virtual void OnExtensionBought(int level)
		{
			bool flag = Activate(level);
			base.gameObject.SetActive(flag);
			this.Modified?.Invoke(flag);
		}

		protected virtual bool Activate(int level)
		{
			return Level <= level == (Modification == EModification.ADD);
		}
	}
}
