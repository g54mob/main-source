using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MalbersAnimations.Controller;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Animal Controller/Mode Align")]
	public class MModeAlign : MonoBehaviour
	{
		[RequiredField]
		public MAnimal animal;

		[ContextMenuItem("Attack Mode", "AddAttackMode")]
		public List<ModeID> modes = new List<ModeID>();

		[Tooltip("Exclude these abilities when playing the mode")]
		public List<int> ExcludeAbilities = new List<int>();

		[Tooltip("If the Target animal is on any of these states then ignore alignment.")]
		public List<StateID> ignoreStates = new List<StateID>();

		[Tooltip("The animal will keep attacking the current target until the target enters in any of the ignore states")]
		public BoolReference KeepCurrentTarget = new BoolReference(value: true);

		[Tooltip("Search only Tags")]
		public Tag[] Tags;

		public LayerReference Layer = new LayerReference(0);

		[Tooltip("Radius used for the Search")]
		[Min(0f)]
		public float SearchRadius = 2f;

		[Tooltip("Radius used push closer/farther the Target when playing the Mode")]
		[Min(0f)]
		public float Distance;

		[Tooltip("Time needed to complete the Position aligment")]
		[Min(0f)]
		public float AlignTime = 0.3f;

		[Tooltip("Front Offset of the Animal")]
		[Min(0f)]
		public float FrontOffet = 0.15f;

		[Tooltip("Ignore Moving the character if we are already too close to the target. Only aplpy look At rotation")]
		public bool IgnoreClose = true;

		[Tooltip("Align Curve")]
		public AnimationCurve AlignCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		public Color debugColor = new Color(1f, 0.5f, 0f, 0.2f);

		[HideInInspector]
		[SerializeField]
		private int EditorTab;

		public bool debug;

		private MAnimal ClosestAnimal;

		private void Awake()
		{
			if (animal == null)
			{
				animal = this.FindComponent<MAnimal>();
			}
			if (modes == null || modes.Count == 0)
			{
				Debug.LogWarning("Please Add Modes to the Mode Align. ", this);
				base.enabled = false;
			}
			if (ignoreStates == null)
			{
				ignoreStates = new List<StateID>();
			}
		}

		private void OnEnable()
		{
			animal.OnModeStart.AddListener(StartingMode);
		}

		private void OnDisable()
		{
			animal.OnModeStart.RemoveListener(StartingMode);
		}

		private void StartingMode(int ModeID, int ability)
		{
			if (base.isActiveAndEnabled && (modes == null || modes.Count == 0 || (bool)modes.FirstOrDefault((ModeID x) => x.ID == ModeID)) && !ExcludeAbilities.Contains(ability))
			{
				Align();
			}
		}

		public void Align()
		{
			if (!FindAnimals())
			{
				AlignCollider();
			}
		}

		private bool FindAnimals()
		{
			ClosestAnimal = null;
			float num = float.MaxValue;
			Vector3 position = base.transform.position;
			float num2 = SearchRadius * animal.ScaleFactor;
			MDebug.DrawWireSphere(position, Color.red, num2, 1f);
			foreach (MAnimal animal in MAnimal.Animals)
			{
				if (!(animal == this.animal) && !animal.Sleep && animal.enabled && MTools.Layer_in_LayerMask(animal.gameObject.layer, Layer) && animal.gameObject.activeInHierarchy && !ignoreStates.Contains(animal.ActiveStateID) && !this.animal.transform.SameHierarchy(animal.transform))
				{
					Vector3 center = animal.Center;
					float num3 = Vector3.Distance(position, center);
					Debug.DrawRay(position, center - position, Color.red, 2f);
					if (num2 >= num3 && num >= num3)
					{
						num = num3;
						ClosestAnimal = animal;
					}
				}
			}
			if (ClosestAnimal == this.animal)
			{
				ClosestAnimal = null;
			}
			if ((bool)ClosestAnimal)
			{
				if (!GetClosestAITarget(ClosestAnimal.transform))
				{
					Debuging("Alinging to [" + ClosestAnimal.name + "]", this);
				}
				return true;
			}
			return false;
		}

		private void AlignCollider()
		{
			Collider[] array = Physics.OverlapSphere(animal.Center, SearchRadius * animal.ScaleFactor, Layer.Value, QueryTriggerInteraction.Ignore);
			Collider collider = null;
			float num = float.MaxValue;
			Collider[] array2 = array;
			foreach (Collider collider2 in array2)
			{
				if (!collider2.transform.SameHierarchy(animal.transform) && (Tags == null || Tags.Length == 0 || collider2.gameObject.HasMalbersTagInParent(Tags)) && collider2.gameObject.activeInHierarchy && !collider2.gameObject.isStatic && !collider2.GetComponentInParent<MAnimal>() && collider2.enabled)
				{
					float num2 = Vector3.Distance(base.transform.position, collider2.transform.position);
					if (num > num2)
					{
						num = num2;
						collider = collider2;
					}
				}
			}
			if ((bool)collider && !GetClosestAITarget(collider.transform))
			{
				Debuging("[" + base.name + "], Alinging to [" + collider.name + "]", this);
			}
		}

		private bool GetClosestAITarget(Transform target)
		{
			Vector3 targetCenter = target.position;
			Vector3 position = animal.Position;
			float num = SearchRadius * animal.ScaleFactor;
			IObjectCore componentInParent = target.GetComponentInParent<IObjectCore>();
			if (componentInParent != null)
			{
				target = componentInParent.transform;
			}
			IAITarget[] array = target.FindInterfaces<IAITarget>();
			IAITarget iAITarget = null;
			float num2 = float.MaxValue;
			if (array != null)
			{
				if (array.Length == 1)
				{
					iAITarget = array[0];
					targetCenter = iAITarget.GetCenterPosition(-1);
				}
				else
				{
					IAITarget[] array2 = array;
					foreach (IAITarget iAITarget2 in array2)
					{
						if (iAITarget2.transform.gameObject.activeInHierarchy)
						{
							float num3 = Vector3.Distance(position, iAITarget2.GetCenterPosition(-1));
							if (num >= num3 && num2 >= num3)
							{
								num2 = num3;
								targetCenter = iAITarget2.GetCenterPosition(-1);
								iAITarget = iAITarget2;
							}
						}
					}
				}
			}
			StartAligning(targetCenter, iAITarget);
			return iAITarget != null;
		}

		private void StartAligning(Vector3 TargetCenter, IAITarget isAI)
		{
			StopAllCoroutines();
			if (!animal.FreeMovement)
			{
				TargetCenter.y = animal.transform.position.y;
			}
			float num = Distance * animal.ScaleFactor;
			if (isAI != null)
			{
				num = isAI.StopDistance();
				if (Distance == 0f)
				{
					num = 0f;
				}
				TargetCenter = isAI.GetCenterPosition();
				Debuging(" Alinging <B>AI Target</B> [" + isAI.transform.name + "]. Mode Align", this);
			}
			if (debug)
			{
				float num2 = 1f;
				MDebug.DrawLine(base.transform.position, TargetCenter, Color.white, num2);
				MDebug.DrawWireSphere(TargetCenter, Quaternion.identity, 0.1f, Color.white, num2);
				if (animal.FreeMovement)
				{
					MDebug.DrawWireSphere(TargetCenter, Quaternion.identity, num, Color.white, num2);
				}
				else
				{
					MDebug.DrawCircle(TargetCenter, Quaternion.identity, num, Color.white, num2);
				}
				MDebug.DrawRay(TargetCenter, Vector3.up, Color.white, num2);
			}
			if (num > 0f)
			{
				num += FrontOffet * animal.ScaleFactor;
				StartCoroutine(MTools.AlignLookAtTransform(animal.transform, TargetCenter, AlignTime, AlignCurve));
				float num3 = Vector3.Distance(animal.Center, TargetCenter);
				MDebug.DrawLine(animal.Center, TargetCenter, Color.yellow, 2f);
				if (!IgnoreClose || !(num3 < num))
				{
					StartCoroutine(MTools.AlignTransformRadius(animal.transform, TargetCenter, AlignTime, num, AlignCurve));
				}
			}
			else
			{
				StartCoroutine(AlignLookAtTransform(animal.transform, TargetCenter, FrontOffet, AlignTime, animal.ScaleFactor, AlignCurve));
			}
		}

		private void Debuging(string deb, Object ob)
		{
			if (debug)
			{
				Debug.Log("<B>[" + animal.name + "]</B> " + deb, ob);
			}
		}

		public IEnumerator AlignLookAtTransform(Transform t1, Vector3 target, float AlignOffset, float time, float scale, AnimationCurve AlignCurve)
		{
			float elapsedTime = 0f;
			WaitForFixedUpdate wait = new WaitForFixedUpdate();
			Quaternion CurrentRot = t1.rotation;
			Vector3 vector = target - t1.position;
			vector = Vector3.ProjectOnPlane(vector, t1.up);
			Quaternion FinalRot = Quaternion.LookRotation(vector);
			Vector3 Offset = t1.position + AlignOffset * scale * t1.forward;
			if (AlignOffset != 0f)
			{
				Quaternion deltaRotation = Quaternion.Inverse(t1.rotation) * FinalRot;
				Vector3 vector2 = t1.position + t1.DeltaPositionFromRotate(Offset, deltaRotation);
				vector = target - vector2;
				float num = 3f;
				if (debug)
				{
					MDebug.Draw_Arrow(vector2, vector, Color.yellow, num);
					MDebug.DrawWireSphere(vector2, 0.1f, Color.green, num);
					MDebug.DrawWireSphere(target, 0.1f, Color.yellow, num);
				}
				vector = Vector3.ProjectOnPlane(vector, t1.up);
			}
			if (vector.CloseToZero())
			{
				Debug.LogWarning("Direction is Zero. Please set a correct rotation", t1);
				yield return null;
				yield break;
			}
			vector = Vector3.ProjectOnPlane(vector, t1.up);
			FinalRot = Quaternion.LookRotation(vector);
			Quaternion Last_Platform_Rot = t1.rotation;
			while (time > 0f && elapsedTime <= time)
			{
				float t2 = AlignCurve?.Evaluate(elapsedTime / time) ?? (elapsedTime / time);
				t1.rotation = Quaternion.SlerpUnclamped(CurrentRot, FinalRot, t2);
				if (AlignOffset != 0f)
				{
					Quaternion deltaRotation2 = Quaternion.Inverse(Last_Platform_Rot) * t1.rotation;
					t1.position += t1.DeltaPositionFromRotate(Offset, deltaRotation2);
				}
				elapsedTime += Time.fixedDeltaTime;
				Last_Platform_Rot = t1.rotation;
				if (debug)
				{
					MDebug.DrawRay(Offset, Vector3.up, Color.white);
					MDebug.DrawWireSphere(t1.position, t1.rotation, 0.05f * scale, Color.white, 0.2f);
					MDebug.DrawWireSphere(t1.position, t1.rotation, 0.05f * scale, Color.white, 0.2f);
					MDebug.DrawWireSphere(Offset, 0.05f * scale, Color.white, 0.2f);
					MDebug.Draw_Arrow(t1.position, t1.forward, Color.white, 0.2f);
				}
				yield return wait;
			}
		}
	}
}
