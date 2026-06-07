using System;
using System.Collections.Generic;

namespace Oculus.Platform.Models
{
	public class TeamList : DeserializableList<Team>
	{
		public TeamList(IntPtr a)
		{
			int num = (int)(uint)CAPI.ovr_TeamArray_GetSize(a);
			_Data = new List<Team>(num);
			for (int i = 0; i < num; i++)
			{
				_Data.Add(new Team(CAPI.ovr_TeamArray_GetElement(a, (UIntPtr)(ulong)i)));
			}
		}
	}
}
