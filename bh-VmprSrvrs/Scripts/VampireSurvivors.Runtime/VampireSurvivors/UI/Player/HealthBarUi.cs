using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.UI.Player
{
	public class HealthBarUi : MonoBehaviour
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

		public void Initialize(VampireSurvivors.Objects.Characters.CharacterController character)
		{
		}
	}
}
