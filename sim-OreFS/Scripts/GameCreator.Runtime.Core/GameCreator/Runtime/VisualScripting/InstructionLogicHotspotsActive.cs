using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Version(0, 0, 1)]
	[Title("Activate Hotspots")]
	[Description("Determines whether Hotspots can be activated or are inactive by type")]
	[Category("Visual Scripting/Activate Hotspots")]
	[Parameter("Type", "The type of Hotspots to activate or deactivate")]
	[Parameter("Active", "Determines if Hotspots can run or are inactive")]
	[Keywords(new string[] { "Execute", "Enable", "Disable", "Show", "Hide", "Deactivate" })]
	[Image(typeof(IconHotspot), ColorTheme.Type.Yellow)]
	public class InstructionLogicHotspotsActive : Instruction
	{
		[Flags]
		private enum HotspotType
		{
			Radial = 1,
			Interactive = 2,
			AlwaysActive = 4
		}

		[SerializeField]
		private HotspotType m_HotspotsType = HotspotType.Interactive;

		[SerializeField]
		private PropertyGetBool m_Active = GetBoolTrue.Create;

		public override string Title
		{
			get
			{
				string arg = TextUtils.Humanize(m_HotspotsType);
				return $"{arg} Hotspots Active = {m_Active}";
			}
		}

		protected override Task Run(Args args)
		{
			bool flag = m_Active.Get(args);
			bool num = (m_HotspotsType & HotspotType.Radial) != 0;
			bool flag2 = (m_HotspotsType & HotspotType.Interactive) != 0;
			bool flag3 = (m_HotspotsType & HotspotType.AlwaysActive) != 0;
			if (num)
			{
				Hotspot.ActiveInRadius = flag;
			}
			if (flag2)
			{
				Hotspot.ActiveInteractive = flag;
			}
			if (flag3)
			{
				Hotspot.ActiveAlways = flag;
			}
			return Instruction.DefaultResult;
		}
	}
}
