using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Scenes.PartIconStudio
{
	[CreateAssetMenu(fileName = "PartIconData", menuName = "Misc/PartIconData", order = 1)]
	public class PartStudioData : ScriptableObject
	{
		[Serializable]
		public class PartIconData
		{
			public Quaternion lightRotation;

			public string partId;

			public Vector3 position;

			public Quaternion rotation;

			public float scale;
		}

		public List<PartIconData> parts;

		public PartIconData GetPart(string name)
		{
			return parts.FirstOrDefault((PartIconData x) => x.partId == name);
		}
	}
}
