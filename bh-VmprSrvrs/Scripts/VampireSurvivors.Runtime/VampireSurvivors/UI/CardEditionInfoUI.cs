using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.UI
{
	public class CardEditionInfoUI : MonoBehaviour
	{
		[SerializeField]
		private Image _editionImage;

		[SerializeField]
		private TextMeshProUGUI _editionDescription;

		public void SetData(SkillCardEdition cardEdition)
		{
		}
	}
}
