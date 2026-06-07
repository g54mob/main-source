using Lightbug.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace Lightbug.CharacterControllerPro.Core
{
	[DefaultExecutionOrder(10)]
	[AddComponentMenu("Character Controller Pro/Core/Character Debug")]
	public class CharacterDebug : MonoBehaviour
	{
		[SerializeField]
		private CharacterActor characterActor;

		[Header("Character Info")]
		[SerializeField]
		private Text text;

		[Header("Events")]
		[SerializeField]
		private bool printEvents;

		[Header("Stability")]
		[SerializeField]
		private Renderer stabilityIndicator;

		[Condition("stabilityIndicator", ConditionAttribute.ConditionType.IsNotNull, ConditionAttribute.VisibilityType.NotEditable, 0f)]
		[SerializeField]
		private Color stableColor = new Color(0f, 1f, 0f, 0.5f);

		[Condition("stabilityIndicator", ConditionAttribute.ConditionType.IsNotNull, ConditionAttribute.VisibilityType.NotEditable, 0f)]
		[SerializeField]
		private Color unstableColor = new Color(1f, 0f, 0f, 0.5f);

		private int colorID = Shader.PropertyToID("_Color");

		private float time;

		private void UpdateCharacterInfoText()
		{
			if (!(text == null))
			{
				if (time > 0.2f)
				{
					text.text = characterActor.GetCharacterInfo();
					time = 0f;
				}
				else
				{
					time += Time.deltaTime;
				}
			}
		}

		private void OnWallHit(Contact contact)
		{
			Debug.Log("OnWallHit");
		}

		private void OnGroundedStateEnter(Vector3 localVelocity)
		{
			Debug.Log("OnEnterGroundedState, localVelocity : " + localVelocity.ToString("F3"));
		}

		private void OnGroundedStateExit()
		{
			Debug.Log("OnExitGroundedState");
		}

		private void OnStableStateEnter(Vector3 localVelocity)
		{
			Debug.Log("OnStableStateEnter, localVelocity : " + localVelocity.ToString("F3"));
		}

		private void OnStableStateExit()
		{
			Debug.Log("OnStableStateExit");
		}

		private void OnHeadHit(Contact contact)
		{
			Debug.Log("OnHeadHit");
		}

		private void OnTeleportation(Vector3 position, Quaternion rotation)
		{
			Debug.Log("OnTeleportation, position : " + position.ToString("F3") + " and rotation : " + rotation.ToString("F3"));
		}

		private void FixedUpdate()
		{
			if (characterActor == null)
			{
				base.enabled = false;
			}
			else
			{
				UpdateCharacterInfoText();
			}
		}

		private void Update()
		{
			if (stabilityIndicator != null)
			{
				stabilityIndicator.material.SetColor(colorID, characterActor.IsStable ? stableColor : unstableColor);
			}
		}

		private void OnEnable()
		{
			if (printEvents)
			{
				characterActor.OnHeadHit += OnHeadHit;
				characterActor.OnWallHit += OnWallHit;
				characterActor.OnGroundedStateEnter += OnGroundedStateEnter;
				characterActor.OnGroundedStateExit += OnGroundedStateExit;
				characterActor.OnStableStateEnter += OnStableStateEnter;
				characterActor.OnStableStateExit += OnStableStateExit;
				characterActor.OnTeleport += OnTeleportation;
			}
		}

		private void OnDisable()
		{
			if (printEvents)
			{
				characterActor.OnHeadHit -= OnHeadHit;
				characterActor.OnWallHit -= OnWallHit;
				characterActor.OnGroundedStateEnter -= OnGroundedStateEnter;
				characterActor.OnGroundedStateExit -= OnGroundedStateExit;
				characterActor.OnStableStateEnter += OnStableStateEnter;
				characterActor.OnStableStateExit += OnStableStateExit;
				characterActor.OnTeleport -= OnTeleportation;
			}
		}
	}
}
