using System.Collections.Generic;
using UMA.CharacterSystem;
using UnityEngine;

namespace UMA
{
	public class UMABoneCleaner : MonoBehaviour
	{
		private List<string> KillBones;

		private List<Transform> AllExceptions;

		private List<UMAJiggleBoneListing> removalRegister;

		private UMAData uMAData;

		private DynamicCharacterAvatar avatar;

		public void Awake()
		{
		}

		protected void OnDisable()
		{
		}

		public void CleanBones(UMAData umaData)
		{
		}

		private void ProcessBones(Transform transform, List<Transform> Exceptions)
		{
		}

		private void RecursivelyRemoveChildBones(Transform transform, List<Transform> Exceptions)
		{
		}

		public void RegisterJiggleBone(UMAJiggleBoneListing boneListing)
		{
		}
	}
}
