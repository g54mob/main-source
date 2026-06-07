using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Implementation
{
	[AddComponentMenu("Character Controller Pro/Implementation/Character/Character Brain")]
	[DefaultExecutionOrder(int.MinValue)]
	public class CharacterBrain : MonoBehaviour
	{
		public enum UpdateModeType
		{
			FixedUpdate = 0,
			Update = 1
		}

		[Tooltip("Indicates when actions should be consumed.\n\nFixedUpdate (recommended): use this when the gameplay logic needs to run during FixedUpdate.\n\nUpdate: use this when the gameplay logic needs to run every frame during Update.")]
		public UpdateModeType UpdateMode;

		[BooleanButton("Brain type", "Player", "AI", true)]
		[SerializeField]
		private bool isAI;

		[Condition("isAI", ConditionAttribute.ConditionType.IsFalse, ConditionAttribute.VisibilityType.Hidden, 0f)]
		[Expand]
		[SerializeField]
		private InputHandlerSettings inputHandlerSettings = new InputHandlerSettings();

		[Condition("isAI", ConditionAttribute.ConditionType.IsTrue, ConditionAttribute.VisibilityType.Hidden, 0f)]
		[SerializeField]
		private CharacterAIBehaviour aiBehaviour;

		[Expand]
		[ReadOnly]
		[SerializeField]
		private CharacterActions characterActions;

		private CharacterAIBehaviour currentAIBehaviour;

		private bool firstUpdateFlag;

		public bool IsAI => isAI;

		public CharacterActions CharacterActions => characterActions;

		public void SetAction(CharacterActions characterActions)
		{
			this.characterActions = characterActions;
		}

		public void SetBrainType(bool isAI)
		{
			characterActions.Reset();
			if (isAI)
			{
				SetAIBehaviour(aiBehaviour);
			}
			this.isAI = isAI;
		}

		public void SetInputHandler(InputHandler inputHandler)
		{
			if (!(inputHandler == null))
			{
				inputHandlerSettings.InputHandler = inputHandler;
				characterActions.Reset();
			}
		}

		public void SetAIBehaviour(CharacterAIBehaviour aiBehaviour)
		{
			if (!(aiBehaviour == null))
			{
				currentAIBehaviour?.ExitBehaviour(Time.deltaTime);
				characterActions.Reset();
				currentAIBehaviour = aiBehaviour;
				currentAIBehaviour.EnterBehaviour(Time.deltaTime);
			}
		}

		public void UpdateBrainValues(float dt)
		{
			if (Time.timeScale != 0f)
			{
				if (IsAI)
				{
					UpdateAIBrainValues(dt);
				}
				else
				{
					UpdateHumanBrainValues(dt);
				}
			}
		}

		private void UpdateHumanBrainValues(float dt)
		{
			characterActions.SetValues(inputHandlerSettings.InputHandler);
			characterActions.Update(dt);
		}

		private void UpdateAIBrainValues(float dt)
		{
			currentAIBehaviour?.UpdateBehaviour(dt);
			characterActions.SetValues(currentAIBehaviour.characterActions);
			characterActions.Update(dt);
		}

		protected virtual void Awake()
		{
			characterActions.InitializeActions();
			inputHandlerSettings.Initialize(base.gameObject);
		}

		protected virtual void OnEnable()
		{
			characterActions.InitializeActions();
			characterActions.Reset();
		}

		protected virtual void OnDisable()
		{
			characterActions.Reset();
		}

		private void Start()
		{
			SetBrainType(isAI);
		}

		protected virtual void FixedUpdate()
		{
			firstUpdateFlag = true;
			if (UpdateMode == UpdateModeType.FixedUpdate)
			{
				UpdateBrainValues(0f);
			}
		}

		protected virtual void Update()
		{
			float deltaTime = Time.deltaTime;
			if (UpdateMode == UpdateModeType.FixedUpdate)
			{
				if (firstUpdateFlag)
				{
					firstUpdateFlag = false;
					characterActions.Reset();
				}
			}
			else
			{
				characterActions.Reset();
			}
			UpdateBrainValues(deltaTime);
		}
	}
}
