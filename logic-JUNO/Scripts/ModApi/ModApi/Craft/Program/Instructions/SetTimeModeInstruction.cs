using System;
using System.Collections.Generic;
using ModApi.Craft.Program.Craft;

namespace ModApi.Craft.Program.Instructions
{
	[Serializable]
	public class SetTimeModeInstruction : ProgramInstruction
	{
		[ProgramNodeProperty]
		private TimeModeType _mode = TimeModeType.Normal;

		public override ProgramInstruction Execute(IThreadContext context)
		{
			context.Craft.TimeMode = _mode;
			return base.Execute(context);
		}

		public override List<ListItemInfo> GetListItems(string listId)
		{
			List<ListItemInfo> list = new List<ListItemInfo>();
			foreach (object value in Enum.GetValues(typeof(TimeModeType)))
			{
				string text = value.ToString();
				list.Add(new ListItemInfo(text, text, string.Empty, ListItemInfoType.None));
			}
			return list;
		}

		public override string GetListValue(string listId)
		{
			return _mode.ToString();
		}

		public override void SetListValue(string listId, string value)
		{
			TimeModeType result = TimeModeType.Normal;
			Enum.TryParse<TimeModeType>(value, out result);
			_mode = result;
		}
	}
}
