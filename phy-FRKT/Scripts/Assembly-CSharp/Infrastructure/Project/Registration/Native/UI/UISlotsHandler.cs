using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using Views.Hints;

namespace Infrastructure.Project.Registration.Native.UI
{
	[Serializable]
	public class UISlotsHandler : NativePrefabsGroupHandler, bgl
	{
		[SerializeField]
		private HintSlot m_hintSlot;

		[CompilerGenerated]
		private PrefabPassport<HintSlot> _003Csyb_003Ek__BackingField;

		public PrefabPassport<HintSlot> xna
		{
			[CompilerGenerated]
			get
			{
				return null;
			}
			[CompilerGenerated]
			private set
			{
			}
		}

		public override void isj()
		{
		}
	}
}
