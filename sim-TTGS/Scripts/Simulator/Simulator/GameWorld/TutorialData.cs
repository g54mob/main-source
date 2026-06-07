using Dhs5.Utility.Databases;
using I2.Loc;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class TutorialData : BaseDataContainerScriptableElement
	{
		[SerializeField]
		private Sprite m_sprite;

		[SerializeField]
		[TermsPopup("")]
		private string m_titleTerm;

		[SerializeField]
		[TermsPopup("")]
		private string m_descriptionTerm;

		public Sprite Sprite => m_sprite;

		public string TitleTerm => m_titleTerm;

		public string DescriptionTerm => m_descriptionTerm;
	}
}
