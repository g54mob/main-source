using UnityEngine;

namespace ToonyColorsPro.Runtime
{
	public class TCP2_GetVertexWavesPosition : MonoBehaviour
	{
		public Transform WaterPlane;

		[Space]
		[Tooltip("Will make the object stick to the water plane")]
		public bool followWaterHeight = true;

		public float heightOffset;

		[Space]
		[Tooltip("Will align the object to the wave normal based on its position")]
		public bool followWaterNormal;

		[Tooltip("Determine the object's up axis (when following wave normal)")]
		public Vector3 upAxis = new Vector3(0f, 1f, 0f);

		[Tooltip("Rotation of the object once it's been affected by the water normal")]
		public Vector3 postRotation = new Vector3(0f, 0f, 0f);

		[Header("Water Shader Configuration")]
		[Space]
		public int sineCount = 1;

		[Space]
		public float WavesSpeed = 2f;

		public float WavesHeight = 0.1f;

		public float WavesFrequency = 1f;

		[Space]
		public bool useCustomTime;

		public bool customSineValues;

		[HideInInspector]
		public Vector4 sinOffsets1 = new Vector4(1f, 2.2f, 0.6f, 1.3f);

		[HideInInspector]
		public Vector4 phaseOffsets1 = new Vector4(1f, 1.3f, 2.2f, 0.4f);

		[HideInInspector]
		public Vector4 sinOffsets2 = new Vector4(0.6f, 1.3f, 3.1f, 2.4f);

		[HideInInspector]
		public Vector4 phaseOffsets2 = new Vector4(2.2f, 0.4f, 3.3f, 2.9f);

		[HideInInspector]
		public Vector4 sinOffsets3 = new Vector4(1.4f, 1.8f, 4.2f, 3.6f);

		[HideInInspector]
		public Vector4 phaseOffsets3 = new Vector4(0.2f, 2.6f, 0.7f, 3.1f);

		[HideInInspector]
		public Vector4 sinOffsets4 = new Vector4(1.1f, 2.8f, 1.7f, 4.3f);

		[HideInInspector]
		public Vector4 phaseOffsets4 = new Vector4(0.5f, 4.8f, 3.1f, 2.3f);

		private static readonly int _Time = Shader.PropertyToID("_Time");

		private static int LastFrameTimeSampling;

		private static float ShaderTime = 0f;

		private void LateUpdate()
		{
			float time;
			if (useCustomTime)
			{
				time = Time.time;
			}
			else
			{
				if (LastFrameTimeSampling < Time.frameCount)
				{
					ShaderTime = Shader.GetGlobalVector(_Time).y;
					LastFrameTimeSampling = Time.frameCount;
				}
				time = ShaderTime;
			}
			if (followWaterHeight)
			{
				Vector3 positionOnWater_SG = GetPositionOnWater_SG2(time, base.transform.position);
				base.transform.position = positionOnWater_SG;
			}
			if (followWaterNormal)
			{
				base.transform.rotation = Quaternion.FromToRotation(upAxis, GetNormalOnWater_SG2(time, base.transform.position));
				base.transform.Rotate(postRotation, Space.Self);
			}
		}

		private Vector4 CalculateSinePosition(float v1, float v2, Vector4 sinOffsets, Vector4 phaseOffsets, ref float phase)
		{
			return new Vector4(Mathf.Sin(v1 * sinOffsets.x + phase * phaseOffsets.x), Mathf.Sin(v1 * sinOffsets.y + phase * phaseOffsets.y), Mathf.Sin(v2 * sinOffsets.z + phase * phaseOffsets.z), Mathf.Sin(v2 * sinOffsets.w + phase * phaseOffsets.w));
		}

		private Vector4 CalculateSineNormal(float v1, float v2, Vector4 sinOffsets, Vector4 phaseOffsets, ref float phase)
		{
			return new Vector4(Mathf.Cos(v1 * sinOffsets.x + phase * phaseOffsets.x) * sinOffsets.x, Mathf.Cos(v1 * sinOffsets.y + phase * phaseOffsets.y) * sinOffsets.y, Mathf.Cos(v2 * sinOffsets.z + phase * phaseOffsets.z) * sinOffsets.z, Mathf.Cos(v2 * sinOffsets.w + phase * phaseOffsets.w) * sinOffsets.w);
		}

