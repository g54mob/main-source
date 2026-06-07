using System;

namespace Simulator
{
	public interface IRuntimeLocaVariable
	{
		string GetLiteralValue();

		bool TryGetIntValue(out int value);

		bool TryGetFloatValue(out float value);

		void SetValue(object value);

		static IRuntimeLocaVariable Create(LocaVariable variable)
		{
			return variable.Type switch
			{
				LocaVariable.EType.INT => new IntRuntimeLocaVariable(variable.Int), 
				LocaVariable.EType.FLOAT => new FloatRuntimeLocaVariable(variable.Float), 
				LocaVariable.EType.STRING => new StringRuntimeLocaVariable(variable.String), 
				_ => throw new NotImplementedException(), 
			};
		}

		static IRuntimeLocaVariable Create(object value)
		{
			if (!(value is int value2))
			{
				if (!(value is float value3))
				{
					if (value is string value4)
					{
						return new StringRuntimeLocaVariable(value4);
					}
					throw new NotImplementedException();
				}
				return new FloatRuntimeLocaVariable(value3);
			}
			return new IntRuntimeLocaVariable(value2);
		}
	}
}
