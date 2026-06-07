using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.UI.Player
{
	public class HealthBar : MonoBehaviour
	{
		[SerializeField]
		private Image _HealthBar;

		[SerializeField]
		private Image _HealthBarFill;

		private VampireSurvivors.Objects.Characters.CharacterController _character;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void ToggleVisible(bool visible)
		{
		}
	}
}