		public Vector3 GetPositionOnWater_SG2(float time, Vector3 worldPosition)
		{
			float phase = time * WavesSpeed;
			float num = worldPosition.x * WavesFrequency;
			float num2 = worldPosition.z * WavesFrequency;
			float num3 = WavesHeight * WaterPlane.transform.lossyScale.y;
			float num4 = 0f;
			float num5 = 0f;
			switch (sineCount)
			{
			case 2:
			{
				Vector4 vector7 = CalculateSinePosition(num, num2, sinOffsets1, phaseOffsets1, ref phase);
				num4 = (vector7.x + vector7.y) * num3 / 2f;
				num5 = (vector7.z + vector7.w) * num3 / 2f;
				break;
			}
			case 4:
			{
				Vector4 vector5 = CalculateSinePosition(num, num, sinOffsets1, phaseOffsets1, ref phase);
				Vector4 vector6 = CalculateSinePosition(num2, num2, sinOffsets2, phaseOffsets2, ref phase);
				num4 = (vector5.x + vector5.y + vector5.z + vector5.w) * num3 / 4f;
				num5 = (vector6.x + vector6.y + vector6.z + vector6.w) * num3 / 4f;
				break;
			}
			case 8:
			{
				Vector4 vector = CalculateSinePosition(num, num, sinOffsets1, phaseOffsets1, ref phase);
				Vector4 vector2 = CalculateSinePosition(num2, num2, sinOffsets2, phaseOffsets2, ref phase);
				Vector4 vector3 = CalculateSinePosition(num, num, sinOffsets3, phaseOffsets3, ref phase);
				Vector4 vector4 = CalculateSinePosition(num2, num2, sinOffsets4, phaseOffsets4, ref phase);
				num4 = (vector.x + vector.y + vector.z + vector.w + vector3.x + vector3.y + vector3.z + vector3.w) * num3 / 8f;
				num5 = (vector2.x + vector2.y + vector2.z + vector2.w + vector4.x + vector4.y + vector4.z + vector4.w) * num3 / 8f;
				break;
			}
			case 1:
				num4 = Mathf.Sin(num + phase) * num3;
				num5 = Mathf.Sin(num2 + phase) * num3;
				break;
			}
			worldPosition.y = num4 + num5 + WaterPlane.transform.position.y + heightOffset;
			return worldPosition;
		}

		public Vector3 GetNormalOnWater_SG2(float time, Vector3 worldPosition)
		{
			float phase = time * WavesSpeed;
			float num = worldPosition.x * WavesFrequency;
			float num2 = worldPosition.z * WavesFrequency;
			float num3 = WavesHeight * WaterPlane.transform.lossyScale.y;
			float x = 0f;
			float z = 0f;
			switch (sineCount)
			{
			case 2:
			{
				Vector4 vector7 = CalculateSineNormal(num, num2, sinOffsets1, phaseOffsets1, ref phase);
				x = (vector7.x + vector7.y) * (0f - num3) / 2f;
				z = (vector7.z + vector7.w) * (0f - num3) / 2f;
				break;
			}
			case 4:
			{
				Vector4 vector5 = CalculateSineNormal(num, num, sinOffsets1, phaseOffsets1, ref phase);
				Vector4 vector6 = CalculateSineNormal(num2, num2, sinOffsets2, phaseOffsets2, ref phase);
				x = (vector5.x + vector5.y + vector5.z + vector5.w) * (0f - num3) / 4f;
				z = (vector6.x + vector6.y + vector6.z + vector6.w) * (0f - num3) / 4f;
				break;
			}
			case 8:
			{
				Vector4 vector = CalculateSineNormal(num, num, sinOffsets1, phaseOffsets1, ref phase);
				Vector4 vector2 = CalculateSineNormal(num2, num2, sinOffsets2, phaseOffsets2, ref phase);
				Vector4 vector3 = CalculateSineNormal(num, num, sinOffsets3, phaseOffsets3, ref phase);
				Vector4 vector4 = CalculateSineNormal(num2, num2, sinOffsets4, phaseOffsets4, ref phase);
				x = (vector.x + vector.y + vector.z + vector.w + vector3.x + vector3.y + vector3.z + vector3.w) * (0f - num3) / 8f;
				z = (vector2.x + vector2.y + vector2.z + vector2.w + vector4.x + vector4.y + vector4.z + vector4.w) * (0f - num3) / 8f;
				break;
			}
			case 1:
				x = Mathf.Cos(num + phase) * (0f - num3);
				z = Mathf.Cos(num2 + phase) * (0f - num3);
				break;
			}
			return new Vector3(x, 1f, z).normalized;
		}
	}
}
