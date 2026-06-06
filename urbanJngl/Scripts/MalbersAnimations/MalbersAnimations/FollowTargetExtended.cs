using System;
using System.Collections;
using System.Linq;
using MalbersAnimations.Controller;
using UnityEngine;

namespace MalbersAnimations
{
	[Serializable]
	[AddComponentMenu("Malbers/AI/Follow Target Extended")]
	public class FollowTargetExtended : MonoBehaviour
	{
		public enum TargetType
		{
			[Tooltip("Use the specific target gameobject as target")]
			GameObject = 0,
			[Tooltip("Use the first found gameobject as target which has the specified target tag. Usually the Player tag")]
			MalbersTag = 1
		}

		[Header("Selection")]
		public TargetType type;

		[Tooltip("An optional target tag. If no target is explicitly set, then the target with this specified target name will be used")]
		[Hide("type", new int[] { 1 })]
		public Tag Tag;

		[Tooltip("The target gameobject. Either explicitly specified or defined at start depending on the target tag")]
		[Hide("type", new int[] { 0 })]
		public Transform target;

		[Tooltip("In case the target is instantiated at startup, setting this to true will try to find the target with the specified tag during the Update method")]
		public bool delayedTargetSearch;

		[Header("Speed")]
		public float stopDistance = 3f;

		[Min(0f)]
		public float SlowDistance = 6f;

		[Tooltip("Limit for the Slowing Multiplier to be applied to the Speed Modifier")]
		[Range(0f, 1f)]
		[SerializeField]
		private float slowingLimit = 0.3f;

		private MAnimal animal;

		[Header("Random Position")]
		[Tooltip("Activate having random positions around the target")]
		public bool targetRandomness;

		[Tooltip("Number of seconds at which the target position changes. Use 0 for keeping the initial position")]
		public float updateInterval;

		[Tooltip("Minimum random distance from the target")]
		[Range(0f, 10f)]
		public float randomDistanceMin = 1f;

		[Tooltip("Maximum random distance from the target")]
		[Range(0f, 10f)]
		public float randomDistanceMax = 3f;

		private Vector3 targetDistanceOffset = Vector3.zero;

		[Header("Follow Mode")]
		public bool followEnabled = true;

		public string followToogleKey;

		[Tooltip("Toggle follow mode depending the target being within a given range")]
		public bool followRangeEnabled = true;

		[Tooltip("The range at which the target following is toggled")]
		[Min(0f)]
		public float followRangeDistance = 10f;

		[Header("State Change")]
		[Tooltip("If the Target starts to fly then enable the Fly State on this Animal")]
		public bool flyEnabled = true;

		[Tooltip("Lands at the target if the target isn't flying and the distance is within slow distance")]
		public bool landEnabled = true;

		private bool shouldFollow;

		private ICharacterAction TargetCharacter;

		private float RemainingDistance;

		public float SlowMultiplier
		{
			get
			{
				float result = 1f;
				if (SlowDistance > stopDistance && RemainingDistance < SlowDistance)
				{
					result = Mathf.Max(RemainingDistance / SlowDistance, slowingLimit);
				}
				return result;
			}
		}

		private void OnEnable()
		{
			animal = GetComponentInParent<MAnimal>();
			if (targetRandomness)
			{
				CalculateTargetPositionOffset();
				if (updateInterval > 0f)
				{
					StartCoroutine(UpdateTargetPositionOffset());
				}
			}
			FindTarget();
			if (target != null)
			{
				TargetCharacter = target.GetComponentInParent<ICharacterAction>();
				if (TargetCharacter != null)
				{
					ICharacterAction targetCharacter = TargetCharacter;
					targetCharacter.OnState = (Action<int>)Delegate.Combine(targetCharacter.OnState, new Action<int>(OnTargetStateChanged));
				}
			}
		}

		private void OnDisable()
		{
			animal.Move(Vector3.zero);
			if (TargetCharacter != null)
			{
				ICharacterAction targetCharacter = TargetCharacter;
				targetCharacter.OnState = (Action<int>)Delegate.Remove(targetCharacter.OnState, new Action<int>(OnTargetStateChanged));
			}
			StopAllCoroutines();
		}

		private void OnTargetStateChanged(int state)
		{
			if (flyEnabled && state == StateEnum.Fly)
			{
				animal.State_Activate(StateEnum.Fly);
			}
		}

		private void FindTarget()
		{
			if (type == TargetType.MalbersTag && Tag != null)
			{
				GameObject gameObject = Tags.GambeObjectbyTag(Tag).FirstOrDefault();
				if (gameObject != null)
				{
					target = gameObject.transform;
				}
				else
				{
					Debug.LogWarning("There's no GameObject with the Tag " + Tag.name + " attached on it");
				}
			}
		}

		private void Update()
		{
			if (!target)
			{
				if (delayedTargetSearch)
				{
					FindTarget();
					Debug.Log("Delayed target update. Target = " + target);
				}
				if (!target)
				{
					return;
				}
			}
			if (Input.anyKeyDown && followToogleKey.Length > 0 && Input.inputString == followToogleKey)
			{
				followEnabled = !followEnabled;
				shouldFollow = followEnabled;
			}
			if (followEnabled && followRangeEnabled)
			{
				float num = Vector3.Distance(base.transform.position, target.position);
				shouldFollow = num <= followRangeDistance;
			}
			if (!shouldFollow)
			{
				animal.Move(Vector3.zero);
				return;
			}
			Vector3 vector = target.position;
			if (targetRandomness)
			{
				vector = target.position + targetDistanceOffset;
			}
			Vector3 vector2 = vector - base.transform.position;
			RemainingDistance = Vector3.Distance(base.transform.position, vector);
			animal.Move((RemainingDistance > stopDistance) ? (vector2 * SlowMultiplier) : Vector3.zero);
			if (!flyEnabled)
			{
				return;
			}
			if (RemainingDistance >= SlowDistance && RemainingDistance <= followRangeDistance)
			{
				if (animal.HasState(StateEnum.Fly))
				{
					animal.State_Activate(StateEnum.Fly);
				}
			}
			else if (landEnabled && RemainingDistance <= SlowDistance && (int)animal.activeState.ID == StateEnum.Fly)
			{
				animal.State_Allow_Exit(StateEnum.Fly);
			}
		}

		private IEnumerator UpdateTargetPositionOffset()
		{
			float interval = updateInterval;
			WaitForSeconds timing = new WaitForSeconds(interval);
			while (true)
			{
				if (interval != updateInterval)
				{
					float seconds;
					interval = (seconds = updateInterval);
					timing = new WaitForSeconds(seconds);
				}
				yield return timing;
				CalculateTargetPositionOffset();
			}
		}

		private void CalculateTargetPositionOffset()
		{
			float num = UnityEngine.Random.Range(randomDistanceMin, randomDistanceMax);
			targetDistanceOffset = UnityEngine.Random.insideUnitSphere.normalized * num;
		}
	}
}
