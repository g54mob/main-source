using System.Collections.Generic;
using UnityEngine;

namespace UMA.Examples
{
	public class PonytailSlotScript : MonoBehaviour
	{
		public bool UseSwayBone;

		public List<string> SwingBoneNames;

		public string AnchorBoneName;

		public float SwingMass;

		public float SwingDrag;

		public float SwingAngularDrag;

		public float SwingRadius;

		public float AnchorColliderRadius;

		public float AnchorMass;

		public bool FreezePositions;

		public Vector3 AnchorOffset;

		public int BoneLayer;

		public float MinGlobalForce;

		public float MaxGlobalForce;

		public float ForceMultiplier;

		public bool ApplyGlobalForces;

		private Transform[] SwingBones;

		private Transform AnchorBone;

		private UMAData umaData;

		public void OnCharacterUpdated(UMAData dta)
		{
		}

		private void SetupSwayBone(Transform t)
		{
		}

		private void SetupSwingBones(List<string> swingBoneNames)
		{
		}

		private Transform SetupAnchorBone(string Name)
		{
			return null;
		}
	}
}
