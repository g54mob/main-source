using System;

namespace UMA
{
	[Serializable]
	public class UMADnaHumanoid : UMADna
	{
		public float height;

		public float headSize;

		public float headWidth;

		public float neckThickness;

		public float armLength;

		public float forearmLength;

		public float armWidth;

		public float forearmWidth;

		public float handsSize;

		public float feetSize;

		public float legSeparation;

		public float upperMuscle;

		public float lowerMuscle;

		public float upperWeight;

		public float lowerWeight;

		public float legsSize;

		public float belly;

		public float waist;

		public float gluteusSize;

		public float earsSize;

		public float earsPosition;

		public float earsRotation;

		public float noseSize;

		public float noseCurve;

		public float noseWidth;

		public float noseInclination;

		public float nosePosition;

		public float nosePronounced;

		public float noseFlatten;

		public float chinSize;

		public float chinPronounced;

		public float chinPosition;

		public float mandibleSize;

		public float jawsSize;

		public float jawsPosition;

		public float cheekSize;

		public float cheekPosition;

		public float lowCheekPronounced;

		public float lowCheekPosition;

		public float foreheadSize;

		public float foreheadPosition;

		public float lipsSize;

		public float mouthSize;

		public float eyeRotation;

		public float eyeSize;

		public float breastSize;

		public override int Count => 0;

		public override float[] Values
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override string[] Names => null;

		public override float GetValue(int idx)
		{
			return 0f;
		}

		public override void SetValue(int idx, float value)
		{
		}

		public static string[] GetNames()
		{
			return null;
		}

		public static UMADnaHumanoid LoadInstance(string data)
		{
			return null;
		}

		public static string SaveInstance(UMADnaHumanoid instance)
		{
			return null;
		}
	}
}
