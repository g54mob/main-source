using UnityEngine;

namespace Gh.Tk
{
	public class ActorAudioPreference : MonoBehaviour
	{
		[DropDownChoice(new string[] { "Barefoot", "Shoes" })]
		public string footshoeType;

		[DropDownChoice(new string[] { "Cloth", "Armour", "Barrel", "Bone" })]
		public string movementMaterialType;

		public static void ApplyDefaultPreference(Actor actor)
		{
		}

		public void Start()
		{
		}
	}
}
