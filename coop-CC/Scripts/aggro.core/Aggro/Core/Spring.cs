using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

namespace Aggro.Core
{
	public struct Spring
	{
		private float m_posPosCoef;

		private float m_posVelCoef;

		private float m_velPosCoef;

		private float m_velVelCoef;

		public static Spring Create(float angularFrequency, float dampingRatio, float deltaTime)
		{
			Spring result = default(Spring);
			if (dampingRatio < 0f)
			{
				dampingRatio = 0f;
			}
			if (angularFrequency < 0f)
			{
				angularFrequency = 0f;
			}
			if (angularFrequency < 0.0001f)
			{
				result.m_posPosCoef = 1f;
				result.m_posVelCoef = 0f;
				result.m_velPosCoef = 0f;
				result.m_velVelCoef = 1f;
				return result;
			}
			if (dampingRatio > 1.0001f)
			{
				float num = (0f - angularFrequency) * dampingRatio;
				float num2 = angularFrequency * math.sqrt(dampingRatio * dampingRatio - 1f);
				float num3 = num - num2;
				float num4 = num + num2;
				float num5 = math.exp(num3 * deltaTime);
				float num6 = math.exp(num4 * deltaTime);
				float num7 = 1f / (2f * num2);
				float num8 = num5 * num7;
				float num9 = num6 * num7;
				float num10 = num3 * num8;
				float num11 = num4 * num9;
				result.m_posPosCoef = num8 * num4 - num11 + num6;
				result.m_posVelCoef = 0f - num8 + num9;
				result.m_velPosCoef = (num10 - num11 + num6) * num4;
				result.m_velVelCoef = 0f - num10 + num11;
			}
			else if (dampingRatio < 0.9999f)
			{
				float num12 = angularFrequency * dampingRatio;
				float num13 = angularFrequency * math.sqrt(1f - dampingRatio * dampingRatio);
				float num14 = math.exp((0f - num12) * deltaTime);
				float num15 = math.cos(num13 * deltaTime);
				float num16 = math.sin(num13 * deltaTime);
				float num17 = 1f / num13;
				float num18 = num14 * num16;
				float num19 = num14 * num15;
				float num20 = num14 * num12 * num16 * num17;
				result.m_posPosCoef = num19 + num20;
				result.m_posVelCoef = num18 * num17;
				result.m_velPosCoef = (0f - num18) * num13 - num12 * num20;
				result.m_velVelCoef = num19 - num20;
			}
			else
			{
				float num21 = math.exp((0f - angularFrequency) * deltaTime);
				float num22 = deltaTime * num21;
				float num23 = num22 * angularFrequency;
				result.m_posPosCoef = num23 + num21;
				result.m_posVelCoef = num22;
				result.m_velPosCoef = (0f - angularFrequency) * num23;
				result.m_velVelCoef = 0f - num23 + num21;
			}
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Update(float equilibriumPos, ref float pPos, ref float pVel)
		{
			float num = pPos - equilibriumPos;
			float num2 = pVel;
			pPos = num * m_posPosCoef + num2 * m_posVelCoef + equilibriumPos;
			pVel = num * m_velPosCoef + num2 * m_velVelCoef;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Update(Vector3 equilibriumPos, ref Vector3 pPos, ref Vector3 pVel)
		{
			Update(equilibriumPos.x, ref pPos.x, ref pVel.x);
			Update(equilibriumPos.y, ref pPos.y, ref pVel.y);
			Update(equilibriumPos.z, ref pPos.z, ref pVel.z);
		}
	}
}
