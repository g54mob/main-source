using System.Collections;
using System.Collections.Generic;
using MalbersAnimations.Reactions;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[AddComponentMenu("Malbers/AI/AI Animal Link")]
	public class MAIAnimalLink : MonoBehaviour
	{
		public static List<MAIAnimalLink> OffMeshLinks;

		public bool BiDirectional = true;

		[SerializeReference]
		[SubclassSelector]
		public Reaction StartReaction;

		[SerializeReference]
		[SubclassSelector]
		public Reaction EndReaction;

		public Color DebugColor = Color.yellow;

		public float StoppingDistance = 1f;

		public float SlowingDistance = 1f;

		public float SlowingLimit = 0.3f;

		public bool AlignToLink = true;

		public float AlignTime = 0.2f;

		public bool ForwardToVertical;

		[Tooltip("OffMesh Start Link Transform For aligning when the Character is near the start point")]
		[RequiredField]
		public Transform start;

		[Tooltip("OffMesh End Link Transform")]
		[RequiredField]
		public Transform end;

		[Tooltip("Input Axis Mode instead of Direction to Move. Use this for Climb")]
		public bool UseInputAxis;

		public bool debug = true;

		public float SlowMultiplier
		{
			get
			{
				float result = 1f;
				if (SlowingDistance > StoppingDistance && RemainingDistance < SlowingDistance)
				{
					result = Mathf.Max(RemainingDistance / SlowingDistance, SlowingLimit);
				}
				return result;
			}
		}

		public float RemainingDistance { get; private set; }

		protected virtual void OnEnable()
		{
			if (OffMeshLinks == null)
			{
				OffMeshLinks = new List<MAIAnimalLink>();
			}
			OffMeshLinks.Add(this);
		}

		protected virtual void OnDisable()
		{
			OffMeshLinks.Remove(this);
		}

		public virtual void Execute(IAIControl ai, MAnimal animal, Vector3 StartPoint, Vector3 EndPoint)
		{
			animal.StartCoroutine(OffMeshMove(ai, animal, StartPoint, EndPoint));
		}

		public IEnumerator Coroutine_Execute(IAIControl ai, MAnimal animal, Vector3 StartPoint, Vector3 EndPoint)
		{
			yield return OffMeshMove(ai, animal, StartPoint, EndPoint);
		}

		private IEnumerator OffMeshMove(IAIControl ai, MAnimal animal, Vector3 StartPoint, Vector3 EndPoint)
		{
			if (AlignToLink)
			{
				Debbuging("Start alignment with [" + animal.name + "]");
				Transform transform = animal.transform.NearestTransform(start, end);
				yield return MTools.AlignTransform_Rotation(animal.transform, transform.rotation, AlignTime);
				Debbuging("Finish alignment with [" + animal.name + "]");
			}
			StartReaction?.React(animal);
			Debbuging("Start Offmesh Coroutine");
			ai.InOffMeshLink = true;
			ai.AIDirection = StartPoint.DirectionTo(EndPoint);
			RemainingDistance = float.MaxValue;
			while (RemainingDistance >= StoppingDistance && ai.InOffMeshLink)
			{
				Vector3 normalized = (EndPoint - animal.Position).normalized;
				MDebug.Draw_Arrow(animal.Position, normalized, Color.green);
				MDebug.DrawWireSphere(EndPoint, DebugColor, StoppingDistance);
				MDebug.DrawWireSphere(EndPoint, Color.cyan, SlowingDistance);
				if (!UseInputAxis)
				{
					ai.AIDirection = normalized;
					animal.Move(normalized * SlowMultiplier);
				}
				else
				{
					normalized = base.transform.InverseTransformDirection(normalized);
					normalized.z = normalized.y;
					normalized.y = 0f;
					animal.SetInputAxis(normalized * SlowMultiplier);
					animal.UsingMoveWithDirection = false;
				}
				RemainingDistance = Vector3.Distance(animal.transform.position, EndPoint);
				yield return null;
			}
			if (ai.InOffMeshLink)
			{
				EndReaction?.React(animal);
			}
			Debbuging("End Offmesh Coroutine");
			ai.CompleteOffMeshLink();
		}

		private void Debbuging(string valu)
		{
			if (debug)
			{
				Debug.Log("<B>OffMeshLink - [" + base.name + "]</B> -> " + valu, this);
			}
		}
	}
}
