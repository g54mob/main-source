using System.Collections.Generic;
using UnityEngine;

namespace MagicaCloth2
{
	public class RuntimeDressUpDemo : MonoBehaviour
	{
		private class EquipInfo
		{
			public GameObject equipObject;

			public List<ColliderComponent> colliderList;

			public bool IsValid()
			{
				return false;
			}
		}

		public GameObject targetAvatar;

		public GameObject hariEqupPrefab;

		public GameObject bodyEquipPrefab;

		private Dictionary<string, Transform> targetAvatarBoneMap;

		private EquipInfo hairEquipInfo;

		private EquipInfo bodyEquipInfo;

		protected void Start()
		{
		}

		public void OnHairEquipButton()
		{
		}

		public void OnBodyEquipButton()
		{
		}

		private void Init()
		{
		}

		private void Equip(GameObject equipPrefab, EquipInfo einfo)
		{
		}

		private void Remove(EquipInfo einfo)
		{
		}
	}
}
