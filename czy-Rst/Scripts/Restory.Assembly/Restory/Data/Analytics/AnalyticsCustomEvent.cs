using System;
using System.Collections.Generic;
using Unity.Services.Analytics;

namespace Restory.Data.Analytics
{
	public class AnalyticsCustomEvent : Event
	{
		public AnalyticsCustomEvent(string name, IEnumerable<IAnalyticsParameter> parameters)
			: base(name)
		{
			foreach (IAnalyticsParameter parameter in parameters)
			{
				if (!(parameter is AnalyticsParameterBool analyticsParameterBool))
				{
					if (!(parameter is AnalyticsParameterString analyticsParameterString))
					{
						if (!(parameter is AnalyticsParameterInt analyticsParameterInt))
						{
							if (!(parameter is AnalyticsParameterFloat analyticsParameterFloat))
							{
								throw new NotImplementedException();
							}
							SetParameter(analyticsParameterFloat.ParameterName, analyticsParameterFloat.ParameterValue);
						}
						else
						{
							SetParameter(analyticsParameterInt.ParameterName, analyticsParameterInt.ParameterValue);
						}
					}
					else
					{
						SetParameter(analyticsParameterString.ParameterName, analyticsParameterString.ParameterValue);
					}
				}
				else
				{
					SetParameter(analyticsParameterBool.ParameterName, analyticsParameterBool.ParameterValue);
				}
			}
		}
	}
}
