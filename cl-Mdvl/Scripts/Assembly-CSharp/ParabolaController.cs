using System.Collections.Generic;
using UnityEngine;

public class ParabolaController : MonoBehaviour
{
	public class ParabolaFly
	{
		public Transform[] Points;

		protected Parabola3D[] parabolas;

		protected float[] partDuration;

		protected float completeDuration;

		public ParabolaFly(Transform ParabolaRoot)
		{
			List<Transform> list = new List<Component>(ParabolaRoot.GetComponentsInChildren(typeof(Transform))).ConvertAll((Component c) => (Transform)c);
			list.Remove(ParabolaRoot.transform);
			list.Sort((Transform a, Transform b) => a.name.CompareTo(b.name));
			Points = list.ToArray();
			if ((Points.Length - 1) % 2 != 0)
			{
				throw new UnityException("ParabolaRoot needs odd number of points");
			}
			if (parabolas == null || parabolas.Length < (Points.Length - 1) / 2)
			{
				parabolas = new Parabola3D[(Points.Length - 1) / 2];
				partDuration = new float[parabolas.Length];
			}
		}

		public Vector3 GetPositionAtTime(float time)
		{
			GetParabolaIndexAtTime(time, out var parabolaIndex, out var timeInParabola);
			float num = timeInParabola / partDuration[parabolaIndex];
			return parabolas[parabolaIndex].GetPositionAtLength(num * parabolas[parabolaIndex].Length);
		}

		public void GetParabolaIndexAtTime(float time, out int parabolaIndex)
		{
			GetParabolaIndexAtTime(time, out parabolaIndex, out var _);
		}

		public void GetParabolaIndexAtTime(float time, out int parabolaIndex, out float timeInParabola)
		{
			timeInParabola = time;
			parabolaIndex = 0;
			while (parabolaIndex < parabolas.Length - 1 && partDuration[parabolaIndex] < timeInParabola)
			{
				timeInParabola -= partDuration[parabolaIndex];
				parabolaIndex++;
			}
		}

		public float GetDuration()
		{
			return completeDuration;
		}

		public Vector3 getHighestPoint(int parabolaIndex)
		{
			return parabolas[parabolaIndex].getHighestPoint();
		}

		public void RefreshTransforms(float speed)
		{
			if (speed <= 0f)
			{
				speed = 1f;
			}
			if (Points == null)
			{
				return;
			}
			completeDuration = 0f;
			for (int i = 0; i < parabolas.Length; i++)
			{
				if (parabolas[i] == null)
				{
					parabolas[i] = new Parabola3D();
				}
				parabolas[i].Set(Points[i * 2].position, Points[i * 2 + 1].position, Points[i * 2 + 2].position);
				partDuration[i] = parabolas[i].Length / speed;
				completeDuration += partDuration[i];
			}
		}
	}

	public class Parabola3D
	{
		public Vector3 A;

		public Vector3 B;

		public Vector3 C;

		protected Parabola2D parabola2D;

		protected Vector3 h;

		protected bool tooClose;

		public float Length { get; private set; }

		public Parabola3D()
		{
		}

		public Parabola3D(Vector3 A, Vector3 B, Vector3 C)
		{
			Set(A, B, C);
		}

		public void Set(Vector3 A, Vector3 B, Vector3 C)
		{
			this.A = A;
			this.B = B;
			this.C = C;
			refreshCurve();
		}

		public Vector3 getHighestPoint()
		{
			float num = (C.y - A.y) / this.parabola2D.Length;
			float num2 = A.y - C.y;
			Parabola2D parabola2D = new Parabola2D(this.parabola2D.a, this.parabola2D.b + num, this.parabola2D.c + num2, this.parabola2D.Length);
			return new Vector3
			{
				y = parabola2D.E.y,
				x = A.x + (C.x - A.x) * (parabola2D.E.x / parabola2D.Length),
				z = A.z + (C.z - A.z) * (parabola2D.E.x / parabola2D.Length)
			};
		}

		public Vector3 GetPositionAtLength(float length)
		{
			float num = length / Length;
			float x = num * (C - A).magnitude;
			if (tooClose)
			{
				x = num * 2f;
			}
			Vector3 result = A * (1f - num) + C * num + h.normalized * parabola2D.f(x);
			if (tooClose)
			{
				result.Set(A.x, result.y, A.z);
			}
			return result;
		}

		private void refreshCurve()
		{
			if (Vector2.Distance(new Vector2(A.x, A.z), new Vector2(B.x, B.z)) < 0.1f && Vector2.Distance(new Vector2(B.x, B.z), new Vector2(C.x, C.z)) < 0.1f)
			{
				tooClose = true;
			}
			else
			{
				tooClose = false;
			}
			Length = Vector3.Distance(A, B) + Vector3.Distance(B, C);
			if (!tooClose)
			{
				refreshCurveNormal();
			}
			else
			{
				refreshCurveClose();
			}
		}

		private void refreshCurveNormal()
		{
			Vector3 vector = ClosestPointInLine(new Ray(A, C - A), B);
			Vector2 a = default(Vector2);
			a.x = 0f;
			a.y = 0f;
			Vector2 b = default(Vector2);
			b.x = Vector3.Distance(A, vector);
			b.y = Vector3.Distance(B, vector);
			Vector2 c = default(Vector2);
			c.x = Vector3.Distance(A, C);
			c.y = 0f;
			parabola2D = new Parabola2D(a, b, c);
			h = (B - vector) / Vector3.Distance(vector, B) * parabola2D.E.y;
		}

