using System.Collections.Generic;
using Items;
using JSAM;
using MyBox;
using UnityEngine;

namespace AssembleSystem.Utils
{
	[CreateAssetMenu(menuName = "Assemble/Part")]
	public class PartConfig : ScriptableObject
	{
		[ReadOnly(new string[] { })]
		public string Name;

		[Header("WARNING! BE Careful when chaning positions")]
		public Vector3 AssembledPosition;

		[ReadOnly(new string[] { })]
		public Quaternion AssembledRotation;

		public List<SoundFileObject> EquipSounds;

		public List<PartConfig> NecessaryAssembleParts;

		public ProgressToolType ToolType;

		public int SavePriority;

		public void PlayEquipSounds()
		{
			foreach (SoundFileObject equipSound in EquipSounds)
			{
				AudioManager.PlaySound(equipSound);
			}
		}
	}
}
