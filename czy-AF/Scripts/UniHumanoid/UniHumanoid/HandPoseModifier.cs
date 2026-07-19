using System;
using UnityEngine;

namespace UniHumanoid
{
	public class HandPoseModifier : IPoseModifier
	{
		public class HandPose
		{
			public float ThumbStretch;

			public float ThumbSpread;

			public float IndexStretch;

			public float IndexSpread;

			public float MiddleStretch;

			public float MiddleSpread;

			public float RingStretch;

			public float RingSpread;

			public float LittleStretch;

			public float LittleSpread;

			[Obsolete("Use ThumbStretch")]
			public float ThumbStrech
			{
				get
				{
					return ThumbStretch;
				}
				set
				{
					ThumbStretch = value;
				}
			}

			[Obsolete("Use IndexStretch")]
			public float IndexStrech
			{
				get
				{
					return IndexStretch;
				}
				set
				{
					IndexStretch = value;
				}
			}

			[Obsolete("Use MiddleStretch")]
			public float MiddleStrech
			{
				get
				{
					return MiddleStretch;
				}
				set
				{
					MiddleStretch = value;
				}
			}

			[Obsolete("Use RingStretch")]
			public float RingStrech
			{
				get
				{
					return RingStretch;
				}
				set
				{
					RingStretch = value;
				}
			}

			[Obsolete("Use LittleStretch")]
			public float LittleStrech
			{
				get
				{
					return LittleStretch;
				}
				set
				{
					LittleStretch = value;
				}
			}
		}

		private int LeftThumb1Stretched;

		private int LeftThumb2Stretched;

		private int LeftThumb3Stretched;

		private int LeftIndex1Stretched;

		private int LeftIndex2Stretched;

		private int LeftIndex3Stretched;

		private int LeftMiddle1Stretched;

		private int LeftMiddle2Stretched;

		private int LeftMiddle3Stretched;

		private int LeftRing1Stretched;

		private int LeftRing2Stretched;

		private int LeftRing3Stretched;

		private int LeftLittle1Stretched;

		private int LeftLittle2Stretched;

		private int LeftLittle3Stretched;

		private int LeftThumbSpread;

		private int LeftIndexSpread;

		private int LeftMiddleSpread;

		private int LeftRingSpread;

		private int LeftLittleSpread;

		private int RightThumb1Stretched;

		private int RightThumb2Stretched;

		private int RightThumb3Stretched;

		private int RightIndex1Stretched;

		private int RightIndex2Stretched;

		private int RightIndex3Stretched;

		private int RightMiddle1Stretched;

		private int RightMiddle2Stretched;

		private int RightMiddle3Stretched;

		private int RightRing1Stretched;

		private int RightRing2Stretched;

		private int RightRing3Stretched;

		private int RightLittle1Stretched;

		private int RightLittle2Stretched;

		private int RightLittle3Stretched;

		private int RightThumbSpread;

		private int RightIndexSpread;

		private int RightMiddleSpread;

		private int RightRingSpread;

		private int RightLittleSpread;

		public HandPose LeftHandPose { get; set; }

		public HandPose RightHandPose { get; set; }

