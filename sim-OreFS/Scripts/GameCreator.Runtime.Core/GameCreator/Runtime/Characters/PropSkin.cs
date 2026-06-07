using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	internal class PropSkin : IProp
	{
		private readonly GameObject m_Prefab;

		public Transform Bone => null;

		[field: NonSerialized]
		public GameObject Instance { get; private set; }

		public PropSkin(GameObject prefab)
		{
			m_Prefab = prefab;
		}

		public void Create(Animator animator)
		{
			if (!(animator == null) && !(m_Prefab == null))
			{
				Instance = SkinMeshUtils.PutOn(m_Prefab, animator);
			}
		}

		public void Destroy()
		{
			if (!(Instance == null))
			{
				SkinMeshUtils.TakeOff(Instance);
			}
		}

		public void Drop()
		{
			Debug.LogError("Skinned Mesh Renderers cannot be dropped. Use Destroy() instead");
			Destroy();
		}
	}
}
