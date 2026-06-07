using Dhs5.Utility.Databases;
using UnityEngine;

namespace Simulator.GameWorld
{
	public abstract class DirtData : BaseDataContainerScriptableElement
	{
		public enum EType
		{
			TRASH = 1,
			STAIN = 2
		}

		[Header("References")]
		[SerializeField]
		private EType m_type;

		[SerializeField]
		private Dirt m_prefab;

		public EType DirtType => m_type;

		public Dirt Prefab => m_prefab;
	}
}
