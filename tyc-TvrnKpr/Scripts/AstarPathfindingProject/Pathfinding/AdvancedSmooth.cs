using System;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
	[Serializable]
	[Obsolete("This modifier is deprecated")]
	[HelpURL("https://arongranberg.com/astar/documentation/stable/advancedsmooth.html")]
	public class AdvancedSmooth : MonoModifier
	{
		[Serializable]
		public class MaxTurn : TurnConstructor
		{
			private Vector3 preRightCircleCenter;

			private Vector3 preLeftCircleCenter;

			private Vector3 rightCircleCenter;

			private Vector3 leftCircleCenter;

			private double vaRight;

			private double vaLeft;

			private double preVaLeft;

			private double preVaRight;

			private double gammaLeft;

			private double gammaRight;

			private double betaRightRight;

			private double betaRightLeft;

			private double betaLeftRight;

			private double betaLeftLeft;

			private double deltaRightLeft;

			private double deltaLeftRight;

			private double alfaRightRight;

			private double alfaLeftLeft;

			private double alfaRightLeft;

			private double alfaLeftRight;

			public override void OnTangentUpdate()
			{
			}

			public override void Prepare(int i, Vector3[] vectorPath)
			{
			}

			public override void TangentToTangent(List<Turn> turnList)
			{
			}

			public override void PointToTangent(List<Turn> turnList)
			{
			}

			public override void TangentToPoint(List<Turn> turnList)
			{
			}

			public override void GetPath(Turn turn, List<Vector3> output)
			{
			}
		}

		[Serializable]
		public class ConstantTurn : TurnConstructor
		{
			private Vector3 circleCenter;

			private double gamma1;

			private double gamma2;

			private bool clockwise;

			public override void Prepare(int i, Vector3[] vectorPath)
			{
			}

			public override void TangentToTangent(List<Turn> turnList)
			{
			}

			public override void GetPath(Turn turn, List<Vector3> output)
			{
			}
		}

		public abstract class TurnConstructor
		{
			public float constantBias;

			public float factorBias;

			public static float turningRadius;

			public const double ThreeSixtyRadians = Math.PI * 2.0;

			public static Vector3 prev;

			public static Vector3 current;

			public static Vector3 next;

			public static Vector3 t1;

			public static Vector3 t2;

			public static Vector3 normal;

			public static Vector3 prevNormal;

			public static bool changedPreviousTangent;

			public abstract void Prepare(int i, Vector3[] vectorPath);

			public virtual void OnTangentUpdate()
			{
			}

			public virtual void PointToTangent(List<Turn> turnList)
			{
			}

			public virtual void TangentToPoint(List<Turn> turnList)
			{
			}

			public virtual void TangentToTangent(List<Turn> turnList)
			{
			}

			public abstract void GetPath(Turn turn, List<Vector3> output);

			public static void Setup(int i, Vector3[] vectorPath)
			{
			}

			public static void PostPrepare()
			{
			}

			public void AddCircleSegment(double startAngle, double endAngle, bool clockwise, Vector3 center, List<Vector3> output, float radius)
			{
			}

			public void DebugCircleSegment(Vector3 center, double startAngle, double endAngle, double radius, Color color)
			{
			}

			public void DebugCircle(Vector3 center, double radius, Color color)
			{
			}

			public double GetLengthFromAngle(double angle, double radius)
			{
				return 0.0;
			}

			public double ClockwiseAngle(double from, double to)
			{
				return 0.0;
			}

			public double CounterClockwiseAngle(double from, double to)
			{
				return 0.0;
			}

			public Vector3 AngleToVector(double a)
			{
				return default(Vector3);
			}

			public double ToDegrees(double rad)
			{
				return 0.0;
			}

			public double ClampAngle(double a)
			{
				return 0.0;
			}

			public double Atan2(Vector3 v)
			{
				return 0.0;
			}
		}

		public struct Turn : IComparable<Turn>
		{
			public float length;

			public int id;

			public TurnConstructor constructor;

			public float score => 0f;

			public Turn(float length, TurnConstructor constructor, int id = 0)
			{
				this.length = 0f;
				this.id = 0;
				this.constructor = null;
			}

			public void GetPath(List<Vector3> output)
			{
			}

			public int CompareTo(Turn t)
			{
				return 0;
			}

			public static bool operator <(Turn lhs, Turn rhs)
			{
				return false;
			}

			public static bool operator >(Turn lhs, Turn rhs)
			{
				return false;
			}
		}

		public float turningRadius;

		public MaxTurn turnConstruct1;

		public ConstantTurn turnConstruct2;

		public override int Order => 0;

		public override void Apply(Path p)
		{
		}

		private void EvaluatePaths(List<Turn> turnList, List<Vector3> output)
		{
		}
	}
}
