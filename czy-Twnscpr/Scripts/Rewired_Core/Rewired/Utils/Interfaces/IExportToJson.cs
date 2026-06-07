using System;
using System.Text;

namespace Rewired.Utils.Interfaces
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal interface IExportToJson
	{
		void WriteJson(StringBuilder stringBuilder, Action<StringBuilder, object> appendValueDelegate);
	}
}
