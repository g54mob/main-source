using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Pug.Automation
{
	[DisallowMultipleComponent]
	public class AutomatedMinerAuthoring : MonoBehaviour
	{
		public List<int2> damagePositions = new List<int2>
		{
			new int2(0, 0)
		};

		public int damage;

		public float cooldownTime;
	}
}