		private void refreshCurveClose()
		{
			float num = ((A.y <= B.y) ? 1f : (-1f));
			float num2 = ((A.y <= C.y) ? 1f : (-1f));
			Vector2 a = default(Vector2);
			a.x = 0f;
			a.y = 0f;
			Vector2 b = default(Vector2);
			b.x = 1f;
			b.y = Vector3.Distance((A + C) / 2f, B) * num;
			Vector2 c = default(Vector2);
			c.x = 2f;
			c.y = Vector3.Distance(A, C) * num2;
			parabola2D = new Parabola2D(a, b, c);
			h = Vector3.up;
		}
	}

	public class Parabola2D
	{
		public float a { get; private set; }

		public float b { get; private set; }

		public float c { get; private set; }

		public Vector2 E { get; private set; }

		public float Length { get; private set; }

		public Parabola2D(float a, float b, float c, float length)
		{
			this.a = a;
			this.b = b;
			this.c = c;
			setMetadata();
			Length = length;
		}

		public Parabola2D(Vector2 A, Vector2 B, Vector2 C)
		{
			float num = (A.x - B.x) * (A.x - C.x) * (C.x - B.x);
			if (num == 0f)
			{
				A.x += 1E-05f;
				B.x += 2E-05f;
				C.x += 3E-05f;
				num = (A.x - B.x) * (A.x - C.x) * (C.x - B.x);
			}
			a = (A.x * (B.y - C.y) + B.x * (C.y - A.y) + C.x * (A.y - B.y)) / num;
			b = (A.x * A.x * (B.y - C.y) + B.x * B.x * (C.y - A.y) + C.x * C.x * (A.y - B.y)) / num;
			c = (A.x * A.x * (B.x * C.y - C.x * B.y) + A.x * (C.x * C.x * B.y - B.x * B.x * C.y) + B.x * C.x * A.y * (B.x - C.x)) / num;
			b *= -1f;
			setMetadata();
			Length = Vector2.Distance(A, C);
		}

		public float f(float x)
		{
			return a * x * x + b * x + c;
		}

		private void setMetadata()
		{
			float x = (0f - b) / (2f * a);
			E = new Vector2(x, f(x));
		}
	}

	public float Speed = 1f;

	public GameObject ParabolaRoot;

	public bool Autostart = true;

	public bool Animation = true;

	internal bool nextParbola;

	protected float animationTime = float.MaxValue;

	protected ParabolaFly gizmo;

	protected ParabolaFly parabolaFly;

	private void OnDrawGizmos()
	{
		if (gizmo == null)
		{
			gizmo = new ParabolaFly(ParabolaRoot.transform);
		}
		gizmo.RefreshTransforms(1f);
		if ((gizmo.Points.Length - 1) % 2 == 0)
		{
			int num = 50;
			Vector3 vector = gizmo.Points[0].position;
			for (int i = 1; i <= num; i++)
			{
				float time = (float)i * gizmo.GetDuration() / (float)num;
				Vector3 positionAtTime = gizmo.GetPositionAtTime(time);
				Gizmos.color = new Color((positionAtTime - vector).magnitude * 2f, 0f, 0f, 1f);
				Gizmos.DrawLine(vector, positionAtTime);
				Gizmos.DrawSphere(positionAtTime, 0.01f);
				vector = positionAtTime;
			}
		}
	}

	private void Start()
	{
		parabolaFly = new ParabolaFly(ParabolaRoot.transform);
		if (Autostart)
		{
			RefreshTransforms(Speed);
			FollowParabola();
		}
	}

	private void Update()
	{
		nextParbola = false;
		if (Animation && parabolaFly != null && animationTime < parabolaFly.GetDuration())
		{
			parabolaFly.GetParabolaIndexAtTime(animationTime, out var parabolaIndex);
			animationTime += Time.deltaTime;
			parabolaFly.GetParabolaIndexAtTime(animationTime, out var parabolaIndex2);
			base.transform.position = parabolaFly.GetPositionAtTime(animationTime);
			if (parabolaIndex != parabolaIndex2)
			{
				nextParbola = true;
			}
		}
		else if (Animation && parabolaFly != null && animationTime > parabolaFly.GetDuration())
		{
			animationTime = float.MaxValue;
			Animation = false;
		}
	}

	public void FollowParabola()
	{
		RefreshTransforms(Speed);
		animationTime = 0f;
		base.transform.position = parabolaFly.Points[0].position;
		Animation = true;
	}

	public Vector3 getHighestPoint(int parabolaIndex)
	{
		return parabolaFly.getHighestPoint(parabolaIndex);
	}

	public Transform[] getPoints()
	{
		return parabolaFly.Points;
	}

	public Vector3 GetPositionAtTime(float time)
	{
		return parabolaFly.GetPositionAtTime(time);
	}

	public float GetDuration()
	{
		return parabolaFly.GetDuration();
	}

	public void StopFollow()
	{
		animationTime = float.MaxValue;
	}

	public void RefreshTransforms(float speed)
	{
		parabolaFly.RefreshTransforms(speed);
	}

	public static float DistanceToLine(Ray ray, Vector3 point)
	{
		return Vector3.Cross(ray.direction, point - ray.origin).magnitude;
	}

	public static Vector3 ClosestPointInLine(Ray ray, Vector3 point)
	{
		return ray.origin + ray.direction * Vector3.Dot(ray.direction, point - ray.origin);
	}
}