		public HandPoseModifier()
		{
			LeftThumb1Stretched = Array.IndexOf(HumanTrait.MuscleName, "Left Thumb 1 Stretched");
			LeftThumb2Stretched = Array.IndexOf(HumanTrait.MuscleName, "Left Thumb 2 Stretched");
			LeftThumb3Stretched = Array.IndexOf(HumanTrait.MuscleName, "Left Thumb 3 Stretched");
			LeftIndex1Stretched = Array.IndexOf(HumanTrait.MuscleName, "Left Index 1 Stretched");
			LeftIndex2Stretched = Array.IndexOf(HumanTrait.MuscleName, "Left Index 2 Stretched");
			LeftIndex3Stretched = Array.IndexOf(HumanTrait.MuscleName, "Left Index 3 Stretched");
			LeftMiddle1Stretched = Array.IndexOf(HumanTrait.MuscleName, "Left Middle 1 Stretched");
			LeftMiddle2Stretched = Array.IndexOf(HumanTrait.MuscleName, "Left Middle 2 Stretched");
			LeftMiddle3Stretched = Array.IndexOf(HumanTrait.MuscleName, "Left Middle 3 Stretched");
			LeftRing1Stretched = Array.IndexOf(HumanTrait.MuscleName, "Left Ring 1 Stretched");
			LeftRing2Stretched = Array.IndexOf(HumanTrait.MuscleName, "Left Ring 2 Stretched");
			LeftRing3Stretched = Array.IndexOf(HumanTrait.MuscleName, "Left Ring 3 Stretched");
			LeftLittle1Stretched = Array.IndexOf(HumanTrait.MuscleName, "Left Little 1 Stretched");
			LeftLittle2Stretched = Array.IndexOf(HumanTrait.MuscleName, "Left Little 2 Stretched");
			LeftLittle3Stretched = Array.IndexOf(HumanTrait.MuscleName, "Left Little 3 Stretched");
			LeftThumbSpread = Array.IndexOf(HumanTrait.MuscleName, "Left Thumb Spread");
			LeftIndexSpread = Array.IndexOf(HumanTrait.MuscleName, "Left Index Spread");
			LeftMiddleSpread = Array.IndexOf(HumanTrait.MuscleName, "Left Middle Spread");
			LeftRingSpread = Array.IndexOf(HumanTrait.MuscleName, "Left Ring Spread");
			LeftLittleSpread = Array.IndexOf(HumanTrait.MuscleName, "Left Little Spread");
			RightThumb1Stretched = Array.IndexOf(HumanTrait.MuscleName, "Right Thumb 1 Stretched");
			RightThumb2Stretched = Array.IndexOf(HumanTrait.MuscleName, "Right Thumb 2 Stretched");
			RightThumb3Stretched = Array.IndexOf(HumanTrait.MuscleName, "Right Thumb 3 Stretched");
			RightIndex1Stretched = Array.IndexOf(HumanTrait.MuscleName, "Right Index 1 Stretched");
			RightIndex2Stretched = Array.IndexOf(HumanTrait.MuscleName, "Right Index 2 Stretched");
			RightIndex3Stretched = Array.IndexOf(HumanTrait.MuscleName, "Right Index 3 Stretched");
			RightMiddle1Stretched = Array.IndexOf(HumanTrait.MuscleName, "Right Middle 1 Stretched");
			RightMiddle2Stretched = Array.IndexOf(HumanTrait.MuscleName, "Right Middle 2 Stretched");
			RightMiddle3Stretched = Array.IndexOf(HumanTrait.MuscleName, "Right Middle 3 Stretched");
			RightRing1Stretched = Array.IndexOf(HumanTrait.MuscleName, "Right Ring 1 Stretched");
			RightRing2Stretched = Array.IndexOf(HumanTrait.MuscleName, "Right Ring 2 Stretched");
			RightRing3Stretched = Array.IndexOf(HumanTrait.MuscleName, "Right Ring 3 Stretched");
			RightLittle1Stretched = Array.IndexOf(HumanTrait.MuscleName, "Right Little 1 Stretched");
			RightLittle2Stretched = Array.IndexOf(HumanTrait.MuscleName, "Right Little 2 Stretched");
			RightLittle3Stretched = Array.IndexOf(HumanTrait.MuscleName, "Right Little 3 Stretched");
			RightThumbSpread = Array.IndexOf(HumanTrait.MuscleName, "Right Thumb Spread");
			RightIndexSpread = Array.IndexOf(HumanTrait.MuscleName, "Right Index Spread");
			RightMiddleSpread = Array.IndexOf(HumanTrait.MuscleName, "Right Middle Spread");
			RightRingSpread = Array.IndexOf(HumanTrait.MuscleName, "Right Ring Spread");
			RightLittleSpread = Array.IndexOf(HumanTrait.MuscleName, "Right Little Spread");
		}

