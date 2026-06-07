using TMPro;
using UnityEngine;
using VampireSurvivors.App.Graphics;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.UI.Player
{
	public class MultiplayerRevivalUI : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _revivalBarFill;

		[SerializeField]
		private TextMeshProUGUI _revivalsLeftText;

		[SerializeField]
		private SpriteRenderer _coffinRenderer;

		[SerializeField]
		private SpriteRenderer _ghostRenderer;

		[SerializeField]
		private Sprite[] _revivalBarSprites;

		[SerializeField]
		private MeshRenderer _coffinOutline;

		[SerializeField]
		private ExplodingCoffin _explodingCoffin;

		private VampireSurvivors.Objects.Characters.CharacterController _character;

		private MultiTargetTween _shakeTween;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		private void SetBarFill(float fillProportion)
		{
		}

		public void DoShake(float strength)
		{
		}

		public void OpenLidAnimation()
		{
		}

		private void UpdateCoffinVisuals()
		{
		}

		public void ToggleVisible(bool visible)
		{
		}

		public void SetGhost(bool isGhost)
		{
		}

		public bool IsGhost()
		{
			return false;
		}

		public bool IsVisible()
		{
			return false;
		}
	}
}
