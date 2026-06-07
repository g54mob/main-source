using System;
using System.Collections.Generic;

namespace Oculus.Platform.Models
{
	public class CalApplicationSuggestionList : DeserializableList<CalApplicationSuggestion>
	{
		public CalApplicationSuggestionList(IntPtr a)
		{
			int num = (int)(uint)CAPI.ovr_CalApplicationSuggestionArray_GetSize(a);
			_Data = new List<CalApplicationSuggestion>(num);
			for (int i = 0; i < num; i++)
			{
				_Data.Add(new CalApplicationSuggestion(CAPI.ovr_CalApplicationSuggestionArray_GetElement(a, (UIntPtr)(ulong)i)));
			}
		}
	}
}
