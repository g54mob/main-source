using System;
using System.Collections.Generic;
using Aggro.Core;
using Unity.Mathematics;
using UnityEngine;

public class TestBoxSprings : MonoBehaviour
{
	public struct SpringData
	{
		public Vector3 left;

		public Vector3 fwd;

		public Vector3 right;

		public Vector3 back;

		public Vector3 debugLeft1;

		public Vector3 debugLeft2;

		public Vector3 debugFwd1;

		public Vector3 debugFwd2;

		public Vector3 debugRight1;

		public Vector3 debugRight2;

		public Vector3 debugBack1;

		public Vector3 debugBack2;
	}

	public struct BoxSpring : IComparable<BoxSpring>
	{
		public BoxSpringSide side;

		public Vector3 position;

		public BoxSpring(BoxSpringSide side, Vector3 position)
		{
			this.side = side;
			this.position = position;
		}

		public int CompareTo(BoxSpring other)
		{
			return position.y.CompareTo(other.position.y);
		}
	}

	public enum BoxSpringSide
	{
		Left = 0,
		Right = 1,
		Forward = 2,
		Back = 3
	}

	public float frequency;

	public float dampingRatio = 1f;

	public Rigidbody[] boxes;

	public SpringData[] data;

	public bool springsEnabled;

	private void Start()
	{
		data = new SpringData[boxes.Length];
	}

	private void FixedUpdate()
	{
		if (boxes.Length == 0)
		{
			return;
		}
		if (springsEnabled)
		{
			for (int i = 0; i < boxes.Length; i++)
			{
				boxes[i].isKinematic = false;
			}
			List<BoxSpring> positions = new List<BoxSpring>();
			GetGroundedSpringPositions(boxes[0].transform, positions);
			Spring spring = Spring.Create(frequency, dampingRatio, 1f / 60f);
			Vector3 vector = GetPositionFor(BoxSpringSide.Left, positions);
			Vector3 vector2 = GetPositionFor(BoxSpringSide.Right, positions);
			Vector3 vector3 = GetPositionFor(BoxSpringSide.Forward, positions);
			Vector3 vector4 = GetPositionFor(BoxSpringSide.Back, positions);
			for (int j = 0; j < boxes.Length; j++)
			{
				Rigidbody rigidbody = boxes[j];
				Vector3 pPos = rigidbody.transform.TransformPoint(new Vector3(-0.5f, -0.5f, 0f));
				Vector3 pPos2 = rigidbody.transform.TransformPoint(new Vector3(0.5f, -0.5f, 0f));
				Vector3 pPos3 = rigidbody.transform.TransformPoint(new Vector3(0f, -0.5f, 0.5f));
				Vector3 pPos4 = rigidbody.transform.TransformPoint(new Vector3(0f, -0.5f, -0.5f));
				SpringData springData = data[j];
				springData.debugLeft1 = pPos;
				springData.debugLeft2 = vector;
				springData.debugRight1 = pPos2;
				springData.debugRight2 = vector2;
				springData.debugFwd1 = pPos3;
				springData.debugFwd2 = vector3;
				springData.debugBack1 = pPos4;
				springData.debugBack2 = vector4;
				spring.Update(vector, ref pPos, ref springData.left);
				spring.Update(vector2, ref pPos2, ref springData.right);
				spring.Update(vector3, ref pPos3, ref springData.fwd);
				spring.Update(vector4, ref pPos4, ref springData.back);
				rigidbody.AddForceAtPosition(springData.left, vector, ForceMode.VelocityChange);
				rigidbody.AddForceAtPosition(springData.right, vector2, ForceMode.VelocityChange);
				rigidbody.AddForceAtPosition(springData.fwd, vector3, ForceMode.VelocityChange);
				rigidbody.AddForceAtPosition(springData.back, vector4, ForceMode.VelocityChange);
				data[j] = springData;
				vector = pPos + rigidbody.transform.up;
				vector2 = pPos2 + rigidbody.transform.up;
				vector3 = pPos3 + rigidbody.transform.up;
				vector4 = pPos4 + rigidbody.transform.up;
			}
		}
		else
		{
			for (int k = 0; k < boxes.Length; k++)
			{
				boxes[k].isKinematic = true;
			}
		}
	}

	private Vector3 GetPositionFor(BoxSpringSide side, List<BoxSpring> positions)
	{
		for (int i = 0; i < positions.Count; i++)
		{
			BoxSpring boxSpring = positions[i];
			if (boxSpring.side == side)
			{
				return boxSpring.position;
			}
		}
		return Vector3.zero;
	}

