using Assets.Scripts.Input;
using UnityEngine;

namespace Assets.Scripts.Character
{
	public class CharacterBrain : MonoBehaviour
	{
		private CharacterActions _actions;

		[SerializeField]
		private bool _isPlayer = true;

		public CharacterActions Actions
		{
			get
			{
				return _actions;
			}
			set
			{
				_actions = value;
			}
		}

		public bool IsPlayer
		{
			get
			{
				return _isPlayer;
			}
			set
			{
				_isPlayer = value;
			}
		}

		protected void Awake()
		{
			_actions.InitializeActions();
		}

		protected void Update()
		{
			if (_isPlayer && Game.Instance.UserInterface.AllowKeyboardInputs)
			{
				_actions.SetValues(GameInputs.Instance);
			}
			_actions.Update(Time.deltaTime);
		}
	}
}
