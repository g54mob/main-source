using System;
using ScriptHelpers;
using SimulationScripts.BibiteScripts;
using UnityEngine;

namespace SimulationScripts
{
	public class ProceduralSpriteController : MonoBehaviour
	{
		public SpriteRenderer img;

		public Vector2 segmentPoint;

		public Vector2 tailPoint;

		private float segmentDist = 4.5f;

		private float tailDist = 6.5f;

		private Material mat;

		[SerializeField]
		private BibiteBody body;

		private NEATBrain brain;

		private float baseArmSpeed = MathF.PI * 2f;

		private float baseArmAngle = MathF.PI / 6f;

		private float armAngleAmplitude = MathF.PI / 6f;

		private float leftArmPhase;

		private float rightArmPhase;

		private float leftArmAngle;

		private float rightArmAngle;

		private float leftArmSpeed;

		private float rightArmSpeed;

		private float maxSegmentAngle = 7.5f;

		private float maxTailAngle = 25f;

		private bool visible;

		private static readonly int MiddleSegmentAngle = Shader.PropertyToID("_MiddleSegmentAngle");

		private static readonly int TailAngle = Shader.PropertyToID("_TailAngle");

		private static readonly int ArmAngles = Shader.PropertyToID("_ArmAngles");

		private static readonly int MouthOpenning = Shader.PropertyToID("_MouthOpenning");

		private static readonly int Size = Shader.PropertyToID("_Size");

		private void Start()
		{
			img.material = UnityEngine.Object.Instantiate(img.material);
			mat = img.material;
			brain = body.brain;
			visible = img.isVisible;
		}

		private void OnBecameVisible()
		{
			visible = true;
			Transform transform = body.transform;
			Vector2 vector = transform.up;
			float d1Size = body.d1Size;
			segmentDist = 4.5f * d1Size;
			tailDist = 7.5f * d1Size;
			segmentPoint = (Vector2)transform.localPosition - segmentDist * vector;
			tailPoint = segmentPoint - tailDist * vector;
			mat.SetFloat(MiddleSegmentAngle, 0f);
			mat.SetFloat(TailAngle, 0f);
		}

		private void OnBecameInvisible()
		{
			visible = false;
		}

		private void Update()
		{
			if (visible && !(Time.timeScale <= 0f))
			{
				float d1Size = body.d1Size;
				segmentDist = 4.5f * d1Size;
				tailDist = 7.5f * d1Size;
				mat.SetFloat(Size, Mathf.Max(Mathf.RoundToInt(d1Size * 25f / 2f) * 2 + 1, 13));
				mat.SetFloat(MouthOpenning, brain.Output(NEATBrain.Outputs.Want2Eat));
				Transform obj = body.transform;
				Vector2 vector = obj.localPosition;
				Vector2 vector2 = (segmentPoint - vector).normalized * segmentDist;
				float num = Vector2.SignedAngle(-obj.up, vector2);
				float num2 = Mathf.Sign(num) * Mathf.Max(0f, Mathf.Min(Mathf.Abs(num), maxSegmentAngle) * (1f - 0.5f * Time.deltaTime) - 1f * Time.deltaTime);
				vector2 = vector2.Rotate(MathF.PI / 180f * (num2 - num));
				num = num2;
				segmentPoint = vector + vector2;
				Vector2 vector3 = (tailPoint - segmentPoint).normalized * tailDist;
				float num3 = Vector2.SignedAngle(vector2, vector3);
				num2 = Mathf.Sign(num3) * Mathf.Max(0f, Mathf.Min(Mathf.Abs(num3), maxTailAngle) * (1f - 0.5f * Time.deltaTime) - 1f * Time.deltaTime);
				vector3 = vector3.Rotate(MathF.PI / 180f * (num2 - num3));
				num3 = num2;
				tailPoint = segmentPoint + vector3;
				mat.SetFloat(MiddleSegmentAngle, MathF.PI / 180f * num);
				mat.SetFloat(TailAngle, MathF.PI / 180f * num3);
				float num4 = brain.Output(NEATBrain.Outputs.Rotate);
				float num5 = brain.Output(NEATBrain.Outputs.Accelerate);
				float num6 = rightArmPhase - leftArmPhase;
				if (num6 > MathF.PI)
				{
					num6 -= MathF.PI;
				}
				if (num6 < -MathF.PI)
				{
					num6 += MathF.PI;
				}
				float num7 = baseArmSpeed * (num5 - num4 / 2f) * (1f + (1f - Mathf.Abs(num4)) * num6 / MathF.PI / 4f);
				float num8 = baseArmSpeed * (num5 + num4 / 2f) * (1f - (1f - Mathf.Abs(num4)) * num6 / MathF.PI / 4f);
				leftArmSpeed += (num7 - leftArmSpeed) * (2f * Time.deltaTime);
				rightArmSpeed += (num8 - rightArmSpeed) * (2f * Time.deltaTime);
				leftArmPhase += leftArmSpeed * Time.deltaTime;
				rightArmPhase += rightArmSpeed * Time.deltaTime;
				leftArmAngle = baseArmAngle + armAngleAmplitude * Mathf.Sin(leftArmPhase);
				rightArmAngle = baseArmAngle + armAngleAmplitude * Mathf.Sin(rightArmPhase);
				if (leftArmPhase > MathF.PI * 2f)
				{
					leftArmPhase -= MathF.PI * 2f;
				}
				else if (leftArmPhase < 0f)
				{
					leftArmPhase += MathF.PI * 2f;
				}
				if (rightArmPhase > MathF.PI * 2f)
				{
					rightArmPhase -= MathF.PI * 2f;
				}
				else if (rightArmPhase < 0f)
				{
					rightArmPhase += MathF.PI * 2f;
				}
				mat.SetVector(ArmAngles, new Vector2(-MathF.PI / 2f - leftArmAngle, -MathF.PI / 2f + rightArmAngle));
			}
		}

		private void OnDestroy()
		{
			UnityEngine.Object.Destroy(mat);
		}

		private void OnDrawGizmosSelected()
		{
			Vector2 vector = body.transform.localPosition;
			_ = segmentPoint - vector;
			Gizmos.DrawLine(vector, segmentPoint);
			Gizmos.DrawLine(segmentPoint, tailPoint);
		}
	}
}
