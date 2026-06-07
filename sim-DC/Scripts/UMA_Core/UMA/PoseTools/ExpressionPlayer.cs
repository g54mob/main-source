using System;
using System.Collections.Generic;
using UnityEngine;

namespace UMA.PoseTools
{
	public class ExpressionPlayer : MonoBehaviour
	{
		public enum GazeMode
		{
			None = 0,
			Acquiring = 1,
			Following = 2,
			Speaking = 3,
			Listening = 4
		}

		[Serializable]
		public class Expression
		{
			public string poseName;

			public MecanimJoint overrideBone;

			[Range(0f, 1f)]
			public float value;

			[Range(0f, 1f)]
			public float defaultValue;
		}

		public enum MecanimJoint
		{
			None = 0,
			Head = 1,
			Neck = 2,
			Jaw = 4,
			Eye = 8,
			Hands = 0x10
		}

		public bool enableBlinking;

		public float blinkDuration;

		public float minBlinkDelay;

		public float maxBlinkDelay;

		protected float blinkDelay;

		public bool enableSaccades;

		protected float saccadeDelay;

		protected float saccadeDuration;

		protected float saccadeProgress;

		protected Vector2 saccadeTarget;

		protected Vector2 saccadeTargetPrev;

		public Vector3 gazeTarget;

		public float gazeWeight;

		public GazeMode gazeMode;

		public bool overrideMecanimEyes;

		public bool overrideMecanimJaw;

		public bool overrideMecanimNeck;

		public bool overrideMecanimHead;

		public bool overrideMecanimHands;

		public List<Expression> Expressions;

		public const int PoseCount = 44;

		public static readonly string[] PoseNames;

		public static readonly MecanimJoint[] MecanimAlternate;

		[Range(-1f, 1f)]
		public float neckUp_Down;

		[Range(-1f, 1f)]
		public float neckLeft_Right;

		[Range(-1f, 1f)]
		public float neckTiltLeft_Right;

		[Range(-1f, 1f)]
		public float headUp_Down;

		[Range(-1f, 1f)]
		public float headLeft_Right;

		[Range(-1f, 1f)]
		public float headTiltLeft_Right;

		[Range(-1f, 1f)]
		public float jawOpen_Close;

		[Range(-1f, 1f)]
		public float jawForward_Back;

		[Range(-1f, 1f)]
		public float jawLeft_Right;

		[Range(-1f, 1f)]
		public float mouthLeft_Right;

		[Range(-1f, 1f)]
		public float mouthUp_Down;

		[Range(-1f, 1f)]
		public float mouthNarrow_Pucker;

		[Range(-1f, 1f)]
		public float tongueOut;

		[Range(0f, 1f)]
		public float tongueCurl;

		[Range(-1f, 1f)]
		public float tongueUp_Down;

		[Range(-1f, 1f)]
		public float tongueLeft_Right;

		[Range(-1f, 1f)]
		public float tongueWide_Narrow;

		[Range(-1f, 1f)]
		public float leftMouthSmile_Frown;

		[Range(-1f, 1f)]
		public float rightMouthSmile_Frown;

		[Range(-1f, 1f)]
		public float leftLowerLipUp_Down;

		[Range(-1f, 1f)]
		public float rightLowerLipUp_Down;

		[Range(-1f, 1f)]
		public float leftUpperLipUp_Down;

		[Range(-1f, 1f)]
		public float rightUpperLipUp_Down;

		[Range(-1f, 1f)]
		public float leftCheekPuff_Squint;

		[Range(-1f, 1f)]
		public float rightCheekPuff_Squint;

		[Range(0f, 1f)]
		public float noseSneer;

		[Range(-1f, 1f)]
		public float leftEyeOpen_Close;

		[Range(-1f, 1f)]
		public float rightEyeOpen_Close;

		[Range(-1f, 1f)]
		public float leftEyeUp_Down;

		[Range(-1f, 1f)]
		public float rightEyeUp_Down;

		[Range(-1f, 1f)]
		public float leftEyeIn_Out;

		[Range(-1f, 1f)]
		public float rightEyeIn_Out;

		[Range(0f, 1f)]
		public float browsIn;

		[Range(-1f, 1f)]
		public float leftBrowUp_Down;

		[Range(-1f, 1f)]
		public float rightBrowUp_Down;

		[Range(-1f, 1f)]
		public float midBrowUp_Down;

		[Range(0f, 1f)]
		public float leftGrasp;

		[Range(0f, 1f)]
		public float rightGrasp;

		[Range(0f, 1f)]
		public float leftPeace;

		[Range(0f, 1f)]
		public float rightPeace;

		[Range(0f, 1f)]
		public float leftRude;

		[Range(0f, 1f)]
		public float rightRude;

		[Range(0f, 1f)]
		public float leftPoint;

		[Range(0f, 1f)]
		public float rightPoint;

		protected float[] valueArray;

		public float[] Values
		{
			get
			{
				return null;
			}
			set
			{
			}
		}
	}
}