	private void OnDrawGizmos()
	{
		if (data != null)
		{
			Gizmos.color = Color.green;
			for (int i = 0; i < data.Length; i++)
			{
				SpringData springData = data[i];
				Gizmos.DrawLine(springData.debugLeft1, springData.debugLeft2);
				Gizmos.DrawLine(springData.debugRight1, springData.debugRight2);
				Gizmos.DrawLine(springData.debugFwd1, springData.debugFwd2);
				Gizmos.DrawLine(springData.debugBack1, springData.debugBack2);
			}
		}
		if (boxes.Length != 0)
		{
			Vector3 item = boxes[0].transform.TransformPoint(new Vector3(-0.5f, -0.5f, 0f));
			Vector3 item2 = boxes[0].transform.TransformPoint(new Vector3(0.5f, -0.5f, 0f));
			Vector3 item3 = boxes[0].transform.TransformPoint(new Vector3(0f, -0.5f, 0.5f));
			Vector3 item4 = boxes[0].transform.TransformPoint(new Vector3(0f, -0.5f, -0.5f));
			List<Vector3> list = new List<Vector3>();
			list.Add(item);
			list.Add(item2);
			list.Add(item3);
			list.Add(item4);
			list.Sort((Vector3 x, Vector3 y) => x.y.CompareTo(y.y));
			Matrix4x4 matrix4x = Matrix4x4.Translate(-list[0]);
			Vector3 vector = list[3] - list[0];
			vector.Normalize();
			Vector3 toDirection = vector;
			toDirection.y = 0f;
			toDirection.Normalize();
			Matrix4x4 matrix4x2 = Matrix4x4.Rotate(Quaternion.FromToRotation(vector, toDirection));
			Matrix4x4 matrix4x3 = matrix4x.inverse * matrix4x2 * matrix4x;
			for (int num = 0; num < list.Count; num++)
			{
				list[num] = matrix4x3 * list[num].XYZW();
			}
			Matrix4x4 matrix4x4 = Matrix4x4.Translate(-list[1]);
			Vector3 vector2 = list[2] - list[1];
			vector2.Normalize();
			Vector3 toDirection2 = vector2;
			toDirection2.y = 0f;
			toDirection2.Normalize();
			Matrix4x4 matrix4x5 = Matrix4x4.Rotate(Quaternion.FromToRotation(vector2, toDirection2));
			Matrix4x4 matrix4x6 = matrix4x4.inverse * matrix4x5 * matrix4x4;
			for (int num2 = 0; num2 < list.Count; num2++)
			{
				list[num2] = matrix4x6 * list[num2].XYZW();
			}
			for (int num3 = 0; num3 < list.Count; num3++)
			{
				list[num3] = new Vector3(list[num3].x, math.max(list[num3].y, 0f), list[num3].z);
			}
			Gizmos.color = Color.cyan;
			for (int num4 = 0; num4 < list.Count; num4++)
			{
				Gizmos.DrawSphere(list[num4], 0.05f);
			}
		}
	}

	private void GetGroundedSpringPositions(Transform boxTransform, List<BoxSpring> positions)
	{
		Vector3 position = boxTransform.TransformPoint(new Vector3(-0.5f, -0.5f, 0f));
		Vector3 position2 = boxTransform.TransformPoint(new Vector3(0.5f, -0.5f, 0f));
		Vector3 position3 = boxTransform.TransformPoint(new Vector3(0f, -0.5f, 0.5f));
		Vector3 position4 = boxTransform.TransformPoint(new Vector3(0f, -0.5f, -0.5f));
		positions.Clear();
		positions.Add(new BoxSpring(BoxSpringSide.Left, position));
		positions.Add(new BoxSpring(BoxSpringSide.Right, position2));
		positions.Add(new BoxSpring(BoxSpringSide.Forward, position3));
		positions.Add(new BoxSpring(BoxSpringSide.Back, position4));
		positions.Sort();
		Matrix4x4 matrix4x = Matrix4x4.Translate(-positions[0].position);
		Vector3 vector = positions[3].position - positions[0].position;
		vector.Normalize();
		Vector3 toDirection = vector;
		toDirection.y = 0f;
		toDirection.Normalize();
		Matrix4x4 matrix4x2 = Matrix4x4.Rotate(Quaternion.FromToRotation(vector, toDirection));
		Matrix4x4 matrix4x3 = matrix4x.inverse * matrix4x2 * matrix4x;
		for (int i = 0; i < positions.Count; i++)
		{
			BoxSpring value = positions[i];
			value.position = matrix4x3 * value.position.XYZW();
			positions[i] = value;
		}
		Matrix4x4 matrix4x4 = Matrix4x4.Translate(-positions[1].position);
		Vector3 vector2 = positions[2].position - positions[1].position;
		vector2.Normalize();
		Vector3 toDirection2 = vector2;
		toDirection2.y = 0f;
		toDirection2.Normalize();
		Matrix4x4 matrix4x5 = Matrix4x4.Rotate(Quaternion.FromToRotation(vector2, toDirection2));
		Matrix4x4 matrix4x6 = matrix4x4.inverse * matrix4x5 * matrix4x4;
		for (int j = 0; j < positions.Count; j++)
		{
			BoxSpring value2 = positions[j];
			value2.position = matrix4x6 * value2.position.XYZW();
			positions[j] = value2;
		}
		for (int k = 0; k < positions.Count; k++)
		{
			BoxSpring value3 = positions[k];
			value3.position = new Vector3(positions[k].position.x, math.max(positions[k].position.y, 0f), positions[k].position.z);
			positions[k] = value3;
		}
	}
}
