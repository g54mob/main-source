using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Stages
{
	public class TPSoftBound
	{
		public Rect Bounds;

		public Rect Containment;

		public TPBiomeType BiomeType;

		public bool IsGreenlight;

		public ItemType KeyToUnlock;

		public bool IgnoreUp;

		public bool IgnoreDown;

		public bool IgnoreLeft;

		public bool IgnoreRight;

		public bool IsAwake;

		public BgmType BGMTrack;
	}
}
