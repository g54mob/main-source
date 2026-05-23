using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace LVA.Puppeteers.Humanoid
{
	[Serializable]
	public class IKReferences
	{
		[field: SerializeField]
		public bmi FullBodyBiped { get; private set; }

		[field: SerializeField]
		public bmb Grounder { get; private set; }

		[field: SerializeField]
		public bml RightLeg { get; private set; }

		[field: SerializeField]
		public bml LeftLeg { get; private set; }

		public rd roh
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

		public void goq()
		{
		}
	}
}
