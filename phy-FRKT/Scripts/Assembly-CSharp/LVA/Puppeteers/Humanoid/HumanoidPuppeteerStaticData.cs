using System.Runtime.CompilerServices;
using UnityEngine;

namespace LVA.Puppeteers.Humanoid
{
	public class HumanoidPuppeteerStaticData : MonoBehaviour
	{
		[field: SerializeField]
		public float PelvisHeight { get; private set; }

		public float rmi
		{
			[CompilerGenerated]
			get
			{
				return 0f;
			}
			[CompilerGenerated]
			private set
			{
			}
		}
	}
}
