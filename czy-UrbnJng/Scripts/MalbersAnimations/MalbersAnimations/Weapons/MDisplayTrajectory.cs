using System;
using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Weapons
{
	[AddComponentMenu("Malbers/Damage/DisplayTrajectory")]
	public class MDisplayTrajectory : MonoBehaviour
	{
		private IThrower Thrower;

		[RequiredField]
		[Tooltip("Reference for the line renderer")]
		public LineRenderer line;

		[Tooltip("Reference to Place a Transform at the End of the Line Renderer")]
		public GameObject HitPoint;

		[Tooltip("Start width of the line renderer")]
		public float StartWidth = 0.3f;

		[Tooltip("End width of the line renderer")]
		public float EndWidth = 0.1f;

		[Tooltip("Start Color of the line renderer")]
		public Color startColor = Color.blue;

		[Tooltip("End Color of the line renderer")]
		public Color endColor = Color.green;

		[Tooltip("Line renderer steps")]
		public float Step = 0.1f;

		[Tooltip("Max Steps")]
		public int MaxSteps = 50;

		private List<Vector3> Trajectory = new List<Vector3>();

		public bool ShowTrayectory { get; set; }

		private void Reset()
		{
			line = GetComponent<LineRenderer>();
			if (line == null)
			{
				line = base.gameObject.AddComponent<LineRenderer>();
			}
			Thrower = GetComponent<IThrower>();
			SetLineRenderer();
		}

		private void OnEnable()
		{
			SetLineRenderer();
			if ((bool)HitPoint && HitPoint.IsPrefab())
			{
				HitPoint = UnityEngine.Object.Instantiate(HitPoint, base.transform);
			}
			if (line.sharedMaterial == null)
			{
				line.material = new Material(Shader.Find("Sprites/Default"));
			}
			if (Thrower == null)
			{
				Thrower = GetComponent<IThrower>();
			}
			if (Thrower != null)
			{
				IThrower thrower = Thrower;
				thrower.Predict = (Action<bool>)Delegate.Combine(thrower.Predict, new Action<bool>(DisplayTraj));
			}
		}

		private void OnDisable()
		{
			if (Thrower != null)
			{
				IThrower thrower = Thrower;
				thrower.Predict = (Action<bool>)Delegate.Remove(thrower.Predict, new Action<bool>(DisplayTraj));
			}
		}

		private void Update()
		{
			if (ShowTrayectory)
			{
				DisplayTrajectory(Thrower.AimOriginPos, Thrower.Velocity);
			}
		}

		private void SetLineRenderer()
		{
			line.startWidth = StartWidth;
			line.endWidth = EndWidth;
			Gradient gradient = new Gradient();
			gradient.SetKeys(new GradientColorKey[2]
			{
				new GradientColorKey(startColor, 0f),
				new GradientColorKey(endColor, 1f)
			}, new GradientAlphaKey[2]
			{
				new GradientAlphaKey(startColor.a, 0f),
				new GradientAlphaKey(endColor.a, 1f)
			});
			line.colorGradient = gradient;
			line.useWorldSpace = true;
			line.receiveShadows = false;
			line.enabled = false;
			line.positionCount = 0;
		}

		private void DisplayTraj(bool show)
		{
			ShowTrayectory = show;
			line.enabled = show;
			if ((bool)HitPoint)
			{
				HitPoint.SetActive(show);
			}
			if (!ShowTrayectory)
			{
				line.enabled = false;
				line.positionCount = 0;
			}
		}

		public virtual void DisplayTrajectory(Vector3 Origin, Vector3 ProjectileVelocity)
		{
			if (ProjectileVelocity == Vector3.zero)
			{
				if ((bool)HitPoint)
				{
					HitPoint.SetActive(value: false);
				}
				line.enabled = false;
				line.positionCount = 0;
				return;
			}
			if ((bool)HitPoint)
			{
				HitPoint.SetActive(value: true);
			}
			line.enabled = true;
			Trajectory = TrajectoryPoints(Origin, ProjectileVelocity);
			DisplayRenderer();
		}

		private List<Vector3> TrajectoryPoints(Vector3 start, Vector3 velocity)
		{
			List<Vector3> list = new List<Vector3>();
			if (Step <= 0f)
			{
				return list;
			}
			list.Add(start);
			Vector3 vector = start;
			RaycastHit hitInfo = new RaycastHit
			{
				normal = Vector3.up
			};
			int num = 0;
			float num2 = 0f;
			for (int i = 1; i < MaxSteps; i++)
			{
				float num3 = Step * (float)i;
				float num4 = Step * (float)(i - num);
				Vector3 vector2 = start + velocity * num3 + num4 * num4 * Thrower.Gravity / 2f;
				if (Physics.Linecast(vector, vector2, out hitInfo, Thrower.Layer, Thrower.TriggerInteraction) && !hitInfo.collider.transform.SameHierarchy(Thrower.Owner.transform))
				{
					list.Add(hitInfo.point);
					break;
				}
				list.Add(vector2);
				Vector3 vector3 = vector2 - vector;
				if (num2 < Thrower.AfterDistance)
				{
					num2 += vector3.magnitude;
					num++;
				}
				vector = vector2;
			}
			if ((bool)HitPoint)
			{
				HitPoint.transform.position = hitInfo.point;
				HitPoint.transform.up = hitInfo.normal;
			}
			return list;
		}

		public void DisplayRenderer()
		{
			for (int i = 1; i < Trajectory.Count; i++)
			{
				Debug.DrawLine(Trajectory[i - 1], Trajectory[i], Color.yellow);
			}
			line.positionCount = Trajectory.Count;
			line.SetPositions(Trajectory.ToArray());
		}
	}
}
