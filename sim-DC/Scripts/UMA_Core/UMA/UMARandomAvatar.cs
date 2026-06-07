using System.Collections.Generic;
using UMA.CharacterSystem;
using UnityEngine;

namespace UMA
{
	public class UMARandomAvatar : MonoBehaviour
	{
		public List<UMARandomizer> Randomizers;

		public GameObject prefab;

		public GameObject ParentObject;

		public bool ShowPlaceholder;

		public bool GenerateGrid;

		public int GridXSize;

		public int GridZSize;

		public float GridDistance;

		public float RandomOffset;

		public bool RandomRotation;

		public string NameBase;

		public UMARandomAvatarEvent RandomAvatarGenerated;

		private DynamicCharacterAvatar RandomAvatar;

		private GameObject character;

		private void Start()
		{
		}

		private Quaternion RandRotation(Quaternion src)
		{
			return default(Quaternion);
		}

		public void GenerateRandomCharacter(Vector3 Pos, Quaternion Rot, string Name)
		{
		}

		public RandomWardrobeSlot GetRandomWardrobe(List<RandomWardrobeSlot> wardrobeSlots)
		{
			return null;
		}

		private OverlayColorData GetRandomColor(RandomColors rc)
		{
			return null;
		}

		private void AddRandomSlot(DynamicCharacterAvatar Avatar, RandomWardrobeSlot uwr)
		{
		}

		public void Randomize(DynamicCharacterAvatar Avatar)
		{
		}
	}
}
