using UnityEngine;

namespace XCharts.Runtime
{
	public class InteractData
	{
		private float m_PreviousValue;

		private float m_CurrentValue = float.NaN;

		private float m_TargetValue = float.NaN;

		private Vector3 m_PreviousPosition = Vector3.one;

		private Vector3 m_TargetPosition = Vector3.one;

		private Color32 m_PreviousColor = ColorUtil.clearColor32;

		private Color32 m_TargetColor = ColorUtil.clearColor32;

		private Color32 m_PreviousToColor = ColorUtil.clearColor32;

		private Color32 m_TargetToColor = ColorUtil.clearColor32;

		private float m_UpdateTime;

		private bool m_UpdateFlag;

		private bool m_ValueEnable;

		internal float targetVaue => m_TargetValue;

		internal float previousValue => m_PreviousValue;

		internal bool valueEnable => m_ValueEnable;

		internal bool updateFlag => m_UpdateFlag;

		public override string ToString()
		{
			return $"m_PreviousValue:{m_PreviousValue},m_TargetValue:{m_TargetValue},m_UpdateTime:{m_UpdateTime},m_UpdateFlag:{m_UpdateFlag},m_ValueEnable:{m_ValueEnable},m_PreviousPosition:{m_PreviousPosition},m_TargetPosition:{m_TargetPosition}";
		}

		public void SetValue(ref bool needInteract, float value, bool highlight, float rate = 1.3f)
		{
			value = ((highlight && rate != 0f) ? (value * rate) : value);
			SetValue(ref needInteract, value);
		}

		public void SetValue(ref bool needInteract, float value, bool previousValueZero = false)
		{
			if (m_TargetValue != value)
			{
				needInteract = true;
				if (!m_ValueEnable)
				{
					m_PreviousValue = (previousValueZero ? 0f : value);
				}
				else
				{
					m_PreviousValue = m_CurrentValue;
				}
				UpdateStart();
				m_TargetValue = value;
			}
			else if (m_UpdateFlag)
			{
				needInteract = true;
			}
		}

		public void SetPosition(ref bool needInteract, Vector3 pos)
		{
			if (m_TargetPosition != pos)
			{
				needInteract = true;
				UpdateStart();
				m_PreviousPosition = ((m_TargetPosition == Vector3.one) ? pos : m_TargetPosition);
				m_TargetPosition = pos;
			}
		}

		public void SetColor(ref bool needInteract, Color32 color)
		{
			if (!ChartHelper.IsValueEqualsColor(color, m_TargetColor))
			{
				needInteract = true;
				UpdateStart();
				m_PreviousColor = (ChartHelper.IsClearColor(m_TargetColor) ? color : m_TargetColor);
				m_TargetColor = color;
			}
			else if (m_UpdateFlag)
			{
				needInteract = true;
			}
		}

		public void SetColor(ref bool needInteract, Color32 color, Color32 toColor)
		{
			SetColor(ref needInteract, color);
			if (!ChartHelper.IsValueEqualsColor(toColor, m_TargetToColor))
			{
				needInteract = true;
				UpdateStart();
				m_PreviousToColor = (ChartHelper.IsClearColor(m_TargetToColor) ? color : m_TargetToColor);
				m_TargetToColor = toColor;
			}
		}

		public void SetValueAndColor(ref bool needInteract, float value, Color32 color)
		{
			SetValue(ref needInteract, value);
			SetColor(ref needInteract, color);
		}

		public void SetValueAndColor(ref bool needInteract, float value, Color32 color, Color32 toColor)
		{
			SetValue(ref needInteract, value);
			SetColor(ref needInteract, color, toColor);
		}

		public bool TryGetValue(ref float value, ref bool interacting, float animationDuration = 250f)
		{
			if (!IsValueEnable() || animationDuration == 0f)
			{
				return false;
			}
			if (float.IsNaN(m_TargetValue))
			{
				return false;
			}
			if (m_UpdateFlag && !float.IsNaN(m_PreviousValue))
			{
				float rate = GetRate(animationDuration);
				if (rate < 1f)
				{
					interacting = true;
					value = Mathf.Lerp(m_PreviousValue, m_TargetValue, rate);
					m_CurrentValue = value;
					return true;
				}
				UpdateEnd();
			}
			value = m_TargetValue;
			return true;
		}

