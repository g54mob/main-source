using System;
using System.Collections.Generic;
using MalbersAnimations.Controller;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.PathCreation
{
	[AddComponentMenu("Malbers/Animal Controller/Path Constraint")]
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/main-components/path-constraint")]
	public class MPathConstraint : MonoBehaviour, IAnimatorListener
	{
		[RequiredField]
		public MAnimal animal;

		public MPath m_Path;

		[Tooltip("It will move automatically when is on a spline, no Input Needed")]
		public BoolReference AutoMove = new BoolReference(value: false);

		[Tooltip("Radius to check if the Character can Enter this path")]
		[Min(0f)]
		public float Radius = 0.5f;

		[Tooltip("Offset of the Radius on the Constraint")]
		public Vector3 Offset = new Vector3(0f, 0.5f, 0f);

		[Tooltip("Forward point to calculate the Path Direction")]
		public float ForwardOffset = 0.3f;

		public float OrientSmoothness = 5f;

		public float AlignSmoothness = 5f;

		public bool debug;

		public GameObjectEvent OnEnterPath = new GameObjectEvent();

		public GameObjectEvent OnExitPath = new GameObjectEvent();

		[HideInInspector]
		[SerializeField]
		private int Editor_Tabs1;

		private float m_PathRootPoint;

		private float m_PathFrontPoint;

		private Vector3 RootPos;

		private Vector3 FrontPos;

		private float Weight;

		private Quaternion StartRotation;

		private Vector3 StartPosition;

		public MPath Path
		{
			get
			{
				return m_Path;
			}
			set
			{
				m_Path = value;
			}
		}

		public MPath NextPath { get; set; }

		public MPath JustEnter { get; set; }

		public MPath JustExit { get; set; }

		public HashSet<MPath> LastPath { get; set; }

		public bool InPath => m_Path != null;

		public bool CanExitOnStart => m_PathRootPoint > m_PathFrontPoint;

		public bool CanExitOnEnd => m_PathRootPoint < m_PathFrontPoint;

		public bool InEndOfThePath
		{
			get
			{
				if (!(m_PathFrontPoint >= 0.999f))
				{
					return m_PathRootPoint >= 0.999f;
				}
				return true;
			}
		}

		public bool InStartOfThePath
		{
			get
			{
				if (!(m_PathFrontPoint <= 0.001f))
				{
					return m_PathRootPoint <= 0.001f;
				}
				return true;
			}
		}

		public Vector3 ContraintPos => base.transform.TransformPoint(Offset);

		public Vector3 RootPathDirection { get; private set; }

		public Vector3 FrontPathDirection { get; private set; }

		Transform IAnimatorListener.transform => base.transform;

		private void Awake()
		{
			if (animal == null)
			{
				animal = this.FindComponent<MAnimal>();
			}
			JustExit = null;
			LastPath = new HashSet<MPath>();
		}

		private void OnEnable()
		{
			MAnimal mAnimal = animal;
			mAnimal.PreStateMovement = (Action<MAnimal>)Delegate.Combine(mAnimal.PreStateMovement, new Action<MAnimal>(PreStateMovement));
			animal.OnStateChange.AddListener(OnStateChange);
			animal.OnModeStart.AddListener(OnModeStart);
			if ((bool)m_Path)
			{
				StartPosition = animal.Position;
				EnterPath(m_Path);
				MoveOnPath(1f);
				animal.Position = StartPosition;
			}
		}

		private void OnStateChange(int ActiveState)
		{
			if (InPath && Path.IgnoreStates != null && Path.IgnoreStates.Contains(animal.ActiveStateID))
			{
				ExitPath();
			}
		}

		private void OnDisable()
		{
			MAnimal mAnimal = animal;
			mAnimal.PreStateMovement = (Action<MAnimal>)Delegate.Remove(mAnimal.PreStateMovement, new Action<MAnimal>(PreStateMovement));
			animal.OnStateChange.RemoveListener(OnStateChange);
			animal.OnModeStart.RemoveListener(OnModeStart);
			if ((bool)Path)
			{
				ExitPath();
			}
		}

		private void OnModeStart(int arg0, int arg1)
		{
			if ((bool)Path && (Path.exitAnyMode.Value || (Path.IgnoreModes != null && Path.IgnoreModes.Contains(animal.ActiveMode.ID))))
			{
				ExitPath();
			}
		}

		private void PreStateMovement(MAnimal animal)
		{
			Weight = Mathf.Clamp01(Mathf.MoveTowards(Weight, InPath ? 1 : 0, animal.DeltaTime * AlignSmoothness));
			if (InPath && (Path.IgnoreStates == null || !Path.IgnoreStates.Contains(animal.ActiveStateID)))
			{
				MoveOnPath(Weight);
			}
		}

		public virtual void TryEnterPath()
		{
			if ((bool)NextPath)
			{
				EnterPath(NextPath);
			}
		}

		public virtual void TryEnterExitPath()
		{
			if (Path != null && NextPath == null)
			{
				if ((bool)Path.CanExitOnMiddle || InEndOfThePath || InStartOfThePath)
				{
					ExitPath();
				}
			}
			else
			{
				TryEnterPath();
			}
		}

		public void EnterPath(MPath path)
		{
			Weight = 0f;
			if (!(Path != path))
			{
				return;
			}
			if (Path != null)
			{
				ExitPath(path);
			}
			if (NextPath == path)
			{
				NextPath = null;
			}
			Path = path;
			JustEnter = path;
			this.Delay_Action(path.pathCooldown, delegate
			{
				JustEnter = null;
			});
			float num = float.MaxValue;
			float num2 = 10f;
			for (int num3 = 1; (float)num3 <= num2; num3++)
			{
				float normalizedTime = (float)num3 / num2;
				Vector3 pointAtTime = Path.Path.GetPointAtTime(normalizedTime);
				MDebug.DrawWireSphere(pointAtTime, Color.cyan, 0.3f, 1f);
				float num4 = Vector3.Distance(pointAtTime, base.transform.position);
				if (num4 < num)
				{
					num = num4;
				}
			}
			Vector3 position = animal.transform.position;
			Vector3 position2 = position + animal.Forward * (ForwardOffset * animal.ScaleFactor);
			m_PathRootPoint = Path.Path.GetClosestTimeOnPath(position);
			m_PathFrontPoint = Path.Path.GetClosestTimeOnPath(position2);
			if (m_PathRootPoint < 0.1f)
			{
				Path.EnterFromStart?.React(animal);
			}
			else if (m_PathRootPoint > 0.9f)
			{
				Path.EnterFromEnd?.React(animal);
			}
			else
			{
				Path.EnterFromMiddle?.React(animal);
			}
			if (Path.DisableStates != null)
			{
				foreach (StateID disableState in Path.DisableStates)
				{
					animal.State_Disable(disableState);
				}
			}
			OnEnterPath.Invoke(Path.gameObject);
			animal.UseCustomRotation = Path.usePathRotation;
			if (path.ActivateState != null)
			{
				animal.State_Force(path.ActivateState);
			}
			path.EnterReaction?.React(animal);
			path.OnEnterPath.Invoke(this);
			Debugging("Enter");
			StartRotation = animal.Rotation;
			StartPosition = animal.Position;
		}

		public void MoveOnPath(float weight)
		{
			if (TryExitPath())
			{
				return;
			}
			float scaleFactor = animal.ScaleFactor;
			Vector3 position = animal.Position;
			Quaternion rotation = animal.Rotation;
			Vector3 position2 = position + animal.Forward * (ForwardOffset * animal.ScaleFactor);
			m_PathRootPoint = Path.Path.GetClosestTimeOnPath(position);
			m_PathFrontPoint = Path.Path.GetClosestTimeOnPath(position2);
			RootPos = Path.Path.GetPointAtTime(m_PathRootPoint);
			FrontPos = Path.Path.GetPointAtTime(m_PathFrontPoint);
			Quaternion pathRotation = Path.Path.GetPathRotation(m_PathRootPoint);
			Vector3 vector = pathRotation * Path.AlignmentOffset;
			RootPathDirection = pathRotation * Vector3.forward;
			Path.PathPosition.SetPositionAndRotation(RootPos, pathRotation);
			Vector3 vector2 = RootPathDirection;
			if ((bool)Path.LockRotation)
			{
				if (Path.FollowDirection == PathFollowDir.None)
				{
					bool flag = Vector3.Dot(animal.Forward, vector2) >= 0f;
					vector2 *= (float)(flag ? 1 : (-1));
				}
				else if (Path.FollowDirection == PathFollowDir.Backward)
				{
					vector2 *= -1f;
				}
			}
			else
			{
				vector2 = (FrontPos - RootPos).normalized;
			}
			Vector3 vector3 = pathRotation * Vector3.up;
			if (debug)
			{
				MDebug.Draw_Arrow(animal.Position, RootPathDirection, Color.cyan);
				MDebug.DrawWireSphere(RootPos + vector, Color.white, 0.1f * scaleFactor);
				MDebug.DrawWireSphere(FrontPos, Color.white, 0.1f * scaleFactor);
				MDebug.DrawWireSphere(RootPos, Color.white, 0.1f * scaleFactor);
				MDebug.Draw_Arrow(RootPos, vector2.normalized, Color.green);
				MDebug.Draw_Arrow(RootPos, vector3.normalized, Color.blue);
			}
			Vector3 vector4 = vector2;
			if (Path.IgnoreVertical)
			{
				Vector3 planeNormal = Vector3.Cross(vector2, animal.UpVector);
				vector4 = Vector3.ProjectOnPlane(Path.LockRotation ? vector2 : animal.Move_Direction, planeNormal).normalized;
			}
			if (Path.IgnoreGrounded)
			{
				animal.Grounded = false;
			}
			Quaternion quaternion = Quaternion.FromToRotation(animal.Forward, vector4) * rotation;
			Quaternion b = Quaternion.Inverse(rotation) * quaternion;
			Quaternion quaternion2 = Quaternion.Slerp(Quaternion.identity, b, OrientSmoothness * Path.OrientSmoothness * animal.DeltaTime);
			float num = Vector3.Dot(animal.Move_Direction, vector2);
			if (weight < 1f)
			{
				animal.Rotation = Quaternion.Lerp(StartRotation, quaternion, weight);
				Vector3 b2 = RootPos + vector;
				if (Path.IgnoreVertical)
				{
					b2.y = StartPosition.y;
				}
				animal.Position = Vector3.Lerp(StartPosition, b2, weight);
				return;
			}
			if (Path.usePathRotation.Value)
			{
				animal.UseCustomRotation = true;
				animal.SlopeNormal = vector3;
				AlignRotation(vector3, animal.DeltaTime, OrientSmoothness);
			}
			if (AutoMove.Value)
			{
				animal.MoveFromDirection(vector2.normalized);
			}
			else if ((bool)Path.LockRotation)
			{
				int num2 = ((num > 0f) ? 1 : (-1));
				if (Mathf.Abs(num) < 0.05f)
				{
					num2 = 0;
				}
				Vector3 movementAxis = new Vector3(0f, 0f, num2);
				animal.SetMovementAxis(movementAxis);
				animal.UseAdditiveRot = false;
				animal.Rotation *= quaternion2;
			}
			else if (num > 0f)
			{
				animal.MoveFromDirection(Path.IgnoreVertical ? vector4 : vector2);
				animal.Rotation *= quaternion2;
			}
			if ((Path.ReachStart && !Path.CanExitOnStart) || (Path.ReachEnd && !Path.CanExitOnEnd))
			{
				animal.MovementAxis.z = 0f;
			}
			Vector3 vector5 = RootPos + vector - position;
			if (Path.IgnoreVertical)
			{
				vector5 = Vector3.ProjectOnPlane(vector5, animal.UpVector);
			}
			vector5 = Vector3.ProjectOnPlane(vector5, Vector3.ProjectOnPlane(vector2, animal.UpVector));
			Vector3 vector6 = Vector3.Lerp(Vector3.zero, vector5, weight);
			animal.Position += vector6;
		}

		public void ExitPath(MPath newPath = null)
		{
			if (Path.DisableStates != null)
			{
				foreach (StateID disableState in Path.DisableStates)
				{
					animal.State_Enable(disableState);
				}
			}
			if ((bool)Path.LockRotation)
			{
				animal.UseAdditiveRot = true;
			}
			if ((bool)Path.usePathRotation)
			{
				animal.UseCustomRotation = false;
			}
			if (newPath == null || ((bool)newPath && !newPath.NoExitPathReactions))
			{
				Path.ExitReaction?.React(animal);
				if (m_PathRootPoint < 0.1f || m_PathFrontPoint < 0.1f)
				{
					Path.ExitFromStart?.React(animal);
				}
				else if (m_PathRootPoint > 0.9f || m_PathFrontPoint > 0.9f)
				{
					Path.ExitFromEnd?.React(animal);
				}
				else
				{
					Path.ExitFromMiddle?.React(animal);
				}
			}
			OnExitPath.Invoke(Path.gameObject);
			Path.OnExitPath.Invoke(this);
			ExitCoolDown(Path);
			animal.CheckIfGrounded();
			LastPath.Add(Path);
			Path = null;
			Weight = 0f;
			Debugging("Exit");
		}

		public virtual bool TryExitPath()
		{
			if ((bool)Path && !Path.IsClosed && !JustEnter && Weight == 1f && !animal.MovementAxisRaw.CloseToZero())
			{
				bool flag;
				bool flag2;
				if (!Path.LockRotation)
				{
					flag = m_PathFrontPoint >= 0.999f;
					flag2 = m_PathFrontPoint <= 0.001f;
				}
				else
				{
					flag = InEndOfThePath;
					flag2 = InStartOfThePath;
				}
				if (flag && !Path.ReachEnd)
				{
					Path.SetEndOfPathEvent(v: true);
				}
				else if (!flag && Path.ReachEnd)
				{
					Path.SetEndOfPathEvent(v: false);
				}
				if (flag2 && !Path.ReachStart)
				{
					Path.SetStartOfPathEvent(v: true);
				}
				else if (!flag2 && Path.ReachStart)
				{
					Path.SetStartOfPathEvent(v: false);
				}
				if ((bool)Path.LockRotation)
				{
					if (Path.FollowDirection == PathFollowDir.None)
					{
						if ((bool)Path.CanExitOnStart && flag2)
						{
							Debugging("Exit on the Path-Start LockRotation");
							ExitPath();
							return true;
						}
						if ((bool)Path.CanExitOnEnd && flag)
						{
							Debugging("Exit on the Path-End LockRotation");
							ExitPath();
							return true;
						}
					}
					else
					{
						float num = Vector3.Dot(RootPathDirection, animal.Move_Direction);
						if (Path.FollowDirection == PathFollowDir.Forward)
						{
							if ((bool)Path.CanExitOnStart && m_PathRootPoint <= 0.001f && num <= 0f)
							{
								Debugging("Exit on the Path-Start LockRotation (FORWARD)");
								ExitPath();
								return true;
							}
							if ((bool)Path.CanExitOnEnd && m_PathFrontPoint >= 0.999f && num >= 0f)
							{
								Debugging("Exit on the Path-End LockRotation (FORWARD)");
								ExitPath();
								return true;
							}
						}
						else
						{
							if ((bool)Path.CanExitOnStart && m_PathFrontPoint <= 0.001f && num <= 0f)
							{
								Debugging("Exit on the Path-Start LockRotation (Backwards)");
								ExitPath();
								return true;
							}
							if ((bool)Path.CanExitOnEnd && m_PathRootPoint >= 0.999f && num >= 0f)
							{
								Debugging("Exit on the Path-End LockRotation (Backwards)");
								ExitPath();
								return true;
							}
						}
					}
					return false;
				}
				if ((bool)Path.CanExitOnStart && m_PathFrontPoint <= 0.001f)
				{
					Debugging("Exit Path on Start");
					ExitPath();
					return true;
				}
				if ((bool)Path.CanExitOnEnd && m_PathFrontPoint >= 0.999f)
				{
					Debugging("Exit Path on End");
					ExitPath();
					return true;
				}
			}
			return false;
		}

		private void ExitCoolDown(MPath mPath)
		{
			JustExit = mPath;
			this.Delay_Action(mPath.pathCooldown, delegate
			{
				JustExit = null;
			});
		}

		public virtual void AlignRotation(Vector3 normal, float time, float Smoothness)
		{
			Quaternion rotation = animal.Rotation;
			Quaternion quaternion = Quaternion.FromToRotation(animal.Up, normal) * animal.Rotation;
			Quaternion b = Quaternion.Inverse(rotation) * quaternion;
			Quaternion quaternion2 = Quaternion.Lerp(Quaternion.identity, b, animal.DeltaTime * Smoothness);
			Debug.DrawRay(animal.Position, normal * 5f);
			Debug.DrawRay(animal.Position, animal.Up * 5f);
			animal.Rotation *= quaternion2;
		}

		public virtual bool OnAnimatorBehaviourMessage(string message, object value)
		{
			return this.InvokeWithParams(message, value);
		}

		public void Debugging(string value)
		{
		}

		private void Reset()
		{
			animal = this.FindComponent<MAnimal>();
		}
	}
}