		public void Modify(ref HumanPose pose)
		{
			if (LeftHandPose != null)
			{
				pose.muscles[LeftThumb1Stretched] = LeftHandPose.ThumbStretch;
				pose.muscles[LeftThumb2Stretched] = LeftHandPose.ThumbStretch;
				pose.muscles[LeftThumb3Stretched] = LeftHandPose.ThumbStretch;
				pose.muscles[LeftIndex1Stretched] = LeftHandPose.IndexStretch;
				pose.muscles[LeftIndex2Stretched] = LeftHandPose.IndexStretch;
				pose.muscles[LeftIndex3Stretched] = LeftHandPose.IndexStretch;
				pose.muscles[LeftMiddle1Stretched] = LeftHandPose.MiddleStretch;
				pose.muscles[LeftMiddle2Stretched] = LeftHandPose.MiddleStretch;
				pose.muscles[LeftMiddle3Stretched] = LeftHandPose.MiddleStretch;
				pose.muscles[LeftRing1Stretched] = LeftHandPose.RingStretch;
				pose.muscles[LeftRing2Stretched] = LeftHandPose.RingStretch;
				pose.muscles[LeftRing3Stretched] = LeftHandPose.RingStretch;
				pose.muscles[LeftLittle1Stretched] = LeftHandPose.LittleStretch;
				pose.muscles[LeftLittle2Stretched] = LeftHandPose.LittleStretch;
				pose.muscles[LeftLittle3Stretched] = LeftHandPose.LittleStretch;
				pose.muscles[LeftThumbSpread] = LeftHandPose.ThumbSpread;
				pose.muscles[LeftIndexSpread] = LeftHandPose.IndexSpread;
				pose.muscles[LeftMiddleSpread] = LeftHandPose.MiddleSpread;
				pose.muscles[LeftRingSpread] = LeftHandPose.RingSpread;
				pose.muscles[LeftLittleSpread] = LeftHandPose.LittleSpread;
			}
			if (RightHandPose != null)
			{
				pose.muscles[RightThumb1Stretched] = RightHandPose.ThumbStretch;
				pose.muscles[RightThumb2Stretched] = RightHandPose.ThumbStretch;
				pose.muscles[RightThumb3Stretched] = RightHandPose.ThumbStretch;
				pose.muscles[RightIndex1Stretched] = RightHandPose.IndexStretch;
				pose.muscles[RightIndex2Stretched] = RightHandPose.IndexStretch;
				pose.muscles[RightIndex3Stretched] = RightHandPose.IndexStretch;
				pose.muscles[RightMiddle1Stretched] = RightHandPose.MiddleStretch;
				pose.muscles[RightMiddle2Stretched] = RightHandPose.MiddleStretch;
				pose.muscles[RightMiddle3Stretched] = RightHandPose.MiddleStretch;
				pose.muscles[RightRing1Stretched] = RightHandPose.RingStretch;
				pose.muscles[RightRing2Stretched] = RightHandPose.RingStretch;
				pose.muscles[RightRing3Stretched] = RightHandPose.RingStretch;
				pose.muscles[RightLittle1Stretched] = RightHandPose.LittleStretch;
				pose.muscles[RightLittle2Stretched] = RightHandPose.LittleStretch;
				pose.muscles[RightLittle3Stretched] = RightHandPose.LittleStretch;
				pose.muscles[RightThumbSpread] = RightHandPose.ThumbSpread;
				pose.muscles[RightIndexSpread] = RightHandPose.IndexSpread;
				pose.muscles[RightMiddleSpread] = RightHandPose.MiddleSpread;
				pose.muscles[RightRingSpread] = RightHandPose.RingSpread;
				pose.muscles[RightLittleSpread] = RightHandPose.LittleSpread;
			}
		}
	}
}
