using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	public class UMARandomizer : ScriptableObject
	{
		public List<RandomAvatar> RandomAvatars;

		public int RandomCount => 0;

		public RandomAvatar GetRandomAvatar()
		{
			return null;
		}
	}
}
