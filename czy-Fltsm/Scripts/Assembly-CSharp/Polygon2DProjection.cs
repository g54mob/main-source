using System.Collections.Generic;
using PajamaLlama.Math;
using UnityEngine;

public struct Polygon2DProjection
{
	internal Vector2 axis;

	internal float min;

	internal float max;

	internal Polygon2DProjection(Vector2 axis, float min, float max)
	{
		this.axis = axis;
		this.min = min;
		this.max = max;
	}

	internal bool ReturnOverlap(Polygon2DProjection other)
	{
		if (!(other.max < min))
		{
			return !(max < other.min);
		}
		return false;
	}

	internal bool ReturnOverlap(int other_min, int other_max)
	{
		if (!((float)other_max < min))
		{
			return !(max < (float)other_min);
		}
		return false;
	}

	internal bool ReturnOverlap(float scalar)
	{
		if (!(scalar < min))
		{
			return !(max < scalar);
		}
		return false;
	}

	internal bool ReturnOverlap(float scalar, float marginOfError)
	{
		float num = min - marginOfError;
		float num2 = max + marginOfError;
		if (!(scalar < num))
		{
			return !(num2 < scalar);
		}
		return false;
	}

	internal bool ReturnOverlap(Polygon2DBase polygon)
	{
		Vector2 vertex = polygon.GetVertex(0);
		float num = axis.x * vertex.x + axis.y * vertex.y;
		float num2 = num;
		float num3 = num;
		int vertexCount = polygon.VertexCount;
		for (int i = 1; i < vertexCount; i++)
		{
			vertex = polygon.GetVertex(i);
			num = axis.x * vertex.x + axis.y * vertex.y;
			if (num < num2)
			{
				num2 = num;
			}
			else if (num3 < num)
			{
				num3 = num;
			}
		}
		if (!(num3 < min))
		{
			return !(max < num2);
		}
		return false;
	}

	internal bool ReturnOverlapWithTolerance(Polygon2DBase polygon)
	{
		Vector2 vertex = polygon.GetVertex(0);
		float num = axis.x * vertex.x + axis.y * vertex.y;
		float num2 = num;
		float num3 = num;
		int vertexCount = polygon.VertexCount;
		for (int i = 1; i < vertexCount; i++)
		{
			vertex = polygon.GetVertex(i);
			num = axis.x * vertex.x + axis.y * vertex.y;
			if (num < num2)
			{
				num2 = num;
			}
			else if (num3 < num)
			{
				num3 = num;
			}
		}
		bool num4 = num3 <= min || MathExtensions.Approximately(num3, min);
		bool flag = max < num2 || MathExtensions.Approximately(max, num2);
		return !(num4 || flag);
	}

	internal bool ReturnOverlap(List<Vector2> polygon, bool includeTolerance = false)
	{
		Vector2 vector = polygon[0];
		float num = axis.x * vector.x + axis.y * vector.y;
		float num2 = num;
		float num3 = num;
		int count = polygon.Count;
		for (int i = 1; i < count; i++)
		{
			vector = polygon[i];
			num = axis.x * vector.x + axis.y * vector.y;
			if (num < num2)
			{
				num2 = num;
			}
			else if (num3 < num)
			{
				num3 = num;
			}
		}
		if (includeTolerance)
		{
			bool num4 = num3 <= min || MathExtensions.Approximately(num3, min);
			bool flag = max < num2 || MathExtensions.Approximately(max, num2);
			return !(num4 || flag);
		}
		if (!(num3 < min))
		{
			return !(max < num2);
		}
		return false;
	}

	internal bool ReturnOverlap(Vector2[] polygon, bool includeTolerance = false)
	{
		Vector2 vector = polygon[0];
		float num = axis.x * vector.x + axis.y * vector.y;
		float num2 = num;
		float num3 = num;
		int num4 = polygon.Length;
		for (int i = 1; i < num4; i++)
		{
			vector = polygon[i];
			num = axis.x * vector.x + axis.y * vector.y;
			if (num < num2)
			{
				num2 = num;
			}
			else if (num3 < num)
			{
				num3 = num;
			}
		}
		if (includeTolerance)
		{
			bool num5 = num3 <= min || MathExtensions.Approximately(num3, min);
			bool flag = max < num2 || MathExtensions.Approximately(max, num2);
			return !(num5 || flag);
		}
		if (!(num3 < min))
		{
			return !(max < num2);
		}
		return false;
	}

	internal bool ReturnOverlap(Vector2 vertexMin, Vector2 vertexMax)
	{
		float num = axis.x * vertexMin.x + axis.y * vertexMax.y;
		float num2 = num;
		float num3 = num;
		num = axis.x * vertexMax.x + axis.y * vertexMax.y;
		num2 = ((num < num2) ? num : num2);
		num3 = ((num3 < num) ? num : num3);
		num = axis.x * vertexMax.x + axis.y * vertexMin.y;
		num2 = ((num < num2) ? num : num2);
		num3 = ((num3 < num) ? num : num3);
		num = axis.x * vertexMin.x + axis.y * vertexMin.y;
		num2 = ((num < num2) ? num : num2);
		num3 = ((num3 < num) ? num : num3);
		if (!(num3 < min))
		{
			return !(max < num2);
		}
		return false;
	}
}
