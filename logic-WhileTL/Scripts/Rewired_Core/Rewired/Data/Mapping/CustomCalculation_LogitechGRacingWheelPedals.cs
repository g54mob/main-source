using System;
using Rewired.Utils;
using Rewired.Utils.Classes;
using Rewired.Utils.Classes.Data;

namespace Rewired.Data.Mapping
{
	[Serializable]
	public sealed class CustomCalculation_LogitechGRacingWheelPedals : CustomCalculation
	{
		public enum Mode
		{
			SharedAxis = 0,
			SeparateAxes = 1
		}

		private const TypeWrapper.DataType resultType = TypeWrapper.DataType.Single;

		private const float dead = 0.01f;

		[NonSerialized]
		private Mode rYnNOCYSuSATudkPRacAQabUEePHA;

		TypeWrapper.DataType SerializedMethod.ResultType => TypeWrapper.DataType.Single;

		internal bool SroJTizchUAifuuvWtjdRDDyBGwR()
		{
			bool flag = false;
			ClearResult();
			if (base.DataCount >= 1)
			{
				_result = ysfzQfPqXjKhptxXShYmeziTSJNO();
				flag = true;
			}
			ClearData();
			_resultIsValid = flag;
			return flag;
		}

		private float ysfzQfPqXjKhptxXShYmeziTSJNO()
		{
			if (base.DataCount < 2)
			{
				return 0f;
			}
			float result = _data[0];
			if (_data[0].type != TypeWrapper.DataType.Single)
			{
				return 0f;
			}
			if (_data[1].type != TypeWrapper.DataType.Single)
			{
				return 0f;
			}
			float num = _data[0];
			float num2 = _data[1];
			bEzNyduSRBgrUFhkICUdJxaadubc(num, num2);
			if (rYnNOCYSuSATudkPRacAQabUEePHA == Mode.SharedAxis)
			{
				float oldValue = num2;
				oldValue = MathTools.ValueInNewRange(oldValue, 0f, 1f, 1f, -1f);
				if (oldValue > 0f)
				{
					if (oldValue > 1f || 1f - oldValue <= 0.001f)
					{
						oldValue = 1f;
					}
				}
				else if (oldValue < 0f && (oldValue < -1f || oldValue + 1f <= 0.001f))
				{
					oldValue = -1f;
				}
				result = oldValue;
			}
			else if (rYnNOCYSuSATudkPRacAQabUEePHA == Mode.SeparateAxes)
			{
				result = num;
			}
			return result;
		}

		private void bEzNyduSRBgrUFhkICUdJxaadubc(float P_0, float P_1)
		{
			switch (rYnNOCYSuSATudkPRacAQabUEePHA)
			{
			case Mode.SharedAxis:
				if (MathTools.Abs(P_0) >= 0.01f && MathTools.Abs(P_1) <= 0.01f)
				{
					rYnNOCYSuSATudkPRacAQabUEePHA = Mode.SeparateAxes;
				}
				break;
			case Mode.SeparateAxes:
				if (MathTools.Abs(P_1) >= 0.01f && MathTools.Abs(P_0) <= 0.01f)
				{
					rYnNOCYSuSATudkPRacAQabUEePHA = Mode.SharedAxis;
				}
				break;
			}
		}
	}
}
