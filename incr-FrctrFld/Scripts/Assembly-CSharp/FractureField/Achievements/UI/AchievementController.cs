using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FractureField.Achievements.UI
{
	public class AchievementController : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		private GameObject _container;

		[SerializeField]
		private Image _icon;

		[SerializeField]
		private TMP_Text _nameText;

		[SerializeField]
		private TMP_Text _descriptionText;

		public bool IsOpen => false;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void UpdateUI(Achievement achievement)
		{
		}

		public void Clicked()
		{
		}
	}
}