		public bool TryGetPosition(ref Vector3 pos, ref bool interacting, float animationDuration = 250f)
		{
			if (!IsValueEnable() || animationDuration == 0f)
			{
				return false;
			}
			if (m_TargetPosition == Vector3.one)
			{
				return false;
			}
			if (m_UpdateFlag && m_PreviousPosition != Vector3.one)
			{
				float rate = GetRate(animationDuration);
				if (rate < 1f)
				{
					interacting = true;
					pos = Vector3.Lerp(m_PreviousPosition, m_TargetPosition, rate);
					return true;
				}
				UpdateEnd();
			}
			pos = m_TargetPosition;
			return true;
		}

		public bool TryGetColor(ref Color32 color, ref bool interacting, float animationDuration = 250f)
		{
			if (!IsValueEnable() || animationDuration == 0f)
			{
				return false;
			}
			if (m_UpdateFlag)
			{
				float rate = GetRate(animationDuration);
				if (rate < 1f)
				{
					interacting = true;
					color = Color32.Lerp(m_PreviousColor, m_TargetColor, rate);
					return true;
				}
				UpdateEnd();
			}
			color = m_TargetColor;
			return true;
		}

		public bool TryGetColor(ref Color32 color, ref Color32 toColor, ref bool interacting, float animationDuration = 250f)
		{
			if (!IsValueEnable() || animationDuration == 0f)
			{
				return false;
			}
			if (m_UpdateFlag)
			{
				float rate = GetRate(animationDuration);
				if (rate < 1f)
				{
					interacting = true;
					color = Color32.Lerp(m_PreviousColor, m_TargetColor, rate);
					toColor = Color32.Lerp(m_PreviousToColor, m_TargetToColor, rate);
					return true;
				}
				UpdateEnd();
			}
			color = m_TargetColor;
			toColor = m_TargetToColor;
			return true;
		}

		public bool TryGetValueAndColor(ref float value, ref Color32 color, ref Color32 toColor, ref bool interacting, float animationDuration = 250f)
		{
			if (!IsValueEnable() || animationDuration == 0f)
			{
				return false;
			}
			if (float.IsNaN(m_TargetValue))
			{
				return false;
			}
			if (m_UpdateFlag && !float.IsNaN(m_PreviousValue))
			{
				float rate = GetRate(animationDuration);
				if (rate < 1f)
				{
					interacting = true;
					value = Mathf.Lerp(m_PreviousValue, m_TargetValue, rate);
					color = Color32.Lerp(m_PreviousColor, m_TargetColor, rate);
					toColor = Color32.Lerp(m_PreviousToColor, m_TargetToColor, rate);
					m_CurrentValue = value;
					return true;
				}
				UpdateEnd();
			}
			value = m_TargetValue;
			color = m_TargetColor;
			toColor = m_TargetToColor;
			return true;
		}

		private float GetRate(float animationDuration)
		{
			float num = Time.time - m_UpdateTime;
			float num2 = animationDuration / 1000f;
			float num3 = num / num2;
			if (num3 > 1f)
			{
				num3 = 1f;
			}
			return num3;
		}

		private void UpdateStart()
		{
			m_ValueEnable = true;
			m_UpdateFlag = true;
			m_UpdateTime = Time.time;
		}

		private void UpdateEnd()
		{
			if (m_UpdateFlag)
			{
				m_UpdateFlag = false;
				m_PreviousColor = m_TargetColor;
				m_PreviousToColor = m_TargetToColor;
				m_PreviousValue = m_TargetValue;
				m_CurrentValue = m_TargetValue;
				m_PreviousPosition = m_TargetPosition;
			}
		}

		public bool TryGetValueAndColor(ref float value, ref Vector3 pos, ref Color32 color, ref Color32 toColor, ref bool interacting, float animationDuration = 250f)
		{
			return TryGetValueAndColor(ref value, ref color, ref toColor, ref interacting, animationDuration) | TryGetPosition(ref pos, ref interacting, animationDuration);
		}

		public bool TryGetValueAndColor(ref float value, ref Vector3 pos, ref bool interacting, float animationDuration = 250f)
		{
			return TryGetValue(ref value, ref interacting, animationDuration) | TryGetPosition(ref pos, ref interacting, animationDuration);
		}

		public void Reset()
		{
			m_UpdateFlag = false;
			m_ValueEnable = false;
			m_TargetValue = float.NaN;
			m_PreviousValue = float.NaN;
			m_CurrentValue = float.NaN;
			m_PreviousPosition = Vector3.one;
			m_TargetPosition = Vector3.one;
			m_TargetColor = ColorUtil.clearColor32;
			m_TargetToColor = ColorUtil.clearColor32;
			m_PreviousColor = ColorUtil.clearColor32;
			m_PreviousToColor = ColorUtil.clearColor32;
		}

		private bool IsValueEnable()
		{
			return m_ValueEnable;
		}
	}
}
