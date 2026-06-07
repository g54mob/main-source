using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI
{
	public class MultiplayerCharacterDisplay : MonoBehaviour
	{
		protected DataManager Data;

		protected PlayerOptions PlayerOptions;

		protected Sprite CharacterSprite;

		protected Coroutine ShowRoutine;

		private CanvasGroup _cg;

		[Inject]
		private void Construct(DataManager data, PlayerOptions playerOptions)
		{
		}

		private void Awake()
		{
		}

		protected virtual void OnEnable()
		{
		}

		private void OnDestroy()
		{
		}

		public virtual void Show()
		{
		}
	}
}
