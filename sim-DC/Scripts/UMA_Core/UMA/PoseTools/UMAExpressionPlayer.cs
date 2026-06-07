using System;
using UMA.CharacterSystem;
using UnityEngine;

namespace UMA.PoseTools
{
	[ExecuteInEditMode]
	public class UMAExpressionPlayer : ExpressionPlayer
	{
		public UMAExpressionSet expressionSet;

		public float minWeight;

		[NonSerialized]
		public UMAData umaData;

		private int jawHash;

		private int neckHash;

		private int headHash;

		private bool standAlone;

		private bool initialized;

		[NonSerialized]
		public int SlotUpdateVsCharacterUpdate;

		public bool logResetErrors;

		public bool useDisableDistance;

		public bool processing;

		private bool EventsAdded;

		public float disableDistance;

		private Transform _mainCameraTransform;

		private DynamicCharacterAvatar avatar;

		public float eyeMovementRange;

		public float mutualGazeRange;

		public float MinSaccadeDelay;

		public float MaxSaccadeMagnitude;

		public float minSaccade;

		public float maxSaccade;

		public bool allowUpDownSaccades;

		public Animator animator;

		private float[] LastValues;

		public UMAExpressionEvent ExpressionChanged;

		private void Start()
		{
		}

		public void Initialize()
		{
		}

		private void CharacterBegun(UMAData _umaData)
		{
		}

		private void SetupBones()
		{
		}

		private void UmaData_OnCharacterUpdated(UMAData obj)
		{
		}

		private void saveValues(float[] values)
		{
		}

		private void Update()
		{
		}

		private void OnAnimatorIK(int layerIndex)
		{
		}

		private void LateUpdate()
		{
		}

		protected void UpdateSaccades()
		{
		}

		private void ClampSaccades()
		{
		}

		protected void UpdateBlinking()
		{
		}
	}
}
