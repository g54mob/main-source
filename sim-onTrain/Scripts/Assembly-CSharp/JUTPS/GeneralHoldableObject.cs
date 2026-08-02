using JUTPS.ItemSystem;
using UnityEngine;

namespace JUTPS
{
	[AddComponentMenu("JU TPS/Item System/General Holdable Item")]
	public class GeneralHoldableObject : JUGeneralHoldableItem
	{
		public override bool Weaved()
		{
			return true;
		}
	}
}
