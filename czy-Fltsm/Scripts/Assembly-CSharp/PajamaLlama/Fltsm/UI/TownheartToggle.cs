using UnityEngine;

namespace PajamaLlama.Fltsm.UI
{
	public class TownheartToggle : AnimatedToggle
	{
		[Header("Townheart Toggle")]
		[SerializeField]
		private BuildableProperties _townheartProperties;

		[SerializeReference]
		[InstantiateSerializeReference]
		private IPlatformRequirement _requirement;

		public BuildableProperties TownheartProperties => _townheartProperties;

		public bool Activate()
		{
			bool flag = _requirement == null || _requirement.IsMet();
			base.gameObject.SetActive(flag);
			return flag;
		}
	}
}
