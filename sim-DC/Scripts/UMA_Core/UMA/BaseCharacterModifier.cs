using System;
using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public class BaseCharacterModifier
	{
		[AttributeUsage(AttributeTargets.Field)]
		public class ConfigAttribute : Attribute
		{
			public bool alwaysExpanded;

			public ConfigAttribute(bool alwaysExpanded)
			{
			}
		}

		[Tooltip("If true the characters 'base scale' will be adjusted using the given scale value on the given bone. For rigs based on the standard UMA Rig, this is usually the 'Position' bone.")]
		[SerializeField]
		private bool _adjustScale;

		[Tooltip("Adjust the height calculation for the character. Head Ratio is how many 'heads high' the character is (classically proportioned character's total height = 7.5 * head height). Bigger heads have a smaller ratio. You can make further manual adjustments using the 'Y' setting. The playmode 'Height Debug' tools in the Converter Customiser scene will help you.")]
		[SerializeField]
		private bool _adjustHeight;

		[Tooltip("Manually adds an X and Z amount when calculating the characters radius.")]
		[SerializeField]
		private bool _adjustRadius;

		[SerializeField]
		private bool _adjustMass;

		[Tooltip("Should the bounds be updated when the dna changes. Turn this on if you are permitting large dna changes on your character.")]
		[SerializeField]
		private bool _updateBounds;

		[Tooltip("Checking this will make the bounds tight to the characters head/feet. You can manually adjust the bounds futher using 'Adjust Bounds' below.")]
		[SerializeField]
		private bool _tightenBounds;

		[Tooltip("Manually adds extra padding to the characters bounds")]
		[SerializeField]
		private bool _adjustBounds;

		[SerializeField]
		private float _scale;

		[SerializeField]
		private string _bone;

		[SerializeField]
		private int _scaleBoneHash;

		[SerializeField]
		private float _headRatio;

		[SerializeField]
		private float _radiusAdjustY;

		[SerializeField]
		private Vector2 _radiusAdjust;

		[Tooltip("This is used to adjust the characters mass.")]
		[SerializeField]
		private Vector3 _massAdjust;

		[SerializeField]
		private Vector3 _boundsAdjust;

		[NonSerialized]
		private Dictionary<string, int> _mechanimBoneDict;

		[NonSerialized]
		private string _lastRace;

		[NonSerialized]
		private bool boundsAdjustmentApplied;

		[NonSerialized]
		private float _liveScale;

		public bool adjustScale => false;

		public bool adjustHeight => false;

		public bool adjustRadius => false;

		public bool adjustMass => false;

		public bool updateBounds => false;

		public bool tightenBounds => false;

		public bool adjustBounds => false;

		public float scale => 0f;

		public int scaleBoneHash => 0;

		public float headRatio => 0f;

		public float radiusAdjustY => 0f;

		public Vector2 radiusAdjust => default(Vector2);

		public Vector3 massAdjust => default(Vector3);

		public Vector3 boundsAdjust => default(Vector3);

		public float liveScale
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public BaseCharacterModifier()
		{
		}

		public BaseCharacterModifier(bool overallModifiersEnabled, float overallScale, string overallScaleBone, int overallScaleBoneHash, bool tightenBounds, Vector3 boundsAdjust, Vector2 radiusAdjust, Vector3 massModifiers)
		{
		}

		public void AdjustScale(UMASkeleton skeleton)
		{
		}

		public void UpdateCharacterHeightMassRadius(UMAData umaData, UMASkeleton skeleton)
		{
		}

		public void UpdateCharacter(UMAData umaData, UMASkeleton skeleton, bool asReset)
		{
		}

		private Bounds DoBoundsModifications(SkinnedMeshRenderer targetRenderer, UMAData umaData)
		{
			return default(Bounds);
		}

		private SkinnedMeshRenderer GetBaseRenderer(UMAData umaData, int rendererToGet = 0)
		{
			return null;
		}

		private void UpdateMechanimBoneDict(UMAData umaData, UMASkeleton skeleton)
		{
		}

		private void UpdateCharacterHeightMassRadius(UMAData umaData, UMASkeleton skeleton, Bounds newBounds)
		{
		}
	}
}
